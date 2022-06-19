using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Gaming.Input;

namespace Robot
{

    public partial class Form1 : Form
    {

        //dodanie odpowiednich obiektów
        Gamepad Controller;
        Kinematyka Kin = new Kinematyka(38, 30, 15, 10, 0, 30, 30, 90);

        //stringi zawieracące pojedyńcze linie z napisanego kodu
        string[] single_Line_Code;
        //stringi zawierające same instrukcje
        string[] only_instructions = new string[100];
        //stringi zawierające parametry do instrukcji
        string[] only_parameters = new string[100];

        //zmienna przechowująca ilość instrukcji 
        int instruction_lines_count;
        //string przechwywujący bierzącą instrukcję
        string current_instruction;
        //string przechowujący bierzący parametr
        string current_parameter;
        //zmienna określająca numer wykonywanej instrukcji
        int current_instruction_number = 0;

        //zmienna określająca czy dalej jest wykonywana konkretna instrukcja
        int state_of_code = 0;

        //zmienna przechowująca wartość kroku
        double step = 0;

        //bazowe ustawienie prędkości na minimalną wartość
        double speed = 1;

        //zmienne przechowujące dane dla pozycji startowej robota
        double start_X, start_Y, start_Z, start_epsilon;

        //zmienna przechowująca długość wektora łączącego dwa punkty między którymi zachodzi funkcja MVS
        double vector_length;

        //zmienne przechowujące dane o współrzędnych punktu docelowego
        double goal_x, goal_y, goal_z, goal_epsilon;

        //stała przechowująca częstotliwość zegra odpowiedzialnego za ruch
        const int freq = 100;

        //bazowa wartosc kroku (w cm)
        double delta_s = 0;

        //zmienna określająca długość rampy przyspieszenia (s)
        double acceleration_time = 0.5;

        //zmienna przechowująca ilość pętli koniecznych do uzyskania acceleration_time (acceleration_perioids = acceleration_time*freq)
        int acceleration_perioids = 50;

        //zmiena przechowująca wartość bierzącego wywołania zdarzenia 
        int current_perioid = 1;

        //zmienna określająca czy prędkość ma rosnąć czy maleć
        bool czy_przyspieszasz = true;

        //zmiena określająca czy jesteśmy w pierwszym wywołaniu mvs
        bool czy_to_pierwsze_powtorzenie = true;

        //zmienna tekstowa przechowująca informację o wysyłanej instrukcji
        String instruction_for_uC = "0";

        //zmienna będąca licznikiem ilości wysłanej instrukcji find_position
        uint instruction_send_count = 0;

        //stałem pomocnicze do odczytu danych
        const int point_name_column = 0;
        const int X_column = 1;
        const int Y_column = 2;
        const int Z_column = 3;
        const int epsilon_column = 4;

        //zmiennna przechowująca informację o tym który punkt jest akltualnie wykorzystywany w funkcji MOV
        int current_point;

        //zmienna przechowująca ilość wykonanych pętli w funkcji DLY
        int time_counter = 0;

        //zmienna logiczna odpowiedzialna za umożliwienie sterowania z poziomu gamepada
        bool is_gamepad_enable = false;

        //funkcja wyszukująca punktu przypisanego jako parametr do danej instrukcji pośród wszystkich punktów w bazie
        public int find_current_point()
        {
            for (int i = 0; i < pointsDataGridView.RowCount; ++i)
            {
                if (pointsDataGridView[point_name_column, i].Value.ToString() == current_parameter)
                {
                    return i;
                }
            }
            return 0;

        }



        public Form1()
        {
            InitializeComponent();
            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;

            //odczytanie dostępnych portów oraz wyświetlenie ich w rozwijanej liście
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);

            //wyłączenie przycisków connect oraz disconnect przy starcie programu
            connectButton.Enabled = false;
            disconnectButton.Enabled = false;
            start_program_button.Enabled = false;
            stop_program_button.Enabled = false;
            reset_program_button.Enabled = false;
            compileButton.Enabled = true;
            find_reference_button.Enabled = false;



        }



        class Kinematyka
        {
            double radian = Math.PI / 180.0;
            double stopnie = 180.0 / Math.PI;
            //zmienne odpowiedzialne za długości poszczególnych stopni ramienia
            double d4 = 10;
            double d1 = 38;
            double d2 = 30;
            double d3 = 15;

            //zmienne odpowiedzialne za położenie efektora
            public double X = 0;
            public double Y = 30;
            public double Z = 30;
            public double epsilon = 90;

            //zmienne pomocnicze do obliczeń
            double R, h, m, p;

            //zmienne przechowujące dane o kątach
            double alfa, beta, gamma, sigma, fi, ro, theta;

            //zmienne końcowe
            public double kat0, kat1, kat2, kat3;

            //zmienne do kopensacji
            public double s1, s2, s3;

            
            public Kinematyka(float d1_, float d2_, float d3_, float d4_, float x, float y, float z, float EPSILON)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
                this.d1 = d1_;
                this.d2 = d2_;
                this.d3 = d3_;
                this.d4 = d4_;
                this.epsilon = EPSILON;
            }

            public void oblicz()
            {
                R = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
                h = Z - d4 + (d3 * Math.Sin(epsilon * radian));
                p = R - (d3 * Math.Cos(epsilon * radian));
                m = Math.Sqrt(Math.Pow(h, 2) + Math.Pow(p, 2));

                alfa = stopnie * Math.Atan(h / p);
                beta = stopnie * Math.Acos((Math.Pow(d1, 2) + Math.Pow(m, 2) - Math.Pow(d2, 2)) / (2 * d1 * m));
                gamma = stopnie * Math.Acos((Math.Pow(d1, 2) + Math.Pow(d2, 2) - Math.Pow(m, 2)) / (2 * d1 * d2));
                sigma = 180 - beta - gamma;
                fi = 90 - alfa;
                ro = 90 + epsilon - fi - sigma;
                theta = stopnie * Math.Atan(Y / X);
                
                if (X < 0)
                {
                    kat0 = theta + 180;
                }
                else
                {
                    kat0 = theta;
                }

               
                kat1 = alfa + beta + 90;

                s1 = kat1;
                s2 = gamma;
                s3 = ro;

                //kompensacja kątów
                kat2 = s2 - s1 * 40 / 48;
                kat3 = s3 + s1 * 40 / 48 - s2;
                

            }

            public bool point_in_range_check(double xx, double yy, double zz, double ee)
            {
                //zmienne pomocnicze do obliczeń
                double R_, h_, m_, p_;
                R_ = Math.Sqrt(Math.Pow(xx, 2) + Math.Pow(yy, 2));
                h_ = zz - d4 + (d3 * Math.Sin(ee * radian));
                p_ = R_ - (d3 * Math.Cos(ee * radian));
                m_ = Math.Sqrt(Math.Pow(h_, 2) + Math.Pow(p_, 2));

                //sprawdzenie czy dany punkt znajduje się w dziedzinie - przynależność do strefy ruchowej robota
                if ((Math.Pow(d1, 2) + Math.Pow(m_, 2) - Math.Pow(d2, 2)) <= (2 * d1 * m_))
                {
                    if (Math.Abs(Math.Pow(d1, 2) + Math.Pow(d2, 2) - Math.Pow(m_, 2)) <= (2 * d1 * d2))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        public int Recalculate_Readings(double val)
        {
            //zamiana wartości odczytanych z gamepada (są w zakresie -1 : 1) na zakres -10 : 10
            int zmienna = (int)(val * 10);
            return zmienna;
        }



        private async Task Log(string txt)
        {
            Task t = Task.Run(() =>
            {
                Debug.WriteLine(DateTime.Now.ToLongTimeString() + ": " + txt);
            });
            await t;
        }

        private async void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            Log("Controller removed");
        }

        private async void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            Log("Controller added");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Points' table. You can move, or remove it, as needed.
            this.pointsTableAdapter.Fill(this.modelDataSet.Points);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            
            if (Gamepad.Gamepads.Count > 0)
            {
                //wybór kontrolera
                Controller = Gamepad.Gamepads.First();
                //odczyt wartości z kontrolera
                var Reading = Controller.GetCurrentReading();
                switch (Reading.Buttons)
                {
                    case GamepadButtons.A:
                        await Log("Button: A");
                        if (instruction_for_uC == "0" && is_gamepad_enable)
                        {
                            instruction_for_uC = "TON";
                        }
                        break;
                    case GamepadButtons.B:
                        await Log("Button: B");
                        if (instruction_for_uC != "find_position" && is_gamepad_enable)
                        {
                            instruction_for_uC = "TOFF";
                        }
                        break;
                    case GamepadButtons.X:
                        await Log("Button: X");
                        break;
                    case GamepadButtons.Y:
                        await Log("Button: Y");
                        break;
                    case GamepadButtons.DPadDown:
                        await Log("Button: DPadDown");
                        break;
                    case GamepadButtons.DPadUp:
                        await Log("Button: DPadUp");
                        break;
                    case GamepadButtons.DPadLeft:
                        await Log("Button: DPadLeft");
                        break;
                    case GamepadButtons.DPadRight:
                        await Log("Button: DPadRight");
                        break;
                    case GamepadButtons.LeftShoulder:
                        await Log("Button: LeftShoulder");
                        break;
                    case GamepadButtons.RightShoulder:
                        await Log("Button: RightShoulder");
                        break;
                }

                //Log("s1: " + Kin.s1.ToString() + " s2: " + Kin.s2.ToString() + " s3: " + Kin.s3.ToString());

                Kin.oblicz();

                //wyświetlanie bierzących wartości kątów
                label_kat0.Text = Kin.kat0.ToString("0.00") + "°";
                label_kat1.Text = Kin.kat1.ToString("0.00") + "°";
                label_kat2.Text = Kin.kat2.ToString("0.00") + "°";
                label_kat3.Text = Kin.kat3.ToString("0.00") + "°";

                double x_move = Convert.ToDouble(Recalculate_Readings(Reading.RightThumbstickX)) / 20.0;
                double y_move = Convert.ToDouble(Recalculate_Readings(Reading.RightThumbstickY)) / 20.0;
                double z_move = Convert.ToDouble(Recalculate_Readings(Reading.LeftThumbstickY)) / 20.0;
                double epsilon_move = Convert.ToDouble(Recalculate_Readings(Reading.LeftThumbstickX)) / 20.0;

                //warunek przytrzymania lewego triggera konieczny do rozpoczęcia ruchu robota
                if (Recalculate_Readings(Reading.LeftTrigger) > 0 && is_gamepad_enable)
                {
                    if (Kin.point_in_range_check(Kin.X + x_move, Kin.Y + y_move, Kin.Z + z_move, Kin.epsilon + epsilon_move))
                    {
                        //zamiana wychylenia drążków na zmiany położenia
                        Kin.X += x_move;
                        Kin.Y += y_move;
                        Kin.Z += z_move;
                        Kin.epsilon += epsilon_move;
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer_data_transmition_Tick(object sender, EventArgs e)
        {
            //Log("jestem");
            //wyświetlenie wartości poszczególnych współrzędnych chwytaka
            x_val_label.Text = Kin.X.ToString("0.0");
            y_val_label.Text = Kin.Y.ToString("0.0");
            z_val_label.Text = Kin.Z.ToString("0.0");
            epsilon_val_label.Text = Kin.epsilon.ToString("0.0");
            
            
            //budowa stringa który zostanie wysłany
            string komunikat = "a" + Kin.kat0.ToString("0.00") +
                "b" + Kin.kat1.ToString("0.00") +
                "c" + Kin.kat2.ToString("0.00") +
                "d" + Kin.kat3.ToString("0.00") +
                "e" + instruction_for_uC + 
                "x";

            if (instruction_for_uC != "0")
            {
                instruction_send_count += 1;
                if (instruction_send_count > 5)
                {
                    instruction_for_uC = "0";
                    instruction_send_count = 0;
                }
            }

            //wysłanie stringa oraz odebranie odpowiedzi
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(komunikat);
                string message = serialPort1.ReadTo("x");
                recieved_label.Text = message;
            }

        }

        private void XYZ_mode_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            //wyłączenie dostępności przycisku CONNECT oraz właczenie dostępności DISCONNECT
            connectButton.Enabled = false;
            disconnectButton.Enabled = true;
            //otwarcie portu szeregowego
            serialPort1.Open();
            frefresh_ports.Enabled = false;
            find_reference_button.Enabled = true;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            //włączenie dostępności przycisku CONNECT oraz wyłaczenie dostępności DISCONNECT
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            //zamknięcie portu szeregowego
            serialPort1.Close();
            frefresh_ports.Enabled = true;
            find_reference_button.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sprawdzenie czy zostały wybrane baudrate i comport jeśli tak można nacisnąć przycisk connect
            if (comboBox1.Text == string.Empty || comboBox2.Text == string.Empty)
            {
                disconnectButton.Enabled = false;
                connectButton.Enabled = false;
            }
            else
            {
                connectButton.Enabled = true;
            }
            //przypisanie do portu szeregowego odpowiedniego portu
            serialPort1.PortName = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sprawdzenie czy zostały wybrane baudrate i comport jeśli tak można nacisnąć przycisk connect
            if (comboBox1.Text == string.Empty || comboBox2.Text == string.Empty)
            {
                disconnectButton.Enabled = false;
                connectButton.Enabled = false;
            }
            else
            {
                connectButton.Enabled = true;
            }
            //przypisanie do portu szeregowego odpowiedniej prędkości transmisji
            serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);

        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////           operacje związane z pobraniem danych z database         //////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////



            //zmienna przechowująca wartoś wiersza z bierzącą zawartością
            current_point = 0;

            //odczytanie ile punktów zostało dodane do bazy danych         
            int points_number = pointsDataGridView.Rows.Count - 1;
            //Log("liczba punktów: " + points_number.ToString());

            if (points_number > 0)
            {
                string odczyt = pointsDataGridView[point_name_column, current_point].Value.ToString();
                //Log(odczyt);
            }



            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////        odczyt oraz interpretacja danych z pola tekstowego         //////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////

            //pobranie tekstu z pola do programowania
            string code_Input = codeInputTextBox.Text;

            //podanie stringa rozdzielającego poszczególne linijki (znak enter)
            string[] separators = new string[] { "\r\n" };

            //rozdzielenie pierwotnego stringa na poszczególne linie
            single_Line_Code = code_Input.Split(separators, StringSplitOptions.None);

            //sprawdzenie czy każda linijka kończy się srednikiem
            for (int i = 0; i < single_Line_Code.Length; ++i)
            {
                if (single_Line_Code[i].IndexOf(";") == -1)
                {
                    //pojawienie się informacji o błędzie
                    MessageBox.Show("ERROR at line: " + (i + 1).ToString() + "\nMissing  ; ");
                    start_program_button.Enabled = false;
                }
                else
                {
                    start_program_button.Enabled = true;
                }
                //Log(single_Line_Code[i]);
            }

            //zapisanie liczby instrukcji w kodzie do zmiennej 
            instruction_lines_count = single_Line_Code.Length;

            //zbiór znaków jakie zostaną usunięte ze stringów z instrukcjami za pomocą finkcji trim
            char[] chars_to_trim = { '(', ')', ';' };



            try
            {
                //pętla odpowiedzialna za przypisanie instrukcji oraz ewentualnego parametru do osobnych stringów
                for (int i = 0; i < single_Line_Code.Length; ++i)
                {
                    if (single_Line_Code[i].IndexOf("(") < 0)
                    {
                        throw new Exception("Compilation ERROR\nSyntax ERROR at: " + i.ToString() + " line\n");
                    }
                    only_instructions[i] = single_Line_Code[i].Remove(single_Line_Code[i].IndexOf("("));
                    only_parameters[i] = single_Line_Code[i].Substring(single_Line_Code[i].IndexOf("(")).Trim(chars_to_trim);
                }

                //sprawdzenie czy funkcje wykorzystane w kodzie są poprawne
                bool is_instruction_correct;
                for (int i = 0; i < single_Line_Code.Length; ++i)
                {
                    is_instruction_correct = false;
                    if (only_instructions[i] == "MVS" || only_instructions[i] == "DLY" || only_instructions[i] == "SPEED" || only_instructions[i] == "ENABLE" || only_instructions[i] == "DISABLE" || only_instructions[i] == "TOOL")
                    {
                        is_instruction_correct = true;
                    }

                    if (!is_instruction_correct)
                    {
                        MessageBox.Show("Compilation ERROR\nIncorrect instruction!!! \n" + only_instructions[i].ToString() + " is no correct\n");
                        start_program_button.Enabled = false;
                    }

                }

            }
            catch (Exception wyjatek)
            {
                MessageBox.Show(wyjatek.Message);
                start_program_button.Enabled = false;
            }



            //zmienna pomocnicza słóżąca do określenia czy punkty w kodzie zgadzają się z punktami w bazie
            bool point_check = false;

            //sprawdzenie czy każdy punkt wytkorzystany w kodzie znajduje się w bazie punktów
            for (int j = 0; j < single_Line_Code.Length; ++j)
            {
                if (only_instructions[j] == "MVS")
                {
                    //ustawienie point_checka na fałsz oznaczające, że nie przypasowano żadnych punktów
                    point_check = false;

                    //pętla wykonywana tyle razy ile punktów znajduje się w bazie
                    for (int m = 0; m < (pointsDataGridView.RowCount - 1); ++m)
                    {
                        //sprawdzenie czy nazwa m-tego punktu pasuje do nazwy parametru dla sprawdzanej instrukcji MVS
                        if (pointsDataGridView[point_name_column, m].Value.ToString() == only_parameters[j])
                        {
                            point_check = true;
                        }
                    }
                    //jeśli po wykonaniu całego sprawdzenia dla danej instrukcji nie znaleziono połączeń punktów, pojawia się messageBox
                    if (point_check == false)
                    {
                        MessageBox.Show("Compilation ERROR\nMissing point in base!!! \n" + only_parameters[j].ToString() + " not found\n");
                        start_program_button.Enabled = false;
                    }
                }
            }


            //sprawdzenie czy żaden z punktów zamieszczonycyh w bazie nie wykracza poza zakres ruchów układu
            //pętla realizowana dla każdego punktu
            for (int m = 0; m < (pointsDataGridView.RowCount - 1); ++m)
            {
                //odczytanie współrzędnych dla każdej współrzędnej
                double current_point_x = Convert.ToDouble(pointsDataGridView[X_column, m].Value.ToString());
                double current_point_y = Convert.ToDouble(pointsDataGridView[Y_column, m].Value.ToString());
                double current_point_z = Convert.ToDouble(pointsDataGridView[Z_column, m].Value.ToString());
                double current_point_epsilon = Convert.ToDouble(pointsDataGridView[epsilon_column, m].Value.ToString());
                string current_point_name = pointsDataGridView[point_name_column, m].Value.ToString();
                //sprawdzenie czy powyższe współrzędne zawierają się w odpowiednim zakresie
                if (Kin.point_in_range_check(current_point_x, current_point_y, current_point_z, current_point_epsilon))
                {
                    point_check = true;
                }
                else
                {
                    point_check = false;
                    MessageBox.Show("Compilation ERROR\nCoordinates of: " + current_point_name + " exceed robot range\n");
                }
            }



            if (point_check == true)
            {
                start_program_button.Enabled = true;
                
                //przypisanie bierzącej pozycji ramienia do zmiennych przechowujących współrzędne pierwszego pounktu z wektora ruchu
                start_X = Kin.X;
                start_Y = Kin.Y;
                start_Z = Kin.Z;
                start_epsilon = Kin.epsilon;
                current_point = 0;
            }
            else
            {
                start_program_button.Enabled = false;
            }

            //Log("liczba instrukcji wynosi: " + single_Line_Code.Length.ToString());


            


        }

        private void pointsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pointsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.modelDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //obsługa kliknięcia rozpocząceia procedury pozycjonowania
            instruction_for_uC = "find_position";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            xTextBox.Text = Kin.X.ToString();
            yTextBox.Text = Kin.Y.ToString();
            zTextBox.Text = Kin.Z.ToString();
            epsilonTextBox.Text = Kin.epsilon.ToString();
        }

        private void frefresh_ports_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
            connectButton.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //jeśli gamepad jest wyłączony wówczas wyłącz go, a jeśli jest włączony wówczas wyłącz
            if (is_gamepad_enable) is_gamepad_enable = false;
            else is_gamepad_enable = true;
        }

        private void start_program_button_Click(object sender, EventArgs e)
        {
            //uruchomienie wykonywania programu poprzez naciśnięcie przycisku START PROGRAM
            timer_script_runtime.Enabled = true;
            stop_program_button.Enabled = true;
            reset_program_button.Enabled = true;
            start_program_button.Enabled = false;
            compileButton.Enabled = false;
        }

        private void stop_program_button_Click(object sender, EventArgs e)
        {
            //przerwanie działania programu bez resetowania jego stanu
            timer_script_runtime.Enabled = false;
            stop_program_button.Enabled = false;
            reset_program_button.Enabled = true;
            start_program_button.Enabled = true;
            compileButton.Enabled = false;
        }

        private void reset_program_botton_Click(object sender, EventArgs e)
        {
            //przerwanie działania programu wraz ze zresetowaniem postępu, przypisaniem aktualnej pozycji do pozycji wejsciowej współrzędnych pierwszego pounktu z wektora ruchu
            timer_script_runtime.Enabled = false;
            state_of_code = 0;
            current_instruction_number = 0;
            start_X = Kin.X;
            start_Y = Kin.Y;
            start_Z = Kin.Z;
            delta_s = 0;
            start_epsilon = Kin.epsilon;
            current_point = 0;
            compileButton.Enabled = true;
        }

        private void pointsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pointsBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void timer_script_runtime_Tick(object sender, EventArgs e)
        {
            //sprawdzenie czy bierząca insterukcja skończyła się wykonywać
            if (state_of_code == 1)
            {
                //jeśli tak wówczas przechodzimy do następnej instrukcji
                current_instruction_number += 1;
                state_of_code = 0;

                //wyzerowanie licznika wywołań
                current_perioid = 1;
                czy_przyspieszasz = true;
                czy_to_pierwsze_powtorzenie = true;
            }




            //przypisanie odpowiedniej instrukcji zgodnie z numerem aktualnej instrukcji do stringa z bierzącą instrukcją
            current_instruction = only_instructions[current_instruction_number];
            current_parameter = only_parameters[current_instruction_number];

            ////dostępne instrukcje:
            //MVS(Point_Name);
            //DLY(time);    time = 1:1000
            //TOOL(state);  STATE = ON/OFF
            //ENABLE();
            //DISABLE();
            //SPEED(speed_val); speed_val = 1:100

            //wykonywanie odpowiedniej instrukcji w zależności jaka jest ustawniona w zmiennej current_instruction jako bierząca
            switch (current_instruction)
            {
                case "MVS":

                    //określenie który punkt został wybrany jako parametr dla bierzącej instrukcji
                    current_point = find_current_point();

                    //pobranie danych z bazy punktów i zapisanie ich do zmiennych
                    if (czy_to_pierwsze_powtorzenie)
                    {
                        goal_x = Convert.ToDouble(pointsDataGridView[X_column, current_point].Value.ToString());
                        goal_y = Convert.ToDouble(pointsDataGridView[Y_column, current_point].Value.ToString());
                        goal_z = Convert.ToDouble(pointsDataGridView[Z_column, current_point].Value.ToString());
                        goal_epsilon = Convert.ToDouble(pointsDataGridView[epsilon_column, current_point].Value.ToString());

                        czy_to_pierwsze_powtorzenie = false;
                    }



                    //określenie wektora wiodącego w danym ruchu
                    double delta_x = goal_x - start_X;
                    double delta_y = goal_y - start_Y;
                    double delta_z = goal_z - start_Z;
                    double delta_epsilon = goal_epsilon - start_epsilon;
                    vector_length = Math.Sqrt(Math.Pow(delta_x, 2) + Math.Pow(delta_y, 2) + Math.Pow(delta_z, 2));



                    //obliczenie ile brakuje do końca wykonania ruchu
                    double missing_distance_x = Math.Abs(goal_x - Kin.X);
                    double missing_distance_y = Math.Abs(goal_y - Kin.Y);
                    double missing_distance_z = Math.Abs(goal_z - Kin.Z);
                    double missing_distance_epsilon = Math.Abs(goal_epsilon - Kin.epsilon);
                    double missing_global_distance = Math.Sqrt(Math.Pow(missing_distance_x, 2) + Math.Pow(missing_distance_y, 2) + Math.Pow(missing_distance_z, 2));


                    //obliczenie ile okresów (wywołań timera) zajmuje przyspieszenie
                    acceleration_perioids = Convert.ToInt32(acceleration_time * freq);

                    //obliczenie ramp oraz aktualnego delta_s dla przyspieszania
                    if ((current_perioid <= acceleration_perioids) && czy_przyspieszasz)
                    {
                        //Log("przyspieszam" + current_perioid.ToString());
                        delta_s = 0.5 * speed / acceleration_time * 0.0001 * (2 * current_perioid - 1);
                        current_perioid += 1;
                    }
                    else
                    {
                        //kiedy wykonamy odpowiednią ilość powtórzeń przechodzimy do domyślnego kroku
                        delta_s = speed / freq;

                        if (czy_przyspieszasz)
                        {
                            current_perioid = 50;
                        }

                        czy_przyspieszasz = false;
                    }

                    //droga potrzebna na wyhamowanie
                    double deccleration_road = 0.5 * speed * acceleration_time;


                    //jeśli droga która została do dotarcia do punktu jest <= od drogi koniecznej do wyhamowania to zaczynamy hamować
                    if ((missing_global_distance <= deccleration_road) && !czy_przyspieszasz)
                    {
                        //Log("missing distance: " + missing_global_distance.ToString());
                        //Log("zwalniam" + current_perioid.ToString());
                        delta_s = 0.5 * speed / acceleration_time * 0.0001 * (2 * current_perioid - 1);
                        current_perioid -= 1;
                    }

                    //Log("delta_s = " + delta_s.ToString());
                    //obliczenie kroku dla poszczególnych współrzednych
                    double step_x = delta_s * delta_x / vector_length;
                    double step_y = delta_s * delta_y / vector_length;
                    double step_z = delta_s * delta_z / vector_length;
                    double step_epsilon = delta_epsilon * delta_s / vector_length;

                    //obliczanie kolejnych wartości X, Y, Z oraz epsilon dla ruchu liniowego ze stałą prędkością
                    Kin.X += step_x;
                    Kin.Y += step_y;
                    Kin.Z += step_z;
                    Kin.epsilon += step_epsilon;

                    //przeliczenie nowej pozcji na kąty
                    Kin.oblicz();







                    //sprawdzenie czy cała instrukcja MVS została wykonana
                    if (missing_distance_x <= delta_s && missing_distance_y <= delta_s && missing_distance_z <= delta_s && missing_distance_epsilon <= delta_s)
                    {
                        //jeśli tak następuje przejście do kolejnej instrukcji oraz przypisanie bierzącej pozycji robota do zmiennych startowych
                        state_of_code = 1;
                        start_X = Kin.X;
                        start_Y = Kin.Y;
                        start_Z = Kin.Z;
                        start_epsilon = Kin.epsilon;
                        //Log("missing distance: " + missing_global_distance.ToString());

                    }

                    break;

                case "DLY":
                    //odczytanie wartości opóźnienia w ms, timer działa co 10ms, więc dzieląc na 10 uzyskujemy potrzebną liczbę cykli
                    int duration = Convert.ToInt32(current_parameter) / 10;
                    //sprawdzenie czy wartość duration nie jest zbyt mała
                    if (duration <= 2)
                    {
                        duration = 2;
                    }

                    //zwiększenie licznika czasowego
                    time_counter += 1;

                    //jeśli licznik przekroczy wartość duration wówczas przerywamy wykonywanie danej funkcji
                    if (time_counter >= duration)
                    {
                        state_of_code = 1;
                        time_counter = 0;
                    }

                    break;

                case "TOOL":
                    string odczytane = current_parameter;
                    instruction_for_uC = "T" + odczytane;

                    state_of_code = 1;
                    break;

                case "ENABLE":

                    break;

                case "DISABLE":

                    break;

                case "SPEED":
                    //prędkość w funkcji SPEED jest z zakresu 1-100
                    int odczyt = Convert.ToInt32(current_parameter);
                    if (odczyt < 1) odczyt = 1;
                    if (odczyt > 100) odczyt = 100;
                    speed = Convert.ToSingle(odczyt);

                    //przemapowanie wartości speed z zakresu 1-100 na zakres 1-20
                    speed = (speed - 1) * (20 - 1) / (100 - 1) + 1;
                    //delta_s = speed / freq;
                    state_of_code = 1;
                    // Log(delta_s.ToString());
                    break;

                default:

                    break;

            }
        }
    }
}

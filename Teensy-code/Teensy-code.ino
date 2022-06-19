#include <InternalTemperature.h>

//zdefiniowanie pinów potrzebnych do sterowania krokami silników
#define motor_0_step_pin 2
#define motor_1_step_pin 5
#define motor_2_step_pin 8
#define motor_3_step_pin 32

//zdefiniowanie pinów potrzebnych do sterowania kierunkiem obrotów silników
#define motor_0_dir_pin 3
#define motor_1_dir_pin 6
#define motor_2_dir_pin 9
#define motor_3_dir_pin 11

//zdefinioiwanie pinów dla krańcówek górnych
#define limit_switch_0_up 14
#define limit_switch_1_up 15
#define limit_switch_2_up 16
#define limit_switch_3_up 17

//zdefinioiwanie pinów dla krańcówek dolnych
#define limit_switch_0_down 18
#define limit_switch_1_down 19
#define limit_switch_2_down 20
#define limit_switch_3_down 21

//zdefiniowanie pinów dla kontrolek
#define motor_0_green_pin 22
#define motor_1_green_pin 23
#define motor_2_green_pin 24
#define motor_3_green_pin 25

#define motor_0_red_pin 26
#define motor_1_red_pin 27
#define motor_2_red_pin 28
#define motor_3_red_pin 29

#define tool_pin 30

#define up_limit_position_for_motor_0 180
#define up_limit_position_for_motor_1 240
#define up_limit_position_for_motor_2 300
#define up_limit_position_for_motor_3 330

#define down_limit_position_for_motor_0 0
#define down_limit_position_for_motor_1 90
#define down_limit_position_for_motor_2 20
#define down_limit_position_for_motor_3 20

#define target_lambda_for_motor_0 90
#define target_lambda_for_motor_1 216.55
#define target_lambda_for_motor_2 -131.95
#define target_lambda_for_motor_3 217.01

//zdefiniowanie pinu potrzebnego do uruchomienia silników
#define motors_enable_pin 10

#define red false
#define green true

#define temperature_read_pin A17

//aktualna temperatura
volatile float current_temp = 0.0;

//kąt o jaki obraca się silnik wykonując 1 krok step_angle = 360/1600
const float step_angle = 0.225;

//zmienne przechowujące docelowy kąt dla każdego ramienia
volatile float lambda_0, lambda_1, lambda_2, lambda_3;

//zmienne przechowujące DOCELOWY kąt dla każdego silnika
volatile float motor_0_angle, motor_1_angle, motor_2_angle, motor_3_angle;

//zmienne przechowujące zliczany, AKTUALNY kąt dla każdego silnika
volatile float motor_0_current_angle, motor_1_current_angle, motor_2_current_angle, motor_3_current_angle;

//zmienna tekstowa przechowująca odczyt danej instrukcji do wykonania
String instruction;

//zmienna przechowująca tekst odczytany z portu szeregowego
String incoming_data;

//zmienna przechowująca string wysyłany do komputera
String send_data;

//stała przechowująca okres wywołania timera (microseconds)
const unsigned int timer_interval = 100;

//zmienna przechowująca numer wywołania timera
volatile uint8_t timer_execution_count = 0;

//zmienne odpowiedzialne za kierunek obrotów
volatile const bool clockwise = true;
volatile const bool counterclockwise = false;

//zmienna logiczna przechowująca informację o tym czy należy wykonać procedurę pozycjonowania (true), czy nie (false);
volatile bool find_position = false; 

//zmienna przechowująca numer etapu pozycjonowany
volatile uint8_t positioning_stage = 0;

//zmienna odpowiedzialna za mruganie lampek
int blink_count = 0;

//logiczna zmienna która realizuje mruganie
bool blink_var = false;

//zmienna logiczna przechowująca stan narzędzia
bool tool_state = false;

//stworzenie obiektu timera
IntervalTimer myTimer;

volatile int temp_counter = 0;

void temperature_read();




/*
 *  kat2 = s2 + delta_s1 * 40 / 48;
 *  kat3 = s3 + delta_s1 * 40 / 48 + (delta_s2 - delta_s1 * 40 / 48) * 40 / 48;
 */

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                                     funkcja wywoływana timerem                                                                                   /// 
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void timer_tick()
{
  //sprawdzenie aktualnej temperatury teensy
  if (temp_counter > 1000)
  {
    temp_counter = 0;
    temperature_read();
  }
  temp_counter++;
  
  if (find_position)
  {
    switch (positioning_stage)
    {
      //pozycjonowanie silnika 0
      case 0:
      {
        //mruganie czerwoną lampką od silnika 0
        if (blink_count > 20000)
        {
          blink_count = 0;
          blink_var = !blink_var;
          set_lamp(0, red, blink_var);
        }
        blink_count += 1;
        
        if(digitalRead(limit_switch_0_up) == LOW)
        {
          lambda_0 = up_limit_position_for_motor_0;
          updateAngles();
          motor_0_current_angle = motor_0_angle;
          positioning_stage += 1;
          break;
        }
        if (timer_execution_count == 2)
        {
          lambda_0 += 0.00675;
          updateAngles();
        }
        
        break;
      }
      case 1:
      {
        //lampka czerwona od silnika 0 świeci ciągle
        set_lamp(0, red, true);
        blink_count = 0;
        if (lambda_0 > target_lambda_for_motor_0)
        {
          if (timer_execution_count == 2)
          {
            lambda_0 -= 0.00675;
            updateAngles();
          }
        }
        else
        {
          positioning_stage += 1;
        }
        break;
      }
      //pozycjonowanie silnika 1
      case 2:
      {
        //lampka czerwona gaśnie, świeci się zielona, mruganie czerwoną od silnika 1
        set_lamp(0, red, false);
        set_lamp(0, green, true);
        //mruganie odpowiednią lampką
        if (blink_count > 20000)
        {
          blink_count = 0;
          blink_var = !blink_var;
          set_lamp(1, red, blink_var);
        }
        blink_count += 1;
        
        if(digitalRead(limit_switch_1_up) == LOW)
        {
          lambda_1 = up_limit_position_for_motor_1;
          updateAngles();
          motor_1_current_angle = motor_1_angle;
          positioning_stage += 1;
          break;
        }
        if (timer_execution_count == 2)
        {
          lambda_1 += 0.00675;
          //kompensacja związana z wpływem kąta lambda_1
          lambda_2 -= 0.00675 * 40/48;
          lambda_3 += 0.00675 * 40/48;
          updateAngles();
        }
        
        break;
      }
      case 3:
      {
        set_lamp(1, red, true);
        blink_count = 0;
        if (lambda_1 > target_lambda_for_motor_1)
        {
          if (timer_execution_count == 2)
          {
            lambda_1 -= 0.00675;
            //kompensacja związana z wpływem kąta lambda_1
            lambda_2 += 0.00675 * 40/48;
            lambda_3 -= 0.00675 * 40/48;
            updateAngles();
          }
        }
        else
        {
          positioning_stage += 1;
        }
        break;
      }
      //pozycjonowanie silnika 2
      case 4:
      {
        //mruganie czerwoną lampką od silnika 2
        set_lamp(1, red, false);
        set_lamp(1, green, true);
        if (blink_count > 20000)
        {
          blink_count = 0;
          blink_var = !blink_var;
          set_lamp(2, red, blink_var);
        }
        blink_count += 1;
        if(digitalRead(limit_switch_2_up) == LOW)
        {
          lambda_2 = up_limit_position_for_motor_2;
          updateAngles();
          motor_2_current_angle = motor_2_angle;
          positioning_stage += 1;
          break;
        }
        if (timer_execution_count == 2)
        {
          lambda_2 += 0.00675;
          //kompensacja związana z wpływem kąta lambda_2
          lambda_3 -= 0.00675;
          updateAngles();
        }
        break;
      }
      case 5:
      {
        set_lamp(2, red, true);
        blink_count = 0;
        if (lambda_2 > target_lambda_for_motor_2)
        {
         if (timer_execution_count == 2)
         {
          lambda_2 -= 0.00675;
          //kompensacja związana z wpływem kąta lambda_2
          lambda_3 += 0.00675;
          updateAngles();
         }
        }
        else
        {
          positioning_stage += 1;
        }
        break;
      }
      //pozycjonowanie silnika 3
      case 6:
      {
        //mruganie czerwoną lampką od silnika 2
        set_lamp(2, red, false);
        set_lamp(2, green, true);
        if (blink_count > 20000)
        {
          blink_count = 0;
          blink_var = !blink_var;
          set_lamp(3, red, blink_var);
        }
        blink_count += 1;
        if(digitalRead(limit_switch_3_up) == LOW)
        {
          lambda_3 = up_limit_position_for_motor_3;
          updateAngles();
          motor_3_current_angle = motor_3_angle;
          positioning_stage += 1;
          break;
        }
        if (timer_execution_count == 2)
        {
          lambda_3 += 0.00675;
          updateAngles();
        }
        break;
      }
      case 7:
      {
        set_lamp(3, red, true);
        blink_count = 0;
        if (lambda_3 > target_lambda_for_motor_3)
        {
         if (timer_execution_count == 2)
          { 
            lambda_3 -= 0.00675;
            updateAngles();
          }
        }
        else
        {
          positioning_stage += 1;
        }
        break;
      }
    }
  }
  
  if (positioning_stage > 7)
  {
    set_lamp(3, red, false);
    set_lamp(3, green, true);
    find_position = false;
    positioning_stage = 0;
  }

  
  

   
  switch (timer_execution_count)
  {
  
  //ustawienie wszystkich wyjść w stan niski
  case 0:
  {
    digitalWrite(motor_0_step_pin, 0); 
    digitalWrite(motor_1_step_pin, 0);
    digitalWrite(motor_2_step_pin, 0);
    digitalWrite(motor_3_step_pin, 0);
    break;
  }
  
  //ustawienie stanu wysokieego na pinach kroku wraz z ddopasowaniem kierunku kiedy jest to wymagane w piewszej milisekundzie
  case 1:
  {
    //sprawdzenie silnika 0
    if (motor_0_angle > (motor_0_current_angle + 0.225) && (digitalRead(limit_switch_0_up) == HIGH) && (digitalRead(limit_switch_0_down) == HIGH))
    {
      digitalWrite(motor_0_dir_pin, counterclockwise);
      digitalWrite(motor_0_step_pin, 1);
      motor_0_current_angle += 0.225;
    }
    if (motor_0_angle < (motor_0_current_angle - 0.225) && (digitalRead(limit_switch_0_up) == HIGH) && (digitalRead(limit_switch_0_down) == HIGH))
    {
      digitalWrite(motor_0_dir_pin, clockwise);
      digitalWrite(motor_0_step_pin, 1);
      motor_0_current_angle -= 0.225;
    }

    //sprawdzenie silnika 1
    if (motor_1_angle > (motor_1_current_angle + 0.225) && (digitalRead(limit_switch_1_up) == HIGH) && (digitalRead(limit_switch_1_down) == HIGH))
    {
      digitalWrite(motor_1_dir_pin, counterclockwise);
      digitalWrite(motor_1_step_pin, 1);
      motor_1_current_angle += 0.225;
    }
    if (motor_1_angle < (motor_1_current_angle - 0.225) && (digitalRead(limit_switch_1_up) == HIGH) && (digitalRead(limit_switch_1_down) == HIGH))
    {
      digitalWrite(motor_1_dir_pin, clockwise);
      digitalWrite(motor_1_step_pin, 1);
      motor_1_current_angle -= 0.225;
    }

    //sprawdzenie silnika 2
    if (motor_2_angle > (motor_2_current_angle + 0.225) && (digitalRead(limit_switch_2_up) == HIGH) && (digitalRead(limit_switch_2_down) == HIGH))
    {
      digitalWrite(motor_2_dir_pin, counterclockwise);
      digitalWrite(motor_2_step_pin, 1); 
      motor_2_current_angle += 0.225;
    }
    if (motor_2_angle < (motor_2_current_angle - 0.225) && (digitalRead(limit_switch_2_up) == HIGH) && (digitalRead(limit_switch_2_down) == HIGH))
    {
      digitalWrite(motor_2_dir_pin, clockwise);
      digitalWrite(motor_2_step_pin, 1);
      motor_2_current_angle -= 0.225;
    }

    //sprawdzenie silnika 3
    if (motor_3_angle > (motor_3_current_angle + 0.225) && (digitalRead(limit_switch_3_up) == HIGH) && (digitalRead(limit_switch_3_down) == HIGH))
    {
      digitalWrite(motor_3_dir_pin, counterclockwise);
      digitalWrite(motor_3_step_pin, 1);
      motor_3_current_angle += 0.225;
    }
    if (motor_3_angle < (motor_3_current_angle - 0.225) && (digitalRead(limit_switch_3_up) == HIGH) && (digitalRead(limit_switch_3_down) == HIGH))
    {
      digitalWrite(motor_3_dir_pin, clockwise);
      digitalWrite(motor_3_step_pin, 1);
      motor_3_current_angle -= 0.225;
    }
    break;
  }

  //ustawienie wszystkich wyjść w stan niski w drugiej milisekundzie
  case 2:
  {
    digitalWrite(motor_0_step_pin, 0); 
    digitalWrite(motor_1_step_pin, 0);
    digitalWrite(motor_2_step_pin, 0);
    digitalWrite(motor_3_step_pin, 0);
    break;
  }
  default:
  {
    break;
  }
  }
  
  //inkrementacja ilości wywołań timera oraz sprawdzenie czy nie wykracza poza zakres
  timer_execution_count += 1;
  if (timer_execution_count > 9)
  {
    timer_execution_count = 0;
  }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                                odpowiednie ustawienie pinów IO                                                                                   ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void setPinMode()
{
  //piny kroku silnika
  pinMode(motor_0_step_pin, OUTPUT);
  pinMode(motor_1_step_pin, OUTPUT);
  pinMode(motor_2_step_pin, OUTPUT);
  pinMode(motor_3_step_pin, OUTPUT);

  //ustawienie pinów w stan niski
  digitalWrite(motor_0_step_pin, 0); 
  digitalWrite(motor_1_step_pin, 0);
  digitalWrite(motor_2_step_pin, 0);
  digitalWrite(motor_3_step_pin, 0);

  //piny kierunku silnika
  pinMode(motor_0_dir_pin, OUTPUT);
  pinMode(motor_1_dir_pin, OUTPUT);
  pinMode(motor_2_dir_pin, OUTPUT);
  pinMode(motor_3_dir_pin, OUTPUT);

  //wspólny enable pin 
  pinMode(motors_enable_pin, OUTPUT);

  //górne krańcówki
  pinMode(limit_switch_0_up, INPUT_PULLUP);
  pinMode(limit_switch_1_up, INPUT_PULLUP);
  pinMode(limit_switch_2_up, INPUT_PULLUP);
  pinMode(limit_switch_3_up, INPUT_PULLUP);

  //dolne krańcówki
  pinMode(limit_switch_0_down, INPUT_PULLUP);
  pinMode(limit_switch_1_down, INPUT_PULLUP);
  pinMode(limit_switch_2_down, INPUT_PULLUP);
  pinMode(limit_switch_3_down, INPUT_PULLUP);

  pinMode(4, OUTPUT);
  digitalWrite(4, LOW);
  pinMode(7, OUTPUT);
  digitalWrite(7, LOW);
  pinMode(10, OUTPUT);
  digitalWrite(10, LOW);

  //wszystkie lampki
  pinMode(motor_0_green_pin, OUTPUT);
  pinMode(motor_0_red_pin, OUTPUT);
  pinMode(motor_1_green_pin, OUTPUT);
  pinMode(motor_1_red_pin, OUTPUT);
  pinMode(motor_2_green_pin, OUTPUT);
  pinMode(motor_2_red_pin, OUTPUT);
  pinMode(motor_3_green_pin, OUTPUT);
  pinMode(motor_3_red_pin, OUTPUT);
  
  for(int i = 0; i<4; ++i)
  {
    set_lamp(i, red, false);
    set_lamp(i, green, false);
  }

  pinMode(tool_pin, OUTPUT);

  return;  
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                                       zarządzanie kontrolkami                                                                                    ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void set_lamp(uint8_t motor_lamp, bool color, bool on_off)
{
  switch (motor_lamp)
  {
    case 0:
    {
      if (color)digitalWrite(motor_0_green_pin, on_off);
      else digitalWrite(motor_0_red_pin, on_off);
      break;
    }
    case 1:
    {
      if (color)digitalWrite(motor_1_green_pin, on_off);
      else digitalWrite(motor_1_red_pin, on_off);
      break;
    }
    case 2:
    {
      if (color)digitalWrite(motor_2_green_pin, on_off);
      else digitalWrite(motor_2_red_pin, on_off);
      break;
    }
    case 3:
    {
      if (color)digitalWrite(motor_3_green_pin, on_off);
      else digitalWrite(motor_3_red_pin, on_off);
      break;
    }
    default:
    {
      break;
    }
  }
  return;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                                         interpretacja danych                                                                                     ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void getData(String inputData)
{
  //odczytanie pozycji konkretnych znaków w stringu danych wejściowych
  int pos_a = inputData.indexOf("a");
  int pos_b = inputData.indexOf("b");
  int pos_c = inputData.indexOf("c");
  int pos_d = inputData.indexOf("d");
  int pos_e = inputData.indexOf("e");
  int pos_x = inputData.indexOf("x");
  
  //przypisanie odczytanych danych do poszczególnych zmiennych lambda_i
  lambda_0 = inputData.substring(pos_a+1, pos_b).replace(",", ".").toFloat();
  lambda_1 = inputData.substring(pos_b+1, pos_c).replace(",", ".").toFloat();
  lambda_2 = inputData.substring(pos_c+1, pos_d).replace(",", ".").toFloat();
  lambda_3 = inputData.substring(pos_d+1, pos_e).replace(",", ".").toFloat();
  instruction = inputData.substring(pos_e+1, inputData.length());

  //zamiana skompensowanych kątów pomiędzy ramionami na kąty dla każdego silnika zgodnie z przekładniami
  
  updateAngles();

  //sprawdzenie czy program komputerowy chce aby wykonać pozycjonowanie
  if (instruction == "find_position")
  {
    find_position = true; 
    positioning_stage = 0;
    setAllAnglesToZero();
    //uruchomienie timera kiedy wywołana zostanie funkcja pozycjonowania
    myTimer.begin(timer_tick, timer_interval);

  }
  if (instruction == "TON")
  {
    tool_state = true;
  }
  if (instruction == "TOFF")
  {
    tool_state = false;
  }
  return;
 }


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                    zamiana kąta lambda na kąt dla wału silnika                                                                                   ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
float LambdaToMotorAngle(float lambda, uint8_t motor)
{
  float angle;
  switch (motor)
  {
    case 0:
    {
      angle = lambda*10/3;
      break;
    }
    case 1:
    {
      angle = lambda*10/3;
      break;
    }
    case 2:
    {
      angle = lambda*3.2;
      break;
    }
    case 3:
    {
      angle = lambda*3.2;
      break;
    }
    default:
    {
      angle = 0;
    }
  }
  return angle;
 }


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                               aktualizacja wszystkich kątów                                                                                                      ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void updateAngles(void)
{
  motor_0_angle = LambdaToMotorAngle(lambda_0, 0);
  motor_1_angle = LambdaToMotorAngle(lambda_1, 1);
  motor_2_angle = LambdaToMotorAngle(lambda_2, 2);
  motor_3_angle = LambdaToMotorAngle(lambda_3, 3);
  
  return;
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                   Wyzerowanie wszystkich katów                                                                                                   ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void setAllAnglesToZero(void)
{
  motor_0_angle = 0;
  motor_1_angle = 0;
  motor_2_angle = 0;
  motor_3_angle = 0;

  motor_0_current_angle = 0;
  motor_1_current_angle = 0;
  motor_2_current_angle = 0;
  motor_3_current_angle = 0;

  lambda_0 = 0;
  lambda_1 = 0;
  lambda_2 = 0;
  lambda_3 = 0;

    return;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                     pomair temperatury układu                                                                                                    ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void temperature_read()
{
  //current_temp = analogRead(temperature_read_pin)*3.3*200/1024; 
  current_temp = InternalTemperature.readTemperatureC(); 
  return;
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                                             SETUP                                                                                                ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void setup() 
{
  //ustalenie prędkości komunikacji dla portu do komunikacji z komputerem SERIAL, oraz do debugowania SERIAL1
  Serial.begin(115200);
  Serial1.begin(115200);

  
  
  //ustawienie pinów do sterowania silnikami jako piny wyjściowe
  setPinMode();

  //wyzerowanie wszystkich wartości na starcie
  setAllAnglesToZero();

  
  //pierwszy pomiar temperatury;
  temperature_read();
    
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                                              główna pętla                                                                                                        ///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void loop() 
{
  //odczytanie danych z portu szeregowego
  if(Serial.available() > 0)
  {
      incoming_data = Serial.readStringUntil('x');
      incoming_data.remove(0,1);
      if (!find_position)
      {
        //w celu manipulacji poszczególnymidocelowymi kątami odczyt danych wykonywany jest wyłącznie kiedy nie trwa pozycjonowanie
        getData(incoming_data);
      }
      temperature_read();
      //send_data = "odczytalem: M0 = " +  String(motor_0_current_angle, 2) + " jestem na: " + String(motor_0_angle, 2) + " M1 = " + String(motor_1_current_angle, 2) + " jestem na: " + String(motor_1_angle, 2) + " M2 = " + String(motor_2_current_angle, 2) + " M3 = " + String(motor_3_current_angle, 2) + " Etap: " + String(positioning_stage) + "x";
      send_data = "lambda_0 = " +  String(lambda_0, 2) + " lambda_1 = " +  String(lambda_1, 2) + " lambda_2 = " +  String(lambda_2, 2) + " lambda_3 = " +  String(lambda_3, 2) + " TOOL: " + String(tool_state) + " temp: " + String(current_temp) + "x";
      Serial.println(send_data);
      
  }
  
}

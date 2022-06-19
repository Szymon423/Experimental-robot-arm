namespace Robot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label epsilonLabel;
            System.Windows.Forms.Label zLabel;
            System.Windows.Forms.Label yLabel;
            System.Windows.Forms.Label xLabel;
            System.Windows.Forms.Label point_nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer_gamepad = new System.Windows.Forms.Timer(this.components);
            this.connectButton = new System.Windows.Forms.Button();
            this.codeInputTextBox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer_data_transmition = new System.Windows.Forms.Timer(this.components);
            this.recieved_label = new System.Windows.Forms.Label();
            this.label_kat1 = new System.Windows.Forms.Label();
            this.label_kat2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_kat0 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_kat3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.z_val_label = new System.Windows.Forms.Label();
            this.y_val_label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.x_val_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.epsilon_val_label = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.compileButton = new System.Windows.Forms.Button();
            this.pointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new Robot.ModelDataSet();
            this.pointsTableAdapter = new Robot.ModelDataSetTableAdapters.PointsTableAdapter();
            this.tableAdapterManager = new Robot.ModelDataSetTableAdapters.TableAdapterManager();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.pointsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.pointsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.epsilonTextBox = new System.Windows.Forms.TextBox();
            this.zTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.point_nameTextBox = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridView = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_script_runtime = new System.Windows.Forms.Timer(this.components);
            this.start_program_button = new System.Windows.Forms.Button();
            this.stop_program_button = new System.Windows.Forms.Button();
            this.reset_program_button = new System.Windows.Forms.Button();
            this.find_reference_button = new System.Windows.Forms.Button();
            this.add_point_from_curr_pos = new System.Windows.Forms.Button();
            this.frefresh_ports = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            epsilonLabel = new System.Windows.Forms.Label();
            zLabel = new System.Windows.Forms.Label();
            yLabel = new System.Windows.Forms.Label();
            xLabel = new System.Windows.Forms.Label();
            point_nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsBindingNavigator)).BeginInit();
            this.pointsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // epsilonLabel
            // 
            epsilonLabel.AutoSize = true;
            epsilonLabel.Location = new System.Drawing.Point(640, 411);
            epsilonLabel.Name = "epsilonLabel";
            epsilonLabel.Size = new System.Drawing.Size(43, 13);
            epsilonLabel.TabIndex = 37;
            epsilonLabel.Text = "epsilon:";
            // 
            // zLabel
            // 
            zLabel.AutoSize = true;
            zLabel.Location = new System.Drawing.Point(499, 415);
            zLabel.Name = "zLabel";
            zLabel.Size = new System.Drawing.Size(17, 13);
            zLabel.TabIndex = 35;
            zLabel.Text = "Z:";
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Location = new System.Drawing.Point(357, 411);
            yLabel.Name = "yLabel";
            yLabel.Size = new System.Drawing.Size(17, 13);
            yLabel.TabIndex = 33;
            yLabel.Text = "Y:";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Location = new System.Drawing.Point(215, 411);
            xLabel.Name = "xLabel";
            xLabel.Size = new System.Drawing.Size(17, 13);
            xLabel.TabIndex = 31;
            xLabel.Text = "X:";
            // 
            // point_nameLabel
            // 
            point_nameLabel.AutoSize = true;
            point_nameLabel.Location = new System.Drawing.Point(33, 411);
            point_nameLabel.Name = "point_nameLabel";
            point_nameLabel.Size = new System.Drawing.Size(63, 13);
            point_nameLabel.TabIndex = 29;
            point_nameLabel.Text = "Point name:";
            // 
            // timer_gamepad
            // 
            this.timer_gamepad.Enabled = true;
            this.timer_gamepad.Interval = 50;
            this.timer_gamepad.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectButton.Location = new System.Drawing.Point(835, 611);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(233, 33);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "CONNECT";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // codeInputTextBox
            // 
            this.codeInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.codeInputTextBox.Location = new System.Drawing.Point(28, 29);
            this.codeInputTextBox.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.codeInputTextBox.Multiline = true;
            this.codeInputTextBox.Name = "codeInputTextBox";
            this.codeInputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeInputTextBox.Size = new System.Drawing.Size(761, 324);
            this.codeInputTextBox.TabIndex = 1;
            this.codeInputTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer_data_transmition
            // 
            this.timer_data_transmition.Enabled = true;
            this.timer_data_transmition.Interval = 10;
            this.timer_data_transmition.Tick += new System.EventHandler(this.timer_data_transmition_Tick);
            // 
            // recieved_label
            // 
            this.recieved_label.AutoSize = true;
            this.recieved_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.recieved_label.Location = new System.Drawing.Point(517, 735);
            this.recieved_label.Name = "recieved_label";
            this.recieved_label.Size = new System.Drawing.Size(70, 25);
            this.recieved_label.TabIndex = 4;
            this.recieved_label.Text = "label2";
            this.recieved_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_kat1
            // 
            this.label_kat1.AutoSize = true;
            this.label_kat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_kat1.Location = new System.Drawing.Point(961, 156);
            this.label_kat1.Name = "label_kat1";
            this.label_kat1.Size = new System.Drawing.Size(70, 25);
            this.label_kat1.TabIndex = 4;
            this.label_kat1.Text = "label2";
            this.label_kat1.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_kat2
            // 
            this.label_kat2.AutoSize = true;
            this.label_kat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_kat2.Location = new System.Drawing.Point(961, 206);
            this.label_kat2.Name = "label_kat2";
            this.label_kat2.Size = new System.Drawing.Size(70, 25);
            this.label_kat2.TabIndex = 4;
            this.label_kat2.Text = "label2";
            this.label_kat2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(860, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kąt 1:";
            this.label1.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_kat0
            // 
            this.label_kat0.AutoSize = true;
            this.label_kat0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_kat0.Location = new System.Drawing.Point(961, 108);
            this.label_kat0.Name = "label_kat0";
            this.label_kat0.Size = new System.Drawing.Size(70, 25);
            this.label_kat0.TabIndex = 3;
            this.label_kat0.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(860, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kąt 2:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(860, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kąt 0:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label_kat3
            // 
            this.label_kat3.AutoSize = true;
            this.label_kat3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_kat3.Location = new System.Drawing.Point(961, 256);
            this.label_kat3.Name = "label_kat3";
            this.label_kat3.Size = new System.Drawing.Size(70, 25);
            this.label_kat3.TabIndex = 4;
            this.label_kat3.Text = "label2";
            this.label_kat3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(860, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kąt 3:";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // z_val_label
            // 
            this.z_val_label.AutoSize = true;
            this.z_val_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.z_val_label.Location = new System.Drawing.Point(1168, 206);
            this.z_val_label.Name = "z_val_label";
            this.z_val_label.Size = new System.Drawing.Size(70, 25);
            this.z_val_label.TabIndex = 4;
            this.z_val_label.Text = "label2";
            this.z_val_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // y_val_label
            // 
            this.y_val_label.AutoSize = true;
            this.y_val_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.y_val_label.Location = new System.Drawing.Point(1168, 156);
            this.y_val_label.Name = "y_val_label";
            this.y_val_label.Size = new System.Drawing.Size(70, 25);
            this.y_val_label.TabIndex = 4;
            this.y_val_label.Text = "label2";
            this.y_val_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(1116, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Y:";
            this.label7.Click += new System.EventHandler(this.label2_Click);
            // 
            // x_val_label
            // 
            this.x_val_label.AutoSize = true;
            this.x_val_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.x_val_label.Location = new System.Drawing.Point(1168, 108);
            this.x_val_label.Name = "x_val_label";
            this.x_val_label.Size = new System.Drawing.Size(70, 25);
            this.x_val_label.TabIndex = 3;
            this.x_val_label.Text = "label1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(1116, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Z:";
            this.label9.Click += new System.EventHandler(this.label2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(1116, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 25);
            this.label10.TabIndex = 3;
            this.label10.Text = "X:";
            this.label10.Click += new System.EventHandler(this.label3_Click);
            // 
            // epsilon_val_label
            // 
            this.epsilon_val_label.AutoSize = true;
            this.epsilon_val_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.epsilon_val_label.Location = new System.Drawing.Point(1168, 256);
            this.epsilon_val_label.Name = "epsilon_val_label";
            this.epsilon_val_label.Size = new System.Drawing.Size(70, 25);
            this.epsilon_val_label.TabIndex = 4;
            this.epsilon_val_label.Text = "label2";
            this.epsilon_val_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(1116, 256);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 25);
            this.label12.TabIndex = 4;
            this.label12.Text = "ε:";
            this.label12.Click += new System.EventHandler(this.label2_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.disconnectButton.Location = new System.Drawing.Point(1074, 611);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(234, 33);
            this.disconnectButton.TabIndex = 0;
            this.disconnectButton.Text = "DISCONNECT";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 24;
            this.comboBox1.Location = new System.Drawing.Point(944, 650);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 32);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 24;
            this.comboBox2.Items.AddRange(new object[] {
            "9600",
            "57000",
            "115200"});
            this.comboBox2.Location = new System.Drawing.Point(1184, 650);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(124, 32);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(846, 653);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 24);
            this.label13.TabIndex = 6;
            this.label13.Text = "COM Port";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(1081, 653);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 24);
            this.label14.TabIndex = 6;
            this.label14.Text = "Baud Rate";
            this.label14.Click += new System.EventHandler(this.label13_Click);
            // 
            // compileButton
            // 
            this.compileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.compileButton.Location = new System.Drawing.Point(836, 455);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(232, 33);
            this.compileButton.TabIndex = 7;
            this.compileButton.Text = "COMPILE";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // pointsBindingSource
            // 
            this.pointsBindingSource.DataMember = "Points";
            this.pointsBindingSource.DataSource = this.modelDataSet;
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pointsTableAdapter
            // 
            this.pointsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PointsTableAdapter = this.pointsTableAdapter;
            this.tableAdapterManager.UpdateOrder = Robot.ModelDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // pointsBindingNavigatorSaveItem
            // 
            this.pointsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("pointsBindingNavigatorSaveItem.Image")));
            this.pointsBindingNavigatorSaveItem.Name = "pointsBindingNavigatorSaveItem";
            this.pointsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.pointsBindingNavigatorSaveItem.Text = "Save Data";
            this.pointsBindingNavigatorSaveItem.Click += new System.EventHandler(this.pointsBindingNavigatorSaveItem_Click);
            // 
            // pointsBindingNavigator
            // 
            this.pointsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.pointsBindingNavigator.BindingSource = this.pointsBindingSource;
            this.pointsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.pointsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.pointsBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.pointsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.pointsBindingNavigatorSaveItem});
            this.pointsBindingNavigator.Location = new System.Drawing.Point(36, 685);
            this.pointsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.pointsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.pointsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.pointsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.pointsBindingNavigator.Name = "pointsBindingNavigator";
            this.pointsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.pointsBindingNavigator.Size = new System.Drawing.Size(278, 25);
            this.pointsBindingNavigator.TabIndex = 8;
            this.pointsBindingNavigator.Text = "bindingNavigator1";
            this.pointsBindingNavigator.RefreshItems += new System.EventHandler(this.pointsBindingNavigator_RefreshItems);
            // 
            // epsilonTextBox
            // 
            this.epsilonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pointsBindingSource, "epsilon", true));
            this.epsilonTextBox.Location = new System.Drawing.Point(689, 408);
            this.epsilonTextBox.Name = "epsilonTextBox";
            this.epsilonTextBox.Size = new System.Drawing.Size(100, 20);
            this.epsilonTextBox.TabIndex = 38;
            // 
            // zTextBox
            // 
            this.zTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pointsBindingSource, "Z", true));
            this.zTextBox.Location = new System.Drawing.Point(522, 408);
            this.zTextBox.Name = "zTextBox";
            this.zTextBox.Size = new System.Drawing.Size(100, 20);
            this.zTextBox.TabIndex = 36;
            // 
            // yTextBox
            // 
            this.yTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pointsBindingSource, "Y", true));
            this.yTextBox.Location = new System.Drawing.Point(380, 408);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 20);
            this.yTextBox.TabIndex = 34;
            // 
            // xTextBox
            // 
            this.xTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pointsBindingSource, "X", true));
            this.xTextBox.Location = new System.Drawing.Point(238, 408);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 20);
            this.xTextBox.TabIndex = 32;
            // 
            // point_nameTextBox
            // 
            this.point_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pointsBindingSource, "Point name", true));
            this.point_nameTextBox.Location = new System.Drawing.Point(102, 408);
            this.point_nameTextBox.Name = "point_nameTextBox";
            this.point_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.point_nameTextBox.TabIndex = 30;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "epsilon";
            this.dataGridViewTextBoxColumn6.HeaderText = "epsilon";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Z";
            this.dataGridViewTextBoxColumn5.HeaderText = "Z";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Y";
            this.dataGridViewTextBoxColumn4.HeaderText = "Y";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "X";
            this.dataGridViewTextBoxColumn3.HeaderText = "X";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Point name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Point name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // pointsDataGridView
            // 
            this.pointsDataGridView.AutoGenerateColumns = false;
            this.pointsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.pointsDataGridView.DataSource = this.pointsBindingSource;
            this.pointsDataGridView.Location = new System.Drawing.Point(36, 451);
            this.pointsDataGridView.Name = "pointsDataGridView";
            this.pointsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.pointsDataGridView.Size = new System.Drawing.Size(753, 231);
            this.pointsDataGridView.TabIndex = 38;
            this.pointsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pointsDataGridView_CellContentClick);
            // 
            // timer_script_runtime
            // 
            this.timer_script_runtime.Interval = 5;
            this.timer_script_runtime.Tick += new System.EventHandler(this.timer_script_runtime_Tick);
            // 
            // start_program_button
            // 
            this.start_program_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start_program_button.Location = new System.Drawing.Point(1074, 455);
            this.start_program_button.Name = "start_program_button";
            this.start_program_button.Size = new System.Drawing.Size(232, 33);
            this.start_program_button.TabIndex = 39;
            this.start_program_button.Text = "START PROGRAM";
            this.start_program_button.UseVisualStyleBackColor = true;
            this.start_program_button.Click += new System.EventHandler(this.start_program_button_Click);
            // 
            // stop_program_button
            // 
            this.stop_program_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stop_program_button.Location = new System.Drawing.Point(836, 494);
            this.stop_program_button.Name = "stop_program_button";
            this.stop_program_button.Size = new System.Drawing.Size(233, 33);
            this.stop_program_button.TabIndex = 40;
            this.stop_program_button.Text = "STOP PROGRAM";
            this.stop_program_button.UseVisualStyleBackColor = true;
            this.stop_program_button.Click += new System.EventHandler(this.stop_program_button_Click);
            // 
            // reset_program_button
            // 
            this.reset_program_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reset_program_button.Location = new System.Drawing.Point(1074, 494);
            this.reset_program_button.Name = "reset_program_button";
            this.reset_program_button.Size = new System.Drawing.Size(232, 33);
            this.reset_program_button.TabIndex = 41;
            this.reset_program_button.Text = "RESET PROGRAM";
            this.reset_program_button.UseVisualStyleBackColor = true;
            this.reset_program_button.Click += new System.EventHandler(this.reset_program_botton_Click);
            // 
            // find_reference_button
            // 
            this.find_reference_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.find_reference_button.Location = new System.Drawing.Point(836, 572);
            this.find_reference_button.Name = "find_reference_button";
            this.find_reference_button.Size = new System.Drawing.Size(233, 33);
            this.find_reference_button.TabIndex = 42;
            this.find_reference_button.Text = "FIND REFERENCE";
            this.find_reference_button.UseVisualStyleBackColor = true;
            this.find_reference_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // add_point_from_curr_pos
            // 
            this.add_point_from_curr_pos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.add_point_from_curr_pos.Location = new System.Drawing.Point(836, 533);
            this.add_point_from_curr_pos.Name = "add_point_from_curr_pos";
            this.add_point_from_curr_pos.Size = new System.Drawing.Size(470, 33);
            this.add_point_from_curr_pos.TabIndex = 43;
            this.add_point_from_curr_pos.Text = "ADD POINT FROM CURRENT POSITOPN";
            this.add_point_from_curr_pos.UseVisualStyleBackColor = true;
            this.add_point_from_curr_pos.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frefresh_ports
            // 
            this.frefresh_ports.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.frefresh_ports.Location = new System.Drawing.Point(1074, 572);
            this.frefresh_ports.Name = "frefresh_ports";
            this.frefresh_ports.Size = new System.Drawing.Size(232, 33);
            this.frefresh_ports.TabIndex = 44;
            this.frefresh_ports.Text = "REFRESH PORTS";
            this.frefresh_ports.UseVisualStyleBackColor = true;
            this.frefresh_ports.Click += new System.EventHandler(this.frefresh_ports_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(850, 415);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(203, 28);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "GAMEPAD ENABLE";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1349, 797);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.frefresh_ports);
            this.Controls.Add(this.add_point_from_curr_pos);
            this.Controls.Add(this.find_reference_button);
            this.Controls.Add(this.reset_program_button);
            this.Controls.Add(this.stop_program_button);
            this.Controls.Add(this.start_program_button);
            this.Controls.Add(this.pointsDataGridView);
            this.Controls.Add(point_nameLabel);
            this.Controls.Add(this.point_nameTextBox);
            this.Controls.Add(xLabel);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(yLabel);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(zLabel);
            this.Controls.Add(this.zTextBox);
            this.Controls.Add(epsilonLabel);
            this.Controls.Add(this.epsilonTextBox);
            this.Controls.Add(this.pointsBindingNavigator);
            this.Controls.Add(this.compileButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.epsilon_val_label);
            this.Controls.Add(this.label_kat3);
            this.Controls.Add(this.recieved_label);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.codeInputTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.x_val_label);
            this.Controls.Add(this.label_kat0);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.y_val_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.z_val_label);
            this.Controls.Add(this.label_kat1);
            this.Controls.Add(this.label_kat2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Robot interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pointsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsBindingNavigator)).EndInit();
            this.pointsBindingNavigator.ResumeLayout(false);
            this.pointsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_gamepad;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox codeInputTextBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer_data_transmition;
        private System.Windows.Forms.Label recieved_label;
        private System.Windows.Forms.Label label_kat1;
        private System.Windows.Forms.Label label_kat2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_kat0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_kat3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label z_val_label;
        private System.Windows.Forms.Label y_val_label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label x_val_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label epsilon_val_label;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button compileButton;
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource pointsBindingSource;
        private ModelDataSetTableAdapters.PointsTableAdapter pointsTableAdapter;
        private ModelDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton pointsBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingNavigator pointsBindingNavigator;
        private System.Windows.Forms.TextBox epsilonTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox point_nameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView pointsDataGridView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer_script_runtime;
        private System.Windows.Forms.Button start_program_button;
        private System.Windows.Forms.Button stop_program_button;
        private System.Windows.Forms.Button reset_program_button;
        private System.Windows.Forms.Button find_reference_button;
        private System.Windows.Forms.Button add_point_from_curr_pos;
        private System.Windows.Forms.Button frefresh_ports;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}


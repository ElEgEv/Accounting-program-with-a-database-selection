namespace TransportCompany
{
    partial class FormCreateTrucking
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
            labelCLient = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBoxClients = new ComboBox();
            comboBoxCargos = new ComboBox();
            comboBoxTransports = new ComboBox();
            comboBoxTypeTransportations = new ComboBox();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            buttonCreate = new Button();
            buttonCancel = new Button();
            label6 = new Label();
            textBoxPrice = new TextBox();
            SuspendLayout();
            // 
            // labelCLient
            // 
            labelCLient.AutoSize = true;
            labelCLient.Location = new Point(37, 30);
            labelCLient.Name = "labelCLient";
            labelCLient.Size = new Size(140, 20);
            labelCLient.TabIndex = 0;
            labelCLient.Text = "Выберите клиента:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 81);
            label1.Name = "label1";
            label1.Size = new Size(150, 20);
            label1.TabIndex = 1;
            label1.Text = "Выберите тип груза:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 135);
            label2.Name = "label2";
            label2.Size = new Size(157, 20);
            label2.TabIndex = 2;
            label2.Text = "Выберите транспорт:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 237);
            label3.Name = "label3";
            label3.Size = new Size(224, 20);
            label3.TabIndex = 3;
            label3.Text = "Дата начала транспортировки:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 288);
            label4.Name = "label4";
            label4.Size = new Size(217, 20);
            label4.TabIndex = 4;
            label4.Text = "Дата конца транспортировки:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 187);
            label5.Name = "label5";
            label5.Size = new Size(236, 20);
            label5.TabIndex = 5;
            label5.Text = "Выберите тип транспортировки:";
            // 
            // comboBoxClients
            // 
            comboBoxClients.FormattingEnabled = true;
            comboBoxClients.Location = new Point(307, 27);
            comboBoxClients.Name = "comboBoxClients";
            comboBoxClients.Size = new Size(319, 28);
            comboBoxClients.TabIndex = 6;
            // 
            // comboBoxCargos
            // 
            comboBoxCargos.FormattingEnabled = true;
            comboBoxCargos.Location = new Point(307, 78);
            comboBoxCargos.Name = "comboBoxCargos";
            comboBoxCargos.Size = new Size(319, 28);
            comboBoxCargos.TabIndex = 7;
            // 
            // comboBoxTransports
            // 
            comboBoxTransports.FormattingEnabled = true;
            comboBoxTransports.Location = new Point(307, 127);
            comboBoxTransports.Name = "comboBoxTransports";
            comboBoxTransports.Size = new Size(319, 28);
            comboBoxTransports.TabIndex = 8;
            // 
            // comboBoxTypeTransportations
            // 
            comboBoxTypeTransportations.FormattingEnabled = true;
            comboBoxTypeTransportations.Location = new Point(307, 184);
            comboBoxTypeTransportations.Name = "comboBoxTypeTransportations";
            comboBoxTypeTransportations.Size = new Size(319, 28);
            comboBoxTypeTransportations.TabIndex = 9;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(307, 237);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(319, 27);
            dateTimePickerStart.TabIndex = 10;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(307, 283);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(319, 27);
            dateTimePickerEnd.TabIndex = 11;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(373, 392);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(120, 29);
            buttonCreate.TabIndex = 12;
            buttonCreate.Text = "Создать";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += ButtonCreate_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(513, 392);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(113, 29);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 346);
            label6.Name = "label6";
            label6.Size = new Size(86, 20);
            label6.TabIndex = 14;
            label6.Text = "Стоимость:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(307, 343);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(319, 27);
            textBoxPrice.TabIndex = 15;
            // 
            // FormCreateTrucking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 438);
            Controls.Add(textBoxPrice);
            Controls.Add(label6);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCreate);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(comboBoxTypeTransportations);
            Controls.Add(comboBoxTransports);
            Controls.Add(comboBoxCargos);
            Controls.Add(comboBoxClients);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelCLient);
            Name = "FormCreateTrucking";
            Text = "Перевозка";
            Load += FormCreateTrucking_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCLient;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxClients;
        private ComboBox comboBoxCargos;
        private ComboBox comboBoxTransports;
        private ComboBox comboBoxTypeTransportations;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Button buttonCreate;
        private Button buttonCancel;
        private Label label6;
        private TextBox textBoxPrice;
    }
}
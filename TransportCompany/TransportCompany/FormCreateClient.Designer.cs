namespace TransportCompany
{
    partial class FormCreateClient
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
            labelName = new Label();
            labelSurname = new Label();
            labelPatronymic = new Label();
            labelTelephone = new Label();
            labelEmail = new Label();
            textBoxName = new TextBox();
            textBoxSurname = new TextBox();
            textBoxPatronymic = new TextBox();
            textBoxTelephone = new TextBox();
            textBoxEmail = new TextBox();
            buttonCreate = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(36, 51);
            labelName.Name = "labelName";
            labelName.Size = new Size(42, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Имя:";
            // 
            // labelSurname
            // 
            labelSurname.AutoSize = true;
            labelSurname.Location = new Point(36, 100);
            labelSurname.Name = "labelSurname";
            labelSurname.Size = new Size(76, 20);
            labelSurname.TabIndex = 1;
            labelSurname.Text = "Фамилия:";
            // 
            // labelPatronymic
            // 
            labelPatronymic.AutoSize = true;
            labelPatronymic.Location = new Point(36, 152);
            labelPatronymic.Name = "labelPatronymic";
            labelPatronymic.Size = new Size(75, 20);
            labelPatronymic.TabIndex = 2;
            labelPatronymic.Text = "Отчество:";
            // 
            // labelTelephone
            // 
            labelTelephone.AutoSize = true;
            labelTelephone.Location = new Point(36, 206);
            labelTelephone.Name = "labelTelephone";
            labelTelephone.Size = new Size(138, 20);
            labelTelephone.TabIndex = 3;
            labelTelephone.Text = "Номера телефона:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(36, 260);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(54, 20);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Почта:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(195, 48);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(394, 27);
            textBoxName.TabIndex = 5;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(195, 97);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(394, 27);
            textBoxSurname.TabIndex = 6;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Location = new Point(195, 149);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(394, 27);
            textBoxPatronymic.TabIndex = 7;
            // 
            // textBoxTelephone
            // 
            textBoxTelephone.Location = new Point(195, 203);
            textBoxTelephone.Name = "textBoxTelephone";
            textBoxTelephone.Size = new Size(394, 27);
            textBoxTelephone.TabIndex = 8;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(195, 257);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(394, 27);
            textBoxEmail.TabIndex = 9;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(309, 318);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(131, 29);
            buttonCreate.TabIndex = 10;
            buttonCreate.Text = "Создать";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += ButtonCreate_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(458, 318);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(131, 29);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormCreateClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 372);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxTelephone);
            Controls.Add(textBoxPatronymic);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxName);
            Controls.Add(labelEmail);
            Controls.Add(labelTelephone);
            Controls.Add(labelPatronymic);
            Controls.Add(labelSurname);
            Controls.Add(labelName);
            Name = "FormCreateClient";
            Text = "Клиент";
            Load += FormCreateClient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelSurname;
        private Label labelPatronymic;
        private Label labelTelephone;
        private Label labelEmail;
        private TextBox textBoxName;
        private TextBox textBoxSurname;
        private TextBox textBoxPatronymic;
        private TextBox textBoxTelephone;
        private TextBox textBoxEmail;
        private Button buttonCreate;
        private Button buttonCancel;
    }
}
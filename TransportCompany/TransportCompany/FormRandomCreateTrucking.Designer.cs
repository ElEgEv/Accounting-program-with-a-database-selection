namespace TransportCompany
{
    partial class FormRandomCreateTrucking
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
            labelClient = new Label();
            textBoxCount = new TextBox();
            buttonCreate = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            textBoxCheckTest = new TextBox();
            SuspendLayout();
            // 
            // labelClient
            // 
            labelClient.AutoSize = true;
            labelClient.Location = new Point(32, 33);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(151, 20);
            labelClient.TabIndex = 0;
            labelClient.Text = "Введите количество:";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(221, 30);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(280, 27);
            textBoxCount.TabIndex = 1;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(237, 148);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(123, 29);
            buttonCreate.TabIndex = 2;
            buttonCreate.Text = "Генерация";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += ButtonCreate_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(382, 148);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(119, 29);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 99);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 4;
            label1.Text = "Время добавления:";
            // 
            // textBoxCheckTest
            // 
            textBoxCheckTest.Location = new Point(221, 96);
            textBoxCheckTest.Name = "textBoxCheckTest";
            textBoxCheckTest.Size = new Size(280, 27);
            textBoxCheckTest.TabIndex = 5;
            // 
            // FormRandomCreateTrucking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 215);
            Controls.Add(textBoxCheckTest);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxCount);
            Controls.Add(labelClient);
            Name = "FormRandomCreateTrucking";
            Text = "Генерация перевозок";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelClient;
        private TextBox textBoxCount;
        private Button buttonCreate;
        private Button buttonCancel;
        private Label label1;
        private TextBox textBoxCheckTest;
    }
}
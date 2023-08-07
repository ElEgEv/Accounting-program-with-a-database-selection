namespace TransportCompany
{
    partial class FormTimeCheck
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
            buttonStartTest = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            textBoxCount = new TextBox();
            label2 = new Label();
            textBoxTimeWork = new TextBox();
            SuspendLayout();
            // 
            // buttonStartTest
            // 
            buttonStartTest.Location = new Point(123, 22);
            buttonStartTest.Name = "buttonStartTest";
            buttonStartTest.Size = new Size(257, 75);
            buttonStartTest.TabIndex = 0;
            buttonStartTest.Text = "Запуск теста";
            buttonStartTest.UseVisualStyleBackColor = true;
            buttonStartTest.Click += ButtonStartTest_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(361, 241);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 30);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 131);
            label1.Name = "label1";
            label1.Size = new Size(230, 20);
            label1.TabIndex = 2;
            label1.Text = "Кол-во считываемых значений:";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(284, 128);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(171, 27);
            textBoxCount.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 186);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 4;
            label2.Text = "Время работы:";
            // 
            // textBoxTimeWork
            // 
            textBoxTimeWork.Location = new Point(284, 183);
            textBoxTimeWork.Name = "textBoxTimeWork";
            textBoxTimeWork.Size = new Size(171, 27);
            textBoxTimeWork.TabIndex = 5;
            // 
            // FormTimeCheck
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 285);
            Controls.Add(textBoxTimeWork);
            Controls.Add(label2);
            Controls.Add(textBoxCount);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonStartTest);
            Name = "FormTimeCheck";
            Text = "Тест скорости чтения записей перевозок";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStartTest;
        private Button buttonCancel;
        private Label label1;
        private TextBox textBoxCount;
        private Label label2;
        private TextBox textBoxTimeWork;
    }
}
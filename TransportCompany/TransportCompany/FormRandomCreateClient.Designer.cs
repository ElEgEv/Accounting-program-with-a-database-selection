namespace TransportCompany
{
    partial class FormRandomCreateClient
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
            labelCount = new Label();
            textBoxCount = new TextBox();
            buttonStart = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            textBoxTimeWork = new TextBox();
            SuspendLayout();
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(21, 25);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(93, 20);
            labelCount.TabIndex = 0;
            labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(158, 22);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(217, 27);
            textBoxCount.TabIndex = 1;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(147, 162);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(110, 29);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Генерация";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStart_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(281, 162);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 101);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 4;
            label1.Text = "Время работы:";
            // 
            // textBoxTimeWork
            // 
            textBoxTimeWork.Location = new Point(158, 98);
            textBoxTimeWork.Name = "textBoxTimeWork";
            textBoxTimeWork.Size = new Size(217, 27);
            textBoxTimeWork.TabIndex = 5;
            // 
            // FormRandomCreateClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 220);
            Controls.Add(textBoxTimeWork);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonStart);
            Controls.Add(textBoxCount);
            Controls.Add(labelCount);
            Name = "FormRandomCreateClient";
            Text = "Случайная генерация клиентов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCount;
        private TextBox textBoxCount;
        private Button buttonStart;
        private Button buttonCancel;
        private Label label1;
        private TextBox textBoxTimeWork;
    }
}
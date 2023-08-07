namespace TransportCompany
{
    partial class FormCheckTimeJoin
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
            textBoxFirstCheck = new TextBox();
            groupBoxFirst = new GroupBox();
            buttonCheckFirstJoin = new Button();
            groupBoxSecond = new GroupBox();
            textBoxSecondCheck = new TextBox();
            buttonCheckSecondJoin = new Button();
            buttonCancel = new Button();
            groupBoxFirst.SuspendLayout();
            groupBoxSecond.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxFirstCheck
            // 
            textBoxFirstCheck.Location = new Point(312, 42);
            textBoxFirstCheck.Name = "textBoxFirstCheck";
            textBoxFirstCheck.Size = new Size(228, 27);
            textBoxFirstCheck.TabIndex = 0;
            // 
            // groupBoxFirst
            // 
            groupBoxFirst.Controls.Add(buttonCheckFirstJoin);
            groupBoxFirst.Controls.Add(textBoxFirstCheck);
            groupBoxFirst.Location = new Point(12, 12);
            groupBoxFirst.Name = "groupBoxFirst";
            groupBoxFirst.Size = new Size(580, 91);
            groupBoxFirst.TabIndex = 1;
            groupBoxFirst.TabStop = false;
            groupBoxFirst.Text = "Для первого запроса";
            // 
            // buttonCheckFirstJoin
            // 
            buttonCheckFirstJoin.Location = new Point(65, 42);
            buttonCheckFirstJoin.Name = "buttonCheckFirstJoin";
            buttonCheckFirstJoin.Size = new Size(195, 29);
            buttonCheckFirstJoin.TabIndex = 1;
            buttonCheckFirstJoin.Text = "Произвести замер";
            buttonCheckFirstJoin.UseVisualStyleBackColor = true;
            buttonCheckFirstJoin.Click += ButtonCheckFirstJoin_Click;
            // 
            // groupBoxSecond
            // 
            groupBoxSecond.Controls.Add(textBoxSecondCheck);
            groupBoxSecond.Controls.Add(buttonCheckSecondJoin);
            groupBoxSecond.Location = new Point(12, 109);
            groupBoxSecond.Name = "groupBoxSecond";
            groupBoxSecond.Size = new Size(580, 95);
            groupBoxSecond.TabIndex = 2;
            groupBoxSecond.TabStop = false;
            groupBoxSecond.Text = "Для второго запроса";
            // 
            // textBoxSecondCheck
            // 
            textBoxSecondCheck.Location = new Point(312, 41);
            textBoxSecondCheck.Name = "textBoxSecondCheck";
            textBoxSecondCheck.Size = new Size(228, 27);
            textBoxSecondCheck.TabIndex = 1;
            // 
            // buttonCheckSecondJoin
            // 
            buttonCheckSecondJoin.Location = new Point(65, 41);
            buttonCheckSecondJoin.Name = "buttonCheckSecondJoin";
            buttonCheckSecondJoin.Size = new Size(195, 29);
            buttonCheckSecondJoin.TabIndex = 0;
            buttonCheckSecondJoin.Text = "Произвести замер";
            buttonCheckSecondJoin.UseVisualStyleBackColor = true;
            buttonCheckSecondJoin.Click += ButtonCheckSecondJoin_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(452, 220);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(140, 29);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormCheckTimeJoin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 259);
            Controls.Add(buttonCancel);
            Controls.Add(groupBoxSecond);
            Controls.Add(groupBoxFirst);
            Name = "FormCheckTimeJoin";
            Text = "Замер времени сложных запросов";
            groupBoxFirst.ResumeLayout(false);
            groupBoxFirst.PerformLayout();
            groupBoxSecond.ResumeLayout(false);
            groupBoxSecond.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxFirstCheck;
        private GroupBox groupBoxFirst;
        private Button buttonCheckFirstJoin;
        private GroupBox groupBoxSecond;
        private TextBox textBoxSecondCheck;
        private Button buttonCheckSecondJoin;
        private Button buttonCancel;
    }
}
namespace TransportCompany
{
	partial class FormCreateTypeTransportation
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
			label1 = new Label();
			textBoxTypeTransportation = new TextBox();
			buttonCreate = new Button();
			buttonCancel = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(24, 36);
			label1.Name = "label1";
			label1.Size = new Size(165, 20);
			label1.TabIndex = 0;
			label1.Text = "Тип транспортировки:";
			// 
			// textBoxTypeTransportation
			// 
			textBoxTypeTransportation.Location = new Point(232, 33);
			textBoxTypeTransportation.Name = "textBoxTypeTransportation";
			textBoxTypeTransportation.Size = new Size(330, 27);
			textBoxTypeTransportation.TabIndex = 1;
			// 
			// buttonCreate
			// 
			buttonCreate.Location = new Point(355, 83);
			buttonCreate.Name = "buttonCreate";
			buttonCreate.Size = new Size(94, 29);
			buttonCreate.TabIndex = 2;
			buttonCreate.Text = "Создать";
			buttonCreate.UseVisualStyleBackColor = true;
			buttonCreate.Click += ButtonCreate_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(468, 83);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(94, 29);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// FormCreateTypeTransportation
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(617, 138);
			Controls.Add(buttonCancel);
			Controls.Add(buttonCreate);
			Controls.Add(textBoxTypeTransportation);
			Controls.Add(label1);
			Name = "FormCreateTypeTransportation";
			Text = "FormCreateTypeTransportation";
			Load += FormCreateTypeTransportation_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBoxTypeTransportation;
		private Button buttonCreate;
		private Button buttonCancel;
	}
}
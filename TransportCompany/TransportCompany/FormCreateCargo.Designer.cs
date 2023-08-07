namespace TransportCompany
{
	partial class FormCreateCargo
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
			textBoxCargo = new TextBox();
			buttonCreate = new Button();
			buttonCancel = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(33, 28);
			label1.Name = "label1";
			label1.Size = new Size(137, 20);
			label1.TabIndex = 0;
			label1.Text = "Введите тип груза:";
			// 
			// textBoxCargo
			// 
			textBoxCargo.Location = new Point(198, 25);
			textBoxCargo.Name = "textBoxCargo";
			textBoxCargo.Size = new Size(313, 27);
			textBoxCargo.TabIndex = 1;
			// 
			// buttonCreate
			// 
			buttonCreate.Location = new Point(305, 73);
			buttonCreate.Name = "buttonCreate";
			buttonCreate.Size = new Size(94, 29);
			buttonCreate.TabIndex = 2;
			buttonCreate.Text = "Создать";
			buttonCreate.UseVisualStyleBackColor = true;
			buttonCreate.Click += ButtonCreate_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(417, 73);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(94, 29);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// FormCreateCargo
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(571, 118);
			Controls.Add(buttonCancel);
			Controls.Add(buttonCreate);
			Controls.Add(textBoxCargo);
			Controls.Add(label1);
			Name = "FormCreateCargo";
			Text = "Создание груза";
			Load += FormCreateCargo_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBoxCargo;
		private Button buttonCreate;
		private Button buttonCancel;
	}
}
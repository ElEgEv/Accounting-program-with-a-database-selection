namespace TransportCompany
{
	partial class FormCreateTransport
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
			textBoxTransport = new TextBox();
			buttonCreate = new Button();
			buttonCancel = new Button();
			label2 = new Label();
			textBoxTypeTransportation = new TextBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(36, 43);
			label1.Name = "label1";
			label1.Size = new Size(122, 20);
			label1.TabIndex = 0;
			label1.Text = "Тип транспорта:";
			// 
			// textBoxTransport
			// 
			textBoxTransport.Location = new Point(215, 40);
			textBoxTransport.Name = "textBoxTransport";
			textBoxTransport.Size = new Size(254, 27);
			textBoxTransport.TabIndex = 1;
			// 
			// buttonCreate
			// 
			buttonCreate.Location = new Point(262, 164);
			buttonCreate.Name = "buttonCreate";
			buttonCreate.Size = new Size(94, 29);
			buttonCreate.TabIndex = 2;
			buttonCreate.Text = "Создать";
			buttonCreate.UseVisualStyleBackColor = true;
			buttonCreate.Click += ButtonCreate_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(375, 164);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(94, 29);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(36, 112);
			label2.Name = "label2";
			label2.Size = new Size(116, 20);
			label2.TabIndex = 4;
			label2.Text = "Тип перевозки:";
			// 
			// textBoxTypeTransportation
			// 
			textBoxTypeTransportation.Location = new Point(215, 109);
			textBoxTypeTransportation.Name = "textBoxTypeTransportation";
			textBoxTypeTransportation.Size = new Size(254, 27);
			textBoxTypeTransportation.TabIndex = 5;
			// 
			// FormCreateTransport
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(527, 215);
			Controls.Add(textBoxTypeTransportation);
			Controls.Add(label2);
			Controls.Add(buttonCancel);
			Controls.Add(buttonCreate);
			Controls.Add(textBoxTransport);
			Controls.Add(label1);
			Name = "FormCreateTransport";
			Text = "Транспорт";
			Load += FormCreateTransport_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBoxTransport;
		private Button buttonCreate;
		private Button buttonCancel;
		private Label label2;
		private TextBox textBoxTypeTransportation;
	}
}
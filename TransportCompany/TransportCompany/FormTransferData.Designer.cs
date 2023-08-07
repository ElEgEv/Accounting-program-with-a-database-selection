namespace TransportCompany
{
	partial class FormTransferData
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
			buttonStartTransfer = new Button();
			SuspendLayout();
			// 
			// buttonStartTransfer
			// 
			buttonStartTransfer.BackColor = Color.Red;
			buttonStartTransfer.BackgroundImageLayout = ImageLayout.Zoom;
			buttonStartTransfer.Font = new Font("Snap ITC", 9F, FontStyle.Bold, GraphicsUnit.Point);
			buttonStartTransfer.Location = new Point(102, 12);
			buttonStartTransfer.Name = "buttonStartTransfer";
			buttonStartTransfer.Size = new Size(213, 36);
			buttonStartTransfer.TabIndex = 0;
			buttonStartTransfer.Text = "НУ ЧЁ, ПОГНАЛИ";
			buttonStartTransfer.UseVisualStyleBackColor = false;
			buttonStartTransfer.Click += ButtonStartTransfer_Click;
			// 
			// FormTransferData
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(415, 60);
			Controls.Add(buttonStartTransfer);
			Name = "FormTransferData";
			Text = "Передача данных";
			ResumeLayout(false);
		}

		#endregion

		private Button buttonStartTransfer;
	}
}
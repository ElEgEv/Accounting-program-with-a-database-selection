namespace TransportCompany
{
	partial class FormTransport
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
			dataGridView = new DataGridView();
			buttonCreate = new Button();
			buttonUpdate = new Button();
			buttonReload = new Button();
			buttonDelete = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// dataGridView
			// 
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Location = new Point(12, 12);
			dataGridView.Name = "dataGridView";
			dataGridView.RowHeadersWidth = 51;
			dataGridView.RowTemplate.Height = 29;
			dataGridView.Size = new Size(455, 426);
			dataGridView.TabIndex = 0;
			// 
			// buttonCreate
			// 
			buttonCreate.Location = new Point(521, 39);
			buttonCreate.Name = "buttonCreate";
			buttonCreate.Size = new Size(138, 29);
			buttonCreate.TabIndex = 1;
			buttonCreate.Text = "Создать";
			buttonCreate.UseVisualStyleBackColor = true;
			buttonCreate.Click += ButtonCreate_Click;
			// 
			// buttonUpdate
			// 
			buttonUpdate.Location = new Point(521, 112);
			buttonUpdate.Name = "buttonUpdate";
			buttonUpdate.Size = new Size(138, 29);
			buttonUpdate.TabIndex = 2;
			buttonUpdate.Text = "Изменить";
			buttonUpdate.UseVisualStyleBackColor = true;
			buttonUpdate.Click += ButtonUpdate_Click;
			// 
			// buttonReload
			// 
			buttonReload.Location = new Point(521, 258);
			buttonReload.Name = "buttonReload";
			buttonReload.Size = new Size(138, 29);
			buttonReload.TabIndex = 4;
			buttonReload.Text = "Обновить";
			buttonReload.UseVisualStyleBackColor = true;
			buttonReload.Click += ButtonReload_Click;
			// 
			// buttonDelete
			// 
			buttonDelete.Location = new Point(521, 184);
			buttonDelete.Name = "buttonDelete";
			buttonDelete.Size = new Size(138, 29);
			buttonDelete.TabIndex = 5;
			buttonDelete.Text = "Удалить";
			buttonDelete.UseVisualStyleBackColor = true;
			buttonDelete.Click += ButtonDelete_Click;
			// 
			// FormTransport
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(703, 450);
			Controls.Add(buttonDelete);
			Controls.Add(buttonReload);
			Controls.Add(buttonUpdate);
			Controls.Add(buttonCreate);
			Controls.Add(dataGridView);
			Name = "FormTransport";
			Text = "FormTransports";
			Load += FormTransport_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonCreate;
		private Button buttonUpdate;
		private Button buttonReload;
		private Button buttonDelete;
	}
}
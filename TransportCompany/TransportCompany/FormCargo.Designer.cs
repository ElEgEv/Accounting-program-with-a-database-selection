namespace TransportCompany
{
	partial class FormCargo
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
			buttonDelete = new Button();
			buttonReload = new Button();
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
			dataGridView.Size = new Size(523, 426);
			dataGridView.TabIndex = 0;
			// 
			// buttonCreate
			// 
			buttonCreate.Location = new Point(590, 33);
			buttonCreate.Name = "buttonCreate";
			buttonCreate.Size = new Size(129, 29);
			buttonCreate.TabIndex = 1;
			buttonCreate.Text = "Создать";
			buttonCreate.UseVisualStyleBackColor = true;
			buttonCreate.Click += ButtonCreate_Click;
			// 
			// buttonUpdate
			// 
			buttonUpdate.Location = new Point(590, 108);
			buttonUpdate.Name = "buttonUpdate";
			buttonUpdate.Size = new Size(129, 29);
			buttonUpdate.TabIndex = 2;
			buttonUpdate.Text = "Изменить";
			buttonUpdate.UseVisualStyleBackColor = true;
			buttonUpdate.Click += ButtonUpdate_Click;
			// 
			// buttonDelete
			// 
			buttonDelete.Location = new Point(590, 179);
			buttonDelete.Name = "buttonDelete";
			buttonDelete.Size = new Size(129, 29);
			buttonDelete.TabIndex = 3;
			buttonDelete.Text = "Удалить";
			buttonDelete.UseVisualStyleBackColor = true;
			buttonDelete.Click += ButtonDelete_Click;
			// 
			// buttonReload
			// 
			buttonReload.Location = new Point(590, 251);
			buttonReload.Name = "buttonReload";
			buttonReload.Size = new Size(129, 29);
			buttonReload.TabIndex = 4;
			buttonReload.Text = "Обновить";
			buttonReload.UseVisualStyleBackColor = true;
			buttonReload.Click += ButtonReload_Click;
			// 
			// FormCargo
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(766, 450);
			Controls.Add(buttonReload);
			Controls.Add(buttonDelete);
			Controls.Add(buttonUpdate);
			Controls.Add(buttonCreate);
			Controls.Add(dataGridView);
			Name = "FormCargo";
			Text = "FormCargo";
			Load += FormCargo_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonCreate;
		private Button buttonUpdate;
		private Button buttonDelete;
		private Button buttonReload;
	}
}
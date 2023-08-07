namespace TransportCompany
{
	partial class FormTrucking
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
			buttonCreateTrucking = new Button();
			menuStrip = new MenuStrip();
			toolStripMenuItem = new ToolStripMenuItem();
			transportToolStripMenuItem = new ToolStripMenuItem();
			typeTransportationToolStripMenuItem = new ToolStripMenuItem();
			cargoToolStripMenuItem = new ToolStripMenuItem();
			clientToolStripMenuItem = new ToolStripMenuItem();
			rndGenerationToolStripMenuItem = new ToolStripMenuItem();
			generationClientsToolStripMenuItem = new ToolStripMenuItem();
			generationTruckingsToolStripMenuItem = new ToolStripMenuItem();
			testTimeGetDataToolStripMenuItem = new ToolStripMenuItem();
			testComplexQueriesToolStripMenuItem = new ToolStripMenuItem();
			buttonUpdate = new Button();
			comboBoxEmails = new ComboBox();
			label1 = new Label();
			checkBoxSorted = new CheckBox();
			checkBoxForFilterMode = new CheckBox();
			chooiceDBToolStripMenuItem = new ToolStripMenuItem();
			transferDataToolStripMenuItem = new ToolStripMenuItem();
			startPostgresqlToolStripMenuItem = new ToolStripMenuItem();
			startMongoDBToolStripMenuItem = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			menuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// dataGridView
			// 
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Location = new Point(11, 67);
			dataGridView.Name = "dataGridView";
			dataGridView.RowHeadersWidth = 51;
			dataGridView.RowTemplate.Height = 29;
			dataGridView.Size = new Size(937, 417);
			dataGridView.TabIndex = 0;
			// 
			// buttonCreateTrucking
			// 
			buttonCreateTrucking.Location = new Point(1014, 67);
			buttonCreateTrucking.Name = "buttonCreateTrucking";
			buttonCreateTrucking.Size = new Size(235, 29);
			buttonCreateTrucking.TabIndex = 1;
			buttonCreateTrucking.Text = "Создать перевозку";
			buttonCreateTrucking.UseVisualStyleBackColor = true;
			buttonCreateTrucking.Click += ButtonCreateTrucking_Click;
			// 
			// menuStrip
			// 
			menuStrip.ImageScalingSize = new Size(20, 20);
			menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem, rndGenerationToolStripMenuItem, testTimeGetDataToolStripMenuItem, testComplexQueriesToolStripMenuItem, chooiceDBToolStripMenuItem });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Padding = new Padding(6, 3, 0, 3);
			menuStrip.Size = new Size(1297, 30);
			menuStrip.TabIndex = 6;
			menuStrip.Text = "menuStrip1";
			// 
			// toolStripMenuItem
			// 
			toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { transportToolStripMenuItem, typeTransportationToolStripMenuItem, cargoToolStripMenuItem, clientToolStripMenuItem });
			toolStripMenuItem.Name = "toolStripMenuItem";
			toolStripMenuItem.Size = new Size(117, 24);
			toolStripMenuItem.Text = "Справочники";
			// 
			// transportToolStripMenuItem
			// 
			transportToolStripMenuItem.Name = "transportToolStripMenuItem";
			transportToolStripMenuItem.Size = new Size(245, 26);
			transportToolStripMenuItem.Text = "Транспорт";
			transportToolStripMenuItem.Click += TransportToolStripMenuItem_Click;
			// 
			// typeTransportationToolStripMenuItem
			// 
			typeTransportationToolStripMenuItem.Name = "typeTransportationToolStripMenuItem";
			typeTransportationToolStripMenuItem.Size = new Size(245, 26);
			typeTransportationToolStripMenuItem.Text = "Тип транспортировки";
			typeTransportationToolStripMenuItem.Click += TypeTransportationToolStripMenuItem_Click;
			// 
			// cargoToolStripMenuItem
			// 
			cargoToolStripMenuItem.Name = "cargoToolStripMenuItem";
			cargoToolStripMenuItem.Size = new Size(245, 26);
			cargoToolStripMenuItem.Text = "Груз";
			cargoToolStripMenuItem.Click += CargoToolStripMenuItem_Click;
			// 
			// clientToolStripMenuItem
			// 
			clientToolStripMenuItem.Name = "clientToolStripMenuItem";
			clientToolStripMenuItem.Size = new Size(245, 26);
			clientToolStripMenuItem.Text = "Клиенты";
			clientToolStripMenuItem.Click += ClientToolStripMenuItem_Click;
			// 
			// rndGenerationToolStripMenuItem
			// 
			rndGenerationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generationClientsToolStripMenuItem, generationTruckingsToolStripMenuItem });
			rndGenerationToolStripMenuItem.Name = "rndGenerationToolStripMenuItem";
			rndGenerationToolStripMenuItem.Size = new Size(179, 24);
			rndGenerationToolStripMenuItem.Text = "Рандомная генерация";
			// 
			// generationClientsToolStripMenuItem
			// 
			generationClientsToolStripMenuItem.Name = "generationClientsToolStripMenuItem";
			generationClientsToolStripMenuItem.Size = new Size(245, 26);
			generationClientsToolStripMenuItem.Text = "Генерация клиентов";
			generationClientsToolStripMenuItem.Click += GenerationClientsToolStripMenuItem_Click;
			// 
			// generationTruckingsToolStripMenuItem
			// 
			generationTruckingsToolStripMenuItem.Name = "generationTruckingsToolStripMenuItem";
			generationTruckingsToolStripMenuItem.Size = new Size(245, 26);
			generationTruckingsToolStripMenuItem.Text = "Генерация перевозок";
			generationTruckingsToolStripMenuItem.Click += GenerationTruckingsToolStripMenuItem_Click;
			// 
			// testTimeGetDataToolStripMenuItem
			// 
			testTimeGetDataToolStripMenuItem.Name = "testTimeGetDataToolStripMenuItem";
			testTimeGetDataToolStripMenuItem.Size = new Size(227, 24);
			testTimeGetDataToolStripMenuItem.Text = "Тест скорости чтения данных";
			testTimeGetDataToolStripMenuItem.Click += TestTimeGetDataToolStripMenuItem_Click;
			// 
			// testComplexQueriesToolStripMenuItem
			// 
			testComplexQueriesToolStripMenuItem.Name = "testComplexQueriesToolStripMenuItem";
			testComplexQueriesToolStripMenuItem.Size = new Size(188, 24);
			testComplexQueriesToolStripMenuItem.Text = "Тест сложных запросов";
			testComplexQueriesToolStripMenuItem.Click += TestComplexQueriesToolStripMenuItem_Click;
			// 
			// buttonUpdate
			// 
			buttonUpdate.Location = new Point(1014, 138);
			buttonUpdate.Name = "buttonUpdate";
			buttonUpdate.Size = new Size(235, 29);
			buttonUpdate.TabIndex = 7;
			buttonUpdate.Text = "Обновить";
			buttonUpdate.UseVisualStyleBackColor = true;
			buttonUpdate.Click += ButtonUpdate_Click;
			// 
			// comboBoxEmails
			// 
			comboBoxEmails.FormattingEnabled = true;
			comboBoxEmails.Location = new Point(142, 33);
			comboBoxEmails.Name = "comboBoxEmails";
			comboBoxEmails.Size = new Size(208, 28);
			comboBoxEmails.TabIndex = 8;
			comboBoxEmails.SelectedIndexChanged += ComboBoxEmails_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 36);
			label1.Name = "label1";
			label1.Size = new Size(124, 20);
			label1.TabIndex = 9;
			label1.Text = "Выберите почту:";
			// 
			// checkBoxSorted
			// 
			checkBoxSorted.AutoSize = true;
			checkBoxSorted.Location = new Point(632, 35);
			checkBoxSorted.Name = "checkBoxSorted";
			checkBoxSorted.Size = new Size(316, 24);
			checkBoxSorted.TabIndex = 10;
			checkBoxSorted.Text = "Сортировать по возрастанию стоимости";
			checkBoxSorted.UseVisualStyleBackColor = true;
			checkBoxSorted.CheckedChanged += CheckBoxSorted_CheckedChanged;
			// 
			// checkBoxForFilterMode
			// 
			checkBoxForFilterMode.AutoSize = true;
			checkBoxForFilterMode.Location = new Point(370, 35);
			checkBoxForFilterMode.Name = "checkBoxForFilterMode";
			checkBoxForFilterMode.Size = new Size(212, 24);
			checkBoxForFilterMode.TabIndex = 11;
			checkBoxForFilterMode.Text = "Включить режим фильтра";
			checkBoxForFilterMode.UseVisualStyleBackColor = true;
			// 
			// chooiceDBToolStripMenuItem
			// 
			chooiceDBToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { transferDataToolStripMenuItem, startPostgresqlToolStripMenuItem, startMongoDBToolStripMenuItem });
			chooiceDBToolStripMenuItem.Name = "chooiceDBToolStripMenuItem";
			chooiceDBToolStripMenuItem.Size = new Size(93, 24);
			chooiceDBToolStripMenuItem.Text = "Выбор БД";
			// 
			// transferDataToolStripMenuItem
			// 
			transferDataToolStripMenuItem.Name = "transferDataToolStripMenuItem";
			transferDataToolStripMenuItem.Size = new Size(224, 26);
			transferDataToolStripMenuItem.Text = "Передача данных";
			transferDataToolStripMenuItem.Click += TransferDataToolStripMenuItem_Click;
			// 
			// startPostgresqlToolStripMenuItem
			// 
			startPostgresqlToolStripMenuItem.Name = "startPostgresqlToolStripMenuItem";
			startPostgresqlToolStripMenuItem.Size = new Size(224, 26);
			startPostgresqlToolStripMenuItem.Text = "Запуск Postgresql";
			startPostgresqlToolStripMenuItem.Click += StartPostgresqlToolStripMenuItem_Click;
			// 
			// startMongoDBToolStripMenuItem
			// 
			startMongoDBToolStripMenuItem.Name = "startMongoDBToolStripMenuItem";
			startMongoDBToolStripMenuItem.Size = new Size(224, 26);
			startMongoDBToolStripMenuItem.Text = "Запуск MongoDB";
			startMongoDBToolStripMenuItem.Click += StartMongoDBToolStripMenuItem_Click;
			// 
			// FormTrucking
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1297, 496);
			Controls.Add(checkBoxForFilterMode);
			Controls.Add(checkBoxSorted);
			Controls.Add(label1);
			Controls.Add(comboBoxEmails);
			Controls.Add(buttonUpdate);
			Controls.Add(buttonCreateTrucking);
			Controls.Add(dataGridView);
			Controls.Add(menuStrip);
			MainMenuStrip = menuStrip;
			Name = "FormTrucking";
			Text = "Перевозки";
			Load += FormMain_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonCreateTrucking;
		private Button buttonTakeOrderInWork;
		private Button buttonOrderReady;
		private Button buttonIssuedOrder;
		private Button buttonRef;
		private MenuStrip menuStrip;
		private ToolStripMenuItem toolStripMenuItem;
		private ToolStripMenuItem transportToolStripMenuItem;
		private ToolStripMenuItem workPieceToolStripMenuItem;
		private ToolStripMenuItem typeTransportationToolStripMenuItem;
		private ToolStripMenuItem cargoToolStripMenuItem;
		private ToolStripMenuItem clientToolStripMenuItem;
		private ToolStripMenuItem shopToolStripMenuItem;
		private ToolStripMenuItem addManufactureToolStripMenuItem;
		private Button buttonSellManufacture;
		private ToolStripMenuItem reportToolStripMenuItem;
		private ToolStripMenuItem groupedOrdersReportToolStripMenuItem;
		private ToolStripMenuItem ordersReportToolStripMenuItem;
		private ToolStripMenuItem manufactureWorkPiecesReportToolStripMenuItem;
		private ToolStripMenuItem shopsReportToolStripMenuItem;
		private ToolStripMenuItem rndGenerationToolStripMenuItem;
		private ToolStripMenuItem generationClientsToolStripMenuItem;
		private ToolStripMenuItem generationTruckingsToolStripMenuItem;
		private Button buttonUpdate;
		private ComboBox comboBoxEmails;
		private Label label1;
		private CheckBox checkBoxSorted;
		private CheckBox checkBoxForFilterMode;
		private ToolStripMenuItem testTimeGetDataToolStripMenuItem;
		private ToolStripMenuItem testComplexQueriesToolStripMenuItem;
		private ToolStripMenuItem chooiceDBToolStripMenuItem;
		private ToolStripMenuItem transferDataToolStripMenuItem;
		private ToolStripMenuItem startPostgresqlToolStripMenuItem;
		private ToolStripMenuItem startMongoDBToolStripMenuItem;
	}
}
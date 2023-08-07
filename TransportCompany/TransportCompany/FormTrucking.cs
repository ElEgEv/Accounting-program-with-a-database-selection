using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using TransportCompanyBusinessLogic.BusinessLogic;
using TransportCompanyContracts.BusinessLogicsContracts;
using TransportCompanyContracts.SearchModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TransportCompany
{
	public partial class FormTrucking : Form
	{
		private readonly ILogger _logger;

		private bool _mongo;

		private ITruckingLogic _truckingLogic;

		private IClientLogic _clientLogic;

		public FormTrucking(ILogger<FormTrucking> logger, ITruckingLogic truckingLogic, IClientLogic clientLogic,
			ICargoLogic cargoLogic, ITransportLogic transportLogic, ITransportationLogic transportationLogic)
		{
			InitializeComponent();

			_logger = logger;
			_truckingLogic = truckingLogic;
			_clientLogic = clientLogic;
			_mongo = false;
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			_logger.LogInformation("Загрузка перевозок");

			try
			{
				var list = _truckingLogic.ReadList(null);

				var listClients = _clientLogic.ReadList(null);

				if (list != null)
				{
					dataGridView.DataSource = list;

					if (list.Any(x => !string.IsNullOrEmpty(x.MongoId)))
					{
						dataGridView.Columns["Id"].Visible = false;
						dataGridView.Columns["MongoId"].Visible = true;
					}
					else
					{
						dataGridView.Columns["Id"].Visible = true;
						dataGridView.Columns["MongoId"].Visible = false;
					}

					dataGridView.Columns["ClientId"].Visible = false;
					dataGridView.Columns["CargoId"].Visible = false;
					dataGridView.Columns["TransportId"].Visible = false;
					dataGridView.Columns["TransportationId"].Visible = false;
				}

				if (listClients != null)
				{
					comboBoxEmails.DisplayMember = "Email";

					if (_mongo)
					{
						comboBoxEmails.ValueMember = "MongoId";
					}
					else
					{
						comboBoxEmails.ValueMember = "Id";
					}

					comboBoxEmails.DataSource = listClients;
					comboBoxEmails.SelectedItem = null;
				}

				_logger.LogInformation("Загрузка перевозок");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки перевозок");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonCreateTrucking_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCreateTrucking));

			if (service is FormCreateTrucking form)
			{
				form.Mongo = _mongo;

				form.ShowDialog();
				LoadData();
			}
		}

		private void TransportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormTransport));

			if (service is FormTransport form)
			{
				form.SetMongo = _mongo;

				form.ShowDialog();
				LoadData();
			}
		}

		private void CargoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCargo));

			if (service is FormCargo form)
			{
				form.ShowDialog();
				LoadData();
			}
		}

		private void ClientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormClients));

			if (service is FormClients form)
			{
				form.ShowDialog();
				LoadData();
			}
		}

		private void TypeTransportationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!_mongo)
			{
				var service = Program.ServiceProvider?.GetService(typeof(FormTypeTransportation));

				if (service is FormTypeTransportation form)
				{
					form.ShowDialog();
					LoadData();
				}
			}
		}

		private void GenerationClientsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormRandomCreateClient));

			if (service is FormRandomCreateClient form)
			{
				form.ShowDialog();
				LoadData();
			}
		}

		private void GenerationTruckingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormRandomCreateTrucking));

			if (service is FormRandomCreateTrucking form)
			{
				form.ShowDialog();
				LoadData();
			}
		}

		private void ButtonUpdate_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void ComboBoxEmails_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!checkBoxForFilterMode.Checked)
			{
				//dataGridView.DataSource = _truckingLogic.ReadList(null);
				LoadData();
			}
			else
			{
				if (_mongo)
				{
					dataGridView.DataSource = _truckingLogic.ReadList(new TruckingSearchModel { MongoId = comboBoxEmails.SelectedValue.ToString() });
				}
				else
				{
					dataGridView.DataSource = _truckingLogic.ReadList(null).Where(x => x.ClientId == comboBoxEmails.SelectedIndex).ToList();
				}
			}
		}

		private void CheckBoxSorted_CheckedChanged(object sender, EventArgs e)
		{
			dataGridView.DataSource = _truckingLogic.ReadList(null).OrderByDescending(x => x.Price).ToList();
		}

		private void TestTimeGetDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormTimeCheck));

			if (service is FormTimeCheck form)
			{
				form.ShowDialog();
				LoadData();
			}
		}

		private void TestComplexQueriesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCheckTimeJoin));

			if (service is FormCheckTimeJoin form)
			{
				form.ShowDialog();
				LoadData();
			}
		}

		/*private void CreateJsonFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var listTrucking = _truckingLogic.ReadList(null);
			var listClients = _clientLogic.ReadList(null);
			var listCargos = _cargoLogic.ReadList(null);
			var listTransport = _transportLogic.ReadList(null);
			var listTransportation = _transportationLogic.ReadList(null);

			string jsonList = JsonSerializer.Serialize(listClients).ToString();

			string path = @"C:\Users\Programmist73\Desktop\JSON\";   // путь к файлу

			string realPath;

			for (int i = 0; i < listClients.Count; i++)
			{
				realPath = path + "json" + i.ToString() + ".json";

				File.Create(realPath).Close();

				StreamWriter writetext = new StreamWriter(realPath);

				writetext.WriteLine("{\n\t" + "\"client\" : " + "{\n\t" + "\t\"Name\" : " + "\"" + listClients[i].Name + "\"" + "\n\t}\n}");

				writetext.Close();
			}
		}*/

		//передача данных из Postgresql в MongoDB
		private void TransferDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormTransferData));

			if (service is FormTransferData form)
			{
				form.ShowDialog();
			}
		}

		//работа с Postgresql
		private void StartPostgresqlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_mongo = false;

			Program.ConnectPostgres();

			_truckingLogic = Program.ServiceProvider.GetService(typeof(ITruckingLogic)) as TruckingLogic;
			_clientLogic = Program.ServiceProvider.GetService(typeof(IClientLogic)) as ClientLogic;

			LoadData();
		}

		//работа с MongoBD
		private void StartMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_mongo = true;

			Program.ConnectMongo();

			_truckingLogic = Program.ServiceProvider.GetService(typeof(ITruckingLogic)) as TruckingLogic;
			_clientLogic = Program.ServiceProvider.GetService(typeof(IClientLogic)) as ClientLogic;

			LoadData();
		}
	}
}
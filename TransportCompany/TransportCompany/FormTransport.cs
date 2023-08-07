using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.BusinessLogicsContracts;

namespace TransportCompany
{
	public partial class FormTransport : Form
	{
		private readonly ILogger _logger;

		private readonly ITransportLogic _logic;

		private bool isMongo;

		public bool SetMongo { set { isMongo = value;} }

		public FormTransport(ILogger<FormTransport> logger, ITransportLogic logic)
		{
			InitializeComponent();

			_logger = logger;
			_logic = logic;
		}

		private void FormClients_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				var list = _logic.ReadList(null);

				//растягиваем колонку Название на всю ширину, колонку Id скрываем
				if (list != null)
				{
					dataGridView.DataSource = list;

					if (!isMongo)
					{
						dataGridView.Columns["Id"].Visible = true;
						dataGridView.Columns["MongoId"].Visible = false;
						dataGridView.Columns["TransportationType"].Visible = false;
					}
					else
					{
						dataGridView.Columns["Id"].Visible = false;
						dataGridView.Columns["MongoId"].Visible = true;
					}

					dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}

				_logger.LogInformation("Загрузка транспортных средств");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки транспортных средств");

				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FormTransport_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCreateTransport));

			if (service is FormCreateTransport form)
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void ButtonUpdate_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var service = Program.ServiceProvider?.GetService(typeof(FormCreateTransport));

				if (service is FormCreateTransport form)
				{
					form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

					form.MongoId = Convert.ToString(dataGridView.SelectedRows[0].Cells["MongoId"].Value);

					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadData();
					}
				}
			}
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			//проверяем наличие выделенной строки
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

					string mongoId = Convert.ToString(dataGridView.SelectedRows[0].Cells["MongoId"].Value);

					_logger.LogInformation("Удаление транспорта");

					try
					{
						if (!_logic.Delete(new TransportBindingModel
						{
							Id = id,
							MongoId = mongoId
						}))
						{
							throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
						}

						LoadData();
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, "Ошибка удаления транспорта");
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void ButtonReload_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}

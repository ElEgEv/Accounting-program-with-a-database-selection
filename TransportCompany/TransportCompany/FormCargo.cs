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
	public partial class FormCargo : Form
	{
		private readonly ILogger _logger;

		private readonly ICargoLogic _logicC;

		public FormCargo(ILogger<FormCargo> logger, ICargoLogic logicC)
		{
			InitializeComponent();

			_logger = logger;
			_logicC = logicC;
		}

		private void FormCargo_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				var list = _logicC.ReadList(null);

				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns["Id"].Visible = false;
					dataGridView.Columns["MongoId"].Visible = false;
					dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}

				_logger.LogInformation("Загрузка типов грузов");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки типов грузов");

				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCreateCargo));

			if (service is FormCreateCargo form)
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
				var service = Program.ServiceProvider?.GetService(typeof(FormCreateCargo));

				if (service is FormCreateCargo form)
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

					string _mongoId = Convert.ToString(dataGridView.SelectedRows[0].Cells["MongoId"].Value);

					_logger.LogInformation("Удаление типа груза");

					try
					{
						if (!_logicC.Delete(new CargoBindingModel
						{
							Id = id,
							MongoId = _mongoId
						}))
						{
							throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
						}

						LoadData();
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, "Ошибка удаления типа груза");
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

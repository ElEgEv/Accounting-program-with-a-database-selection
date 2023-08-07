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
	public partial class FormTypeTransportation : Form
	{
		private readonly ILogger _logger;

		private readonly ITransportationLogic _logic;

		public FormTypeTransportation(ILogger<FormTypeTransportation> logger, ITransportationLogic logic)
		{
			InitializeComponent();

			_logger = logger;
			_logic = logic;
		}

		private void FormTypeTransportation_Load(object sender, EventArgs e)
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
					dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}

				_logger.LogInformation("Загрузка типа перевозок");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки типа перевозок");

				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCreateTypeTransportation));

			if (service is FormCreateTypeTransportation form)
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
				var service = Program.ServiceProvider?.GetService(typeof(FormCreateTypeTransportation));

				if (service is FormCreateTypeTransportation form)
				{
					form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

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

					_logger.LogInformation("Удаление типа перевозки");

					try
					{
						if (!_logic.Delete(new TransportationBindingModel
						{
							Id = id
						}))
						{
							throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
						}

						LoadData();
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, "Ошибка удаления типа перевозки");
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

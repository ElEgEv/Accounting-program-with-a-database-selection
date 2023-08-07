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
using TransportCompanyContracts.SearchModels;

namespace TransportCompany
{
	public partial class FormCreateCargo : Form
	{
		private readonly ILogger _logger;

		private readonly ICargoLogic _logicCg;

		private int? _id;

		private string? _mongoId;

		public int Id { set { _id = value; } }

		public string MongoId { set { _mongoId = value; } }

		public FormCreateCargo(ILogger<FormCreateCargo> logger, ICargoLogic logicCg)
		{
			InitializeComponent();

			_logger = logger;
			_logicCg = logicCg;
		}

		private void FormCreateCargo_Load(object sender, EventArgs e)
		{
			//проверка на заполнение поля id. Если оно заполнено, то пробуем получить запись и выести её на экран
			if (!string.IsNullOrEmpty(_mongoId))
			{
				try
				{
					_logger.LogInformation("Получение типа груза");

					var view = _logicCg.ReadElement(new CargoSearchModel { MongoId = _mongoId });

					if (view != null)
					{
						textBoxCargo.Text = view.TypeCargo;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения типа груза");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (_id.HasValue)
			{
				try
				{
					_logger.LogInformation("Получение типа груза");

					var view = _logicCg.ReadElement(new CargoSearchModel { Id = _id.Value });

					if (view != null)
					{
						textBoxCargo.Text = view.TypeCargo;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения типа груза");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCargo.Text))
			{
				MessageBox.Show("Введите тип груза", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_logger.LogInformation("Добавление груза");

			try
			{
				var model = new CargoBindingModel
				{
					Id = _id ?? 0,
					MongoId = _mongoId,
					TypeCargo = textBoxCargo.Text
				};

				var operationResult = _id.HasValue ? _logicCg.Update(model) : _logicCg.Create(model);

				if (!operationResult)
				{
					throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
				}

				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;

				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка сохранения клиента");

				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}

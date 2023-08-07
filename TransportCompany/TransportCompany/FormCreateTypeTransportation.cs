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
	public partial class FormCreateTypeTransportation : Form
	{
		private readonly ILogger _logger;

		private readonly ITransportationLogic _logic;

		private int? _id;

		public int Id { set { _id = value; } }

		public FormCreateTypeTransportation(ILogger<FormCreateTypeTransportation> logger, ITransportationLogic logic)
		{
			InitializeComponent();

			_logger = logger;
			_logic = logic;
		}

		private void FormCreateTypeTransportation_Load(object sender, EventArgs e)
		{
			//проверка на заполнение поля id. Если оно заполнено, то пробуем получить запись и выести её на экран
			if (_id.HasValue)
			{
				try
				{
					_logger.LogInformation("Получение типа транспортировки");

					var view = _logic.ReadElement(new TransportationSearchModel { Id = _id.Value });

					if (view != null)
					{
						textBoxTypeTransportation.Text = view.TransportationType;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения типа транспортировки");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxTypeTransportation.Text))
			{
				MessageBox.Show("Введите тип транспортировки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_logger.LogInformation("Добавление типа транспортировки");

			try
			{
				var model = new TransportationBindingModel
				{
					Id = 0,
					TransportationType = textBoxTypeTransportation.Text
				};

				var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);

				if (!operationResult)
				{
					throw new Exception("Ошибка при сохранеии. Дополнительная информация в логах.");
				}

				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;

				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка сохранения типа транспортировки");

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

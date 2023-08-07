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
	public partial class FormCreateTransport : Form
	{
		private readonly ILogger _logger;

		private readonly ITransportLogic _logicT;

		private int? _id;

		private string? _mongoId;

		public int Id { set { _id = value; } }

		public string MongoId { set { _mongoId = value; } }

		public FormCreateTransport(ILogger<FormCreateTransport> logger, ITransportLogic logicT)
		{
			InitializeComponent();

			_logger = logger;
			_logicT = logicT;
		}

		private void FormCreateTransport_Load(object sender, EventArgs e)
		{
			//проверка на заполнение поля id. Если оно заполнено, то пробуем получить запись и выести её на экран
			if (!string.IsNullOrEmpty(_mongoId))
			{
				try
				{
					_logger.LogInformation("Получение транспорта");

					var view = _logicT.ReadElement(new TransportSearchModel { MongoId = _mongoId });

					if (view != null)
					{
						textBoxTransport.Text = view.Tranport;
						textBoxTypeTransportation.Text = view.TransportationType;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения транспорта");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (_id.HasValue)
			{
				try
				{
					_logger.LogInformation("Получение транспорта");

					var view = _logicT.ReadElement(new TransportSearchModel { Id = _id.Value });

					if (view != null)
					{
						textBoxTransport.Text = view.Tranport;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения транспорта");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ButtonCreate_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxTransport.Text))
			{
				MessageBox.Show("Введите тип транспорта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			/*if (string.IsNullOrEmpty(textBoxTypeTransportation.Text))
			{
				MessageBox.Show("Введите тип транспортировки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}*/

			_logger.LogInformation("Добавление транспорта");

			try
			{
				var model = new TransportBindingModel
				{
					Id = _id ?? 0,
					MongoId = _mongoId,
					Tranport = textBoxTransport.Text,
					TransportationType = textBoxTypeTransportation.Text
				};

				var operationResult = _id.HasValue ? _logicT.Update(model) : _logicT.Create(model);

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
				_logger.LogError(ex, "Ошибка сохранения транспорта");

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

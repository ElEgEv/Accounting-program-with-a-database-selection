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
    public partial class FormCreateClient : Form
    {
        private readonly ILogger _logger;

        private readonly IClientLogic _logicC;

        private int? _id;

		private string? _mongoId;

		public int Id { set { _id = value; } }

		public string MongoId { set { _mongoId = value; } }

		public FormCreateClient(ILogger<FormCreateClient> logger, IClientLogic logicC)
        {
            InitializeComponent();

            _logger = logger;
            _logicC = logicC;
        }

        //для загрузки данных при редактировании
        private void FormCreateClient_Load(object sender, EventArgs e)
        {
            //проверка на заполнение поля id. Если оно заполнено, то пробуем получить запись и выести её на экран
            if (!string.IsNullOrEmpty(_mongoId))
            {
				try
				{
					_logger.LogInformation("Получение клиента");

					var view = _logicC.ReadElement(new ClientSearchModel { MongoId = _mongoId });

					if (view != null)
					{
						textBoxName.Text = view.Name;
						textBoxSurname.Text = view.Surname;
						textBoxPatronymic.Text = view.Patronymic;
						textBoxTelephone.Text = view.Telephone;
						textBoxEmail.Text = view.Email;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения компонента");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
            else if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение клиента");

                    var view = _logicC.ReadElement(new ClientSearchModel { Id = _id.Value });

                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxSurname.Text = view.Surname;
                        textBoxPatronymic.Text = view.Patronymic;
                        textBoxTelephone.Text = view.Telephone;
                        textBoxEmail.Text = view.Email;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения компонента");

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите своё имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxSurname.Text))
            {
                MessageBox.Show("Введите свою фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPatronymic.Text))
            {
                MessageBox.Show("Введите своё отчество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxTelephone.Text))
            {
                MessageBox.Show("Введите свой телефон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Введите свою почту", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _logger.LogInformation("Добавление клиента");

            try
            {
                var model = new ClientBindingModel
                {
                    Id = 0,
                    MongoId = _mongoId,
                    Name = textBoxName.Text,
                    Surname = textBoxSurname.Text,
                    Patronymic = textBoxPatronymic.Text,
                    Telephone = textBoxTelephone.Text,
                    Email = textBoxEmail.Text
                };

                var operationResult = _id.HasValue ? _logicC.Update(model) : _logicC.Create(model);

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

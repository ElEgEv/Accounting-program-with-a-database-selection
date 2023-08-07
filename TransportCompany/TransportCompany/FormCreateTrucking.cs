using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
    public partial class FormCreateTrucking : Form
    {
        private readonly ILogger _logger;

        private bool isMongo;

		public bool Mongo { set { isMongo = value; } }

		private readonly IClientLogic _logicCl;

        private readonly ITransportLogic _logicTransport;

        private readonly ITransportationLogic _logicTransportation;

        private readonly ICargoLogic _logicCargo;

        private readonly ITruckingLogic _logic;

        private int? _id;

        public int Id { set { _id = value; } }

        public FormCreateTrucking(ILogger<FormCreateTrucking> logger, ITruckingLogic logic, ICargoLogic logicCargo,
            IClientLogic logicCl, ITransportLogic logicTransport, ITransportationLogic logicTransportation)
        {
            InitializeComponent();

            _logger = logger;
            _logic = logic;
            _logicCargo = logicCargo;
            _logicCl = logicCl;
            _logicTransport = logicTransport;
            _logicTransportation = logicTransportation;
        }

        private void FormCreateTrucking_Load(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Получение сводки по перевозке");

                var viewClient = _logicCl.ReadList(null);
                var viewCargo = _logicCargo.ReadList(null);
                var viewTransport = _logicTransport.ReadList(null);
                var viewTransportation = _logicTransportation.ReadList(null);

                //var view = _logic.ReadElement(new TruckingSearchModel { Id = _id.Value });

                if (viewClient != null)
                {
                    comboBoxClients.DisplayMember = "Email";

                    if (isMongo)
                    {
						comboBoxClients.ValueMember = "MongoId";
					}
                    else
                    {
						comboBoxClients.ValueMember = "Id";
					}

                    comboBoxClients.DataSource = viewClient;
                    comboBoxClients.SelectedItem = null;
                }

                if (viewCargo != null)
                {
                    comboBoxCargos.DisplayMember = "TypeCargo";

					if (isMongo)
					{
						comboBoxClients.ValueMember = "MongoId";
					}
					else
					{
						comboBoxClients.ValueMember = "Id";
					}

					comboBoxCargos.DataSource = viewCargo;
                    comboBoxCargos.SelectedItem = null;
                }

                if (viewTransport != null)
                {
                    comboBoxTransports.DisplayMember = "Tranport";

					if (isMongo)
					{
						comboBoxClients.ValueMember = "MongoId";
					}
					else
					{
						comboBoxClients.ValueMember = "Id";
					}

					comboBoxTransports.DataSource = viewTransport;
                    comboBoxTransports.SelectedItem = null;
                }

                if (!isMongo)
                {
					if (viewTransportation != null)
					{
						comboBoxTypeTransportations.DisplayMember = "TransportationType";
						comboBoxTypeTransportations.ValueMember = "Id";
						comboBoxTypeTransportations.DataSource = viewTransportation;
						comboBoxTypeTransportations.SelectedItem = null;
					}
				} 
                else
                {
                    comboBoxTypeTransportations.Text = "Сейчас это недоступно";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения сводки по перевозке");

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                MessageBox.Show("Дата начала транспортировки не может быть позже её конца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (comboBoxClients.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (comboBoxCargos.SelectedValue == null)
            {
                MessageBox.Show("Выберите груз", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (comboBoxTransports.SelectedValue == null)
            {
                MessageBox.Show("Выберите транспорт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!isMongo)
            {
				if (comboBoxTypeTransportations.SelectedValue == null)
				{
					MessageBox.Show("Выберите тип транспортировки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;
				}
			}

            _logger.LogInformation("Создание сводки по перевозке");

            try
            {
                if (isMongo)
                {
					var operationResult = _logic.Create(new TruckingBindingModel
					{
						Client = comboBoxClients.SelectedValue.ToString(),
						Cargo = comboBoxCargos.SelectedValue.ToString(),
						Transport = comboBoxTransports.SelectedValue.ToString(),
						Price = Convert.ToInt32(textBoxPrice.Text),
						DateStart = dateTimePickerStart.Value,
						DateEnd = dateTimePickerEnd.Value
					});

					if (!operationResult)
					{
						throw new Exception("Ошибка при создании сводки по перевозке. Дополнительная информация в логах.");
					}
				}
                else
                {
                    var operationResult = _logic.Create(new TruckingBindingModel
                    {
                        ClientId = Convert.ToInt32(comboBoxClients.SelectedValue),
                        CargoId = Convert.ToInt32(comboBoxCargos.SelectedValue),
                        TransportId = Convert.ToInt32(comboBoxTransports.SelectedValue),
                        TransportationId = Convert.ToInt32(comboBoxTypeTransportations.SelectedValue),
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        DateStart = dateTimePickerStart.Value,
                        DateEnd = dateTimePickerEnd.Value
                    });

                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при создании сводки по перевозке. Дополнительная информация в логах.");
                    }
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания сводки по перевозке");
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

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
using System.Xml.Linq;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.BusinessLogicsContracts;

namespace TransportCompany
{
    public partial class FormRandomCreateTrucking : Form
    {
        private readonly IClientLogic _logicCl;

        private readonly ITransportLogic _logicTransport;

        private readonly ITransportationLogic _logicTransportation;

        private readonly ICargoLogic _logicCargo;

        private readonly ITruckingLogic _logic;

        public FormRandomCreateTrucking(ILogger<FormRandomCreateTrucking> logger, ITruckingLogic logic, ICargoLogic logicCargo,
            IClientLogic logicCl, ITransportLogic logicTransport, ITransportationLogic logicTransportation)
        {
            InitializeComponent();

            _logic = logic;
            _logicCargo = logicCargo;
            _logicCl = logicCl;
            _logicTransport = logicTransport;
            _logicTransportation = logicTransportation;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var viewClient = _logicCl.ReadList(null);
            var viewCargo = _logicCargo.ReadList(null);
            var viewTransport = _logicTransport.ReadList(null);
            var viewTransportation = _logicTransportation.ReadList(null);

            try
            {
                textBoxCheckTest.Text = _logic.TestRandomCreate(Convert.ToInt32(textBoxCount.Text), viewClient, viewCargo, viewTransport, viewTransportation);
            }
            catch (Exception ex)
            {
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

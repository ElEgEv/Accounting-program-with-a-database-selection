using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompanyContracts.BusinessLogicsContracts;

namespace TransportCompany
{
    public partial class FormCheckTimeJoin : Form
    {
        private readonly ITruckingLogic _truckingLogic;

        private readonly IClientLogic _clientLogic;

        public FormCheckTimeJoin(ITruckingLogic truckingLogic, IClientLogic clientLogic)
        {
            InitializeComponent();

            _truckingLogic = truckingLogic;
            _clientLogic = clientLogic;
        }

        private void ButtonCheckFirstJoin_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxFirstCheck.Text = _truckingLogic.TestFirstJoin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCheckSecondJoin_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxSecondCheck.Text = _clientLogic.TestSecondJoin();
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

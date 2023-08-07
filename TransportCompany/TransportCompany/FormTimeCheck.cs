using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompanyBusinessLogic.BusinessLogic;
using TransportCompanyContracts.BusinessLogicsContracts;

namespace TransportCompany
{
    //форма за измерения времени считывания значений
    public partial class FormTimeCheck : Form
    {
        private readonly ITruckingLogic _truckingLogic;

        public FormTimeCheck(ITruckingLogic truckingLogic)
        {
            InitializeComponent();

            _truckingLogic = truckingLogic;
        }

        private void ButtonStartTest_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _truckingLogic.TestReadList();

                string[] parameters = result.Split(' ');

                textBoxCount.Text = parameters[0];

                textBoxTimeWork.Text = parameters[1];
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

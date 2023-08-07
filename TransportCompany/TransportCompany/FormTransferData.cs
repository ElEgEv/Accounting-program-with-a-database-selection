using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompanyBusinessLogic.BusinessLogic;
using TransportCompanyContracts.BusinessLogicsContracts;

namespace TransportCompany
{
	//форма для перегона данных в MongoDB
	public partial class FormTransferData : Form
	{
		private ICargoLogic _cargoLogic;

		private ITruckingLogic _truckingLogic;

		private ITransportLogic _transportLogic;

		private IClientLogic _clientLogic;

		public FormTransferData(ICargoLogic cargoLogic, ITruckingLogic truckingLogic, IClientLogic clientLogic, ITransportLogic transportLogic)
		{
			InitializeComponent();

			_cargoLogic = cargoLogic;
			_truckingLogic = truckingLogic;
			_clientLogic = clientLogic;
			_transportLogic = transportLogic;
		}

		private void ButtonStartTransfer_Click(object sender, EventArgs e)
		{
			var soundPlayer = new SoundPlayer(@"C:\Users\Programmist73\Desktop\Практика\2-й курс\4-й семестр\СУБД\Лаб. раб. №8\led-tronulsya.wav");
			
			soundPlayer.PlaySync(); // can also use soundPlayer.PlaySync()

			Program.ConnectPostgres();

			_cargoLogic = Program.ServiceProvider.GetService(typeof(ICargoLogic)) as CargoLogic;
			_clientLogic = Program.ServiceProvider.GetService(typeof(IClientLogic)) as ClientLogic;
			_truckingLogic = Program.ServiceProvider.GetService(typeof(ITruckingLogic)) as TruckingLogic;
			_transportLogic = Program.ServiceProvider.GetService(typeof(ITransportLogic)) as TransportLogic;

			var cargolist = _cargoLogic.ReadList(null);
			var clientlist = _clientLogic.ReadList(null);
			var truckinglist = _truckingLogic.ReadList(null);
			var transportlist = _transportLogic.ReadList(null);

			Program.ConnectMongo();

			_cargoLogic = Program.ServiceProvider.GetService(typeof(ICargoLogic)) as CargoLogic;
			_clientLogic = Program.ServiceProvider.GetService(typeof(IClientLogic)) as ClientLogic;
			_truckingLogic = Program.ServiceProvider.GetService(typeof(ITruckingLogic)) as TruckingLogic;
			_transportLogic = Program.ServiceProvider.GetService(typeof(ITransportLogic)) as TransportLogic;

			_cargoLogic.TransferData(cargolist);
			_clientLogic.TransferData(clientlist);
			_transportLogic.TransferData(transportlist);
			_truckingLogic.TransferData(truckinglist);

			MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

			Program.ConnectPostgres();
		}
	}
}

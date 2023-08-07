using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyContracts.BusinessLogicsContracts
{
	public interface ITruckingLogic
	{
		List<TruckingViewModel>? ReadList(TruckingSearchModel? model);

        string? TestReadList();

		string? TestFirstJoin();

        TruckingViewModel? ReadElement(TruckingSearchModel model);

		bool Create(TruckingBindingModel model);

        string TestRandomCreate(int count, List<ClientViewModel> clients, List<CargoViewModel> cargos, List<TransportViewModel> transports, List<TransportationViewModel> transportations);

        bool Update(TruckingBindingModel model);

		bool Delete(TruckingBindingModel model);

		bool TransferData(List<TruckingViewModel> model);
	}
}

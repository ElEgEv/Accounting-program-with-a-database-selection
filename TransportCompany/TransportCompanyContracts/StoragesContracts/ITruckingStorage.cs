using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyContracts.StoragesContracts
{
	public interface ITruckingStorage
	{
		List<TruckingViewModel> GetFullList();

		string TestGetFullList();

        string FirstJoin();

        List<TruckingViewModel> GetFilteredList(TruckingSearchModel model);

		TruckingViewModel? GetElement(TruckingSearchModel model);

		TruckingViewModel? Insert(TruckingBindingModel model);

        string TestRandomInsert(int count, List<ClientViewModel> clients, List<CargoViewModel> cargos, List<TransportViewModel> transports, List<TransportationViewModel> transportations);

        TruckingViewModel? Update(TruckingBindingModel model);

		TruckingViewModel? Delete(TruckingBindingModel model);

		bool InsertFromPostgres(List<TruckingViewModel> model);
	}
}

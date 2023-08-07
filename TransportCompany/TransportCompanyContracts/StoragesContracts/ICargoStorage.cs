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
	public interface ICargoStorage
	{
		List<CargoViewModel> GetFullList();

		List<CargoViewModel> GetFilteredList(CargoSearchModel model);

		CargoViewModel? GetElement(CargoSearchModel model);

		CargoViewModel? Insert(CargoBindingModel model);

		CargoViewModel? Update(CargoBindingModel model);

		CargoViewModel? Delete(CargoBindingModel model);

		bool InsertFromPostgres(List<CargoViewModel> model);
	}
}

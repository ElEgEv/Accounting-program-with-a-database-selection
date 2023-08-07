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
	public interface ICargoLogic
	{
		List<CargoViewModel>? ReadList(CargoSearchModel? model);

		CargoViewModel? ReadElement(CargoSearchModel model);

		bool Create(CargoBindingModel model);

		bool Update(CargoBindingModel model);

		bool Delete(CargoBindingModel model);

		bool TransferData(List<CargoViewModel> model);
	}
}

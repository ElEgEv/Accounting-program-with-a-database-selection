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
	public interface ITransportationStorage
	{
		List<TransportationViewModel> GetFullList();

		List<TransportationViewModel> GetFilteredList(TransportationSearchModel model);

		TransportationViewModel? GetElement(TransportationSearchModel model);

		TransportationViewModel? Insert(TransportationBindingModel model);

		TransportationViewModel? Update(TransportationBindingModel model);

		TransportationViewModel? Delete(TransportationBindingModel model);

		bool InsertFromPostgres(List<TransportationViewModel> model);
	}
}

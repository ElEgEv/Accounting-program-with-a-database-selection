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
	public interface ITransportStorage
	{
		List<TransportViewModel> GetFullList();

		List<TransportViewModel> GetFilteredList(TransportSearchModel model);

		TransportViewModel? GetElement(TransportSearchModel model);

		TransportViewModel? Insert(TransportBindingModel model);

		TransportViewModel? Update(TransportBindingModel model);

		TransportViewModel? Delete(TransportBindingModel model);

		bool InsertFromPostgres(List<TransportViewModel> model);
	}
}

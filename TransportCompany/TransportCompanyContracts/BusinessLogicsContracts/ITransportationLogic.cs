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
	public interface ITransportationLogic
	{
		List<TransportationViewModel>? ReadList(TransportationSearchModel? model);

		TransportationViewModel? ReadElement(TransportationSearchModel model);

		bool Create(TransportationBindingModel model);

		bool Update(TransportationBindingModel model);

		bool Delete(TransportationBindingModel model);
	}
}

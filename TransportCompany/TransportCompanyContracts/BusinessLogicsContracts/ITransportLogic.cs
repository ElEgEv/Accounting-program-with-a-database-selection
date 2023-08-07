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
	public interface ITransportLogic
	{
		List<TransportViewModel>? ReadList(TransportSearchModel? model);

		TransportViewModel? ReadElement(TransportSearchModel model);

		bool Create(TransportBindingModel model);

		bool Update(TransportBindingModel model);

		bool Delete(TransportBindingModel model);

		bool TransferData(List<TransportViewModel> model);
	}
}

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
	public interface IClientLogic
	{
		List<ClientViewModel>? ReadList(ClientSearchModel? model);

		ClientViewModel? ReadElement(ClientSearchModel model);

		bool Create(ClientBindingModel model);

        string TestRandomCreate(int count, string[] _name, string[] _surname, string[] _patronymic, string[] _telephone, string[] _email);

		string TestSecondJoin();

        bool Update(ClientBindingModel model);

		bool Delete(ClientBindingModel model);

		bool TransferData(List<ClientViewModel> model);
	}
}

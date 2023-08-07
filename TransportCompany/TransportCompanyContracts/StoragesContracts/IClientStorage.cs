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
	public interface IClientStorage
	{
		List<ClientViewModel> GetFullList();

		List<ClientViewModel> GetFilteredList(ClientSearchModel model);

		ClientViewModel? GetElement(ClientSearchModel model);

		ClientViewModel? Insert(ClientBindingModel model);

        string TestRandomInsert(int count, string[] _name, string[] _surname, string[] _patronymic, string[] _telephone, string[] _email);

		string SecondJoin();

        ClientViewModel? Update(ClientBindingModel model);

		ClientViewModel? Delete(ClientBindingModel model);

		bool InsertFromPostgres(List<ClientViewModel> model);
	}
}

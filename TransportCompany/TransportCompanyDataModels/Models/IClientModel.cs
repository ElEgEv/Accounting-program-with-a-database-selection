using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyDataModels.Models
{
	public interface IClientModel : IId
	{
		string Name { get; }

		string Surname { get; }

		//отчество
		string Patronymic { get; }

		string Telephone { get; }

		string Email { get; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyContracts.SearchModels
{
	public class ClientSearchModel
	{
		public int? Id { get; set; }

		public string? MongoId { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public string? Patronymic { get; set; }

		public string? TelephoneNumber { get; set; }

		public string? Email { get; set; }
	}
}

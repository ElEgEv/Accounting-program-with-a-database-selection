using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.BindingModels
{
	public class ClientBindingModel : IClientModel
	{
		public int Id { get; set; }

		public string? MongoId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Surname { get; set; } = string.Empty;

		public string Patronymic { get; set; } = string.Empty;

		public string Telephone { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;
	}
}

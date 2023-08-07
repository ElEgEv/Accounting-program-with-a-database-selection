using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.BindingModels
{
	public class CargoBindingModel : ICargoModel
	{
		public int Id { get; set; }

		public string? MongoId { get; set; }

		public string TypeCargo { get; set; } = string.Empty;
	}
}

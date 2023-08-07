using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.ViewModels
{
	public class CargoViewModel : ICargoModel
	{
		public int Id { get; set; }

		public string? MongoId { get; set; }

		[DisplayName("Тип груза")]
		public string TypeCargo {get; set; } = string.Empty;
	}
}

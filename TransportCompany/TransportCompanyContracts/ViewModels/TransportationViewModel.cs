using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.ViewModels
{
	public class TransportationViewModel : ITransportationModel
	{
		public int Id { get; set; }

		public string? MongoId { get; set; }

		[DisplayName("Тип транспортировки")]
		public string TransportationType { get; set; } = string.Empty;
	}
}

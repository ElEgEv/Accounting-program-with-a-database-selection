using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.ViewModels
{
	public class TransportViewModel : ITransportModel
	{
		[DisplayName("Номер")]
		public int Id { get; set; }

		[DisplayName("Номер")]
		public string? MongoId { get; set; }

		[DisplayName("Вид транспорта")]
		public string Tranport { get; set; } = string.Empty;

		[DisplayName("Тип перевозки")]
		public string? TransportationType { get; set; }
	}
}

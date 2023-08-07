using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyContracts.SearchModels
{
	public class TruckingSearchModel
	{
		public int? Id { get; set; }

		public string? MongoId { get; set; }

		public int? ClientId { get; set; }

		public DateTime? DateStart { get; set; }

		public DateTime? DateEnd { get; set; }
	}
}

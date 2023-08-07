using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyContracts.SearchModels
{
	public class TransportSearchModel
	{
		public int? Id { get; set; }

		public string? MongoId { get; set; }

		public string? Tranport { get; set; }
	}
}

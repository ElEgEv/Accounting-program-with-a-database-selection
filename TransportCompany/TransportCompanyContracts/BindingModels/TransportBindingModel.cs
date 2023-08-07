using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.BindingModels
{
	public class TransportBindingModel : ITransportModel
	{
		public int Id { get; set; }

		public string? MongoId { get; set; }

		//для MongoDB
		public string? TransportationType { get; set; }

		public string Tranport { get; set; } = string.Empty;
	}
}

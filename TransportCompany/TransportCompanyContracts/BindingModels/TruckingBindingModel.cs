using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.BindingModels
{
	public class TruckingBindingModel : ITruckingModel
	{
		public int Id { get; set; }

		public string? MongoId { get; set; }

		public int ClientId { get; set; }

		public int CargoId { get; set; }

		public double Price { get; set; }

		public DateTime DateStart { get; set; }

		public DateTime DateEnd { get; set; }

		public int TransportationId { get; set; }

		public int TransportId { get; set; }

		public string Client { get; set; }

		public string Cargo { get; set; }

		public string Transport { get; set; }
	}
}

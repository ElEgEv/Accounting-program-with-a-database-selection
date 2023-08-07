using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyDataModels.Models
{
	public interface ITruckingModel : IId
	{
		int ClientId { get; }

		int CargoId { get; }

		double Price { get; }

		DateTime DateStart { get; }

		DateTime DateEnd { get; }

		int TransportationId { get; }

		int TransportId { get; }
	}
}

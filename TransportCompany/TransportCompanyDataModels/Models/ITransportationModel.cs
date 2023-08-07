using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyDataModels.Models
{
	public interface ITransportationModel : IId
	{
		//тип транспортировки
		string TransportationType { get; } 
	}
}

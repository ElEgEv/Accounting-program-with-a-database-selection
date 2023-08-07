using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyDataModels.Models
{
	public interface ITransportModel : IId
	{
		//тип транспорта для перевозки
		string Tranport { get; }
	}
}

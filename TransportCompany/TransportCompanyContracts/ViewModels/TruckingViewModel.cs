using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.ViewModels
{
	public class TruckingViewModel : ITruckingModel
	{
		[DisplayName("Номер")]
		public int Id { get; set; }

		[DisplayName("Номер")]
		public string? MongoId { get; set; }

		public int ClientId { get; set; }

		[DisplayName("Имя")]
		public string ClientName { get; set; } = string.Empty;

		[DisplayName("Фамилия")]
		public string ClientSurname { get; set; } = string.Empty;

		[DisplayName("Отчество")]
		public string ClientPatronymic { get; set; } = string.Empty;

		[DisplayName("Почта")]
		public string ClientEmail { get; set; } = string.Empty;

		public int CargoId { get; set; }

		[DisplayName("Объект перевозки")]
		public string Cargo { get; set; } = string.Empty;

		public int TransportId { get; set; }

		[DisplayName("Тип транспорта")]
		public string TransportName { get; set; } = string.Empty;

		public int TransportationId { get; set; }

		[DisplayName("Тип перевозки")]
		public string TypeTransportation { get; set; } = string.Empty;

		[DisplayName("Цена")]
		public double Price { get; set; }

		[DisplayName("Дата оформления перевозки")]
		public DateTime DateStart { get; set; }

		[DisplayName("Дата завершения перевозки")]
		public DateTime DateEnd { get; set; }
	}
}

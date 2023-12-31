﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyDataModels.Models;

namespace TransportCompanyContracts.ViewModels
{
	public class ClientViewModel : IClientModel
	{
		public int Id { get; set; }

		public string? MongoId { get; set; }

		[DisplayName("Имя")]
		public string Name { get; set; } = string.Empty;

		[DisplayName("Фамилия")]
		public string Surname { get; set; } = string.Empty;

		[DisplayName("Отчество")]
		public string Patronymic { get; set; } = string.Empty;

		[DisplayName("Телефон")]
		public string Telephone { get; set; } = string.Empty;

		[DisplayName("Почта")]
		public string Email { get; set; } = string.Empty;
	}
}

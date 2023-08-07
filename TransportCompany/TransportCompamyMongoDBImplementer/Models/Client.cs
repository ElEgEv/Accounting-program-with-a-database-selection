using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompamyMongoDBImplementer.Models
{
	public class Client
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

		public string Patronymic { get; set; } = null!;

		public string Telephone { get; set; } = null!;

		public string Email { get; set; } = null!;

		//public virtual ICollection<Trucking> Truckings { get; set; } = new List<Trucking>();

		public static Client Create(ClientBindingModel model)
		{
			return new Client()
			{
				Id = model.MongoId,
				Name = model.Name,
				Surname = model.Surname,
				Patronymic = model.Patronymic,
				Telephone = model.Telephone,
				Email = model.Email,
			};
		}

		public void Update(ClientBindingModel model)
		{
			Name = model.Name;
			Surname = model.Surname;
			Patronymic = model.Patronymic;
			Telephone = model.Telephone;
			Email = model.Email;
		}

		public ClientViewModel GetViewModel => new()
		{
			MongoId = Id,
			Name = Name,
			Surname = Surname,
			Patronymic = Patronymic,
			Telephone = Telephone,
			Email = Email
		};
	}
}

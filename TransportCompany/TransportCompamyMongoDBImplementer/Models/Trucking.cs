using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;
using MongoDB.Driver;

namespace TransportCompamyMongoDBImplementer.Models
{
	public class Trucking
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public double Price { get; set; }

		public DateTime DateStart { get; set; }

		public DateTime DateEnd { get; set; }

		public Cargo Cargo { get; set; }

		public Client Client { get; set; }

		public Transport Transport { get; set; }

		public static Trucking? Create( DBMSContext context, TruckingBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			return new Trucking()
			{
				Id = model.MongoId,
				Price = model.Price,
				DateStart = model.DateStart,
				DateEnd = model.DateEnd,
				Cargo = context.ConnectToMongo<Cargo>("cargo").Find(x => x.Id == model.Cargo).FirstOrDefault(),
				Client = context.ConnectToMongo<Client>("client").Find(x => x.Id == model.Client).FirstOrDefault(),
				Transport = context.ConnectToMongo<Transport>("transport").Find(x => x.Id == model.Transport).FirstOrDefault()
			};
		}

		public void Update(TruckingBindingModel model)
		{
			if (model == null)
			{
				return;
			}

			Price = model.Price;
			DateStart = model.DateStart;
			DateEnd = model.DateEnd;
		}

		public TruckingViewModel GetViewModel => new()
		{
			MongoId = Id,
			Price = Price,
			DateStart = DateStart,
			DateEnd = DateEnd,
			ClientName = Client == null ? string.Empty : Client.Name,
			ClientSurname = Client == null ? string.Empty : Client.Surname,
			ClientPatronymic = Client == null ? string.Empty : Client.Patronymic,
			ClientEmail = Client == null ? string.Empty : Client.Email,
			TransportName = Transport == null ? string.Empty : Transport.TransportType,
			TypeTransportation = Transport == null ? string.Empty : Transport.TransportationType,
			Cargo = Cargo == null ? string.Empty : Cargo.TypeCargo
		};
	}
}

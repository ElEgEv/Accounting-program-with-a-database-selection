using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompamyMongoDBImplementer.Models;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.StoragesContracts;
using TransportCompanyContracts.ViewModels;

namespace TransportCompamyMongoDBImplementer.Implements
{
	public class TransportStorage : ITransportStorage
	{
		private DBMSContext context = new();

		public TransportViewModel? Delete(TransportBindingModel model)
		{
			var transportCollection = context.ConnectToMongo<Transport>("transport");

			var element = transportCollection.Find(rec => rec.Id == model.MongoId).FirstOrDefault();
			
			if (element != null)
			{
				transportCollection.DeleteOne(x => x.Id == model.MongoId);

				return element.GetViewModel;
			}

			return null;
		}

		public TransportViewModel? GetElement(TransportSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Tranport) && string.IsNullOrEmpty(model.MongoId))
			{
				return null;
			}

			var transportCollection = context.ConnectToMongo<Transport>("transport");

			return transportCollection.Find(x => (!string.IsNullOrEmpty(model.MongoId) && x.Id == model.MongoId)
				&& x.TransportType == model.Tranport || (!string.IsNullOrEmpty(model.MongoId) && x.Id == model.MongoId))
				.FirstOrDefault()
				?.GetViewModel;
		}

		public List<TransportViewModel> GetFilteredList(TransportSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return new();
			}

			var transportCollection = context.ConnectToMongo<Transport>("transport");

			return transportCollection.Find(x => x.Id == model.MongoId)
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<TransportViewModel> GetFullList()
		{
			var transportCollection = context.ConnectToMongo<Transport>("transport");

			return transportCollection.Find(_ => true)
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public TransportViewModel? Insert(TransportBindingModel model)
		{
			var transportCollection = context.ConnectToMongo<Transport>("transport");

			var newTransport = Transport.Create(model);

			if (newTransport == null)
			{
				return null;
			}

			transportCollection.InsertOne(newTransport);

			return newTransport.GetViewModel;
		}

		//добавление экземпляров сущности из Postgresql
		public bool InsertFromPostgres(List<TransportViewModel> model)
		{
			var transportCollection = context.ConnectToMongo<Transport>("transport");
			
			List<Transport> models = model.Select(x => Transport.Create(new()
			{
				Tranport = x.Tranport
			})).ToList();

			//цикл для перезаписи типа грузоперевозки
			foreach (var transport in models)
			{
				if (transport.TransportType.Equals("Баржа"))
				{
					transport.TransportationType = "Грузовая";
				}

				if (transport.TransportType.Equals("Вертолёт"))
				{
					transport.TransportationType = "Пассажирская";
				}

				if (transport.TransportType.Equals("Самолёт"))
				{
					transport.TransportationType = "Пассажирская";
				}

				if (transport.TransportType.Equals("Легковой автомобиль"))
				{
					transport.TransportationType = "Пассажирская";
				}

				if (transport.TransportType.Equals("Фура"))
				{
					transport.TransportationType = "Грузовая";
				}

				if (transport.TransportType.Equals("Минивен"))
				{
					transport.TransportationType = "Грузовая";
				}

				if (transport.TransportType.Equals("Открытый грузовик"))
				{
					transport.TransportationType = "Перевозка животных";
				}
			}

			transportCollection.InsertMany(models);

			return true;
		}

		public TransportViewModel? Update(TransportBindingModel model)
		{
			var transportCollection = context.ConnectToMongo<Transport>("transport");

			var transport = transportCollection.Find(x => x.Id == model.MongoId).FirstOrDefault();

			if (transport == null)
			{
				return null;
			}

			transport.Update(model);

			var filter = Builders<Transport>.Filter.Eq("Id", model.MongoId);
			transportCollection.ReplaceOne(filter, transport, new ReplaceOptions { IsUpsert = true });

			return transport.GetViewModel;
		}
	}
}

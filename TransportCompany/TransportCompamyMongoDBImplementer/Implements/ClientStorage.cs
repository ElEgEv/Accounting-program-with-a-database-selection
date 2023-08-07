using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public class ClientStorage : IClientStorage
	{
		private DBMSContext context = new();

		public List<ClientViewModel> GetFullList()
		{
			var clientCollection = context.ConnectToMongo<Client>("client");

			return clientCollection.Find(_ => true)
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.MongoId))
			{
				return new();
			}

			var clientCollection = context.ConnectToMongo<Client>("client");

			return clientCollection.Find(x => x.Id.Contains(model.MongoId))
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Name) && string.IsNullOrEmpty(model.MongoId))
			{
				return null;
			}

			var clientCollection = context.ConnectToMongo<Client>("client");

			return clientCollection.Find(x => (!string.IsNullOrEmpty(model.MongoId) && x.Id == model.MongoId))
				.FirstOrDefault()
				?.GetViewModel;
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			var clientCollection = context.ConnectToMongo<Client>("client");

			var newClient = Client.Create(model);

			if (newClient == null)
			{
				return null;
			}

			clientCollection.InsertOne(newClient);

			return newClient.GetViewModel;
		}

		//метод для замера вставки большого кол-ва клиентов в бд
		public string TestRandomInsert(int count, string[] _name, string[] _surname, string[] _patronymic, string[] _telephone, string[] _email)
		{
			var clientCollection = context.ConnectToMongo<Client>("client");

			Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

			//старт замера времени добавления в бд
			Stopwatch stopwatch = new();

			stopwatch.Start();

			for (int i = 0; i < count; i++)
			{
				var model = new Client
				{
					Name = _name[rnd.Next(0, _name.Length)],
					Surname = _surname[rnd.Next(0, _surname.Length)],
					Patronymic = _patronymic[rnd.Next(0, _patronymic.Length)],
					Telephone = _telephone[rnd.Next(0, _telephone.Length)],
					Email = _email[rnd.Next(0, _email.Length)],
				};

				clientCollection.InsertOne(model);
			}

			stopwatch.Stop();
			
			return stopwatch.ElapsedMilliseconds.ToString();
		}


		public string SecondJoin()
		{
			var clientCollection = context.ConnectToMongo<Client>("client");
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

			//старт замера времени добавления в бд
			Stopwatch stopwatch = new();

			stopwatch.Start();

			var secondJoin = from t in truckingCollection.Find(_ => true).ToList()
							 from c in clientCollection.Find(c => c.Id == t.Client.Id).ToList()
							 select new { c, t };

			//ВСЁ ГОТОВО ДЛЯ СЛЕДУЮЩЕГО ЗАМЕРА

			foreach (var element in secondJoin)
			{
				var trucking = truckingCollection.Find(x => x.Id == element.t.Id).FirstOrDefault();

				trucking.Update(new TruckingBindingModel
				{
					Price = element.t.Price,
					DateStart = element.t.DateStart.AddDays(10),
					DateEnd = element.t.DateEnd.AddDays(10)
				});

				var filter = Builders<Trucking>.Filter.Eq("Id", element.t.Id);
				truckingCollection.ReplaceOne(filter, trucking, new ReplaceOptions { IsUpsert = true });
			}

			stopwatch.Stop();

			return stopwatch.ElapsedMilliseconds.ToString();
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			var clientCollection = context.ConnectToMongo<Client>("client");

			var client = clientCollection.Find(x => x.Id == model.MongoId).FirstOrDefault();

			if (client == null)
			{
				return null;
			}

			client.Update(model);

			var filter = Builders<Client>.Filter.Eq("Id", model.MongoId);
			clientCollection.ReplaceOne(filter, client, new ReplaceOptions { IsUpsert = true });

			return client.GetViewModel;
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			var clientCollection = context.ConnectToMongo<Client>("client");

			var element = clientCollection.Find(rec => rec.Id == model.MongoId).FirstOrDefault();

			if (element != null)
			{
				clientCollection.DeleteOne(x => x.Id == model.MongoId);

				return element.GetViewModel;
			}

			return null;
		}

		//добавление экземпляров сущности из Postgresql
		public bool InsertFromPostgres(List<ClientViewModel> model)
		{
			var clientCollection = context.ConnectToMongo<Client>("client");

			List<Client> models = model.Select(x => Client.Create(new() { Name = x.Name, Surname = x.Surname,
			Patronymic = x.Patronymic, Email = x.Email, Telephone = x.Telephone })).ToList();

			clientCollection.InsertMany(models);

			return true;
		}
	}
}

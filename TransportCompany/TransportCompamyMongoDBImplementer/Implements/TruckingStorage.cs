using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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
	public class TruckingStorage : ITruckingStorage
	{
		private DBMSContext context = new();

		public TruckingViewModel? Delete(TruckingBindingModel model)
		{
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			var element = truckingCollection.Find(rec => rec.Id == model.MongoId).FirstOrDefault();

			if (element != null)
			{
				truckingCollection.DeleteOne(x => x.Id == model.MongoId);

				return element.GetViewModel;
			}

			return null;
		}

		public string FirstJoin()
		{
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");
			var clientCollection = context.ConnectToMongo<Client>("client");

			Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

			//старт замера времени добавления в бд
			Stopwatch stopwatch = new();

			stopwatch.Start();

			var firstJoin = from t in truckingCollection.Find(t => t.Price == 999999.0).ToList()
							from c in clientCollection.Find(c => c.Id == t.Client.Id).ToList()
							select new { t, c };

			//ВСЁ ГОТОВО ДЛЯ СЛЕДУЮЩЕГО ЗАМЕРА
			// 1200000.0

			foreach (var element in firstJoin)
			{
				var trucking = truckingCollection.Find(x => x.Id == element.t.Id).FirstOrDefault();

				trucking.Update(new TruckingBindingModel
				{
					Price = 999999.0,
					DateStart = element.t.DateStart,
					DateEnd = element.t.DateEnd,
				});

				var filter = Builders<Trucking>.Filter.Eq("Id", element.t.Id);
				truckingCollection.ReplaceOne(filter, trucking, new ReplaceOptions { IsUpsert = true });
			}

			stopwatch.Stop();

			return stopwatch.ElapsedMilliseconds.ToString();
		}

		public TruckingViewModel? GetElement(TruckingSearchModel model)
		{

			if (!model.Id.HasValue || !model.ClientId.HasValue)
			{
				return null;
			}

			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			return truckingCollection.Find(x => !string.IsNullOrEmpty(model.MongoId) && x.Id == model.MongoId)
				.FirstOrDefault()
				?.GetViewModel;
		}

		public List<TruckingViewModel> GetFilteredList(TruckingSearchModel model)
		{
			if (string.IsNullOrEmpty(model.MongoId))
			{
				return new();
			}

			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			//не забудь, что тут сделал исправление для поиска по id клиента в MongoDB
			return truckingCollection.Find(x => x.Client.Id == model.MongoId)
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<TruckingViewModel> GetFullList()
		{
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");
			
			return truckingCollection.Find(_ => true)
								 .ToList()
								 .Select(x => x.GetViewModel)
								 .ToList();
		}

		public TruckingViewModel? Insert(TruckingBindingModel model)
		{
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			var newTrucking = Trucking.Create(context, model);

			if (newTrucking == null)
			{
				return null;
			}

			truckingCollection.InsertOne(newTrucking);

			return newTrucking.GetViewModel;
		}

		public bool InsertFromPostgres(List<TruckingViewModel> model)
		{
			var clientCollection = context.ConnectToMongo<Client>("client");
			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");
			var transportCollection = context.ConnectToMongo<Transport>("transport");
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			//список, который по итогу и будем вставлять
			List<Trucking> models = new();

			foreach(var element in model)
			{
				var newTrucking = new TruckingBindingModel();

				newTrucking.DateStart = element.DateStart;
				newTrucking.DateEnd = element.DateEnd;
				newTrucking.Price = element.Price;
				newTrucking.Cargo = cargoCollection.Find(x => x.TypeCargo == element.Cargo).FirstOrDefault().Id;
				newTrucking.Client = clientCollection.Find(x => x.Email == element.ClientEmail).FirstOrDefault().Id;
				newTrucking.Transport = transportCollection.Find(x => x.TransportType == element.TransportName).FirstOrDefault().Id;
			
				models.Add(Trucking.Create(context, newTrucking));
			}

			truckingCollection.InsertMany(models);

			return true;
		}

		public string TestGetFullList()
		{
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			string result = null;

			//для замера времени считывания из бд
			Stopwatch stopwatch = new();

			stopwatch.Start();

			List<TruckingViewModel> list = truckingCollection.Find(_ => true)
								 .ToList()
								 .Select(x => x.GetViewModel)
								 .ToList();

			stopwatch.Stop();

			result = list.Count.ToString();

			list.Clear();

			return result + " " + stopwatch.ElapsedMilliseconds.ToString();
		}

		public string TestRandomInsert(int count, List<ClientViewModel> clients, List<CargoViewModel> cargos, List<TransportViewModel> transports, List<TransportationViewModel> transportations)
		{
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

			//старт замера времени добавления в бд
			Stopwatch stopwatch = new();

			stopwatch.Start();

			for (int i = 0; i < count; i++)
			{
				DateTime dateStart = new(rnd.Next(1991, 2023), rnd.Next(1, 12), rnd.Next(1, 28));
				DateTime dateEnd = dateStart.AddDays(20);

				var model = Trucking.Create(context, new()
				{
					Client = clients[rnd.Next(0, clients.Count)].MongoId,
					Cargo = cargos[rnd.Next(0, cargos.Count)].MongoId,
					Transport = transports[rnd.Next(0, transports.Count)].MongoId,
					DateStart = dateStart,
					DateEnd = dateEnd,
					Price = clients.Count * rnd.Next(100, 5000)
				});

				truckingCollection.InsertOne(model);
			}

			stopwatch.Stop();

			return stopwatch.ElapsedMilliseconds.ToString();
		}

		public TruckingViewModel? Update(TruckingBindingModel model)
		{
			var truckingCollection = context.ConnectToMongo<Trucking>("trucking");

			var trucking = truckingCollection.Find(x => x.Id == model.MongoId).FirstOrDefault();

			if (trucking == null)
			{
				return null;
			}

			trucking.Update(model);

			var filter = Builders<Trucking>.Filter.Eq("Id", model.MongoId);
			truckingCollection.ReplaceOne(filter, trucking, new ReplaceOptions { IsUpsert = true });

			return trucking.GetViewModel;
		}
	}
}

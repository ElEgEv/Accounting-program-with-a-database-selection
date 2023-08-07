using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TransportCompamyMongoDBImplementer.Models;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.StoragesContracts;
using TransportCompanyContracts.ViewModels;

namespace TransportCompamyMongoDBImplementer.Implements
{
	public class CargoStorage : ICargoStorage
	{
		private DBMSContext context = new();

		public CargoViewModel? Delete(CargoBindingModel model)
		{
			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");

			var element = cargoCollection.Find(rec => rec.Id == model.MongoId).FirstOrDefault();

			if (element != null)
			{
				cargoCollection.DeleteOne(x => x.Id == model.MongoId);

				return element.GetViewModel;
			}

			return null;
		}

		public CargoViewModel? GetElement(CargoSearchModel model)
		{
			if (string.IsNullOrEmpty(model.TypeCargo) && string.IsNullOrEmpty(model.MongoId))
			{
				return null;
			}

			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");

			return cargoCollection.Find(x => (!string.IsNullOrEmpty(model.TypeCargo) && x.TypeCargo == model.TypeCargo) ||
					(!string.IsNullOrEmpty(model.MongoId) && x.Id == model.MongoId))
				.FirstOrDefault()
				?.GetViewModel;
		}

		public List<CargoViewModel> GetFilteredList(CargoSearchModel model)
		{
			if (string.IsNullOrEmpty(model.MongoId))
			{
				return new();
			}

			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");

			return cargoCollection.Find(x => x.TypeCargo.Contains(model.TypeCargo))
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<CargoViewModel> GetFullList()
		{
			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");

			return cargoCollection.Find(_ => true)
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public CargoViewModel? Insert(CargoBindingModel model)
		{
			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");

			var newCargo = Cargo.Create(model);

			if (newCargo == null)
			{
				return null;
			}

			cargoCollection.InsertOne(newCargo);

			return newCargo.GetViewModel;
		}

		//добавление экземпляров сущности из Postgresql
		public bool InsertFromPostgres(List<CargoViewModel> model)
		{
			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");

			List<Cargo> models = model.Select(x => Cargo.Create(new() { TypeCargo = x.TypeCargo })).ToList();
			
			cargoCollection.InsertMany(models);

			return true;
		}

		public CargoViewModel? Update(CargoBindingModel model)
		{
			var cargoCollection = context.ConnectToMongo<Cargo>("cargo");

			var cargo = cargoCollection.Find(x => x.Id == model.MongoId).FirstOrDefault();

			if (cargo == null)
			{
				return null;
			}

			cargo.Update(model);

			var filter = Builders<Cargo>.Filter.Eq("Id", model.MongoId);
			cargoCollection.ReplaceOne(filter, cargo, new ReplaceOptions { IsUpsert = true });

			return cargo.GetViewModel;
		}
	}
}

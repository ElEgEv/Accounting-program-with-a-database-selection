using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.StoragesContracts;
using TransportCompanyContracts.ViewModels;
using TransportCompanyDatabaseImplements.Models;

namespace TransportCompanyDatabaseImplements.Implements
{
	public class CargoStorage : ICargoStorage
	{
		public CargoViewModel? Delete(CargoBindingModel model)
		{
			using var context = new ElegevContext();

			var element = context.Cargos
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.Cargos.Remove(element);
				context.SaveChanges();

				return element.GetViewModel;
			}

			return null;
		}

		public CargoViewModel? GetElement(CargoSearchModel model)
		{
			if (string.IsNullOrEmpty(model.TypeCargo) && !model.Id.HasValue)
			{
				return null;
			}

			using var context = new ElegevContext();

			return context.Cargos
				.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public List<CargoViewModel> GetFilteredList(CargoSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return new();
			}

			using var context = new ElegevContext();

			return context.Cargos
				.Where(x => x.Id == model.Id)
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<CargoViewModel> GetFullList()
		{
			using var context = new ElegevContext();

			return context.Cargos
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public CargoViewModel? Insert(CargoBindingModel model)
		{
			using var context = new ElegevContext();

			model.Id = context.Cargos.Count() > 0 ? context.Cargos.Max(x => x.Id) + 1 : 1;

			var newCargo = Cargo.Create(model);

			if (newCargo == null)
			{
				return null;
			}

			context.Cargos.Add(newCargo);
			context.SaveChanges();

			return newCargo.GetViewModel;
		}

		public CargoViewModel? Update(CargoBindingModel model)
		{
			using var context = new ElegevContext();
			using var transaction = context.Database.BeginTransaction();

			try
			{
				var cargo = context.Cargos.FirstOrDefault(rec => rec.Id == model.Id);

				if (cargo == null)
				{
					return null;
				}

				cargo.Update(model);
				context.SaveChanges();
				transaction.Commit();

				return cargo.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public bool InsertFromPostgres(List<CargoViewModel> model)
		{
			throw new NotImplementedException();
		}
	}
}

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
	public class TransportationStorage : ITransportationStorage
	{
		public TransportationViewModel? Delete(TransportationBindingModel model)
		{
			using var context = new ElegevContext();

			var element = context.TypeTransportations
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.TypeTransportations.Remove(element);
				context.SaveChanges();

				return element.GetViewModel;
			}

			return null;
		}

		public TransportationViewModel? GetElement(TransportationSearchModel model)
		{
			if (string.IsNullOrEmpty(model.TransportationType) && !model.Id.HasValue)
			{
				return null;
			}

			using var context = new ElegevContext();

			return context.TypeTransportations
				.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public List<TransportationViewModel> GetFilteredList(TransportationSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return new();
			}

			using var context = new ElegevContext();

			return context.TypeTransportations
				.Where(x => x.Id == model.Id)
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<TransportationViewModel> GetFullList()
		{
			using var context = new ElegevContext();

			return context.TypeTransportations
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public TransportationViewModel? Insert(TransportationBindingModel model)
		{
			using var context = new ElegevContext();

			model.Id = context.TypeTransportations.Count() > 0 ? context.TypeTransportations.Max(x => x.Id) + 1 : 1;

			var newTypeTransportation = TypeTransportation.Create(model);

			if (newTypeTransportation == null)
			{
				return null;
			}

			context.TypeTransportations.Add(newTypeTransportation);
			context.SaveChanges();

			return newTypeTransportation.GetViewModel;
		}

		public TransportationViewModel? Update(TransportationBindingModel model)
		{
			using var context = new ElegevContext();
			using var transaction = context.Database.BeginTransaction();

			try
			{
				var typeTransportations = context.TypeTransportations.FirstOrDefault(rec => rec.Id == model.Id);

				if (typeTransportations == null)
				{
					return null;
				}

				typeTransportations.Update(model);
				context.SaveChanges();
				transaction.Commit();

				return typeTransportations.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public bool InsertFromPostgres(List<TransportationViewModel> model)
		{
			throw new NotImplementedException();
		}
	}
}

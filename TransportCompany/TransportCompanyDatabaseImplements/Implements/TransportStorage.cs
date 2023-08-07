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
	public class TransportStorage : ITransportStorage
	{
		public TransportViewModel? Delete(TransportBindingModel model)
		{
			using var context = new ElegevContext();

			var element = context.Transports
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.Transports.Remove(element);
				context.SaveChanges();

				return element.GetViewModel;
			}

			return null;
		}

		public TransportViewModel? GetElement(TransportSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Tranport) && !model.Id.HasValue)
			{
				return null;
			}

			using var context = new ElegevContext();

			return context.Transports
				.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public List<TransportViewModel> GetFilteredList(TransportSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return new();
			}

			using var context = new ElegevContext();

			return context.Transports
				.Where(x => x.Id == model.Id)
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<TransportViewModel> GetFullList()
		{
			using var context = new ElegevContext();

			return context.Transports
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public TransportViewModel? Insert(TransportBindingModel model)
		{
			using var context = new ElegevContext();

			model.Id = context.Transports.Count() > 0 ? context.Transports.Max(x => x.Id) + 1 : 1;

			var newTransport = Transport.Create(model);

			if (newTransport == null)
			{
				return null;
			}

			context.Transports.Add(newTransport);
			context.SaveChanges();

			return newTransport.GetViewModel;
		}

		public TransportViewModel? Update(TransportBindingModel model)
		{
			using var context = new ElegevContext();
			using var transaction = context.Database.BeginTransaction();

			try
			{
				var transport = context.Transports.FirstOrDefault(rec => rec.Id == model.Id);

				if (transport == null)
				{
					return null;
				}

				transport.Update(model);
				context.SaveChanges();
				transaction.Commit();

				return transport.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public bool InsertFromPostgres(List<TransportViewModel> model)
		{
			throw new NotImplementedException();
		}
	}
}

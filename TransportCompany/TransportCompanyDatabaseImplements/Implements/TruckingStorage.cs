using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public class TruckingStorage : ITruckingStorage
	{
		public TruckingViewModel? Delete(TruckingBindingModel model)
		{
			using var context = new ElegevContext();

			var element = context.Truckings
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.Truckings.Remove(element);
				context.SaveChanges();

				return element.GetViewModel;
			}

			return null;
		}

		public TruckingViewModel? GetElement(TruckingSearchModel model)
		{
			if (!model.Id.HasValue || !model.ClientId.HasValue)
			{
				return null;
			}

			using var context = new ElegevContext();

			return context.Truckings
				.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public List<TruckingViewModel> GetFilteredList(TruckingSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return new();
			}

			using var context = new ElegevContext();

			return context.Truckings
				.Where(x => x.Id == model.Id)
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<TruckingViewModel> GetFullList()
		{
			using var context = new ElegevContext();

			return context.Truckings
				.Include(x => x.Transport)
				.Include(x => x.Cargo)
				.Include(x => x.Transportation)
				.Include(x => x.Client)
				.Select(x => x.GetViewModel)
				.ToList();
		}


        public string TestGetFullList()
        {
            using var context = new ElegevContext();

			string result = null;

            //для замера времени считывания из бд
            Stopwatch stopwatch = new();

            stopwatch.Start();

			List<TruckingViewModel> list = context.Truckings
                    .Include(x => x.Transport)
                    .Include(x => x.Cargo)
                    .Include(x => x.Transportation)
                    .Include(x => x.Client)
                    .Select(x => x.GetViewModel)
                    .ToList();

            stopwatch.Stop();

			result = list.Count.ToString();

			list.Clear();

            return result + " " + stopwatch.ElapsedMilliseconds.ToString();
        }

        public TruckingViewModel? Insert(TruckingBindingModel model)
		{
			using var context = new ElegevContext();

			model.Id = context.Truckings.Count() > 0 ? context.Truckings.Max(x => x.Id) + 1 : 1;

			var newTrucking = Trucking.Create(model);

			if (newTrucking == null)
			{
				return null;
			}

			context.Truckings.Add(newTrucking);
			context.SaveChanges();

			return context.Truckings
					.Include(x => x.Transport)
					.Include(x => x.Cargo)
					.Include(x => x.Transportation)
					.Include(x => x.Client)
					.FirstOrDefault(x => x.Id == model.Id)
					?.GetViewModel;
		}

        //метод для замера вставки большого кол-ва клиентов в бд
        public string TestRandomInsert(int count, List<ClientViewModel> clients, List<CargoViewModel> cargos, List<TransportViewModel> transports, List<TransportationViewModel> transportations)
        {
            using var context = new ElegevContext();

            Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

            int lastId = context.Truckings.Count() > 0 ? context.Truckings.Max(x => x.Id) + 1 : 1;

            for (int i = 0; i < count; i++)
			{
				DateTime dateStart = new(rnd.Next(1991, 2023), rnd.Next(1, 12), rnd.Next(1, 28));
				DateTime dateEnd = dateStart.AddDays(20);

				var model = new Trucking
				{
					Id = lastId,
					ClientId = clients[rnd.Next(0, clients.Count)].Id,
					CargoId = cargos[rnd.Next(0, cargos.Count)].Id,
					TransportId = transports[rnd.Next(0, transports.Count)].Id,
					TransportationId = transportations[rnd.Next(0, transportations.Count)].Id,
					DateStart = dateStart,
					DateEnd = dateEnd,
					Price = clients.Count * rnd.Next(100, 5000)
				};

				lastId++;

                context.Truckings.Add(model);
            }

            //старт замера времени добавления в бд
            Stopwatch stopwatch = new();

            stopwatch.Start();

            context.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds.ToString();
        }

        public TruckingViewModel? Update(TruckingBindingModel model)
		{
			using var context = new ElegevContext();
			using var transaction = context.Database.BeginTransaction();

			try
			{
				var trucking = context.Truckings.FirstOrDefault(rec => rec.Id == model.Id);

				if (trucking == null)
				{
					return null;
				}

				trucking.Update(model);
				context.SaveChanges();
				transaction.Commit();

				return trucking.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		//первый сложный запрос
		public string FirstJoin()
		{
            using var context = new ElegevContext();

            Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

            //старт замера времени добавления в бд
            Stopwatch stopwatch = new();

            stopwatch.Start();

			var firstJoin = from t in context.Set<Trucking>().Where(t => t.Price == 1200000.0)
							from c in context.Set<Client>().Where(c => c.Id == t.ClientId)
							select new { t, c };

			//ВСЁ ГОТОВО ДЛЯ СЛЕДУЮЩЕГО ЗАМЕРА
            // 999999.0

            foreach (var element in firstJoin)
			{
				element.t.Update(new TruckingBindingModel
				{
                    Id = element.t.Id,
					ClientId = element.t.ClientId,
					CargoId = element.t.CargoId,
					Price = 999999.0,
					DateStart = element.t.DateStart,
					DateEnd = element.t.DateEnd,
					TransportationId = element.t.TransportationId,
					TransportId = element.t.TransportId,
				});
			}

			context.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds.ToString();
        }

		public bool InsertFromPostgres(List<TruckingViewModel> model)
		{
			throw new NotImplementedException();
		}
	}
}

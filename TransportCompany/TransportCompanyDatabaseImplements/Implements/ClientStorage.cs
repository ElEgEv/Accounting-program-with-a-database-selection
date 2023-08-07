using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.StoragesContracts;
using TransportCompanyContracts.ViewModels;
using TransportCompanyDatabaseImplements.Models;

namespace TransportCompanyDatabaseImplements.Implements
{
	public class ClientStorage : IClientStorage
	{
		public List<ClientViewModel> GetFullList()
		{
			using var context = new ElegevContext();

			return context.Clients
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return new();
			}

			using var context = new ElegevContext();

			return context.Clients
				.Where(x => x.Id == model.Id)
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Name) && !model.Id.HasValue)
			{
				return null;
			}

			using var context = new ElegevContext();

			return context.Clients
				.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			using var context = new ElegevContext();

			model.Id = context.Clients.Count() > 0 ? context.Clients.Max(x => x.Id) + 1 : 1;

			var newClient = Client.Create(model);

			if (newClient == null)
			{
				return null;
			}

			context.Clients.Add(newClient);
			context.SaveChanges();

			return newClient.GetViewModel;
		}

		//метод для замера вставки большого кол-ва клиентов в бд
        public string TestRandomInsert(int count, string[] _name, string[] _surname, string[] _patronymic, string[] _telephone, string[] _email)
        {
            using var context = new ElegevContext();

            Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

			int lastId = context.Clients.Count() > 0 ? context.Clients.Max(x => x.Id) + 1 : 1;

            for (int i = 0; i < count; i++)
			{
                var model = new Client
                {
                    Id = lastId,
					Name = _name[rnd.Next(0, _name.Length)],
                    Surname = _surname[rnd.Next(0, _surname.Length)],
                    Patronymic = _patronymic[rnd.Next(0, _patronymic.Length)],
                    Telephone = _telephone[rnd.Next(0, _telephone.Length)],
                    Email = _email[rnd.Next(0, _email.Length)],
                };

				lastId++;

                context.Clients.Add(model);
            }

			//старт замера времени добавления в бд
            Stopwatch stopwatch = new();

            stopwatch.Start();

            context.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds.ToString();
        }


        public string SecondJoin()
        {
            using var context = new ElegevContext();

            Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

            //старт замера времени добавления в бд
            Stopwatch stopwatch = new();

            stopwatch.Start();

            var secondJoin = from t in context.Set<Trucking>()
						from c in context.Set<Client>().Where(c => c.Id == t.ClientId)
                        select new { c, t };

            //ВСЁ ГОТОВО ДЛЯ СЛЕДУЮЩЕГО ЗАМЕРА

            foreach (var element in secondJoin)
            {
                element.t.Update(new TruckingBindingModel
                {
                    Id = element.t.Id,
                    ClientId = element.t.ClientId,
                    CargoId = element.t.CargoId,
                    Price = element.t.Price,
                    DateStart = element.t.DateStart.AddDays(-10),
                    DateEnd = element.t.DateEnd.AddDays(-10),
                    TransportationId = element.t.TransportationId,
                    TransportId = element.t.TransportId,
                });
            }

            context.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds.ToString();
        }

        public ClientViewModel? Update(ClientBindingModel model)
		{
			using var context = new ElegevContext();
			using var transaction = context.Database.BeginTransaction();

			try
			{
				var client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);

				if (client == null)
				{
					return null;
				}

				client.Update(model);
				context.SaveChanges();
				transaction.Commit();

				return client.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public ClientViewModel? Delete(ClientBindingModel model)
		{
			using var context = new ElegevContext();

			var element = context.Clients
				.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.Clients.Remove(element);
				context.SaveChanges();

				return element.GetViewModel;
			}

			return null;
		}

		public bool InsertFromPostgres(List<ClientViewModel> model)
		{
			throw new NotImplementedException();
		}
	}
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.BusinessLogicsContracts;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.StoragesContracts;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyBusinessLogic.BusinessLogic
{
	public class ClientLogic : IClientLogic
	{
		private readonly ILogger _logger;

		private readonly IClientStorage _clientStorage;

		public ClientLogic(ILogger<ClientLogic> logger, IClientStorage clientStorage)
		{
			_logger = logger;
			_clientStorage = clientStorage;
		}

		public List<ClientViewModel>? ReadList(ClientSearchModel? model)
		{
			_logger.LogInformation("ReadList. Surname:{Surname}. Id:{Id}", model?.Surname, model?.Id);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _clientStorage.GetFullList() : _clientStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");

				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		public ClientViewModel? ReadElement(ClientSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadElement. Surname:{Surname}. Id:{Id}", model.Surname, model.Id);

			var element = _clientStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", model.Id);

			return element;
		}

		public bool Create(ClientBindingModel model)
		{
			CheckModel(model);

			if (_clientStorage.Insert(model) == null)
			{
				_logger.LogWarning("Create operation failed");

				return false;
			}

			return true;
		}

		//для замера времени рандомного добавления
        public string TestRandomCreate(int count, string[] _name, string[] _surname, string[] _patronymic, string[] _telephone, string[] _email)
        {
			return _clientStorage.TestRandomInsert(count, _name, _surname, _patronymic, _telephone, _email);
        }

        //для проверки времени выполнения сложного запроса
        public string TestSecondJoin()
        {
            return _clientStorage.SecondJoin();
        }

        public bool Update(ClientBindingModel model)
		{
			CheckModel(model);

			if (_clientStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}

			return true;
		}

        public bool Delete(ClientBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_clientStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		//проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(ClientBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			//так как при удалении параметром withParams передаём false
			if (!withParams)
			{
				return;
			}

			//проверка на наличие имени
			if (string.IsNullOrEmpty(model.Name))
			{
				throw new ArgumentNullException("Нет имени клиента", nameof(model.Name));
			}

			//проверка на наличие фамилии
			if (string.IsNullOrEmpty(model.Surname))
			{
				throw new ArgumentNullException("Нет фамилии клиента", nameof(model.Surname));
			}

			//проверка на наличие отчества
			if (string.IsNullOrEmpty(model.Patronymic))
			{
				throw new ArgumentNullException("Нет отчества клиента", nameof(model.Patronymic));
			}

			//проверка на наличие телефонного номера
			if (string.IsNullOrEmpty(model.Telephone))
			{
				throw new ArgumentNullException("Нет телефонного номера клиента", nameof(model.Telephone));
			}

			//проверка на наличие почты
			if (string.IsNullOrEmpty(model.Email))
			{
				throw new ArgumentNullException("Нет электронной почты клиента", nameof(model.Email));
			}

			_logger.LogInformation("Client. Name:{Name}. Surname:{Surname}. Patronymic:{Patronymic}. " +
				"TelephoneNumber:{TelephoneNumber}. Email:{Email}. Id:{Id}",
				model.Name, model.Surname, model.Patronymic, model.Telephone, model.Email, model.Id);

			//проверка на наличие такой же почты в списке
			var element = _clientStorage.GetElement(new ClientSearchModel
			{
				Email = model.Email,
			});

			//если почта найдена и его Id не совпадает с Id объекта, переданного на вход
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Клиент с такой почтой уже есть");
			}
		}

		public bool TransferData(List<ClientViewModel> model)
		{
			return _clientStorage.InsertFromPostgres(model);
		}
	}
}

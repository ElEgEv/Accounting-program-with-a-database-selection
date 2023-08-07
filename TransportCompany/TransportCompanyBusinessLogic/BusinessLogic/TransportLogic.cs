using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.BusinessLogicsContracts;
using TransportCompanyContracts.SearchModels;
using TransportCompanyContracts.StoragesContracts;
using TransportCompanyContracts.ViewModels;

namespace TransportCompanyBusinessLogic.BusinessLogic
{
	public class TransportLogic : ITransportLogic
	{
		private readonly ILogger _logger;

		private readonly ITransportStorage _transportStorage;

		//конструктор
		public TransportLogic(ILogger<TransportLogic> logger, ITransportStorage transportStorage)
		{
			_logger = logger;
			_transportStorage = transportStorage;
		}

		public List<TransportViewModel>? ReadList(TransportSearchModel? model)
		{
			_logger.LogInformation("ReadList. Tranport:{Tranport}. Id:{Id}", model?.Tranport, model?.Id);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _transportStorage.GetFullList() : _transportStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");

				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		public TransportViewModel? ReadElement(TransportSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadElement. Tranport:{Tranport}. Id:{Id}", model.Tranport, model.Id);

			var element = _transportStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", model.Id);

			return element;
		}

		public bool Create(TransportBindingModel model)
		{
			CheckModel(model);

			if (_transportStorage.Insert(model) == null)
			{
				_logger.LogWarning("Create operation failed");

				return false;
			}

			return true;
		}

		public bool Update(TransportBindingModel model)
		{
			CheckModel(model);

			if (_transportStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}

			return true;
		}

		public bool Delete(TransportBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_transportStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		//проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(TransportBindingModel model, bool withParams = true)
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

			//проверка на наличие названия транспортного средства
			if (string.IsNullOrEmpty(model.Tranport))
			{
				throw new ArgumentNullException("Нет названия транспортного средства", nameof(model.Tranport));
			}

			_logger.LogInformation("Tranport. Tranport:{Tranport}. Id:{Id}", model.Tranport, model.Id);

			//проверка на наличие такого же транспортного средства в списке
			var element = _transportStorage.GetElement(new TransportSearchModel
			{
				Tranport = model.Tranport,
			});

			//если элемент найден и его Id не совпадает с Id объекта, переданного на вход
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Такое транспортное средство уже есть");
			}
		}

		public bool TransferData(List<TransportViewModel> model)
		{
			return _transportStorage.InsertFromPostgres(model);
		}
	}
}

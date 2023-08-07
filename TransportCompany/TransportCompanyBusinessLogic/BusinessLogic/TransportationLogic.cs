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
	public class TransportationLogic : ITransportationLogic
	{
		private readonly ILogger _logger;

		private readonly ITransportationStorage _transportationStorage;

		//конструктор
		public TransportationLogic(ILogger<TransportationLogic> logger, ITransportationStorage transportationStorage)
		{
			_logger = logger;
			_transportationStorage = transportationStorage;
		}


		public List<TransportationViewModel>? ReadList(TransportationSearchModel? model)
		{
			_logger.LogInformation("ReadList. TransportationType:{TransportationType}. Id:{Id}", model?.TransportationType, model?.Id);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _transportationStorage.GetFullList() : _transportationStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");

				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		public TransportationViewModel? ReadElement(TransportationSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadElement. TransportationType:{TransportationType}. Id:{Id}", model.TransportationType, model.Id);

			var element = _transportationStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", model.Id);

			return element;
		}

		public bool Create(TransportationBindingModel model)
		{
			CheckModel(model);

			if (_transportationStorage.Insert(model) == null)
			{
				_logger.LogWarning("Create operation failed");

				return false;
			}

			return true;
		}

		public bool Update(TransportationBindingModel model)
		{
			CheckModel(model);

			if (_transportationStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}

			return true;
		}

		public bool Delete(TransportationBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_transportationStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		//проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(TransportationBindingModel model, bool withParams = true)
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

			//проверка на наличие типа перевозки
			if (string.IsNullOrEmpty(model.TransportationType))
			{
				throw new ArgumentNullException("Нет названия изделия", nameof(model.TransportationType));
			}

			_logger.LogInformation("Transportation. TransportationType:{TransportationType}. Id:{Id}",
				model.TransportationType, model.Id);

			//проверка на наличие такого же типа перевозки в списке
			var element = _transportationStorage.GetElement(new TransportationSearchModel
			{
				TransportationType = model.TransportationType,
			});

			//если элемент найден и его Id не совпадает с Id объекта, переданного на вход
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Такой тип перевозки уже есть");
			}
		}
	}
}

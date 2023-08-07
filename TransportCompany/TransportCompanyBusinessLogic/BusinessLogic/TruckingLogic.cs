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
	public class TruckingLogic : ITruckingLogic
	{
		private readonly ILogger _logger;

		private readonly ITruckingStorage _truckingStorage;

		//конструктор
		public TruckingLogic(ILogger<TruckingLogic> logger, ITruckingStorage truckingStorage)
		{
			_logger = logger;
			_truckingStorage = truckingStorage;
		}

		public List<TruckingViewModel>? ReadList(TruckingSearchModel? model)
		{
			_logger.LogInformation("ReadList. ClientId:{ClientId}. DateStart:{DateStart} Id:{Id}", model?.ClientId, model?.DateStart, model?.Id);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _truckingStorage.GetFullList() : _truckingStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");

				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		//для замера времени считывания значений
        public string? TestReadList()
        {
			return _truckingStorage.TestGetFullList();
        }

        public TruckingViewModel? ReadElement(TruckingSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadElement. ClientId:{ClientId}. DateStart:{DateStart} Id:{Id}", model?.ClientId, model?.DateStart, model?.Id);

			var element = _truckingStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", model.Id);

			return element;
		}

		public bool Create(TruckingBindingModel model)
		{
			CheckModel(model);

			if (_truckingStorage.Insert(model) == null)
			{
				_logger.LogWarning("Create operation failed");

				return false;
			}

			return true;
		}

        public string TestRandomCreate(int count, List<ClientViewModel> clients, List<CargoViewModel> cargos, List<TransportViewModel> transports, List<TransportationViewModel> transportations)
        {
			return _truckingStorage.TestRandomInsert(count, clients, cargos, transports, transportations);
        }

		//первый сложный запрос
        public string? TestFirstJoin()
        {
			return _truckingStorage.FirstJoin();
        }

        public bool Update(TruckingBindingModel model)
		{
			CheckModel(model);

			if (_truckingStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}

			return true;
		}

		public bool Delete(TruckingBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_truckingStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		//проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(TruckingBindingModel model, bool withParams = true)
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

			//проверка на корректный id заказчика
			if (model.ClientId <= 0 && string.IsNullOrEmpty(model.Client))
			{
				throw new ArgumentNullException("Некорректный id заказчика", nameof(model.ClientId));
			}

			//проверка на корректный id груза
			if (model.CargoId <= 0 && string.IsNullOrEmpty(model.Cargo))
			{
				throw new ArgumentNullException("Некорректный id груза", nameof(model.CargoId));
			}

			//проверка на корректный id транспорта
			if (model.TransportId <= 0 && string.IsNullOrEmpty(model.Transport))
			{
				throw new ArgumentNullException("Некорректный id транспорта", nameof(model.TransportId));
			}

			//проверка на корректный id типа транспортировки
			if (model.TransportationId <= 0 && string.IsNullOrEmpty(model.Transport))
			{
				throw new ArgumentNullException("Некорректный id типа транспортировки", nameof(model.TransportationId));
			}

			//проверка на корректную дату начала транспортировки
			if (model.DateStart > model.DateEnd)
			{
				throw new ArgumentNullException("Дата начала транспортировки должна быть раньше даты окончания перевозки", nameof(model.DateStart));
			}

			_logger.LogInformation("Trucking. ClientId:{ClientId}. CargoId:{CargoId}. TransportId:{TransportId}." +
				"TransportationId:{TransportationId}. DateStart:{DateStart}. DateEnd:{DateEnd}. Id:{Id}",
				model.ClientId, model.CargoId, model.TransportId, model.TransportationId, model.DateStart, model.DateEnd, model.Id);
		}

		public bool TransferData(List<TruckingViewModel> model)
		{
			return _truckingStorage.InsertFromPostgres(model);
		}
	}
}

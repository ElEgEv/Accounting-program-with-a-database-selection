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
	public class CargoLogic : ICargoLogic
	{
		private readonly ILogger _logger;

		private readonly ICargoStorage _cargoStorage;

		//конструктор
		public CargoLogic(ILogger<CargoLogic> logger, ICargoStorage cargoStorage)
		{
			_logger = logger;
			_cargoStorage = cargoStorage;
		}

		public List<CargoViewModel>? ReadList(CargoSearchModel? model)
		{
			_logger.LogInformation("ReadList. TypeCargo:{TypeCargo}. Id:{Id}", model?.TypeCargo, model?.Id);

			//list хранит весь список в случае, если model пришло со значением null на вход метода
			var list = model == null ? _cargoStorage.GetFullList() : _cargoStorage.GetFilteredList(model);

			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");

				return null;
			}

			_logger.LogInformation("ReadList. Count:{Count}", list.Count);

			return list;
		}

		public CargoViewModel? ReadElement(CargoSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			_logger.LogInformation("ReadElement. TypeCargo:{TypeCargo}. Id:{Id}", model.TypeCargo, model.Id);

			var element = _cargoStorage.GetElement(model);

			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");

				return null;
			}

			_logger.LogInformation("ReadElement find. Id:{Id}", model.Id);

			return element;
		}

		public bool Create(CargoBindingModel model)
		{
			CheckModel(model);

			if (_cargoStorage.Insert(model) == null)
			{
				_logger.LogWarning("Create operation failed");

				return false;
			}

			return true;
		}

		public bool Update(CargoBindingModel model)
		{
			CheckModel(model);

			if (_cargoStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}

			return true;
		}

		public bool Delete(CargoBindingModel model)
		{
			CheckModel(model, false);

			_logger.LogInformation("Delete. Id:{Id}", model.Id);

			if (_cargoStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");

				return false;
			}

			return true;
		}

		//проверка входного аргумента для методов Insert, Update и Delete
		private void CheckModel(CargoBindingModel model, bool withParams = true)
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

			//проверка на наличие названия типа груза
			if (string.IsNullOrEmpty(model.TypeCargo))
			{
				throw new ArgumentNullException("названия типа груза", nameof(model.TypeCargo));
			}

			_logger.LogInformation("Cargo. TypeCargo:{TypeCargo}. Id:{Id}",
				model.TypeCargo, model.Id);

			//проверка на наличие такого же типа груза в списке
			var element = _cargoStorage.GetElement(new CargoSearchModel
			{
				TypeCargo = model.TypeCargo,
			});

			//если элемент найден и его Id не совпадает с Id объекта, переданного на вход
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Такой тип груза уже есть");
			}
		}

		public bool TransferData(List<CargoViewModel> model)
		{
			return _cargoStorage.InsertFromPostgres(model);
		}
	}
}

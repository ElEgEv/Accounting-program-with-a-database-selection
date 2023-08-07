using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TransportCompamyMongoDBImplementer.Implements;
using TransportCompanyBusinessLogic.BusinessLogic;
using TransportCompanyContracts.BusinessLogicsContracts;
using TransportCompanyContracts.StoragesContracts;
using TransportCompanyDatabaseImplements.Implements;

namespace TransportCompany
{
	internal static class Program
	{
		private static ServiceProvider? _serviceProvider;

		public static ServiceProvider? ServiceProvider => _serviceProvider;

		public static ServiceCollection _serviseCollection;

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font;
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			_serviseCollection = new ServiceCollection();
			ConfigureServices(_serviseCollection);
			_serviceProvider = _serviseCollection.BuildServiceProvider();
			Application.Run(_serviceProvider.GetRequiredService<FormTrucking>());
		}

		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddLogging(option =>
			{
				option.SetMinimumLevel(LogLevel.Information);
				option.AddNLog("nlog.config");
			});

			services.AddTransient<ICargoStorage, TransportCompanyDatabaseImplements.Implements.CargoStorage>();
			services.AddTransient<IClientStorage, TransportCompanyDatabaseImplements.Implements.ClientStorage>();
			services.AddTransient<ITransportStorage, TransportCompanyDatabaseImplements.Implements.TransportStorage>();
			services.AddTransient<ITransportationStorage, TransportationStorage>();
			services.AddTransient<ITruckingStorage, TransportCompanyDatabaseImplements.Implements.TruckingStorage>();

			services.AddTransient<ICargoLogic, CargoLogic>();
			services.AddTransient<IClientLogic, ClientLogic>();
			services.AddTransient<ITransportLogic, TransportLogic>();
			services.AddTransient<ITransportationLogic, TransportationLogic>();
			services.AddTransient<ITruckingLogic, TruckingLogic>();

			services.AddTransient<FormTrucking>();
			services.AddTransient<FormCargo>();
			services.AddTransient<FormClients>();
			services.AddTransient<FormTransport>();
			services.AddTransient<FormTypeTransportation>();
			services.AddTransient<FormCreateCargo>();
			services.AddTransient<FormCreateClient>();
			services.AddTransient<FormCreateTrucking>();
			services.AddTransient<FormCreateTransport>();
			services.AddTransient<FormCreateTypeTransportation>();
			services.AddTransient<FormRandomCreateClient>();
			services.AddTransient<FormRandomCreateTrucking>();
			services.AddTransient<FormTimeCheck>();
			services.AddTransient<FormCheckTimeJoin>();
			services.AddTransient<FormTransferData>();
		}

		//работа с Postgresql
		public static void ConnectPostgres()
		{
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ICargoStorage)));
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IClientStorage)));
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ITruckingStorage)));
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ITransportStorage)));
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ITransportationStorage)));
			
			_serviseCollection.AddTransient<ICargoStorage, TransportCompanyDatabaseImplements.Implements.CargoStorage>();
			_serviseCollection.AddTransient<IClientStorage, TransportCompanyDatabaseImplements.Implements.ClientStorage>();
			_serviseCollection.AddTransient<ITruckingStorage, TransportCompanyDatabaseImplements.Implements.TruckingStorage>();
			_serviseCollection.AddTransient<ITransportationStorage, TransportationStorage>();
			_serviseCollection.AddTransient<ITransportStorage, TransportCompanyDatabaseImplements.Implements.TransportStorage>();

			_serviceProvider = _serviseCollection.BuildServiceProvider();
		}

		//работа с MongoDB
		public static void ConnectMongo()
		{
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ICargoStorage)));
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IClientStorage)));
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ITruckingStorage)));
			_serviseCollection.Remove(_serviseCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ITransportStorage)));
			
			_serviseCollection.AddTransient<ICargoStorage, TransportCompamyMongoDBImplementer.Implements.CargoStorage>();
			_serviseCollection.AddTransient<IClientStorage, TransportCompamyMongoDBImplementer.Implements.ClientStorage>();
			_serviseCollection.AddTransient<ITruckingStorage, TransportCompamyMongoDBImplementer.Implements.TruckingStorage>();
			_serviseCollection.AddTransient<ITransportStorage, TransportCompamyMongoDBImplementer.Implements.TransportStorage>();

			_serviceProvider = _serviseCollection.BuildServiceProvider();
		}
	}
}
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.ViewModels;

namespace TransportCompamyMongoDBImplementer.Models
{
	public class Cargo
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string TypeCargo { get; set; } = null!;

		//public virtual ICollection<Trucking> Truckings { get; set; } = new List<Trucking>();

		public static Cargo Create(CargoBindingModel model)
		{
			return new Cargo()
			{
				Id = model.MongoId,
				TypeCargo = model.TypeCargo
			};
		}

		public void Update(CargoBindingModel model)
		{
			TypeCargo = model.TypeCargo;
		}

		public CargoViewModel GetViewModel => new()
		{
			MongoId = Id,
			TypeCargo = TypeCargo
		};
	}
}

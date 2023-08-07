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
	public class Transport
	{

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string TransportType { get; set; } = null!;

		public string TransportationType { get; set; } = null!;

		//public virtual ICollection<Trucking> Truckings { get; set; } = new List<Trucking>();

		public static Transport Create(TransportBindingModel model)
		{
			return new Transport()
			{
				Id = model.MongoId,
				TransportType = model.Tranport,
				TransportationType = model.TransportationType
			};
		}

		public void Update(TransportBindingModel model)
		{
			Id = model.MongoId;
			TransportType = model.Tranport;
			TransportationType = model.TransportationType;
		}

		public TransportViewModel GetViewModel => new()
		{
			MongoId = Id,
			Tranport = TransportType,
			TransportationType = TransportationType
		};
	}
}

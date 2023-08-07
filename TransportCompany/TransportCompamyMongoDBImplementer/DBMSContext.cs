using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompamyMongoDBImplementer
{
	public class DBMSContext
	{
		private const string ConnectionString = "mongodb://127.0.0.1:27017";

		private const string DatabaseName = "transportcompany";

		public IMongoCollection<T> ConnectToMongo<T>(in string collection)
		{
			var client = new MongoClient(ConnectionString);
			var db = client.GetDatabase(DatabaseName);

			return db.GetCollection<T>(collection);
		}
	}
}

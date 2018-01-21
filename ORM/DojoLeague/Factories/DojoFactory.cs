using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;

namespace DojoLeague.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;
        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=leaguesdb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Dojo item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO dojos (name, location, description) VALUES (@Name, @Location, @Description)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Dojo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
            }
        }
        public Dojo FindByID(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = 
                @"
                SELECT * FROM dojos WHERE id = @Id;
                SELECT dojo_id AS DojoId, dojos.name AS DojoName, ninjas.id, ninjas.name, ninjas.level, ninjas.description FROM ninjas LEFT JOIN dojos ON ninjas.dojo_id = dojos.id WHERE dojos.id = @Id";
                
                using (var multi = dbConnection.QueryMultiple(query, new {Id = id}))
                {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }
    }
}
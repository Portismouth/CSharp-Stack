using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;

namespace DojoLeague.Factory
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;
        public NinjaFactory()
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
        public void Add(Ninja ninja, Dojo dojo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                if(dojo == null)
                {
                    string query = $"INSERT INTO ninjas (name, level, description) VALUES (@Name, @Level, @Description)";
                    dbConnection.Execute(query, ninja);
                }
                else
                {
                    long dojo_id = dojo.Id;
                    string query = $"INSERT INTO ninjas (name, level, description, dojo_id) VALUES (@Name, @Level, @Description, {dojo_id})";
                    dbConnection.Execute(query, ninja);
                }
            }
        }
        public IEnumerable<Ninja> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT dojo_id AS DojoId, dojos.name AS DojoName, ninjas.id, ninjas.name, ninjas.level, ninjas.description FROM ninjas LEFT JOIN dojos ON ninjas.dojo_id = dojos.id");
            }
        }
        public Ninja FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT dojo_id AS DojoId, dojos.name AS DojoName, ninjas.id, ninjas.name, ninjas.level, ninjas.description FROM ninjas LEFT JOIN dojos ON ninjas.dojo_id = dojos.id", new { Id = id }).FirstOrDefault();
            }
        }
        public IEnumerable<Ninja> FindAllRogues()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE dojo_id is null");
            }
        }
        public IEnumerable<Ninja> NinjasForDojoById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id WHERE dojos.id = ninjas.dojo_id AND dojos.id = {id}";
                dbConnection.Open();

                var myNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
                return myNinjas;
            }
        }

        public void Recruit(int id, int dojo_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"UPDATE ninjas SET dojo_id = {dojo_id} WHERE id = {id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void Banish(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"UPDATE ninjas SET dojo_id = null WHERE id = {id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
    }
}
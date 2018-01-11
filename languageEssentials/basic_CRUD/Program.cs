using System;
using DbConnection;

namespace basic_CRUD
{
    class Program
    {
        public static void create()
        {
            System.Console.WriteLine("Enter a first name");
            string firstName = Console.ReadLine();
            string fString = '"'+ firstName + '"';
            System.Console.WriteLine("Enter a last name");
            string lastName = Console.ReadLine();
            string lString = '"' + lastName + '"';
            System.Console.WriteLine("Enter your favorite number");
            string favNum = Console.ReadLine();
            string lNum = '"' + favNum + '"';
            string insertQuery = $"INSERT INTO users (FirstName, LastName, FavoriteNumber) VALUES ({fString}, {lString}, {lNum})";
            System.Console.WriteLine(insertQuery);
            DbConnector.Execute(insertQuery);
            read();
        }
        public static void read()
        { 
            var users = DbConnector.Query("SELECT * FROM users");
            foreach(var user in users)
            {
                System.Console.WriteLine($"{user["FirstName"]} {user["LastName"]} {user["FavoriteNumber"]}");
            }
        }
        public static void update()
        {
            System.Console.WriteLine("Tell me the first name of who you want to update");
            string id = Console.ReadLine();
            string sId = '"' + id + '"';
            System.Console.WriteLine("Update their first name");
            string firstName = Console.ReadLine();
            string fString = '"' + firstName + '"';
            System.Console.WriteLine("Update their last name");
            string lastName = Console.ReadLine();
            string lString = '"' + lastName + '"';
            System.Console.WriteLine("Update their favorite number");
            string favNum = Console.ReadLine();
            string lNum = '"' + favNum + '"';
            string insertQuery = $"UPDATE users SET FirstName = {fString} , LastName = {lString}, FavoriteNumber = {lNum} WHERE FirstName = {sId}";
            DbConnector.Execute(insertQuery);
            read();
        }
        public static void delete()
        {
            System.Console.WriteLine("Tell me the first name of who you want to delete");
            string id = Console.ReadLine();
            string sId = '"' + id + '"';
            string insertQuery = $"DELETE FROM users WHERE FirstName = {sId}";
            DbConnector.Execute(insertQuery);
            read();
        }
        public static void select()
        {
            System.Console.WriteLine("What do you want to do?");
            string option = Console.ReadLine();
            if(option.ToLower() == "create")
            {
                create();
            }
            else if (option.ToLower() == "update")
            {
                update();
            }
            else if (option.ToLower() == "delete")
            {
                delete();
            }
        }
        static void Main(string[] args)
        {
            select();
        }
    }
}

    using System;
using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using ConsoleApp1.Domain;
    using ConsoleApp1.Repository;

namespace ConsoleApp1
{
    class Program
    {   
        static void Main(string[] args)
        {
            ////string connectionString = @"Data Source=localhost;Initial Catalog=SocialNetwork;Integrated Security=True";
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    var query = "SELECT * FROM ITCompanies";
            //    SqlCommand command = new SqlCommand(query, connection);
            //    var reader = command.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} ");
            //        }
            //    }
            //}
            
            IRepository<User> repo = new UsersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            var users = repo.Read();

            User user = new User(4, "Tom", "Hardson", 1, "hardson@gmail.com", 2);

            repo.Insert(user);

            Console.WriteLine();
            repo.Read();

            user.name = "Henry";

            repo.Update(user);

            Console.WriteLine();
            repo.Read();


            repo.Delete(5);

            Console.WriteLine();
            repo.Read();

            Console.ReadLine();
        }
    }
}

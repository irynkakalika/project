using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Configuration;
using ConsoleApp1.Domain;

namespace ConsoleApp1.Repository
{
    public class UsersRepository: IRepository<User>
    {
        private string connectionString; 
        public UsersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<User> Read()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                List<User> Users = null;
                connection.Open();
                var query = "SELECT id, name, surname, positionId, email, companyId FROM Users order by id";
                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Users = new List<User>();
                    while (reader.Read())
                    {
                        Users.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5)));
                        //{
                        //    id = reader.GetInt32(0),
                        //    name = reader.GetString(1),
                        //    surname = reader.GetString(2),
                        //    positionId = reader.GetInt32(3),
                        //    email = reader.GetString(4),
                        //    companyId = reader.GetInt32(5)
                        //});
                        Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)} {reader.GetString(4)} {reader.GetInt32(5)}");
                    }
                }
                return Users;
            }
        }

        public void Insert(User obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = $"INSERT INTO Users (name, surname, positionId, email, companyId) values " +
                            $"('{obj.name}', '{obj.surname}', {obj.positionId}, '{obj.email}', {obj.companyId});";

                SqlCommand command = new SqlCommand(query, connection);
                var number = command.ExecuteNonQuery();
                Console.WriteLine($"Added users: {number}");
            }
        }

        public void Update(User obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = $"UPDATE Users set name = '{obj.name}', surname = '{obj.surname}', positionId = {obj.positionId}, email = '{obj.email}', companyId = {obj.companyId}" +
                    $"where id = {obj.id};";

                SqlCommand command = new SqlCommand(query, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Updated users: {number}");
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = $"DELETE FROM Users WHERE id = '{id}';";
                SqlCommand command = new SqlCommand(query, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine($"Deleted users: {number}");
            }
        }
    }
}
using System;
using System.Data.SqlClient;

namespace Code
{
    public class DatabaseOperations
    {
        private SqlConnection _connection;

        public DatabaseOperations(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create()
        {
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            int userAge = int.Parse(Console.ReadLine());

            string insertQuery = "INSERT INTO DETAILS(user_name, user_age) VALUES (@name, @age)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, _connection);
            insertCommand.Parameters.AddWithValue("@name", userName);
            insertCommand.Parameters.AddWithValue("@age", userAge);
            insertCommand.ExecuteNonQuery();

            Console.WriteLine("Data is successfully inserted into the table.");
        }

        public void Retrieve()
        {
            string displayQuery = "SELECT * FROM DETAILS";
            SqlCommand displayCommand = new SqlCommand(displayQuery, _connection);
            SqlDataReader reader = displayCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader["user_id"]}, Name: {reader["user_name"]}, Age: {reader["user_age"]}");
            }

            reader.Close();
        }

        public void Update()
        {
            Console.WriteLine("Enter the user ID to update:");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new age:");
            int newAge = int.Parse(Console.ReadLine());

            string updateQuery = "UPDATE DETAILS SET user_age = @age WHERE user_id = @id";
            SqlCommand updateCommand = new SqlCommand(updateQuery, _connection);
            updateCommand.Parameters.AddWithValue("@age", newAge);
            updateCommand.Parameters.AddWithValue("@id", userId);
            updateCommand.ExecuteNonQuery();

            Console.WriteLine("Data updated successfully!");
        }

        public void Delete()
        {
            Console.WriteLine("Enter the user ID to delete:");
            int userId = int.Parse(Console.ReadLine());

            string deleteQuery = "DELETE FROM DETAILS WHERE user_id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, _connection);
            deleteCommand.Parameters.AddWithValue("@id", userId);
            deleteCommand.ExecuteNonQuery();

            Console.WriteLine("Deleted successfully.");
        }
    }
}

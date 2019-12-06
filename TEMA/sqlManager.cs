using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEMA
{
    class sqlManager
    {
        public SqlConnection Connection()
        {

            string con = "Data Source=.;Initial Catalog=" + "HomeworkWeek09" + ";Integrated Security=True";
            SqlConnection cn = new SqlConnection(con);
            cn.Open();
            return cn;
        }

        public void ScalarWithSelectIdentity(string commandQuery, Dictionary<string, SqlParameter> procParameters)
        {
            try
            {
                SqlConnection connection = Connection();
                SqlCommand SqlScalarCommand = new SqlCommand(commandQuery, connection);

                foreach (var procParameter in procParameters)
                {
                    SqlScalarCommand.Parameters.Add(procParameter.Value);
                }


                var rc = SqlScalarCommand.ExecuteScalar();

                Console.WriteLine($"The Id is : {rc}");

                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Scalar(string commandQuery)
        {
            try
            {
                SqlConnection connection = Connection();
                SqlCommand SqlScalarCommand = new SqlCommand(commandQuery, connection);

                var command = SqlScalarCommand.ExecuteScalar();

                Console.WriteLine($"The result of the query is : {command}");
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Reader(string commandQuery, string param1, string param2)
        {
            SqlDataReader command = null;
            SqlConnection connection = Connection();
            try
            {
                SqlCommand dataReader = new SqlCommand(commandQuery, connection);

                command = dataReader.ExecuteReader();

                while (command.Read())
                {
                    var currentRow = command;
                    var x = currentRow[param1];
                    var y = currentRow[param2];

                    Console.WriteLine($"{x} - {y}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (command != null)
                {
                    command.Close();
                }
                connection.Close();
            }
        }
        public void ScalarDelete()
        {
            try
            {
                SqlConnection connection = Connection();


                Console.WriteLine("Enter the name of the Book: ");
                var name = Console.ReadLine();
                string commandQuery = "SELECT[BookId] FROM[Book] WHERE[Title] = @title; DELETE FROM [Book] WHERE [Title] = @title;";
                SqlParameter nameParam1 = new SqlParameter("@title", name);
                SqlCommand SqlScalarCommand = new SqlCommand(commandQuery, connection);
                SqlScalarCommand.Parameters.Add(nameParam1);
                int comand = Convert.ToInt32(SqlScalarCommand.ExecuteScalar());
                Console.WriteLine($"The Id is : {comand}");
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void ScalarUpdate()
        {
            try
            {
                SqlConnection connection = Connection();
                Console.WriteLine("Enter the name of the Book: ");
                var name =Console.ReadLine();
                Console.WriteLine("Enter the new price: ");
                var price = int.Parse(Console.ReadLine());

              
                string commandQuery = "UPDATE [Book] SET [Price] = @price WHERE [Title] =@name; SELECT [BookId] FROM [Book] WHERE [Price] = @price";
                SqlParameter nameParam2 = new SqlParameter("@name", name);
                SqlParameter nameParam1 = new SqlParameter("@price", price);
                

                SqlCommand SqlScalarCommand = new SqlCommand(commandQuery, connection);
                SqlScalarCommand.Parameters.Add(nameParam1);
                SqlScalarCommand.Parameters.Add(nameParam2);

                var comand = SqlScalarCommand.ExecuteScalar();
                Console.WriteLine($"The Id is : {comand}");
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ScalarSelect()
        {
            try
            {
                SqlConnection connection = Connection();
                Console.WriteLine("Enter the name of the Book: ");
                string name = Console.ReadLine();

                string commandQuery = "SELECT [BookId] FROM [Book] WHERE [Title] = @name";
                SqlParameter nameParam = new SqlParameter("@name", name);
                SqlCommand SqlScalarCommand = new SqlCommand(commandQuery, connection);
                SqlScalarCommand.Parameters.Add(nameParam);

                var comand = SqlScalarCommand.ExecuteScalar();
                Console.WriteLine($"The Id is : {comand}");
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

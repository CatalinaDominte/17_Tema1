using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEMA
{
    class Program
    {
        static void Main(string[] args)
        {

            sqlManager test = new sqlManager();


            /*Ex.1 Create a console app named InsertPublisherApp to connect to a local database.
            2. With this console read the name of the publisher and insert a new publisher to the database.
            -Use SQL parameters for that
            -Print the inserted id (Execute scalar with select identity)*/
            Dictionary<string, SqlParameter> Parameters = new Dictionary<string, SqlParameter>();
            Parameters["a"] = new SqlParameter("@Id", "21");
            Parameters["b"] = new SqlParameter("@name", "Librisss");
            //test.ScalarWithSelectIdentity("INSERT INTO [Publisher] ([PublisherId],[Name]) VALUES(@Id, @name); SELECT [PublisherId] From [Publisher] where [Name]=@name", Parameters);


            /* Ex.3 Create a new console app named SummaryPublisherApp. Here print to console:
            -Number of rows from the Publisher table(Execute scalar)
            -Top 10 publishers(Id, Name)(SQL Data Reader)
            -Number of books for each publisher (Publisher Name, Number of Books)
            -The total price for books for a publisher*/

            //test.Reader("SELECT TOP 10[PublisherId], [Name] FROM[Publisher]", "PublisherId", "Name");
            //test.Reader("SELECT  [Name], COUNT([BookId]) AS CountB FROM [Publisher] LEFT JOIN [Book] ON [Publisher].[PublisherId] =[Book].[PublisherId] GROUP BY [Name]", "Name", "CountB");
            // test.Reader("SELECT  [Name], SUM([Price]) AS SumB FROM [Publisher] LEFT JOIN [Book] ON [Publisher].[PublisherId] =[Book].[PublisherId] GROUP BY [Name]", "Name", "SumB");
            // test.Scalar("SELECT COUNT([PublisherId]) FROM [Publisher]");

            /* Ex.5. Create a console app named CrudBookApp to connect to a local database.
                 Use SQL parameters for that
                Print the inserted id (Execute scalar with select identity)*/

            //-----Update a book (read id from console) 
            Dictionary<string, SqlParameter> Parameters1 = new Dictionary<string, SqlParameter>();
            Parameters["a"] = new SqlParameter("'@Title'", "thgfr");
            Parameters["b"] = new SqlParameter("@PublisherId", "2");
            Parameters["c"] = new SqlParameter("'@Year'", "1999");
            Parameters["d"] = new SqlParameter("'@Price'", "35");

            //test.ScalarWithSelectIdentity("INSERT INTO [Book] ([Title],[PublisherId],[Year],[Price]) VALUES ('@Title', '@PublisherId', '@Year', '@Price'); SELECT [BookId] FROM[Book] WHERE[Price]= '@Price';", Parameters1);
            //test.ScalarUpdate();

            //------Delete a book (read id from console)
            //test.ScalarDelete();

            //------Select a book (read id from console)
            test.ScalarSelect();



            Console.ReadLine();
        }
    }
}

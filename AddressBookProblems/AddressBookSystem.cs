using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblems
{
    public class AddressBookSystem
    {
        static List<AddressBookModel> contact = new List<AddressBookModel>();

        //Retrieve all details from  database
        public static void RetrieveDetailsFromDataBase()
        {
            String SQL = "select * from Address_Book";
            string connectingstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingstring);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var details = new AddressBookModel();
                    details.FirstName = reader.GetString(0);
                    details.LastName = reader.GetString(1);
                    details.Address = reader.GetString(2);
                    details.City = reader.GetString(3);
                    details.State = reader.GetString(4);
                    details.ZipCode = reader.GetInt32(5);
                    details.PhoneNumber = reader.GetInt64(6);
                    details.Email = reader.GetString(7);
                    details.AddressBookId = reader.GetInt32(8);
                    details.Type = reader.GetString(9);
                    contact.Add(details);
                }
                reader.Close();
                foreach (var con in contact)
                {
                    Console.WriteLine("\nFirst Name :" + con.FirstName +
                        "\nLast Name :" + con.LastName +
                        "\nAddress : " + con.Address +
                        "\nCity :" + con.City +
                        "\nState :" + con.State +
                        "\nZip Code :" + con.ZipCode +
                        "\nMobile Number :" + con.PhoneNumber +
                        "\nEmail :" + con.Email +
                        "\nAddress Book Name :" + con.AddressBookId +
                        "\nAddress Book ID :" + con.Type);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
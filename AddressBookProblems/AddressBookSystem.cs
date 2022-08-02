﻿using System;
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
                    details.Date_Added = reader.GetDateTime(10);
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
                        "\nPhoneNumber :" + con.PhoneNumber +
                        "\nEmail :" + con.Email +
                        "\nAddressBookId  :" + con.AddressBookId +
                        "\nType :" + con.Type +
                        "\nDate_Added :" + con.Date_Added);
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

        //Updating the information in the address Book for a person 
        public static void UpdateDetails()
        {
            var SQL = @$"update Address_Book set PhoneNumber  = '9999666673' where FirstName = 'Siddhant'";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Command Completed Successfully");
            Console.ReadKey();
            connection.Close();
        }
        //Retrieve Contacts from Database that were added in particular period
        public static void GetDetailsInPeroid()
        {
            var SQL = @$"select * from Address_Book where Date_Added BETWEEN CAST('2018-01-01' As date) AND CAST('2022-12-01' As date)";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
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
                details.Date_Added = reader.GetDateTime(10);
                contact.Add(details);
            }

            connection.Close();
            foreach (var con in contact)
            {
                Console.WriteLine("\nFirst Name :" + con.FirstName +
                    "\nLast Name :" + con.LastName +
                    "\nAddress : " + con.Address +
                    "\nCity :" + con.City +
                    "\nState :" + con.State +
                    "\nZip Code :" + con.ZipCode +
                    "\nPhoneNumber :" + con.PhoneNumber +
                    "\nEmail :" + con.Email +
                    "\nAddressBookId  :" + con.AddressBookId +
                    "\nType :" + con.Type +
                    "\nDate_Added :" + con.Date_Added);
            }

            Console.ReadKey();
        }

        //Retrieve Number of Contacts in AddressBook by City
        public static int CountOfContactDetailsByCity()
        {
            var SQL = @$"select count(*) from Address_Book where City='Pune'";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int count = (int)cmd.ExecuteScalar();
            connection.Close();
            return count;


        }

        //Retrieve Number of Contacts in AddressBook by State 
        public static int CountOfContactDetailsByState()
        {
            var SQL = @$"select count(*) from Address_Book where State='Karnataka'";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int count = (int)cmd.ExecuteScalar();
            connection.Close();
            return count;

        }
        //Add New Contact information in the address Book
        public static void AddNewContact()
        {
            var SQL = @$"insert into Address_Book Values ('Taniya','Sharma','WW colony','Gwalior', 'MP','654327',8843676627,'Taniya@gmail.com', '2', 'Family', '2022-03-15')";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Commands Completed Successfully");
            Console.ReadKey();
            connection.Close();
        }
        public static void AddMultipleContact()
        {
            var SQL = @$"insert into Address_Book Values ('Disha','Sharma','YY colony','Mumbai', 'Maharashtra','554327',8745675627,'Disha@gmail.com', '2', 'Family', '2022-04-20'),
                                                         ('Atharva','Vedh','ZZ colony','Mumbai', 'Maharashtra','654427',8843637623,'Atharva@gmail.com', '2', 'Family', '2022-07-01')";
            string connectingString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
          
            Task thread = new Task(() =>
            {
                connection.Open();
                int reader = cmd.ExecuteNonQuery();
                Console.WriteLine(reader);
                Console.WriteLine("Commands Completed Successfully");
                Console.ReadKey();
            });
            thread.Start();
             connection.Close();
        }
    }
}


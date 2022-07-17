using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblems
{
    public class AddressBook
    {
        List<Contact> addressbook = new List<Contact>();
        public Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> dictcity = new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> dictstate = new Dictionary<string, List<Contact>>();
        public void NotAddDuplicateRecord()
        {
            Contact person = new();
            int Flag = 0;
            Console.WriteLine("Enter the First name :");
            person.FirstName = Console.ReadLine();
            string FirstNameToBeAdded = person.FirstName;
            foreach (var data in addressbook)
            {
                if (addressbook.Exists(data => data.FirstName == FirstNameToBeAdded))
                {
                    Flag++;
                    Console.WriteLine("This FirstName already Exist! Can't take the Duplicate Record.");
                    break;
                }
            }
            if (Flag == 0)
            {
                Console.Write("Enter Last Name: ");
                person.LastName = Console.ReadLine();

                Console.Write("Enter Address: ");
                person.Address = Console.ReadLine();

                Console.Write("Enter City: ");
                person.City = Console.ReadLine();

                Console.Write("Enter State: ");
                person.State = Console.ReadLine();

                Console.Write("Enter Zip: ");
                person.Zipcode = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Phone Number: ");
                person.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                Console.Write("Enter Email: ");
                person.Email = Console.ReadLine();
                addressbook.Add(person);
                Console.WriteLine("********************************************************");


            }



        }

        public void Display()
        {
            foreach (var data in addressbook)
            {
                Console.WriteLine("The Details that you have added are -");
                Console.WriteLine("First Name: " + data.FirstName);
                Console.WriteLine("Last Name: " + data.LastName);
                Console.WriteLine("Enter Address: " + data.Address);
                Console.WriteLine("City: " + data.City);
                Console.WriteLine("State: " + data.State);
                Console.WriteLine("Zip: " + data.Zipcode);
                Console.WriteLine("Phone Number: " + data.PhoneNumber);
                Console.WriteLine("Email: " + data.Email);
            }
            Console.WriteLine("Details added successfully");

        }
        public void EditContact()
        {

            Console.WriteLine("__________________________");
            Console.WriteLine("For editing a contact enter first name : ");
            string name = Console.ReadLine();

            foreach (var List in addressbook)
            {


                if (List.FirstName == name)
                {
                    Console.WriteLine("Edit a contact\n1. Last Name\n2. Address\n3. City\n4. State\n5. ZipCode\n6. Phone Number\n7. Email Address");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter your new Last name");
                            string lastname = Console.ReadLine();
                            List.LastName = lastname;
                            break;
                        case 2:
                            Console.WriteLine("Enter your new Address");
                            string address = Console.ReadLine();
                            List.Address = address;
                            break;
                        case 3:

                            Console.WriteLine("Enter your new city");
                            string newcity = Console.ReadLine();
                            List.City = newcity;
                            break;
                        case 4:
                            Console.WriteLine("Enter your new State");
                            string state = Console.ReadLine();
                            List.State = state;
                            break;
                        case 5:
                            Console.WriteLine("Enter your new Zipcode");
                            int zipcode = Convert.ToInt32(Console.ReadLine());
                            List.Zipcode = zipcode;
                            break;
                        case 6:
                            Console.WriteLine("Enter your new PhoneNumber");
                            long phonenumber = Convert.ToInt32(Console.ReadLine());
                            List.PhoneNumber = phonenumber;
                            break;
                        case 7:
                            Console.WriteLine("Enter your new Email");
                            string email = Console.ReadLine();
                            List.Email = email;
                            break;

                    }

                }
                else
                {
                    Console.WriteLine("Contact doesn't exist");
                }

                string statement1 = "FirstName " + List.FirstName + " LastName " + List.LastName + " Address " + List.Address +
                                " City " + List.City + " State " + List.State + " Zipcode " + List.Zipcode + " PhoneNumber "
                                 + List.PhoneNumber + " Email " + List.Email;
                Console.WriteLine("----------------------");
                Console.WriteLine("Contact changed successfully as " + statement1);
            }

        }
        public void delete()
        {
            Console.WriteLine("Enter the Name to search : ");
            string Name = Console.ReadLine();
            try
            {
                foreach (var data in addressbook)
                {
                    if (addressbook.Contains(data))
                    {
                        if (data.FirstName == Name)
                        {
                            Console.WriteLine("Given Name Contact Exists");
                            addressbook.Remove(data);

                            Console.WriteLine("Contact Details Deleted Successfully");
                            return;
                        }
                    }
                }
                Console.WriteLine("Given Name Contact does not Exists");
            }
            catch (Exception r)
            {
                Console.WriteLine(r.Message);
            }

        }
        public void AddMultipleContacts(int n)
        {

            while (n > 0)
            {
                NotAddDuplicateRecord();
                n--;
            }
        }
        public void AddUniqueName()
        {
            Console.WriteLine("Enter the Firstname to Add Unique Name");
            string name = Console.ReadLine();
            foreach (var data in addressbook)
            {
                if (addressbook.Contains(data))
                {
                    if (data.FirstName == name)
                    {
                        Console.WriteLine("Please Enter an Unique Name");
                        string uniquename = Console.ReadLine();
                        if (dict.ContainsKey(uniquename))
                        {
                            Console.WriteLine("This unique name already exists");
                        }
                        dict.Add(uniquename, addressbook);
                        return;
                    }
                }
            }
            Console.WriteLine("This Contact doesn't Exist");
            return;

        }


        public void DisplayUniqueName()
        {
            Console.WriteLine("Enter the Uniquename of your contacts");
            string name = Console.ReadLine();

            foreach (var PersonContacts in dict)
            {
                if (PersonContacts.Key.Contains(name))
                {
                    foreach (var contact in PersonContacts.Value)
                    {
                        Console.WriteLine("Enter First Name: " + contact.FirstName);
                        Console.WriteLine("Enter Last Name: " + contact.LastName);
                        Console.WriteLine("Enter Address: " + contact.Address);
                        Console.WriteLine("Enter City: " + contact.City);
                        Console.WriteLine("Enter State: " + contact.State);
                        Console.WriteLine("Enter Zip: " + contact.Zipcode);
                        Console.WriteLine("Enter Phone Number: " + contact.PhoneNumber);
                        Console.WriteLine("Enter Email: " + contact.Email);
                        return;
                    }
                }




            }
        }
        public void SearchByCityState()
        {
            Console.WriteLine("Please Enter the name of City or State:");
            string SearchCityOrState = Console.ReadLine();
            foreach (var data in addressbook)
            {
                if (addressbook.Exists(data => (data.City == SearchCityOrState) || (data.State == SearchCityOrState)))
                {
                    if ((data.City == SearchCityOrState) || (data.State == SearchCityOrState))
                    {
                        Console.WriteLine("Name of person : " + data.FirstName + " " + data.LastName);
                        Console.WriteLine("Address of person is : " + data.Address);
                        Console.WriteLine("City : " + data.City);
                        Console.WriteLine("State :" + data.State);
                        Console.WriteLine("Zip :" + data.Zipcode);
                        Console.WriteLine("Phone Number of person: " + data.PhoneNumber);
                        Console.WriteLine("Email of person : " + data.Email);
                        Console.WriteLine();


                    }


                }
            }
        }
        public void ContactByCityInDictionary()
        {

            try
            {
                var data = addressbook.GroupBy(x => x.City);
                foreach (var cities in data)
                {
                    List<Contact> cityList = new List<Contact>();
                    foreach (var city in cities)
                    {
                        cityList.Add(city);
                    }
                    dictcity.Add(cities.Key, cityList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DictionayCity_Display()
        {
            if (dictcity.Count == 0)
                Console.WriteLine("No AddressBook(s) to Show.");
            if (dictcity.Count >= 1)
            {
                foreach (KeyValuePair<string, List<Contact>> addressBooks in dictcity)
                {
                    Console.WriteLine("Contacts From City: " + addressBooks.Key);
                    foreach (Contact contact in addressBooks.Value)
                    {
                        Console.WriteLine("Name of person : " + contact.FirstName + " " + contact.LastName);
                        Console.WriteLine("Address of person is : " + contact.Address);
                        Console.WriteLine("City : " + contact.City);
                        Console.WriteLine("State :" + contact.State);
                        Console.WriteLine("Zip :" + contact.Zipcode);
                        Console.WriteLine("Phone Number of person: " + contact.PhoneNumber);
                        Console.WriteLine("Email of person : " + contact.Email);
                        Console.WriteLine();

                    }
                }
            }
        }
        public void ContactByStateInDictionary()
        {

            try
            {
                var data = addressbook.GroupBy(x => x.State);
                foreach (var states in data)
                {
                    List<Contact> stateList = new List<Contact>();
                    foreach (var state in states)
                    {
                        stateList.Add(state);
                    }
                    dictstate.Add(states.Key, stateList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DictionayState_Display()
        {
            if (dictstate.Count == 0)
                Console.WriteLine("No AddressBook(s) to Show.");
            if (dictstate.Count >= 1)
            {
                foreach (KeyValuePair<string, List<Contact>> addressBooks in dictstate)
                {
                    Console.WriteLine("Contacts From State: " + addressBooks.Key);
                    foreach (Contact contact in addressBooks.Value)
                    {
                        Console.WriteLine("Name of person : " + contact.FirstName + " " + contact.LastName);
                        Console.WriteLine("Address of person is : " + contact.Address);
                        Console.WriteLine("City : " + contact.City);
                        Console.WriteLine("State :" + contact.State);
                        Console.WriteLine("Zip :" + contact.Zipcode);
                        Console.WriteLine("Phone Number of person: " + contact.PhoneNumber);
                        Console.WriteLine("Email of person : " + contact.Email);
                        Console.WriteLine();
                    }
                }
            }
        }

        public void CountByCityOrState()
        {
            Console.WriteLine("Please enter the city or state : ");
            string cityorstate = Console.ReadLine();
            List<Contact> checkCityorState = addressbook.FindAll(x => (x.City == cityorstate || x.State == cityorstate));
            Console.WriteLine("Number of Persons in the State {0} is {1}", cityorstate, checkCityorState.Count);

        }
        public void SortingContactsByName()
        {
            foreach (var data in addressbook.OrderBy(s => s.FirstName).ToList())
            {
                if (addressbook.Contains(data))
                {
                    Console.WriteLine("Name of the Person : " + data.FirstName + " " + data.LastName);
                    Console.WriteLine("Email ID : " + data.Email);
                    Console.WriteLine("Mobile Number : " + data.PhoneNumber);
                    Console.WriteLine("Address : " + data.Address);
                    Console.WriteLine("City : " + data.City);
                    Console.WriteLine("State : " + data.State);
                    Console.WriteLine("Zip : " + data.Zipcode);
                    Console.WriteLine("\n");
                }

            }
        }
        public void SortingContactsByCity()
        {

            foreach (var data in addressbook.OrderBy(s => s.City).ToList())
            {
                if (addressbook.Contains(data))
                {
                    Console.WriteLine("Name of person : " + data.FirstName + " " + data.LastName);
                    Console.WriteLine("Address of person is : " + data.Address);
                    Console.WriteLine("City : " + data.City);
                    Console.WriteLine("State :" + data.State);
                    Console.WriteLine("Zip :" + data.Zipcode);
                    Console.WriteLine("Phone Number of person: " + data.PhoneNumber);
                    Console.WriteLine("Email of person : " + data.Email);
                    Console.WriteLine();
                }

            }
        }

        public void SortingContactsByState()
        {

            foreach (var data in addressbook.OrderBy(s => s.State).ToList())
            {
                if (addressbook.Contains(data))
                {
                    Console.WriteLine("Name of person : " + data.FirstName + " " + data.LastName);
                    Console.WriteLine("Address of person is : " + data.Address);
                    Console.WriteLine("City : " + data.City);
                    Console.WriteLine("State :" + data.State);
                    Console.WriteLine("Zip :" + data.Zipcode);
                    Console.WriteLine("Phone Number of person: " + data.PhoneNumber);
                    Console.WriteLine("Email of person : " + data.Email);
                    Console.WriteLine();
                }

            }
        }
        public void WriteAddressbookintoTextFile()
        {
            string path = @"D:\AddressBookUC2\Wapssai\AddressBookProblems\AddressBookProblems\AddressBook.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Contact person in addressbook)
                {
                    sw.WriteLine("First Name : " + person.FirstName + "\n" +
                        "Last Name : " + person.LastName + "\n" +
                        "Address : " + person.Address + "\n" +
                        "City : " + person.City + "\n" +
                        "State : " + person.State + "\n" +
                        "Zip Code: " + person.Zipcode + "\n" +
                        "Mobile Number : " + person.PhoneNumber + "\n" +
                        "Email : " + person.Email);
                    sw.Close();
                    Console.WriteLine(File.ReadAllText(path));
                    Console.WriteLine("Person details are successfully Exported to Text File");
                }
                Console.ReadKey();
            }


        }
        public void WriteAddressbookintoCSVFile()
        {
            string path = @"D:\AddressBookUC2\Wapssai\AddressBookProblems\AddressBookProblems\AddressBook.csv";

            Console.WriteLine("********* Reading the File and Write to CSV File **********");

            //Writing the User data in to CSV file
            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter csvWrite = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(addressbook);
            }

        }

        public void ReadFromCSVFile()
        {
            string path = @"D:\AddressBookUC2\Wapssai\AddressBookProblems\AddressBookProblems\AddressBook.csv";
            using (StreamReader sr = new StreamReader(path))
            using (CsvReader csvRead = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                //Reading the user data from CSV file
                var result = csvRead.GetRecords<Contact>().ToList();
                foreach (Contact person in addressbook)
                {
                    Console.WriteLine("First Name : " + person.FirstName + "\n" +
                        "Last Name : " + person.LastName + "\n" +
                        "Address : " + person.Address + "\n" +
                        "City : " + person.City + "\n" +
                        "State : " + person.State + "\n" +
                        "Zip Code: " + person.Zipcode + "\n" +
                        "Mobile Number : " + person.PhoneNumber + "\n" +
                        "Email : " + person.Email);
                }
            }
        }

        public void WriteDetailsToJSONFile()
        {
            string Path = @"D:\AddressBookUC2\Wapssai\AddressBookProblems\AddressBookProblems\AddressBook.json";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(Path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, addressbook);
            }
        }
        public void ReadDetailsFromJSONFile()
        {
            string Path = @"D:\AddressBookUC2\Wapssai\AddressBookProblems\AddressBookProblems\AddressBook.json";
            IList<Contact> addressData = JsonConvert.DeserializeObject<IList<Contact>>(File.ReadAllText(Path));

            foreach (Contact person in addressData)
            {
                Console.WriteLine("First Name : " + person.FirstName + "\n" +
                    "Last Name : " + person.LastName + "\n" +
                    "Address : " + person.Address + "\n" +
                    "City : " + person.City + "\n" +
                    "State : " + person.State + "\n" +
                    "Zip Code: " + person.Zipcode + "\n" +
                    "Mobile Number : " + person.PhoneNumber + "\n" +
                    "Email : " + person.Email);
            }
        }

    }

}














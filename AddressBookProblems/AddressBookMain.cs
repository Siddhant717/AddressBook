using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblems
{
    public class AddressBookMain
    {
        List<Contact> addressbook = new List<Contact>();

        public void AddNewContacts()
        {
            Contact contact = new Contact();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Enter your First name-");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your Last name-");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter your Address-");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter your City-");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter your State-");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter your Zipcode-");
            contact.Zipcode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your PhoneNumber-");
            contact.PhoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Email-");
            contact.Email = Console.ReadLine();

            addressbook.Add(contact);
            Display();

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
    }

}

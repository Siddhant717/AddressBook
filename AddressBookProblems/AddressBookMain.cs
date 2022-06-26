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
    }
}

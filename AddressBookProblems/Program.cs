using System;

namespace AddressBookProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Program");

            AddressBookMain contactdetails = new AddressBookMain();
            while (true)
            {
                Console.WriteLine("Enter the option : \n1)Adding Contact \n2)Display contact \n3)Editing Contacts \n4)Delete Contacts");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        contactdetails.AddNewContacts();
                        break;
                    case 2:
                        contactdetails.Display();
                        break;
                    case 3:
                        contactdetails.EditContact();
                        break;
                    case 4:
                        contactdetails.delete();
                        break;
                    default:
                        Console.WriteLine("Please Choose From Above Given Options");
                        break;
                }
            }

        }
    }

}
using System;

namespace AddressBookProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Program");

            AddressBookMain contactdetails = new AddressBookMain();
            contactdetails.AddNewContacts();
            contactdetails.Display();
            contactdetails.EditContact();
            
        }
    }
}

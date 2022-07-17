using System;

namespace AddressBookProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Program");

            AddressBook contactdetails = new AddressBook();
            while (true)
            {
                Console.WriteLine("Enter the option : \n1)Adding Contact \n2)Display contact \n3)Editing Contacts \n4)Delete Contacts\n5)Adding Multiple Contacts\n6)Adding Unique Name \n7)Display Unique Name \n8)Searching Person Contacts By a City or State\n9)View Person contacts By City \n10)View Person contacts By State\n11)Count Persons Contacts By City Or State");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        contactdetails.NotAddDuplicateRecord();
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
                    case 5:
                        Console.WriteLine("How many no. of contacts");
                        int n = Convert.ToInt32(Console.ReadLine());
                        contactdetails.AddMultipleContacts(n);
                        break;
                    case 6:
                        contactdetails.AddUniqueName();
                        break;
                    case 7:
                        contactdetails.DisplayUniqueName();
                        break;
                    case 8:
                        contactdetails.SearchByCityState();
                        break;
                    case 9:
                        contactdetails.ContactByCityInDictionary();
                        contactdetails.DictionayCity_Display();
                        break;
                    case 10:
                        contactdetails.ContactByStateInDictionary();
                        contactdetails.DictionayState_Display();
                        break;
                    case 11:
                        contactdetails.CountByCityOrState();
                        break;
                    default:
                        Console.WriteLine("Please Choose From Above Given Options");
                        break;
                }
            }

        }
    }

}
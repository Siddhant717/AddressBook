using System;

namespace AddressBookProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Program");

            Console.WriteLine("Contact Details that you have provided- ");
            Contact contact = new Contact();

            contact.FirstName = "Siddhant";
            contact.LastName = "Shrivastava";
            contact.Address = "PQR";
            contact.City = "Lucknow";
            contact.State = "UP";
            contact.Zipcode = 676567;
            contact.PhoneNumber = 8888666666;
            contact.Email = "Sid@gmail.com";
            string statement = "FirstName " + contact.FirstName + " LastName " + contact.LastName + " Address " + contact.Address +
                             " City " + contact.City + " State " + contact.State + " Zipcode " + contact.Zipcode + " PhoneNumber "
                               + contact.PhoneNumber + " Email " + contact.Email;


            Console.WriteLine(statement);

        }
    }
}

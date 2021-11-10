
using System;

namespace Task_03_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string again;
            UserView userV = new UserView();
            do
            {
                userV.View();
                Console.WriteLine("---Press Enter to continue---");
                again = Console.ReadLine();
                Console.Clear();

            }
            while (again != null);
           

        }
     

    }
    


   
}


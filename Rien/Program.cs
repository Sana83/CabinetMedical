using System;
using CabinetMedical.Exceptions;

namespace Rien
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                throw new CabinetMedicalException("erreur dans prog");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}

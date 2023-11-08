using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ConsoleView
    {
        private readonly AdressDAO adressesDao;
 /// ////////////////////////////////////////////////////////// Adress
        public ConsoleView(AdressDAO adressDao)
        {
            adressesDao = adressDao;
        }

        private void PrintAdresses(List<Adress> adresses)
        {
            System.Console.WriteLine("Adresses: ");
            System.Console.WriteLine($"ID:{"",3}| Street: {"",21} | StreetNum: {"",4} | City: {"",15} |State:{"",17}|");
            string s = $"ID:{"",3}| Street: {"",21} | StreetNum: {"",4} | City: {"",15} |State:{"",17}|";
            foreach (Adress v in adresses)
            {
                System.Console.WriteLine(v);
            }
        }

        private Adress InputAdress()
        {
            System.Console.WriteLine("Enter  street: ");
            string street = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter street number: ");
            int streetnumber = ConsoleViewUtils.SafeInputInt();
            System.Console.WriteLine("Enter city: ");
            string city = System.Console.ReadLine() ?? string.Empty;
            System.Console.WriteLine("Enter state: ");
            string state = System.Console.ReadLine() ?? string.Empty;
            Adress a = new Adress(street, streetnumber, city, state);

            return a;
        }
        private int InputId() {
            System.Console.WriteLine("Enter id: ");
            return ConsoleViewUtils.SafeInputInt();
        }
        private void UpdateAdress()
        {
            int id=InputId();
            Adress adress= InputAdress();
            adress.Id = id;
            Adress? updateAdress = adressesDao.UpdateAdress(adress);
            if(updateAdress != null)
            {
                System.Console.WriteLine($"Adress not found");
                return;
            }
            System.Console.WriteLine("Adress updated");
        }
        private void AddAdress()
        {
            Adress adress= InputAdress();
            adressesDao.AddAdress(adress);
            System.Console.WriteLine("Adress added");
        }

    }
}

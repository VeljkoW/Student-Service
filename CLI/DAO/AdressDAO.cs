using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class AdressDAO
    {
        private readonly List<Adress> Adresses;
        private readonly Storage<Adress> storage;
        public AdressDAO()
        {
            storage = new Storage<Adress>("Adresses.txt");
            Adresses = storage.Load();
        }
        private int GenerateId()
        {
            if (Adresses.Count == 0) return 0;
            return Adresses[^1].Id + 1;
        }
        public Adress AddAdress(Adress adresa)
        {
            adresa.Id = GenerateId();
            Adresses.Add(adresa);
            storage.Save(Adresses);
            return adresa;
        }
        public Adress? UpdateAdress(Adress adress)
        {
            Adress? old = GetAdressById(adress.Id);
            if (old is null) return null;
            old.StreetNumber = adress.StreetNumber;
            old.Street= adress.Street;
            old.State = adress.State;
            old.City = adress.City;
            storage.Save(Adresses);
            return old;
        }
        public Adress? RemoveAdress(int id)
        {
            Adress? vehicle = GetAdressById(id);
            if (vehicle == null) return null;

            Adresses.Remove(vehicle);
            storage.Save(Adresses);
            return vehicle;
        }
        private Adress? GetAdressById(int id)
        {
            return Adresses.Find(v => v.Id == id);
        }
        public List<Adress> GetAllVehicles()
        {
            return Adresses;
        }
    }
}
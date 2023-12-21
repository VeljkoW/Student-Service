using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class KatedraDAO
    {
        private readonly List<Katedra> katedras;  //katedra nije na engleskom ali gg
        private readonly Storage<Katedra> storage;
        public ObserverSubject katedraSubject;

        public KatedraDAO()
        {
            storage = new Storage<Katedra>("Departments.csv");
            katedras = storage.Load();
            katedraSubject=new ObserverSubject();
        }
        public int GenerateID()
        {
            if (katedras.Count == 0) return 0;
            return katedras[^1].Id + 1;
        }
        public Katedra AddKatedra(Katedra katedra)
        {
            katedra.Id = GenerateID();
            katedras.Add(katedra);
            storage.Save(katedras);
            katedraSubject.NotifyObservers();
            return katedra;
        }
        public Katedra? UpdateKatedra(Katedra katedra)
        {
            Katedra? oldKatedra = GetKatedraById(katedra.Id);
            if (oldKatedra is null) return null;
            oldKatedra.Name = katedra.Name;
            oldKatedra.Head = katedra.Head;
            oldKatedra.Professors = katedra.Professors;
            storage.Save(katedras);
            katedraSubject.NotifyObservers();
            return oldKatedra;

        }
        private Katedra? GetKatedraById(int id)
        {
            return katedras.Find(k => k.Id == id);
        }

        public Katedra? RemoveKatedra(int id)
        {
            Katedra? katedra = GetKatedraById(id);
            if (katedra == null) return null;

            katedras.Remove(katedra);
            storage.Save(katedras);
            katedraSubject.NotifyObservers();
            return katedra;
        }
        public List<Katedra> GetAllKatedras()
        {
            return katedras;
        }

    }
}

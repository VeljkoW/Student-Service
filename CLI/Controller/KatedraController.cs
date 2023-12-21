using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Controller
{
    public class KatedraController
    {
        private readonly KatedraDAO katedraDao;

        public KatedraController()
        {
            katedraDao = new KatedraDAO();
        }

        public List<Katedra> GetAllKatedras()
        {
            return katedraDao.GetAllKatedras();
        }

        public void Add(Katedra katedra)
        {
            katedraDao.AddKatedra(katedra);
        }

        public void Delete(int katedraId)
        {
            katedraDao.RemoveKatedra(katedraId);
        }

        public void Subscribe(IObserver observer)
        {
            katedraDao.katedraSubject.Subscribe(observer);
        }
    }
}

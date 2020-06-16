using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Trenes
{
    public class BusinessLogicLayer
    {

        private DataAccessLayer _dataAccessLayer;

        public BusinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }
        public Tren saveTren(Tren tren)
        {
            if (tren.Id == 0)
                _dataAccessLayer.insertTren(tren);
            return tren;
        }

        public List<Tren> getTrenes()
        {
            return _dataAccessLayer.getTrenes();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class BerechnungViewModel
    {

        private int _repMax;

        public int RepMax
        {
            get { return _repMax; }
            set { _repMax = value; }
        }

        public BerechnungViewModel()
        {

        }
    }
}

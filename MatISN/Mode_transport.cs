using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Mode_transport
    {
        private static int ajoutModeTransport;
        private int numTransport;
        private string nomTransport;

        public int NumTransport
        {
            get
            {
                return numTransport;
            }

            set
            {
                numTransport = value;
            }
        }

        public string NomTransport
        {
            get
            {
                return nomTransport;
            }

            set
            {
                nomTransport = value;
            }
        }

        public Mode_transport(string nomTransport)
        {
            this.numTransport = ajoutModeTransport;
            ajoutModeTransport++;
        }

    }
}

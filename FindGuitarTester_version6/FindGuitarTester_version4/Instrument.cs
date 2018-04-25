using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version5
{
    class Instrument
    {
        private string serialNumber;
        private double price;
        private InstrumentSpec spec;


        public Instrument(string serialNumber, double price, InstrumentSpec spec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = spec;
        }

        public string getSerialNumber()
        {
            return serialNumber;
        }


        public void setPrice(float newPrice)
        {
            this.price = newPrice;
        }

        public double getPrice()
        {
            return price;
        }

        public InstrumentSpec getSpec()
        {
            return spec;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2
{
    class Guitar
    {
        private string serialNumber;
        private double price;
        private GuitarSpec spec;

        public Guitar(string serialNumber, double price, GuitarSpec guitarSpec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = guitarSpec;
        }

        public string SerialNumber
        {
            get { return serialNumber; }
        }

        public double Price
        {
            get { return price; }
            set { this.price = value; }
        }

        public GuitarSpec Spec
        {
            get { return spec; }
        }
    }
}

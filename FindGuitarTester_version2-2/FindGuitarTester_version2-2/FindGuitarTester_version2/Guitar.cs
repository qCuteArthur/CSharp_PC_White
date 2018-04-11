using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2
{
    class Guitar
    {
        private string serialNumber, model;
        private Builder_Enum builder;
        private Type_Enum type;
        private Wood_Enum backWood, topWood;
        private double price;

        
        public Guitar(string serialNumber, double price, Builder_Enum builder, string model, Type_Enum type,
            Wood_Enum backWood, Wood_Enum topWood)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.builder = builder;
            this.model = model;
            this.type = type;
            this.backWood = backWood;
            this.topWood = topWood;
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

        public Builder_Enum Builder
        {
            get { return builder; }
        }
        public string Model
        {
            get { return model; }
        }
        public Type_Enum Type
        {
            get { return type; }
        }

        public Wood_Enum BackWood
        {
            get { return backWood; }
        }
        public Wood_Enum TopWood
        {
            get { return topWood; }
        }
    }
}

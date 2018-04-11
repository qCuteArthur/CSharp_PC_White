using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version1
{
    class Guitar
    {
        private SerialNumberEnum serialNumber;
        private Builder builder;
        private Model model;
        private Type_enum type;
        private Back_WoodEnum backWood;
        private TopWoodEnum topWood;
        private double price;

        public Guitar(SerialNumberEnum serialNumber, double price, Builder builder, Model model, Type_enum type,
            Back_WoodEnum backWood, TopWoodEnum topWood)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.builder = builder;
            this.model = model;
            this.type = type;
            this.backWood = backWood;
            this.topWood = topWood;
        }

        public SerialNumberEnum SerialNumber
        {
            get { return serialNumber; }            
        }

        public double Price
        {
            get { return price; }
            set { this.price = value; }
        }

        public Builder Builder
        {
            get { return builder; }
        }
        public Model Model
        {
            get { return model; }
        }
        public Type_enum Type
        {
            get { return type; }
        }

        public Back_WoodEnum BackWood
        {
            get { return backWood; }
        }
        public TopWoodEnum TopWood
        {
            get { return topWood; }
        }
    }
}

using FindGuitarTester_version2.主程序;
using FindGuitarTester_version2.枚举类;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2
{
    class Guitar: Instruments
    {
        private string serialNumber;
        private double price;
        private GuitarSpec spec;

        public Guitar(string serialNumber, double price, GuitarSpec guitarSpec):base(serialNumber,price,guitarSpec)
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


    class GuitarSpec:InstrumentSpec
    {
        private string model;
        private Builder_Enum builder;
        private Type_Enum type;
        private Wood_Enum backWood, topWood;
        private String_Enum numString;

        public GuitarSpec(Builder_Enum builder, string Model, Type_Enum type, Wood_Enum backWood, Wood_Enum topWood, String_Enum numString) : base(builder, Model, type, backWood, topWood)
        {
            this.builder = builder;
            this.model = model;
            this.type = type;
            this.backWood = backWood;
            this.topWood = topWood;
            this.numString = numString;
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
        public String_Enum NumString
        {
            get { return numString; }
        }
    }
}

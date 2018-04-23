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

        public object Spec { get; internal set; }
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
        public String_Enum NumString
        {
            get { return numString; }
        }
    }
}

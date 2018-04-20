using FindGuitarTester_version2.枚举类;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2.主程序
{
    public class Instruments
    {
        private string serialNumber;
        private double price;
        private InstrumentSpec spec;

        public string SerialNumber
        {
            get { return serialNumber; }
        }
        public double Price
        {
            get { return price; }
        }
        public InstrumentSpec InstrumentSpec
        {
            get { return spec; }
        }
        public Instruments(string serialNumber,double price, InstrumentSpec spec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.spec = spec;
        }
    }
    public class InstrumentSpec
    {
        private string model;
        private Builder_Enum builder;
        private Type_Enum type;
        private Wood_Enum backWood, topWood;
        private String_Enum numString;
        private Style_Enum style;

        public string Model
        {
            get { return model; }
        }
        public  Builder_Enum Builder
        {
            get { return builder; }
        }
        public Type_Enum Type
        {
            get { return type; }
        }
        public Wood_Enum BackWood
        {
            get { return backWood; }
        }
        public Wood_Enum Top_Wood
        {
            get { return topWood; }
        }
        public String_Enum String
        {
            get { return numString; }
        }
        public Style_Enum Style
        {
            get { return style; }
        }
        public InstrumentSpec(Builder_Enum builder, string Model, Type_Enum type, Wood_Enum backWood, Wood_Enum topWood)
        {
            this.builder = builder;
            this.model = Model;
            this.type = type;
            this.topWood = topWood;
            this.backWood = backWood;
        }
    }
}

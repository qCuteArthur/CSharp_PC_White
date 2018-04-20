using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindGuitarTester_version2.枚举类;

namespace FindGuitarTester_version2.主程序
{
    public class Piano : Instruments
    {
        private string serialNumber;
        private double price;
        private InstrumentSpec instrumentsSpec;
        public Piano(string serialNumber, double price, InstrumentSpec spec) : base(serialNumber, price, spec)
        {
            this.serialNumber = serialNumber;
            this.price = price;
            this.instrumentsSpec = spec;
        }
        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
        }
        public InstrumentSpec InstrumentSpec
        {
            get { return instrumentsSpec; }
        }
    }

    public class PianoSpec : InstrumentSpec
    {
        private string model;
        private Builder_Enum builder;
        private Type_Enum type;
        private Wood_Enum backWood, topWood;
        private Style_Enum style;

        public PianoSpec(Builder_Enum builder, string Model, Type_Enum type, Wood_Enum backWood, Wood_Enum topWood, Style_Enum style) : base(builder, Model, type, backWood, topWood)
        {
            this.builder = builder;
            this.model = model;
            this.type = type;
            this.backWood = backWood;
            this.topWood = topWood;
            this.style = style;
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
        public Style_Enum Style
        {
            get { return style; }
        }
    }
}

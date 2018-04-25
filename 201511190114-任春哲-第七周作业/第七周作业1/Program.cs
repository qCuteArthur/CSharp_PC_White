using FindGuitarTester_version2;
using System;
using System.Collections;
using System.Collections.Generic;

namespace 第七周作业
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventoy inventoy = new Inventoy();
            inventoy.AddInstruments(new Guitar("000001", 100.00, String_Enum.eighteen, new GuitarSpec(Model_Enum.A, Builder_Enum.ANY, Type_Enum.ACOUSTIC, Wood_Enum.ADIRONDACK, Wood_Enum.ADIRONDACK, String_Enum.eighteen)));

            inventoy.AddInstruments(new Guitar("000002", 200.00, String_Enum.eighteen, new GuitarSpec(Model_Enum.A, Builder_Enum.ANY, Type_Enum.ACOUSTIC, Wood_Enum.ADIRONDACK, Wood_Enum.ADIRONDACK, String_Enum.eighteen)));

            inventoy.AddInstruments(new Guitar("000003", 300.00, String_Enum.eighteen, new GuitarSpec(Model_Enum.A, Builder_Enum.ANY, Type_Enum.ACOUSTIC, Wood_Enum.ADIRONDACK, Wood_Enum.ADIRONDACK, String_Enum.eighteen)));

            inventoy.AddInstruments(new Guitar("000003", 300.00, String_Enum.eighteen, new GuitarSpec(Model_Enum.A, Builder_Enum.ANY, Type_Enum.ACOUSTIC, Wood_Enum.ADIRONDACK, Wood_Enum.ADIRONDACK, String_Enum.eighteen)));

            inventoy.AddInstruments(new Piano("000004", 400.00, Style_Enum.A, new PianoSpec(Model_Enum.A, Builder_Enum.ANY, Type_Enum.ACOUSTIC, Wood_Enum.ADIRONDACK, Wood_Enum.ADIRONDACK, Style_Enum.A)));

            inventoy.AddInstruments(new Piano("000005", 500.00, Style_Enum.A, new PianoSpec(Model_Enum.A, Builder_Enum.ANY, Type_Enum.ACOUSTIC, Wood_Enum.ADIRONDACK, Wood_Enum.ADIRONDACK, Style_Enum.A)));

            //inventoy.DispInstruments();

            GuitarSpec whatErinLikes = new GuitarSpec(Model_Enum.A,Builder_Enum.ANY,Type_Enum.ACOUSTIC,Wood_Enum.ADIRONDACK,Wood_Enum.ADIRONDACK,String_Enum.eighteen);

            List<InstrumentsSpec> myList  = inventoy.Seach(whatErinLikes);
            foreach(var item in myList){
                Console.WriteLine("Model:{0},\nType:{1},\nBackWood:{2},\nTopWood:{3},\n,Builder:{4},\nType:{5},\n", item.Model, item.Type, item.BackWood, item.TopWood, item.Builder, item.Type);
                if (item is GuitarSpec)
                {
                    GuitarSpec guitarSpec = item as GuitarSpec;
                    Console.WriteLine(guitarSpec.NumString);
                }
                else
                {
                    PianoSpec pianoSpec = item as PianoSpec;
                    Console.WriteLine(pianoSpec.Style);
                }
                Console.WriteLine("___________________");
            }
            Console.ReadLine();
        }
    }
    interface IInstruments
    {
        String SerialNumber
        {
            get;
        }
        Double Price
        {
            get;
        }
    }
    interface IInstrumentSpec
    {
        Model_Enum Model { get; }
        Builder_Enum Builder { get; }
        Type_Enum Type { get; }
        Wood_Enum TopWood { get; }
        Wood_Enum BackWood { get; }
    }
    interface IInventory
    {
        void AddInstruments(Instruments instruments);
        void DispInstruments();
        List<InstrumentsSpec> Seach(InstrumentsSpec instrumensSpec);
}
    public class Inventoy : IInventory
    {
        private List<Instruments> Instruments_List= new List<Instruments>();
        public Instruments this[int index]
        {
            get { return Instruments_List[index]; }
        }
        public void AddInstruments(Instruments m_instruments)
        {
            this.Instruments_List.Add(m_instruments);
        }

        public void DispInstruments()
        {
            foreach(var item in Instruments_List)
            {
                
                Console.WriteLine("The SerialNumber :{0},\nThe Price {1},\n",item.SerialNumber,item.Price);

                InstrumentsSpec instrumensSpec = item.InstrumensSpec as InstrumentsSpec;

                Console.WriteLine("Model:{0},\nType:{1},\nBackWood:{2},\nTopWood:{3},\n,Builder:{4},\nType:{5},\n", instrumensSpec.Model, instrumensSpec.Type,instrumensSpec.BackWood, instrumensSpec.TopWood,instrumensSpec.Builder,instrumensSpec.Type);

                if (item.InstrumensSpec is GuitarSpec)
                {
                    GuitarSpec guitarSpec = item.InstrumensSpec as GuitarSpec;
                    Console.WriteLine("String Number of Guitar:{0},\n",guitarSpec.NumString);
                }
                else if (item.InstrumensSpec is PianoSpec)
                {
                    PianoSpec pianoSpec = item.InstrumensSpec as PianoSpec;
                    Console.WriteLine("Style of Piano:{0},\n",pianoSpec.Style);
                }
                Console.WriteLine("__________________________________");
            }
        }

        public List<InstrumentsSpec> Seach(InstrumentsSpec m_instrumensSpec)
        {
            List<InstrumentsSpec> myList = new List<InstrumentsSpec>();
            foreach (var item in Instruments_List)
            {
                if (!Match(item.InstrumensSpec, m_instrumensSpec))
                {
                    continue;      
                }
                //首先进行类型的转换，然后判断是不是可以进行匹配

                if (m_instrumensSpec is GuitarSpec && item.InstrumensSpec is GuitarSpec)
                {
                    GuitarSpec guitarSpec = item.InstrumensSpec as GuitarSpec;
                    GuitarSpec m_guitarSpec = m_instrumensSpec as GuitarSpec;
                    //如果说这个类型是一致的，所以对比一下二者的NumString属性
                    if (m_guitarSpec.NumString == guitarSpec.NumString) myList.Add(guitarSpec);
                }
                else if (m_instrumensSpec is PianoSpec && item.InstrumensSpec is PianoSpec)
                {
                    PianoSpec pianoSpec = item.InstrumensSpec as PianoSpec;
                    PianoSpec m_pianoSpec = m_instrumensSpec as PianoSpec;
                    if (m_pianoSpec.Style == pianoSpec.Style) myList.Add(pianoSpec);
                }
            }
            return myList;
        }
        public bool Match(InstrumentsSpec instrumensSpec1,InstrumentsSpec instrumensSpec2)
        {
            if(instrumensSpec1.BackWood != instrumensSpec2.BackWood) return false;
            if (instrumensSpec2.Builder != instrumensSpec1.Builder) return false;
            if (instrumensSpec2.TopWood != instrumensSpec1.TopWood) return false;
            if (instrumensSpec2.Model != instrumensSpec1.Model) return false;
            if (instrumensSpec2.Type != instrumensSpec1.Type) return false;
            return true;
        }
    }
    public class InstrumentsSpec : IInstrumentSpec
    {
        private Model_Enum model;
        public Model_Enum Model { get { return model; } }
        private Builder_Enum builder;
        public Builder_Enum Builder { get { return builder; } }
        private Type_Enum type;
        public Type_Enum Type { get { return type; } }
        private Wood_Enum topWood;
        public Wood_Enum TopWood { get { return topWood; } }
        private Wood_Enum backWood;
        public Wood_Enum BackWood { get { return backWood; } }
        public InstrumentsSpec(Model_Enum model,Builder_Enum builder,Type_Enum type,Wood_Enum topWood,Wood_Enum backWood)
        {
            this.model = model;
            this.builder = builder;
            this.type = type;
            this.topWood = topWood;
            this.backWood = backWood;
        }
    }
    public class Instruments : IInstruments
    {
        private string serialNumber;
        public string SerialNumber { get { return serialNumber; }}
        private double price;
        public double Price { get { return price; }}
        private InstrumentsSpec instrumensSpec;
        public InstrumentsSpec InstrumensSpec
        {
            get { return instrumensSpec; }
        }
        public Instruments(string serialNumber,double price,InstrumentsSpec instrumensSpec)
        {
            this.instrumensSpec = instrumensSpec;
            this.price = price;
            this.serialNumber = serialNumber;
        }
    }
    public class Piano :Instruments
    {
        public Piano(string serialNumber, double price, Style_Enum a, InstrumentsSpec instrumensSpec) : base(serialNumber, price, instrumensSpec)
        {
        }
    }
    public class Guitar : Instruments
    {
        public Guitar(string serialNumber, double price, String_Enum numString,InstrumentsSpec instrumensSpec) :base(serialNumber,price,instrumensSpec)
        {
        }
    }
    public class GuitarSpec : InstrumentsSpec
    {
        private String_Enum numString;
        public String_Enum NumString { get { return numString; } }
        public GuitarSpec(Model_Enum model, Builder_Enum builder, Type_Enum type, Wood_Enum topWood, Wood_Enum backWood,String_Enum numString) : base(model, builder, type, topWood, backWood)
        {
            this.numString = numString;
        }
    }
    public class PianoSpec : InstrumentsSpec
    {
        private Style_Enum style;
        public Style_Enum Style { get { return style; } }
        public PianoSpec(Model_Enum model, Builder_Enum builder, Type_Enum type, Wood_Enum topWood, Wood_Enum backWood,Style_Enum style) : base(model, builder, type, topWood, backWood)
        {
            this.style = style;
        }
    }
}
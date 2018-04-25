using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version5
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            initializeInventory(inventory);

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("InstrumentType", InstrumentType.Guitar);
            properties.Add("Builder", Builder.fender);
            properties.Add("Model", "Stratocastor");
            properties.Add("Type", Type.eletric);
            properties.Add("NumString", 6);
            properties.Add("BackWood", Wood.alder);
            properties.Add("TopWood", Wood.alder);
            InstrumentSpec whatErinLikes = new InstrumentSpec(properties);
            List<Instrument> matchingInstrument = inventory.search(whatErinLikes);
            if (matchingInstrument.Count != 0)
            {
                Console.WriteLine("Erin, you might like these instrument:");
                for (int i = 0; i < matchingInstrument.Count; i++)
                {
                    Instrument instrument = matchingInstrument[i];
                    InstrumentSpec spec = instrument.getSpec();
                    Console.WriteLine(" We have a " + " " + spec.getProperty("InstrumentType") +
                        "with the following proersties:");

                    string output = null;
                    Dictionary<string, object> proersties = spec.getProperties();
                    foreach (string key in proersties.Keys)
                    {
                        output += key + " "+ proersties[key] +"; ";
                    }
                    Console.WriteLine(output + "\n");
                    Console.WriteLine("You can have it for only $" +  instrument.getPrice() + "!\n ----");
                }
            }
            else
            {
                Console.WriteLine("Sorry, Erin, we have nothing for you.");
            }
            Console.ReadKey();
        }

        private static void initializeInventory(Inventory inventory)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("InstrumentType",InstrumentType.Guitar);
            properties.Add("Builder", Builder.fender);
            properties.Add("Model", "Stratocastor");
            properties.Add("Type", Type.eletric);
            properties.Add("NumString", 6);
            properties.Add("BackWood", Wood.alder);
            properties.Add("TopWood", Wood.alder);
            InstrumentSpec guitarSpec = new InstrumentSpec(properties);
            inventory.addInstrument("V95693", 1499.95, guitarSpec);


            properties = new Dictionary<string, object>();
            properties.Add("InstrumentType", InstrumentType.Guitar);
            properties.Add("Builder", Builder.gibson);
            properties.Add("Model", "Stratocastor");
            properties.Add("Type", Type.acoustic);
            properties.Add("NumString", 6);
            properties.Add("BackWood", Wood.cocobolo);
            properties.Add("TopWood", Wood.alder);
            guitarSpec = new InstrumentSpec(properties);
            inventory.addInstrument("V9512", 2059.95, guitarSpec);

            properties = new Dictionary<string, object>();
            properties.Add("InstrumentType", InstrumentType.Mandolin);
            properties.Add("Builder", Builder.gibson);
            properties.Add("Model", "Stratocastor");
            properties.Add("Type", Type.acoustic);
            properties.Add("Style", Style.F);
            properties.Add("BackWood", Wood.cocobolo);
            properties.Add("TopWood", Wood.alder);
            InstrumentSpec mandolinSpec = new InstrumentSpec(properties);
            inventory.addInstrument("M1122", 239.95, mandolinSpec);

        }
    }
}

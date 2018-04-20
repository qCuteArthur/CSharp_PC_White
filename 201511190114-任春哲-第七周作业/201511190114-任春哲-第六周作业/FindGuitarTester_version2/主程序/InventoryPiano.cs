using FindGuitarTester_version2.枚举类;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2.主程序
{
    class InventoryPiano:Inventory
    {
        private List<Piano> pianos;
        public InventoryPiano()
        {
            pianos = new List<Piano>();
        }
        //没有合适的方法来重新，难道是因为签名有问题吗？？？？
        public void Add(string serialNumber, double price, Builder_Enum builder, string model, Type_Enum type,
    Wood_Enum backWood, Wood_Enum topWood, Style_Enum style)
        {
            PianoSpec pianoSpec = new PianoSpec(builder, model, type, backWood, topWood, style);
            Piano piano = new Piano(serialNumber, price, pianoSpec);
            pianos.Add(piano);
        }

        public Piano GetPiano(string serialNumber)
        {
            for (int i = 0; i < pianos.Count; i++)
            {
                Piano piano = pianos[i];
                if (piano.SerialNumber.Equals(serialNumber))
                    return piano;
            }
            return null;
        }

        public  List<Piano> Search(PianoSpec searchSpec)
        {
            List<Piano> matchGuitar = new List<Piano>();
            for (int i = 0; i < pianos.Count; i++)
            {
                Piano piano = pianos[i];
                Builder_Enum builder = searchSpec.Builder;
                if (builder != piano.InstrumentSpec.Builder)
                    continue;
                string model = searchSpec.Model.ToLower();
                if ((model != null) && (!model.Equals("")) &&
                    (!model.Equals(piano.InstrumentSpec.Model.ToLower())))
                    continue;
                Type_Enum type = searchSpec.Type;
                if (type != piano.InstrumentSpec.Type)
                    continue;
                Wood_Enum backWood = searchSpec.BackWood;
                if (backWood != piano.InstrumentSpec.BackWood)
                    continue;
                Wood_Enum topWood = searchSpec.TopWood;
                if (topWood != piano.InstrumentSpec.Top_Wood)
                    continue;
                Style_Enum style = searchSpec.Style;
                if (style != piano.InstrumentSpec.Style)
                    continue;
                matchGuitar.Add(piano);
            }
            return matchGuitar;
        }
    }
}

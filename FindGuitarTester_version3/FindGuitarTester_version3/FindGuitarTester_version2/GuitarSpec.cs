using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2
{
    class GuitarSpec
    {
        private string model;
        private Builder_Enum builder;
        private Type_Enum type;
        private Wood_Enum backWood, topWood;



        public GuitarSpec(Builder_Enum builder, string model, Type_Enum type,
            Wood_Enum backWood, Wood_Enum topWood)
        {
            this.builder = builder;
            this.model = model;
            this.type = type;
            this.backWood = backWood;
            this.topWood = topWood;
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

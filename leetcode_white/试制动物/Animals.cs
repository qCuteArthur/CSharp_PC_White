using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试制动物
{
    //不知道继承自DictionaryBase和 继承自CollectionBase有啥区别。
    public class Animals:DictionaryBase
    {

        
            //都是字典大类的操作。
        public void Add(string newID,Animal newAnimal)
        {
            Dictionary.Add(newID,newAnimal);
        }
        public void Remove(string animalID)
        {
            Dictionary.Remove(animalID);
        }
        //返回值是从Animals里面返回Animal类型对象，由于集合中的存储使用的是Dictionary，并且存储的是object，所以输出的时候需要进行强制类型转化为Animal类型。
        //索引器的声明和属性类似
        public Animal this[int AnimalIndex]
        {
            set
            {
                Dictionary[AnimalIndex] = value;
            }
            get
            {
                return (Animal)Dictionary[AnimalIndex];
            }
        }

        public new IEnumerator GetEnumerator()
        {
            foreach(object animal in Dictionary.Values)
            {
                yield return (Animal)animal;
            }
        }
        
    }
}

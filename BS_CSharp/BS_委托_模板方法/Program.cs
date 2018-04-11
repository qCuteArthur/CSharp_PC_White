using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//其实模板方法间接调用
//模板方法间接调用——其实就是把直接调用的部分封装到函数里面了。
//而Action 和 Func方法，你可以理解为Lambda表达式。

//什么叫做·模板方法？
//在WrapFactory中，使用WrapProduct的东西，除了少数部分不一样之外，大部分相同，所以，我们为了代码的重复可用性，使用委托进行重构。


    //.invoke就是调用函数指针
    //这样的好处————最大限度的实现了代码的重复使用
namespace BS_委托_模板方法
{

    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory PF = new ProductFactory();
            WrapFactory WF = new WrapFactory();

            Product myDirectProduct = PF.MakePizza();
            Box box1 = new Box();
            box1.Product = myDirectProduct;

            Product myDirectProduct2 = PF.MakeToy();
            Box box2 = new Box();
            box2.Product = myDirectProduct2;
            //上面两个东西，除了在调用的方法不一样之外，完全相同，这个时候就可以进行封装，同时由于不同的部分是类方法，我们使用函数指针（委托）进行代替。
            


            Func<Product> funcProduct = new Func<Product>(PF.MakePizza);
            Product myFirstProduct = funcProduct.Invoke();

            Func<Product> funcProduct2 = new Func<Product>(PF.MakeToy);
            Product mySecondProduct = funcProduct2.Invoke();


        }
    }
    public class Product
    {
        public string Name { get; set; }
    }
    public class Box
    {
        public Product Product { get; set; }
    }
    public class WrapFactory
    {
        //模板方法，接收一个函数方法作为参数。
        public Box WrapProduct(Func<Product> getProduct)
        {
            Box box = new BS_委托_模板方法.Box();
            Product Product = getProduct.Invoke();
            return box;
        }
    }
    public class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "pizza";
            return product;
        }
        public Product MakeToy()
        {
            Product product = new Product();
            product.Name = "Toy";
            return product;
        }
    }
}
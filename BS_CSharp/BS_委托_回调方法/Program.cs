using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//无论是模板方法还是回调方法，都是差不多的，都是yoga委托来调用外部的方法。然后把方法传进方法的内部来进行间接调用。


    //委托是方法级别的耦合，
    //会引发bugger的难度
    //委托回调 异步调用和 多线程纠缠在一起会使得整个程序难以调用。
    //委托的使用会造成内存泄漏

namespace BS_委托_回调方法
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory PF = new ProductFactory();
            WrapFactory WF = new WrapFactory();
            Logger LOG = new Logger();
            Action<Product> log = new Action<Product>(LOG.Log);


            Func<Product> funcProduct = new Func<Product>(PF.MakePizza);
            Product myFirstProduct = funcProduct.Invoke();
            Func<Product> funcProduct2 = new Func<Product>(PF.MakeToy);
            Product mySecondProduct = funcProduct2.Invoke();

            Box box1 = WF.WrapProduct(funcProduct,log);
            Box box2 = WF.WrapProduct(funcProduct2, log);

            Console.WriteLine(box1.Product.Price);
            Console.WriteLine(box2.Product.Price);
        }
    }
    //记录程序运行状态的logger类。
    class Logger
    {
        //对于没有返回值的方法可以使用action委托
        public void Log(Product product)
        {
            Console.WriteLine("Product'{0}' created at {1} .Price at {2}.",product.Name,DateTime.UtcNow,product.Price);
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Box
    {
        public Product Product { get; set; }
    }
    public class WrapFactory
    {
        //模板方法，接收一个函数方法作为参数。
        public Box WrapProduct(Func<Product> getProduct, Action<Product> logCallBack)
        {
            Box box = new Box();
            Product Product = getProduct.Invoke();
            if (Product.Price > 50)
            {
                logCallBack(Product);
            }
            box.Product = Product;
            return box;
        }

        //如果产品的价格大于50元，我们就log一下。

    }
    public class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "pizza";
            product.Price = 12;
            return product;
        }
        public Product MakeToy()
        {
            Product product = new Product();
            product.Name = "Toy";
            product.Price = 100;
            return product;
        }
    }
}
//回调方法是通过委托类型的方法来传进主调方法的一个被调用方法。主调方法可以根据自己的逻辑来决定是不是调用这个方法。
//好莱坞方法——一个人去面试，并且留下自己的联系方式，老板说，等我们需要你的时候，会给你打电话。
//回调方法———在模板方法上的进一步完善。
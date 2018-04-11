using System;

namespace BS_使用接口替代委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用接口的话，完全不需要使用委托，包括Action和Func
            WrapFactory WF = new WrapFactory();
            Pizza PizzaProduct = new Pizza();
            ToyCar ToyProduct = new ToyCar();

            //抽象类或者是接口自己没办法·1实例化，但是继承之后的实际类可以实例化。
            Iproduct myPizzaFacroty = new Pizza();
            Iproduct myToyFacroty = new ToyCar();

            //抽象类或者是接口的对象是无法创建的。
            //注意，下面定义的函数参数就是虚基类。，
            Box MyBox1 = WF.WarpBox(PizzaProduct);
            Box MyBox2 = WF.WarpBox(ToyProduct);

            Box mybox3 = WF.WarpBox(myPizzaFacroty);
            Box mybox4 = WF.WarpBox(myToyFacroty);


            Console.WriteLine(MyBox1.BoxProduct.Name);
            Console.WriteLine(MyBox1.BoxProduct.Price);
            Console.WriteLine(MyBox2.BoxProduct.Name);
            Console.WriteLine(MyBox2.BoxProduct.Price);

            Console.ReadLine();
        }
    }
    public class Product
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
    public class Box
    {
        private Product boxproduct;

        public Product BoxProduct
        {
            get { return boxproduct; }
            set { boxproduct = value; }
        }
    }
    public class WrapFactory
    {
        //public Box WarpBox(Func<Product> getProduct)
        //{
        //    Product productX = getProduct();
        //    Box boxX = new Box();
        //    boxX.BoxProduct = productX;
        //    return boxX;
        //}
        public Box WarpBox(Iproduct productFactory)
        {
            Box box1 = new Box();
            box1.BoxProduct = productFactory.Make();
            return box1;
        }
        //你这里使用的是一个基类作为参数，所以最后的结果就是直接把这个基类穿进去。
    }
    //下面两个替代了原来的那个ProductFactory
    public interface Iproduct
    {
        Product Make();
        ///就是定义了一个签名啊
    }
    public class Pizza : Iproduct
    {
        public Product Make()
        {
            Product product = new Product() { Name = "pizza", Price = 20.00 };
            return product;
        }
    }
    public class ToyCar : Iproduct
    {
        public Product Make()
        {
            Product product = new Product() { Name = "Toycar", Price = 100.00 };
            return product;
        }
    }
}
//首先注意，学会使用内置的Action委托和Func委托其实差不多就够了= =，然后。。。。。
//一般使用接口替代委托。
//学会大量的使用接口，进行程序的封装。同时封装的程序自己也是可以作为参数的。（接口作为参数）
//内个，说委托是方法级别的耦合，那么这个虚基类或者叫做接口，就是类级别的耦合。


//using System;

//namespace BS_使用接口替代委托
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ProductFactory PF = new ProductFactory();
//            WrapFactory WF = new WrapFactory();
//            Func<Product> action1 = new Func<Product>(PF.MakePizza);
//            Func<Product> action2 = new Func<Product>(PF.MakeToyCar);

//            Box MyBox1 = WF.WarpBox(action1);
//            Box MyBox2 = WF.WarpBox(action2);

//            Console.WriteLine(MyBox1.BoxProduct.Name);
//            Console.WriteLine(MyBox1.BoxProduct.Price);
//            Console.WriteLine(MyBox2.BoxProduct.Name);
//            Console.WriteLine(MyBox2.BoxProduct.Price);

//            Console.ReadLine();
//        }
//    }
//    public class Product
//    {
//        private string name;

//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }
//        private double price;

//        public double Price
//        {
//            get { return price; }
//            set { price = value; }
//        }
//    }
//    public class Box
//    {
//        private Product boxproduct;

//        public Product BoxProduct
//        {
//            get { return boxproduct; }
//            set { boxproduct = value; }
//        }
//    }
//    public class WrapFactory
//    {
//        public Box WarpBox(Func<Product> getProduct)
//        {
//            Product productX = getProduct();
//            Box boxX = new Box();
//            boxX.BoxProduct = productX;
//            return boxX;
//        }
//    }
//    public class ProductFactory
//    {
//        public Product MakePizza()
//        {
//            Product product = new Product() { Name = "pizza", Price = 10.00 };
//            return product;
//        }
//        public Product MakeToyCar()
//        {
//            Product product = new Product() { Name = "toyCar", Price = 100.00 };
//            return product;
//        }
//    }
//}
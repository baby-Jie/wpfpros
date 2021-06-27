using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow():base()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Person p = Test();
            Console.WriteLine(p.age);
        }

        int getRet()
        {
            int a = 1;
            try
            {
                return a;
            }
            catch (Exception e)
            {
            }
            finally
            {
                a++;
            }

            return 99;

        }

        Person Test()
        {
            Person p = new Person();
            p.age = 1;
            try
            {
                return p;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                p.age++;
            }
        }
    }


    public abstract class A
    {
        public virtual void test1()
        {
        }

        public A()
        {
            Console.WriteLine("A");
        }

        public  void Fun()
        {
            Console.WriteLine("A.Fun()");
        }
    }

    public class B:A
    {
        public virtual void test()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (int dicValue in dic.Values)
            {
                
            }
        }

        public B()
        {
            Console.WriteLine("B");
        }

        public new void Fun()
        {
            Console.WriteLine("B.Fun()");
        }
    }

    public class Person
    {
        public int age;

    }
   
}

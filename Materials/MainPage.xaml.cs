using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Animal
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private delegate string AnimalSaying(object sender, EventArgs e);//声明一个委托
        private event AnimalSaying Say;//委托声明一个事件

        public MainPage()
        {
            this.InitializeComponent();
        }

        interface Animal
        {
            //方法
            string saying(object sender, EventArgs e);
            //属性
            int A { get; set; }
        }

        class cat : Animal
        {
            TextBox word;
            private int a;

            public cat(TextBox w)
            {
                this.word = w;
            }
            public string saying(object sender, EventArgs e)
            {
                this.word.Text += "Cat: 喵喵喵\n";
                return "";
            }
            public int A
            {
                get { return a; }
                set { this.a = value; }
            }
        }

        class dog : Animal
        {
            TextBox word;
            private int a;

            public dog(TextBox w)
            {
                this.word = w;
            }
            public string saying(object sender, EventArgs e)
            {
                this.word.Text += "Dog: 汪汪汪\n";
                return "";
            }
            public int A
            {
                get { return a; }
                set { this.a = value; }
            }
        }

        class pig : Animal
        {
            TextBox word;
            private int a;

            public pig(TextBox w)
            {
                this.word = w;
            }
            public string saying(object sender, EventArgs e)
            {
                this.word.Text += "Pig: 呼噜噜\n";
                return "";
            }
            public int A
            {
                get { return a; }
                set { this.a = value; }
            }
        }

        private cat c;
        private dog d;
        private pig p;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            words.Text = ""; //C#事件的绑定机制决定了必须每次清空
            if(c == null) {
                c = new cat(words);
                d = new dog(words);
                p = new pig(words);
            }

            Random rd = new Random(); //产生随机数
            int flag = rd.Next();

            if (flag % 3 == 0) //用取模的结果限定随机输出
            {
                Say += new AnimalSaying(c.saying);
            }
            else if (flag % 3 == 1)
            {
                Say += new AnimalSaying(d.saying);
            }
            else
            {
                Say += new AnimalSaying(p.saying);
            }
            //执行事件
            Say(this, EventArgs.Empty);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void words_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (c == null)
            {
                c = new cat(words);
                d = new dog(words);
                p = new pig(words);
            }
            if (textBox.Text == "cat")
            {
                words.Text = "";
                Say += new AnimalSaying(c.saying);
                Say(this, EventArgs.Empty);
                textBox.Text = "";
            }
            else if (textBox.Text == "dog")
            {
                words.Text = "";
                Say += new AnimalSaying(d.saying);
                Say(this, EventArgs.Empty);
                textBox.Text = "";
            }
            else if (textBox.Text == "pig")
            {
                words.Text = "";
                Say += new AnimalSaying(p.saying);
                Say(this, EventArgs.Empty);
                textBox.Text = "";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread t1;
        Thread t2;
        Thread t3;
        private void Form1_Load(object sender, EventArgs e)
        {
           t1 = new Thread(new ThreadStart(act));
           t2 = new Thread(new ThreadStart(act2));
           t3 = new Thread(new ThreadStart(act3));
            t1.IsBackground = true;
            t2.IsBackground = true;
            t3.IsBackground = true;
            t1.Start();
            t2.Start();
            t3.Start();
        
        }




        public void act() {

            while (true)
            {
                //for (int i = 0; i < 5; i++)
                //{
                Thread.Sleep(10);
                //}

                this.Invoke(new Action(() => {

                 
                    string str = DateTime.Now.Ticks.ToString() + "=>1" + "\r\n";
                    this.textBox1.Text = textBox1.Text.Insert(0, str);
                }));

            }



        }


        public void act2()
        {

            while (true)
            {
                Thread.Sleep(1000);

                this.Invoke(new Action(() => {

                    string str = DateTime.Now.Ticks.ToString() + "=>2" + "\r\n";
                    this.textBox1.Text = textBox1.Text.Insert(0, str);

                }));

            }



        }

        public void act3()
        {

            while (true)
            {
                Thread.Sleep(1000);

                this.Invoke(new Action(()=>{

                    string str = DateTime.Now.Ticks.ToString() + "=>3" + "\r\n";
                    this.textBox1.Text = textBox1.Text.Insert(0, str);

                }));
               

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1.Abort();
            t2.Abort();
            t3.Abort();
        }

        //public public void test2()
        //{
        //    Action act = () =>
        //    {
        //        Console.WriteLine("this is 1");


        //    };


        //    Action act2 = () =>
        //    {

        //        Console.WriteLine("this is 2");
        //    };


        //    Action act3 = () =>
        //    {

        //        Console.WriteLine("this is 3");
        //    };




        //    t2.Join(); //主线程停止,执行t2
        //    t3.Start();
        //    t3.Join(); //主线程停止,执行t3

        //    Console.ReadLine();
        //}

    }
}

using CompetitionDesktopClient.Playing;
using CompetitionDesktopClient.Playing.DecoratorPattern;
using CompetitionDesktopClient.Playing.Func;
using CompetitionDesktopClient.Playing.Generics;
using CompetitionDesktopClient.Playing.StatePattern;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompetitionDesktopClient
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestStructure test = new TestStructure();
            test.WorkIt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SiegeTank tank = new SiegeTank();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FuncTest ft = new FuncTest();
            //ft.Test();

            //FuncTest2 f2 = new FuncTest2();
            //f2.Test();

            FuncTest3 test = new FuncTest3();
            test.Test();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PredicateTest f3 = new PredicateTest();
            f3.TestThis();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenericDemo gen = new GenericDemo();

            gen.RunTest();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tester test = new Tester();
            test.RunTest();
        }
    }
}

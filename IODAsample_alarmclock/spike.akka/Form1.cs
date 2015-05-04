using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace spike.akka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OnDataEntered(this.textBox1.Text);
        }


        public void Display_message(string msg)
        {
            this.label1.Text = msg;
            this.listBox1.Items.Insert(0, msg);
        }


        public event Action<string> OnDataEntered;
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

public class HelloWorld : Form
{
    static public void Main()
    {
        Application.Run(new HelloWorld());
    }

    public HelloWorld()
    {
        Button b = new Button();
        b.Text = "Click Me!";
        b.Click += new EventHandler(Button_Click);
        Controls.Add(b);
    }

    private void Button_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Button Clicked!");
    }
}
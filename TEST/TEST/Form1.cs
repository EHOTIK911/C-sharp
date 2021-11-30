using System.Drawing.Drawing2D;
namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Beige);
            Pen bluePen = new Pen(Color.CadetBlue, 5);
            g.DrawPie(bluePen, -100, -100, pictureBox1.Width, pictureBox1.Height, 0, 45);
            g.Dispose();
        }
    }
}
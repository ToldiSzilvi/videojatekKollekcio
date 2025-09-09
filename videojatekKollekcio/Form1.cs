using static System.Runtime.InteropServices.JavaScript.JSType;

namespace videojatekKollekcio
{
    public partial class Form1 : Form
    {
        public List<Jatek> jatekPeldanyok = new List<Jatek>();
        public Form1()
        {
            InitializeComponent();
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            string utvonal = openFileDialog.FileName;
            beolvasas(utvonal);
        }

        private void beolvasas(string utvonal)
        {
            StreamReader sr = new StreamReader(utvonal);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                Jatek jatek = new Jatek(sr.ReadLine());
                listBox1.Items.Add(jatek.Cim);
                jatekPeldanyok.Add(jatek);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = jatekPeldanyok[listBox1.SelectedIndex].Cim;
            textBox2.Text = jatekPeldanyok[listBox1.SelectedIndex].Fejleszto;
            textBox3.Text = jatekPeldanyok[listBox1.SelectedIndex].Platform;
            textBox4.Text = jatekPeldanyok[listBox1.SelectedIndex].MegjelenesEv.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Nincs megadva fejlesztõ a kereséshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (Jatek elem in jatekPeldanyok)
            {
                if (elem.Fejleszto.Equals(textBox2.Text) && elem.Cim.Equals(textBox1.Text) == false)
                {
                    listBox2.Items.Add(elem.Cim);
                }
            }
            if (listBox2.Items.Count == 0)
            {
                MessageBox.Show("Az adott fejlesztõnek nincs több játéka", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

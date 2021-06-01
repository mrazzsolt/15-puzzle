using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        int[,] helyes;
        int noveles;
        public Form1()
        {
            InitializeComponent();
            this.Activated += AfterLoading;
            r = new Random();
            negyzetek = new Label[x, y];
            helyes=new int[x, y];
            szamlalo = 0;
            
        }
        Random r;
        Label[,] negyzetek;
        int x = 4;
        int y = 4;
        int a = 0;
        int b = 0;
        string seged="";
        int szamlalo;
       
        private void klikk(object sender, EventArgs e)
        {
            if ((sender as Label).Text != "")
            {
                
                seged = (sender as Label).Text;
                
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (negyzetek[i, j].Text == seged)
                        {
                            a = i;
                            b = j;
                        }
                    }
                }
                try
                {
                    if (a - 1 >= 0&&negyzetek[a - 1, b].Text == "")
                    {
                        negyzetek[a - 1, b].Text = (sender as Label).Text;
                        negyzetek[a,b].Text = "";
                        szamlalo++;
                        

                    }
                    else if (a + 1 < x && negyzetek[a + 1, b].Text == "")
                    {
                        negyzetek[a + 1, b].Text = (sender as Label).Text;
                        negyzetek[a, b].Text = "";
                        szamlalo++;
                    }
                    
                    else if (b - 1 >= 0 && negyzetek[a, b - 1].Text == "")
                    {
                        negyzetek[a, b - 1].Text = (sender as Label).Text;
                        negyzetek[a, b].Text = "";
                        szamlalo++;
                    }
                    else if (b + 1 < y && negyzetek[a, b + 1].Text == "")
                    {
                        negyzetek[a, b + 1].Text = (sender as Label).Text;
                        negyzetek[a,b].Text = "";
                        szamlalo++;
                    }
                }
                catch
                {
                    MessageBox.Show("hiba");
                }
            }
            int nyeres = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (helyes[i,j].ToString()==negyzetek[i,j].Text)
                    {
                        nyeres++;
                    }

                }
            }
            if(nyeres>=15)
            {
                MessageBox.Show("Nyertél! "+szamlalo+" lépésből.");
            }
            richTextBox1.Text = szamlalo.ToString() + ". lépésed.";
            
        }
        private void AfterLoading(object sender, EventArgs e)
        {
            
            
            this.Text = "Tili-Toli";
            this.ControlBox = false;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    negyzetek[i,j] = new Label();
                    negyzetek[i,j].Parent = Form1.ActiveForm;
                    //negyzetek[i, j].Text = (r.Next(1, 16)).ToString();
                    negyzetek[i,j].Width = 50;
                    negyzetek[i,j].Height = 50;
                    negyzetek[i,j].AutoSize = false;
                    negyzetek[i,j].BackColor = Color.CadetBlue;
                    negyzetek[i,j].Font = new Font("Arial", 20,FontStyle.Bold);
                    negyzetek[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    negyzetek[i,j].Left = 50 + i * 50;
                    negyzetek[i,j].Top = 100 + j * 50;
                    negyzetek[i,j].BorderStyle = BorderStyle.Fixed3D;
                    //negyzetek[i,j].Font = new Font("Arial", 10);
                    negyzetek[i,j].Click += klikk;
                }
            }
            for (int i = 1; i <= x * y; i++)
            {
                int rx, ry;
                bool hiba;
                do
                {
                    hiba = false;
                    rx = r.Next(x);
                    ry = r.Next(y);

                    if (negyzetek[rx, ry].Text != "")
                    {
                        hiba = true;
                    }

                } while (hiba == true);

                negyzetek[rx, ry].Text = i.ToString();
            }
            
            //teszt();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (negyzetek[i, j].Text == "16")
                    {
                        negyzetek[i, j].Text = "";
                    }
                }
            }
            String_Feltoltes();
            
        }

        private void teszt()
        {
            int valami = 1;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    negyzetek[j, i].Text = valami.ToString();
                    valami++;
                }
            }
        }

        private void String_Feltoltes()
        {
            noveles = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    noveles++;
                    helyes[j, i] = noveles;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Újra szeretnéd indítani?", "Reset", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                this.Refresh();
                Refresh();
                this.Hide();
                Form1 ss = new Form1();
                ss.ShowDialog();
                
                DialogResult = DialogResult.OK;
                Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult kilepes = MessageBox.Show("Ki szeretnél lépni?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
            if(kilepes==DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Örülök, hogy nem léptél ki. Sok Sikert!");
            }
            
        }
    }
}

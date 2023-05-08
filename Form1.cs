using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuyruk_VeYığın_Projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = (trackBar1.Maximum + 1) - trackBar1.Value; //1 arttırma maximum deger valueye eşit olunca hata verdi o yüzden ekledk.
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            timer2.Interval = (trackBar2.Maximum + 1) - trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            timer3.Interval = (trackBar3.Maximum + 1) - trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            timer4.Interval = (trackBar4.Maximum + 1) - trackBar4.Value;
        }


        Random rnd = new Random();
        public class kuyruk
        {
            public int p1kuyruk;
            public int p2kuyruk;
            public int p3kuyruk;
            public kuyruk sonrakikuyruk;
        }
        public class yıgınp1
        {
            public int p1yıgın;
            public yıgınp1 sonrakiyıgınp1;
        }
        public class yıgınp2
        {
            public int p2yıgın;
            public yıgınp2 sonrakiyıgınp2;                //4 kuyruk 3 yığın yapısı
        }
        public class yıgınp3
        {
            public int p3yıgın;
            public yıgınp3 sonrakiyıgınp3;
        }
        public class p1list
        {
            public int p1;
            public p1list sonrakip1;
        }
        public class p2list
        {
            public int p2;
            public p2list sonrakip2;
        }
        public class p3list
        {
            public int p3;
            public p3list sonrakip3;
        }

        public p1list onkuyrukp1 = null, arkakuyrukp1 = null;
        public p2list onkuyrukp2 = null, arkakuyrukp2 = null;
        public p3list onkuyrukp3 = null, arkakuyrukp3 = null;
        public kuyruk onkuyruk = null, arkakuyruk = null;
        public yıgınp1 ilkyıgınp1 = null, sonyıgınp1 = null;
        public yıgınp2 ilkyıgınp2 = null, sonyıgınp2 = null;
        public yıgınp3 ilkyıgınp3 = null, sonyıgınp3 = null;

        private void timer1_Tick(object sender, EventArgs e)
        {
            kuyruk kuyruk = new kuyruk();
            if (onkuyrukp1!=null && onkuyrukp2!=null && onkuyrukp3!=null) //işlemci hızını fazla arttırdığımızda null hatasını önlemek için.
            {
                kuyruk.p1kuyruk = onkuyrukp1.p1;
                kuyruk.p2kuyruk = onkuyrukp2.p2;  //kuyrukları işlemciye aktarmış olduk (merge linkedlist)
                kuyruk.p3kuyruk = onkuyrukp3.p3;
                if (onkuyruk == null)
                {
                    onkuyruk = kuyruk;
                    arkakuyruk = kuyruk;
                }
                else
                {
                    arkakuyruk.sonrakikuyruk = kuyruk;
                    //kuyruk.sonrakikuyruk = null; 
                    arkakuyruk = arkakuyruk.sonrakikuyruk; //sonraki kuyrugu p1 p2 p3 den alıp devam ettirmesi için
                    arkakuyruk = kuyruk;

                }
                yazdirKuyruk();
                yıgınp1 yıgınp1 = new yıgınp1();
                yıgınp2 yıgınp2 = new yıgınp2();
                yıgınp3 yıgınp3 = new yıgınp3();
                yıgınp1.p1yıgın = onkuyruk.p1kuyruk;
                yıgınp2.p2yıgın = onkuyruk.p2kuyruk;
                yıgınp3.p3yıgın = onkuyruk.p3kuyruk;
                if (ilkyıgınp1 == null)
                {
                    ilkyıgınp1 = yıgınp1;
                    sonyıgınp1 = yıgınp1;
                }
                else
                {
                    yıgınp1.sonrakiyıgınp1 = ilkyıgınp1;
                    ilkyıgınp1 = yıgınp1;
                }

                if (ilkyıgınp2 == null)
                {
                    ilkyıgınp2 = yıgınp2;
                    sonyıgınp2 = yıgınp2;
                }
                else
                {
                    yıgınp2.sonrakiyıgınp2 = ilkyıgınp2;
                    ilkyıgınp2 = yıgınp2;
                }


                if (ilkyıgınp3 == null)
                {
                    ilkyıgınp3 = yıgınp3;
                    sonyıgınp3 = yıgınp3;
                }
                else
                {
                    yıgınp3.sonrakiyıgınp3 = ilkyıgınp3;
                    ilkyıgınp3 = yıgınp3;
                }
                kuyrukSil(); //veriler kuyruktan silinmeden önce yığınlara aktarıldı.
            }
        }
           
        private void timer2_Tick(object sender, EventArgs e)
        {
            p1list yenip1 = new p1list();
            yenip1.p1 = rnd.Next(0, 6);

            if (onkuyrukp1 == null)  //p1
            {
                onkuyrukp1 = yenip1;
                arkakuyrukp1 = yenip1;
            }
            else
            {
                arkakuyrukp1.sonrakip1 = yenip1;
                yenip1.sonrakip1 = null;
                arkakuyrukp1 = yenip1;
            }
            Yazdirp1();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            p2list yenip2 = new p2list();
            yenip2.p2 = rnd.Next(0, 6);
            if (onkuyrukp2 == null)  //p2
            {
                onkuyrukp2 = yenip2;
                arkakuyrukp2 = yenip2;
            }
            else
            {
                arkakuyrukp2.sonrakip2 = yenip2;
                yenip2.sonrakip2 = null;
                arkakuyrukp2 = yenip2;
            }
            Yazdirp2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled==false)
            {
                MessageBox.Show("İşlemci Başlatılmadan Durdurulamaz...", "Hata");
            }
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            p3list yenip3 = new p3list();
            yenip3.p3 = rnd.Next(0, 6);
            if (onkuyrukp3 == null)  //p3
            {
                onkuyrukp3 = yenip3;
                arkakuyrukp3 = yenip3;
            }
            else
            {
                arkakuyrukp3.sonrakip3 = yenip3;
                yenip3.sonrakip3 = null;
                arkakuyrukp3 = yenip3;
            }
            Yazdirp3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
        }

        private void Yazdirp1()
        {
            textBox2.Clear();
            p1list yeni = new p1list();
            yeni = onkuyrukp1;
            while (yeni != null)
            {
                textBox2.Text += "P1-" + yeni.p1 + Environment.NewLine;
                yeni = yeni.sonrakip1;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yıgınYazdır();
        }

        private void Yazdirp2()
        {
            textBox3.Clear();
            p2list yeni = new p2list();
            yeni = onkuyrukp2;
            while (yeni != null)
            {
                textBox3.Text += "P2-" + yeni.p2 + Environment.NewLine;
                yeni = yeni.sonrakip2;

            }
        }
        private void Yazdirp3()
        {
            textBox4.Clear();
            p3list yeni = new p3list();
            yeni = onkuyrukp3;
            while (yeni != null)
            {
                textBox4.Text += "P3-" + yeni.p3 + Environment.NewLine;
                yeni = yeni.sonrakip3;

            }
        }
        private void yazdirKuyruk()
        {
            textBox1.Clear();
            kuyruk yeni = new kuyruk();
            yeni = onkuyruk;
            while (yeni != null)              //process önceliğine göre tersten çalışmalı.
            {
                if (yeni.p1kuyruk >= yeni.p2kuyruk && yeni.p1kuyruk >= yeni.p3kuyruk)
                {
                    if (yeni.p2kuyruk >= yeni.p3kuyruk)
                    {
                        textBox1.Text += "P3-" + yeni.p3kuyruk + "-->" + " P2-" + yeni.p2kuyruk + "-->" + "P1-" + yeni.p1kuyruk + "-->"; //3-2-1
                        yeni = yeni.sonrakikuyruk;
                    }
                    else
                    {
                        textBox1.Text += "P2-" + yeni.p2kuyruk + "-->" + " P3-" + yeni.p3kuyruk + "-->" + "P1-" + yeni.p1kuyruk + "-->"; //2-3-1;
                        yeni = yeni.sonrakikuyruk;
                    }
                }
                else if (yeni.p2kuyruk >= yeni.p1kuyruk && yeni.p2kuyruk >= yeni.p3kuyruk)
                {
                    if (yeni.p1kuyruk >= yeni.p3kuyruk)
                    {
                        textBox1.Text += "P3-" + yeni.p3kuyruk + "-->" + " P1-" + yeni.p1kuyruk + "-->" + "P2-" + yeni.p2kuyruk + "-->"; //3-1-2;
                        yeni = yeni.sonrakikuyruk;
                    }
                    else
                    {
                        textBox1.Text += "P1-" + yeni.p1kuyruk + "-->" + " P3-" + yeni.p3kuyruk + "-->" + "P2-" + yeni.p2kuyruk + "-->"; //1-3-2
                        yeni = yeni.sonrakikuyruk;
                    }
                }
                else if (yeni.p3kuyruk >= yeni.p1kuyruk && yeni.p3kuyruk >= yeni.p2kuyruk)
                {
                    if (yeni.p1kuyruk >= yeni.p2kuyruk)
                    {
                        textBox1.Text += "P2-" + yeni.p2kuyruk + "-->" + " P1-" + yeni.p1kuyruk + "-->" + "P3-" + yeni.p3kuyruk + "-->"; //2-1-3
                        yeni = yeni.sonrakikuyruk;
                    }
                    else
                    {
                        textBox1.Text += "P1-" + yeni.p1kuyruk + "-->" + " P2-" + yeni.p2kuyruk + "-->" + "P3-" + yeni.p3kuyruk + "-->"; //1-2-3
                        yeni = yeni.sonrakikuyruk;
                    }
                }
            }
        }
        private void kuyrukSil()
        {
            onkuyrukp1 = onkuyrukp1.sonrakip1;
            onkuyrukp2 = onkuyrukp2.sonrakip2;
            onkuyrukp3 = onkuyrukp3.sonrakip3;
            onkuyruk = onkuyruk.sonrakikuyruk; //yıgınlarda sonraki veriyi almak için

        }
        private void yıgınYazdır()
        {
            textBox5.Clear();
            yıgınp3 yeni3 = new yıgınp3();
            yıgınp2 yeni2 = new yıgınp2();
            yıgınp1 yeni1 = new yıgınp1();
            yeni1 = ilkyıgınp1;
            yeni2 = ilkyıgınp2;
            yeni3 = ilkyıgınp3;
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
            {
                while (yeni1 != null && yeni2 != null && yeni3 != null)
                {
                    textBox5.Text += "P1-" + yeni1.p1yıgın + "\t   P2-" + yeni2.p2yıgın + "\t       P3-" + yeni3.p3yıgın + Environment.NewLine;
                    yeni1 = yeni1.sonrakiyıgınp1;
                    yeni2 = yeni2.sonrakiyıgınp2;
                    yeni3 = yeni3.sonrakiyıgınp3;
                }
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                while (yeni1 != null && yeni2!= null)
                {
                    textBox5.Text += "P1-" + yeni1.p1yıgın + "\t   P2-" + yeni2.p2yıgın + Environment.NewLine;
                    yeni1 = yeni1.sonrakiyıgınp1;
                    yeni2 = yeni2.sonrakiyıgınp2;
                }
            }
            else if (checkBox1.Checked== true && checkBox3.Checked == true)
            {
                while (yeni1 != null && yeni3!=null)
                {
                    textBox5.Text += "P1-" + yeni1.p1yıgın +"\t\t      P3-" + yeni3.p3yıgın + Environment.NewLine;
                    yeni1 = yeni1.sonrakiyıgınp1;
                    yeni3 = yeni3.sonrakiyıgınp3;
                }
            }
            else if (checkBox2.Checked==true && checkBox3.Checked == true)
            {
                while (yeni3 != null)
                {
                    textBox5.Text += "\t P2-" + yeni2.p2yıgın + "\t       P3-" + yeni3.p3yıgın + Environment.NewLine;
                    yeni3 = yeni3.sonrakiyıgınp3;
                    yeni2 = yeni2.sonrakiyıgınp2;
                }
            }
            else if (checkBox1.Checked==true)
            {
                while (yeni1!=null)
                {
                    textBox5.Text += "P1-" + yeni1.p1yıgın + Environment.NewLine;
                    yeni1 = yeni1.sonrakiyıgınp1;
                }
            }
            else if (checkBox2.Checked==true)
            {
                while (yeni2!=null)
                {
                    textBox5.Text += "\t   P2-" + yeni2.p2yıgın + Environment.NewLine;
                    yeni2 = yeni2.sonrakiyıgınp2;
                }
            }
            else if (checkBox3.Checked==true)
            {
                while (yeni3!=null)
                {
                    textBox5.Text += "\t\t       P3-" + yeni3.p3yıgın + Environment.NewLine;
                    yeni3 = yeni3.sonrakiyıgınp3;
                }
            }
            else if (checkBox1.Checked!=true && checkBox2.Checked!=true && checkBox3.Checked!=true)
            {
                MessageBox.Show("Hangi Processleri Listeleyeceğinizi Seçmediniz...", "HATA");
            }
        }
    }
}
    






using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInformations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("TC KİMLİK NO", 150);
            listView1.Columns.Add("ADI SOYADI", 200);
            listView1.Columns.Add("YAŞI", 50);
            listView1.Columns.Add("MEZUNİYETİ", 150);
            listView1.Columns.Add("CİNSİYETİ", 125);
            listView1.Columns.Add("DOĞUM YERİ", 125);
            listView1.Columns.Add("TELEFON NO", 130);

            string[] mezuniyet = { "İlköğretim", "Ortaöğretim", "Lisans", "Yüksek Lisans", "Doktora" };
            comboBox1.Items.AddRange(mezuniyet);
            kayitsayisiyaz();         
        }
        private void kayitsayisiyaz()
        {
            int kayitsayisi = listView1.Items.Count;
            label6.Text = Convert.ToString(kayitsayisi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tc = "", adsoyad = "", yas = "", mezuniyet = "", cinsiyet = "", dogumyeri = "", telno = "";
            tc = textBox1.Text; adsoyad = textBox2.Text; yas = textBox3.Text; mezuniyet = comboBox1.Text;
            if (radioButton1.Checked == true)
                cinsiyet = radioButton1.Text; //radioButton1.Text yerine sadece "Bay" da yazabilirdik
            else if (radioButton2.Checked == true)
                cinsiyet = radioButton2.Text;
            dogumyeri = textBox4.Text;
            telno = textBox5.Text;

            string[] bilgiler = { tc, adsoyad, yas, mezuniyet, cinsiyet, dogumyeri, telno };

            bool aranankayitkontrolu = false;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    aranankayitkontrolu = true;
                    MessageBox.Show(textBox1.Text + " TC Kimlik Numarası Zaten Kayıtlarda Mevcuttur.");
                }
            }
            if (aranankayitkontrolu == false)
            {
                ListViewItem bilgiler2 = new ListViewItem(bilgiler);
                if (tc != "" && adsoyad != "" && yas != "" && mezuniyet != "" && dogumyeri != "" && telno != "")
                {
                    listView1.Items.Add(bilgiler2);
                }
                else
                    MessageBox.Show("Kayıt Bilgilerinde Eksiklik Var!");
            }
            kayitsayisiyaz();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secilensayisi = listView1.CheckedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.CheckedItems)
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secilensayisi.ToString() + " Adet Kayıt Silindi.");
            kayitsayisiyaz();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int secilensayisi = listView1.SelectedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.SelectedItems)
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secilensayisi.ToString() + " Adet Kayıt Silindi.");
            kayitsayisiyaz();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            kayitsayisiyaz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool aranankayitkontrolu = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    aranankayitkontrolu = true;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text = listView1.Items[i].SubItems[2].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[3].Text;
                    if (listView1.Items[i].SubItems[4].Text == "Bay")
                        radioButton1.Checked = true;
                    else if (listView1.Items[i].SubItems[4].Text == "Bayan")                        
                        radioButton2.Checked = true;
                    textBox4.Text = listView1.Items[i].SubItems[5].Text;
                    textBox5.Text = listView1.Items[i].SubItems[6].Text;
                    //veri girişini engelleyip pasif yapmak için enabled özelliğini false yapiyoruz.
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    comboBox1.Enabled = false;
                    groupBox1.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                }
            }
            if (aranankayitkontrolu == false)
            {
                MessageBox.Show(textBox1.Text + " TC Kimlik Numaralı Kayıt Bulunamadı");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            comboBox1.Enabled = true;
            groupBox1.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }
    }
}

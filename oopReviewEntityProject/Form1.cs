using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oopReviewEntityProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EntityProjectDBEntities db = new EntityProjectDBEntities(); //dbye erissmek
        private void button1_Click(object sender, EventArgs e)
        {
            
            var values = db.TblGuide.ToList();// To list ile beraber hepsini listeleriz
            dataGridView1.DataSource = values;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            
            guide.GuideName=textBox2.Text;
            guide.GuideSurname = textBox3.Text;

            db.TblGuide.Add(guide);//Ekleme
            db.SaveChanges();//Kaydetme
            MessageBox.Show("Guide Added!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id =int.Parse(textBox1.Text);
            var removeValue = db.TblGuide.Find(id);
            db.TblGuide.Remove(removeValue);
            db.SaveChanges() ;
            MessageBox.Show("Guide Deleted!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var updateValue=db.TblGuide.Find(id);
            updateValue.GuideName = textBox2.Text;
            updateValue.GuideSurname = textBox3.Text;
            db.SaveChanges();
            MessageBox.Show("Guide Updated!","HEY",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var values=db.TblGuide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}

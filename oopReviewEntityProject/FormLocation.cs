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
    public partial class FormLocation : Form
    {
        public FormLocation()
        {
            InitializeComponent();
        }
        EntityProjectDBEntities db = new EntityProjectDBEntities(); //dbye erissmek
        private void button1_Click(object sender, EventArgs e)
        {
            var values = db.TblLocation.ToList();// To list ile beraber hepsini listeleriz
            dataGridView1.DataSource = values;
        }

        private void FormLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname
            }).ToList();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "TblGuide";
            comboBox1.DataSource = values;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblLocation location = new TblLocation();
            
            location.LocationCity=textBox2.Text;
            location.LocationCountry=textBox3.Text;
            location.LocationCapacitty = byte.Parse(numericUpDown1.Value.ToString());
            location.LocationPrice=decimal.Parse(textBox4.Text);
            location.DayNight=textBox5.Text;
            location.GuideId =int.Parse(comboBox1.SelectedValue.ToString());
            db.TblLocation.Add(location);
            db.SaveChanges();
            MessageBox.Show("Added");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var deleteValue = db.TblLocation.Find(id);
            db.TblLocation.Remove(deleteValue);

            db.SaveChanges();
            MessageBox.Show("Deleted!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var updateValue = db.TblLocation.Find(id);
            updateValue.DayNight=textBox5.Text;
            updateValue.LocationCity = textBox2.Text; ;
            updateValue.LocationCountry = textBox3.Text;
            updateValue.LocationCapacitty= byte.Parse(numericUpDown1.Value.ToString());
            updateValue.LocationPrice = decimal.Parse(textBox4.Text);
            updateValue.GuideId=int.Parse(comboBox1.SelectedValue.ToString());
            db.TblLocation.Add(updateValue);
            db.SaveChanges();
            MessageBox.Show("Updated!");
        }
    }
}

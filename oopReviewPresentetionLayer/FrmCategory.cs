using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oopReviewBusinessLayer.Abstract;
using oopReviewBusinessLayer.Concrete;
using oopReviewDataAccessLayer.EntityFramework;
using oopReviewEntityLayer.Concrete;

namespace oopReviewPresentetionLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());//bu yontemin daha iyisi var ama yapmiyoruz 
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //business servise gidip calisacaz

            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category category=new Category();
            category.CategoryName = textBox2.Text;
            category.CategoryStatus = 1;
            _categoryService.TInsert(category);
            MessageBox.Show("Added");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id=int.Parse(textBox1.Text);
            var deleteValues=_categoryService.TGetById(id);
            _categoryService.TDelete(deleteValues);
            MessageBox.Show("Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id=int.Parse(textBox1.Text);
            var values=_categoryService.TGetById(id);
            _categoryService.TUpdate(values);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            int updatedId=int.Parse(textBox1.Text);
            var updatedValue=_categoryService.TGetById(updatedId);
            updatedValue.CategoryName = textBox2.Text;
            updatedValue.CategoryStatus = 1;
            _categoryService.TUpdate(updatedValue);

        }
    }
}

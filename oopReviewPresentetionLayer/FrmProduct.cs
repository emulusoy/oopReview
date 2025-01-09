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
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FrmProduct()
        {
            _productService = new ProductManager(new EfProductDal());
            _categoryService=new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            product.ProductName = txtProductname.Text;
            product.ProductPrice = decimal.Parse(txtPrice.Text);
            product.ProductDescription = txtDescript.Text;
            product.ProductStock = int.Parse(txtStock.Text);

            _productService.TInsert(product);
            MessageBox.Show("ADDED");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource= values;   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtProductid.Text);
            var value=_productService.TGetById(id);
            _productService.TDelete(value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductid.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource= value;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtProductid.Text);
            var value=_productService.TGetById(id);
            value.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            value.ProductDescription = txtDescript.Text;
            value.ProductPrice=decimal.Parse(txtStock.Text);
            value.ProductStock = int.Parse(txtStock.Text);
            value.ProductName=txtProductname.Text;
            _productService.TUpdate(value);
            MessageBox.Show("Updated");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values=_categoryService.TGetAll();
            comboBox1.DataSource= values;
            comboBox1.DisplayMember= "CategoryName";
            comboBox1.ValueMember= "CategoryId";
        }
    }
}

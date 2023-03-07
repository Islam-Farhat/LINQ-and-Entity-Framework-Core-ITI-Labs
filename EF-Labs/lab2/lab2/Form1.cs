using lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        JouralismContext context = new JouralismContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = context.newDetails.Select(x => new {x.News.id, x.News.title,x.News.bref,x.News.datetime,x.News.autherId,x.description,x.photo,x.pdf,x.Id}).ToList();
            cmbAuther.DataSource = context.authers.ToList();
            cmbAuther.ValueMember = "Id";
            cmbAuther.DisplayMember = "name";
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            News newsObj = new News();
            NewDetails newDetailsObj = new NewDetails();

            newsObj.title = txttitle.Text;
            newsObj.bref = txtbref.Text;
            newsObj.datetime = dateTimePicker.Value;
            newsObj.autherId = (int)cmbAuther.SelectedValue;
            context.news.Add(newsObj);
            context.SaveChanges();

            newDetailsObj.description = txtdesc.Text;
            newDetailsObj.photo = txtphoto.Text;
            newDetailsObj.pdf = txtpdf.Text;
            newDetailsObj.newId = newsObj.id;
            context.newDetails.Add(newDetailsObj);
            context.SaveChanges();

            dataGridView.DataSource = context.newDetails.Select(x => new { x.News.id, x.News.title, x.News.bref, x.News.datetime, x.News.autherId, x.description, x.photo, x.pdf, x.Id }).ToList();
            cmbAuther.DataSource = context.authers.ToList();
            cmbAuther.ValueMember = "Id";
            cmbAuther.DisplayMember = "name";

        }











        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            var news = context.news.FirstOrDefault(x => x.id == newid);
            var newdetails = context.newDetails.FirstOrDefault(x => x.Id == newdetailsid);
            news.title = txttitle.Text;
            news.bref = txtbref.Text;
            news.datetime = dateTimePicker.Value;
            news.autherId = (int)cmbAuther.SelectedValue;
            newdetails.description = txtdesc.Text;
            newdetails.photo = txtphoto.Text;
            newdetails.pdf = txtpdf.Text;
            context.news.Update(news);
            context.newDetails.Update(newdetails);
            context.SaveChanges();

            dataGridView.DataSource = context.newDetails.Select(x => new { x.News.id, x.News.title, x.News.bref, x.News.datetime, x.News.autherId, x.description, x.photo, x.pdf, x.Id }).ToList();
            cmbAuther.DataSource = context.authers.ToList();
            cmbAuther.ValueMember = "Id";
            cmbAuther.DisplayMember = "name";
        }
        int newid = 0;
        int newdetailsid = 0;
        private void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txttitle.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtbref.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker.Value= (DateTime)dataGridView.SelectedRows[0].Cells[3].Value;
            cmbAuther.SelectedValue = dataGridView.SelectedRows[0].Cells[4].Value;

            txtdesc.Text = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            txtphoto.Text = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
            txtpdf.Text = dataGridView.SelectedRows[0].Cells[7].Value.ToString();

            newid =(int) dataGridView.SelectedRows[0].Cells[0].Value;
            newdetailsid = (int)dataGridView.SelectedRows[0].Cells[8].Value;
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var news = context.news.FirstOrDefault(x => x.id == newid);
            var newdetails = context.newDetails.FirstOrDefault(x => x.Id == newdetailsid);
            
            context.newDetails.Remove(newdetails);
            context.news.Remove(news);
            
            context.SaveChanges();

            dataGridView.DataSource = context.newDetails.Select(x => new { x.News.id, x.News.title, x.News.bref, x.News.datetime, x.News.autherId, x.description, x.photo, x.pdf, x.Id }).ToList();
            cmbAuther.DataSource = context.authers.ToList();
            cmbAuther.ValueMember = "Id";
            cmbAuther.DisplayMember = "name";
        }
    }
}
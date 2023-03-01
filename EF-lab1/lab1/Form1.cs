using lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab1
{
    public partial class Form1 : Form
    {
        ItiContext context = new ItiContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = context.Topics.ToList();
            comtTopic.DataSource= context.Topics.ToList();
            comtTopic.ValueMember = "TopId";
            comtTopic.DisplayMember = "TopName";
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = context.Topics.Where(t=>t.TopName.ToLower().Contains(txtsearch.Text.ToLower())).ToList();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Topic topic = new Topic();
            topic.TopId = int.Parse(txtid.Text);
            topic.TopName = txtname.Text;
            
            if (btnsave.Text == "Update")
            {
                var newtopicupdated = context.Topics.FirstOrDefault(x => x.TopId==topic.TopId);
                newtopicupdated.TopName= txtname.Text;
                context.Topics.Update(newtopicupdated);
                txtid.Enabled = true;
                btnsave.Text = "Add";
            }
            else
            {
                context.Topics.Add(topic);
            }
            context.SaveChanges();
            dataGridView.DataSource = context.Topics.ToList();
            comtTopic.DataSource = context.Topics.ToList();
            comtTopic.ValueMember = "TopId";
            comtTopic.DisplayMember = "TopName";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var topic = context.Topics.FirstOrDefault(x => x.TopId == (int)comtTopic.SelectedValue);
            context.Topics.Remove(topic);
            context.SaveChanges();
            comtTopic.DataSource = context.Topics.ToList();
            comtTopic.ValueMember = "TopId";
            comtTopic.DisplayMember = "TopName";
        }

        private void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtid.Text = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtid.Enabled = false;
            btnsave.Text = "Update";
        }
    }
}
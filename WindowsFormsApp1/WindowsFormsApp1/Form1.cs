using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Book> bookList;
        private int bid;
        

        public Form1()
        {
            InitializeComponent();
            bookList = new List<Book>()
            {
                new Book("B101","Jane Eyre","Brontë", 58,10.40f),
                new Book("B102","Twilight","S. Meyer", 49 ,11.49f),
                new Book("B103","Killing Floor","Lee Child", 80,12.95f),
            };

        }



        void setPanel(String pname)
        {
            foreach (Control c in this.Controls)
                if (c is Panel)
                {
                    Panel p = c as Panel;
                    if (p.Name.Equals(pname))
                        p.Visible = true;
                    else
                        p.Visible = false;
                }
        }

        public void Clear()
        {
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            label13.Text = String.Empty;
            label14.Text = String.Empty;
            label15.Text = String.Empty;
            label16.Text = String.Empty;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            setPanel("panel2");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setPanel("panel1");
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Book b in bookList)
                if (b.Bname.Contains(textBox1.Text))
                    listBox1.Items.Add(b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            setPanel("panel3");
            List<int> idList = new List<int>();
            foreach (Book b in bookList)
            {
                idList.Add(int.Parse(b.BookId.Substring(1)));
            }
                
            idList.Sort();
            bid = idList[idList.Count -1] + 1 ;
            textBox2.Text = "B" + bid;

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            bookList.Add(new Book(textBox2.Text, textBox3.Text, textBox4.Text, int.Parse(textBox5.Text), float.Parse(textBox6.Text)));
            MessageBox.Show("Book" + bid + "Added");
            Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            setPanel("panel5");
           
            foreach (Book b in bookList)
                comboBox2.Items.Add(b);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book b = (Book)comboBox2.SelectedItem;
            textBox7.Text = "" + b.Bname;
            textBox8.Text = "" + b.Author;
            textBox9.Text = "" + b.Quantity;
            textBox10.Text = "" + b.Price;
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        
            if (MessageBox.Show("Do you want to Update", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Book b = (Book)comboBox2.SelectedItem;
                b.Bname = textBox7.Text;
                b.Author = textBox8.Text;
                b.Quantity = int.Parse(textBox9.Text);
                b.Price = float.Parse(textBox10.Text);
                button3_Click(sender, e);
                Clear();
            }
            else
            {
                MessageBox.Show("NotUpdate", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setPanel("panel4");
            foreach (Book b in bookList)
                comboBox1.Items.Add(b);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book b = (Book)comboBox1.SelectedItem;
            label13.Text = "" + b.Bname;
            label14.Text = "" + b.Author;
            label15.Text = "" + b.Quantity;
            label16.Text = "" + b.Price;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Book b = (Book)comboBox1.SelectedItem;
           
            if(MessageBox.Show("Do you want to delete" , "delete" , MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
            {
                bookList.Remove(b);
                button4_Click(sender, e);
                Clear();

            }
            else
            {
                MessageBox.Show("Not Delete", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setPanel("panel6");
            Clear();
            bookList.Sort();
            foreach (Book b in bookList)
                listBox2.Items.Add(b);
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setPanel("panel6");
            Clear();
            bookList.Sort(new SortByAuthor());
            foreach (Book b in bookList)
                listBox2.Items.Add(b);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace StudList
{
	public partial class Form1 : Form
	{
		List<Students> stu = new List<Students>();
		int id = 0;
		int temp = 0;
		void DataSourceReset()
		{
			listBox1.DataSource = null;
			listBox1.DataSource = stu;
			listBox1.DisplayMember = "Name";
			listBox1.ValueMember = "ID";
			listBox2.DataSource = null;
			listBox2.DataSource = stu;
			listBox2.DisplayMember = "Date";
			listBox2.ValueMember = "ID";
			listBox3.DataSource = null;
			listBox3.DataSource = stu;
			listBox3.DisplayMember = "Group";
			listBox3.ValueMember = "ID";
		}
		public Form1()
		{
			InitializeComponent();
			listBox1.DataSource = stu;
			listBox1.DisplayMember = "Name";
			listBox2.DataSource = stu;
			listBox2.DisplayMember = "Date";
			listBox3.DataSource = stu;
			listBox3.DisplayMember = "Group";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (
				textBox1.Text == "" &
				textBox2.Text == "" &
				textBox3.Text == "")
			{
				label1.Visible = true;
			}
			else
			{
				string name;
				if (textBox1.Text != "")
				{ name = textBox1.Text; }
				else { name = ""; };

				DateTime nd;
				if (textBox2.Text != "")
				{
					nd = DateTime.ParseExact(textBox2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

				}
				else nd = DateTime.Now;

				int ng;
				if (textBox3.Text != "")
				{

					ng = Int32.Parse(textBox3.Text);
				}
				else ng = 0;


				stu.Insert(id, new Students()
				{
					Name = name,
					Date = nd,
					Group = ng,
					ID=id,


				});


				id++;
				DataSourceReset();


			}
		}

		

		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			button1.Visible = false;button2.Visible = false;button4.Visible = false;
			button3.Visible = true;
			textBox4.Text = stu[listBox1.SelectedIndex].Name;
			textBox5.Text = stu[listBox1.SelectedIndex].Date.ToString("dd/MM/yyyy");
			textBox6.Text = stu[listBox1.SelectedIndex].Group.ToString();
			temp = listBox1.SelectedIndex;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			button1.Visible = true; button2.Visible = true; button4.Visible = true;
			button3.Visible = false;

			stu.RemoveAt(temp);
			
			stu.Insert(temp, new Students()
			{
				Name =textBox4.Text,
				Date = DateTime.Parse(textBox5.Text),
				Group = Int32.Parse(textBox6.Text),
				ID = temp,
			});

			DataSourceReset();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedItems.Count > 0)
			{
				stu.RemoveRange(listBox1.SelectedIndex, listBox1.SelectedItems.Count);
				id -= listBox1.SelectedItems.Count;
				DataSourceReset();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			stu.Sort();
			DataSourceReset();
		}
	}
}

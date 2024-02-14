using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Лаб_12
{
    public partial class Form1 : Form
    {
        University Spisok = new University();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// заполнение поля вывода
        /// </summary>
        public void fill()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Spisok.SortBySurname();
                    break;
                case 1:
                    Spisok.SortByHeight();
                    break;
                case 2:
                    Spisok.SortByWeight();
                    break;
            }
            listBox1.Items.Clear();
            listBox1.Items.Add("Фамилия\tГруппа\tВес\tРост");
            foreach (Student student in Spisok)
            {
                listBox1.Items.Add(student);
            }
        }

        /// <summary>
        /// вывод ср. веса и роста
        /// </summary>
        public void show_wtht()
        {

            if (listBox1.Items.Count > 1)
            {
                label6.Text = "Средний рост студентов: " + Math.Round(Spisok.find_avg_ht(), 3);
                label6.Visible = true;
            }
            else
            {
                label6.Visible = false;
            }

            if (listBox1.Items.Count > 1)
            {
                label7.Text = "Средний вес студентов: " + Math.Round(Spisok.find_avg_wt(), 3);
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
            }
        }
        


        /// <summary>
        /// начальные настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            comboBox1.Text = Convert.ToString(comboBox1.Items[0]);
            fill();
        }
        



        /// <summary>
        /// блокировка ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = '\0';
        }

        /// <summary>
        /// проверка ввода (только буквы, без пробелов)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            else e.KeyChar = '\0';
        }

        /// <summary>
        /// проверка ввода (только цифры)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            else e.KeyChar = '\0';
        }

        /// <summary>
        /// проверка ввода (цифры и точка .\\ )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text != "" && ((TextBox)sender).Text.Contains(".") == false)
                return;
            else e.KeyChar = '\0';
        }

        /// <summary>
        /// блокировка кнопки добавить/удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }




        Student cur_student = new Student();

        /// <summary>
        /// "добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                cur_student = new Student(Convert.ToString(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text));
                Spisok.Add(cur_student);
                fill();
                show_wtht();
            }

        }

        /// <summary>
        /// "удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                cur_student = new Student(Convert.ToString(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text));
                Spisok.Remove(cur_student);
                fill();
                show_wtht();
            }
        }




        /// <summary>
        /// вывод при изменении типа сортировки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill();
        }

        /// <summary>
        /// ввод данных о выбранном студенте в поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 0)
            {
                string[] parameters = (Convert.ToString(listBox1.SelectedItem)).Split('\t');
                textBox1.Text = (Convert.ToString(parameters[0]).Split())[0];
                textBox2.Text = parameters[1];
                textBox3.Text = parameters[2];
                textBox4.Text = parameters[3];
            }
        }
    }
}

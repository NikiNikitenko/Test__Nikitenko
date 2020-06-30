using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test__Nikitenko
{

    public partial class Form1 : Form
    {

        public Form1()
        {


            InitializeComponent();
            textBox01_frame_width.Text = "30";
            textBox02_frame_height.Text = "10";
            textBox03_pic_width.Text = "4";
            textBox04_pic_height.Text = "3";
            textBox05_pic_x.Text = "2";
            textBox06_pic_y.Text = "2";

        }

        public void Fill_Textbox(TextBox textbox, int[,] source, int frame_width, int frame_height)
        {
            textbox.Text = "";

            for (int i = 0; i < frame_height; i++)
            {
                for (int j = 0; j < frame_width; j++)
                {
                    //textbox.Text += $"{i}{j}";

                    if (source[i, j] < 10)
                        textbox.Text += $"{source[i, j]}   ";
                    else
                        textbox.Text += $"{source[i, j]} ";

                }
                textbox.Text += "\r\n";
            }
        }

        public int[,] Rand_fill(int[,] arr, int frame_width, int frame_height)
        {
            Random random = new Random();
            for (int i = 0; i < frame_height; i++)
                for (int j = 0; j < frame_width; j++)
                { arr[i, j] = random.Next(0, 99); }
            return arr;
        }


        /// <summary>
        /// Перемещает подмассив внутри массива 
        /// <para><paramref name="frame_width"/>/<paramref name="frame_height"/> - ширина/высота массива </para>
        /// <para><paramref name="pic_width"/>/<paramref name="pic_height"/> - ширина/высота подмассива</para>
        /// <para><paramref name="pic_x"/>/<paramref name="pic_y"/> - X/Y подмассива</para>
        /// <para><paramref name="targer_x"/>/<paramref name="target_y"/> - Куда перенести подмассив(только выше и/или левее)</para>
        /// </summary>

        public int[,] Partial_relocation(int[,] source, int frame_width, int frame_height, int pic_width, int pic_height, int pic_x, int pic_y, int targer_x, int target_y)
        {
            for (int i = 0; i < pic_height; i++)
                for (int j = 0; j < pic_width; j++)
                {
                    source[i, j] = source[i + pic_x, j + pic_y];
                }
            return source;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int frame_width = 4;
            int frame_height = 4;
            int pic_width = 2;
            int pic_height = 2;
            int pic_x = 1;
            int pic_y = 1;
            int targer_x = 0;
            int target_y = 0;

            frame_width = Convert.ToInt32(textBox01_frame_width.Text);
            frame_height = Convert.ToInt32(textBox02_frame_height.Text);
            pic_width = Convert.ToInt32(textBox03_pic_width.Text);
            pic_height = Convert.ToInt32(textBox04_pic_height.Text);
            pic_x = Convert.ToInt32(textBox05_pic_x.Text);
            pic_y = Convert.ToInt32(textBox06_pic_y.Text);


            int[,] source = new int[frame_height, frame_width];

            Rand_fill(source, frame_width, frame_height);
            Fill_Textbox(textBox2, source, frame_width, frame_height);

            source = Partial_relocation(source, frame_width, frame_height, pic_width, pic_height, pic_x, pic_y, targer_x, target_y);

            Fill_Textbox(textBox1, source, frame_width, frame_height);

        }



        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = Prescription(textBox_Part2.Text);
        }

        private void textBox01_frame_width_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox01_frame_width.Text != "")
                    textBox01_frame_width.Text = Convert.ToInt32(textBox01_frame_width.Text) > 50 ? "50" : textBox01_frame_width.Text;
            }
            catch { textBox01_frame_width.Text = ""; }
        }

        private void textBox02_frame_height_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox02_frame_height.Text != "")
                    textBox02_frame_height.Text = Convert.ToInt32(textBox02_frame_height.Text) > 50 ? "50" : textBox02_frame_height.Text;
            }
            catch { textBox02_frame_height.Text = ""; }
        }

        private void textBox03_pic_width_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox03_pic_width.Text != "" & textBox01_frame_width.Text != "")
                    textBox03_pic_width.Text = Convert.ToInt32(textBox03_pic_width.Text) > Convert.ToInt32(textBox01_frame_width.Text) ? textBox01_frame_width.Text : textBox03_pic_width.Text;
            }
            catch { textBox03_pic_width.Text = ""; }
        }

        private void textBox04_pic_height_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox04_pic_height.Text != "" & textBox02_frame_height.Text != "")
                    textBox04_pic_height.Text = Convert.ToInt32(textBox04_pic_height.Text) > Convert.ToInt32(textBox02_frame_height.Text) ? textBox02_frame_height.Text : textBox04_pic_height.Text;
            }
            catch { textBox04_pic_height.Text = ""; }
        }

        private void textBox05_pic_x_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox03_pic_width.Text != "" & textBox01_frame_width.Text != "" & textBox05_pic_x.Text != "")
                    textBox05_pic_x.Text = Convert.ToInt32(textBox05_pic_x.Text) > Convert.ToInt32(textBox01_frame_width.Text) - Convert.ToInt32(textBox03_pic_width.Text) ? $"{Convert.ToInt32(textBox01_frame_width.Text) - Convert.ToInt32(textBox03_pic_width.Text)}" : textBox05_pic_x.Text;
            }
            catch { textBox05_pic_x.Text = ""; }
        }

        private void textBox06_pic_y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox04_pic_height.Text != "" & textBox02_frame_height.Text != "" & textBox06_pic_y.Text != "")
                    textBox06_pic_y.Text = Convert.ToInt32(textBox06_pic_y.Text) > Convert.ToInt32(textBox02_frame_height.Text) - Convert.ToInt32(textBox04_pic_height.Text) ? $"{Convert.ToInt32(textBox02_frame_height.Text) - Convert.ToInt32(textBox04_pic_height.Text)}" : textBox06_pic_y.Text;
            }
            catch { textBox06_pic_y.Text = ""; }
        }

        private void textBox_Part2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Part2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string numbers = ".0123456789";
            int index = textBox_Part2.Text.IndexOf(".");

            if (index > -1)
            {                
               if (Convert.ToInt32( textBox_Part2.Text.Remove(index) )> 1000000000) { textBox_Part2.Text = "1000000000.00"; }
            }



            

            if (!numbers.Contains(e.KeyChar) && e.KeyChar != 8)
            {

                e.Handled = true;
            }
            else
            {
                if (textBox_Part2.Text.Length - index ==3&(e.KeyChar != 8)&index!=-1)
                {
                    e.Handled = true;
                }
                if((textBox_Part2.Text.Length >= 13)&(e.KeyChar != 8)) 
                {
                    e.Handled = true;
                }
                

                if (e.KeyChar != '.' & textBox_Part2.Text.Length>=10& index == -1 && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
                if ((e.KeyChar == '.' & index >= 0) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
                //if ((e.KeyChar != '.'|| e.KeyChar != 8) & textBox_Part2.Text.Length == 10 & index == -1 )
                //{
                //    e.Handled = true;
                //}
            }
            //if ((textBox_Part2.Text.Length == 8 | numbers[0] == e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }
           
            


        }

        public string Prescription(string str)
        {
            string prescription = "";
            string cents = str;
            string dollars = str;
            
            int index = str.IndexOf(".");

            if (index > -1)
            {
                if (str.Length - index < 3) str += "0";
                if (str.Length - index < 3) str += "0";
                cents = str[index + 1].ToString() + str[index + 2].ToString();
                dollars = str.Remove(index);
            }
            string dollars_temp = dollars;




            //while(dollars.Length < 10) 
            //{
            //    dollars = "0" + dollars;
            //}

            while (dollars.Length > 0)
            {
                if (dollars.Length == 10)
                {
                    prescription = "one billion";
                    dollars = dollars.Substring(1);
                }
                else
                {
                    if (dollars.Length < 10 && dollars.Length > 6)
                    {
                        while (dollars.Length < 9)
                            dollars = "0" + dollars;
                        prescription += $"{Hundred(dollars.Remove(3))}";
                        if (Convert.ToInt32(dollars.Remove(3)) > 0)
                            prescription += " million";
                        dollars = dollars.Substring(3);
                    }
                    else
                    {
                        if (dollars.Length < 7 && dollars.Length > 3)
                        {
                            while (dollars.Length < 6)
                                dollars = "0" + dollars;
                            prescription += $"{Hundred(dollars.Remove(3))}";
                            if (Convert.ToInt32(dollars.Remove(3))>0)
                            prescription += " thousand";

                            dollars = dollars.Substring(3);
                        }
                        else
                        {
                            while (dollars.Length < 3)
                                dollars = "0" + dollars;
                            prescription += $"{Hundred(dollars)}";
                            dollars = dollars.Substring(3);
                        }
                    }
                }
            }

           
            if (dollars_temp.Length > 1)
            {
                if (dollars_temp[dollars_temp.Length - 1].ToString() == "1" & (dollars_temp[dollars_temp.Length - 1].ToString() + dollars_temp[dollars_temp.Length - 2].ToString()) != "11")
                    prescription += " dollar";
                else { prescription += " dollars"; }
            }
            else
            {
                if (dollars_temp == "1")
                    prescription += " dollar";
                else { prescription += " dollars"; }
            }



            if (index > -1)
            {
                if (prescription != "") prescription += " ";

                prescription += UpTo99(cents);

                if (cents[1].ToString() == "1" & cents != "11")
                    prescription += " cent";
                else
                {
                    if (cents[0].ToString() == "0" & cents[1].ToString() == "0")
                    {
                    }
                    else
                        prescription += " cents";
                }
            }

            prescription = prescription.Trim();
            return prescription;
        }
        public string Hundred(string hundred)
        {
            string prescription = "";
            if (hundred[0].ToString() != "0")
            {
                prescription += $" {UpTo9(hundred[0].ToString())}";
                prescription += " hundred";
            }
            prescription += $" {UpTo99(hundred.Substring(1))}";
            return prescription;
        }

        public string UpTo99(string upTo99)
        {
            string prescription = "";
            int decade = Convert.ToInt32(upTo99[0].ToString());
            int ones = Convert.ToInt32(upTo99[1].ToString());
            switch (decade)
            {
                case 0:
                    prescription = UpTo9(upTo99[1].ToString());
                    break;
                case 1:
                    prescription = UpTo19(upTo99);
                    break;
                case 2:
                    prescription += ones > 0 ? $"twenty-{UpTo9(upTo99[1].ToString())}" : "twenty";
                    break;
                case 3:
                    prescription += ones > 0 ? $"thirty-{UpTo9(upTo99[1].ToString())}" : "thirty";
                    break;
                case 4:
                    prescription += ones > 0 ? $"forty-{UpTo9(upTo99[1].ToString())}" : "forty";
                    break;
                case 5:
                    prescription += ones > 0 ? $"fifty-{UpTo9(upTo99[1].ToString())}" : "fifty";
                    break;
                case 6:
                    prescription += ones > 0 ? $"sixty-{UpTo9(upTo99[1].ToString())}" : "sixty";
                    break;
                case 7:
                    prescription += ones > 0 ? $"seventy-{UpTo9(upTo99[1].ToString())}" : "seventy";
                    break;
                case 8:
                    prescription += ones > 0 ? $"eighty-{UpTo9(upTo99[1].ToString())}" : "eighty";
                    break;
                case 9:
                    prescription += ones > 0 ? $"ninety-{UpTo9(upTo99[1].ToString())}" : "ninety";
                    break;

                default: break;
            }
            return prescription;
        }
        public string UpTo9(string upTo9)
        {
            string prescription = "";
            int number = Convert.ToInt32(upTo9);
            switch (number)
            {
                case 1:
                    prescription = "one";
                    break;
                case 2:
                    prescription = "two";
                    break;
                case 3:
                    prescription = "three";
                    break;
                case 4:
                    prescription = "four";
                    break;
                case 5:
                    prescription = "five";
                    break;
                case 6:
                    prescription = "six";
                    break;
                case 7:
                    prescription = "seven";
                    break;
                case 8:
                    prescription = "eight";
                    break;
                case 9:
                    prescription = "nine";
                    break;
            }
            return prescription;
        }


        public string UpTo19(string upTo99)
        {
            string prescription = "";
            int number = Convert.ToInt32(upTo99);
            switch (number)
            {
                case 10:
                    prescription = "ten";
                    break;
                case 11:
                    prescription = "eleven";
                    break;
                case 12:
                    prescription = "twelve";
                    break;
                case 13:
                    prescription = "thirteen";
                    break;
                case 14:
                    prescription = "fourteen";
                    break;
                case 15:
                    prescription = "fifteen";
                    break;
                case 16:
                    prescription = "sixteen";
                    break;
                case 17:
                    prescription = "seventeen";
                    break;
                case 18:
                    prescription = "eighteen";
                    break;
                case 19:
                    prescription = "nineteen";
                    break;
            }
            return prescription;
        }
    }
}

using System;
using System.Windows.Forms;

namespace PickLarger
{

    public partial class Form1 : Form
    {
        int[] array1 = new int[100];
        int[] array2 = new int[100];

        Random randNum = new Random();

        int index_counter = 99;
        int correct_guesses = 0;
        int incorrect_guesses = 0;

        const int MAX = 100;


        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = randNum.Next(0, 1000);
            };

            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = randNum.Next(0, 1000);
            };

        }

        private void button3_Click(object sender, EventArgs e)
        {

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;

            if(index_counter >= MAX)
            {


                index_counter = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(array1[index_counter] > array2[index_counter])
            {
                int compared_value1 = array1[index_counter];
                int compared_value2 = array2[index_counter];


                ++correct_guesses;
                label4.Text = Convert.ToString(correct_guesses);
                label8.Text = compared_value1 + " and " + compared_value2;


            }//Button 1 success condition

            if (array2[index_counter] > array1[index_counter])
            {

                int compared_value1 = array1[index_counter];
                int compared_value2 = array2[index_counter];

                ++incorrect_guesses;
                label6.Text = Convert.ToString(incorrect_guesses);
                label8.Text = compared_value1 + " and " + compared_value2;
                

            }//Button 1 fail condition

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button3.Visible = true;

            ++index_counter;
            //label9.Text = Convert.ToString(index_counter);//Uncomment for test of index_counter reset

            if (index_counter > MAX)
            {


                index_counter = 0;
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i] = randNum.Next(0, 1000);
                };

                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i] = randNum.Next(0, 1000);
                };

            }//Reset subscript and redraw arrays so that pattern in guessing does not exist.
        }//Button 1 Click End

        private void button2_Click(object sender, EventArgs e)
        {
            if(array2[index_counter] > array1[index_counter])
            {
                int compared_value1 = array1[index_counter];
                int compared_value2 = array2[index_counter];

                ++correct_guesses;
                label4.Text = Convert.ToString(correct_guesses);
                label8.Text = compared_value1 + " and " + compared_value2;
              
            }//Button 2 success condition

            if(array1[index_counter] > array2[index_counter])
            {
                int compared_value1 = array1[index_counter];
                int compared_value2 = array2[index_counter];

                ++incorrect_guesses;
                label6.Text = Convert.ToString(incorrect_guesses);
                label8.Text = compared_value1 + " and " + compared_value2;
              
            }//Button 2 fail condition

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button3.Visible = true;

            //label9.Text = Convert.ToString(index_counter);//Uncomment for test of index_counter reset
            ++index_counter;

            if(index_counter > MAX)
            {

                index_counter = 0;
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i] = randNum.Next(0, 1000);
                };

                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i] = randNum.Next(0, 1000);
                };

            }//Reset subscript and redraw arrays so that pattern in guessing does not exist.

        }//Button 2 Click End
    }
}

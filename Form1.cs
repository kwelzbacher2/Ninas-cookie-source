//Programmer: Katie Welzbacher
//Date: 5/3/17
//Lab 10 Ch. 12

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinasCookieSource
{
    public partial class Form1 : Form
    {
        //declare variables
        double accumulate;
        public Form1()
        {
            InitializeComponent();

            //add to the ListBox
            this.cookieListBox.Items.AddRange(new Object[]{
                "1/2 dozen",
                "1 dozen",
                "2 dozen",
                "3 dozen"
            });
            //set the minimum calendar date to today
            monthCalendar1.MinDate = DateTime.Today;
            deliveryLabel.Text = "Cookies delivered on: " + monthCalendar1.SelectionStart.AddDays(3).ToShortDateString();

            //create event handler for when radio button is changed
            chocoChipRadioButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            oatmealRadioButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            waferRadioButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            cookieListBox.SelectedIndexChanged += new EventHandler(radioButtons_CheckedChanged);

        }

        //calculate the price when buy button clicked
        private void buyButton_Click(object sender, EventArgs e)
        {
            //declare variables
            double price=0;

            //try and catch exceptions
            try
            {
                if ((chocoChipRadioButton.Checked == false) && (oatmealRadioButton.Checked == false) && (waferRadioButton.Checked == false))
                {
                    throw new ArgumentException();
                }
                try
                    {
                        if (cookieListBox.SelectedIndex == -1) throw new ArgumentException();
                        //give price based on what items chosen
                        if (oatmealRadioButton.Checked == true)
                        {


                            if (cookieListBox.SelectedIndex == 0)
                            {
                                price = 3.49;
                            }
                            else if (cookieListBox.SelectedIndex == 1)
                            {
                                price = 6.98;
                            }
                            else if (cookieListBox.SelectedIndex == 2)
                            {
                                price = 13.96;
                            }
                            else
                            {
                                price = 20.94;
                            }
                        }
                        else if (chocoChipRadioButton.Checked == true)
                        {


                            if (cookieListBox.SelectedIndex == 0)
                            {
                                price = 4.49;
                            }
                            else if (cookieListBox.SelectedIndex == 1)
                            {
                                price = 8.98;
                            }
                            else if (cookieListBox.SelectedIndex == 2)
                            {
                                price = 17.96;
                            }
                            else
                            {
                                price = 26.94;
                            }
                        }
                        else
                        {
                            if (cookieListBox.SelectedIndex == 0)
                            {
                                price = 3.24;
                            }
                            else if (cookieListBox.SelectedIndex == 1)
                            {
                                price = 6.48;
                            }
                            else if (cookieListBox.SelectedIndex == 2)
                            {
                                price = 12.96;
                            }
                            else
                            {
                                price = 19.44;
                            }

                        }
                        //display price and calculate accumulate
                        cookieTextBox.Text = price.ToString("c");
                        accumulate += price;
                        accumulateTextBox.Text = accumulate.ToString("c");
                    }
                    catch (ArgumentException iee)
                    {
                        MessageBox.Show("Choose a quantity of cookies.", "Missing purchase detail.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
            } catch (ArgumentException ie)
            {
                MessageBox.Show("Choose a type of cookie.", "Missing purchase detail.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        // show the delivery date on the label
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            const int DAYS_TO_ADD = 3;
            deliveryLabel.Text = "Cookies delivered on: " + monthCalendar1.SelectionStart.AddDays(DAYS_TO_ADD).ToShortDateString();
        }

        //clear the price textbox when different button chosen
        private void radioButtons_CheckedChanged (object sender, EventArgs e)
        {
            cookieTextBox.Clear();
        }

        //close the form
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //clear the form
        private void clearButton_Click(object sender, EventArgs e)
        {
            cookieTextBox.Clear();
            accumulateTextBox.Clear();
            cookieListBox.SelectedIndex = -1;
            chocoChipRadioButton.Checked = false;
            oatmealRadioButton.Checked = false;
            waferRadioButton.Checked = false;
            monthCalendar1.ShowToday = true;
            deliveryLabel.Text = "Cookies delivered on: " + DateTime.Today.AddDays(3).ToShortDateString();

        }

       
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

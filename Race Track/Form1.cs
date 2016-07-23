using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_Track
{
    public partial class Form1 : Form
    {
        Guy[] guy= new Guy[3];
        Guy currentBettor;
        Greyhound[] GreyhoundArray = new Greyhound[4];
        public Form1()
        {
            InitializeComponent();
            UpdateMinBetLabel();

            joeRadioButton.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            bobRadioButton.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            alRadioButton.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);

            guy[0] = new Guy() { Name = "Joe", Cash = 50, MyLabel = joeBetLabel, MyRadioButton = joeRadioButton };
            guy[2] = new Guy() { Name = "Al", Cash = 45, MyLabel = alBetLabel, MyRadioButton = alRadioButton };
            guy[1] = new Guy() { Name = "Bob", Cash = 75, MyLabel = bobBetLabel, MyRadioButton = bobRadioButton };

            guy[0].UpdateLabel();
            guy[1].UpdateLabel();
            guy[2].UpdateLabel();

            currentBettor = guy[0];

            GreyhoundArray[0] = new Greyhound() { MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width
                 };

            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width
            };

            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width
            };

            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width
            };

        }

        private void UpdateMinBetLabel()
        {
            minimumBetLabel.Text = "Minimum bet: " + numericUpDown1.Value + "bucks";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool stop = false;
            foreach (Greyhound dog in GreyhoundArray)
            {
                if (dog.Run() && !stop )
                {
                    timer1.Stop();
                    stop = true;
                    // We have a winner!
                    int winningDog = Array.IndexOf(GreyhoundArray,dog)+ 1;
                    // Showing mesage who won
                    MessageBox.Show("Dog #" + winningDog + " won the race!", "We have a winner", MessageBoxButtons.OK);
                    // Each guy collects his winnings
                    foreach (Guy g in guy)
                    {
                        g.Collect(winningDog);
                        g.UpdateLabel();
                    }

                    
                }
            }
        }

        public void ErrorConsole(string Message)
        {
            MessageBox.Show(Message);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked == true)
            {
                nameLabel.Text = guy[0].Name;
                currentBettor = guy[0];
            }
            else if(bobRadioButton.Checked == true)
            {
                nameLabel.Text = guy[1].Name;
                currentBettor = guy[1];
            }
            else if(alRadioButton.Checked == true)
            {
                nameLabel.Text = guy[2].Name;
                currentBettor = guy[2];
            }
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            for (int k =0; k < 4; k++)
            {
                GreyhoundArray[k].TakeStartingPosition();
            }
            timer1.Start();
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                currentBettor.PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                currentBettor.UpdateLabel();
            }
            else
            {
                ErrorConsole("Enter a valid amount to bet");
            }
        }
    }
}

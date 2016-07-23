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
    public class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer = new Random();

        public bool Run()
        {
            Randomizer = new Random();
            int distance = Randomizer.Next(8, 16);

            MoveMyPictureBox(distance);

            Location += distance;
            if (Location >= (RacetrackLength - StartingPosition))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            MoveMyPictureBox(-Location);
            Location = 0;
        }

        public void MoveMyPictureBox(int distance)
        {
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;
        }
    }
}

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
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Bettor.Cash >= Amount)
                return Bettor.Name + " bets " + " $" + Amount + " on Dog #" + Dog;
            else if (Bettor.Cash < Amount)
            {
                MessageBox.Show("Not enough cash on " + Bettor.Name);
                return Bettor.Name + "hasn't placed a bet";
            }
            else
                return Bettor.Name + "hasn't placed a bet";
        }

        public int PayOut(int Winner)
        {
            if (Winner == Dog)
                return Amount;
            else
                return (Amount * -1);
        }
    }
}

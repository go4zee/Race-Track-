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
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;


        public void UpdateLabel()
        {
            MyRadioButton.Text = Name + "has " + Cash + " bucks";
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
            UpdateLabel();
            MyLabel.Text = MyBet.GetDescription();
            return true;
        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
            UpdateLabel();
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
        }
    }
}

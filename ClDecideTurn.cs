using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    internal class ClDecideTurn 
    {
        protected enum enPlayerTurn
        {
            enPlyaer1,
            enPlayer2,
            enNoPlayersYet
        }

        Form1 frmGame;


        protected enPlayerTurn DecidePlayers()
        {

            List<Button> ChoiceButtons = new List<Button>();

            for (int i = 1; i <= 9; i++)
            {
                ChoiceButtons.Add(frmGame.Controls["button" +i] as Button);
            }

           
            if (ChoiceButtons.Any(b => b.Text != ""))
            {
                 return enPlayerTurn.enPlyaer1;

            }
            return enPlayerTurn.enNoPlayersYet;

        }

        void show_players()
        {
            if (DecidePlayers() == enPlayerTurn.enPlyaer1)
            {
                
            }


        }


        
    }








    
}

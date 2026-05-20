using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;
using static Tic_Tac_Toe_Game.Form1;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enPlyerTurn PlyerTurn = enPlyerTurn.Player1;
        
        
        public enum enPlyerTurn
        {
            Player1,Player2
        }
        public enum enWinner
        {
            Player1, Player2 ,Draw,Inprogress
        }
        public struct stGameStatus
        {
            public enWinner Winner;
            public short PlayCount;
            public bool GameOver;
        }


        public bool CheckCasesOfWins(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn2.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.YellowGreen;
                btn2.BackColor = Color.YellowGreen;
                btn3.BackColor = Color.YellowGreen;

               if (btn1.Tag.ToString()=="X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    MessageBox.Show("Game Over", "Game Over",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            else
            {
                GameStatus.GameOver = false;
                return false;
            }
        }

        public bool CheckWinner()
        {

            if (CheckCasesOfWins(button1, button2, button3))
            {
                return true;
            }

            if (CheckCasesOfWins(button4, button5, button6))
            {
                return true;
            }

            if (CheckCasesOfWins(button7, button8, button9))
            {
                return true;
            }

            if (CheckCasesOfWins(button1, button4, button7))
            {
                return true;
            }

            if (CheckCasesOfWins(button2, button5, button8))
            {
                return true;
            }

            if (CheckCasesOfWins(button3, button6, button9))
            {
                return true;
            }

            if (CheckCasesOfWins(button1, button5, button9))
            {
                return true;
            }

            if (CheckCasesOfWins(button3, button5, button7))
            {
                return true;
            }


            return false;
        }

        public void EndGame()
        {
            lblPlayerTurn.Text = "Game Over";
           
            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinnerName.Text = "Player1";
                    break;

                case enWinner.Player2:
                    lblWinnerName.Text = "Player2";
                    break;

                default:
                    lblWinnerName.Text = "Draw";
                    break;
            }
        }

        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlyerTurn)
                {
                    case enPlyerTurn.Player1: 
                        btn.Tag= "X";
                        btn.BackgroundImage = Resources.X;
                        PlyerTurn = enPlyerTurn.Player2;
                        lblPlayerTurn.Text = "Player2";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;

                    case enPlyerTurn.Player2:
                        btn.Tag = "O";
                        btn.BackgroundImage = Resources.O;
                        PlyerTurn = enPlyerTurn.Player1;
                        lblPlayerTurn.Text = "Player1";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Warrning" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                EndGame();
            }

        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color white = Color.FromArgb(255, 255, 255, 255);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

        public void ResetButtons(Button btn)
        {
            btn.Tag = "?";
            btn.BackgroundImage = Resources.question_mark_96;
            btn.BackColor = Color.Transparent;
        }


        public void ResetGame()
        {
            ResetButtons(button1);
            ResetButtons(button2);
            ResetButtons(button3);
            ResetButtons(button4);
            ResetButtons(button5);
            ResetButtons(button6);
            ResetButtons(button7);
            ResetButtons(button8);
            ResetButtons(button9);

            GameStatus.Winner = enWinner.Inprogress;
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            PlyerTurn = enPlyerTurn.Player1;
            lblWinnerName.Text = "InProgress";
            lblPlayerTurn.Text = "Player1";
        
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

    }
}


















using ST10081800_PROG7312_POE.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.IO;

namespace ST10081800_PROG7312_POE
{
    public partial class Game : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private List<Button> btnList = new List<Button>();
        private Button btn = null;
        Book obj = new Book();
        List<string> callNumbers = Book.GenerateCallNumbers();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Game()
        {
            InitializeComponent();

            btnList.Add(button1);
            btnList.Add(button2);
            btnList.Add(button3);
            btnList.Add(button4);
            btnList.Add(button5);
            btnList.Add(button6);
            btnList.Add(button7);
            btnList.Add(button8);
            btnList.Add(button9);
            btnList.Add(button10);

            foreach(var element in btnList)
            {
                element.MouseDown += Button_MouseDown;
                element.DragEnter += Button_DragEnter;
                element.DragDrop += Button_DragDrop;
                element.AllowDrop = true;
            }
        }

        #region
        /// <summary>
        /// Swapping books between positions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            btn = sender as Button;
            btn.DoDragDrop(btn, DragDropEffects.Move);
        }
        #endregion

        #region
        /// <summary>
        /// Using drag enter for the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DragEnter(object sender,DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Button)) && sender != e.Data.GetData(typeof(Button)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion

        #region
        /// <summary>
        /// Allow drag and drop for buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DragDrop(object sender, DragEventArgs e)
        {
            Button btns = sender as Button;

            if (btns == null)
            
                return;
            //setting destination location for books
            if(e.Data.GetData(typeof(Button)) is Button btn)
            {
                Point destination = btn.Location;
                btn.Location = btns.Location;
                btns.Location = destination;
                int locationCount = btnList.IndexOf(btn);
                int newLocation = btnList.IndexOf(btns);
                btnList[locationCount] = btns;
                btnList[newLocation] = btn;
            }  
        }
        #endregion

        #region
        /// <summary>
        /// Method to display call numbers when button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateCallNumbersBtn_Click(object sender, EventArgs e)
        {
            checkOrderBtn.Visible = true;
            generateCallNumbersBtn.Visible = false;
            
            for(int i=0; i<btnList.Count; i++)
            {
                btnList[(i)].Text = Book.GenerateCallNumbers()[i].ToString();
            }        
        }
        #endregion

        #region
        /// <summary>
        /// To close an application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region
        /// <summary>
        /// Checking if call numbers are sorted in ascending order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkOrderBtn_Click(object sender, EventArgs e)
        {
            string mp4Path = Application.StartupPath + "\\Resources\\winning_sound.mp4";
            string binPath = Application.StartupPath + "\\winning_sound.mp4";
            File.WriteAllBytes(binPath, Properties.Resources.winning_sound);
            
            if (isCorrect())
            {       
                mediaPlayer.URL = binPath;
                mediaPlayer.uiMode = "full";
                player.controls.play();
                checkOrderBtn.Visible = false;
                mediaPlayer.Visible = true;
                MessageBox.Show("Congratulations, you have won the game!");
            }
            else
            {
                MessageBox.Show("You have lost the game, retry ):");
            }
        }
        #endregion

        #region
        /// <summary>
        /// To compare if numbers are in order
        /// </summary>
        /// <returns></returns>
        private bool isCorrect()
        {
            for (int i = 0; i < btnList.Count - 1; i++)
            {
                if (string.Compare(btnList[i].Text, btnList[i + 1].Text) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
//////////////////////////////// END OF CLASS ////////////////////////////////

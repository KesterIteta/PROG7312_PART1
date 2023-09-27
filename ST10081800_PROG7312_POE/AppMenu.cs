using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ST10081800_PROG7312_POE
{
    public partial class AppMenu : Form
    {
        public AppMenu()
        {
            InitializeComponent();
        }

        Game gameHere = new Game();
        #region
        /// <summary>
        /// To close an application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBtn1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region
        /// <summary>
        /// Menu option to select either to replace books,
        /// identify books, or finding call numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (bookReplacementBtn.Checked)
            {
                gameHere.ShowDialog();
            }
            else if (identifyAreaBtn.Checked)
            {
                MessageBox.Show("Wrong selection, select book replacement above");
            }
            else if (findingCallNumbersBtn.Checked)
            {
                MessageBox.Show("Wrong selection, select book replacement above ):");
            }
            else
            {
                MessageBox.Show("You have not made selection.");
            }
        }
        #endregion
    }
}
///////////////////////////////////// END OF CLASS /////////////////////////////////////

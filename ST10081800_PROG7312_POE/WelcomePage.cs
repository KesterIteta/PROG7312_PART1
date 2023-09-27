using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST10081800_PROG7312_POE
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
            progressBar.Value = 0;
        }
        #region
        /// <summary>
        /// Closing an application
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
        /// Button used to launch an application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void launchAppBtn_Click(object sender, EventArgs e)
        {
            AppMenu appMenuHere = new AppMenu();
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(1);
                progressBar.Value = i;
                progressBar.Update();
            }
            appMenuHere.ShowDialog();
        }
        #endregion

        #region
        /// <summary>
        /// Setting progress bar value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WelcomePage_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
        }
        #endregion

        private void WelcomePage_Load(object sender, EventArgs e)
        {

        }
        #region
        /// <summary>
        /// Using timer progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //https://www.c-sharpcorner.com/article/custom-progress-bar-in-splash-screen-using-c-sharp/
            progressBar.Value += 1; //increment the value of the progressbar by +1
            progressBar.Text = progressBar.Value.ToString() + "%";
            if (progressBar.Value == 100)
            {
                timer1.Enabled = false;
                // create the object of of login
                AppMenu appMenuHere = new AppMenu(); 
                appMenuHere.Show();
                // to hide this screen
                this.Hide(); 
            }   
        }
        #endregion
    }
}
////////////////////////////////// END OF CLASS //////////////////////////////////

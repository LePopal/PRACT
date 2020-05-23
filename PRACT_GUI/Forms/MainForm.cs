using PRACT.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRACT_GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.Text = Application.ProductName;

            InitializeComponent();

            this.ttipMainform.AutoPopDelay = 5000;
            this.ttipMainform.InitialDelay = 1000;
            this.ttipMainform.ReshowDelay = 500;
            this.ttipMainform.ShowAlways = true;

            openRekordboxXML.InitialDirectory = ProgramSettings.InputFolder;

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

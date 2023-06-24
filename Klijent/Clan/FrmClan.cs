using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Clan
{
    public partial class FrmClan : Form
    {
        public FrmClan()
        {
            InitializeComponent();
        }

        internal void SetPanel(UserControl userControl)
        {
            panel1.Controls.Clear();
            userControl.Parent = panel1;
            userControl.Dock = DockStyle.Fill;
        }

    }
}

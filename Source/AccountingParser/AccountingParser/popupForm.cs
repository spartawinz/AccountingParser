using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingParser
{
    public partial class popupForm : Form
    {
        public popupForm()
        {
            InitializeComponent();
        }

        private void PopupOKBttn_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }
    }
}

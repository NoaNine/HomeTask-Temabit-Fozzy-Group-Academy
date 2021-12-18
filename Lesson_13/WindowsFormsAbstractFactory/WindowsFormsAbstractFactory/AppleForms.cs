using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAbstractFactory
{
    public partial class AppleForms : Form
    {
        AbstractWidgetFactory widgetFactory = null;
        UserControlClient userControlClient = null;

        public AppleForms()
        {
            this.widgetFactory = new AppleWidgetFactory();
            InitializeComponent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace devDesarrollo.cache
{
    public static class Ui
    {
      public  static void clearTextBoxs(Control.ControlCollection owner)
        {
               foreach(Control element in owner)
            {
                if(element is TextBox)
                {
                    element.Text = "";
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarbideWebApp
{
    public partial class demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Attributes.Add("onkeypress", "return controlEnter('" + TextBox2.ClientID + "', event)");

            TextBox2.Attributes.Add("onkeypress", "return controlEnter('" + TextBox3.ClientID + "', event)");

            TextBox3.Attributes.Add("onkeypress", "return controlEnter('" + TextBox4.ClientID + "', event)");

            TextBox4.Attributes.Add("onkeypress", "return controlEnter('" + TextBox5.ClientID + "', event)");

            TextBox5.Attributes.Add("onkeypress", "return controlEnter('" + TextBox1.ClientID + "', event)");
        }
    }
}
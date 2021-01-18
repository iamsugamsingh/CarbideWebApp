using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarbideWebApp
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aws1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/carbideEnquiry.aspx?location=1");
        }

        protected void aws2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/carbideEnquiry.aspx?location=2");
        }

        protected void orderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/carbideOrder.aspx");
        }

        protected void recieveBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/carbideReceive.aspx");
        }
    }
}
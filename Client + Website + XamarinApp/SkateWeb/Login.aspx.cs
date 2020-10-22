using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string uname = this.username.Text;
        string pass = this.password.Text;
        Service1Client host = new Service1Client();
        Person p = host.LogIn(uname, pass);
        if (p == null)
        { label1.Text = "error"; }
        else
        {
            Session["u"] = p;
            Response.Redirect("CommentsPage.aspx");  // goto page...
        }
    }
   
}


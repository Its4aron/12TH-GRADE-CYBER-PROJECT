using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class CommentsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Service1Client host = new Service1Client();
        if (!this.IsPostBack)
        {
            Person p = new Person();
            p = Session["u"] as Person;
            CommentsList l =  host.SelectCbyP(p);
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = l;
            GridView1.DataBind();
        
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
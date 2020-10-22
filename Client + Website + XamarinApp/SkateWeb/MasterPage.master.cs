using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected string menu;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["u"]==null)
        {
            menu = menu;
        }
        else
        {
            menu = menu + "<a href='CommentsPage.aspx'>Comments</a><br/>";
            menu = menu + "<a href='LocationPage.aspx'>Locations</a><br/>";
            menu = menu + "<a href='Logout.aspx'>Logout</a><br/>";
            menu = menu + "<button width='40%' font-size='140' text='TestButton' ID='label1' OnClick='test'></button>";
             
        }
        ////http://www.google.com/maps/place/lat,lng
    }
  

}

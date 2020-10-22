using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class LocationPage : System.Web.UI.Page
{
    Service1Client host;
    LocationList list;
    protected void Page_Load(object sender, EventArgs e)
    {
         host = new Service1Client();
        if (!this.IsPostBack)
        {
            Person p = Session["u"] as Person;
            list = host.SelectAllL();
            Session["listL"] = list;
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        else
        {
            list =Session["listL"] as LocationList;
        }
    }
    void CustomersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MAP")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Location loc = list.Find(l => l.ID == id);
            double lat = loc.Altitude;
            double lng = loc.Longitude;
            string url = @"http://www.google.com/maps/place/" + lat + "," + lng;
            Response.Redirect(url);
        }
    }
    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        Location loc = list.Find(l => l.ID == id);
        double lat = loc.Altitude;
        double lng = loc.Longitude;
        string url = @"http://www.google.com/maps/place/" + lat + "," + lng;
        Response.Redirect(url);
    }
}
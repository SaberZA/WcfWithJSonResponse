using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using SalesServiceHost.SaleServiceReference;
using SalesServiceHost.Common;
using SalesServiceHost.ServiceReference1;
using SaleClassLibrary;


namespace SalesServiceHost
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SaleServiceClient proxy;
        protected string JsonResponse { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                proxy = new SaleServiceClient();

                GridView1.DataSource = proxy.GetAllCustomer();
                GridView1.DataBind();
            }
            proxy = new SaleServiceClient();
            JsonResponse = proxy.GetRottenTomatoesMovieInfo("http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=8rnf67ztabgzkyfgekzptazj&q=Toy+Story+3");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            proxy = new SaleServiceClient();
            Customer objcust =
            new Customer()
            {
                CustomerId = 5,
                CustomerName = TextBox1.Text,
                Address = TextBox2.Text,
                Email = TextBox3.Text
            };

            proxy.InsertCustomer(objcust);

            GridView1.DataSource = proxy.GetAllCustomer();
            GridView1.DataBind();
            Label1.Text = "Record Saved Successfully";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex]
                .Values["CustomerId"].ToString());
            proxy = new SaleServiceClient();

            bool check = proxy.DeleteCustomer(userid);
            Label1.Text = "Record Deleted Successfully";
            GridView1.DataSource = proxy.GetAllCustomer();
            GridView1.DataBind();
        }
    }
}
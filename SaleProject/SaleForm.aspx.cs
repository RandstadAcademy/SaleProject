using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaleProject.ServiceClient;

namespace SaleProject
{
    public partial class SaleForm : System.Web.UI.Page
    {
        SaleServiceClient _proxy;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _proxy = new SaleServiceClient();
                GridView1.DataSource = _proxy.GetAllCustomer();
                GridView1.DataBind();
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            _proxy = new SaleServiceClient();
            Customer objcust = new Customer()
            {
                CustomerID = 5,
                CustomerName = TextBox.Text,
                Address = TextBox2.Text,
                EmailId = TextBox3.Text
            };

            _proxy.InsertCustomer(objcust);
            GridView1.DataSource = _proxy.GetAllCustomer();
            GridView1.DataBind();
            Label1.Text = "Record Saved Succesfully";


        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["CustomerID"].ToString());

            _proxy = new SaleServiceClient();


            bool check = _proxy.DeleteCustomer(userid);
            Label1.Text = "Deleted Succesfully";
            GridView1.DataSource = _proxy.GetAllCustomer();
            GridView1.DataBind();

        }


    }
}
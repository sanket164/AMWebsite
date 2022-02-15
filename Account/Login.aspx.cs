using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        DataTable dtLoginDetails = new DataTable();
        try
        {
            lblErrmsg.Attributes.Add("style", "display:none");
            string UserName = Convert.ToString(txtEmail_login.Text);
            string Password = Convert.ToString(txtPassword_login.Text);
            DataSet ds = objdb.ExecuteDataset("CheckAdminLogin", UserName, Password);
            dtLoginDetails = ds.Tables[0];
            if (dtLoginDetails.Rows.Count > 0)
            {
                Session["LoginCode"] = Convert.ToString(dtLoginDetails.Rows[0]["UserName"]);
                Response.Redirect("/Account/DeletePhotos");
            }
            else
            {
                lblErrmsg.Attributes.Add("style", "display:block");
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}
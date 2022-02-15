using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmitQuery_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtQueryEmail.Text != "" && txtQueryMessage.Text.Trim() != "" && txtQueryMobNo.Text.Trim() != "" && txtQueryName.Text.Trim() != "")
            {
                UD_Global objGlobal = new UD_Global();
                objGlobal.SaveQueryBox(txtQueryName.Text.Trim(), txtQueryEmail.Text.Trim(), txtQueryMobNo.Text.Trim(), txtQueryMessage.Text.Trim());
                txtQueryName.Text = "";
                txtQueryMobNo.Text = "";
                txtQueryMessage.Text = "";
                txtQueryEmail.Text = "";
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
}
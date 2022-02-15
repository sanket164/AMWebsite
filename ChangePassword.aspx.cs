using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    dbInteraction objDb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["MemberCode"] == null)
            {
                Response.Redirect("/Default");
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
    protected void lnkbtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblErrorMessage.Visible = false;
            if (Session["MemberCode"] == null)
            {
                Response.Redirect("/Default");
            }
            else
            {
                long MemberCode = 0;
                MemberCode = Convert.ToInt64(Session["MemberCode"]);
                string strSql = "SELECT EmailID FROM tbl_MemberMaster WHERE MemberCode=" + MemberCode;
                string Email = Convert.ToString(objDb.ExecuteScalar(strSql));
                string isValid = objGlobal.ChangePassword(MemberCode, Email, txtPassword.Text.Trim(), txtNewPassword.Text.Trim());
                if (isValid == "Invalid Old Password!")
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = isValid;
                }
                else if (isValid == "success")
                {
                    Response.Redirect("/Default");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    dbInteraction objDb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();
    long MemberCode = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["guid"] != null && Request["token"] != null)
            {
                CurrentPassword.Visible = false;
                RequiredFieldValidator1.Enabled = false;
                string tokan = Request["token"];
                string email = Request["guid"];
                if (objGlobal.DecodeToken(tokan, 12))
                {
                    string strSql = "SELECT MemberCode FROM tbl_MemberMaster WHERE EmailID='" + objGlobal.Decrypt(email) + "'";
                    MemberCode = Convert.ToInt32(objDb.ExecuteScalar(strSql));
                    if (MemberCode == 0)
                    {
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = "Something went wrong with reset password link, You will be redirect to forgot password page.";
                        Thread.Sleep(1000);
                        Response.Redirect("/ForgotPassword");
                    }
                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Your reset password link is expired, You will be redirect to forgot password page.";
                    Thread.Sleep(1000);
                    Response.Redirect("/ForgotPassword");
                }
            }
            else if (Session["MemberCode"] == null)
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
            if (Session["MemberCode"] == null && MemberCode == 0)
            {
                Response.Redirect("/Default");
            }
            else
            {
                if (MemberCode == 0)
                {
                    MemberCode = Convert.ToInt64(Session["MemberCode"]);
                }

                string strSql = "SELECT EmailID FROM tbl_MemberMaster WHERE MemberCode=" + MemberCode;
                string Email = Convert.ToString(objDb.ExecuteScalar(strSql));
                string isValid = "";
                if (Request["guid"] != "" && Request["token"] != "")
                {
                    isValid = objGlobal.ChangePassword(MemberCode, Email, txtPassword.Text.Trim(), txtNewPassword.Text.Trim(), 1);
                }
                else
                {
                    isValid = objGlobal.ChangePassword(MemberCode, Email, txtPassword.Text.Trim(), txtNewPassword.Text.Trim(), 0);
                }

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
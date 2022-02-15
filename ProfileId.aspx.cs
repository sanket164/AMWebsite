using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileId : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["MemberCode"] == null)
            {
                Response.Redirect("/Default");
            }
            else
            {
                if (txtProfileId.Text != "")
                {
                    int s_memberCode = 0;

                    string val = txtProfileId.Text;
                    DataTable dtMemberList = objGlobal.SearchMemberDetails("ProfileID", val);
                    if (dtMemberList.Rows.Count > 0)
                    {
                        ////0= Male, 1=Female
                        if (Convert.ToString(Session["Gender"]) != Convert.ToString(dtMemberList.Rows[0]["Gender"]))
                        {
                            s_memberCode = Convert.ToInt32(dtMemberList.Rows[0]["MemberCode"]);
                            Response.Redirect("/MemberDetails?M_id=" + s_memberCode + "&P_Id=" + val);    
                        }
                        else
                        {
                            if (Convert.ToString(dtMemberList.Rows[0]["Gender"])=="1")
                            {
                                lblMessage.Text = "You cannot search Bride profile";    
                            }
                            else
                            {
                                lblMessage.Text = "You cannot search Groom profile";
                            }
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Profile Id not Found";
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

}
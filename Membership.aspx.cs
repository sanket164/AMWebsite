using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Membership : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    dbInteraction objDb = new dbInteraction();

    string StrSql = "";
    int MemberDays = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MemberCode"] == null)
            {
                Response.Redirect("/Default");
            }
            if (Session["MemberCode"] != null)
            {
                long MemberCode = Convert.ToInt64(Session["MemberCode"]);
                MemberDays = objGlobal.CheckIsYetMember(MemberCode);
                GetMembershipDetails();
            }
        }
    }

    public void GetMembershipDetails()
    {
        try
        {
            StrSql = " select pmd.Membership_name,pmd.Remark as Membership_Remark,pm.Remark ";
            StrSql += " from tbl_Package pm";
            StrSql += " inner join tbl_Package_Details pmd on pm.Package_Id= pmd.Package_Id";
            StrSql += " where pm.IsDefault=1 ";
            DataTable dtDetails = objDb.GetDataTable(StrSql);
            string strHtml = "";
            if (dtDetails.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                {
                    if (cnt == 1)
                    {
                        strHtml += "<p style='margin-top:27px;'><i class='fas fa-check'></i> " + Convert.ToString(dtDetails.Rows[cnt]["Membership_name"]);
                    }
                    else
                    {
                        strHtml += "<p><i class='fas fa-check'></i> " + Convert.ToString(dtDetails.Rows[cnt]["Membership_name"]);
                    }
                    
                    if (Convert.ToString(dtDetails.Rows[cnt]["Membership_Remark"]) == "Recommanded")
                    {
                        strHtml += "<i><img class='img' width='120px' height='44px' style='display:inline-block' src='images/Recommended.png' /></i>";
                    }
                    strHtml += "</p>";
                }
                strHtml += "<p style='text-align: center;'>" + Convert.ToString(dtDetails.Rows[0]["Remark"]) + "</p>";
            }
            ltrBodySection.Text = strHtml;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
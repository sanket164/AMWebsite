using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class PackageSelection : System.Web.UI.Page
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
            StrSql = " select pmd.Membership_name,pmd.Remark as Membership_Remark,pm.Remark,pmd.Amount ";
            StrSql += " from tbl_Package pm";
            StrSql += " inner join tbl_Package_Details pmd on pm.Package_Id= pmd.Package_Id";
            StrSql += " where pm.IsDefault=1 ";
            DataTable dtDetails = objDb.GetDataTable(StrSql);
            string strHtml = "";
            if (dtDetails.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                {
                    strHtml += " <div class=col-md-3 col-lg-3> ";
                    strHtml += " <div class=item> ";
                    strHtml += " <div class=heading> ";
                    strHtml += " <h3>" + Convert.ToString(dtDetails.Rows[cnt]["Membership_name"]) + "</h3> ";
                    strHtml += " </div>";
                    strHtml += " <div class=features> ";
                    strHtml += " <h4><span class=feature>Duration</span> : <span class=value>" + Convert.ToString(dtDetails.Rows[cnt]["Membership_name"]) + "</span></h4> ";
                    strHtml += " <h4><span class=feature>" + Convert.ToString(dtDetails.Rows[0]["Remark"]) + "</span></h4> ";
                    strHtml += " </div> ";
                    strHtml += " <div class=price> ";
                    strHtml += " <h4>" + Convert.ToString(dtDetails.Rows[cnt]["Amount"]) + "/-</h4> ";
                    strHtml += " </div> ";
                    strHtml += " <div class='features'>";
                    strHtml += " <button class='btn btn-block btn-outline-primary' type='submit' onclick='CheckOut(1)'>BUY NOW</button> ";
                    //strHtml += " <asp:Button ID='btnBuy" + Convert.ToString(dtDetails.Rows[cnt]["Package_Id"]) + "' runat='server' Text='BUY NOW' class='btn btn-block btn-outline-primary' />";
                    strHtml += " </div> ";
                    strHtml += " </div> ";
                    strHtml += " </div>";
                }
                //strHtml += "<p style='text-align: center;'>" + Convert.ToString(dtDetails.Rows[0]["Remark"]) + "</p>";
            }
            ltrBodySection.Text = strHtml;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [WebMethod]
    public static void CheckOutPackage(string PackageId, string MemberCode)
    {
        try
        {
            string sql = " select pmd.Amount ";
            sql += " from tbl_Package pm ";
            sql += " inner join tbl_Package_Details pmd on pm.Package_Id= pmd.Package_Id ";
            sql += " where pm.IsDefault=1 and pmd.Package_Details_Id=" + PackageId;
            dbInteraction objDb = new dbInteraction();
            DataTable dt = objDb.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                sql = " select * from tbl_MemberMaster where MemberCode=" + MemberCode;
                DataTable dtMember = objDb.GetDataTable(sql);
                if (dtMember.Rows.Count > 0)
                {

                    //string amount = Convert.ToString(dt.Rows[0]["Amount"]);
                    //string ord = "1";
                    //string cus = MemberCode;
                    //string email = TextBox3.Text;
                    //string phone = TextBox4.Text;
                    //string am = amount;
                    //String merchantKey = "your merchant key";
                    //Dictionary<string, string> parameters = new Dictionary<string, string>();
                    //parameters.Add("MID", "your mechant id");
                    //parameters.Add("CHANNEL_ID", "WEB");
                    //parameters.Add("INDUSTRY_TYPE_ID", "Retail");
                    //parameters.Add("WEBSITE", "WEBSTAGING");
                    //parameters.Add("EMAIL", email);
                    //parameters.Add("MOBILE_NO", phone);
                    //parameters.Add("CUST_ID", cus);
                    //parameters.Add("ORDER_ID", ord);
                    //parameters.Add("TXN_AMOUNT", am);
                    //parameters.Add("CALLBACK_URL", ""); //This parameter is not mandatory. Use this to pass the callback url dynamically.

                    //string checksum = paytm.CheckSum.generateCheckSum(merchantKey, parameters);
                    //string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction?orderid=";

                    //string outputHTML = "<html>";
                    //outputHTML += "<head>";
                    //outputHTML += "<title>Merchant Check Out Page</title>";
                    //outputHTML += "</head>";
                    //outputHTML += "<body>";
                    //outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
                    //outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
                    //outputHTML += "<table border='1'>";
                    //outputHTML += "<tbody>";
                    //foreach (string key in parameters.Keys)
                    //{
                    //    outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
                    //}
                    //outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
                    //outputHTML += "</tbody>";
                    //outputHTML += "</table>";
                    //outputHTML += "<script type='text/javascript'>";
                    //outputHTML += "document.f1.submit();";
                    //outputHTML += "</script>";
                    //outputHTML += "</form>";
                    //outputHTML += "</body>";
                    //outputHTML += "</html>";
                    //Response.Write(outputHTML);

                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }


}
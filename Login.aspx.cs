using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();

    protected void Page_Load(object sender, EventArgs e)
    {
        //lnkLogin.Attributes.Add("onKeyPress",
        //"javascript:if (event.keyCode == 13) __doPostBack('" + lnkLogin.ClientID + "','')");
        if (!IsPostBack)
        {

        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        DataTable dtLoginDetails = new DataTable();
        try
        {
            lblErrmsg.Attributes.Add("style", "display:none");
            string UserName = Convert.ToString(txtEmail_login.Text);
            string Password = Convert.ToString(txtPassword_login.Text);
            DataSet ds = objdb.ExecuteDataset("CheckforLogin", UserName, Password);
            dtLoginDetails = ds.Tables[0];
            if (dtLoginDetails.Rows.Count > 0)
            {
                Session["MemberCode"] = Convert.ToString(dtLoginDetails.Rows[0]["MemberCode"]);
                Session["ProfileID"] = Convert.ToString(dtLoginDetails.Rows[0]["ProfileID"]);
                Session["MemberName"] = Convert.ToString(dtLoginDetails.Rows[0]["MemberName"]);
                Session["Gender"] = Convert.ToString(dtLoginDetails.Rows[0]["Gender"]);
                string UserIP = Fetch_UserIP();
                string City = GetUserCountryByIp(UserIP);
                HttpCookie upsceducook = new HttpCookie("userinfo");
                upsceducook["membercode"] = Convert.ToString(dtLoginDetails.Rows[0]["MemberCode"]);                
                upsceducook.Expires = DateTime.Now.AddYears(2);
                Response.Cookies.Add(upsceducook);
                //Request.Cookies["userinfo"].Values["membercode"]
                objdb.ExecuteDataset("Insert_tbl_LogTable", Convert.ToString(dtLoginDetails.Rows[0]["MemberCode"]), DateTime.Now, UserIP, City);
                Response.Redirect("/Welcome");
            }
            else
            {
                lblErrmsg.Attributes.Add("style", "display:block");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.ToUpper() == "UNAPPROVED")
            {
                lblAlert.Text = "Your profile is under Admin process. It will take 48 hourse for activation of your profile";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
            }
        }
    }



    private string Fetch_UserIP()
    {
        string VisitorsIPAddress = string.Empty;
        try
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddress = HttpContext.Current.Request.UserHostAddress;
            }
        }
        catch (Exception ex)
        {

            //Handle Exceptions  
        }
        return VisitorsIPAddress;
    }

    public string GetUserCountryByIp(string ip)
    {
        IpInfo ipInfo = new IpInfo();
        try
        {
            string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
            ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
            ipInfo.Country = myRI1.EnglishName;
            string StrCity = ipInfo.City + ":" + ipInfo.Region + ":" + ipInfo.Country;
            return StrCity;
        }
        catch (Exception)
        {
            ipInfo.Country = null;
            return "";
        }
    }

    [WebMethod]
    public static bool CheckLogin(string UserName, string Password)
    {
        DataTable dtLoginDetails = new DataTable();
        try
        {

            //DataSet ds = objdb.ExecuteDataset("CheckforLogin_new", UserName, Password);
            //dtLoginDetails = ds.Tables[0];
            //if (dtLoginDetails.Rows.Count > 0)
            //{
            //    Session["MemberCode"] = Convert.ToString(dtLoginDetails.Rows[0]["MemberCode"]);
            //    Session["ProfileID"] = Convert.ToString(dtLoginDetails.Rows[0]["ProfileID"]);
            //    Session["MemberName"] = Convert.ToString(dtLoginDetails.Rows[0]["MemberName"]);
            //    Session["Gender"] = Convert.ToString(dtLoginDetails.Rows[0]["Gender"]);
            //    return true;
            //}
            //else
            //{
            //    lblErrmsg.Attributes.Add("style", "display:block");
            //    return false;
            //}
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
public class IpInfo
{

    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("hostname")]
    public string Hostname { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("region")]
    public string Region { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("loc")]
    public string Loc { get; set; }

    [JsonProperty("org")]
    public string Org { get; set; }

    [JsonProperty("postal")]
    public string Postal { get; set; }
}
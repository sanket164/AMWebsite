using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["MemberCode"] = null;
        Session["S_BornFrom"] = null;
        Session["S_BornTo"] = null;
        Session["MaritalStatusList"] = null;
        Session["CasteList"] = null;
        Session["Education"] = null;
        Session["Country"] = null;
        Session["State"] = null;
        Session["ProfileID"] = null;
        Session["MemberName"] = null;
        Session["Gender"] = null;
        Session["dtSibbling"] = null;
        Session["dtSingUp"] = null;
        Session["SearchResult"] = null;
    }
}
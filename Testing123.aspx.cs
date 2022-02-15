using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Testing123 : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtCaste = objGlobal.GetCasteList("");
        lstCaste.DataSource = dtCaste;
        lstCaste.DataValueField = "CasteCode";
        lstCaste.DataTextField = "Caste";
        lstCaste.DataBind();
        lstCaste.Items.Insert(0, new ListItem("Any", ""));
    }
}
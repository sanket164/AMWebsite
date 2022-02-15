using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MarriedConfirmation : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    dbInteraction objDb = new dbInteraction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mid"] != "")
        {
            GetMemberDetails();
        }
        else
        {
            Response.Redirect("/Default");
        }
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["mid"] != "")
            {
                long MemberCode = Convert.ToInt64(Request.QueryString["mid"]);
                objGlobal.UpdateMarriedConfirm(MemberCode, true);
                Firstdiv.Visible = false;
                Secounddiv_Yes.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["mid"] != "")
            {
                long MemberCode = Convert.ToInt64(Request.QueryString["mid"]);
                objGlobal.UpdateMarriedConfirm(MemberCode, false);
                Firstdiv.Visible = false;
                Secounddiv_No.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void GetMemberDetails()
    {
        try
        {
            long MemberCode = Convert.ToInt64(Request.QueryString["mid"]);
            DataTable dtMember = objGlobal.GetMemberDetails(MemberCode);
            if (dtMember.Rows.Count > 0)
            {
                string MemberDetails = Convert.ToString(dtMember.Rows[0]["MemberName"]);
                MemberDetails += " (" + Convert.ToString(dtMember.Rows[0]["ProfileId"]) + ")";
                //lblMemberName.Text = MemberDetails;
            }
            //bool isUpload = objGlobal.GetUploadPhotoStatus(MemberCode);
            //if (!isUpload)
            //{
            //    lblPhotoUploadMSG1.Visible = true;
            //}
        }
        catch (Exception ex)
        {

            throw;
        }
    }



}
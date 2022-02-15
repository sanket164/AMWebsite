using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadPhotos : System.Web.UI.Page
{
    cl_tbl_MemberMaster objMemberMaster = new cl_tbl_MemberMaster();
    dbInteraction objDb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();

    protected void Page_Load(object sender, EventArgs e)
    {
        img1_dev.Visible = false;
        img2_dev.Visible = false;
        img3_dev.Visible = false;
        lnkDelete1.Visible = false;
        lnkDelete2.Visible = false;
        lnkDelete3.Visible = false;
        if (Session["MemberCode"] == null)
        {
            Response.Redirect("/Registration");
        }
        Label1.Text = "";
        if (!IsPostBack)
        {
            if (Session["MemberCode"] != null)
            {
                long MemberCode = Convert.ToInt64(Session["MemberCode"]);
                GetMemberPhotos(MemberCode);
            }
        }
    }

    protected void Upload(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            int Cnt = GetPhotoCount(MemberCode);
            if (Cnt >= 3)
            {
                Label1.Text = "Not more than 3 photos";
                Response.Redirect("/UploadPhotos");
                return;
            }
            if (Cnt == 0)
            {
                Cnt = 1;
            }
            HttpFileCollection _HttpFileCollection = Request.Files;
            foreach (HttpPostedFile thefile in FileUpload1.PostedFiles)
            {
                string fileName = Path.GetFileName(thefile.FileName);
                string[] strArr = fileName.Split('.');
                string D_time = DateTime.Now.ToString("ddMMyyyyhhmmss");
                string FileName = MemberCode + "_" + D_time.ToString() + "." + strArr[1];
                thefile.SaveAs(Server.MapPath("~/MemberPhoto/") + FileName);
                objMemberMaster.MemberCode = Convert.ToDecimal(Session["MemberCode"]);
                objMemberMaster.PhotoFileName = Convert.ToString(FileName);
                objMemberMaster.InsertMemberPhoto();
                System.Threading.Thread.Sleep(1000);
                int TotalCnt = Convert.ToInt32(objMemberMaster.TotalCount);
            }
            FileUpload1.Dispose();
            Response.Redirect("/UploadPhotos");
        }
        else
        {
            Label1.Text = "Please select atleast 1 Photo";
            return;
        }
    }

    public int GetPhotoCount(long MemberCode)
    {
        int TotalCnt = 0;
        try
        {
            string strSql = "select Count(*) Cnt from tbl_MemberPhotos where MemberCode=" + MemberCode;
            TotalCnt = Convert.ToInt32(objDb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return TotalCnt;
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("/Login");
            long membercode = Convert.ToInt32(Session["MemberCode"]);
            if (objGlobal.CheckIsUpdateDate(membercode))
            {
                lblErrMsg.Text = "Your changes will be updated soon and reflect in your profile soon in max 48 hours.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
            }
            else
            {
                lblErrMsg.Text = "Your profile is under Admin process. It will take 48 hourse for activation of your profile";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
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

                Response.Redirect("/Authentication");
            }


        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void GetMemberPhotos(long MemberCode)
    {
        try
        {
            DataTable dtMemberPhotos = objGlobal.GetMemberPhotos(MemberCode);
            if (dtMemberPhotos.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtMemberPhotos.Rows.Count; cnt++)
                {
                    if (cnt == 0)
                    {
                        img1_dev.Visible = true;
                        img1.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img1.AlternateText = Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        lnkDelete1.Visible = true;
                    }
                    if (cnt == 1)
                    {
                        img2_dev.Visible = true;
                        img2.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img2.AlternateText = Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        lnkDelete2.Visible = true;
                    }
                    if (cnt == 2)
                    {
                        img3_dev.Visible = true;
                        img3.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img3.AlternateText = Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        lnkDelete3.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
    protected void lnkDelete1_Click(object sender, EventArgs e)
    {
        try
        {
            string strFileName = img1.AlternateText;
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            objGlobal.Delete_tbl_MemberPhotos(MemberCode, strFileName);
            Response.Redirect("/UploadPhotos");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
    protected void lnkDelete2_Click(object sender, EventArgs e)
    {
        try
        {
            string strFileName = img2.AlternateText;
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            objGlobal.Delete_tbl_MemberPhotos(MemberCode, strFileName);
            Response.Redirect("/UploadPhotos");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
    protected void lnkDelete3_Click(object sender, EventArgs e)
    {
        try
        {
            string strFileName = img3.AlternateText;
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            objGlobal.Delete_tbl_MemberPhotos(MemberCode, strFileName);
            Response.Redirect("/UploadPhotos");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }



}
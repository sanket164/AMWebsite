using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_DeletePhotos : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();
    SqlConnection objConnection = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["LoginCode"] != null)
        //{
        //    if (!IsPostBack)
        //    {
        BindGrid();
        //    }
        //}
        //else
        //{
        //    Response.Redirect("/Account/Login");
        //}
    }

    public void BindGrid()
    {
        DataSet dsGetData = objGlobal.GET_Delete_Photos_List("");
        if (dsGetData != null)
        {
            lblTotalCnt.Text = "Total : " + Convert.ToString(dsGetData.Tables[0].Rows.Count);
            dgvDetails.DataSource = dsGetData;
            dgvDetails.DataBind();// = dsGetData;
        }
    }

    protected void Grdviplist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvDetails.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            long MemberCode = Convert.ToInt64(e.CommandArgument);
            string strSql = "Select * from tbl_MemberPhotos where MemberCode=" + MemberCode;
            DataTable dtDetails = objdb.GetDataTable(strSql);
            if (dtDetails.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                {
                    string sPath = (Server.MapPath("/MemberPhoto/" + Convert.ToString(dtDetails.Rows[cnt]["PhotoFileName"])));
                    Console.Write(sPath);
                    File.Delete(sPath);
                    Console.Write("File Delete from Server");
                    objGlobal.Delete_tbl_MemberPhotos(MemberCode, Convert.ToString(dtDetails.Rows[cnt]["PhotoFileName"]));
                    Console.Write("File Delete from Database");
                }
                //HttpFileCollection _HttpFileCollection = Request.Files;
                //foreach (HttpPostedFile thefile in FileUpload1.PostedFiles)
                //{
                //    string fileName = Path.GetFileName(thefile.FileName);
                //    string[] strArr = fileName.Split('.');
                //    string D_time = DateTime.Now.ToString("ddMMyyyyhhmmss");
                //    string FileName = MemberCode + "_" + D_time.ToString() + "." + strArr[1];
                //    thefile.(Server.MapPath("~/MemberPhoto/") + FileName);
                //}
            }
            BindGrid();
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        DataSet dsGetData = objGlobal.GET_Delete_Photos_List("");
        for (int cnt = 0; cnt < dsGetData.Tables[0].Rows.Count; cnt++)
        {
            long MemberCode = Convert.ToInt64(dsGetData.Tables[0].Rows[cnt]["MemberCode"]);
            string strSql = "Select * from tbl_MemberPhotos where MemberCode=" + MemberCode;
            DataTable dtDetails = objdb.GetDataTable(strSql);
            if (dtDetails.Rows.Count > 0)
            {
                for (int cnt1 = 0; cnt1 < dtDetails.Rows.Count; cnt1++)
                {
                    string sPath = (Server.MapPath("/MemberPhoto/" + Convert.ToString(dtDetails.Rows[cnt1]["PhotoFileName"])));
                    Console.WriteLine(sPath);
                    try
                    {
                        File.Delete(sPath);
                        objGlobal.Delete_tbl_MemberPhotos(MemberCode, Convert.ToString(dtDetails.Rows[cnt1]["PhotoFileName"]));
                        Console.WriteLine("Delete from Server : " + MemberCode);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error Member : " + MemberCode);
                    }

                }
                //HttpFileCollection _HttpFileCollection = Request.Files;
                //foreach (HttpPostedFile thefile in FileUpload1.PostedFiles)
                //{
                //    string fileName = Path.GetFileName(thefile.FileName);
                //    string[] strArr = fileName.Split('.');
                //    string D_time = DateTime.Now.ToString("ddMMyyyyhhmmss");
                //    string FileName = MemberCode + "_" + D_time.ToString() + "." + strArr[1];
                //    thefile.(Server.MapPath("~/MemberPhoto/") + FileName);
                //}
            }
        }
    }
}
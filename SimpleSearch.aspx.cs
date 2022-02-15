using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SimpleSearch : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();
    SqlConnection objConnection = new SqlConnection();

    string StrSql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberCode"] == null)
        {
            Response.Redirect("/Login");
        }
        if (!IsPostBack)
        {
            FillCombo();
        }
    }

    public void FillCombo()
    {
        try
        {
            DataTable dtCaste = objGlobal.GetCasteList("");
            lstCaste.DataSource = dtCaste;
            lstCaste.DataValueField = "CasteCode";
            lstCaste.DataTextField = "Caste";
            lstCaste.DataBind();
            lstCaste.Items.Insert(0, new ListItem("Any", ""));

            string MaritalStatus = "";
            if (Convert.ToString(Session["MemberCode"]) != "")
            {
                int MemberCode = Convert.ToInt32(Session["MemberCode"]);
                //MaritalStatus = objGlobal.GetMaritalStatus(MemberCode);
                MaritalStatus = objGlobal.GeMGetMaritalStatus_Preference(MemberCode);
            }
            DataTable dtMaritalStatusList = new DataTable();
            //if (MaritalStatus != "")
            //{
            //    if (MaritalStatus == "Widow/Widower")
            //    {
            //        MaritalStatus = "Widow";
            //    }
            //    else if (MaritalStatus == "Divorced")
            //    {

            //    }
            //    dtMaritalStatusList = objGlobal.GetMaritalStatusList(MaritalStatus);

            //}
            //else
            //{
            //    dtMaritalStatusList = objGlobal.GetMaritalStatusList("");
            //}
            dtMaritalStatusList = objGlobal.GetMaritalStatusListById(" WHERE MaritalStatusCode in (" + MaritalStatus + ")");
            lstMarital_Status.DataSource = dtMaritalStatusList;
            lstMarital_Status.DataValueField = "MaritalStatusCode";
            lstMarital_Status.DataTextField = "MaritalStatus";
            lstMarital_Status.DataBind();
            if (MaritalStatus == "")
            {
                lstMarital_Status.Items.Insert(0, new ListItem("Any", ""));
            }


            int FromYear = 1950, ToYear = 1996;
            if (Session["ProfileID"] != null)
            {
                string val = Convert.ToString(Session["ProfileID"]);
                int MemberCode = Convert.ToInt32(Session["MemberCode"]);
                int AgeDiff = objGlobal.GetAgeDiff(MemberCode);
                DataTable dtMemberList = objdb.GetDataTable("select * from tbl_MemberMaster  where MemberCode=" + MemberCode);
                if (dtMemberList.Rows.Count > 0)
                {
                    if (Convert.ToString(dtMemberList.Rows[0]["DateOfBirth"]) != "")
                    {
                        DateTime DOB = Convert.ToDateTime(dtMemberList.Rows[0]["DateOfBirth"]);
                        FromYear = DOB.Year;
                        ////0= Male, 1=Female
                        ////If Male profile than From+AgeDiff and Female Profile than ToYear-AgeDiff (as per Discuss with Hemish on 05-Aug-2019)
                        if (Convert.ToString(Session["Gender"]) == "0")
                        {
                            ToYear = FromYear + 5;
                            if (AgeDiff > 0)
                            {
                                FromYear = FromYear - AgeDiff;
                            }
                        }
                        else
                        {
                            ToYear = FromYear;
                            FromYear = FromYear - 5;
                            if (AgeDiff > 0)
                            {
                                ToYear = ToYear + AgeDiff;
                            }
                        }
                    }
                }
            }


            DataTable dtFromBorn = objGlobal.GetYearList(FromYear, ToYear);
            ddlBornFrom.DataSource = dtFromBorn;
            ddlBornFrom.DataValueField = "NValue";
            ddlBornFrom.DataTextField = "Number";
            ddlBornFrom.DataBind();

            DataTable dtToBorn = objGlobal.GetYearList(FromYear, ToYear);
            ddlBornTo.DataSource = dtToBorn;
            ddlBornTo.DataValueField = "NValue";
            ddlBornTo.DataTextField = "Number";
            ddlBornTo.DataBind();
        }
        catch (Exception ex)
        {
            throw;
        }
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
                //long MemberCode = Convert.ToInt64(Session["MemberCode"]);
                //int s_Gender = objGlobal.GetGender(MemberCode);
                //if (s_Gender == 0)
                //{
                //    s_Gender = 1;
                //}
                //else
                //{
                //    s_Gender = 0;
                //}
                //Session["s_Gender"] = s_Gender;
                Session["S_BornFrom"] = ddlBornFrom.SelectedValue;
                Session["S_BornTo"] = ddlBornTo.SelectedValue;
                Session["MaritalStatusList"] = objGlobal.GetListBox_SelectedItem(lstMarital_Status);
                string StrSelectedItems = "";
                if (objGlobal.GetListBox_SelectedItem(lstMarital_Status) == "")
                {
                    for (int cnt = 0; cnt < lstMarital_Status.Items.Count; cnt++)
                    {
                        StrSelectedItems = StrSelectedItems + "," + lstMarital_Status.Items[cnt].Value;
                    }
                    StrSelectedItems = StrSelectedItems.Substring(1, StrSelectedItems.Length - 1);
                    Session["MaritalStatusList"] = StrSelectedItems;
                }
                
                Session["CasteList"] = objGlobal.GetListBox_SelectedItem(lstCaste);
                Response.Redirect("/SearchResult.aspx");
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public string GetConnStr()
    {
        string str = "";
        try
        {
            objConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["nsConn"].ToString();
            return str;
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::GetConnStr::Error occured.", ex);
        }
        return str;
    }

    public DataTable Load_ProfileList()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[Load_ProfileList]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            int s_Gender = objGlobal.GetGender(MemberCode);
            if (s_Gender == 0)
            {
                s_Gender = 1;
            }
            else
            {
                s_Gender = 0;
            }
            string AgeStart = ddlBornFrom.SelectedValue;
            string AgeUpto = ddlBornTo.SelectedValue;
            string MaritalStatusList = objGlobal.GetListBox_SelectedItem(lstMarital_Status);
            //string EducationList="";
            string CasteList = objGlobal.GetListBox_SelectedItem(lstCaste);
            //string CountryList=""; 
            //string StateCityList="";
            int TotalCnt = 0;

            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, MemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, s_Gender));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeStart", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeStart));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeUpto", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeUpto));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatusList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, MaritalStatusList));
            cmdToExecute.Parameters.Add(new SqlParameter("@EducationList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ""));
            cmdToExecute.Parameters.Add(new SqlParameter("@CasteList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CasteList));
            cmdToExecute.Parameters.Add(new SqlParameter("@CountryList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ""));
            cmdToExecute.Parameters.Add(new SqlParameter("@StateCityList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ""));
            cmdToExecute.Parameters.Add(new SqlParameter("@SqlCondition", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
            cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
            cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 8));

            cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 10, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, TotalCnt));

            if (objConnection.State == ConnectionState.Closed)
            {
                // Open connection.
                objConnection.Open();
            }

            // Execute query.
            //cmdToExecute.ExeD();
            DataTable dtData = new DataTable();
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(cmdToExecute);
            sdaAdapter.Fill(dtData);
            return dtData;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Load_ProfileList::Get Values::Error occured.", ex);
        }
        finally
        {
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }





}
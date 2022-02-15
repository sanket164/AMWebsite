using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    SqlConnection objConnection = new SqlConnection();
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();
    int TotalCnt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["Search"] == "First")
            {
                if (!IsPostBack)
                {
                    DataTable dtDetails = Load_ProfileList_NEW();
                    SetHTML(dtDetails);
                    return;
                }
            }
            if (Session["MemberCode"] != null)
            {
                if (Session["S_BornFrom"] == null && Session["S_BornTo"] == null && Session["MaritalStatusList"] == null && Session["CasteList"] == null)
                {
                    Response.Redirect("/SimpleSearch");
                }
            }
            else
            {
                Response.Redirect("/Default");
            }
            if (!IsPostBack)
            {
                //DataTable dtDetails = (DataTable)Session["SearchResult"];
                DataTable dtDetails = Load_ProfileList_NEW();
                SetHTML(dtDetails);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void SetHTML(DataTable dtDetails)
    {
        try
        {
            if (dtDetails.Rows.Count == 0)
            {
                ltrHTML.Text = " <p>No records found</p>";
            }
            else
            {
                string strHTML = "";
                lblTotalMsg.Text = "Total " + TotalCnt + " profile found";
                for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                {
                    strHTML += " <div class='col-md-3 col-sm-6'> ";
                    strHTML += " <div class='prof-box'> ";
                    strHTML += " <div class='prof-id'> ";
                    strHTML += " <h4>" + Convert.ToString(dtDetails.Rows[cnt]["ProfileID"]) + "</h4> ";
                    strHTML += " </div> ";
                    strHTML += " <div class='prof-img'> ";
                    strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtDetails.Rows[cnt]["PhotoFileName"]) + "' /> ";
                    strHTML += " </div> ";
                    strHTML += " <div class='prof-details'> ";
                    strHTML += " <ul> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["BirthYear"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += "  <li> ";
                    strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["Height"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["Caste"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["MaritalStatus"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["Education"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["StateCity"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["VisaStatus"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Visa Country<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["VisaCountry"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " </ul> ";
                    strHTML += " </div> ";
                    strHTML += " <div class='view-more'> ";
                    strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtDetails.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtDetails.Rows[cnt]["ProfileID"]) + "' target='_blank'>View More</a> ";
                    strHTML += " </div> ";
                    strHTML += " </div> ";
                    strHTML += " </div> ";
                }
                int intPageNo = 1;
                if (Request["pg_no"] != null)
                {
                    intPageNo = Convert.ToInt32(Request["pg_no"]);
                }
                var totalPages = (int)Math.Ceiling((decimal)TotalCnt / (decimal)8);
                var currentPage = intPageNo != null ? (int)intPageNo : 1;
                var startPage = currentPage - 5;
                var endPage = currentPage + 4;
                if (startPage <= 0)
                {
                    endPage -= (startPage - 1);
                    startPage = 1;
                }
                if (endPage > totalPages)
                {
                    endPage = totalPages;
                    if (endPage > 10)
                    {
                        startPage = endPage - 9;
                    }
                }
                strHTML += " <ul class='pagination'> ";
                if (currentPage > 1)
                {
                    strHTML += " <li><a href='/SearchResult?pg_no=1'>First</a></li> ";
                    strHTML += " <li><a href='/SearchResult?pg_no=" + (intPageNo - 1) + "'>Previous</a></li>";
                }
                for (int cnt = startPage; cnt <= endPage; cnt++)
                {
                    if (intPageNo == (cnt))
                    {
                        strHTML += " <li class='active'><a href='/SearchResult?pg_no=" + (cnt) + "''>" + (cnt) + "</a></li> ";
                    }
                    else
                    {
                        strHTML += " <li><a href='/SearchResult?pg_no=" + (cnt) + "'>" + (cnt) + "</a></li> ";
                    }
                }
                //if (intPageNo != TotalRow)
                //{
                //    strHTML += " <div class='pageing_clo'><a rel='next' href='/SearchResult?PageNo=" + (intPageNo + 1) + "')'>Next</a></div> ";
                //}
                if (currentPage < totalPages)
                {
                    strHTML += " <li> <a href='/SearchResult?pg_no=" + (intPageNo + 1) + "'>Next</a> </li>";
                    strHTML += " <li> <a href='/SearchResult?pg_no=" + totalPages + "'>Last</a> </li>";
                }

                strHTML += " </ul>";
                strHTML += " <div class='form-group input-group-lg' style='display:inline-block; float:left; margin-right:10px;'> ";
                strHTML += "<br/> ";
                //strHTML += " <a> Go to page  ";
                //strHTML += " <input size='7' placeholder='page #'><button class='btn btn-primary btn-xl'>Go</button></a></div>";
                ltrHTML.Text = strHTML;
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
    public DataTable Load_ProfileList_NEW()
    {
        try
        {
            int intPageNo = 0;
            if (intPageNo == 0)
            {
                intPageNo = 1;
            }
            if (Request["pg_no"] != null)
            {
                intPageNo = Convert.ToInt32(Request["pg_no"]);
            }
            long MemberCode = 0;
            int s_Gender = 0;

            if (Session["MemberCode"] != null)
            {
                MemberCode = Convert.ToInt64(Session["MemberCode"]);
                s_Gender = objGlobal.GetGender(MemberCode);
                if (s_Gender == 0)
                {
                    s_Gender = 1;
                }
                else
                {
                    s_Gender = 0;
                }
            }
            else
            {
                s_Gender = Convert.ToInt32(Session["s_Gender"]);
                if (s_Gender == 0)
                {
                    s_Gender = 1;
                }
                else
                {
                    s_Gender = 0;
                }
            }

            string AgeStart = Convert.ToString(Session["S_BornFrom"]);
            string AgeUpto = Convert.ToString(Session["S_BornTo"]);
            string MaritalStatusList = Convert.ToString(Session["MaritalStatusList"]);
            string EducationList = Convert.ToString(Session["Education"]);
            string CasteList = Convert.ToString(Session["CasteList"]);
            string CountryList = Convert.ToString(Session["Country"]);
            string StateCityList = Convert.ToString(Session["State"]);
            int Total = 0;
            string strCond = " and 0=0 ";
            if (EducationList != "")
            {
                strCond += " AND MM.Education IN (" + EducationList + ")";
            }
            if (CountryList != "")
            {
                strCond += " AND MM.VisaCountry IN (" + CountryList + ")";
            }
            if (StateCityList != "")
            {
                strCond += " AND MM.StateCity IN (" + StateCityList + ")";
            }
            DataTable dtData = new DataTable();
            int FromCnt = 0;
            int ToCnt = 0;
            FromCnt = (intPageNo * 8) - (8 - 1);
            ToCnt = (FromCnt + 7);

            string strSql = " SELECT * FROM(  ";
            strSql += " SELECT ROW_NUMBER() OVER (ORDER BY MM.VIP_ORD DESC,MM.MemberCode desc,RegisterDate DESC) as  row_num ,MM.MemberCode, MM.ProfileID, MM.ProfileCreatedBy, MM.MemberName, CASE WHEN MM.Gender = 0 THEN 'Male' ELSE 'Female' END AS Gender,    ";
            strSql += "  CONVERT(varchar(4), MM.DateofBirth, 111) AS BirthYear, dbo.getheight(MM.Height) AS Height, MM.Weight, MM.AboutInfo, ISNULL(MP.PhotoFileName,    ";
            strSql += " CASE WHEN Gender = 0 THEN 'male.jpg' ELSE 'female.jpg' END) AS PhotoFileName, Mar.MaritalStatus, StCity.StateCity, Rel.Religion,";
            strSql += " Cas.Caste, Edu.Education, MM.HomeAddress1, Cou.Country, VC.Country VisaCountry, MM.MobileNo, MM.EmailID, VS.VisaStatus, AIC.AnnualIncomeCurrency, AI.AnnualIncome,   ";
            strSql += " SC.SubCaste,MM.Manglik,MM.MobileNo1,MM.Degree,MM.RegisterDate,MM.VIP_ORD  ";
            strSql += " FROM    dbo.tbl_MemberMaster AS MM LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_VisaStatus AS VS ON MM.VisaStatus = VS.VisaStatusCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_AnnualIncomeCurrency AS AIC ON MM.AnnualIncomeCurrency = AIC.AnnualIncomeCurrencyCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_AnnualIncome AS AI ON MM.AnnualIncome = AI.AnnualIncomeCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_SubCaste AS SC ON MM.SubCaste = SC.SubCasteCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_MaritalStatus AS Mar ON MM.MaritalStatus = Mar.MaritalStatusCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_StateCity AS StCity ON MM.StateCity = StCity.StateCityCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_Country AS Cou ON MM.Country = Cou.CountryCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_Country AS VC ON MM.VisaCountry = VC.CountryCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_Religion AS Rel ON MM.Religion = Rel.ReligionCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_Caste AS Cas ON MM.Caste = Cas.CasteCode LEFT OUTER JOIN  ";
            strSql += " dbo.tbl_Education AS Edu ON MM.Education = Edu.EducationCode LEFT OUTER JOIN  ";
            strSql += " (SELECT MemberCode, MIN(PhotoFileName) AS PhotoFileName FROM tbl_MemberPhotos Group by MemberCode) AS MP ON MM.MemberCode = MP.MemberCode  ";
            strSql += " WHERE     MM.isActive IN (1 ,2)  AND   ";
            strSql += " MM.MemberCode != Convert(varchar," + MemberCode + ")  ";
            strSql += " AND MM.Gender = " + s_Gender;
            strSql += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + AgeStart + " AND " + AgeUpto;
            if (MaritalStatusList != "")
            {
                strSql += " AND MM.MaritalStatus IN (SELECT items FROM dbo.Split('" + MaritalStatusList + "',','))";
            }
            if (CasteList != "")
            {
                strSql += " AND MM.Caste IN (SELECT items FROM dbo.Split('" + CasteList + "',','))";
            }
            if (EducationList != "")
            {
                strSql += " AND MM.Education IN (SELECT items FROM dbo.Split('" + EducationList + "',','))";
            }
            if (CountryList != "")
            {
                strSql += " AND MM.VisaCountry IN (SELECT items FROM dbo.Split('" + CountryList + "',','))";
            }
            if (StateCityList != "")
            {
                strSql += " AND MM.StateCity IN (SELECT items FROM dbo.Split('" + StateCityList + "',','))";
            }
            strSql += " ) AS A WHERE row_num BETWEEN " + FromCnt + " AND " + ToCnt + "";
            //strSql += " ORDER BY RegisterDate DESC,MemberCode DESC ";
            dtData = objdb.GetDataTable(strSql);

            ////Query for total Count
            strSql = " SELECT Count(MemberCode) FROM tbl_MemberMaster MM  ";
            strSql += " WHERE   MM.isActive IN (1 ,2)  AND ";
            strSql += " MM.MemberCode != Convert(varchar," + MemberCode + ") ";
            strSql += " AND MM.Gender = " + s_Gender;
            strSql += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + AgeStart + " AND " + AgeUpto;
            if (MaritalStatusList != "")
            {
                strSql += " AND MM.MaritalStatus IN (SELECT items FROM dbo.Split('" + MaritalStatusList + "',','))";
            }
            if (CasteList != "")
            {
                strSql += " AND MM.Caste IN (SELECT items FROM dbo.Split('" + CasteList + "',','))";
            }
            if (EducationList != "")
            {
                strSql += " AND MM.Education IN (SELECT items FROM dbo.Split('" + EducationList + "',','))";
            }
            if (CountryList != "")
            {
                strSql += " AND MM.VisaCountry IN (SELECT items FROM dbo.Split('" + CountryList + "',','))";
            }
            if (StateCityList != "")
            {
                strSql += " AND MM.StateCity IN (SELECT items FROM dbo.Split('" + StateCityList + "',','))";
            }
            
            TotalCnt = Convert.ToInt32(objdb.ExecuteScalar(strSql));
            return dtData;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Load_ProfileList::Get Values::Error occured.", ex);
        }
    }

    public DataTable Load_ProfileList()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[SP_SEARCH_RESULT]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            int intPageNo = 0;
            if (intPageNo == 0)
            {
                intPageNo = 1;
            }
            if (Request["pg_no"] != null)
            {
                intPageNo = Convert.ToInt32(Request["pg_no"]);
            }
            long MemberCode = 0;
            int s_Gender = 0;

            if (Session["MemberCode"] != null)
            {
                MemberCode = Convert.ToInt64(Session["MemberCode"]);
                s_Gender = objGlobal.GetGender(MemberCode);
                if (s_Gender == 0)
                {
                    s_Gender = 1;
                }
                else
                {
                    s_Gender = 0;
                }
            }
            else
            {
                s_Gender = Convert.ToInt32(Session["s_Gender"]);
                if (s_Gender == 0)
                {
                    s_Gender = 1;
                }
                else
                {
                    s_Gender = 0;
                }
            }

            string AgeStart = Convert.ToString(Session["S_BornFrom"]);
            string AgeUpto = Convert.ToString(Session["S_BornTo"]);
            string MaritalStatusList = Convert.ToString(Session["MaritalStatusList"]);
            string EducationList = Convert.ToString(Session["Education"]);
            string CasteList = Convert.ToString(Session["CasteList"]);
            string CountryList = Convert.ToString(Session["Country"]);
            string StateCityList = Convert.ToString(Session["State"]);
            int Total = 0;
            string strCond = " and 0=0 ";
            if (EducationList != "")
            {
                strCond += " AND MM.Education IN (" + EducationList + ")";
            }
            if (CountryList != "")
            {
                strCond += " AND MM.VisaCountry IN (" + CountryList + ")";
            }
            if (StateCityList != "")
            {
                strCond += " AND MM.StateCity IN (" + StateCityList + ")";
            }

            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, MemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, s_Gender));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeStart", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeStart));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeUpto", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeUpto));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatusList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, MaritalStatusList));
            //cmdToExecute.Parameters.Add(new SqlParameter("@EducationList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, EducationList));
            cmdToExecute.Parameters.Add(new SqlParameter("@CasteList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CasteList));
            //cmdToExecute.Parameters.Add(new SqlParameter("@CountryList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, CountryList));
            //cmdToExecute.Parameters.Add(new SqlParameter("@StateCityList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, StateCityList));
            //cmdToExecute.Parameters.Add(new SqlParameter("@SqlCondition", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
            cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, intPageNo));
            cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 8));
            cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 10, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, Total));
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
            Total = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
            TotalCnt = Total;
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
    public DataTable SP_SEARCH_RESULT()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[SP_SEARCH_RESULT]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            int intPageNo = 0;
            if (intPageNo == 0)
            {
                intPageNo = 1;
            }
            if (Request["pg_no"] != null)
            {
                intPageNo = Convert.ToInt32(Request["pg_no"]);
            }
            long MemberCode = 0;
            int s_Gender = 0;

            if (Session["MemberCode"] != null)
            {
                MemberCode = Convert.ToInt64(Session["MemberCode"]);
                s_Gender = objGlobal.GetGender(MemberCode);
                if (s_Gender == 0)
                {
                    s_Gender = 1;
                }
                else
                {
                    s_Gender = 0;
                }
            }
            else
            {
                s_Gender = Convert.ToInt32(Session["s_Gender"]);
                if (s_Gender == 0)
                {
                    s_Gender = 1;
                }
                else
                {
                    s_Gender = 0;
                }
            }

            string AgeStart = Convert.ToString(Session["S_BornFrom"]);
            string AgeUpto = Convert.ToString(Session["S_BornTo"]);
            string MaritalStatusList = Convert.ToString(Session["MaritalStatusList"]);
            string EducationList = Convert.ToString(Session["Education"]);
            string CasteList = Convert.ToString(Session["CasteList"]);
            string CountryList = Convert.ToString(Session["Country"]);
            string StateCityList = Convert.ToString(Session["State"]);
            int Total = 0;

            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, MemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, s_Gender));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeStart", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeStart));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeUpto", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeUpto));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatusList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, MaritalStatusList));
            cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, intPageNo));
            cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 8));
            cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 10, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, Total));
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
            Total = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
            TotalCnt = Total;
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
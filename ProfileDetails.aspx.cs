using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileDetails : System.Web.UI.Page
{
    SqlConnection objConnection = new SqlConnection();
    UD_Global objGlobal = new UD_Global();
    int TotalCnt = 0;
    string strPara = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["FYear"] != null && Request["TYear"] != null && Request["MStatus"] != null && Request["Caste"] != null && Request["Edu"] != null && Request["StCt"] != null && Request["Cou"] != null)
            {
                //if (Session["Path"] != null)
                //{
                //    Session["Path"] = path;
                //}
                //else
                //{
                //    if (path != Session["Path"])
                //    {
                //        Session["Path"] = path;
                //    }
                //}
                DataTable dtDetails = Load_ProfileList();
                SetHTML(dtDetails);
            }
            else
            {
                Response.Redirect("/Default");
            }
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
            int s_Gender = Convert.ToInt32(Request["G"]);


            string AgeStart = Request["FYear"];
            string AgeUpto = Request["TYear"];
            string MaritalStatusList = Request["MStatus"];
            string EducationList = "";
            if (Request["Edu"] != "0")
            {
                EducationList = Request["Edu"];
            }

            string CasteList = "";
            if (Request["Caste"] != "0")
            {
                CasteList = Request["Caste"];
            }

            string CountryList = "";
            if (Request["Cou"] != "0")
            {
                CountryList = Request["Cou"];
            }
            string StateCityList = "";
            if (Request["StCt"] != "0")
            {
                StateCityList = Request["StCt"];
            }

            int Total = 0;

            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, MemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, s_Gender));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeStart", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeStart));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeUpto", SqlDbType.VarChar, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, AgeUpto));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatusList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, MaritalStatusList));
            cmdToExecute.Parameters.Add(new SqlParameter("@EducationList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, EducationList));
            cmdToExecute.Parameters.Add(new SqlParameter("@CasteList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, CasteList));
            cmdToExecute.Parameters.Add(new SqlParameter("@CountryList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, CountryList));
            cmdToExecute.Parameters.Add(new SqlParameter("@StateCityList", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, StateCityList));
            cmdToExecute.Parameters.Add(new SqlParameter("@SqlCondition", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
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

    public void SetHTML(DataTable dtDetails)
    {
        try
        {
            string path = HttpContext.Current.Request.Url.Query;
            if (Request["pg_no"] != null)
            {
                path = path.Replace("&pg_no=" + Request["pg_no"], "");
                path = path.Replace("?", "");
                path = "/ProfileDetails?" + path;
            }

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
                    strHTML += " <li><a href=" + path + "&pg_no=1>First</a></li> ";
                    strHTML += " <li><a href=" + path + "&pg_no=" + (intPageNo - 1) + ">Previous</a></li>";
                }
                for (int cnt = startPage; cnt < endPage; cnt++)
                {
                    if (intPageNo == (cnt))
                    {
                        strHTML += " <li class='active'><a href=" + path + "&pg_no=" + (cnt) + ">" + (cnt) + "</a></li> ";
                    }
                    else
                    {
                        strHTML += " <li><a href=" + path + "&pg_no=" + (cnt) + ">" + (cnt) + "</a></li> ";
                    }
                }
                //if (intPageNo != TotalRow)
                //{
                //    strHTML += " <div class='pageing_clo'><a rel='next' href='/SearchResult?PageNo=" + (intPageNo + 1) + "')'>Next</a></div> ";
                //}
                if (currentPage < totalPages)
                {
                    strHTML += " <li> <a href=" + path + "&pg_no=" + (intPageNo + 1) + ">Next</a> </li>";
                    strHTML += " <li> <a href=" + path + "&pg_no=" + totalPages + ">Last</a> </li>";
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
}
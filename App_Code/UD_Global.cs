using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Mail;

/// <summary>
/// Summary description for UD_Global
/// </summary>
public class UD_Global
{
    dbInteraction objdb = new dbInteraction();
    SqlConnection objConnection = new SqlConnection();
    string strSql = "";

    public UD_Global()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCasteList(string searchtext)
    {
        DataTable dtCasteList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_Caste", searchtext);
            dtCasteList = ds.Tables[0];
            return dtCasteList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtCasteList;
    }

    public DataTable GetProfileCreatedBy(string searchtext)
    {
        DataTable dtProfileCreated = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_ProfileCreatedBy", searchtext);            
            dtProfileCreated = ds.Tables[0];
            return dtProfileCreated;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtProfileCreated;
    }

    public DataTable GetBloodGrpList(string searchtext)
    {
        DataTable dtBloodGrp = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_BloodGroup", searchtext);
            dtBloodGrp = ds.Tables[0];
            return dtBloodGrp;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtBloodGrp;
    }

    public DataTable GetVisaStatusList(string searchtext)
    {
        DataTable dtVisaStatus = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_VisaStatus", searchtext);
            dtVisaStatus = ds.Tables[0];
            return dtVisaStatus;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtVisaStatus;
    }

    public DataTable GetEducationList(string searchtext)
    {
        DataTable dtEducationList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_Education", searchtext);
            dtEducationList = ds.Tables[0];
            return dtEducationList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtEducationList;
    }

    public DataTable GetCountryList(string searchtext)
    {
        DataTable dtCountryList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_Country", searchtext);
            dtCountryList = ds.Tables[0];
            return dtCountryList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtCountryList;
    }

    public DataTable GetYearList(int FromYear, int ToYear)
    {
        DataTable dtYearList = new DataTable();
        try
        {
            //GetBirthYearList
            DataSet ds = objdb.ExecuteDataset("GetBirthYearList", FromYear, ToYear);
            dtYearList = ds.Tables[0];
            return dtYearList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtYearList;
    }

    public DataTable GetMaritalStatusList(string searchtext)
    {
        DataTable dtMaritalStatusList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_MaritalStatus_new", searchtext);
            dtMaritalStatusList = ds.Tables[0];
            return dtMaritalStatusList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtMaritalStatusList;
    }

    public DataTable GetMaritalStatusListById(string IdArr)
    {
        DataTable dtMaritalStatusList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Get_MaritalStatus_byId", IdArr);
            dtMaritalStatusList = ds.Tables[0];
            return dtMaritalStatusList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtMaritalStatusList;
    }

    public DataTable GetMemberDetails(long MemberCode)
    {
        DataTable dtMemberDetails = new DataTable();
        try
        {
            dtMemberDetails = objdb.GetDataTable("Select_tbl_MemberMaster " + MemberCode + ",@TotalCount=10");
            //dtMemberDetails = ds.Tables[0];
            return dtMemberDetails;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtMemberDetails;
    }

    public DataTable SearchMemberDetails(string SearchBy, string SearchVal)
    {
        DataTable dtMemberDetails = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Search_tbl_MemberMaster", SearchBy, SearchVal);
            dtMemberDetails = ds.Tables[0];
            //dtMemberDetails = ds.Tables[0];
            return dtMemberDetails;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtMemberDetails;
    }

    public DataTable GetSubCasteList(string CasteCode, string searchtext)
    {
        DataTable dtCasteList = new DataTable();
        try
        {
            //DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_SubCaste", CasteCode, searchtext);
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_SubCaste", CasteCode, searchtext);
            dtCasteList = ds.Tables[0];
            return dtCasteList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtCasteList;
    }

    public DataTable GetHeight()
    {
        DataTable dtHeight = new DataTable();
        try
        {
            DataTable ds = new DataTable();
            string strSql = "SELECT 0 AS HeightCM,'Select' AS Height UNION ALL SELECT HeightCM,Height FROM tbl_Height ORDER BY HeightCM ";
            ds = objdb.GetDataTable(strSql);

            //DataRow row = ds.Tables[0].NewRow();
            //row["HeightCM"] = 0;
            //row["Height"] = "--Select--";
            //ds.Tables[0].Rows.InsertAt(row, 0);
            //dtHeight = ds.Tables[0];
            return ds;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtHeight;
    }

    public DataTable GetOccupationList(string searchtext)
    {
        DataTable dtOccupationList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_Occupation", searchtext);
            dtOccupationList = ds.Tables[0];
            return dtOccupationList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtOccupationList;
    }

    public DataTable GetAnnualIncomeList()
    {
        DataTable dtAnnualIncome = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_AnnualIncome");
            dtAnnualIncome = ds.Tables[0];
            return dtAnnualIncome;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtAnnualIncome;
    }

    public DataTable GetStateCityList(string searchtext, string CountryCode)
    {
        DataTable dtStateCityList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_StateCity", CountryCode, searchtext);
            dtStateCityList = ds.Tables[0];
            return dtStateCityList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtStateCityList;
    }

    public DataTable GetVisaList(string searchtext)
    {
        DataTable dtVisaList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("SelectCombo_tbl_VisaStatus", searchtext);
            dtVisaList = ds.Tables[0];
            return dtVisaList;
        }
        catch (Exception ex)
        {
            throw;
        }
        return dtVisaList;
    }

    public DataTable Load_MFProfileList(int Gender)
    {
        DataTable dtLoad_MFProfileList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Load_MFProfileList", Gender);
            dtLoad_MFProfileList = ds.Tables[0];
            return dtLoad_MFProfileList;
        }
        catch (Exception ex)
        {
            throw;
        }
        return dtLoad_MFProfileList;
    }

    public DataTable Get_UpdateMemberMaster(long MemberCode)
    {
        DataTable dtLoad_MemberDetails = new DataTable();
        DataSet ds = objdb.ExecuteDataset("Select_tbl_UpdateMemberMaster", MemberCode, 1, 10, 10);
        dtLoad_MemberDetails = ds.Tables[0];
        return dtLoad_MemberDetails;
    }

    public DataTable Load_PartnersPreferences(long MemberCode)
    {
        DataTable dtLoad_PartnersPreferences = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_PartnersPreferences", MemberCode);
            dtLoad_PartnersPreferences = ds.Tables[0];
            return dtLoad_PartnersPreferences;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtLoad_PartnersPreferences;
    }

    public DataTable Load_MemberDetails(int isLogedin, long LoginCode, string ProfileID, long MemberCode)
    {
        DataTable dtLoad_MemberDetails = new DataTable();
        try
        {
            if (ProfileID == "")
            {
                LoginCode = 0;
            }
            DataSet ds = objdb.ExecuteDataset("Load_MemberDetails", isLogedin, LoginCode, ProfileID, MemberCode);
            dtLoad_MemberDetails = ds.Tables[0];
            return dtLoad_MemberDetails;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtLoad_MemberDetails;
    }

    public DataTable Load_ProfileList(long MemberCode, int Gender, string AgeStart, string AgeUpto, string MaritalStatusList, string EducationList, string CasteList, string CountryList, string StateCityList, int SqlCondition)
    {
        DataTable dtLoad_ProfileList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Load_ProfileList", "@MemberCode=" + MemberCode, "@Gender=" + Gender, "@AgeStart='" + AgeStart + "'", "@AgeUpto='" + AgeUpto + "'", "@MaritalStatusList='" + MaritalStatusList + "'"
                , "@EducationList='" + EducationList + "'", "@CasteList='" + CasteList + "'", "@StateCityList=''", "@CountryList='" + StateCityList + "'", "@SqlCondition=" + SqlCondition, "@TotalCount=0");
            dtLoad_ProfileList = ds.Tables[0];
            return dtLoad_ProfileList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtLoad_ProfileList;
    }

    public int GetGender(long MemberCode)
    {
        int Gender = 0;
        try
        {
            strSql = "SELECT Gender FROM  tbl_MemberMaster WHERE MemberCode=" + MemberCode;
            Gender = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {
            throw;
        }
        return Gender;
    }

    public string GetListBox_SelectedItem(ListBox _ListBox)
    {
        string StrSelectedItems = "";
        bool isSelected = false;
        try
        {
            for (int cnt = 0; cnt < _ListBox.Items.Count; cnt++)
            {
                if (_ListBox.Items[cnt].Selected == true)
                {
                    isSelected = true;
                    StrSelectedItems = StrSelectedItems + "," + _ListBox.Items[cnt].Value;
                }
            }
            if (StrSelectedItems == "")
            {
                if (_ListBox.Items.Count == 1)
                {
                    isSelected = true;
                    StrSelectedItems = StrSelectedItems + "," + _ListBox.Items[0].Value;
                }
            }

            if (isSelected)
            {
                StrSelectedItems = StrSelectedItems.Substring(1, StrSelectedItems.Length - 1);
            }
            else
            {
                _ListBox.Focus();
            }
        }

        catch (Exception)
        {

            throw;
        }
        return StrSelectedItems;
    }

    public void SelectListBox_Items(ListBox _listBox, string Selected_Items)
    {
        try
        {
            bool isSelected = false;
            string[] Selected_Items_Arr = Selected_Items.Split(',');
            if (Selected_Items_Arr.Length > 0)
            {
                for (int cnt = 0; cnt < Selected_Items_Arr.Length; cnt++)
                {
                    string Insert_Items = Selected_Items_Arr[cnt];
                    for (int cnt_i = 0; cnt_i < _listBox.Items.Count; cnt_i++)
                    {
                        if (Insert_Items.Trim() == _listBox.Items[cnt_i].Text)
                        {
                            _listBox.Items[cnt_i].Selected = true;
                            isSelected = true;
                            break;
                        }
                    }
                }
            }
            if (!isSelected)
            {
                _listBox.Items[0].Selected = true;
            }
        }
        catch (Exception ex)
        {

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

    public bool InsertInterestShown(long MemberCode, long InterestinMemberCode, int isInterested)
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[Insert_tbl_InterestShown]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object        
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, MemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@InterestinMemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, InterestinMemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@isInterested", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, isInterested));

            if (objConnection.State == ConnectionState.Closed)
            {
                // Open connection.
                objConnection.Open();
            }

            // Execute query.
            cmdToExecute.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("InsertUpdate_tbl_PartnersPreferences::Insert::Error occured.", ex);
        }
        finally
        {
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public DataTable GetInterestReceived(long MemberCode, int ShowSendInterestReq)
    {
        DataTable dtInterestReceived = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_InterestReceive", MemberCode);
            dtInterestReceived = ds.Tables[0];
            return dtInterestReceived;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtInterestReceived;
    }

    public DataTable GetInterestSend(long MemberCode, int ShowSendInterestReq)
    {
        DataTable dtInterestReceived = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_InterestSend", ShowSendInterestReq, MemberCode);
            dtInterestReceived = ds.Tables[0];
            return dtInterestReceived;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtInterestReceived;
    }

    public string ChangePassword(long MemberCode, string EmailId, string OldPassword, string NewPassword)
    {
        string IsValid = "";
        DataTable dtResult = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("ChangePassword", EmailId, MemberCode, OldPassword, NewPassword);
            IsValid = "success";
        }
        catch (Exception ex)
        {
            IsValid = ex.Message;
        }
        return IsValid;
    }

    public DataTable GetMemberPhotos(long MemberCode)
    {
        DataTable dtMemberPhotos = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_MemberPhotos", MemberCode);
            dtMemberPhotos = ds.Tables[0];
            return dtMemberPhotos;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtMemberPhotos;
    }

    public DataTable GetSibblingDetails(long MemberCode)
    {
        DataTable dtSibblingDetails = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_SibblingDetails", MemberCode);
            dtSibblingDetails = ds.Tables[0];
            return dtSibblingDetails;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtSibblingDetails;
    }

    public bool Delete_tbl_MemberPhotos(long MemberCode, string PhotoFileName)
    {
        try
        {
            objdb.ExecuteDataset("Delete_tbl_MemberPhotos", MemberCode, PhotoFileName);
            return true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return false;
        }
    }

    public bool Update_tbl_InterestShown(long MemberCode, long InterestinMemberCode, int isInterested)
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[Update_tbl_InterestShown]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object        
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, MemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@InterestinMemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, InterestinMemberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@isInterested", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, isInterested));

            if (objConnection.State == ConnectionState.Closed)
            {
                // Open connection.
                objConnection.Open();
            }

            // Execute query.
            cmdToExecute.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("InsertUpdate_tbl_PartnersPreferences::Insert::Error occured.", ex);
        }
        finally
        {
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public DataTable GetLastLogingDate(long MemberCode)
    {
        DataTable dtLastLoginDate = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_LogTable_memberId", MemberCode);
            dtLastLoginDate = ds.Tables[0];
            return dtLastLoginDate;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtLastLoginDate;
    }

    public bool CheckIsInterested(long MemberCode, long InterestinMemberCode)
    {
        bool IsInterest = false;
        try
        {
            strSql = "select isInterested from tbl_InterestShown where MemberCode=" + MemberCode + " and InterestinMemberCode=" + InterestinMemberCode;
            IsInterest = Convert.ToBoolean(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {

            throw;
        }
        return IsInterest;
    }

    public bool CheckBookMark(long MemberCode, long bookmarkId)
    {
        bool IsBookMark = false;
        try
        {
            strSql = "select count(*) Cnt from tbl_BookmarkList where MemberCode=" + MemberCode + " and BookmarkedProfile like '%" + bookmarkId + "%'";
            IsBookMark = Convert.ToBoolean(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {

            throw;
        }
        return IsBookMark;
    }

    public string GetMaritalStatus(long MemberCode)
    {
        string MaritalStatus = "";
        try
        {
            strSql = " select tbl_MaritalStatus.MaritalStatus from tbl_MemberMaster ";
            strSql += " inner join tbl_MaritalStatus on tbl_MemberMaster.MaritalStatus=tbl_MaritalStatus.MaritalStatusCode ";
            strSql += " where MemberCode=" + MemberCode;
            MaritalStatus = Convert.ToString(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {

            throw;
        }
        return MaritalStatus;
    }

    public string GeMGetMaritalStatus_Preference(long MemberCode)
    {
        string MaritalStatus = "";
        try
        {
            strSql = " Select MStatus_Preference from tbl_MemberMaster where MemberCode=" + MemberCode;
            MaritalStatus = Convert.ToString(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {

            throw;
        }
        return MaritalStatus;
    }

    public int GetAgeDiff(long MemberCode)
    {
        int AgeDiff = 0;
        try
        {
            strSql = " Select isnull(AgeDiff,0) as AgeDiff  from tbl_MemberMaster where MemberCode=" + MemberCode;
            AgeDiff = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return AgeDiff;
    }

    public bool CheckInterest(long MemberCode, long InterestinMemberCode)
    {

        try
        {
            strSql = "SELECT count(*) as Cnt FROM tbl_InterestShown WHERE MemberCode = " + MemberCode + " AND InterestinMemberCode = " + InterestinMemberCode;
            int Cnt = Convert.ToInt32(objdb.ExecuteScalar(strSql));
            if (Cnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public int CheckIsYetMember(long MemberCode)
    {
        int Days = 0;
        try
        {
            strSql = " SELECT dbo.isYetMember(" + MemberCode + ",0 ) as TotalCnt";
            Days = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return Days;
    }

    public bool CheckEmailAlreadyExist(string strEmail, long MemberCode)
    {
        bool isExist = false;
        strSql = " Select Count(*) as Email from tbl_MemberMaster where EmailID='" + strEmail.Trim() + "'";
        if (MemberCode > 0)
        {
            strSql += " and MemberCode!=" + MemberCode;
        }
        int Res = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        if (Res > 0)
        {
            isExist = true;
        }
        else
        {
            isExist = false;
        }
        return isExist;
    }

    public int GetIntrestCnt(long MemberCode)
    {
        int Cnt = 0;
        strSql = "select COUNT(*) as TotalCnt from tbl_InterestShown where MemberCode=" + MemberCode;
        Cnt = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        return Cnt;
    }

    public bool CheckIsUpdateDate(long MemberCode)
    {
        strSql = "select count(*) from tbl_UpdateMemberMaster where MemberCode=" + MemberCode;
        int Cnt = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        if (Cnt > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataTable GetRecommend_ProfileList(int Gender, int FromAge, int ToAge, int MaritalStatus)
    {
        DataTable dtRecommendProfileList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Load_Recommend_ProfileList", Gender, FromAge, ToAge, MaritalStatus);
            dtRecommendProfileList = ds.Tables[0];
            return dtRecommendProfileList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtRecommendProfileList;
    }

    public string GetPassword(long MemberCode)
    {
        string password = "";
        try
        {
            strSql = "select Password from tbl_membermaster where MemberCode =" + MemberCode;
            password = Convert.ToString(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {

            throw;
        }
        return password;
    }

    public int GetProfileCreatedId_Name(string profileCreatedBy)
    {
        int ProfileCreatedCode = 0;
        try
        {
            strSql = " select * from tbl_ProfileCreatedBy where profileCreatedBy='" + profileCreatedBy.ToString().Trim() + "'";
            ProfileCreatedCode = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {
            throw;
        }
        return ProfileCreatedCode;
    }

    public int GetProfileCreatedId_Id(string profileCreatedBy_Id)
    {
        int ProfileCreatedCode = 0;
        try
        {
            strSql = " select * from tbl_ProfileCreatedBy where ProfileCreatedByCode='" + profileCreatedBy_Id + "'";
            ProfileCreatedCode = Convert.ToInt32(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return ProfileCreatedCode;
    }

    public string SendSMS(string MobileNo, string strMsg)
    {
        string authKey = System.Configuration.ConfigurationManager.AppSettings["authKey"];
        string strResult = "";
        string senderId = System.Configuration.ConfigurationManager.AppSettings["senderId"];
        string sendSMSUri = System.Configuration.ConfigurationManager.AppSettings["sendSMSUri"];

        try
        {
            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", MobileNo);
            sbPostData.AppendFormat("&message={0}", strMsg);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "4");

            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
            //Prepare and Add URL Encoded data
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(sbPostData.ToString());
            //Specify post method
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;
            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            //Get the response
            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            strResult = response.ToString();
            //Close the response
            reader.Close();
            response.Close();
        }
        catch (Exception ex)
        {
            strResult = ex.Message.ToString();
        }
        return strResult;
    }

    public string GetProfileId(int MemberCode)
    {
        string ProfileId = "";
        try
        {
            strSql = " Select profileid from tbl_membermaster where membercode=" + MemberCode;
            ProfileId = Convert.ToString(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return ProfileId;
    }

    public bool GetUploadPhotoStatus(long MemberCode)
    {
        bool IsUpload = true;
        try
        {
            DataSet ds = objdb.ExecuteDataset("sp_GetUploadPhotoPending", " AND MEMBERCODE=" + MemberCode);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IsUpload = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write("UD_Global::GetUploadPhotoStatus :: " + ex.Message);
        }
        return IsUpload;
    }

    public DataTable GetMemberDetails_Email_Mobile(string Email, string Mobile)
    {
        DataTable dtMemberDetails = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("CheckMobileEmail", " where emailId='" + Email + "' and MobileNo like '%" + Mobile + "%'");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtMemberDetails = ds.Tables[0];
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write("UD_Global::GetUploadPhotoStatus :: " + ex.Message);
        }
        return dtMemberDetails;
    }

    public bool UpdateMarriedConfirm(long MemberCode, bool YesNo)
    {
        try
        {
            if (YesNo == true)
            {
                strSql = "UPDATE tbl_membermaster SET Married=1 WHERE MemberCode=" + MemberCode;
            }
            else
            {
                strSql = "UPDATE tbl_membermaster SET Married=2 WHERE MemberCode=" + MemberCode;
            }
            objdb.ExecuteNonQuery(strSql);
            return true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return false;
        }
    }

    public bool SendMail(string ToEmailAddres, string MailSubject, string MailBody, bool HTML, string FromMianAdd, string Password)
    {

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("anantmatrimony.com");

            mail.From = new MailAddress(FromMianAdd);
            mail.To.Add(ToEmailAddres);
            //mail.CC.Add("sanket164@gmail.com");
            mail.Subject = MailSubject;
            mail.Body = MailBody;
            //Attachment attachment = new Attachment(filename);
            //mail.Attachments.Add(attachment);
            if (HTML)
            {
                mail.IsBodyHtml = true;
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(FromMianAdd, Password);
            SmtpServer.EnableSsl = false;

            SmtpServer.Send(mail);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool SaveQueryBox(string SenderName, string Email, string Mobile, string SenderMessage)
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_Query]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object        
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MessageCode", SqlDbType.Int, 10, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, 0));
            cmdToExecute.Parameters.Add(new SqlParameter("@Surname", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ""));
            cmdToExecute.Parameters.Add(new SqlParameter("@SenderName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SenderName));
            cmdToExecute.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ""));
            cmdToExecute.Parameters.Add(new SqlParameter("@ContactNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Mobile));
            cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Email));
            cmdToExecute.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime, 15, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, DateTime.Now));
            cmdToExecute.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ""));
            cmdToExecute.Parameters.Add(new SqlParameter("@SenderMessage", SqlDbType.NVarChar, 300, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, SenderMessage));
            cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));

            if (objConnection.State == ConnectionState.Closed)
            {
                // Open connection.
                objConnection.Open();
            }

            // Execute query.
            cmdToExecute.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("SaveQueryBox::Insert::Error occured.", ex);
        }
        finally
        {
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public bool CheckAlreadyInsertAndIsActiveNew(long MemberCode)
    {

        try
        {
            strSql = "SELECT COUNT(*) FROM tbl_membermaster WHERE membercode=" + MemberCode + " AND isActive=0";
            int CNT = Convert.ToInt32(objdb.ExecuteScalar(strSql));
            if (CNT > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return false;
        }
    }

    public DataSet GET_Delete_Photos_List(string strCondition)
    {
        DataSet ds = null;
        try
        {
            ds = objdb.ExecuteDataset("sp_GetPhotosDeleteList", strCondition);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return ds;
    }

    public bool Insert_tbl_ProfilevisitLog(long MemberCode, string VisitProfileId)
    {
        try
        {
            bool RecExist = false;
            string strVisitProfileLog = "";
            DataTable dtProfilevisitLog = Get_tbl_ProfilevisitLog(MemberCode);

            //if (dtProfilevisitLog.Rows.Count > 0)
            //{
            //    RecExist = true;
            //    strVisitProfileLog = Convert.ToString(dtProfilevisitLog.Rows[0]["VisitProfileId"]);
            //}
            //strVisitProfileLog = strVisitProfileLog + "," + VisitProfileId;
            //if (!RecExist)
            //{
            //    strVisitProfileLog = strVisitProfileLog.Substring(1, strVisitProfileLog.Length - 1);
            //}
            //if (!CheckProfilevisitLog(MemberCode, VisitProfileId))
            //{

            objdb.ExecuteDataset("InsertUpdate_tbl_ProfilevisitLog_new", MemberCode, VisitProfileId);
            //}


            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public DataTable Get_tbl_ProfilevisitLog(long MemberCode)
    {
        DataTable dtProfilevisitLog = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_ProfilevisitLog", MemberCode);
            dtProfilevisitLog = ds.Tables[0];
            return dtProfilevisitLog;
        }
        catch (Exception ex)
        {
            throw;
        }
        return dtProfilevisitLog;
    }

    public bool CheckProfilevisitLog(long MemberCode, string VisitProfileId)
    {
        bool IsBookMark = false;
        try
        {
            strSql = "select count(*) Cnt from tbl_ProfilevisitLog where MemberCode=" + MemberCode + " and VisitProfileId like '%" + VisitProfileId + "%'";
            IsBookMark = Convert.ToBoolean(objdb.ExecuteScalar(strSql));
        }
        catch (Exception ex)
        {

            throw;
        }
        return IsBookMark;
    }

    public DataTable GetExperienceDate(long MemberCode)
    {
        DataTable dtData = new DataTable();
        try
        {
            dtData = objdb.GetDataTable("sp_ExpiredMembership ' and ms.membercode=" + MemberCode + " and getDate() between MS.StartDate and MS.EndDate ' ");
            //dtMemberDetails = ds.Tables[0];
            return dtData;
        }
        catch (Exception ex)
        {   
            throw;
        }
        return dtData;
    }

}
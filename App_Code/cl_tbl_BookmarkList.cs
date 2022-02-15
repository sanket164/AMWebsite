using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cl_tbl_BookmarkList
/// </summary>
public class cl_tbl_BookmarkList
{
    dbInteraction objdb = new dbInteraction();
    SqlConnection objConnection = new SqlConnection();
    public cl_tbl_BookmarkList()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable Load_BookmasterList(string bookmasterList)
    {
        DataTable dtBookmasterList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Load_BookmarkList", bookmasterList);
            dtBookmasterList = ds.Tables[0];
            //dtMemberDetails = ds.Tables[0];
            return dtBookmasterList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtBookmasterList;
    }

    public DataTable Load_BookmasterList_New(string bookmasterList, int intPageNo,out int TotalCnt)
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[Load_BookmarkListPagination]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            if (intPageNo == 0)
            {
                intPageNo = 1;
            }

            cmdToExecute.Parameters.Add(new SqlParameter("@BookmarkList", SqlDbType.VarChar, 4000, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, bookmasterList));            
            cmdToExecute.Parameters.Add(new SqlParameter("@PageNo", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, intPageNo));
            cmdToExecute.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 8));
            cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 10, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, 0));
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
            TotalCnt = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);
            return dtData;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Load_BookmasterList_New::Get Values::Error occured.", ex);
        }
        finally
        {
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public DataTable GetBookMarkList(long MemberCode)
    {
        DataTable dtBookmarkList = new DataTable();
        try
        {
            DataSet ds = objdb.ExecuteDataset("Select_tbl_BookmarkList", MemberCode);
            dtBookmarkList = ds.Tables[0];
            return dtBookmarkList;
        }
        catch (Exception ex)
        {

            throw;
        }
        return dtBookmarkList;
    }

    public bool InsertUpdate_tbl_BookmarkList(long MemberCode, string BookmarkedProfile)
    {
        try
        {
            objdb.ExecuteDataset("InsertUpdate_tbl_BookmarkList", MemberCode, BookmarkedProfile);
            return true;
        }
        catch (Exception ex)
        {
            return false;
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
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dbInteraction
/// </summary>

public class dbInteraction
{
    SqlConnection objConnection = new SqlConnection();

    public dbInteraction()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetConnStr()
    {
        string str = "";
        try
        {
            objConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["nsConn"].ToString();
            objConnection.Open();
            return str;
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::GetConnStr::Error occured.", ex);
        }
        return str;
    }

    public DataTable GetDataTable(string strSQl)
    {
        DataTable dtData = new DataTable();
        try
        {
            if (objConnection.State == ConnectionState.Closed)
            {
                GetConnStr();
            }
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = strSQl;
            scmCmdToExecute.CommandType = CommandType.Text;
            scmCmdToExecute.Connection = objConnection;
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);
            sdaAdapter.Fill(dtData);
            CloseConnection();
            return dtData;
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::GetDataTable::Error occured.", ex);
        }
        return dtData;
    }

    public DataTable GetDataTable(string strSQl, SqlTransaction objTransaction)
    {
        DataTable dtData = new DataTable();
        try
        {
            if (objConnection.State == ConnectionState.Closed)
            {
                GetConnStr();
            }
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.CommandText = strSQl;
            scmCmdToExecute.CommandType = CommandType.Text;
            scmCmdToExecute.Connection = objConnection;
            scmCmdToExecute.Transaction = objTransaction;
            SqlDataAdapter sdaAdapter = new SqlDataAdapter(scmCmdToExecute);
            sdaAdapter.Fill(dtData);
            CloseConnection();
            return dtData;
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::GetDataTable::Error occured.", ex);
        }
        return dtData;
    }

    public int ExecuteNonQuery(string SqlStr)
    {
        int Result = 0;
        try
        {
            if (objConnection.State == ConnectionState.Closed)
            {
                GetConnStr();
            }
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.Connection = objConnection;
            scmCmdToExecute.CommandText = SqlStr;
            Result = scmCmdToExecute.ExecuteNonQuery();
            CloseConnection();
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::ExecuteNonQuery::Error occured.", ex);
        }
        return Result;
    }

    public int ExecuteNonQuery(string SqlStr, SqlTransaction objTransaction)
    {
        int Result = 0;
        try
        {
            if (objConnection.State == ConnectionState.Closed)
            {
                GetConnStr();
            }
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.Connection = objConnection;
            scmCmdToExecute.Transaction = objTransaction;
            scmCmdToExecute.CommandText = SqlStr;
            Result = scmCmdToExecute.ExecuteNonQuery();
            CloseConnection();
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::ExecuteNonQuery::Error occured.", ex);
        }
        return Result;
    }

    public object ExecuteScalar(string SqlStr)
    {
        object obj = new object();
        try
        {
            if (objConnection.State == ConnectionState.Closed)
            {
                GetConnStr();
            }
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.Connection = objConnection;
            scmCmdToExecute.CommandText = SqlStr;
            obj = scmCmdToExecute.ExecuteScalar();
            CloseConnection();
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::ExecuteScalar::Error occured.", ex);
        }
        return obj;
    }

    public object ExecuteScalar(string SqlStr, SqlTransaction objTransaction)
    {
        object obj = new object();
        try
        {
            if (objConnection.State == ConnectionState.Closed)
            {
                GetConnStr();
            }
            SqlCommand scmCmdToExecute = new SqlCommand();
            scmCmdToExecute.Connection = objConnection;
            scmCmdToExecute.Transaction = objTransaction;
            scmCmdToExecute.CommandText = SqlStr;
            obj = scmCmdToExecute.ExecuteScalar();
            CloseConnection();
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::ExecuteScalar::Error occured.", ex);
        }
        return obj;
    }

    public void CloseConnection()
    {
        if (objConnection != null)
        {
            objConnection.Close();
        }
    }

    public DataSet ExecuteDataset(string spName, params object[] parameterValues)
    {

        SqlParameter[] commandParameters = null;

        if (parameterValues != null & parameterValues.Length > 0)
        {

            commandParameters = GetParametersSetFromSp(spName);

            AssignParameterValues(commandParameters, parameterValues);

            return ExecuteDataset(CommandType.StoredProcedure, spName, commandParameters);
        }
        else
        {
            return ExecuteDataset(CommandType.StoredProcedure, spName);
        }
    }

    public SqlParameter[] GetParametersSetFromSp(string spName)
    {
        if (objConnection.State == ConnectionState.Closed)
        {
            GetConnStr();
        }
        SqlCommand cmd = new SqlCommand(spName, objConnection);
        SqlParameter[] spParameters = null;

        try
        {
            //cn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            cmd.Parameters.RemoveAt(0);
            spParameters = new SqlParameter[cmd.Parameters.Count];
            cmd.Parameters.CopyTo(spParameters, 0);
            cmd.Parameters.Clear();
        }
        finally
        {
            cmd.Dispose();
            CloseConnection();
        }

        return spParameters;

    } //GetParametersSetFromSp

    public void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
    {

        int i = 0;
        int j = 0;

        if ((commandParameters == null) & (parameterValues == null))
        {
            return;
        }

        j = commandParameters.Length - 1;
        for (i = 0; i <= j; i++)
        {
            if (i <= parameterValues.GetUpperBound(0))
            {
                commandParameters[i].Value = parameterValues[i];
            }
            else
            {
                commandParameters[i].Value = null;
            }
        }

    } //AssignParameterValues

    public DataSet ExecuteDataset(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        try
        {
            if (objConnection.State == ConnectionState.Closed)
            {
                GetConnStr();
            }
            return ExecuteDataset(objConnection, commandType, commandText, commandParameters);
        }
        finally
        {
            CloseConnection();
        }
    } //ExecuteDataset

    public DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataAdapter da = null;

        PrepareCommand(cmd, connection, commandType, commandText, commandParameters);

        da = new SqlDataAdapter(cmd);

        da.Fill(ds);

        cmd.Parameters.Clear();

        return ds;

    } //ExecuteDataset

    public void PrepareCommand(SqlCommand command, SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters)
    {

        //if the provided connection is not open, we will open it
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        command.Connection = connection;

        command.CommandText = commandText;

        command.CommandType = commandType;

        if (commandParameters != null)
        {
            AttachParameters(command, commandParameters);
        }

        return;
    } //PrepareCommand

    public void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
    {

        command.Parameters.Clear();

        //INSTANT C# NOTE: Commented this declaration since looping variables in 'foreach' loops are declared in the 'foreach' header in C#
        //			SqlParameter p = null;
        foreach (SqlParameter p in commandParameters)
        {
            command.Parameters.Add(p);
        }

    } //AttachParameters



}

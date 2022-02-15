using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

/// <summary>
/// Summary description for cl_tbl_PartnersPreferences
/// </summary>
public class cl_tbl_PartnersPreferences
{
    #region Class Member Declarations
    private SqlInt32 _diet, _annualIncome, _annualIncomeCurrency, _smoke, _manglik, _drink, _haveChildren, _ageTo, _ageFrom, _heightFrom, _heightTo;
    private SqlDecimal _memberCode;
    int _RetVal;
    private SqlString _workingWith, _healthProblem, _aboutPartner, _bodyType, _complexion, _caste, _subCaste, _motherTongue, _maritalStatus, _religion, _education, _occupation, _residencyStatus, _countryLivingIn, _stateCity;
    #endregion

    SqlConnection objConnection = new SqlConnection();

	public cl_tbl_PartnersPreferences()
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
            return str;
        }
        catch (Exception ex)
        {
            throw new Exception("dbInteraction::GetConnStr::Error occured.", ex);
        }
        return str;
    }

    public bool Insert()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_PartnersPreferences]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeFrom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ageFrom));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ageTo));
            cmdToExecute.Parameters.Add(new SqlParameter("@HeightFrom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _heightFrom));
            cmdToExecute.Parameters.Add(new SqlParameter("@HeightTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _heightTo));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _maritalStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@HaveChildren", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _haveChildren));
            cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _religion));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _motherTongue));
            cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _caste));
            cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _subCaste));
            cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _manglik));
            cmdToExecute.Parameters.Add(new SqlParameter("@CountryLivingIn", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _countryLivingIn));
            cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _stateCity));
            cmdToExecute.Parameters.Add(new SqlParameter("@ResidencyStatus", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _residencyStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _education));
            cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _occupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _workingWith));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncomeCurrency));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncome));
            cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _diet));
            cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _smoke));
            cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _drink));
            cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _bodyType));
            cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _complexion));
            cmdToExecute.Parameters.Add(new SqlParameter("@HealthProblem", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _healthProblem));
            cmdToExecute.Parameters.Add(new SqlParameter("@AboutPartner", SqlDbType.VarChar, 2500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aboutPartner));

            cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _RetVal));

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

    public bool Insert_UpdatePartnersPreferences()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_UpdatePartnersPreferences]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeFrom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ageFrom));
            cmdToExecute.Parameters.Add(new SqlParameter("@AgeTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _ageTo));
            cmdToExecute.Parameters.Add(new SqlParameter("@HeightFrom", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _heightFrom));
            cmdToExecute.Parameters.Add(new SqlParameter("@HeightTo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _heightTo));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _maritalStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@HaveChildren", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _haveChildren));
            cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _religion));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _motherTongue));
            cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _caste));
            cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _subCaste));
            cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _manglik));
            cmdToExecute.Parameters.Add(new SqlParameter("@CountryLivingIn", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _countryLivingIn));
            cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _stateCity));
            cmdToExecute.Parameters.Add(new SqlParameter("@ResidencyStatus", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _residencyStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _education));
            cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _occupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _workingWith));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncomeCurrency));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncome));
            cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _diet));
            cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _smoke));
            cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _drink));
            cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _bodyType));
            cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _complexion));
            cmdToExecute.Parameters.Add(new SqlParameter("@HealthProblem", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _healthProblem));
            cmdToExecute.Parameters.Add(new SqlParameter("@AboutPartner", SqlDbType.VarChar, 2500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aboutPartner));

            //cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _RetVal));

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

    #region Class Property Declarations
    public SqlDecimal MemberCode
    {
        get
        {
            return _memberCode;
        }
        set
        {
            SqlDecimal memberCodeTmp = (SqlDecimal)value;
            if (memberCodeTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MemberCode", "MemberCode can't be NULL");
            }
            _memberCode = value;
        }
    }


    public SqlInt32 AgeFrom
    {
        get
        {
            return _ageFrom;
        }
        set
        {
            SqlInt32 ageFromTmp = (SqlInt32)value;
            if (ageFromTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("AgeFrom", "AgeFrom can't be NULL");
            }
            _ageFrom = value;
        }
    }


    public SqlInt32 AgeTo
    {
        get
        {
            return _ageTo;
        }
        set
        {
            SqlInt32 ageToTmp = (SqlInt32)value;
            if (ageToTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("AgeTo", "AgeTo can't be NULL");
            }
            _ageTo = value;
        }
    }


    public SqlInt32 HeightFrom
    {
        get
        {
            return _heightFrom;
        }
        set
        {
            SqlInt32 heightFromTmp = (SqlInt32)value;
            if (heightFromTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("HeightFrom", "HeightFrom can't be NULL");
            }
            _heightFrom = value;
        }
    }


    public SqlInt32 HeightTo
    {
        get
        {
            return _heightTo;
        }
        set
        {
            SqlInt32 heightToTmp = (SqlInt32)value;
            if (heightToTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("HeightTo", "HeightTo can't be NULL");
            }
            _heightTo = value;
        }
    }


    public SqlString MaritalStatus
    {
        get
        {
            return _maritalStatus;
        }
        set
        {
            SqlString maritalStatusTmp = (SqlString)value;
            if (maritalStatusTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MaritalStatus", "MaritalStatus can't be NULL");
            }
            _maritalStatus = value;
        }
    }


    public SqlInt32 HaveChildren
    {
        get
        {
            return _haveChildren;
        }
        set
        {
            SqlInt32 haveChildrenTmp = (SqlInt32)value;
            if (haveChildrenTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("HaveChildren", "HaveChildren can't be NULL");
            }
            _haveChildren = value;
        }
    }


    public SqlString Religion
    {
        get
        {
            return _religion;
        }
        set
        {
            SqlString religionTmp = (SqlString)value;
            if (religionTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Religion", "Religion can't be NULL");
            }
            _religion = value;
        }
    }


    public SqlString MotherTongue
    {
        get
        {
            return _motherTongue;
        }
        set
        {
            SqlString motherTongueTmp = (SqlString)value;
            if (motherTongueTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MotherTongue", "MotherTongue can't be NULL");
            }
            _motherTongue = value;
        }
    }


    public SqlString Caste
    {
        get
        {
            return _caste;
        }
        set
        {
            SqlString casteTmp = (SqlString)value;
            if (casteTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Caste", "Caste can't be NULL");
            }
            _caste = value;
        }
    }


    public SqlString SubCaste
    {
        get
        {
            return _subCaste;
        }
        set
        {
            SqlString subCasteTmp = (SqlString)value;
            if (subCasteTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("SubCaste", "SubCaste can't be NULL");
            }
            _subCaste = value;
        }
    }


    public SqlInt32 Manglik
    {
        get
        {
            return _manglik;
        }
        set
        {
            SqlInt32 manglikTmp = (SqlInt32)value;
            if (manglikTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Manglik", "Manglik can't be NULL");
            }
            _manglik = value;
        }
    }


    public SqlString CountryLivingIn
    {
        get
        {
            return _countryLivingIn;
        }
        set
        {
            SqlString countryLivingInTmp = (SqlString)value;
            if (countryLivingInTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("CountryLivingIn", "CountryLivingIn can't be NULL");
            }
            _countryLivingIn = value;
        }
    }


    public SqlString StateCity
    {
        get
        {
            return _stateCity;
        }
        set
        {
            SqlString stateCityTmp = (SqlString)value;
            if (stateCityTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("StateCity", "StateCity can't be NULL");
            }
            _stateCity = value;
        }
    }


    public SqlString ResidencyStatus
    {
        get
        {
            return _residencyStatus;
        }
        set
        {
            SqlString residencyStatusTmp = (SqlString)value;
            if (residencyStatusTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("ResidencyStatus", "ResidencyStatus can't be NULL");
            }
            _residencyStatus = value;
        }
    }


    public SqlString Education
    {
        get
        {
            return _education;
        }
        set
        {
            SqlString educationTmp = (SqlString)value;
            if (educationTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Education", "Education can't be NULL");
            }
            _education = value;
        }
    }


    public SqlString Occupation
    {
        get
        {
            return _occupation;
        }
        set
        {
            SqlString occupationTmp = (SqlString)value;
            if (occupationTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Occupation", "Occupation can't be NULL");
            }
            _occupation = value;
        }
    }


    public SqlString WorkingWith
    {
        get
        {
            return _workingWith;
        }
        set
        {
            SqlString workingWithTmp = (SqlString)value;
            if (workingWithTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("WorkingWith", "WorkingWith can't be NULL");
            }
            _workingWith = value;
        }
    }


    public SqlInt32 AnnualIncomeCurrency
    {
        get
        {
            return _annualIncomeCurrency;
        }
        set
        {
            SqlInt32 annualIncomeCurrencyTmp = (SqlInt32)value;
            if (annualIncomeCurrencyTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("AnnualIncomeCurrency", "AnnualIncomeCurrency can't be NULL");
            }
            _annualIncomeCurrency = value;
        }
    }


    public SqlInt32 AnnualIncome
    {
        get
        {
            return _annualIncome;
        }
        set
        {
            SqlInt32 annualIncomeTmp = (SqlInt32)value;
            if (annualIncomeTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("AnnualIncome", "AnnualIncome can't be NULL");
            }
            _annualIncome = value;
        }
    }


    public SqlInt32 Diet
    {
        get
        {
            return _diet;
        }
        set
        {
            SqlInt32 dietTmp = (SqlInt32)value;
            if (dietTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Diet", "Diet can't be NULL");
            }
            _diet = value;
        }
    }


    public SqlInt32 Smoke
    {
        get
        {
            return _smoke;
        }
        set
        {
            SqlInt32 smokeTmp = (SqlInt32)value;
            if (smokeTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Smoke", "Smoke can't be NULL");
            }
            _smoke = value;
        }
    }


    public SqlInt32 Drink
    {
        get
        {
            return _drink;
        }
        set
        {
            SqlInt32 drinkTmp = (SqlInt32)value;
            if (drinkTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Drink", "Drink can't be NULL");
            }
            _drink = value;
        }
    }


    public SqlString BodyType
    {
        get
        {
            return _bodyType;
        }
        set
        {
            SqlString bodyTypeTmp = (SqlString)value;
            if (bodyTypeTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("BodyType", "BodyType can't be NULL");
            }
            _bodyType = value;
        }
    }


    public SqlString Complexion
    {
        get
        {
            return _complexion;
        }
        set
        {
            SqlString complexionTmp = (SqlString)value;
            if (complexionTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Complexion", "Complexion can't be NULL");
            }
            _complexion = value;
        }
    }


    public SqlString HealthProblem
    {
        get
        {
            return _healthProblem;
        }
        set
        {
            SqlString healthProblemTmp = (SqlString)value;
            if (healthProblemTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("HealthProblem", "HealthProblem can't be NULL");
            }
            _healthProblem = value;
        }
    }


    public SqlString AboutPartner
    {
        get
        {
            return _aboutPartner;
        }
        set
        {
            SqlString aboutPartnerTmp = (SqlString)value;
            if (aboutPartnerTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("AboutPartner", "AboutPartner can't be NULL");
            }
            _aboutPartner = value;
        }
    }

    public Int32 RetVal
    {
        get
        {
            return _RetVal;
        }
        set
        {
            Int32 RetValTmp = (Int32)value;
            _RetVal = value;
        }
    }
    #endregion

}
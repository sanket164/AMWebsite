using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

/// <summary>
/// Summary description for cl_tbl_MemberMaster
/// </summary>
public class cl_tbl_MemberMaster
{
    #region Class Member Declarations
    private SqlBoolean _liveChildrenTogether, _isEdit;
    private SqlDateTime _dateofBirth, _timeofBirth, _registerDate;
    private SqlInt32 _religion, _familyValues, _manglik, _nakshtra, _rashi, _subCaste, _caste, _motherTongue, _familyType, _gotra, _education, _drink, _diet, _smoke, _mStatus, _isActive, _workingWith, _occupation, _workingAs, _annualIncome, _annualIncomeCurrency, _healthInformation, _bodyType, _complexion, _bloodGroup, _anyDisability, _weight, _gender, _profileCreatedBy, _maritalStatus, _height, _noOfChildren, _visaStatus, _stateCity, _country;
    private SqlDecimal _memberCode, _visaCountry;
    int _RetVal, _TotalCount;
    private SqlString _mobileNo1, _aboutInfo, _memberName, _password, _emailID, _degree, _occupationDtls, _fileNote, _profileID, _choice, _remarks, _landlineNo1, _homeAddress2, _homeAddress1, _motherName, _motherOccupation, _mosalPlace, _nativePlace, _fatherOccupation, _landlineNo, _secondaryEmailID, _birthPlace, _fatherName, _mobileNo, _workAddress, _RetProfileID, _RetPassword;

    private SqlString _PhotoFileName, _MobileNo_Rel, _MobileNo1_Rel, _MobileNo2_Rel, _LandlineNo1_Rel;
    #endregion

    SqlConnection objConnection = new SqlConnection();

    public cl_tbl_MemberMaster()
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
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_MemberMaster_web]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            //cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.BigInt, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@ProfileID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _profileID));
            cmdToExecute.Parameters.Add(new SqlParameter("@ProfileCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _profileCreatedBy));
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _memberName));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _gender));
            cmdToExecute.Parameters.Add(new SqlParameter("@DateofBirth", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dateofBirth));
            cmdToExecute.Parameters.Add(new SqlParameter("@TimeofBirth", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _timeofBirth));
            cmdToExecute.Parameters.Add(new SqlParameter("@BirthPlace", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _birthPlace));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _maritalStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@NoOfChildren", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _noOfChildren));
            cmdToExecute.Parameters.Add(new SqlParameter("@LiveChildrenTogether", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _liveChildrenTogether));
            cmdToExecute.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _height));
            cmdToExecute.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _weight));
            cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _bodyType));
            cmdToExecute.Parameters.Add(new SqlParameter("@HealthInformation", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _healthInformation));
            cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _complexion));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnyDisability", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _anyDisability));
            cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _bloodGroup));
            cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress1", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _homeAddress1));
            cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress2", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _homeAddress2));
            cmdToExecute.Parameters.Add(new SqlParameter("@VisaStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _visaStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _country));
            cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _stateCity));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mobileNo));
            cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _landlineNo));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo1", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mobileNo1));
            cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo1", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _landlineNo1));
            cmdToExecute.Parameters.Add(new SqlParameter("@SecondaryEmailID", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _secondaryEmailID));
            cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _religion));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _motherTongue));
            cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _caste));
            cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _subCaste));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gotra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _gotra));
            cmdToExecute.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fatherName));
            cmdToExecute.Parameters.Add(new SqlParameter("@FatherOccupation", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fatherOccupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _motherName));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherOccupation", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _motherOccupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@MosalPlace", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mosalPlace));
            cmdToExecute.Parameters.Add(new SqlParameter("@NativePlace", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nativePlace));
            cmdToExecute.Parameters.Add(new SqlParameter("@FamilyType", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _familyType));
            cmdToExecute.Parameters.Add(new SqlParameter("@FamilyValues", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _familyValues));
            cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _manglik));
            cmdToExecute.Parameters.Add(new SqlParameter("@Nakshtra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nakshtra));
            cmdToExecute.Parameters.Add(new SqlParameter("@Rashi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _rashi));
            cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _education));
            cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _occupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _workingWith));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkingAs", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _workingAs));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkAddress", SqlDbType.VarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _workAddress));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncomeCurrency));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncome));
            cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _diet));
            cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _drink));
            cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _smoke));
            cmdToExecute.Parameters.Add(new SqlParameter("@AboutInfo", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aboutInfo));
            cmdToExecute.Parameters.Add(new SqlParameter("@EmailID", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _emailID));
            cmdToExecute.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _password));
            cmdToExecute.Parameters.Add(new SqlParameter("@RegisterDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _registerDate));
            cmdToExecute.Parameters.Add(new SqlParameter("@isActive", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _isActive));
            cmdToExecute.Parameters.Add(new SqlParameter("@Choice", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _choice));
            cmdToExecute.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _remarks));
            cmdToExecute.Parameters.Add(new SqlParameter("@Degree", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _degree));
            cmdToExecute.Parameters.Add(new SqlParameter("@OccupationDtls", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _occupationDtls));
            cmdToExecute.Parameters.Add(new SqlParameter("@VisaCountry", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _visaCountry));
            cmdToExecute.Parameters.Add(new SqlParameter("@mStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _mStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@FileNote", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fileNote));

            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MobileNo_Rel));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo1_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MobileNo1_Rel));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo2_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MobileNo2_Rel));
            cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo1_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _LandlineNo1_Rel));

            cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _RetVal));
            cmdToExecute.Parameters.Add(new SqlParameter("@RetProfileID", SqlDbType.VarChar, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _RetProfileID));
            cmdToExecute.Parameters.Add(new SqlParameter("@RetPassword", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _RetPassword));



            if (objConnection.State == ConnectionState.Closed)
            {
                // Open connection.
                objConnection.Open();
            }
            // Execute query.
            cmdToExecute.ExecuteNonQuery();

            _RetVal = Convert.ToInt32(cmdToExecute.Parameters["@RetVal"].Value);
            _memberCode = _RetVal;
            _RetProfileID = Convert.ToString(cmdToExecute.Parameters["@RetProfileID"].Value);
            _RetPassword = Convert.ToString(cmdToExecute.Parameters["@RetPassword"].Value);

            return true;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception(ex.Message.ToString());
        }
        finally
        {
            // Close connection.
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public bool Insert_UpdateMemberMaster()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_UpdateMemberMaster_WEB]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            //cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.BigInt, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@ProfileID", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _profileID));
            cmdToExecute.Parameters.Add(new SqlParameter("@ProfileCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _profileCreatedBy));
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _memberName));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _gender));
            cmdToExecute.Parameters.Add(new SqlParameter("@DateofBirth", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dateofBirth));
            cmdToExecute.Parameters.Add(new SqlParameter("@TimeofBirth", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _timeofBirth));
            cmdToExecute.Parameters.Add(new SqlParameter("@BirthPlace", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _birthPlace));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _maritalStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@NoOfChildren", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _noOfChildren));
            cmdToExecute.Parameters.Add(new SqlParameter("@LiveChildrenTogether", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _liveChildrenTogether));
            cmdToExecute.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _height));
            cmdToExecute.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _weight));
            cmdToExecute.Parameters.Add(new SqlParameter("@BodyType", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _bodyType));
            cmdToExecute.Parameters.Add(new SqlParameter("@HealthInformation", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _healthInformation));
            cmdToExecute.Parameters.Add(new SqlParameter("@Complexion", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _complexion));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnyDisability", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _anyDisability));
            cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _bloodGroup));
            cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress1", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _homeAddress1));
            cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress2", SqlDbType.VarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _homeAddress2));
            cmdToExecute.Parameters.Add(new SqlParameter("@VisaStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _visaStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@Country", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _country));
            cmdToExecute.Parameters.Add(new SqlParameter("@StateCity", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _stateCity));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mobileNo));
            cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _landlineNo));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo1", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mobileNo1));
            cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo1", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _landlineNo1));
            cmdToExecute.Parameters.Add(new SqlParameter("@SecondaryEmailID", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _secondaryEmailID));
            cmdToExecute.Parameters.Add(new SqlParameter("@Religion", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _religion));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherTongue", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _motherTongue));
            cmdToExecute.Parameters.Add(new SqlParameter("@Caste", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _caste));
            cmdToExecute.Parameters.Add(new SqlParameter("@SubCaste", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _subCaste));
            cmdToExecute.Parameters.Add(new SqlParameter("@Gotra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _gotra));
            cmdToExecute.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fatherName));
            cmdToExecute.Parameters.Add(new SqlParameter("@FatherOccupation", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fatherOccupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _motherName));
            cmdToExecute.Parameters.Add(new SqlParameter("@MotherOccupation", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _motherOccupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@MosalPlace", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mosalPlace));
            cmdToExecute.Parameters.Add(new SqlParameter("@NativePlace", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nativePlace));
            cmdToExecute.Parameters.Add(new SqlParameter("@FamilyType", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _familyType));
            cmdToExecute.Parameters.Add(new SqlParameter("@FamilyValues", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _familyValues));
            cmdToExecute.Parameters.Add(new SqlParameter("@Manglik", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _manglik));
            cmdToExecute.Parameters.Add(new SqlParameter("@Nakshtra", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _nakshtra));
            cmdToExecute.Parameters.Add(new SqlParameter("@Rashi", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _rashi));
            cmdToExecute.Parameters.Add(new SqlParameter("@Education", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _education));
            cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _occupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkingWith", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _workingWith));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkingAs", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _workingAs));
            cmdToExecute.Parameters.Add(new SqlParameter("@WorkAddress", SqlDbType.VarChar, 350, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _workAddress));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncomeCurrency", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncomeCurrency));
            cmdToExecute.Parameters.Add(new SqlParameter("@AnnualIncome", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _annualIncome));
            cmdToExecute.Parameters.Add(new SqlParameter("@Diet", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _diet));
            cmdToExecute.Parameters.Add(new SqlParameter("@Drink", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _drink));
            cmdToExecute.Parameters.Add(new SqlParameter("@Smoke", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _smoke));
            cmdToExecute.Parameters.Add(new SqlParameter("@AboutInfo", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aboutInfo));
            cmdToExecute.Parameters.Add(new SqlParameter("@EmailID", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _emailID));
            cmdToExecute.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _password));
            cmdToExecute.Parameters.Add(new SqlParameter("@RegisterDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _registerDate));
            cmdToExecute.Parameters.Add(new SqlParameter("@isActive", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 2));
            cmdToExecute.Parameters.Add(new SqlParameter("@Choice", SqlDbType.VarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _choice));
            cmdToExecute.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.VarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _remarks));
            cmdToExecute.Parameters.Add(new SqlParameter("@Degree", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _degree));
            cmdToExecute.Parameters.Add(new SqlParameter("@OccupationDtls", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _occupationDtls));
            cmdToExecute.Parameters.Add(new SqlParameter("@VisaCountry", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _visaCountry));
            cmdToExecute.Parameters.Add(new SqlParameter("@mStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _mStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@FileNote", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fileNote));

            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MobileNo_Rel));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo1_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MobileNo1_Rel));
            cmdToExecute.Parameters.Add(new SqlParameter("@MobileNo2_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MobileNo2_Rel));
            cmdToExecute.Parameters.Add(new SqlParameter("@LandlineNo1_Rel", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _LandlineNo1_Rel));

            //cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _RetVal));
            //cmdToExecute.Parameters.Add(new SqlParameter("@RetProfileID", SqlDbType.VarChar, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _RetProfileID));
            //cmdToExecute.Parameters.Add(new SqlParameter("@RetPassword", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _RetPassword));



            if (objConnection.State == ConnectionState.Closed)
            {
                // Open connection.
                objConnection.Open();
            }
            // Execute query.
            cmdToExecute.ExecuteNonQuery();

            //_RetVal = Convert.ToInt32(cmdToExecute.Parameters["@RetVal"].Value);
            //_RetProfileID = Convert.ToString(cmdToExecute.Parameters["@RetProfileID"].Value);
            //_RetPassword = Convert.ToString(cmdToExecute.Parameters["@RetPassword"].Value);

            return true;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception(ex.Message.ToString());
        }
        finally
        {
            // Close connection.
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public bool InsertMemberPhoto()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_MemberPhotos]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@PhotoFileName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _PhotoFileName));

            cmdToExecute.Parameters.Add(new SqlParameter("@TotalCount", SqlDbType.Int, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _RetVal));

            if (objConnection.State == ConnectionState.Closed)
            {
                // Open connection.
                objConnection.Open();
            }
            // Execute query.
            cmdToExecute.ExecuteNonQuery();

            _RetVal = Convert.ToInt32(cmdToExecute.Parameters["@TotalCount"].Value);

            return true;
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("InsertUpdate_tbl_MemberMaster_web::Insert::Error occured.", ex);
        }
        finally
        {
            // Close connection.
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public bool InsertUpdate_tbl_SibblingDetails(string _BrotherSister, string _SibblingName, string _MaritalStatus, string _Occupation)
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_SibblingDetails]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@BrotherSister", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _BrotherSister));
            cmdToExecute.Parameters.Add(new SqlParameter("@SibblingName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _SibblingName));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MaritalStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _Occupation));
            cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, 1));
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
            throw new Exception("InsertUpdate_tbl_SibblingDetails::Insert::Error occured.", ex);
        }
        finally
        {
            // Close connection.
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public bool InsertUpdate_tbl_UpdateSibblingDetails(string _BrotherSister, string _SibblingName, string _MaritalStatus, string _Occupation)
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[InsertUpdate_tbl_UpdateSibblingDetails]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));
            cmdToExecute.Parameters.Add(new SqlParameter("@BrotherSister", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _BrotherSister));
            cmdToExecute.Parameters.Add(new SqlParameter("@SibblingName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _SibblingName));
            cmdToExecute.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _MaritalStatus));
            cmdToExecute.Parameters.Add(new SqlParameter("@Occupation", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _Occupation));
            //cmdToExecute.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, 1));
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
            throw new Exception("InsertUpdate_tbl_UpdateSibblingDetails::Insert::Error occured.", ex);
        }
        finally
        {
            // Close connection.
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    public bool Delete_tbl_SibblingDetails()
    {
        GetConnStr();

        SqlCommand cmdToExecute = new SqlCommand();
        cmdToExecute.CommandText = "dbo.[Delete_tbl_SibblingDetails]";
        cmdToExecute.CommandType = CommandType.StoredProcedure;

        // Use base class' connection object
        cmdToExecute.Connection = objConnection;

        try
        {
            cmdToExecute.Parameters.Add(new SqlParameter("@MemberCode", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _memberCode));

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
            throw new Exception("Delete_tbl_SibblingDetails::Insert::Error occured.", ex);
        }
        finally
        {
            // Close connection.
            objConnection.Close();
            cmdToExecute.Dispose();
        }
    }

    #region Class Property Declarations

    public SqlBoolean isEdit
    {
        get
        {
            return _isEdit;
        }
        set
        {
            SqlBoolean IsEditTmp = (SqlBoolean)value;
            if (IsEditTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("isEdit", "");
            }
            _isEdit = value;
        }
    }

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

    public SqlString ProfileID
    {
        get
        {
            return _profileID;
        }
        set
        {
            SqlString profileIDTmp = (SqlString)value;
            if (profileIDTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("ProfileID", "ProfileID can't be NULL");
            }
            _profileID = value;
        }
    }

    public SqlString PhotoFileName
    {
        get
        {
            return _PhotoFileName;
        }
        set
        {
            SqlString PhotoFileNameTmp = (SqlString)value;
            if (PhotoFileNameTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("PhotoFileName", "PhotoFileName can't be NULL");
            }
            _PhotoFileName = value;
        }
    }

    public SqlInt32 ProfileCreatedBy
    {
        get
        {
            return _profileCreatedBy;
        }
        set
        {
            SqlInt32 profileCreatedByTmp = (SqlInt32)value;
            if (profileCreatedByTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("ProfileCreatedBy", "ProfileCreatedBy can't be NULL");
            }
            _profileCreatedBy = value;
        }
    }

    public SqlString MemberName
    {
        get
        {
            return _memberName;
        }
        set
        {
            SqlString memberNameTmp = (SqlString)value;
            if (memberNameTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MemberName", "MemberName can't be NULL");
            }
            _memberName = value;
        }
    }

    public SqlInt32 Gender
    {
        get
        {
            return _gender;
        }
        set
        {
            SqlInt32 genderTmp = (SqlInt32)value;
            if (genderTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Gender", "Gender can't be NULL");
            }
            _gender = value;
        }
    }

    public SqlDateTime DateofBirth
    {
        get
        {
            DateTime dt = Convert.ToDateTime(_dateofBirth);
            _dateofBirth = Convert.ToDateTime(dt.ToString("dd/MM/yyyy"));
            return _dateofBirth;
        }
        set
        {
            SqlDateTime dateofBirthTmp = (SqlDateTime)value;
            if (dateofBirthTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("DateofBirth", "DateofBirth can't be NULL");
            }
            _dateofBirth = value;
        }
    }

    public SqlDateTime TimeofBirth
    {
        get
        {
            return _timeofBirth;
        }
        set
        {
            SqlDateTime timeofBirthTmp = (SqlDateTime)value;
            if (timeofBirthTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("TimeofBirth", "TimeofBirth can't be NULL");
            }
            _timeofBirth = value;
        }
    }

    public SqlString BirthPlace
    {
        get
        {
            return _birthPlace;
        }
        set
        {
            SqlString birthPlaceTmp = (SqlString)value;
            if (birthPlaceTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("BirthPlace", "BirthPlace can't be NULL");
            }
            _birthPlace = value;
        }
    }

    public SqlInt32 MaritalStatus
    {
        get
        {
            return _maritalStatus;
        }
        set
        {
            SqlInt32 maritalStatusTmp = (SqlInt32)value;
            if (maritalStatusTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MaritalStatus", "MaritalStatus can't be NULL");
            }
            _maritalStatus = value;
        }
    }

    public SqlInt32 NoOfChildren
    {
        get
        {
            return _noOfChildren;
        }
        set
        {
            SqlInt32 noOfChildrenTmp = (SqlInt32)value;
            if (noOfChildrenTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("NoOfChildren", "NoOfChildren can't be NULL");
            }
            _noOfChildren = value;
        }
    }

    public SqlBoolean LiveChildrenTogether
    {
        get
        {
            return _liveChildrenTogether;
        }
        set
        {
            SqlBoolean liveChildrenTogetherTmp = (SqlBoolean)value;
            if (liveChildrenTogetherTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("LiveChildrenTogether", "LiveChildrenTogether can't be NULL");
            }
            _liveChildrenTogether = value;
        }
    }

    public SqlInt32 Height
    {
        get
        {
            return _height;
        }
        set
        {
            SqlInt32 heightTmp = (SqlInt32)value;
            if (heightTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Height", "Height can't be NULL");
            }
            _height = value;
        }
    }

    public SqlInt32 Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            SqlInt32 weightTmp = (SqlInt32)value;
            if (weightTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Weight", "Weight can't be NULL");
            }
            _weight = value;
        }
    }

    public SqlInt32 BodyType
    {
        get
        {
            return _bodyType;
        }
        set
        {
            SqlInt32 bodyTypeTmp = (SqlInt32)value;
            if (bodyTypeTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("BodyType", "BodyType can't be NULL");
            }
            _bodyType = value;
        }
    }

    public SqlInt32 HealthInformation
    {
        get
        {
            return _healthInformation;
        }
        set
        {
            SqlInt32 healthInformationTmp = (SqlInt32)value;
            if (healthInformationTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("HealthInformation", "HealthInformation can't be NULL");
            }
            _healthInformation = value;
        }
    }

    public SqlInt32 Complexion
    {
        get
        {
            return _complexion;
        }
        set
        {
            SqlInt32 complexionTmp = (SqlInt32)value;
            if (complexionTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Complexion", "Complexion can't be NULL");
            }
            _complexion = value;
        }
    }

    public SqlInt32 AnyDisability
    {
        get
        {
            return _anyDisability;
        }
        set
        {
            SqlInt32 anyDisabilityTmp = (SqlInt32)value;
            if (anyDisabilityTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("AnyDisability", "AnyDisability can't be NULL");
            }
            _anyDisability = value;
        }
    }

    public SqlInt32 BloodGroup
    {
        get
        {
            return _bloodGroup;
        }
        set
        {
            SqlInt32 bloodGroupTmp = (SqlInt32)value;
            if (bloodGroupTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("BloodGroup", "BloodGroup can't be NULL");
            }
            _bloodGroup = value;
        }
    }

    public SqlString HomeAddress1
    {
        get
        {
            return _homeAddress1;
        }
        set
        {
            SqlString homeAddress1Tmp = (SqlString)value;
            if (homeAddress1Tmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("HomeAddress1", "HomeAddress1 can't be NULL");
            }
            _homeAddress1 = value;
        }
    }

    public SqlString HomeAddress2
    {
        get
        {
            return _homeAddress2;
        }
        set
        {
            SqlString homeAddress2Tmp = (SqlString)value;
            if (homeAddress2Tmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("HomeAddress2", "HomeAddress2 can't be NULL");
            }
            _homeAddress2 = value;
        }
    }

    public SqlInt32 VisaStatus
    {
        get
        {
            return _visaStatus;
        }
        set
        {
            SqlInt32 visaStatusTmp = (SqlInt32)value;
            if (visaStatusTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("VisaStatus", "VisaStatus can't be NULL");
            }
            _visaStatus = value;
        }
    }

    public SqlInt32 Country
    {
        get
        {
            return _country;
        }
        set
        {
            SqlInt32 countryTmp = (SqlInt32)value;
            if (countryTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Country", "Country can't be NULL");
            }
            _country = value;
        }
    }

    public SqlInt32 StateCity
    {
        get
        {
            return _stateCity;
        }
        set
        {
            SqlInt32 stateCityTmp = (SqlInt32)value;
            if (stateCityTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("StateCity", "StateCity can't be NULL");
            }
            _stateCity = value;
        }
    }

    public SqlString MobileNo
    {
        get
        {
            return _mobileNo;
        }
        set
        {
            SqlString mobileNoTmp = (SqlString)value;
            if (mobileNoTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MobileNo", "MobileNo can't be NULL");
            }
            _mobileNo = value;
        }
    }

    public SqlString LandlineNo
    {
        get
        {
            return _landlineNo;
        }
        set
        {
            SqlString landlineNoTmp = (SqlString)value;
            if (landlineNoTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("LandlineNo", "LandlineNo can't be NULL");
            }
            _landlineNo = value;
        }
    }

    public SqlString MobileNo1
    {
        get
        {
            return _mobileNo1;
        }
        set
        {
            SqlString mobileNo1Tmp = (SqlString)value;
            if (mobileNo1Tmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MobileNo1", "MobileNo1 can't be NULL");
            }
            _mobileNo1 = value;
        }
    }

    public SqlString LandlineNo1
    {
        get
        {
            return _landlineNo1;
        }
        set
        {
            SqlString landlineNo1Tmp = (SqlString)value;
            if (landlineNo1Tmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("LandlineNo1", "LandlineNo1 can't be NULL");
            }
            _landlineNo1 = value;
        }
    }

    public SqlString SecondaryEmailID
    {
        get
        {
            return _secondaryEmailID;
        }
        set
        {
            SqlString secondaryEmailIDTmp = (SqlString)value;
            if (secondaryEmailIDTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("SecondaryEmailID", "SecondaryEmailID can't be NULL");
            }
            _secondaryEmailID = value;
        }
    }

    public SqlInt32 Religion
    {
        get
        {
            return _religion;
        }
        set
        {
            SqlInt32 religionTmp = (SqlInt32)value;
            if (religionTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Religion", "Religion can't be NULL");
            }
            _religion = value;
        }
    }

    public SqlInt32 MotherTongue
    {
        get
        {
            return _motherTongue;
        }
        set
        {
            SqlInt32 motherTongueTmp = (SqlInt32)value;
            if (motherTongueTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MotherTongue", "MotherTongue can't be NULL");
            }
            _motherTongue = value;
        }
    }

    public SqlInt32 Caste
    {
        get
        {
            return _caste;
        }
        set
        {
            SqlInt32 casteTmp = (SqlInt32)value;
            if (casteTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Caste", "Caste can't be NULL");
            }
            _caste = value;
        }
    }

    public SqlInt32 SubCaste
    {
        get
        {
            return _subCaste;
        }
        set
        {
            SqlInt32 subCasteTmp = (SqlInt32)value;
            if (subCasteTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("SubCaste", "SubCaste can't be NULL");
            }
            _subCaste = value;
        }
    }

    public SqlInt32 Gotra
    {
        get
        {
            return _gotra;
        }
        set
        {
            SqlInt32 gotraTmp = (SqlInt32)value;
            if (gotraTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Gotra", "Gotra can't be NULL");
            }
            _gotra = value;
        }
    }

    public SqlString FatherName
    {
        get
        {
            return _fatherName;
        }
        set
        {
            SqlString fatherNameTmp = (SqlString)value;
            if (fatherNameTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("FatherName", "FatherName can't be NULL");
            }
            _fatherName = value;
        }
    }

    public SqlString FatherOccupation
    {
        get
        {
            return _fatherOccupation;
        }
        set
        {
            SqlString fatherOccupationTmp = (SqlString)value;
            if (fatherOccupationTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("FatherOccupation", "FatherOccupation can't be NULL");
            }
            _fatherOccupation = value;
        }
    }

    public SqlString MotherName
    {
        get
        {
            return _motherName;
        }
        set
        {
            SqlString motherNameTmp = (SqlString)value;
            if (motherNameTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MotherName", "MotherName can't be NULL");
            }
            _motherName = value;
        }
    }

    public SqlString MotherOccupation
    {
        get
        {
            return _motherOccupation;
        }
        set
        {
            SqlString motherOccupationTmp = (SqlString)value;
            if (motherOccupationTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MotherOccupation", "MotherOccupation can't be NULL");
            }
            _motherOccupation = value;
        }
    }

    public SqlString MosalPlace
    {
        get
        {
            return _mosalPlace;
        }
        set
        {
            SqlString mosalPlaceTmp = (SqlString)value;
            if (mosalPlaceTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MosalPlace", "MosalPlace can't be NULL");
            }
            _mosalPlace = value;
        }
    }

    public SqlString NativePlace
    {
        get
        {
            return _nativePlace;
        }
        set
        {
            SqlString nativePlaceTmp = (SqlString)value;
            if (nativePlaceTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("NativePlace", "NativePlace can't be NULL");
            }
            _nativePlace = value;
        }
    }

    public SqlInt32 FamilyType
    {
        get
        {
            return _familyType;
        }
        set
        {
            SqlInt32 familyTypeTmp = (SqlInt32)value;
            if (familyTypeTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("FamilyType", "FamilyType can't be NULL");
            }
            _familyType = value;
        }
    }

    public SqlInt32 FamilyValues
    {
        get
        {
            return _familyValues;
        }
        set
        {
            SqlInt32 familyValuesTmp = (SqlInt32)value;
            if (familyValuesTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("FamilyValues", "FamilyValues can't be NULL");
            }
            _familyValues = value;
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

    public SqlInt32 Nakshtra
    {
        get
        {
            return _nakshtra;
        }
        set
        {
            SqlInt32 nakshtraTmp = (SqlInt32)value;
            if (nakshtraTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Nakshtra", "Nakshtra can't be NULL");
            }
            _nakshtra = value;
        }
    }

    public SqlInt32 Rashi
    {
        get
        {
            return _rashi;
        }
        set
        {
            SqlInt32 rashiTmp = (SqlInt32)value;
            if (rashiTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Rashi", "Rashi can't be NULL");
            }
            _rashi = value;
        }
    }

    public SqlInt32 Education
    {
        get
        {
            return _education;
        }
        set
        {
            SqlInt32 educationTmp = (SqlInt32)value;
            if (educationTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Education", "Education can't be NULL");
            }
            _education = value;
        }
    }

    public SqlInt32 Occupation
    {
        get
        {
            return _occupation;
        }
        set
        {
            SqlInt32 occupationTmp = (SqlInt32)value;
            if (occupationTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Occupation", "Occupation can't be NULL");
            }
            _occupation = value;
        }
    }

    public SqlInt32 WorkingWith
    {
        get
        {
            return _workingWith;
        }
        set
        {
            SqlInt32 workingWithTmp = (SqlInt32)value;
            if (workingWithTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("WorkingWith", "WorkingWith can't be NULL");
            }
            _workingWith = value;
        }
    }

    public SqlInt32 WorkingAs
    {
        get
        {
            return _workingAs;
        }
        set
        {
            SqlInt32 workingAsTmp = (SqlInt32)value;
            if (workingAsTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("WorkingAs", "WorkingAs can't be NULL");
            }
            _workingAs = value;
        }
    }

    public SqlString WorkAddress
    {
        get
        {
            return _workAddress;
        }
        set
        {
            SqlString workAddressTmp = (SqlString)value;
            if (workAddressTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("WorkAddress", "WorkAddress can't be NULL");
            }
            _workAddress = value;
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

    public SqlString AboutInfo
    {
        get
        {
            return _aboutInfo;
        }
        set
        {
            SqlString aboutInfoTmp = (SqlString)value;
            if (aboutInfoTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("AboutInfo", "AboutInfo can't be NULL");
            }
            _aboutInfo = value;
        }
    }

    public SqlString EmailID
    {
        get
        {
            return _emailID;
        }
        set
        {
            SqlString emailIDTmp = (SqlString)value;
            if (emailIDTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("EmailID", "EmailID can't be NULL");
            }
            _emailID = value;
        }
    }

    public SqlString Password
    {
        get
        {
            return _password;
        }
        set
        {
            SqlString passwordTmp = (SqlString)value;
            if (passwordTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Password", "Password can't be NULL");
            }
            _password = value;
        }
    }

    public SqlDateTime RegisterDate
    {
        get
        {
            return _registerDate;
        }
        set
        {
            SqlDateTime registerDateTmp = (SqlDateTime)value;
            if (registerDateTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("RegisterDate", "RegisterDate can't be NULL");
            }
            _registerDate = value;
        }
    }

    public SqlInt32 IsActive
    {
        get
        {
            return _isActive;
        }
        set
        {
            SqlInt32 isActiveTmp = (SqlInt32)value;
            if (isActiveTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("IsActive", "IsActive can't be NULL");
            }
            _isActive = value;
        }
    }

    public SqlString Choice
    {
        get
        {
            return _choice;
        }
        set
        {
            SqlString choiceTmp = (SqlString)value;
            if (choiceTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Choice", "Choice can't be NULL");
            }
            _choice = value;
        }
    }

    public SqlString Remarks
    {
        get
        {
            return _remarks;
        }
        set
        {
            SqlString remarksTmp = (SqlString)value;
            if (remarksTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Remarks", "Remarks can't be NULL");
            }
            _remarks = value;
        }
    }

    public SqlString Degree
    {
        get
        {
            return _degree;
        }
        set
        {
            SqlString degreeTmp = (SqlString)value;
            if (degreeTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("Degree", "Degree can't be NULL");
            }
            _degree = value;
        }
    }

    public SqlString OccupationDtls
    {
        get
        {
            return _occupationDtls;
        }
        set
        {
            SqlString occupationDtlsTmp = (SqlString)value;
            if (occupationDtlsTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("OccupationDtls", "OccupationDtls can't be NULL");
            }
            _occupationDtls = value;
        }
    }

    public SqlDecimal VisaCountry
    {
        get
        {
            return _visaCountry;
        }
        set
        {
            SqlDecimal visaCountryTmp = (SqlDecimal)value;
            if (visaCountryTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("VisaCountry", "VisaCountry can't be NULL");
            }
            _visaCountry = value;
        }
    }

    public SqlInt32 MStatus
    {
        get
        {
            return _mStatus;
        }
        set
        {
            SqlInt32 mStatusTmp = (SqlInt32)value;
            if (mStatusTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MStatus", "MStatus can't be NULL");
            }
            _mStatus = value;
        }
    }

    public SqlString FileNote
    {
        get
        {
            return _fileNote;
        }
        set
        {
            SqlString fileNoteTmp = (SqlString)value;
            if (fileNoteTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("FileNote", "FileNote can't be NULL");
            }
            _fileNote = value;
        }
    }

    public SqlString RetPassword
    {
        get
        {
            return _RetPassword;
        }
        set
        {
            SqlString RetPasswordTmp = (SqlString)value;
            if (RetPasswordTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("RetPassword", "RetPassword can't be NULL");
            }
            _RetPassword = value;
        }
    }

    public SqlString RetProfileID
    {
        get
        {
            return _RetProfileID;
        }
        set
        {
            SqlString RetProfileIDTmp = (SqlString)value;
            if (RetProfileIDTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("RetProfileID", "RetProfileID can't be NULL");
            }
            _RetProfileID = value;
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

    public Int32 TotalCount
    {
        get
        {
            return _TotalCount;
        }
        set
        {
            Int32 TotalCountTmp = (Int32)value;
            _TotalCount = value;
        }
    }

    public SqlString MobileNo_Rel
    {
        get
        {
            return _MobileNo_Rel;
        }
        set
        {
            SqlString MobileNo_RelTmp = (SqlString)value;
            if (MobileNo_RelTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MobileNo_Rel", "MobileNo_Rel can't be NULL");
            }
            _MobileNo_Rel = value;
        }
    }
    public SqlString MobileNo1_Rel
    {
        get
        {
            return _MobileNo1_Rel;
        }
        set
        {
            SqlString MobileNo1_RelTmp = (SqlString)value;
            if (MobileNo1_RelTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MobileNo1_Rel", "MobileNo1_Rel can't be NULL");
            }
            _MobileNo1_Rel = value;
        }
    }
    public SqlString MobileNo2_Rel
    {
        get
        {
            return _MobileNo2_Rel;
        }
        set
        {
            SqlString MobileNo2_RelTmp = (SqlString)value;
            if (MobileNo2_RelTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("MobileNo2_Rel", "MobileNo2_Rel can't be NULL");
            }
            _MobileNo2_Rel = value;
        }
    }
    public SqlString LandlineNo1_Rel
    {
        get
        {
            return _LandlineNo1_Rel;
        }
        set
        {
            SqlString LandlineNo1_RelTmp = (SqlString)value;
            if (LandlineNo1_RelTmp.IsNull)
            {
                throw new ArgumentOutOfRangeException("LandlineNo1_Rel", "LandlineNo1_Rel can't be NULL");
            }
            _LandlineNo1_Rel = value;
        }
    }




    #endregion
}
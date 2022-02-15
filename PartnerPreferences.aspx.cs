using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PartnerPreferences : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();

    string StrSql = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCombo();
            FillList();
            if (Session["MemberCode"] != null)
            {
                GetMemberDetails();
            }
        }

    }

    public void FillCombo()
    {
        try
        {
            int strMemberCode = 0;
            int FromYear = 1950, ToYear = 1996;

            DataTable dtMember = new DataTable();
            if (Session["MemberCode"] != null)
            {
                strMemberCode = Convert.ToInt32(Session["MemberCode"]);

                //dtMember = objGlobal.Get_UpdateMemberMaster(strMemberCode);
                //if (dtMember.Rows.Count == 0)
                //{
                //dtMember = objGlobal.Load_MemberDetails(1, 0, "", strMemberCode);
                dtMember = objGlobal.GetMemberDetails(strMemberCode);
                //}

                int AgeDiff = objGlobal.GetAgeDiff(strMemberCode);
                AgeDiff = 5;
                DataTable dtMaritalStatusList = new DataTable();
                if (strMemberCode > 0)
                {
                    DateTime DOB = DateTime.ParseExact(Convert.ToString(dtMember.Rows[0]["DateOfBirth_1"]), "dd/MM/yyyy", null);
                    FromYear = DOB.Year;
                    ////0= Male, 1=Female
                    if (Convert.ToString(dtMember.Rows[0]["Gender"]) == "0")
                    {
                        ToYear = FromYear + AgeDiff;
                    }
                    else
                    {
                        ToYear = FromYear;
                        FromYear = FromYear - AgeDiff;
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

            DataTable dtHeightList = objGlobal.GetHeight();
            ddlHeight_From.DataSource = dtHeightList;
            ddlHeight_From.DataValueField = "HeightCM";
            ddlHeight_From.DataTextField = "Height";
            ddlHeight_From.DataBind();

            ddlHeight_To.DataSource = dtHeightList;
            ddlHeight_To.DataValueField = "HeightCM";
            ddlHeight_To.DataTextField = "Height";
            ddlHeight_To.DataBind();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void FillList()
    {
        try
        {
            int strMemberCode = 0;
            DataTable dtMember = new DataTable();
            if (Session["MemberCode"] != null)
            {
                strMemberCode = Convert.ToInt32(Session["MemberCode"]);
                //dtMember = objGlobal.Load_MemberDetails(1, 0, "", strMemberCode);
                dtMember = objGlobal.GetMemberDetails(strMemberCode);
            }
            DataTable dtMaritalStatusList = new DataTable();
            if (strMemberCode > 0)
            {
                string strMritalStatus = Convert.ToString(dtMember.Rows[0]["MaritalStatus"]);
                dtMaritalStatusList = objGlobal.GetMaritalStatusList(strMritalStatus);
            }
            else
            {
                dtMaritalStatusList = objGlobal.GetMaritalStatusList("");
            }
            lstMarital_Status.DataSource = dtMaritalStatusList;
            lstMarital_Status.DataValueField = "MaritalStatusCode";
            lstMarital_Status.DataTextField = "MaritalStatus";
            lstMarital_Status.DataBind();
            //lstMarital_Status.Items.Insert(0, new ListItem("Any", "0"));

            DataTable dtCountry = objGlobal.GetCountryList("");
            lst_Country.DataSource = dtCountry;
            lst_Country.DataValueField = "CountryCode";
            lst_Country.DataTextField = "Country";
            lst_Country.DataBind();
            lst_Country.Items.Insert(0, new ListItem("Any", "0"));

            DataTable dtVisaList = objGlobal.GetVisaList("");
            lstResidency_status.DataSource = dtVisaList;
            lstResidency_status.DataValueField = "VisaStatusCode";
            lstResidency_status.DataTextField = "VisaStatus";
            lstResidency_status.DataBind();
            lstResidency_status.Items.Insert(0, new ListItem("Any", "0"));

            DataTable dtEducation = objGlobal.GetEducationList("");
            lstEducation.DataSource = dtEducation;
            lstEducation.DataValueField = "EducationCode";
            lstEducation.DataTextField = "Education";
            lstEducation.DataBind();
            lstEducation.Items.Insert(0, new ListItem("Any", "0"));

            DataTable dtOccupationList = objGlobal.GetOccupationList("");
            lstOccupation.DataSource = dtOccupationList;
            lstOccupation.DataValueField = "OccupationCode";
            lstOccupation.DataTextField = "Occupation";
            lstOccupation.DataBind();
            lstOccupation.Items.Insert(0, new ListItem("Any", "0"));

            DataTable dtCaste = objGlobal.GetCasteList("");
            lstCaste.DataSource = dtCaste;
            lstCaste.DataValueField = "CasteCode";
            lstCaste.DataTextField = "Caste";
            lstCaste.DataBind();
            lstCaste.Items.Insert(0, new ListItem("Any", "0"));
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void GetMemberDetails()
    {
        try
        {
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            //DataTable dtMember = objGlobal.Load_MemberDetails(1, 0, "", MemberCode);
            DataTable dtMember = objGlobal.Load_PartnersPreferences(MemberCode);
            //Select_tbl_PartnersPreferences
            if (dtMember.Rows.Count > 0)
            {
                txtAboutLifePartner.Text = Convert.ToString(dtMember.Rows[0]["AboutPartner"]);
                ddlBornFrom.Text = Convert.ToString(dtMember.Rows[0]["AgeFrom"]);
                ddlBornTo.Text = Convert.ToString(dtMember.Rows[0]["AgeTo"]);
                objGlobal.SelectListBox_Items(lstCaste, Convert.ToString(dtMember.Rows[0]["Caste"]));
                objGlobal.SelectListBox_Items(lst_Country, Convert.ToString(dtMember.Rows[0]["CountryLivingIn"]));
                objGlobal.SelectListBox_Items(lstEducation, Convert.ToString(dtMember.Rows[0]["Education"]));

                ddlHeight_From.SelectedValue = Convert.ToString(dtMember.Rows[0]["HeightFrom"]);
                ddlHeight_To.SelectedValue = Convert.ToString(dtMember.Rows[0]["HeightTo"]);
                if (Convert.ToString(dtMember.Rows[0]["Manglik"]) != "")
                {
                    ddlManglik.SelectedValue = Convert.ToString(dtMember.Rows[0]["Manglik"]);
                }


                //ddlHeight_From.SelectedItem.Text = Convert.ToString(dtMember.Rows[0]["HeightFrom"]);
                //ddlHeight_To.SelectedItem.Text = Convert.ToString(dtMember.Rows[0]["HeightTo"]);
                //ddlManglik.SelectedItem.Text = Convert.ToString(dtMember.Rows[0]["pManglik"]);
                objGlobal.SelectListBox_Items(lstMarital_Status, Convert.ToString(dtMember.Rows[0]["MaritalStatus"]));
                objGlobal.SelectListBox_Items(lstOccupation, Convert.ToString(dtMember.Rows[0]["Occupation"]));
                objGlobal.SelectListBox_Items(lstResidency_status, Convert.ToString(dtMember.Rows[0]["ResidencyStatus"]));
                //GetMemberPhotos(MemberCode);
            }
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

            cl_tbl_MemberMaster objMemberMaster = new cl_tbl_MemberMaster();
            cl_tbl_PartnersPreferences objPartPref = new cl_tbl_PartnersPreferences();

            objPartPref.MemberCode = Convert.ToInt32(Session["MemberCode"]);
            objPartPref.AgeFrom = Convert.ToInt32(ddlBornFrom.SelectedValue);
            objPartPref.AgeTo = Convert.ToInt32(ddlBornTo.SelectedValue);
            objPartPref.HeightFrom = Convert.ToInt32(ddlHeight_From.SelectedValue);
            objPartPref.HeightTo = Convert.ToInt32(ddlHeight_To.SelectedValue);
            objPartPref.MaritalStatus = objGlobal.GetListBox_SelectedItem(lstMarital_Status);
            objPartPref.HaveChildren = 0;
            objPartPref.Religion = "";
            objPartPref.MotherTongue = "";
            objPartPref.Caste = objGlobal.GetListBox_SelectedItem(lstCaste);
            objPartPref.SubCaste = "";
            objPartPref.Manglik = Convert.ToInt32(ddlManglik.SelectedValue);
            objPartPref.CountryLivingIn = objGlobal.GetListBox_SelectedItem(lst_Country);
            objPartPref.StateCity = "";
            objPartPref.ResidencyStatus = objGlobal.GetListBox_SelectedItem(lstResidency_status);
            objPartPref.Education = objGlobal.GetListBox_SelectedItem(lstEducation);
            objPartPref.Occupation = objGlobal.GetListBox_SelectedItem(lstOccupation);
            objPartPref.WorkingWith = "";
            objPartPref.AnnualIncomeCurrency = 0;
            objPartPref.AnnualIncome = 0;
            objPartPref.Diet = 0;
            objPartPref.Smoke = 0;
            objPartPref.Drink = 0;
            objPartPref.BodyType = "";
            objPartPref.Complexion = "";
            objPartPref.HealthProblem = "";
            objPartPref.AboutPartner = txtAboutLifePartner.Text;
            if (!objMemberMaster.isEdit)
            {
                if (objPartPref.Insert())
                {
                    Response.Redirect("/UploadPhotos");
                }
            }
            else
            {
                if (objPartPref.Insert_UpdatePartnersPreferences())
                {
                    Response.Redirect("/UploadPhotos");
                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }





}
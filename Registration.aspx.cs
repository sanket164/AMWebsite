using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    cl_tbl_MemberMaster objMemberMaster = new cl_tbl_MemberMaster();
    DataTable dtSibbling = new DataTable();
    dbInteraction objdb = new dbInteraction();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!IsPostBack)
            {
                FillCombo();
                Fill_Data_SignUp();
                if (Session["MemberCode"] != null)
                {
                    GetMemberDetails();
                }
            }
            if (Session["dtSibbling"] == null)
            {
                CreateTable();
            }
            else
            {
                dtSibbling = (DataTable)Session["dtSibbling"];
                if (dtSibbling.Columns.Count == 0)
                {
                    CreateTable();
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void CreateTable()
    {
        try
        {
            dtSibbling.Columns.Add("MemberCode");
            dtSibbling.Columns.Add("SrNo");
            dtSibbling.Columns.Add("BrotherSister");
            dtSibbling.Columns.Add("SibblingName");
            dtSibbling.Columns.Add("MaritalStatus");
            dtSibbling.Columns.Add("Occupation");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void GetMemberDetails()
    {
        try
        {
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            //DataTable dtMember = objGlobal.Load_MemberDetails(1, 0, "", MemberCode);
            DataTable dtMember = objGlobal.GetMemberDetails(MemberCode);
            if (dtMember.Rows.Count > 0)
            {
                txtMemberName.Text = Convert.ToString(dtMember.Rows[0]["MemberName"]);
                lblProfileId.Value = Convert.ToString(dtMember.Rows[0]["ProfileID"]);
                lblPassword.Value = objGlobal.GetPassword(MemberCode);
                //DateTime dtTempVal = DateTime.ParseExact(Convert.ToString(dtMember.Rows[0]["RegisterDate"]), "dd/MM/yyyy", null);
                lblRegisterDate.Value = Convert.ToDateTime(dtMember.Rows[0]["RegisterDate"]).ToShortDateString();
                ddlAnnualIncome.SelectedValue = Convert.ToString(dtMember.Rows[0]["AnnualIncome"]);
                txtDob.Text = Convert.ToString(dtMember.Rows[0]["DateofBirth_1"]);
                //txtDob_Hidden.Value = Convert.ToString(dtMember.Rows[0]["DateofBirth_1"]);
                txtBirthPlace.Text = Convert.ToString(dtMember.Rows[0]["BirthPlace"]);
                txtBirthtime.Text = Convert.ToString(dtMember.Rows[0]["TimeofBirth_1"]);
                lblChoice.Value = Convert.ToString(dtMember.Rows[0]["Choice"]);
                lblRemark.Value = Convert.ToString(dtMember.Rows[0]["Remarks"]);
                lblFileNote.Value = Convert.ToString(dtMember.Rows[0]["FileNote"]);
                lblProfileCreated.Value = Convert.ToString(objGlobal.GetProfileCreatedId_Id(Convert.ToString(dtMember.Rows[0]["ProfileCreatedByCode"])));
                if (Convert.ToString(dtMember.Rows[0]["BloodGroup"]) != "")
                {
                    ddlBloodGrp.SelectedValue = ddlBloodGrp.Items.FindByText(Convert.ToString(dtMember.Rows[0]["BloodGroup"])).Value;
                    //ddlBloodGrp.SelectedItem.Text = Convert.ToString(dtMember.Rows[0]["BloodGroup"]);
                }
                if (Convert.ToString(dtMember.Rows[0]["CasteCode"]) != "")
                {
                    ddlCaste.SelectedValue = Convert.ToString(dtMember.Rows[0]["CasteCode"]);
                    //ddlCaste.SelectedValue = ddlCaste.Items.FindByText(Convert.ToString(dtMember.Rows[0]["Caste"])).Value;//. = Convert.ToString(dtMember.Rows[0]["Caste"]);
                    GetSubCaste();
                }
                if (Convert.ToString(dtMember.Rows[0]["CountryCode"]) != "")
                {
                    ddlCountry.SelectedValue = Convert.ToString(dtMember.Rows[0]["CountryCode"]);
                    //ddlCountry.SelectedValue = ddlCountry.Items.FindByText(Convert.ToString(dtMember.Rows[0]["Country"])).Value;
                    GetState();
                }
                if (Convert.ToString(dtMember.Rows[0]["EducationCode"]) != "")
                {
                    ddlEducation.SelectedValue = Convert.ToString(dtMember.Rows[0]["EducationCode"]);
                    //ddlEducation.SelectedValue = ddlEducation.Items.FindByText(Convert.ToString(dtMember.Rows[0]["Education"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["Gender"]) != "")
                {
                    ddlGender.SelectedValue = Convert.ToString(dtMember.Rows[0]["Gender"]);
                    //ddlGender.SelectedValue = ddlGender.Items.FindByText(Convert.ToString(dtMember.Rows[0]["Gender"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["Height"]) != "")
                {
                    ddlHeight.SelectedValue = Convert.ToString(dtMember.Rows[0]["Height"]);
                    //ddlHeight.SelectedValue = ddlHeight.Items.FindByText(Convert.ToString(dtMember.Rows[0]["Height"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["Manglik"]) != "")
                {
                    ddlManglik.SelectedValue = Convert.ToString(dtMember.Rows[0]["Manglik"]);
                    //ddlManglik.SelectedValue = ddlManglik.Items.FindByText(Convert.ToString(dtMember.Rows[0]["Manglik"])).Value;
                }
                ddlMaritalStatus.SelectedValue = Convert.ToString(dtMember.Rows[0]["MaritalStatusCode"]);
                ddlMaritalStatus_Hidden.Value = Convert.ToString(dtMember.Rows[0]["MaritalStatusCode"]);
                //ddlMaritalStatus.SelectedValue = ddlMaritalStatus.Items.FindByText(Convert.ToString(dtMember.Rows[0]["MaritalStatus"])).Value;
                txtAboutMySelf.Text = Convert.ToString(dtMember.Rows[0]["AboutInfo"]);
                if (Convert.ToString(dtMember.Rows[0]["OccupationCode"]) != "")
                {
                    ddlOccupation.SelectedValue = Convert.ToString(dtMember.Rows[0]["OccupationCode"]);
                    //ddlOccupation.SelectedValue = ddlOccupation.Items.FindByText(Convert.ToString(dtMember.Rows[0]["Occupation"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["StateCityCode"]) != "")
                {
                    ddlStateCity.SelectedValue = Convert.ToString(dtMember.Rows[0]["StateCityCode"]);
                    //ddlStateCity.SelectedValue = ddlStateCity.Items.FindByText(Convert.ToString(dtMember.Rows[0]["StateCity"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["SubCasteCode"]) != "")
                {
                    ddlSubCaste.SelectedValue = Convert.ToString(dtMember.Rows[0]["SubCasteCode"]);
                    //ddlSubCaste.SelectedValue = ddlSubCaste.Items.FindByText(Convert.ToString(dtMember.Rows[0]["SubCaste"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["VisaStatusCode"]) != "")
                {
                    ddlVisaStatus.SelectedValue = Convert.ToString(dtMember.Rows[0]["VisaStatusCode"]);
                    //ddlVisaStatus.SelectedValue = ddlVisaStatus.Items.FindByText(Convert.ToString(dtMember.Rows[0]["VisaStatus"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["VisaCountryCode"]) != "")
                {
                    ddlVisaCountry.SelectedValue = Convert.ToString(dtMember.Rows[0]["VisaCountryCode"]);
                    //ddlVisaStatus.SelectedValue = ddlVisaStatus.Items.FindByText(Convert.ToString(dtMember.Rows[0]["VisaStatus"])).Value;
                }

                if (Convert.ToString(dtMember.Rows[0]["MobileNo_Rel"]) != "")
                {
                    //ddlMob_Rel.SelectedValue = Convert.ToString(dtMember.Rows[0]["MobileNo_Rel"]);
                    ddlMob_Rel.SelectedValue = ddlMob_Rel.Items.FindByText(Convert.ToString(dtMember.Rows[0]["MobileNo_Rel"])).Value;
                    //ddlMob_Rel.Items.FindByText(dtMember.Rows[0]["MobileNo_Rel"].ToString()).Selected = true;
                }
                if (Convert.ToString(dtMember.Rows[0]["MobileNo1_Rel"]) != "")
                {
                    //ddlMob1_Rel.SelectedValue = Convert.ToString(dtMember.Rows[0]["MobileNo1_Rel"]);
                    ddlMob1_Rel.SelectedValue = ddlMob1_Rel.Items.FindByText(Convert.ToString(dtMember.Rows[0]["MobileNo1_Rel"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["MobileNo2_Rel"]) != "")
                {
                    //ddlMob2_Rel.SelectedValue = Convert.ToString(dtMember.Rows[0]["MobileNo2_Rel"]);
                    ddlMob2_Rel.SelectedValue = ddlMob2_Rel.Items.FindByText(Convert.ToString(dtMember.Rows[0]["MobileNo2_Rel"])).Value;
                }
                if (Convert.ToString(dtMember.Rows[0]["LandlineNo1_Rel"]) != "")
                {
                    //ddlLanline_Rel.SelectedValue = Convert.ToString(dtMember.Rows[0]["LandlineNo1_Rel"]);
                    ddlLanline_Rel.SelectedValue = ddlLanline_Rel.Items.FindByText(Convert.ToString(dtMember.Rows[0]["LandlineNo1_Rel"])).Value;
                }

                txtWeight.Text = Convert.ToString(dtMember.Rows[0]["Weight"]);
                txtEmail.Text = Convert.ToString(dtMember.Rows[0]["EmailId"]);
                txtSecondEmail.Text = Convert.ToString(dtMember.Rows[0]["SecondaryEmailID"]);
                txtAddress.Text = Convert.ToString(dtMember.Rows[0]["HomeAddress1"]);
                txtAltAddress.Text = Convert.ToString(dtMember.Rows[0]["HomeAddress2"]);
                txtFatherName.Text = Convert.ToString(dtMember.Rows[0]["FatherName"]);
                txtMotherName.Text = Convert.ToString(dtMember.Rows[0]["MotherName"]);
                txtFather_Occupation.Text = Convert.ToString(dtMember.Rows[0]["FatherOccupation"]);
                txtMother_Occupation.Text = Convert.ToString(dtMember.Rows[0]["MotherOccupation"]);
                txtMosalPlace.Text = Convert.ToString(dtMember.Rows[0]["MosalPlace"]);
                txtNativePlace.Text = Convert.ToString(dtMember.Rows[0]["NativePlace"]);
                txtWorkAddress.Text = Convert.ToString(dtMember.Rows[0]["WorkAddress"]);
                txtMobileNo.Text = Convert.ToString(dtMember.Rows[0]["MobileNo"]);
                txtMobileNo_1.Text = Convert.ToString(dtMember.Rows[0]["MobileNo1"]);
                txtLandLineNo.Text = Convert.ToString(dtMember.Rows[0]["LandlineNo"]);
                txtOccupationDetails.Text = Convert.ToString(dtMember.Rows[0]["OccupationDtls"]);
                txtDegree.Text = Convert.ToString(dtMember.Rows[0]["Degree"]);
                //ddlMaritalStatus.Enabled = false;
                ddlMaritalStatus.Attributes.Add("disabled", "disabled");
                //txtDob.Attributes.Add("disabled", "disabled");
                txtDob.ReadOnly = true;
                txtMemberName.ReadOnly = true;
                GetSibblingDetails(MemberCode);
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void FillCombo()
    {
        try
        {
            DataTable dtCaste = objGlobal.GetCasteList("");
            ddlCaste.DataSource = dtCaste;
            ddlCaste.DataValueField = "CasteCode";
            ddlCaste.DataTextField = "Caste";
            ddlCaste.DataBind();

            DataTable dtEducation = objGlobal.GetEducationList("");
            ddlEducation.DataSource = dtEducation;
            ddlEducation.DataValueField = "EducationCode";
            ddlEducation.DataTextField = "Education";
            ddlEducation.DataBind();

            DataTable dtCountry = objGlobal.GetCountryList("");
            ddlCountry.DataSource = dtCountry;
            ddlCountry.DataValueField = "CountryCode";
            ddlCountry.DataTextField = "Country";
            ddlCountry.DataBind();

            ddlVisaCountry.DataSource = dtCountry;
            ddlVisaCountry.DataValueField = "CountryCode";
            ddlVisaCountry.DataTextField = "Country";
            ddlVisaCountry.DataBind();

            DataTable dtMaritalStatusList = objGlobal.GetMaritalStatusList("");
            ddlMaritalStatus_Brother_Sister.DataSource = dtMaritalStatusList;
            ddlMaritalStatus_Brother_Sister.DataValueField = "MaritalStatusCode";
            ddlMaritalStatus_Brother_Sister.DataTextField = "MaritalStatus";
            ddlMaritalStatus_Brother_Sister.DataBind();

            dtMaritalStatusList.Rows.RemoveAt(3);
            ddlMaritalStatus.DataSource = dtMaritalStatusList;
            ddlMaritalStatus.DataValueField = "MaritalStatusCode";
            ddlMaritalStatus.DataTextField = "MaritalStatus";
            ddlMaritalStatus.DataBind();

            

            DataTable dtHeightList = objGlobal.GetHeight();
            ddlHeight.DataSource = dtHeightList;
            ddlHeight.DataValueField = "HeightCM";
            ddlHeight.DataTextField = "Height";
            ddlHeight.DataBind();

            DataTable dtOccupationList = objGlobal.GetOccupationList("");
            DataRow dr1 = dtOccupationList.NewRow();
            dr1["OccupationCode"] = "0";
            dr1["Occupation"] = "Select";
            dtOccupationList.Rows.InsertAt(dr1, 0);
            ddlOccupation.DataSource = dtOccupationList;
            ddlOccupation.DataValueField = "OccupationCode";
            ddlOccupation.DataTextField = "Occupation";
            ddlOccupation.DataBind();

            ddlOccupation_Brother_Sister.DataSource = dtOccupationList;
            ddlOccupation_Brother_Sister.DataValueField = "OccupationCode";
            ddlOccupation_Brother_Sister.DataTextField = "Occupation";
            ddlOccupation_Brother_Sister.DataBind();

            DataTable dtAnnualIncome;
            dtAnnualIncome = objGlobal.GetAnnualIncomeList();
            DataRow dr = dtAnnualIncome.NewRow();
            dr["AnnualIncomeCode"] = "0";
            dr["AnnualIncome"] = "Select";
            dtAnnualIncome.Rows.InsertAt(dr,0);
            ddlAnnualIncome.DataSource = dtAnnualIncome;
            ddlAnnualIncome.DataValueField = "AnnualIncomeCode";
            ddlAnnualIncome.DataTextField = "AnnualIncome";
            ddlAnnualIncome.DataBind();

            DataTable dtStateCity = objGlobal.GetStateCityList("", ddlCountry.Text);
            ddlStateCity.DataSource = dtStateCity;
            ddlStateCity.DataValueField = "StateCityCode";
            ddlStateCity.DataTextField = "StateCity";
            ddlStateCity.DataBind();

            DataTable dtBloodGrp = objGlobal.GetBloodGrpList("");
            ddlBloodGrp.DataSource = dtBloodGrp;
            ddlBloodGrp.DataValueField = "BloodGroupCode";
            ddlBloodGrp.DataTextField = "BloodGroup";
            ddlBloodGrp.DataBind();

            DataTable dtVisaStatus = objGlobal.GetVisaStatusList("");
            ddlVisaStatus.DataSource = dtVisaStatus;
            ddlVisaStatus.DataValueField = "VisaStatusCode";
            ddlVisaStatus.DataTextField = "VisaStatus";
            ddlVisaStatus.DataBind();

            string strSql = " SELECT 0 AS ProfileCreatedByCode,'--SELECT--' AS ProfileCreatedBy ,0 as ORD UNION ALL ";
            strSql += " SELECT ProfileCreatedByCode,ProfileCreatedBy,1 as ORD FROM tbl_ProfileCreatedBy ORDER BY ORD,ProfileCreatedBy  ";
            DataTable dtRel_1 = objdb.GetDataTable(strSql);
            ddlMob_Rel.DataSource = dtRel_1;
            ddlMob_Rel.DataValueField = "ProfileCreatedBy";
            ddlMob_Rel.DataTextField = "ProfileCreatedBy";
            ddlMob_Rel.DataBind();
            ddlMob_Rel.SelectedIndex = 0;

            ddlMob1_Rel.DataSource = dtRel_1;
            ddlMob1_Rel.DataValueField = "ProfileCreatedBy";
            ddlMob1_Rel.DataTextField = "ProfileCreatedBy";
            ddlMob1_Rel.DataBind();
            ddlMob1_Rel.SelectedIndex = 0;

            ddlMob2_Rel.DataSource = dtRel_1;
            ddlMob2_Rel.DataValueField = "ProfileCreatedBy";
            ddlMob2_Rel.DataTextField = "ProfileCreatedBy";
            ddlMob2_Rel.DataBind();
            ddlMob2_Rel.SelectedIndex = 0;

            //strSql = "SELECT 'Select' as Id,0 as ORD  UNION";
            //strSql += " SELECT 'Home' as Id,1 as ORD UNION ";
            //strSql += " SELECT 'Work' as Id,2 as ORD  UNION ";
            //strSql += " SELECT 'Other' as Id,3 as ORD  ORDER BY ORD  ";
            //DataTable dtWLL = objdb.GetDataTable(strSql);
            ddlLanline_Rel.DataSource = dtRel_1;
            ddlLanline_Rel.DataValueField = "ProfileCreatedBy";
            ddlLanline_Rel.DataTextField = "ProfileCreatedBy";
            ddlLanline_Rel.DataBind();
            ddlLanline_Rel.SelectedIndex = 0;

            GetSubCaste();
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
            long MemberCode = 0;
            bool SecoundTime = false;
            if (txtMemberName.Text.Trim() == "")
            {
                lblErrMsg.Text = "Please Insert Member Name";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                return;
            }
            if (txtDob.Text.Trim() == "")
            {

                lblErrMsg.Text = "Please Insert Date of Birth";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                return;

            }
            if (txtDob.Text.Trim() != "")
            {
                DateTime dtDOB = DateTime.ParseExact(txtDob.Text, "dd/MM/yyyy", null);
                int Age = DateTime.Now.Year - dtDOB.Year;
                if (Convert.ToInt32(ddlGender.SelectedValue) == 1)
                {
                    if (Age < 18)
                    {
                        lblErrMsg.Text = "Age must be 18 or more than 18";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                        return;
                    }
                }
                else
                {
                    if (Age < 21)
                    {
                        lblErrMsg.Text = "Age must be 21 or more than 21";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                        return;
                    }
                }
            }
            //else
            //{
            //    if (txtDob_Hidden.Value.Trim() != "")
            //    {
            //        DateTime dtDOB = DateTime.ParseExact(txtDob_Hidden.Value, "dd/MM/yyyy", null);
            //        int Age = DateTime.Now.Year - dtDOB.Year;
            //        if (Convert.ToInt32(ddlGender.SelectedValue) == 1)
            //        {
            //            if (Age < 18)
            //            {
            //                lblErrMsg.Text = "Age must be 18 or more than 18";
            //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            if (Age < 21)
            //            {
            //                lblErrMsg.Text = "Age must be 21 or more than 21";
            //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
            //                return;
            //            }
            //        }
            //    }
            //}
            if (txtMobileNo.Text.Trim() == "")
            {
                lblErrMsg.Text = "Please Insert Mobile Number";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                lblErrMsg.Text = "Please Insert Email";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                return;
            }

            if (Session["MemberCode"] != null)
            {
                MemberCode = Convert.ToInt64(Session["MemberCode"]);
            }

            if (objGlobal.CheckEmailAlreadyExist(txtEmail.Text, MemberCode))
            {
                lblErrMsg.Text = "Email Id Already Exist";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                return;
            }

            //////Remove code because of Back button enable in browser
            //////Check IsAvtive Status for back button press in browser and save other time

            //if (MemberCode > 0)
            //{
            //    if (objGlobal.CheckAlreadyInsertAndIsActiveNew(MemberCode))
            //    {
            //        SecoundTime = true;
            //    }
            //}

            //ddlMaritalStatus.Attributes.Remove("disabled");
            objMemberMaster.MemberCode = MemberCode;
            objMemberMaster.ProfileID = "";

            if (Convert.ToString(lblProfileCreated.Value) != "")
            {
                objMemberMaster.ProfileCreatedBy = Convert.ToInt32(lblProfileCreated.Value);
            }
            else
            {
                objMemberMaster.ProfileCreatedBy = 1;
            }
            objMemberMaster.MemberName = txtMemberName.Text;
            if (ddlGender.SelectedValue != "")
            {
                objMemberMaster.Gender = Convert.ToInt32(ddlGender.SelectedValue);
            }
            if (txtDob.Text != "")
            {
                objMemberMaster.DateofBirth = DateTime.ParseExact(txtDob.Text, "dd/MM/yyyy", null); //Convert.ToDateTime(txtDob.Text);
            }
            //else
            //{
            //    objMemberMaster.DateofBirth = DateTime.ParseExact(txtDob_Hidden.Value, "dd/MM/yyyy", null); //Convert.ToDateTime(txtDob.Text);
            //}

            if (txtBirthtime.Text != "")
            {
                objMemberMaster.TimeofBirth = Convert.ToDateTime(txtBirthtime.Text);
            }

            objMemberMaster.BirthPlace = txtBirthPlace.Text;
            //objMemberMaster.MaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
            if (ddlMaritalStatus_Hidden.Value != "")
            {
                objMemberMaster.MaritalStatus = Convert.ToInt32(ddlMaritalStatus_Hidden.Value);
            }
            else
            {
                objMemberMaster.MaritalStatus = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
            }
            objMemberMaster.NoOfChildren = 0;
            objMemberMaster.LiveChildrenTogether = false;
            if (ddlHeight.SelectedValue != "")
            {
                objMemberMaster.Height = Convert.ToInt32(ddlHeight.SelectedValue);
            }
            if (txtWeight.Text != "")
            {
                objMemberMaster.Weight = Convert.ToInt32(txtWeight.Text);
            }
            objMemberMaster.BodyType = 0;
            objMemberMaster.HealthInformation = 0;
            objMemberMaster.Complexion = 0;
            objMemberMaster.AnyDisability = 0;
            if (ddlBloodGrp.SelectedValue != "")
            {
                objMemberMaster.BloodGroup = Convert.ToInt32(ddlBloodGrp.SelectedValue);
            }
            objMemberMaster.HomeAddress1 = txtAddress.Text;
            objMemberMaster.HomeAddress2 = txtAltAddress.Text;
            if (ddlVisaStatus.SelectedValue != "")
            {
                objMemberMaster.VisaStatus = Convert.ToInt32(ddlVisaStatus.SelectedValue);
            }
            if (ddlCountry.SelectedValue != "")
            {
                objMemberMaster.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            }
            if (ddlStateCity.SelectedValue != "")
            {
                objMemberMaster.StateCity = Convert.ToInt32(ddlStateCity.SelectedValue);
            }
            objMemberMaster.MobileNo = txtMobileNo.Text;
            objMemberMaster.LandlineNo = txtLandLineNo.Text;
            objMemberMaster.MobileNo1 = txtMobileNo_1.Text;
            objMemberMaster.LandlineNo1 = "";
            objMemberMaster.SecondaryEmailID = txtSecondEmail.Text;
            objMemberMaster.Religion = 0;
            objMemberMaster.MotherTongue = 0;
            if (ddlCaste.SelectedValue != "")
            {
                objMemberMaster.Caste = Convert.ToInt32(ddlCaste.SelectedValue);
            }
            if (ddlSubCaste.SelectedValue != "")
            {
                objMemberMaster.SubCaste = Convert.ToInt32(ddlSubCaste.SelectedValue);
            }
            objMemberMaster.Gotra = 0;
            objMemberMaster.FatherName = txtFatherName.Text;
            objMemberMaster.FatherOccupation = txtFather_Occupation.Text;
            objMemberMaster.MotherName = txtMotherName.Text;
            objMemberMaster.MotherOccupation = txtMother_Occupation.Text;
            objMemberMaster.MosalPlace = txtMosalPlace.Text;
            objMemberMaster.NativePlace = txtNativePlace.Text;
            objMemberMaster.FamilyType = 0;
            objMemberMaster.FamilyValues = 0;
            if (ddlManglik.SelectedValue != "")
            {
                objMemberMaster.Manglik = Convert.ToInt32(ddlManglik.SelectedValue);
            }
            objMemberMaster.Nakshtra = 0;
            objMemberMaster.Rashi = 0;
            if (ddlEducation.SelectedValue != "")
            {
                objMemberMaster.Education = Convert.ToInt32(ddlEducation.SelectedValue);
            }
            if (ddlOccupation.SelectedValue != "")
            {
                objMemberMaster.Occupation = Convert.ToInt32(ddlOccupation.SelectedValue);
            }
            objMemberMaster.WorkingWith = 0;
            objMemberMaster.WorkingAs = 0;
            objMemberMaster.WorkAddress = txtWorkAddress.Text;
            objMemberMaster.AnnualIncomeCurrency = 0;
            if (ddlAnnualIncome.SelectedValue != "")
            {
                objMemberMaster.AnnualIncome = Convert.ToInt32(ddlAnnualIncome.SelectedValue);
            }
            objMemberMaster.Diet = 0;
            objMemberMaster.Drink = 0;
            objMemberMaster.Smoke = 0;
            objMemberMaster.AboutInfo = txtAboutMySelf.Text;
            objMemberMaster.EmailID = txtEmail.Text;
            objMemberMaster.Password = "";
            objMemberMaster.RegisterDate = DateTime.Now;
            objMemberMaster.IsActive = 0;
            objMemberMaster.Choice = lblChoice.Value;
            objMemberMaster.Remarks = lblRemark.Value;
            objMemberMaster.Degree = txtDegree.Text;
            objMemberMaster.OccupationDtls = txtOccupationDetails.Text;
            objMemberMaster.VisaCountry = Convert.ToDecimal(ddlVisaCountry.SelectedValue);
            if (ddlMob_Rel.SelectedIndex > 0)
            {
                objMemberMaster.MobileNo_Rel = ddlMob_Rel.SelectedValue;
            }
            if (ddlMob1_Rel.SelectedIndex > 0)
            {
                objMemberMaster.MobileNo1_Rel = ddlMob1_Rel.SelectedValue;
            }
            if (ddlMob2_Rel.SelectedIndex > 0)
            {
                objMemberMaster.MobileNo2_Rel = ddlMob2_Rel.SelectedValue;
            }
            if (ddlLanline_Rel.SelectedIndex > 0)
            {
                objMemberMaster.LandlineNo1_Rel = ddlLanline_Rel.SelectedValue;
            }
            objMemberMaster.MStatus = 0;

            objMemberMaster.FileNote = lblFileNote.Value;

            if (MemberCode == 0)
            {
                objMemberMaster.isEdit = false;
                if (!objMemberMaster.Insert())
                {

                }
                else
                {
                    int RetVal = Convert.ToInt32(objMemberMaster.RetVal);
                    string RetProfileID = Convert.ToString(objMemberMaster.RetProfileID);
                    string RetPassword = Convert.ToString(objMemberMaster.RetPassword);
                    Session["ProfileID"] = RetProfileID.ToString() + RetVal.ToString();
                    Session["MemberCode"] = RetVal.ToString();
                    lblProfileId.Value = RetProfileID.ToString() + RetVal.ToString();
                    lblPassword.Value = Convert.ToString(objMemberMaster.RetPassword);
                    InsertSibblingDetails(false);
                    Session["dtSibbling"] = null;
                    string strRegMSG = "Welcome to Anant Matrimony, Elite Matrimonial Service since 2003. Your Profile will Activated once Verified By Admin";
                    string strPhoneNo = txtMobileNo.Text.Trim();
                    if (strPhoneNo != "")
                    {
                        objGlobal.SendSMS(strPhoneNo, strRegMSG);
                    }
                    if (txtEmail.Text != "")
                    {
                        string strHTML = "<html> ";
                        strHTML += " <head> ";
                        strHTML += " <title>Anant Matrimony</title> ";
                        strHTML += " <link href='https://fonts.googleapis.com/css?family=Lato:400,500,600,700' rel='stylesheet' /> ";
                        strHTML += " </head> ";
                        strHTML += " <body style='font-family: 'Lato', sans-serif;background-color: #ffffff;margin: 0px;padding: 0px;width: 100%;font-size: 15px;font-weight: 400;color: #323232;line-height: 18px;text-align:left;'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='contentbg'> ";
                        strHTML += " <tr> <td valign='top'>  ";
                        strHTML += " <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                        strHTML += " <tr> <td valign='top' bgcolor='#FFFFFF'>  ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'>  ";
                        strHTML += " <tr> <td width='80%' height='105' align='left' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr>  ";
                        strHTML += " <td valign='top' bgcolor='#ca3b3b' style='padding:35px;'><a href='#'><img src='http://www.anantmatrimony.com/images/logo.png' width='349' height='107' alt='logo' style='margin-left: auto;margin-right: auto;' /></a></td> ";
                        strHTML += " </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> ";
                        strHTML += " <td valign='top'> ";
                        strHTML += " <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                        strHTML += " <tr> <td valign='top'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding:20px 0px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> ";
                        strHTML += " <td width='100%' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> ";
                        strHTML += " <td width='100%' valign='top' style='text-align: left; font-size: 22px; font-weight: 600; color: #323232; border-bottom: 1px solid #e8e8e8;font-family: inherit; '> ";
                        strHTML += " <p>Hello " + txtMemberName.Text + " ,</p> ";
                        strHTML += " <p>Thank you for register with us.</p> ";
                        strHTML += " <p>AnantMatrimony.com Has Gained Expertise in Matrimony Services and match making From More than 15 Years (since2003)</p> ";
                        strHTML += " <p>More than 22000+ Profiles registered with us and they have experienced the best Services from Us</p> ";
                        strHTML += " <p>2200+ Pair of Couples From all over the World have Found Their Soul mates With the Support of us.</p> ";

                        strHTML += " <p>Visis us on <a href='http://www.anantmatrimony.com' target='_blank'>www.anantmatrimony.com</a></p> ";
                        strHTML += " </td> </tr> <tr> ";
                        strHTML += " <td class='footerheading' width='100%' valign='top' style='padding-bottom:16px;text-align:center;font-size: 22px;font-weight: 600;color: #323232;line-height: 44px;'>For More Details, Call Us!</td> ";
                        strHTML += " </tr> <tr> ";
                        strHTML += " <td width='100%' valign='top' style='padding-bottom:16px;border-bottom:1px solid #e8e8e8;font-size: 35px;font-weight: 600;color: #f54d56;line-height: 24px;text-align:center;'>9428412065/9998489093</td> ";
                        strHTML += " </tr> <tr> ";
                        strHTML += " <td width='100%' valign='top' style='padding-bottom: 16px; border-bottom: 1px solid #e8e8e8; color: #323232; line-height: 24px; text-align: justify; '> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px; margin-top: 15px;'>425, 4th Floor, Saman Complex,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Opp. Satyam Mall,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Near Jodhpur Cross Roads,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Satellite, Ahmedabad,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Gujarat 380015</p> ";
                        strHTML += " </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td valign='top'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding-bottom:33px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> <td width='100%' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding-top:21px; padding-bottom:17px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> ";
                        strHTML += " </td> </tr> <tr> ";
                        strHTML += " <td valign='top' style='font-size:13px;color:#989797;text-align:center; padding-right:84px;'> ";
                        strHTML += " © 2003 - <script>document.write(new Date().getFullYear())</script> AnantMatrimony.com & Kankukanya.com. All Rights Reserved.<br /> ";
                        strHTML += " </td> </tr> </table> </td>  </tr> </table> </td> </tr> </table> </td> </tr> ";
                        strHTML += " </table> </td> </tr> </table> </body> </html>";
                        objGlobal.SendMail(txtEmail.Text, "AnantMatrimony : Registration ", strHTML, true, "noreply@anantmatrimony.com", "Changeme@123");
                    }
                    Response.Redirect("/PartnerPreferences");
                }
            }
            else
            {
                objMemberMaster.isEdit = false;
                objMemberMaster.ProfileID = lblProfileId.Value;
                objMemberMaster.Password = lblPassword.Value;
                objMemberMaster.ProfileCreatedBy = Convert.ToInt32(lblProfileCreated.Value);
                objMemberMaster.RegisterDate = Convert.ToDateTime(lblRegisterDate.Value);
                if (!objMemberMaster.Insert_UpdateMemberMaster())
                {

                }
                else
                {
                    InsertSibblingDetails(true);

                    Response.Redirect("/PartnerPreferences");
                }
            }

        }
        catch (Exception ex)
        {
            lblErrMsg.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
        }
    }

    public int InsertSibblingDetails(bool isEdit)
    {
        try
        {
            if (!isEdit)
            {
                dtSibbling = (DataTable)Session["dtSibbling"];
                //objMemberMaster.Delete_tbl_SibblingDetails();
                for (int cnt = 0; cnt < dtSibbling.Rows.Count; cnt++)
                {
                    string _BrotherSister = "", _SibblingName = "", _MaritalStatus = "", _Occupation = "";
                    _BrotherSister = Convert.ToString(dtSibbling.Rows[cnt]["BrotherSister"]);
                    _SibblingName = Convert.ToString(dtSibbling.Rows[cnt]["SibblingName"]);
                    _MaritalStatus = Convert.ToString(dtSibbling.Rows[cnt]["MaritalStatus"]);
                    _Occupation = Convert.ToString(dtSibbling.Rows[cnt]["Occupation"]);
                    objMemberMaster.InsertUpdate_tbl_SibblingDetails(_BrotherSister, _SibblingName, _MaritalStatus, _Occupation);
                }
            }
            else
            {
                dtSibbling = (DataTable)Session["dtSibbling"];
                //objMemberMaster.Delete_tbl_SibblingDetails();
                for (int cnt = 0; cnt < dtSibbling.Rows.Count; cnt++)
                {
                    string _BrotherSister = "", _SibblingName = "", _MaritalStatus = "", _Occupation = "";
                    _BrotherSister = Convert.ToString(dtSibbling.Rows[cnt]["BrotherSister"]);
                    _SibblingName = Convert.ToString(dtSibbling.Rows[cnt]["SibblingName"]);
                    _MaritalStatus = Convert.ToString(dtSibbling.Rows[cnt]["MaritalStatus"]);
                    _Occupation = Convert.ToString(dtSibbling.Rows[cnt]["Occupation"]);
                    objMemberMaster.InsertUpdate_tbl_UpdateSibblingDetails(_BrotherSister, _SibblingName, _MaritalStatus, _Occupation);
                }
            }
            return 1;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message.ToString());
            return 0;
        }
    }

    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetSubCaste();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void GetSubCaste()
    {
        if (ddlCaste.SelectedValue != "")
        {
            DataTable dtSubCaste = objGlobal.GetSubCasteList(ddlCaste.SelectedValue, "");
            ddlSubCaste.DataSource = dtSubCaste;
            ddlSubCaste.DataValueField = "SubCasteCode";
            ddlSubCaste.DataTextField = "SubCaste";
            ddlSubCaste.DataBind();
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetState();
    }

    private void GetState()
    {
        DataTable dtStateCity = objGlobal.GetStateCityList("", ddlCountry.Text);
        ddlStateCity.DataSource = dtStateCity;
        ddlStateCity.DataValueField = "StateCityCode";
        ddlStateCity.DataTextField = "StateCity";
        ddlStateCity.DataBind();
    }

    public void GetSibblingDetails(long memberCode)
    {
        try
        {
            dtSibbling = objGlobal.GetSibblingDetails(memberCode);
            if (dtSibbling.Rows.Count > 0)
            {
                GridBind();
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private void GridBind()
    {
        if (Session["dtSibbling"] != null)
        {
            dtSibbling = (DataTable)Session["dtSibbling"];
        }
        dgvSibblingDetails.DataSource = dtSibbling;
        dgvSibblingDetails.DataBind();
        Session["dtSibbling"] = dtSibbling;
    }

    protected void btnDeleteBroSis_Click(object sender, CommandEventArgs e)
    {
        try
        {
            string SrNo = Convert.ToString(e.CommandArgument);
            for (int cnt = 0; cnt < dtSibbling.Rows.Count; cnt++)
            {
                if (SrNo == Convert.ToString(dtSibbling.Rows[cnt]["SrNo"]))
                {
                    dtSibbling.Rows.RemoveAt(cnt);
                    break;
                }
            }
            //foreach (GridViewRow gvrow in dgvSibblingDetails.Rows)
            //{
            //    if (gvrow.RowType == DataControlRowType.DataRow)
            //    {
            //        CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
            //        if (chk != null & chk.Checked)
            //        {
            //            Label SrNo = (Label)gvrow.FindControl("SrNo");
            //            for (int cnt = 0; cnt < dtSibbling.Rows.Count; cnt++)
            //            {
            //                if (SrNo.Text == Convert.ToString(dtSibbling.Rows[cnt]["SrNo"]))
            //                {
            //                    dtSibbling.Rows.RemoveAt(cnt);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            GridBind();
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message.ToString());
        }
    }

    protected void btn_AddClick(object sender, EventArgs e)
    {
        try
        {
            if (txtName_Brother_Sister.Text.Trim() == "")
            {
                lblErrMsg.Text = "Please Insert Sibbling Name";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                return;
            }
            if (DDlBroSis.SelectedIndex == 0)
            {
                lblErrMsg.Text = "Please Select Sibbling Type";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
                return;
            }
            long memberCode = Convert.ToInt32(Session["MemberCode"]);
            DataRow dr;
            if (dtSibbling == null)
            {
                dtSibbling = (DataTable)Session["dtSibbling"];
            }
            int SrNo = dtSibbling.Rows.Count;
            dr = dtSibbling.NewRow();
            dr["MemberCode"] = memberCode;
            dr["BrotherSister"] = DDlBroSis.SelectedItem.Text;
            dr["SibblingName"] = txtName_Brother_Sister.Text;
            dr["MaritalStatus"] = ddlMaritalStatus_Brother_Sister.SelectedItem.Text;
            dr["Occupation"] = ddlOccupation_Brother_Sister.SelectedItem.Text;
            dr["SrNo"] = (SrNo + 1);
            dtSibbling.Rows.Add(dr);
            GridBind();
            DDlBroSis.SelectedIndex = 0;
            txtName_Brother_Sister.Text = "";
            ddlMaritalStatus_Brother_Sister.SelectedIndex = 0;
            ddlOccupation_Brother_Sister.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void Fill_Data_SignUp()
    {
        try
        {
            if (Session["dtSingUp"] != null)
            {
                DataTable dtSingUp = new DataTable();
                dtSingUp = (DataTable)Session["dtSingUp"];
                txtMemberName.Text = Convert.ToString(dtSingUp.Rows[0]["MemberName"]);
                ddlGender.SelectedValue = Convert.ToString(dtSingUp.Rows[0]["Gender"]);
                //DateTime dt = Convert.ToDateTime(dtSingUp.Rows[0]["DateofBirth"]);
                txtDob.Text = Convert.ToString(dtSingUp.Rows[0]["DateofBirth"]);
                //txtDob_Hidden.Value = Convert.ToString(dtSingUp.Rows[0]["DateofBirth"]);
                ddlMaritalStatus.SelectedValue = Convert.ToString(dtSingUp.Rows[0]["MaritalStatus"]);
                ddlCountry.SelectedValue = Convert.ToString(dtSingUp.Rows[0]["Country"]);
                ddlStateCity.SelectedValue = Convert.ToString(dtSingUp.Rows[0]["StateCity"]);
                txtMobileNo.Text = Convert.ToString(dtSingUp.Rows[0]["MobileNo"]);
                ddlCaste.SelectedValue = Convert.ToString(dtSingUp.Rows[0]["Caste"]);
                ddlEducation.SelectedValue = Convert.ToString(dtSingUp.Rows[0]["Education"]);
                txtEmail.Text = Convert.ToString(dtSingUp.Rows[0]["EmailID"]);
                lblProfileCreated.Value = Convert.ToString(dtSingUp.Rows[0]["ProfileCreatedBy"]);
                GetSubCaste();
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message.ToString());
        }
    }


    protected void ddlMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMaritalStatus_Hidden.Value = ddlMaritalStatus.SelectedValue;
    }
}
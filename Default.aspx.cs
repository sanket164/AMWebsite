using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();
    cl_tbl_MemberMaster objMemberMaster = new cl_tbl_MemberMaster();
    DataTable dtSingUp = new DataTable();

    string StrSql = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                FillCombo();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void FillCombo()
    {
        try
        {
            DataTable dtProfileCreated = objGlobal.GetProfileCreatedBy("");
            ddlProfCreated.DataSource = dtProfileCreated;
            ddlProfCreated.DataValueField = "ProfileCreatedByCode";
            ddlProfCreated.DataTextField = "ProfileCreatedBy";
            ddlProfCreated.DataBind();

            //ListItem li = new ListItem();
            //li.Text = "Select";
            //li.Value = "0";

            //ddlProfCreated.Items.Add(li);

            DataTable dtCaste = objGlobal.GetCasteList("");
            ddlCaste.DataSource = dtCaste;
            ddlCaste.DataValueField = "CasteCode";
            ddlCaste.DataTextField = "Caste";
            ddlCaste.DataBind();

            ddlCaste_Find.DataSource = dtCaste;
            ddlCaste_Find.DataValueField = "CasteCode";
            ddlCaste_Find.DataTextField = "Caste";
            ddlCaste_Find.DataBind();

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

            DataTable dtMaritalStatusList = objGlobal.GetMaritalStatusList("");
            ddlMaritalStatus.DataSource = dtMaritalStatusList;
            ddlMaritalStatus.DataValueField = "MaritalStatusCode";
            ddlMaritalStatus.DataTextField = "MaritalStatus";
            ddlMaritalStatus.DataBind();

            DataTable dtFromBorn = objGlobal.GetYearList(1950, 1996);
            ddlBornFrom.DataSource = dtFromBorn;
            ddlBornFrom.DataValueField = "NValue";
            ddlBornFrom.DataTextField = "Number";
            ddlBornFrom.DataBind();

            DataTable dtToBorn = objGlobal.GetYearList(1950, 1996);
            ddlBornTo.DataSource = dtToBorn;
            ddlBornTo.DataValueField = "NValue";
            ddlBornTo.DataTextField = "Number";
            ddlBornTo.DataBind();

            StrSql = "SELECT '0' AS Code ,'Bride' AS Name ";
            StrSql += " UNION ALL ";
            StrSql += " SELECT '1' AS Code,'Groom' as Name";
            DataTable dtSelect = objdb.GetDataTable(StrSql);
            ddlLooking.DataSource = dtSelect;
            ddlLooking.DataValueField = "Code";
            ddlLooking.DataTextField = "Name";
            ddlLooking.DataBind();

            GetState();

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
            Session["s_Gender"] = ddlLooking.SelectedValue;
            Session["S_BornFrom"] = ddlBornFrom.SelectedValue;
            Session["S_BornTo"] = ddlBornTo.SelectedValue;
            Session["MaritalStatusList"] = ddlMaritalStatus.SelectedValue;
            Session["CasteList"] = ddlCaste_Find.SelectedValue;
            Response.Redirect("/SearchResult.aspx?Search=First");
        }
        catch (Exception ex)
        {

            throw;
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

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            lblMessage.Text = "";
            if (txtMemberName.Text == "" || txtDob.Text == "" || txtMobNo.Text == "" || ddlGender.SelectedValue == "" || ddlCaste.SelectedValue == ""
                || ddlEducation.SelectedValue == "" || ddlCountry.SelectedValue == "" || ddlStateCity.SelectedValue == "" || txtEmail.Text == "")
            {
                lblMessage.Text = "All Fileds are mandatory";
                return;
            }
            if (objGlobal.CheckEmailAlreadyExist(txtEmail.Text, 0))
            {
                lblMessage.Text = "Email Id Already Exist";
                return;
            }
            CreateTable();
            DataRow dr;
            dr = dtSingUp.NewRow();
            dr["ProfileCreatedBy"] = Convert.ToInt32(ddlProfCreated.SelectedValue);
            dr["MemberName"] = txtMemberName.Text;
            dr["Gender"] = Convert.ToInt32(ddlGender.SelectedValue);
            //DateTime dtDOB = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            //dtDOB = Convert.ToDateTime(txtDob.Text);
            dr["DateofBirth"] = txtDob.Text;
            dr["MaritalStatus"] = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
            dr["Country"] = Convert.ToInt32(ddlCountry.SelectedValue);
            dr["StateCity"] = Convert.ToInt32(ddlStateCity.SelectedValue);
            dr["MobileNo"] = txtMobNo.Text;
            dr["Caste"] = Convert.ToInt32(ddlCaste.SelectedValue);
            dr["Education"] = Convert.ToInt32(ddlEducation.SelectedValue);
            dr["EmailID"] = txtEmail.Text;
            dtSingUp.Rows.Add(dr);
            Session["dtSingUp"] = dtSingUp;
            Response.Redirect("/Registration", false);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void CreateTable()
    {
        try
        {
            dtSingUp.Columns.Add("ProfileCreatedBy");
            dtSingUp.Columns.Add("MemberName");
            dtSingUp.Columns.Add("Gender");
            dtSingUp.Columns.Add("DateofBirth");
            dtSingUp.Columns.Add("MaritalStatus");
            dtSingUp.Columns.Add("Country");
            dtSingUp.Columns.Add("StateCity");
            dtSingUp.Columns.Add("MobileNo");
            dtSingUp.Columns.Add("Caste");
            dtSingUp.Columns.Add("Education");
            dtSingUp.Columns.Add("EmailID");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }


}
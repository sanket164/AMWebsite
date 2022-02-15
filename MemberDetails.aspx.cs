using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberDetails : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    dbInteraction objdb = new dbInteraction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MemberCode"] == null)
            {
                Response.Redirect("/Default");
            }
            GetMemberDetails();
        }
    }

    public void CheckEdit(long memberCode)
    {
        try
        {
            EditMsg.Visible = false;
            string strSql = "select count(*) as Cnt from dbo.tbl_UpdateMemberMaster where MemberCode=" + memberCode;
            int Cnt = Convert.ToInt32(objdb.ExecuteScalar(strSql));
            if (Cnt > 0)
            {
                lnkEdit.Visible = false;
                EditMsg.Visible = true;
            }
            strSql = "select count(*) as Cnt  from dbo.tbl_UpdatePartnersPreferences where MemberCode=" + memberCode;
            Cnt = Convert.ToInt32(objdb.ExecuteScalar(strSql));
            if (Cnt > 0)
            {
                lnkEdit.Visible = false;
                EditMsg.Visible = true;
            }
            strSql = "select count(*) as Cnt  from dbo.tbl_UpdateSibblingDetails where MemberCode=" + memberCode;
            Cnt = Convert.ToInt32(objdb.ExecuteScalar(strSql));
            if (Cnt > 0)
            {
                lnkEdit.Visible = false;
                EditMsg.Visible = true;
            }
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
            int MemberDays = 0;
            //lnkInterest.Visible = true;
            lnkBookmark.Visible = true;
            lnkViewMore.Visible = true;
            lnkEdit.Visible = true;
            long M_Code = Convert.ToInt32(Request["M_id"]);
            int LogInCode = Convert.ToInt32(Session["MemberCode"]);
            string P_Id = Convert.ToString(Request["P_Id"]);
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            if (M_Code == 0 || P_Id == null)
            {
                return;
            }
            CheckEdit(MemberCode);
            DataTable dtMember = objGlobal.Load_MemberDetails(1, LogInCode, P_Id, M_Code);
            if (P_Id != "" && P_Id != null)
            {
                MemberDays = objGlobal.CheckIsYetMember(LogInCode);
            }
            else
            {
                MemberDays = 1;
            }
            if (dtMember.Rows.Count > 0)
            {
                objGlobal.Insert_tbl_ProfilevisitLog(LogInCode, P_Id.ToString());
                if (MemberDays > 0)
                {
                    lblMemberName.Text = Convert.ToString(dtMember.Rows[0]["MemberName"]);
                }
                else
                {
                    MemName.Visible = false;
                }
                lblProfileId.Text = Convert.ToString(dtMember.Rows[0]["ProfileId"]);
                lblAnnualIncome.Text = Convert.ToString(dtMember.Rows[0]["AnnualIncome"]);
                lblBirthDate.Text = Convert.ToString(dtMember.Rows[0]["DateofBirth"]);
                lblBirthPlace.Text = Convert.ToString(dtMember.Rows[0]["BirthPlace"]);
                lblBirthTime.Text = Convert.ToString(dtMember.Rows[0]["TimeofBirth_1"]);
                lblBloodGrp.Text = Convert.ToString(dtMember.Rows[0]["BloodGroup"]);
                lblCaste.Text = Convert.ToString(dtMember.Rows[0]["Caste"]);
                lblCountry.Text = Convert.ToString(dtMember.Rows[0]["Country"]);
                lblEducation.Text = Convert.ToString(dtMember.Rows[0]["Education"]);
                lblGender.Text = Convert.ToString(dtMember.Rows[0]["Gender"]);
                lblHeight.Text = Convert.ToString(dtMember.Rows[0]["Height"]);
                lblManglic.Text = Convert.ToString(dtMember.Rows[0]["Manglik"]);
                lblMaritalStatus.Text = Convert.ToString(dtMember.Rows[0]["MaritalStatus"]);
                lblMySelf.Text = Convert.ToString(dtMember.Rows[0]["AboutInfo"]);
                lblOccupation.Text = Convert.ToString(dtMember.Rows[0]["Occupation"]);
                lblStateCity.Text = Convert.ToString(dtMember.Rows[0]["StateCity"]);
                lblSubCaste.Text = Convert.ToString(dtMember.Rows[0]["SubCaste"]);
                lblVisaStatus.Text = Convert.ToString(dtMember.Rows[0]["VisaStatus"]);
                lblWeight.Text = Convert.ToString(dtMember.Rows[0]["Weight"]);

                lblDegree.Text = Convert.ToString(dtMember.Rows[0]["Degree"]);
                lblOccupationDetails.Text = Convert.ToString(dtMember.Rows[0]["OccupationDtls"]);
                lblVisaCountry.Text = Convert.ToString(dtMember.Rows[0]["VisaCountry"]);

                lblNativePlace.Text = Convert.ToString(dtMember.Rows[0]["NativePlace"]);
                lblMosalPlace.Text = Convert.ToString(dtMember.Rows[0]["MosalPlace"]);

                lblAbout_p.Text = Convert.ToString(dtMember.Rows[0]["AboutPartner"]);
                lblBirthdate_p.Text = Convert.ToString(dtMember.Rows[0]["AgeFrom"]) + " to " + Convert.ToString(dtMember.Rows[0]["AgeTo"]);
                lblCaste_p.Text = Convert.ToString(dtMember.Rows[0]["pCaste"]);
                lblChildren_p.Text = Convert.ToString(dtMember.Rows[0]["pHaveChildren"]);
                if (Convert.ToString(dtMember.Rows[0]["pCountryLivingIn"]) != "")
                {
                    lblCountry_p.Text = Convert.ToString(dtMember.Rows[0]["pCountryLivingIn"]);
                }
                else
                {
                    lblCountry_p.Text = "Any";
                }

                if (Convert.ToString(dtMember.Rows[0]["pEducation"]) != "")
                {
                    lblEducation_p.Text = Convert.ToString(dtMember.Rows[0]["pEducation"]);
                }
                else
                {
                    lblEducation_p.Text = "Any";
                }

                lblHeight_p.Text = Convert.ToString(dtMember.Rows[0]["HeightFrom"]) + " to " + Convert.ToString(dtMember.Rows[0]["HeightTo"]);
                lblManglik_p.Text = Convert.ToString(dtMember.Rows[0]["pManglik"]);
                lblMaritalStatus_p.Text = Convert.ToString(dtMember.Rows[0]["pMaritalStatus"]);
                if (Convert.ToString(dtMember.Rows[0]["pOccupation"]) != "")
                {
                    lblOccupation_p.Text = Convert.ToString(dtMember.Rows[0]["pOccupation"]);
                }
                else
                {
                    lblOccupation_p.Text = "Any";
                }

                if (Convert.ToString(dtMember.Rows[0]["pResidencyStatus"]) != "")
                {
                    lblResidencyStatus_p.Text = Convert.ToString(dtMember.Rows[0]["pResidencyStatus"]);
                }
                else
                {
                    lblResidencyStatus_p.Text = "Any";
                }

                if (lblMaritalStatus_p.Text.ToString().Trim() == "Unmarried")
                {
                    li_Child.Visible = false;
                }
                GetLastLoginDetails(M_Code);
                GetMemberPhotos(M_Code);

                if (MemberDays > 0)
                {
                    lnkViewMore.Visible = false;
                    tblContactDetails.Visible = true;
                    tblFamilyDeails.Visible = true;
                    GetSibblingDetails(M_Code);
                    lblEmailId.Text = Convert.ToString(dtMember.Rows[0]["EmailID"]);
                    lblEmail_1.Text = Convert.ToString(dtMember.Rows[0]["SecondaryEmailID"]);
                    lblFatherName.Text = Convert.ToString(dtMember.Rows[0]["FatherName"]);
                    lblFatherOccupation.Text = Convert.ToString(dtMember.Rows[0]["FatherOccupation"]);
                    lblMotherName.Text = Convert.ToString(dtMember.Rows[0]["MotherName"]);
                    lblMotherOccupation.Text = Convert.ToString(dtMember.Rows[0]["MotherOccupation"]);
                    lblAddress.Text = Convert.ToString(dtMember.Rows[0]["HomeAddress1"]);
                    lblMobileNo.Text = Convert.ToString(dtMember.Rows[0]["MobileNo"]);
                    if (Convert.ToString(dtMember.Rows[0]["MobileNo"]) != "" && Convert.ToString(dtMember.Rows[0]["MobileNo"]).ToString().ToUpper() != "--SELECT-")
                    {
                        lblMobileNo.Text = Convert.ToString(dtMember.Rows[0]["MobileNo"]) + "-" + Convert.ToString(dtMember.Rows[0]["MobileNo_rel"]);
                    }
                    if (Convert.ToString(dtMember.Rows[0]["MobileNo1"]) != "" && Convert.ToString(dtMember.Rows[0]["MobileNo1"]) != "-SELECT-")
                    {
                        lblMobileNo1.Text = Convert.ToString(dtMember.Rows[0]["MobileNo1"]) + "-" + Convert.ToString(dtMember.Rows[0]["MobileNo1_rel"]);
                    }

                    lblMobileNo3.Text = Convert.ToString(dtMember.Rows[0]["LandlineNo1"]);
                    lblLandline.Text = Convert.ToString(dtMember.Rows[0]["LandlineNo"]);
                    lblAddress2.Text = Convert.ToString(dtMember.Rows[0]["HomeAddress2"]);
                }
                else
                {
                    tblContactDetails.Visible = false;
                    tblFamilyDeails.Visible = false;
                    lnkViewMore.Visible = true;
                }
            }
            if (objGlobal.CheckBookMark(MemberCode, M_Code))
            {
                lnkBookmark.Attributes.Add("style", "background-color: green;");
                lnkBookmark.Text = "Bookmarked";
            }
            if (P_Id == "")
            {
                //lnkInterest.Visible = false;
                lnkBookmark.Visible = false;
                lnkViewMore.Visible = false;
                tab_photos.Visible = true;
                lastLogin_div.Visible = false;
            }
            else
            {
                div_UpdateMSG.Visible = false;
                lnkEdit.Visible = false;
                tab_photos.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void GetSibblingDetails(long memberCode)
    {
        try
        {
            DataTable dtSibblingDetails = objGlobal.GetSibblingDetails(memberCode);
            if (dtSibblingDetails.Rows.Count > 0)
            {
                dgvSibblingDetails.DataSource = dtSibblingDetails;
                dgvSibblingDetails.DataBind();
            }

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private void GetLastLoginDetails(long M_Code)
    {
        DataTable dtLoginDetails = objGlobal.GetLastLogingDate(M_Code);
        if (dtLoginDetails.Rows.Count > 0)
        {
            DateTime dtLoginDate = Convert.ToDateTime(dtLoginDetails.Rows[0]["LoginDate"]);
            lblLoginDate.InnerText = dtLoginDate.ToString("dd-MM-yyyy hh:mm:tt");
        }
    }

    public void GetMemberPhotos(long MemberCode)
    {
        try
        {
            img_1_Slide.Visible = false;
            img_1_thum.Visible = false;
            img1.Visible = false;

            img_2_Slide.Visible = false;
            img_2_thum.Visible = false;
            img2.Visible = false;

            img_3_Slide.Visible = false;
            img_3_thum.Visible = false;
            img3.Visible = false;

            DataTable dtMemberPhotos = objGlobal.GetMemberPhotos(MemberCode);
            if (dtMemberPhotos.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtMemberPhotos.Rows.Count; cnt++)
                {
                    if (cnt == 0)
                    {
                        img_1_Slide.Visible = true;
                        img_1_thum.Visible = true;
                        img1.Visible = true;
                        img1_dev.Visible = true;
                        img1.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_thum.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img1.AlternateText = Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide_pop.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                    }
                    if (cnt == 1)
                    {
                        img_2_Slide.Visible = true;
                        img_2_thum.Visible = true;
                        img2.Visible = true;
                        img2_dev.Visible = true;
                        img2.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_2_thum.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_2_Slide.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img2.AlternateText = Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide_pop_2.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                    }
                    if (cnt == 2)
                    {
                        img_3_Slide.Visible = true;
                        img_3_thum.Visible = true;
                        img3.Visible = true;
                        img3_dev.Visible = true;
                        img3.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_3_thum.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_3_Slide.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img3.AlternateText = Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide_pop_3.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                    }
                }
            }
            else
            {
                img_1_Slide.Visible = true;
                img_1_thum.Visible = true;
                img1.Visible = true;
                img1_dev.Visible = true;

                img_2_Slide.Visible = true;
                img_2_thum.Visible = true;
                img2.Visible = true;
                img2_dev.Visible = true;

                img_3_Slide.Visible = true;
                img_3_thum.Visible = true;
                img3.Visible = true;
                img3_dev.Visible = true;

                if (lblGender.Text.ToString().ToUpper() == "FEMALE")
                {
                    img1.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_1_thum.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_1_Slide.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img1.AlternateText = Convert.ToString("Female.jpg");

                    img2.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_2_thum.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_2_Slide.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img2.AlternateText = Convert.ToString("Female.jpg");

                    img3.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_3_thum.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_3_Slide.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img3.AlternateText = Convert.ToString("Female.jpg");
                }
                else
                {
                    img1.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_1_thum.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_1_Slide.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img1.AlternateText = Convert.ToString("Male.jpg");

                    img2.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_2_thum.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_2_Slide.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img2.AlternateText = Convert.ToString("Male.jpg");

                    img3.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_3_thum.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_3_Slide.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img3.AlternateText = Convert.ToString("Male.jpg");
                }

            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public string BookmarkClick(string Mcode)
    {
        Console.Write("Fuction call");
        return "TRUE";
    }

    protected void lnkBookmark_Click(object sender, EventArgs e)
    {
        try
        {
            Console.Write("Fuction call");
            int M_Code = Convert.ToInt32(Request["M_id"]);
            cl_tbl_BookmarkList objBm = new cl_tbl_BookmarkList();
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            string strBookmarkList = "";
            DataTable dtBookmarkList = objBm.GetBookMarkList(MemberCode);
            bool RecExist = false;
            if (dtBookmarkList.Rows.Count > 0)
            {
                RecExist = true;
                strBookmarkList = Convert.ToString(dtBookmarkList.Rows[0]["BookmarkedProfile"]);
            }
            strBookmarkList = strBookmarkList + "," + M_Code;
            if (!RecExist)
            {
                strBookmarkList = strBookmarkList.Substring(1, strBookmarkList.Length - 1);
            }
            if (!objGlobal.CheckBookMark(MemberCode, M_Code))
            {
                objBm.InsertUpdate_tbl_BookmarkList(MemberCode, strBookmarkList);
            }
            lnkBookmark.Attributes.Add("style", "background-color: green;");
            lnkBookmark.Text = "Bookmarked";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    protected void lnkInterest_Click(object sender, EventArgs e)
    {
        try
        {
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            int M_Code = Convert.ToInt32(Request["M_id"]);
            if (objGlobal.CheckIsYetMember(MemberCode) == 0)
            {
                if (objGlobal.GetIntrestCnt(MemberCode) >= 9)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "show_Free_interest();", true);
                    return;
                }
            }
            if (!objGlobal.CheckInterest(MemberCode, M_Code))
            {
                objGlobal.InsertInterestShown(MemberCode, M_Code, 0);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_Intrest_exist();", true);
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Registration");
    }

    protected void lnkViewMore_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal_BasicDetails();", true);
            //Response.Redirect("~/Membership");
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
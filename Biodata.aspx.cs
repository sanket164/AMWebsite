using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Biodata : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    dbInteraction objdb = new dbInteraction();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetMemberDetails();
    }

    public void GetMemberDetails()
    {
        try
        {
            int MemberDays = 0;
            //lnkInterest.Visible = true;

            int M_Code = Convert.ToInt32(Request["M_id"]);
            //string P_Id = Convert.ToString(Request["P_Id"]);
            if (M_Code == 0)
            {
                Response.Redirect("/Welcome");
            }
            if (Request["Uid"] == "c0f2109d-f2d9-47a8-8825-c7fb00aa80eb")
            {
                MemberDays = 1;
            }
            else if (Request["Uid"] == "2dea213e-6e46-4cc6-9edb-3e17aa5de656")
            {
                MemberDays = 0;
            }
            else
            {
                Response.Redirect("/Welcome");
            }
            string P_Id = objGlobal.GetProfileId(M_Code);
            if (P_Id == "")
            {
                Response.Redirect("/Welcome");
            }
            DataTable dtMember = objGlobal.Load_MemberDetails(1, 0, P_Id, M_Code);
            //if (P_Id != "" && P_Id != null)
            //{
            //    MemberDays = objGlobal.CheckIsYetMember(LogInCode);
            //}
            //else
            //{
            //    MemberDays = 1;
            //}
            if (dtMember.Rows.Count > 0)
            {

                lblMemberName.Text = Convert.ToString(dtMember.Rows[0]["MemberName"]);

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

                GetMemberPhotos(M_Code);

                if (MemberDays > 0)
                {
                    //lnkViewMore.Visible = false;
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
                    //lnkViewMore.Visible = true;
                }
            }
            else
            {
                Response.Redirect("/Welcome");
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

    public void GetMemberPhotos(long MemberCode)
    {
        try
        {
            img_1_Slide.Visible = false;
            img_1_thum.Visible = false;


            img_2_Slide.Visible = false;
            img_2_thum.Visible = false;

            img_3_Slide.Visible = false;
            img_3_thum.Visible = false;

            DataTable dtMemberPhotos = objGlobal.GetMemberPhotos(MemberCode);
            if (dtMemberPhotos.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtMemberPhotos.Rows.Count; cnt++)
                {
                    if (cnt == 0)
                    {
                        img_1_Slide.Visible = true;
                        img_1_thum.Visible = true;
                        img_1_thum.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide_pop.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                    }
                    if (cnt == 1)
                    {
                        img_2_Slide.Visible = true;
                        img_2_thum.Visible = true;
                        img_2_thum.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_2_Slide.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide_pop_2.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                    }
                    if (cnt == 2)
                    {
                        img_3_Slide.Visible = true;
                        img_3_thum.Visible = true;
                        img_3_thum.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_3_Slide.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                        img_1_Slide_pop_3.ImageUrl = "~/MemberPhoto/" + Convert.ToString(dtMemberPhotos.Rows[cnt]["PhotoFileName"]);
                    }
                }
            }
            else
            {
                img_1_Slide.Visible = true;
                img_1_thum.Visible = true;

                img_2_Slide.Visible = true;
                img_2_thum.Visible = true;

                img_3_Slide.Visible = true;
                img_3_thum.Visible = true;

                if (lblGender.Text.ToString().ToUpper() == "FEMALE")
                {
                    img_1_thum.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_1_Slide.ImageUrl = "~/MemberPhoto/Female.jpg";

                    img_2_thum.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_2_Slide.ImageUrl = "~/MemberPhoto/Female.jpg";

                    img_3_thum.ImageUrl = "~/MemberPhoto/Female.jpg";
                    img_3_Slide.ImageUrl = "~/MemberPhoto/Female.jpg";
                }
                else
                {
                    img_1_thum.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_1_Slide.ImageUrl = "~/MemberPhoto/Male.jpg";

                    img_2_thum.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_2_Slide.ImageUrl = "~/MemberPhoto/Male.jpg";

                    img_3_thum.ImageUrl = "~/MemberPhoto/Male.jpg";
                    img_3_Slide.ImageUrl = "~/MemberPhoto/Male.jpg";
                }

            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

}
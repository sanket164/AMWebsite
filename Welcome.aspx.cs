using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Welcome : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    dbInteraction objDb = new dbInteraction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MemberCode"] == null)
            {
                Response.Redirect("/Default");
            }
            GetMemberDetails();
            GetLoad_MFProfileList(Convert.ToInt64(Session["MemberCode"]));
        }
    }

    public void GetMemberDetails()
    {
        try
        {
            long MemberCode = Convert.ToInt64(Session["MemberCode"]);
            DataTable dtMember = objGlobal.GetMemberDetails(MemberCode);
            if (dtMember.Rows.Count > 0)
            {
                string MemberDetails = Convert.ToString(dtMember.Rows[0]["MemberName"]);
                MemberDetails += " (" + Convert.ToString(dtMember.Rows[0]["ProfileId"]) + ")";
                lblMemberName.Text = MemberDetails;
                DataTable dtdetais = objGlobal.GetExperienceDate(MemberCode);
                if (dtdetais.Rows.Count>0)
                {
                    lblMemberShipValidMessage.Text = "Your membership is valid Up " + dtdetais.Rows[0]["enddate"];
                    div_promo.Visible = true;
                    div_promo.Style.Add("display", "");
                }
            }
            bool isUpload = objGlobal.GetUploadPhotoStatus(MemberCode);
            if (!isUpload)
            {
                lblPhotoUploadMSG1.Visible = true;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void GetLoad_MFProfileList(long MemberCode)
    {
        try
        {
            int s_Gender = objGlobal.GetGender(MemberCode);
            if (s_Gender == 0)
            {
                s_Gender = 1;
            }
            else
            {
                s_Gender = 0;
            }
            int MaritalStatus = 0;
            int FromYear = 1950, ToYear = 1996;
            int AgeDiff = objGlobal.GetAgeDiff(MemberCode);
            DataTable dtMemberList = objDb.GetDataTable("select * from tbl_MemberMaster  where MemberCode=" + MemberCode);
            if (dtMemberList.Rows.Count > 0)
            {
                if (Convert.ToString(dtMemberList.Rows[0]["DateOfBirth"]) != "")
                {
                    DateTime DOB = Convert.ToDateTime(dtMemberList.Rows[0]["DateOfBirth"]);
                    FromYear = DOB.Year;
                    ////0= Male, 1=Female
                    if (Convert.ToString(Session["Gender"]) == "0")
                    {
                        ToYear = FromYear + AgeDiff;
                    }
                    else
                    {
                        ToYear = FromYear;
                        FromYear = FromYear - AgeDiff;
                    }
                }
                if (Convert.ToString(dtMemberList.Rows[0]["MaritalStatus"]) != "")
                {
                    MaritalStatus = Convert.ToInt32(dtMemberList.Rows[0]["MaritalStatus"]);
                }
            }
            DataTable dtProfile = objGlobal.GetRecommend_ProfileList(s_Gender, FromYear, ToYear, MaritalStatus);
            string strHTML = "";
            strHTML += " <div class='row'> ";
            strHTML += " <div id='prof-slider' class='carousel slide'> ";
            strHTML += " <div class='carousel-inner'> ";
            //for (int cnt = 0; cnt < dtProfile.Rows.Count; cnt++)
            int iRowCnt = 8;
            if (dtProfile.Rows.Count < 8)
            {
                iRowCnt = dtProfile.Rows.Count;
            }
            for (int cnt = 0; cnt < iRowCnt; cnt++)
            {
                if (Convert.ToString(dtProfile.Rows[cnt]["MemberCode"]) != "")
                {
                    if ((cnt + 1) <= 4)
                    {
                        if ((cnt + 1) == 1)
                        {
                            strHTML += " <div class='item active'> ";
                            strHTML += " <div class='row'> ";
                        }
                        strHTML += " <div class='col-md-3 col-sm-6'> ";
                        strHTML += " <div class='prof-box'> ";
                        strHTML += " <div class='prof-id'> ";
                        strHTML += " <h4>" + Convert.ToString(dtProfile.Rows[cnt]["ProfileID"]) + "</h4> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-img'> ";
                        strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtProfile.Rows[cnt]["PhotoFileName"]) + "' /> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-details'> ";
                        strHTML += " <ul> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["BirthYear"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["Height"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["Caste"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["MaritalStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["Education"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["StateCity"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["VisaStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Visa Country<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["VisaCountry"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " </ul> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='view-more'> ";
                        strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtProfile.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtProfile.Rows[cnt]["ProfileID"]) + "' target='_blank'>View More</a> ";
                        strHTML += " </div> ";
                        strHTML += " </div> ";
                        strHTML += " </div> ";
                        if ((cnt + 1) == 4)
                        {
                            strHTML += " </div> ";
                            strHTML += " </div> ";
                        }
                    }
                    else
                    {
                        if ((cnt + 1) == 5 || (cnt + 1) == 9 || (cnt + 1) == 13)
                        {
                            strHTML += " <div class='item'> ";
                            strHTML += " <div class='row'> ";
                        }
                        strHTML += " <div class='col-md-3 col-sm-6'> ";
                        strHTML += " <div class='prof-box'> ";
                        strHTML += " <div class='prof-id'> ";
                        strHTML += " <h4>" + Convert.ToString(dtProfile.Rows[cnt]["ProfileID"]) + "</h4> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-img'> ";
                        strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtProfile.Rows[cnt]["PhotoFileName"]) + "' /> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-details'> ";
                        strHTML += " <ul> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["BirthYear"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["Height"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["Caste"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["MaritalStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["Education"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["StateCity"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["VisaStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Visa Country<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtProfile.Rows[cnt]["VisaCountry"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " </ul> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='view-more'> ";
                        strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtProfile.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtProfile.Rows[cnt]["ProfileID"]) + "' target='_blank'>View More</a> ";
                        strHTML += " </div> ";
                        strHTML += " </div> ";
                        strHTML += " </div> ";
                        if ((cnt + 1) % 4 == 0)
                        {
                            strHTML += " </div> ";
                            strHTML += " </div> ";
                        }
                    }
                }
            }
            strHTML += " </div> ";
            strHTML += " <a class='left carousel-control' href='#prof-slider' data-slide='prev'>‹</a> ";
            strHTML += " <a class='right carousel-control' href='#prof-slider' data-slide='next'>›</a> ";
            strHTML += " </div> ";
            strHTML += " </div>";
            ltrLoadRecom.Text = strHTML;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}
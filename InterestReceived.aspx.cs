using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InterestReceived : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MemberCode"] == null)
            {
                Response.Redirect("/Default");
            }
            if (Session["MemberCode"] != null)
            {
                long MemberCode = Convert.ToInt64(Session["MemberCode"]);
                string strRes = Request["Op"];
                if (strRes == "Interest")
                {
                    long IMemId = Convert.ToInt64(Request["IMemId"]);
                    int Res = Convert.ToInt32(Request["Res"]);
                    objGlobal.Update_tbl_InterestShown(IMemId, MemberCode, Res);
                    Response.Redirect("/InterestReceived");
                }
                GetInterestRec(MemberCode);
            }
        }
    }

    public void GetInterestRec(long MemberCode)
    {
        try
        {
            string strHTML = "";
            cl_tbl_BookmarkList objBM = new cl_tbl_BookmarkList();
            DataTable dtInterestRecList = objGlobal.GetInterestReceived(MemberCode, 1);
            if (dtInterestRecList.Rows.Count > 0)
            {
                strHTML = " <div id='prof-slider' class='carousel slide'> ";
                strHTML += " <p>Interest for <span class='comment'>" + dtInterestRecList.Rows.Count + "</span>profile has been received</p> ";
                strHTML += " <div class='carousel-inner'> ";
                for (int cnt = 0; cnt < dtInterestRecList.Rows.Count; cnt++)
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
                        strHTML += " <h4>" + Convert.ToString(dtInterestRecList.Rows[cnt]["ProfileID"]) + "</h4> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-img'> ";
                        strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtInterestRecList.Rows[cnt]["PhotoFileName"]) + "' /> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-details'> ";
                        strHTML += " <ul> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["BirthYear"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["Height"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["Caste"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["MaritalStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["Education"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["StateCity"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        //strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'></div> ";
                        strHTML += " </li> ";
                        strHTML += " </ul> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='view-more'> ";
                        //strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtBookmarkList.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtBookmarkList.Rows[cnt]["ProfileID"]) + "'>View More</a> ";

                        bool IsIterest = objGlobal.CheckIsInterested(Convert.ToInt64(dtInterestRecList.Rows[cnt]["MemberCode"]), MemberCode);
                        if (IsIterest)
                        {
                            strHTML += " <a style='background-color: green;color:  white;border:green'>Accepted</a> ";
                            strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtInterestRecList.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtInterestRecList.Rows[cnt]["ProfileID"]) + "'>View More</a> ";
                            //strHTML += " <a href='/InterestReceived?Op=Interest&IMemId=" + Convert.ToString(dtInterestRecList.Rows[cnt]["MemberCode"]) + "&Res=0'>View More</a> ";
                        }
                        else
                        {
                            strHTML += " <a href='/InterestReceived?Op=Interest&IMemId=" + Convert.ToString(dtInterestRecList.Rows[cnt]["MemberCode"]) + "&Res=1'>Accept</a> ";
                            strHTML += " <a href='/InterestReceived?Op=Interest&IMemId=" + Convert.ToString(dtInterestRecList.Rows[cnt]["MemberCode"]) + "&Res=0'>Decline</a><br /><br /> ";
                            strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtInterestRecList.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtInterestRecList.Rows[cnt]["ProfileID"]) + "' style='width: 95%;'>View More</a> ";
                        }
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
                        strHTML += " <h4>" + Convert.ToString(dtInterestRecList.Rows[cnt]["ProfileID"]) + "-" + (cnt + 1) + "</h4> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-img'> ";
                        strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtInterestRecList.Rows[cnt]["PhotoFileName"]) + "' /> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-details'> ";
                        strHTML += " <ul> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["BirthYear"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["Height"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["Caste"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["MaritalStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["Education"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestRecList.Rows[cnt]["StateCity"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'> N A </div> ";
                        strHTML += " </li> ";
                        strHTML += " </ul> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='view-more'> ";
                        //strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtBookmarkList.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtBookmarkList.Rows[cnt]["ProfileID"]) + "'>View More</a> ";
                        strHTML += " <a href='/InterestReceived?Op=Interest&IMemId=" + Convert.ToString(dtInterestRecList.Rows[cnt]["MemberCode"]) + "&Res=1'>Accept</a> ";
                        strHTML += " <a href='/InterestReceived?Op=Interest&IMemId=" + Convert.ToString(dtInterestRecList.Rows[cnt]["MemberCode"]) + "&Res=0'>Decline</a> ";
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
                strHTML += " </div> ";
                strHTML += " </div>";
                strHTML += " </div> ";
                strHTML += " <a class='left carousel-control' href='#prof-slider' data-slide='prev'>‹</a> ";
                strHTML += " <a class='right carousel-control' href='#prof-slider' data-slide='next'>›</a> ";
                strHTML += " </div>";
                ltrBodySection.Text = strHTML;
            }
            else
            {
                strHTML = "";
                strHTML = " <div class='prof-img'> ";
                strHTML += " <img class='img-responsive' src='images/InterstRec.png' /> ";
                strHTML += " </div> ";
                strHTML += " <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />";
                //strHTML += " <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />";
                ltrBodySection.Text = strHTML;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }


}
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
                GetInterestSend(MemberCode);
            }
        }
    }

    public void GetInterestSend(long MemberCode)
    {
        try
        {
            string strHTML = "";
            DataTable dtInterestSendList = objGlobal.GetInterestSend(MemberCode, 1);
            if (dtInterestSendList.Rows.Count > 0)
            {
                strHTML = " <div id='prof-slider' class='carousel slide'> ";
                strHTML += " <div class='carousel-inner'> ";
                for (int cnt = 0; cnt < dtInterestSendList.Rows.Count; cnt++)
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
                        strHTML += " <h4>" + Convert.ToString(dtInterestSendList.Rows[cnt]["ProfileID"]) + "</h4> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-img'> ";
                        strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtInterestSendList.Rows[cnt]["PhotoFileName"]) + "' /> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-details'> ";
                        strHTML += " <ul> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["BirthYear"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["Height"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["Caste"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["MaritalStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["Education"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["StateCity"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " </ul> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='view-more'> ";
                        strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtInterestSendList.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtInterestSendList.Rows[cnt]["ProfileID"]) + "'>View More</a> ";
                        bool IsIterest = objGlobal.CheckIsInterested(MemberCode, Convert.ToInt64(dtInterestSendList.Rows[cnt]["MemberCode"]));
                        if (!IsIterest)
                        {
                            strHTML += " <a style='background-color: #ca3b3b;color:  white;' >Pending</a> ";
                        }
                        else
                        {
                            strHTML += " <a style='background-color: green;color:  white;border:green'>Accept</a> ";
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
                        strHTML += " <h4>" + Convert.ToString(dtInterestSendList.Rows[cnt]["ProfileID"]) + "</h4> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-img'> ";
                        strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtInterestSendList.Rows[cnt]["PhotoFileName"]) + "' /> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='prof-details'> ";
                        strHTML += " <ul> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["BirthYear"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["Height"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["Caste"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["MaritalStatus"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["Education"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " <li> ";
                        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtInterestSendList.Rows[cnt]["StateCity"]) + "</div> ";
                        strHTML += " </li> ";
                        strHTML += " </ul> ";
                        strHTML += " </div> ";
                        strHTML += " <div class='view-more'> ";
                        strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtInterestSendList.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtInterestSendList.Rows[cnt]["ProfileID"]) + "'>View More</a> ";
                        bool IsIterest = objGlobal.CheckIsInterested(MemberCode, Convert.ToInt64(dtInterestSendList.Rows[cnt]["MemberCode"]));
                        if (!IsIterest)
                        {
                            strHTML += " <a style='background-color: #ca3b3b;color:  white;' >Pending</a> ";
                        }
                        else
                        {
                            strHTML += " <a style='background-color: green;color:  white;border:green'>Accept</a> ";
                        }
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
                strHTML += " <a class='left carousel-control' href='#prof-slider' data-slide='prev'>‹</a> ";
                strHTML += " <a class='right carousel-control' href='#prof-slider' data-slide='next'>›</a> ";
                strHTML += " </div> ";
                strHTML += " </div> ";
                strHTML += " </div>";
                ltrBodySection.Text = strHTML;
            }
            else
            {
                //strHTML = "";
                //strHTML = "<p>Hello,</p> ";
                //strHTML += "<p>You have not express your interest to any of the profile yet</p>";
                strHTML = " <div class='prof-img'> ";
                strHTML += " <img class='img-responsive' src='images/IntrestSend.png' /> ";
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
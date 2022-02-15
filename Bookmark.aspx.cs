using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bookmark : System.Web.UI.Page
{
    UD_Global objGlobal = new UD_Global();
    dbInteraction objDb = new dbInteraction();

    string StrSql = "";

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
                Delete(MemberCode);
                GetBookMark(MemberCode);
            }
        }
    }

    public void Delete(long MemberCode)
    {
        try
        {

            if (Request["M_id"] != null)
            {

                string strBookmarkList = "";
                long M_Code = Convert.ToInt32(Request["M_id"]);
                cl_tbl_BookmarkList objBM = new cl_tbl_BookmarkList();
                DataTable dtBookmarkList = objBM.GetBookMarkList(MemberCode);
                if (dtBookmarkList.Rows.Count > 0)
                {
                    string BookmarkedProfile = Convert.ToString(dtBookmarkList.Rows[0]["BookmarkedProfile"]);
                    StrSql = "SELECT items FROM dbo.Split('" + BookmarkedProfile + "',',')";
                    DataTable dtB_Profile = objDb.GetDataTable(StrSql);
                    for (int cnt = 0; cnt < dtB_Profile.Rows.Count; cnt++)
                    {
                        if (M_Code.ToString() != Convert.ToString(dtB_Profile.Rows[cnt]["items"]).Trim())
                        {
                            strBookmarkList = strBookmarkList + "," + Convert.ToString(dtB_Profile.Rows[cnt]["items"]);
                        }
                    }
                    if (strBookmarkList.Length > 0)
                    {
                        strBookmarkList = strBookmarkList.Substring(1, strBookmarkList.Length - 1);
                    }
                    objBM.InsertUpdate_tbl_BookmarkList(MemberCode, strBookmarkList);
                    Response.Redirect("Bookmark");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    public void GetBookMark(long MemberCode)
    {
        try
        {
            string strHTML = "";
            cl_tbl_BookmarkList objBM = new cl_tbl_BookmarkList();
            DataTable dtBookmarkList = objBM.GetBookMarkList(MemberCode);
            if (dtBookmarkList.Rows.Count > 0)
            {
                int _temp = 5;
                for (int icnt = 0; icnt < dtBookmarkList.Rows.Count; icnt++)
                {
                    string BookmarkedProfile = Convert.ToString(dtBookmarkList.Rows[icnt]["BookmarkedProfile"]);
                    int TotalCnt = 0;
                    int intPageNo = Convert.ToInt32(Request["pg_no"]);
                    DataTable dtMemberDetails = objBM.Load_BookmasterList_New(BookmarkedProfile, intPageNo, out TotalCnt);
                    SetHTML(dtMemberDetails, TotalCnt);
                    //strHTML = " <div id='prof-slider' class='carousel slide'> ";
                    //strHTML += " <p>Total <span class='comment'>" + dtMemberDetails.Rows.Count + "</span> Profile Bookmarked</p> ";
                    //strHTML += " <div class='carousel-inner'> ";
                    //for (int cnt = 0; cnt < dtMemberDetails.Rows.Count; cnt++)
                    //{
                    //    if ((cnt + 1) <= 4)
                    //    {
                    //        if ((cnt + 1) == 1)
                    //        {
                    //            strHTML += " <div class='item active'> ";
                    //            strHTML += " <div class='row'> ";
                    //        }
                    //        strHTML += " <div class='col-md-3 col-sm-6'> ";
                    //        strHTML += " <div class='prof-box'> ";
                    //        strHTML += " <div class='prof-id'> ";
                    //        strHTML += " <h4>" + Convert.ToString(dtMemberDetails.Rows[cnt]["ProfileID"]) + " </h4> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " <div class='prof-img'> ";
                    //        strHTML += " <img class='img-responsive' src='/MemberPhoto/" + Convert.ToString(dtMemberDetails.Rows[cnt]["PhotoFileName"]) + "' /> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " <div class='prof-details'> ";
                    //        strHTML += " <ul> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["BirthYear"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Height"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Caste"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["MaritalStatus"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Education"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["StateCity"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Country"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " </ul> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " <div class='view-more'> ";
                    //        strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtMemberDetails.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtMemberDetails.Rows[cnt]["ProfileID"]) + "' target='_blank' >View More</a> ";
                    //        strHTML += " <a href='/Bookmark?M_id=" + Convert.ToString(dtMemberDetails.Rows[cnt]["MemberCode"]) + "' OnClick = \"return confirm('Are you sure?')\" >Delete</a> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " </div> ";
                    //        if ((cnt + 1) == 4)
                    //        {
                    //            strHTML += " </div> ";
                    //            strHTML += " </div> ";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if ((cnt + 1) == _temp)
                    //        //if ((cnt + 1) == 5 || (cnt + 1) == 9 || (cnt + 1) == 13 || (cnt + 1) == 17 || (cnt + 1) == 21 || (cnt + 1) == 25 || (cnt + 1) == 29 || (cnt + 1) == 33 || (cnt + 1) == 37)
                    //        {
                    //            _temp += 4;
                    //            strHTML += " <div class='item'> ";
                    //            strHTML += " <div class='row'> ";
                    //        }
                    //        strHTML += " <div class='col-md-3 col-sm-6'> ";
                    //        strHTML += " <div class='prof-box'> ";
                    //        strHTML += " <div class='prof-id'> ";
                    //        strHTML += " <h4>" + Convert.ToString(dtMemberDetails.Rows[cnt]["ProfileID"]) + "</h4> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " <div class='prof-img'> ";
                    //        strHTML += " <img class='img-responsive' src='/MemberPhoto/" + Convert.ToString(dtMemberDetails.Rows[cnt]["PhotoFileName"]) + "' /> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " <div class='prof-details'> ";
                    //        strHTML += " <ul> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["BirthYear"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Height"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Caste"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["MaritalStatus"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Education"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["StateCity"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " <li> ";
                    //        strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtMemberDetails.Rows[cnt]["Country"]) + "</div> ";
                    //        strHTML += " </li> ";
                    //        strHTML += " </ul> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " <div class='view-more'> ";
                    //        strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtMemberDetails.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtMemberDetails.Rows[cnt]["ProfileID"]) + "' target='_blank'>View More</a> ";
                    //        strHTML += " <a href='/Bookmark?M_id=" + Convert.ToString(dtMemberDetails.Rows[cnt]["MemberCode"]) + "' OnClick = \"return confirm('Are you sure?')\" >Delete</a> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " </div> ";
                    //        strHTML += " </div> ";
                    //        if ((cnt + 1) % 4 == 0 && (cnt + 1) != dtMemberDetails.Rows.Count)
                    //        {
                    //            strHTML += " </div> ";
                    //            strHTML += " </div> ";
                    //        }
                    //        else if ((cnt + 1) == dtMemberDetails.Rows.Count)
                    //        {
                    //            strHTML += " </div> ";
                    //            strHTML += " </div> ";
                    //        }
                    //    }
                    //}
                    //strHTML += " </div> ";
                    //strHTML += " <a class='left carousel-control' href='#prof-slider' data-slide='prev'>‹</a> ";
                    //strHTML += " <a class='right carousel-control' href='#prof-slider' data-slide='next'>›</a> ";
                    //strHTML += " </div>";
                    //strHTML += " </div>";
                    //strHTML += " </div>";
                    //ltrBodySection.Text = strHTML;
                }
            }
            else
            {
                //strHTML = "";
                //strHTML = " <div> ";
                //strHTML += " <img class='img-responsive' src='images/Bookmark.png' /> ";
                //strHTML += " </div> ";
                //strHTML += " <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />";
                //ltrBodySection.Text = strHTML;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void Delete_BookmarkList(long MemberCode, long BookmarkId)
    {
        try
        {
            string strSql = "select * form ";
        }
        catch (Exception ex)
        {

        }
    }

    public void SetHTML(DataTable dtDetails, int TotalCnt)
    {
        try
        {
            if (dtDetails.Rows.Count == 0)
            {
                ltrBodySection.Text = " <p>No records found</p>";
            }
            else
            {
                string strHTML = "";
                lblTotalMsg.Text = "Total " + TotalCnt + " profile found";
                for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                {
                    strHTML += " <div class='col-md-3 col-sm-6'> ";
                    strHTML += " <div class='prof-box'> ";
                    strHTML += " <div class='prof-id'> ";
                    strHTML += " <h4>" + Convert.ToString(dtDetails.Rows[cnt]["ProfileID"]) + "</h4> ";
                    strHTML += " </div> ";
                    strHTML += " <div class='prof-img'> ";
                    strHTML += " <img class='img-responsive' src='MemberPhoto/" + Convert.ToString(dtDetails.Rows[cnt]["PhotoFileName"]) + "' /> ";
                    strHTML += " </div> ";
                    strHTML += " <div class='prof-details'> ";
                    strHTML += " <ul> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Year<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["BirthYear"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += "  <li> ";
                    strHTML += " <label>Height<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["Height"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Religion Caste<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["Caste"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Marital Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["MaritalStatus"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>Education<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["Education"]) + "</div> ";
                    strHTML += " </li> ";
                    strHTML += " <li> ";
                    strHTML += " <label>State / City<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["StateCity"]) + "</div> ";
                    strHTML += " </li> ";
                    //strHTML += " <li> ";
                    //strHTML += " <label>Visa Status<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["VisaStatus"]) + "</div> ";
                    //strHTML += " </li> ";
                    //strHTML += " <li> ";
                    //strHTML += " <label>Visa Country<span>:</span></label><div class='prof-val'>" + Convert.ToString(dtDetails.Rows[cnt]["VisaCountry"]) + "</div> ";
                    //strHTML += " </li> ";
                    strHTML += " </ul> ";
                    strHTML += " </div> ";
                    strHTML += " <div class='view-more'> ";
                    strHTML += " <a href='/MemberDetails?M_id=" + Convert.ToString(dtDetails.Rows[cnt]["MemberCode"]) + "&P_Id=" + Convert.ToString(dtDetails.Rows[cnt]["ProfileID"]) + "' target='_blank' style='float:left;'>View More</a> ";
                    strHTML += " <a href='/Bookmark?M_id=" + Convert.ToString(dtDetails.Rows[cnt]["MemberCode"]) + "' OnClick = \"return confirm('Are you sure?')\" style='float:left;' >Delete</a> ";
                    strHTML += " </div> ";
                    strHTML += " </div> ";
                    strHTML += " </div> ";
                }
                int intPageNo = 1;
                if (Request["pg_no"] != null)
                {
                    intPageNo = Convert.ToInt32(Request["pg_no"]);
                }
                var totalPages = (int)Math.Ceiling((decimal)TotalCnt / (decimal)8);
                var currentPage = intPageNo != null ? (int)intPageNo : 1;
                var startPage = currentPage - 5;
                var endPage = currentPage + 4;
                if (startPage <= 0)
                {
                    endPage -= (startPage - 1);
                    startPage = 1;
                }
                if (endPage > totalPages)
                {
                    endPage = totalPages;
                    if (endPage > 10)
                    {
                        startPage = endPage - 9;
                    }
                }

                strHTML += " <ul class='pagination' style='width :-webkit-fill-available'> ";
                if (currentPage > 1)
                {
                    strHTML += " <li><a href='/Bookmark?pg_no=1'>First</a></li> ";
                    strHTML += " <li><a href='/Bookmark?pg_no=" + (intPageNo - 1) + "'>Previous</a></li>";
                }
                for (int cnt = startPage; cnt <= endPage; cnt++)
                {
                    if (intPageNo == (cnt))
                    {
                        strHTML += " <li class='active'><a href='/Bookmark?pg_no=" + (cnt) + "''>" + (cnt) + "</a></li> ";
                    }
                    else
                    {
                        strHTML += " <li><a href='/Bookmark?pg_no=" + (cnt) + "'>" + (cnt) + "</a></li> ";
                    }
                }
                //if (intPageNo != TotalRow)
                //{
                //    strHTML += " <div class='pageing_clo'><a rel='next' href='/Bookmark.aspx?PageNo=" + (intPageNo + 1) + "')'>Next</a></div> ";
                //}
                if (currentPage < totalPages)
                {
                    strHTML += " <li> <a href='/Bookmark?pg_no=" + (intPageNo + 1) + "'>Next</a> </li>";
                    strHTML += " <li> <a href='/Bookmark?pg_no=" + totalPages + "'>Last</a> </li>";
                }

                strHTML += " </ul>";                
                strHTML += " <div class='form-group input-group-lg' style='display:inline-block; float:left; margin-right:10px;'> ";
                strHTML += "<br/> ";
                //strHTML += " <a> Go to page  ";
                //strHTML += " <input size='7' placeholder='page #'><button class='btn btn-primary btn-xl'>Go</button></a></div>";
                ltrBodySection.Text = strHTML;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

}
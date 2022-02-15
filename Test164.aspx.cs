using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test164 : System.Web.UI.Page
{
    dbInteraction objdb = new dbInteraction();
    UD_Global objGlobal = new UD_Global();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtCaste = objGlobal.GetCasteList("");
        lstCaste.DataSource = dtCaste;
        lstCaste.DataValueField = "CasteCode";
        lstCaste.DataTextField = "Caste";
        lstCaste.DataBind();
        lstCaste.Items.Insert(0, new ListItem("Any", ""));
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string strSql = " select mp.* from tbl_MemberMaster mm  inner join tbl_MemberPhotos mp on mp.MemberCode =mm.MemberCode WHERE mm.isActive=1";
            DataTable dtDetails = objdb.GetDataTable(strSql);
            if (dtDetails.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                {
                    //File.Copy(@"anantmatrimony.com/httpdocs/MemberPhoto/" + Convert.ToString(dtDetails.Rows[cnt]["PhotoFileName"]), "~/MemberPhoto/");
                    string filename = @"~\MemberPhoto\"+Convert.ToString(dtDetails.Rows[cnt]["PhotoFileName"]);
                    string ftpServerIP = "anantmatrimony.com";
                    string ftpUserID = "anantmatrimony";
                    string ftpPassword = "Changeme@123";

                    FileInfo fileInf = new FileInfo(filename);

                    string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;

                    FtpWebRequest reqFTP;

                    // Create FtpWebRequest object 
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));

                    //Provide ftp userid and password 
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                    // By default KeepAlive is true, where the control connection is not closed 
                    // after a command is executed. 
                    reqFTP.KeepAlive = false;

                    //Specify the command to be executed. Here we use upload file command 
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;

                    //data transfer type we use here is binary 
                    reqFTP.UseBinary = true;

                    // Notify the server about the size of the uploaded file 
                    reqFTP.ContentLength = fileInf.Length;

                    // The buffer size is set to 2kb 
                    int buffLength = 2048;

                    byte[] buff = new byte[buffLength];

                    int contentLen;

                    // Opens a file stream (System.IO.FileStream) to read the file to be uploaded 
                    FileStream fs = fileInf.OpenRead();

                    try
                    {

                        // Stream to which the file to be upload is written 
                        Stream strm = reqFTP.GetRequestStream();

                        // Read from the file stream 2kb at a time 
                        contentLen = fs.Read(buff, 0, buffLength);

                        // Till Stream content ends 
                        while (contentLen != 0)
                        {

                            // Write Content from the file stream to the FTP Upload Stream 
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }

                        // Close the file stream and the Request Stream 
                        strm.Close();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        string ErrMsg = ex.Message;
                    } 

                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
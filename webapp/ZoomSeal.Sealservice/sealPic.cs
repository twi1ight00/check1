using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ZoomSeal.Sealservice;

public class sealPic : Page
{
	protected HtmlForm form1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["userName"] == null || Session["userName"].ToString() == "" || Session["userPw"] == null || Session["userPw"].ToString() == "")
		{
			base.Response.Redirect("login.aspx");
		}
		if (Session["imagePic"] != null && Session["imagePic"].ToString().Trim().Length > 0 && Session["fileExPic"] != null && Session["fileExPic"].ToString().Length > 0)
		{
			byte[] b = (byte[])Session["imagePic"];
			string imgType = "image/" + Session["fileExPic"].ToString();
			string imgName = "down." + imgType;
			base.Response.ContentType = imgType;
			base.Response.AddHeader("Content-Disposition", "attachment; filename=" + imgName);
			base.Response.AddHeader("Content-Length", b.Length.ToString());
			base.Response.Clear();
			Stream fs = base.Response.OutputStream;
			fs.Write(b, 0, b.Length);
			fs.Close();
			Session["imagePic"] = null;
			Session["fileExPic"] = null;
		}
	}
}

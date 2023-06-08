using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using PageOffice;

namespace webapp.Packages.OnlineOffice.POBrowser2;

public class SaveFile : Page
{
	protected HtmlForm form1;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (base.Request["action"] != null)
			{
				FileSaver fs = new FileSaver();
				string fileName = HttpContext.Current.Server.MapPath("/") + base.Request.QueryString["Path"] + base.Request.QueryString["Name"] + "." + base.Request.QueryString["fileType"];
				string streamfile = HttpContext.Current.Server.MapPath("/") + base.Request.QueryString["Path"] + base.Request.QueryString["Name"];
				fs.SaveToFile(fileName);
				fs.CustomSaveResult = "OK";
				fs.Close();
				if (File.Exists(streamfile))
				{
					File.Delete(streamfile);
					File.Move(fileName, streamfile);
				}
				else
				{
					File.Move(fileName, streamfile);
				}
				File.Delete(fileName);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}

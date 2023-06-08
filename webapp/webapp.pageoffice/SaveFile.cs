using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Aspose.Words;
using PageOffice;

namespace webapp.pageoffice;

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
				string fileName = base.Server.MapPath("/upload/online/files/") + base.Request.QueryString["FileName"];
				fs.SaveToFile(fileName);
				fs.CustomSaveResult = "OK";
				fs.Close();
				string pdfName = base.Server.MapPath("/upload/online/files/") + base.Request.QueryString["FileName"].Replace(".doc", ".pdf");
				Document doc = new Document(fileName);
				doc.Save(pdfName, SaveFormat.Pdf);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}

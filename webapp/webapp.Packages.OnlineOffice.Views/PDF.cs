using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using PageOffice;

namespace webapp.Packages.OnlineOffice.Views;

public class PDF : Page
{
	protected HtmlForm form1;

	protected PDFCtrl PageOfficeCtrl1;

	public string OfficeId
	{
		get
		{
			if (base.Request.QueryString["officeId"] == null)
			{
				return Guid.NewGuid().ToString();
			}
			return base.Request.QueryString["officeId"];
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void PageOfficeCtrl1_Load(object sender, EventArgs e)
	{
		PageOfficeCtrl1.ServerPage = "/Packages/OnlineOffice/Views/server.aspx";
		PageOfficeCtrl1.Theme = ThemeType.Office2007;
		PageOfficeCtrl1.AddCustomToolButton("打印", "Print()", 6);
		PageOfficeCtrl1.AddCustomToolButton("-", "", 0);
		PageOfficeCtrl1.AddCustomToolButton("实际大小", "SetPageReal()", 16);
		PageOfficeCtrl1.AddCustomToolButton("适合页面", "SetPageFit()", 17);
		PageOfficeCtrl1.AddCustomToolButton("适合宽度", "SetPageWidth()", 18);
		PageOfficeCtrl1.AddCustomToolButton("-", "", 0);
		PageOfficeCtrl1.AddCustomToolButton("首页", "FirstPage()", 8);
		PageOfficeCtrl1.AddCustomToolButton("上一页", "PreviousPage()", 9);
		PageOfficeCtrl1.AddCustomToolButton("下一页", "NextPage()", 10);
		PageOfficeCtrl1.AddCustomToolButton("尾页", "LastPage()", 11);
		PageOfficeCtrl1.AddCustomToolButton("-", "", 0);
		string fileName = OfficeId + ".pdf";
		string filePath = HttpContext.Current.Server.MapPath("/upload/online/files/") + fileName;
		PageOfficeCtrl1.WebOpen(filePath);
	}
}

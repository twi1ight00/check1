using System;
using System.IO;
using System.Web;
using System.Web.UI;
using Microsoft.JScript;
using PageOffice;

namespace webapp.Packages.OnlineOffice;

public class view : Page
{
	protected PageOfficeCtrl PageOfficeCtrl1;

	protected PDFCtrl Pdfctrl1;

	public string Subject
	{
		get
		{
			if (base.Request.QueryString["Subject"] == null)
			{
				return "无效文件名称";
			}
			return GlobalObject.unescape(base.Request.QueryString["Subject"]);
		}
	}

	public string filePath
	{
		get
		{
			if (base.Request.QueryString["filePath"] == null)
			{
				return "";
			}
			string filePath = HttpContext.Current.Server.MapPath("/") + GlobalObject.unescape(base.Request.QueryString["filePath"]);
			if (!File.Exists(filePath))
			{
				File.Copy(filePath.Substring(0, filePath.LastIndexOf(".")), filePath, overwrite: true);
			}
			return filePath;
		}
	}

	public filetype filetype
	{
		get
		{
			if (base.Request.QueryString["filetype"] == null)
			{
				return filetype.none;
			}
			return (filetype)int.Parse(base.Request.QueryString["filetype"]);
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		PageOfficeCtrl1.ServerPage = "/Packages/OnlineOffice/Views/server.aspx";
		Pdfctrl1.ServerPage = "/Packages/OnlineOffice/Views/server.aspx";
		switch (filetype)
		{
		case filetype.doc:
			initdoc();
			break;
		case filetype.pdf:
			initpdf();
			break;
		case filetype.ppt:
			initppt();
			break;
		case filetype.excel:
			initexcel();
			break;
		case filetype.img:
			initimg();
			break;
		}
	}

	private void initexcel()
	{
		try
		{
			Pdfctrl1.Visible = false;
			PageOfficeCtrl1.Visible = true;
			PageOfficeCtrl1.Caption = GlobalObject.unescape(Subject);
			PageOfficeCtrl1.WebOpen(filePath, OpenModeType.xlsReadOnly, "Tom");
		}
		catch (Exception)
		{
		}
	}

	private void initimg()
	{
		throw new NotImplementedException();
	}

	private void initppt()
	{
		try
		{
			Pdfctrl1.Visible = false;
			PageOfficeCtrl1.Visible = true;
			PageOfficeCtrl1.Caption = GlobalObject.unescape(Subject);
			PageOfficeCtrl1.WebOpen(filePath, OpenModeType.pptReadOnly, "Tom");
		}
		catch (Exception)
		{
		}
	}

	private void initdoc()
	{
		try
		{
			Pdfctrl1.Visible = false;
			PageOfficeCtrl1.Visible = true;
			PageOfficeCtrl1.Caption = GlobalObject.unescape(Subject);
			PageOfficeCtrl1.WebOpen(filePath, OpenModeType.docReadOnly, "游客");
		}
		catch (Exception)
		{
		}
	}

	private void initpdf()
	{
		try
		{
			Pdfctrl1.Visible = true;
			PageOfficeCtrl1.Visible = false;
			Pdfctrl1.AddCustomToolButton("打印", "Print()", 6);
			Pdfctrl1.AddCustomToolButton("-", "", 0);
			Pdfctrl1.AddCustomToolButton("显示/隐藏书签", "SwitchBKMK()", 0);
			Pdfctrl1.AddCustomToolButton("实际大小", "SetPageReal()", 16);
			Pdfctrl1.AddCustomToolButton("适合页面", "SetPageFit()", 17);
			Pdfctrl1.AddCustomToolButton("适合宽度", "SetPageWidth()", 18);
			Pdfctrl1.AddCustomToolButton("-", "", 0);
			Pdfctrl1.AddCustomToolButton("首页", "FirstPage()", 8);
			Pdfctrl1.AddCustomToolButton("上一页", "PreviousPage()", 9);
			Pdfctrl1.AddCustomToolButton("下一页", "NextPage()", 10);
			Pdfctrl1.AddCustomToolButton("尾页", "LastPage()", 11);
			Pdfctrl1.AddCustomToolButton("-", "", 0);
			Pdfctrl1.Caption = GlobalObject.unescape(Subject);
			Pdfctrl1.WebOpen(filePath);
		}
		catch (Exception)
		{
		}
	}
}

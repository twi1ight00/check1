using System;
using System.IO;
using System.Web;
using System.Web.UI;
using PageOffice;

namespace webapp.pageoffice;

public class Word : Page
{
	protected PageOfficeCtrl PageOfficeCtrl1;

	public string Subject
	{
		get
		{
			if (base.Request.QueryString["Subject"] == null)
			{
				return "无效文件名称";
			}
			return base.Request.QueryString["Subject"];
		}
	}

	public string IsCreate
	{
		get
		{
			if (base.Request.QueryString["isCreate"] == null)
			{
				return "1";
			}
			return base.Request.QueryString["isCreate"];
		}
	}

	public string OpenMode
	{
		get
		{
			if (base.Request.QueryString["OpenMode"] == null)
			{
				return "0";
			}
			return base.Request.QueryString["OpenMode"];
		}
	}

	public string TemplateName
	{
		get
		{
			if (base.Request.QueryString["TemplateName"] == null)
			{
				return "temp.doc";
			}
			return base.Request.QueryString["TemplateName"];
		}
	}

	public string fileID
	{
		get
		{
			if (base.Request.QueryString["fileID"] == null)
			{
				return Guid.NewGuid().ToString();
			}
			return base.Request.QueryString["fileID"];
		}
	}

	public string UserName
	{
		get
		{
			if (base.Request.QueryString["UserName"] == null)
			{
				return "";
			}
			return base.Request.QueryString["UserName"];
		}
	}

	public string FPath
	{
		get
		{
			if (base.Request.QueryString["filepath"] == null)
			{
				return "";
			}
			return base.Request.QueryString["filepath"];
		}
	}

	public string FileType
	{
		get
		{
			if (base.Request.QueryString["fileType"] == null)
			{
				return "";
			}
			return base.Request.QueryString["fileType"];
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		string format = "\\r\\n================================={0}===========================================\\r\\n方法名称：{1}\\r\\n事件：{2}\\r\\n";
		string fileName = fileID + "." + FileType;
		string Path = FPath;
		PageOfficeCtrl1.ServerPage = base.Request.ApplicationPath + "/pageoffice/server.aspx";
		PageOfficeCtrl1.SaveFilePage = "SaveFile.aspx";
		PageOfficeCtrl1.AddCustomToolButton("保存", "Save()", 1);
		PageOfficeCtrl1.AddCustomToolButton("显示痕迹", "ShowRevisions()", 2);
		PageOfficeCtrl1.AddCustomToolButton("隐藏痕迹", "HiddenRevisions()", 3);
		PageOfficeCtrl1.AddCustomToolButton("关闭", "Close", 21);
		PageOfficeCtrl1.SaveFilePage = $"SaveFile.aspx?action=online&Path={Path}&Name={fileID}&fileType={FileType}";
		try
		{
			if (string.IsNullOrEmpty(fileID))
			{
				return;
			}
			fileName = fileID + "." + FileType;
			string filePath = HttpContext.Current.Server.MapPath("/") + Path + fileName;
			string oldFilePath = HttpContext.Current.Server.MapPath("/") + Path + fileID;
			if (File.Exists(oldFilePath))
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				}
				File.Copy(oldFilePath, filePath);
				string openfilePath = "/" + Path + fileName;
				PageOfficeCtrl1.WebOpen(filePath, OpenModeType.docRevisionOnly, UserName);
			}
		}
		catch (Exception exc)
		{
			File.AppendAllText(base.Server.MapPath("\\log\\pageofficelog.txt"), string.Format(format, DateTime.Now.ToString(), " public void WebOpen(string Document, soaWorkMode WorkMode, string UserName, string ProgID);", exc.Message));
		}
	}
}

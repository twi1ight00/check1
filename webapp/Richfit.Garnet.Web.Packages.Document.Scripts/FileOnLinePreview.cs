using System;
using System.Configuration;
using System.Web.UI;

namespace Richfit.Garnet.Web.Packages.Document.Scripts;

public class FileOnLinePreview : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string parameter = "";
		string fileID = base.Request.QueryString["fileID"];
		string token = base.Request.QueryString["token"];
		string filePath = base.Request.QueryString["filePath"];
		string curHost = ConfigurationManager.AppSettings["DocViewIP"];
		string kkFileUrl = ConfigurationManager.AppSettings["kkFilePreview"];
		if (!string.IsNullOrEmpty(filePath))
		{
			parameter = (filePath.ToLower().StartsWith("http") ? ("onlinePreview?url=" + base.Server.UrlEncode(filePath)) : ((!filePath.StartsWith("/")) ? ("onlinePreview?url=" + base.Server.UrlEncode(curHost + "/" + filePath)) : ("onlinePreview?url=" + base.Server.UrlEncode(curHost + filePath))));
		}
		else if (!string.IsNullOrEmpty(fileID) && !string.IsNullOrEmpty(token))
		{
			parameter = "viewFile_implicitURL?url=" + base.Server.UrlEncode(curHost + "/Handlers/Do.ashx?RequestData={\"TokenGuid\":\"" + token + "\",\"ActionCode\":\"System_DownloadAttachment\",\"Data\":\"{\\\"ATTACHMENT_ID\\\":\\\"" + fileID + "\\\"}\"}");
		}
		else
		{
			base.Response.Write("输入的参数非法无效！");
			base.Response.End();
		}
		if (string.IsNullOrEmpty(kkFileUrl))
		{
			base.Response.Write("配置文件没有配置文档在线浏览的处理路径，请联系运维人员！");
			base.Response.End();
		}
		else if (!kkFileUrl.EndsWith("/"))
		{
			kkFileUrl += "/";
		}
		string transferUrl = kkFileUrl + parameter;
		base.Response.Redirect(transferUrl);
	}
}

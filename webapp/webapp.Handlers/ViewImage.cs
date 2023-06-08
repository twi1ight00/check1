using System;
using System.IO;
using System.Web;
using Microsoft.JScript;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

namespace webapp.Handlers;

public class ViewImage : IHttpHandler
{
	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		Stream stream = null;
		string absolutelyPath = GlobalObject.unescape(context.Server.MapPath(context.Request.QueryString["filePath"]));
		string[] fileInfo = absolutelyPath.Split('.');
		string realName = "";
		if (fileInfo.Length > 0)
		{
			for (int i = 0; i < fileInfo.Length - 1; i++)
			{
				realName = realName + fileInfo[i] + ".";
			}
		}
		realName = realName.Substring(0, realName.Length - 1);
		FileInfo fi = new FileInfo(realName);
		if (fi.Exists)
		{
			try
			{
				stream = new FileStream(realName, FileMode.Open, FileAccess.Read, FileShare.Read);
				AttachmentHepler.DownloadStream(stream, fi.Name, fileInfo[fileInfo.Length - 1]);
				return;
			}
			catch (Exception ex)
			{
				throw new CustomCodeException("Fundation.Public.V_0003", ex);
			}
			finally
			{
				stream?.Close();
			}
		}
		throw new ValidationException("Fundation.Public.V_0004");
	}
}

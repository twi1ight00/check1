using System;
using System.IO;
using System.Web;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Web.Handlers;

public class Upload_Image : IHttpHandler
{
	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		string json = SaveFiles();
		context.Response.Write(json);
	}

	public string SaveFiles()
	{
		string uploadFileName = string.Empty;
		Result result = new Result();
		HttpFileCollection files = HttpContext.Current.Request.Files;
		try
		{
			for (int iFile = 0; iFile < files.Count; iFile++)
			{
				HttpPostedFile postedFile = files[iFile];
				string mapPath = "/upload/image/UploadImage/";
				string fileName = Path.GetFileName(postedFile.FileName);
				string directtoryPath = HttpContext.Current.Request.MapPath(mapPath);
				string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
				if (!string.IsNullOrEmpty(fileName))
				{
					if (!Directory.Exists(directtoryPath))
					{
						Directory.CreateDirectory(directtoryPath);
					}
					fileName = newFileName + "." + fileName.Split('.')[1];
					postedFile.SaveAs(directtoryPath + fileName);
				}
				uploadFileName = mapPath + fileName;
			}
			result.success = true;
			result.imagePath = uploadFileName;
			return result.JsonSerialize();
		}
		catch (Exception)
		{
			result.success = false;
			result.imagePath = "";
			return result.JsonSerialize();
		}
	}
}

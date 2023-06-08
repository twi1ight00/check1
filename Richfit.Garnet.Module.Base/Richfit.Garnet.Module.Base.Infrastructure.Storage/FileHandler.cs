using System;
using System.IO;
using System.Web;

namespace Richfit.Garnet.Module.Base.Infrastructure.Storage;

public class FileHandler
{
	/// <summary>
	/// 保存导入的错误（Execl） 
	/// </summary>
	/// <param name="errorStream">错误文件流</param>
	/// <param name="fileName">保存文件名</param>
	/// <returns>返回文件保存路径</returns>
	public static string SaveErrorFile(Stream errorStream, string fileName)
	{
		string absolutelyPath = string.Empty;
		string saveFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
		absolutelyPath = string.Format("{0}{1}", HttpContext.Current.Server.MapPath("~/TempFile/"), saveFileName);
		errorStream.Position = 0L;
		using (FileStream fs = File.Create(absolutelyPath))
		{
			errorStream.CopyTo(fs);
		}
		return "/TempFile/" + saveFileName;
	}
}

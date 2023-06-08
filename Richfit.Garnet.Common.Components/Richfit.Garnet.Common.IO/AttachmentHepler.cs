using System.IO;
using System.Web;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.IO;

/// <summary>
/// 附件处理帮助类
/// </summary>
public class AttachmentHepler
{
	/// <summary>
	/// 下载字节流
	/// </summary>
	/// <param name="stream">字节流</param>
	/// <param name="fileName">导出文件名称</param>
	/// <param name="contentType">导出文件类型</param>
	public static void DownloadStream(Stream stream, string fileName, string contentType)
	{
		stream.GuardNotNull("stream");
		fileName.GuardNotNull("fileName");
		contentType.GuardNotNull("contentType");
		HttpContext context = HttpContext.Current.GuardNotNull("HttpContext.Current");
		context.Response.Clear();
		context.Response.ClearContent();
		context.Response.ClearHeaders();
		context.Response.ContentType = contentType;
		context.Response.AppendHeader("Connection", "Keep-Alive");
		context.Response.AppendHeader("Content-Length", stream.Length.ToString());
		context.Response.AppendHeader("Content-Transfer-Encoding", "binary");
		if (context.Request.Browser.Browser.ToUpper().IndexOf("FIREFOX") >= 0)
		{
			context.Response.AddHeader("Content-Disposition", $"attachment;filename=\"{fileName}\"");
		}
		else
		{
			context.Response.AddHeader("Content-Disposition", $"attachment;filename=\"{HttpUtility.UrlEncode(fileName).Replace('+', ' ')}\"");
		}
		stream.Position = 0L;
		byte[] buff = new byte[1048576];
		int count = 0;
		while ((count = stream.Read(buff, 0, buff.Length)) > 0)
		{
			context.Response.OutputStream.Write(buff, 0, count);
			context.Response.Flush();
		}
		context.Response.Flush();
	}
}

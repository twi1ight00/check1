using System.IO;
using System.Text;
using System.Web;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Web.Extensions;

/// <summary>
/// Http相应对象扩展方法类
/// </summary>
public static class HttpResponseExtensions
{
	/// <summary>
	/// 文件下载（TransmitFile方式）
	/// </summary>
	/// <param name="response"></param>
	/// <param name="virtualPath"></param>
	/// <param name="fileName"></param>
	/// <example>Response.TransmitFile("~/Downloads/MyMusic.mp3","MyMusic.mp3");</example>
	/// <remarks>微软为Response对象提供了一个新的方法TransmitFile来解决使用Response.BinaryWrite下载超过400mb的文件时导致Aspnet_wp.exe进程回收而无法成功下载的问题。</remarks>
	public static void TransmitFile(this HttpResponse response, string virtualPath, string fileName)
	{
		response.Clear();
		response.ClearHeaders();
		response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
		string filename = VirtualPathUtility.ToAbsolute(virtualPath);
		response.TransmitFile(filename);
	}

	/// <summary>
	/// 文件下载（WriteFile方式）
	/// </summary>
	/// <param name="response"></param>
	/// <param name="virtualPath">虚拟路径</param>
	/// <param name="fileName">返回的文件名称</param>
	/// <example>Response.ResponseFile("~/Downloads/MyMusic.mp3","MyMusic.mp3");</example>
	public static void ResponseFile(this HttpResponse response, string virtualPath, string fileName)
	{
		response.Clear();
		response.ClearHeaders();
		response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
		response.WriteFile(virtualPath);
		response.ContentType = string.Empty;
		response.End();
	}

	/// <summary>
	/// 文件下载（WriteFile分块方式）
	/// </summary>
	/// <param name="response"></param>
	/// <param name="stream"></param>
	/// <param name="fileName">返回的文件名称</param>
	public static void ResponseFile(this HttpResponse response, Stream stream, string fileName)
	{
		try
		{
			response.ContentType = "application/octet-stream";
			response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
			stream.CopyTo(response.OutputStream);
			response.Flush();
		}
		catch
		{
			response.Write("Error!");
		}
		finally
		{
			stream?.Close();
		}
	}

	/// <summary>
	/// 文件下载（WriteFile分块方式）
	/// </summary>
	/// <param name="response"></param>
	/// <param name="fileContent">文件内容（二进制数组）</param>
	/// <param name="fileName">返回的文件名称</param>
	public static void ResponseFile(this HttpResponse response, byte[] fileContent, string fileName)
	{
		MemoryStream memoryStream = new MemoryStream(fileContent);
		response.ResponseFile(memoryStream, fileName);
	}

	/// <summary>
	/// Set the cookie in HTTP response.
	/// </summary>
	/// <param name="response">The HTTP response</param>
	/// <param name="name">The cookie name.</param>
	/// <param name="value">The cookie value.</param>
	public static void SetCookie(this HttpResponse response, string name, object value)
	{
		if (!name.IsNullOrWhiteSpace())
		{
			response.SetCookie(new HttpCookie(name, value.ToString()));
		}
	}

	/// <summary>
	/// Set the cookie in HTTP response.
	/// </summary>
	/// <param name="response">The HTTP response</param>
	/// <param name="name">The cookie name.</param>
	/// <param name="value">The cookie value.</param>
	public static void SetCookie(this HttpResponseBase response, string name, object value)
	{
		if (!name.IsNullOrWhiteSpace())
		{
			response.SetCookie(new HttpCookie(name, value.ToString()));
		}
	}

	/// <summary>
	///   Reloads the current page / handler by performing a redirect to the current url
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	public static void Reload(this HttpResponse response)
	{
		response.Redirect(HttpContext.Current.Request.Url.ToString(), endResponse: true);
	}

	/// <summary>
	///   Performs a response redirect and allows the url to be populated with string format parameters.
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	/// <param name="urlFormat">The URL including string.Format placeholders.</param>
	/// <param name="values">The values to the populated.</param>
	public static void Redirect(this HttpResponse response, string urlFormat, params object[] values)
	{
		response.Redirect(urlFormat, endResponse: true, values);
	}

	/// <summary>
	///   Performs a response redirect and allows the url to be populated with string format parameters.
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	/// <param name="urlFormat">The URL including string.Format placeholders.</param>
	/// <param name="endResponse">If set to <c>true</c> the response will be terminated.</param>
	/// <param name="values">The values to the populated.</param>
	public static void Redirect(this HttpResponse response, string urlFormat, bool endResponse, params object[] values)
	{
		string url = string.Format(urlFormat, values);
		response.Redirect(url, endResponse);
	}

	/// <summary>
	///   Returns a 404 to the client and ends the response.
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	public static void SetFileNotFound(this HttpResponse response)
	{
		response.SetFileNotFound(endResponse: true);
	}

	/// <summary>
	///   Returns a 404 to the client and optionally ends the response.
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	/// <param name="endResponse">If set to <c>true</c> the response will be terminated.</param>
	public static void SetFileNotFound(this HttpResponse response, bool endResponse)
	{
		response.SetStatus(404, "Not Found", endResponse);
	}

	/// <summary>
	///   Returns a 500 to the client and ends the response.
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	public static void SetInternalServerError(this HttpResponse response)
	{
		response.SetInternalServerError(endResponse: true);
	}

	/// <summary>
	///   Returns a 500 to the client and optionally ends the response.
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	/// <param name="endResponse">If set to <c>true</c> the response will be terminated.</param>
	public static void SetInternalServerError(this HttpResponse response, bool endResponse)
	{
		response.SetStatus(500, "Internal Server Error", endResponse);
	}

	/// <summary>
	///   Set the specified HTTP status code and description and optionally ends the response.
	/// </summary>
	/// <param name="response">The HttpResponse to perform on.</param>
	/// <param name="code">The status code.</param>
	/// <param name="description">The status description.</param>
	/// <param name="endResponse">If set to <c>true</c> the response will be terminated.</param>
	public static void SetStatus(this HttpResponse response, int code, string description, bool endResponse)
	{
		response.StatusCode = code;
		response.StatusDescription = description;
		if (endResponse)
		{
			response.End();
		}
	}
}

using System;
using System.IO.Compression;
using System.Web;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Web.Extensions;

/// <summary>
/// 定义HttpContext相关的扩展方法
/// </summary>
public static class HttpContextExtensions
{
	/// <summary>
	/// Gzip编码
	/// </summary>
	private const string EncodingGzip = "gzip";

	/// <summary>
	/// Deflate编码
	/// </summary>
	private const string EncodingDeflate = "deflate";

	/// <summary>
	/// 返回请求绝对根的URI
	/// </summary>
	/// <param name="context">Http上下文环境</param>
	/// <returns>绝对根Uri</returns>
	public static Uri AbsoluteRoot(this HttpContext context)
	{
		context.GuardNotNull("Context");
		if (context.Items["absoluteurl"].IsNull())
		{
			context.Items["absoluteurl"] = new Uri(context.Request.Url.GetLeftPart(UriPartial.Authority) + context.RelativeRoot());
		}
		return context.Items["absoluteurl"] as Uri;
	}

	/// <summary>
	/// Adds HTTP compression to the current context
	/// </summary>
	/// <param name="context">Current context</param>
	public static void HttpCompress(this HttpContext context)
	{
		context.GuardNotNull("Context");
		if (context.Request.UserAgent == null || !context.Request.UserAgent.Contains("MSIE 6"))
		{
			if (context.IsEncodingAccepted("gzip"))
			{
				context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
				context.SetEncoding("gzip");
			}
			else if (context.IsEncodingAccepted("deflate"))
			{
				context.Response.Filter = new DeflateStream(context.Response.Filter, CompressionMode.Compress);
				context.SetEncoding("deflate");
			}
		}
	}

	/// <summary>
	/// 判断某编码类型是否是客户端所接受的
	/// </summary>
	/// <param name="context">Http上下文</param>
	/// <param name="encoding">Http流编码</param>
	/// <returns>如果客户端接受该编码返回true，否则返回false</returns>
	public static bool IsEncodingAccepted(this HttpContext context, string encoding)
	{
		if (context == null)
		{
			return false;
		}
		return context.Request.Headers["Accept-encoding"] != null && context.Request.Headers["Accept-encoding"].Contains(encoding);
	}

	/// <summary>
	/// 得到相对路径根的绝对路径
	/// </summary>
	/// <param name="context">Current context</param>
	/// <returns>The relative root of the web site</returns>
	public static string RelativeRoot(this HttpContext context)
	{
		return VirtualPathUtility.ToAbsolute("~/");
	}

	/// <summary>
	/// 在response headers中添加特定的编码
	/// </summary>
	/// <param name="context">Http上下文环境</param>
	/// <param name="encoding">Encoding to set</param>
	public static void SetEncoding(this HttpContext context, string encoding)
	{
		context.GuardNotNull("Context");
		context.Response.AppendHeader("Content-encoding", encoding);
	}
}

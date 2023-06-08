using System.Web;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Web.Extensions;

/// <summary>
/// HttpRequest扩展方法
/// </summary>
public static class HttpRequestExtensions
{
	/// <summary>
	/// Returns the root part of a request.
	/// </summary>
	/// <param name="request">Http请求对象</param>
	/// <returns>返回Http请求Url，包含协议和端口</returns>
	/// <example>http://localhost:3030</example>
	/// <remarks>Prevents port number issues by using the client requested host</remarks>
	public static string ToRootUrlString(this HttpRequestBase request)
	{
		return string.Format("{0}://{1}", request.Url.Scheme, request.Headers["Host"]);
	}

	/// <summary>
	/// Returns the root part of a request.
	/// </summary>
	/// <param name="request">Http请求对象</param>
	/// <returns>返回Http请求Url，包含协议和端口</returns>
	/// <example>http://localhost:3030</example>
	/// <remarks>Prevents port number issues by using the client requested host</remarks>
	public static string ToRootUrlString(this HttpRequest request)
	{
		return string.Format("{0}://{1}", request.Url.Scheme, request.Headers["Host"]);
	}

	/// <summary>
	/// Returns the application root part of a request.
	/// </summary>
	/// <param name="request">Http请求对象</param>
	/// <returns>返回Http请求Url，包含协议、端口和应用程序名称</returns>
	/// <example>http://localhost:3030/OrchardLocal</example>
	/// <remarks>Prevents port number issues by using the client requested host</remarks>
	public static string ToApplicationRootUrlString(this HttpRequestBase request)
	{
		return string.Format("{0}://{1}{2}", request.Url.Scheme, request.Headers["Host"], (request.ApplicationPath == "/") ? string.Empty : request.ApplicationPath);
	}

	/// <summary>
	/// Returns the application root part of a request.
	/// </summary>
	/// <param name="request">Http请求对象</param>
	/// <returns>返回Http请求Url，包含协议、端口和应用程序名称</returns>
	/// <example>http://localhost:3030/OrchardLocal</example>
	/// <remarks>Prevents port number issues by using the client requested host</remarks>
	public static string ToApplicationRootUrlString(this HttpRequest request)
	{
		return string.Format("{0}://{1}{2}", request.Url.Scheme, request.Headers["Host"], (request.ApplicationPath == "/") ? string.Empty : request.ApplicationPath);
	}

	/// <summary>
	/// Returns the client requested url.
	/// </summary>
	/// <param name="request">Http请求对象</param>
	/// <returns>返回客户端请求的完整Url</returns>
	/// <example>http://localhost:3030/OrchardLocal/Admin/Blogs</example>
	/// <remarks>Prevents port number issues by using the client requested host</remarks>
	public static string ToUrlString(this HttpRequestBase request)
	{
		return string.Format("{0}://{1}{2}", request.Url.Scheme, request.Headers["Host"], request.RawUrl);
	}

	/// <summary>
	/// Returns the client requested url.
	/// </summary>
	/// <param name="request">Http请求对象</param>
	/// <returns>返回客户端请求的完整Url</returns>
	/// <example>http://localhost:3030/OrchardLocal/Admin/Blogs</example>
	/// <remarks>Prevents port number issues by using the client requested host</remarks>
	public static string ToUrlString(this HttpRequest request)
	{
		return string.Format("{0}://{1}{2}", request.Url.Scheme, request.Headers["Host"], request.RawUrl);
	}

	/// <summary>
	/// Gets the cookie value from the HTTP request.
	/// </summary>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The name of cookie.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The cookie value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static string GetCookie(this HttpRequest request, string name, string defaultValue = "")
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return defaultValue;
		}
		HttpCookie cookie = request.Cookies[name];
		if (cookie == null)
		{
			return defaultValue;
		}
		return cookie.Value;
	}

	/// <summary>
	/// Gets the cookie value as the type T from the HTTP request.
	/// </summary>
	/// <typeparam name="T">The type to return.</typeparam>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The name of cookie.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The cookie value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static T GetCookie<T>(this HttpRequest request, string name, T defaultValue = default(T))
	{
		return request.GetCookie(name).ConvertTo(defaultValue);
	}

	/// <summary>
	/// Gets the cookie value from the HTTP request.
	/// </summary>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The name of cookie.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The cookie value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static string GetCookie(this HttpRequestBase request, string name, string defaultValue = "")
	{
		if (name.IsNullOrWhiteSpace())
		{
			return defaultValue;
		}
		HttpCookie cookie = request.Cookies[name];
		if (cookie == null)
		{
			return defaultValue;
		}
		return cookie.Value;
	}

	/// <summary>
	/// Gets the cookie value as the type T from the HTTP request.
	/// </summary>
	/// <typeparam name="T">The type to return.</typeparam>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The name of cookie.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The cookie value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static T GetCookie<T>(this HttpRequestBase request, string name, T defaultValue = default(T))
	{
		return request.GetCookie(name).ConvertTo(defaultValue);
	}

	/// <summary>
	/// Gets the user host address from HTTP request.
	/// </summary>
	/// <param name="request">The HTTP request.</param>
	/// <returns>The user host addesss.</returns>
	public static string GetUserHostAddress(this HttpRequest request)
	{
		string httpXFwdFor = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
		if (!httpXFwdFor.IsNullOrWhiteSpace())
		{
			string[] tmp = httpXFwdFor.Split(',');
			if (tmp.Length != 0)
			{
				return tmp[0];
			}
		}
		return request.ServerVariables["REMOTE_ADDR"];
	}

	/// <summary>
	/// Gets the user host address from HTTP request.
	/// </summary>
	/// <param name="request">The HTTP request.</param>
	/// <returns>The user host addesss.</returns>
	public static string GetUserHostAddress(this HttpRequestBase request)
	{
		string httpXFwdFor = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
		if (!httpXFwdFor.IsNullOrWhiteSpace())
		{
			string[] tmp = httpXFwdFor.Split(',');
			if (tmp.Length != 0)
			{
				return tmp[0];
			}
		}
		return request.ServerVariables["REMOTE_ADDR"];
	}

	/// <summary>
	/// Gets the query string parameter from HTTP request. 
	/// </summary>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The parameter name.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The parameter value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static string QueryParam(this HttpRequest request, string name, string defaultValue = "")
	{
		if (name.IsNullOrWhiteSpace())
		{
			return defaultValue;
		}
		string value = request.Params[name];
		if (value.IsNullOrWhiteSpace())
		{
			return defaultValue;
		}
		return value;
	}

	/// <summary>
	/// Gets the query string parameter as the type T from HTTP request. 
	/// </summary>
	/// <typeparam name="T">The type to return.</typeparam>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The parameter name.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The parameter value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static T QueryParam<T>(this HttpRequest request, string name, T defaultValue = default(T))
	{
		return request.QueryParam(name).ConvertTo(defaultValue);
	}

	/// <summary>
	/// Gets the query string parameter from HTTP request. 
	/// </summary>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The parameter name.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The parameter value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static string QueryParam(this HttpRequestBase request, string name, string defaultValue = "")
	{
		if (name.IsNullOrWhiteSpace())
		{
			return defaultValue;
		}
		string value = request.Params[name];
		if (value.IsNullOrWhiteSpace())
		{
			return defaultValue;
		}
		return value;
	}

	/// <summary>
	/// Gets the query string parameter as the type T from HTTP request. 
	/// </summary>
	/// <typeparam name="T">The type to return.</typeparam>
	/// <param name="request">The HTTP request.</param>
	/// <param name="name">The parameter name.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>
	/// The parameter value if it found; otherwise 
	/// the default value.
	/// </returns>
	public static T QueryParam<T>(this HttpRequestBase request, string name, T defaultValue = default(T))
	{
		return request.QueryParam(name).ConvertTo(defaultValue);
	}
}

using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;
using Richfit.Garnet.Common.Cache;
using Richfit.Garnet.Common.Configuration;

namespace webapp.Handlers;

public class JSProvider : IHttpHandler, IRequiresSessionState
{
	private TimeSpan sessionSlidingExpired = TimeSpan.FromMinutes(ConfigurationManager.System.Settings.SessionTimeout);

	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		context.Response.Cache.SetExpires(DateTime.Now.AddYears(-100));
		context.Response.Cache.SetNoStore();
		context.Response.ContentType = "text/javascript";
		string encrypt = context.Request.Params["encrypt"];
		if (string.IsNullOrEmpty(encrypt) || !(encrypt.ToLower() == "symmetric"))
		{
			return;
		}
		using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
		string privateKey = rsa.ToXmlString(includePrivateParameters: true);
		context.Session["user_rsa_private_key"] = privateKey;
		string secretToken = $"SecretToken-{Guid.NewGuid()}";
		SystemCacheBus.Instance.Set(secretToken, privateKey, sessionSlidingExpired);
		RSAParameters parameters = rsa.ExportParameters(includePrivateParameters: false);
		context.Response.Write($"var rsaExponent='{ConvertByteToHex(parameters.Exponent)}',rsaModulus='{ConvertByteToHex(parameters.Modulus)}',secretToken ='{secretToken}';");
	}

	private string ConvertByteToHex(byte[] data)
	{
		if (data == null)
		{
			return string.Empty;
		}
		return BitConverter.ToString(data).Replace("-", "");
	}
}

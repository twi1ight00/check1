using System;
using System.Security.Cryptography;
using System.Text;

namespace LumiSoft.Net.AUTH;

public class AuthHelper
{
	public static string Apop(string password, string passwordTag)
	{
		return Hex(Md5(passwordTag + password));
	}

	public static string Cram_Md5(string password, string hashKey)
	{
		return Hex(HmacMd5(hashKey, password));
	}

	public static string Digest_Md5(bool client_server, string realm, string userName, string password, string nonce, string cnonce, string digest_uri)
	{
		string text = "auth";
		string text2 = "00000001";
		string text3 = Md5(userName + ":" + realm + ":" + password) + ":" + nonce + ":" + cnonce;
		string text4 = "";
		text4 = ((!client_server) ? (":" + digest_uri) : ("AUTHENTICATE:" + digest_uri));
		return Hex(Md5(Hex(Md5(text3)) + ":" + nonce + ":" + text2 + ":" + cnonce + ":" + text + ":" + Hex(Md5(text4))));
	}

	public static string Create_Digest_Md5_ServerResponse(string realm, string nonce)
	{
		return "realm=\"" + realm + "\",nonce=\"" + nonce + "\",qop=\"auth\",algorithm=md5-sess";
	}

	public static string GenerateNonce()
	{
		return Guid.NewGuid().ToString().Replace("-", "")
			.Substring(0, 16);
	}

	public static string HmacMd5(string hashKey, string text)
	{
		HMACMD5 hMACMD = new HMACMD5(Encoding.Default.GetBytes(text));
		return Encoding.Default.GetString(hMACMD.ComputeHash(Encoding.ASCII.GetBytes(hashKey)));
	}

	public static string Md5(string text)
	{
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] bytes = mD.ComputeHash(Encoding.Default.GetBytes(text));
		return Encoding.Default.GetString(bytes);
	}

	public static string Hex(string text)
	{
		return BitConverter.ToString(Encoding.Default.GetBytes(text)).ToLower().Replace("-", "");
	}

	public static string Base64en(string text)
	{
		return Convert.ToBase64String(Encoding.Default.GetBytes(text));
	}

	public static string Base64de(string text)
	{
		return Encoding.Default.GetString(Convert.FromBase64String(text));
	}
}

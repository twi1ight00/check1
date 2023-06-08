using System.Collections.Generic;
using System.Text;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Implements the default plain text ("PLAIN") Memcached authentication.
/// </summary>
/// <remarks>Either use the parametrized constructor, or pass the "userName" and "password" parameters during initalization.</remarks>
public sealed class PlainTextAuthenticator : ISaslAuthenticationProvider
{
	private byte[] authData;

	string ISaslAuthenticationProvider.Type => "PLAIN";

	public PlainTextAuthenticator()
	{
	}

	public PlainTextAuthenticator(string zone, string userName, string password)
	{
		authData = CreateAuthData(zone, userName, password);
	}

	void ISaslAuthenticationProvider.Initialize(Dictionary<string, object> parameters)
	{
		if (parameters != null)
		{
			string zone = (string)parameters["zone"];
			string userName = (string)parameters["userName"];
			string password = (string)parameters["password"];
			authData = CreateAuthData(zone, userName, password);
		}
	}

	byte[] ISaslAuthenticationProvider.Authenticate()
	{
		return authData;
	}

	byte[] ISaslAuthenticationProvider.Continue(byte[] data)
	{
		return null;
	}

	private static byte[] CreateAuthData(string zone, string userName, string password)
	{
		return Encoding.UTF8.GetBytes(zone + "\0" + userName + "\0" + password);
	}
}

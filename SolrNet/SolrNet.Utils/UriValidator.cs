using System;
using SolrNet.Exceptions;

namespace SolrNet.Utils;

public static class UriValidator
{
	/// <summary>
	/// Validates that <paramref name="s" /> if a valid HTTP / HTTPS URI.
	/// Otherwise throws <see cref="T:SolrNet.Exceptions.InvalidURLException" />
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	/// <exception cref="T:SolrNet.Exceptions.InvalidURLException"></exception>
	public static string ValidateHTTP(string s)
	{
		try
		{
			Uri u = new Uri(s);
			if (u.Scheme != Uri.UriSchemeHttp && u.Scheme != Uri.UriSchemeHttps)
			{
				throw new InvalidURLException("Only HTTP or HTTPS protocols are supported");
			}
			return s;
		}
		catch (ArgumentException e2)
		{
			throw new InvalidURLException($"Invalid URL '{s}'", e2);
		}
		catch (UriFormatException e)
		{
			throw new InvalidURLException($"Invalid URL '{s}'", e);
		}
	}
}

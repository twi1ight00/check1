using System;
using System.Text;

namespace Enyim.Caching.Memcached.Results.Helpers;

public static class ResultHelper
{
	public static string ProcessResponseData(ArraySegment<byte> data, string message = "")
	{
		if (data.Count > 0)
		{
			try
			{
				return message + ((!string.IsNullOrEmpty(message)) ? ": " : "") + Encoding.ASCII.GetString(data.Array, data.Offset, data.Count);
			}
			catch (Exception ex)
			{
				return ex.GetBaseException().Message;
			}
		}
		return string.Empty;
	}
}

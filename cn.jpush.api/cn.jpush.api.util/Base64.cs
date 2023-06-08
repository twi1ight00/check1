using System;
using System.Text;

namespace cn.jpush.api.util;

internal class Base64
{
	public static string getBase64Encode(string str)
	{
		return Convert.ToBase64String(Encoding.Default.GetBytes(str));
	}
}

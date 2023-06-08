using System.Security.Cryptography;
using System.Text;

namespace cn.jpush.api.util;

internal class Md5
{
	public static string getMD5Hash(string str)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(str);
		byte[] array = mD.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			stringBuilder.Append(b.ToString("x2"));
		}
		return stringBuilder.ToString();
	}
}

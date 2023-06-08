using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ns103;
using ns106;
using ns119;
using ns99;

namespace ns102;

internal class Class4693 : Interface126
{
	private Class4487 class4487_0;

	private Class4490 class4490_0;

	private static Regex regex_0 = new Regex("\\/FontName[^\\/]*?\\/(?<name>(.)*?)((\\Wdef)|(\\Wreadonly def))", RegexOptions.Compiled);

	public Class4490 imethod_0(Class4487 fontStreamSource)
	{
		try
		{
			class4487_0 = fontStreamSource;
			method_0();
			method_1();
			return class4490_0;
		}
		catch (Exception29)
		{
			throw;
		}
		catch (Exception innerException)
		{
			throw new Exception48("Unexpected font parsing exception", innerException);
		}
	}

	private void method_0()
	{
	}

	private void method_1()
	{
		string text = string.Empty;
		Stream stream = class4487_0.vmethod_0();
		try
		{
			stream.Position = 0L;
			byte[] array = new byte[(int)stream.Length];
			stream.Read(array, 0, (int)stream.Length);
			string @string = Encoding.ASCII.GetString(array);
			MatchCollection matchCollection = regex_0.Matches(@string);
			if (matchCollection.Count > 0)
			{
				text = matchCollection[0].Groups["name"].Value;
			}
			class4490_0 = new Class4490(text, text, Enum639.const_1, new Class4492(class4487_0));
		}
		finally
		{
			if (class4487_0 != null && class4487_0.vmethod_1())
			{
				stream.Close();
			}
		}
	}
}

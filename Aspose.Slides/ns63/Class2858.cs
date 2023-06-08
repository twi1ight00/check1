using System.Text;

namespace ns63;

internal class Class2858 : Class2857
{
	public const int int_1 = 4000;

	public override string Text
	{
		get
		{
			string result = "";
			if (byte_0.Length > 0)
			{
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				char[] chars = unicodeEncoding.GetChars(byte_0);
				if (chars != null)
				{
					result = new string(chars);
				}
			}
			return result;
		}
		set
		{
			if (value != null)
			{
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				byte_0 = unicodeEncoding.GetBytes(value.ToCharArray());
			}
		}
	}

	public Class2858(Class2951 subTextFrame)
		: base(subTextFrame)
	{
		base.Header.Type = 4000;
	}
}

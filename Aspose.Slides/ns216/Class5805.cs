using System;
using System.Text;
using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5805 : Class5804
{
	internal new static string Tag => "dateTimeEdit";

	public Class5805()
	{
		Class5906.smethod_6(this, "picker", XfaEnums.Enum701.const_0);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_46(this);
		base.vmethod_4(visitor);
		visitor.vmethod_47(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5805();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[4]
		{
			Class5790.Tag,
			Class5863.Tag,
			Class5816.Tag,
			Class5829.Tag
		};
	}

	protected override void vmethod_11(Class5893 value)
	{
		base.TextField.Value = value.method_6() ?? string.Empty;
		if (string.IsNullOrEmpty(base.TextField.Value))
		{
			return;
		}
		Class5817 @class = Class5804.smethod_2(base.Parent);
		if (!(@class.method_0("..#ui[0].#picture[0]") is Class5882 class2) || string.IsNullOrEmpty(class2.Value) || !class2.Value.Contains("date"))
		{
			return;
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < class2.Value.Length; i++)
			{
				char c = class2.Value[i];
				switch (c)
				{
				case 'Y':
					stringBuilder.Append('y');
					break;
				case 'D':
					stringBuilder.Append('d');
					break;
				default:
					stringBuilder.Append(c);
					break;
				case 'd':
					if (i + 3 < class2.Value.Length && class2.Value[i + 1] == 'a' && class2.Value[i + 2] == 't' && class2.Value[i + 3] == 'e')
					{
						i += 3;
					}
					break;
				case '{':
				case '}':
					break;
				}
			}
			DateTime dateTime = DateTime.Parse(base.TextField.Value);
			base.TextField.Value = dateTime.ToString(stringBuilder.ToString());
		}
		catch (Exception)
		{
		}
	}
}

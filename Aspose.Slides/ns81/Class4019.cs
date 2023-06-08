using System;
using ns305;

namespace ns81;

internal class Class4019 : Class4011
{
	public override string ConditionText => '[' + LocalName + "~=\"" + base.Value + "\"]";

	public Class4019(string namespaceURI, string localName, string value)
		: base(namespaceURI, localName, value)
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!string.IsNullOrEmpty(base.Value) && base.Value.IndexOf(' ') == -1)
		{
			if (!method_1(e))
			{
				return false;
			}
			string[] array = method_0(e).Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			int num = 0;
			while (true)
			{
				if (num < array2.Length)
				{
					string text = array2[num];
					if (text.Equals(base.Value))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}
}

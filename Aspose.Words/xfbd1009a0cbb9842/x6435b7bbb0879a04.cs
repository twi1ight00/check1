using System.Collections;
using System.Reflection;
using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

[DefaultMember("Item")]
internal class x6435b7bbb0879a04 : ArrayList
{
	public Field xe6d4b1b411ed94b5 => base[xc0c4c459c6ccbd00] as Field;

	internal Field xb5d8f9e48f1d338e(Node xda5bf54deb817e37)
	{
		for (int i = 0; i < Count; i++)
		{
			Field field = this.get_xe6d4b1b411ed94b5(i);
			if (field.x263d579af1d0d43f(xda5bf54deb817e37))
			{
				return field;
			}
		}
		return null;
	}
}

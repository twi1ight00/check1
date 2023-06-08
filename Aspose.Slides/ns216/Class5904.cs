using System.Globalization;
using System.Text;
using ns215;
using ns217;

namespace ns216;

internal class Class5904 : Class5898
{
	protected override Class5898 vmethod_2()
	{
		Class5904 @class = new Class5904();
		@class.vmethod_0(vmethod_1());
		return @class;
	}

	public override void vmethod_0(string value)
	{
		string text = value.Trim(' ');
		if (text.Length > 0)
		{
			string[] array = text.Split(' ');
			base.Value = new float[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				((float[])base.Value)[i] = Class5932.smethod_0(array[i]);
			}
		}
	}

	public override string vmethod_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		float[] array = (float[])base.Value;
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString(CultureInfo.InvariantCulture)).Append(' ');
		}
		return stringBuilder.ToString();
	}
}

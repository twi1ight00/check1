using ns73;

namespace ns87;

internal class Class4161 : Class4154
{
	private Class4162 class4162_0;

	private Class4162 class4162_1;

	private bool bool_0;

	private bool bool_1;

	public Class4162 Width => class4162_0;

	public Class4162 Height => class4162_1;

	public bool IsCover => bool_0;

	public bool IsContain => bool_1;

	internal Class4161(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			if (Class3700.Class3702.class3689_18 == cssValue)
			{
				bool_0 = true;
			}
			else if (Class3700.Class3702.class3689_19 == cssValue)
			{
				bool_1 = true;
			}
		}
		else if (cssValue.CSSValueType == 2)
		{
			Class3691 @class = (Class3691)cssValue;
			if (@class.Length == 1)
			{
				class4162_0 = new Class4162(@class[0]);
				class4162_1 = new Class4162(Class3700.Class3702.class3689_3);
			}
			else
			{
				class4162_0 = new Class4162(@class[0]);
				class4162_1 = new Class4162(@class[1]);
			}
		}
		else
		{
			class4162_1 = (class4162_0 = new Class4162(cssValue));
		}
	}
}

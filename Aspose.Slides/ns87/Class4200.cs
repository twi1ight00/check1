using ns73;

namespace ns87;

internal class Class4200 : Class4154
{
	private Class4167 class4167_0;

	private Class4167 class4167_1;

	public Class4167 OffsetX => class4167_0;

	public Class4167 OffsetY => class4167_1;

	internal Class4200(Class3679 cssValue)
		: base(cssValue)
	{
		Class3691 @class = cssValue as Class3691;
		if (@class.Length == 1)
		{
			class4167_0 = (class4167_1 = new Class4167(@class[0]));
			return;
		}
		class4167_0 = new Class4167(@class[0]);
		class4167_1 = new Class4167(@class[1]);
	}
}

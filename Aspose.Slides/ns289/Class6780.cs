using ns301;

namespace ns289;

internal class Class6780
{
	private Class6781 class6781_0;

	private Class6784 class6784_0;

	public Class6784 Size
	{
		get
		{
			return class6784_0;
		}
		set
		{
			Class6892.smethod_0(value, "value");
			class6784_0 = value;
		}
	}

	public Class6781 Margin => class6781_0;

	internal static Class6780 A4 => new Class6780(new Class6784(new Class6785(210f, Enum920.const_2), new Class6785(297f, Enum920.const_2)));

	public Class6780(Class6784 size)
	{
		Size = size;
		class6781_0 = new Class6781();
	}
}

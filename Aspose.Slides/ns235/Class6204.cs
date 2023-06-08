using ns221;

namespace ns235;

internal abstract class Class6204
{
	private string string_0 = string.Empty;

	private Class6204 class6204_0;

	public string Id
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class6204 Parent
	{
		get
		{
			return class6204_0;
		}
		set
		{
			class6204_0 = value;
		}
	}

	[Attribute7(true)]
	public abstract void vmethod_0(Class6176 visitor);
}

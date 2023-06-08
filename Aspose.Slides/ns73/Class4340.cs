using ns84;

namespace ns73;

internal sealed class Class4340
{
	private string string_0;

	private bool bool_0;

	private Enum586 enum586_0;

	private Class3677 class3677_0;

	public string ContentLanguage
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

	public bool CaseSensitive
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Enum586 Vendor
	{
		get
		{
			return enum586_0;
		}
		set
		{
			enum586_0 = value;
		}
	}

	public Class3677 Device => class3677_0;

	internal static Class4340 Default
	{
		get
		{
			Class4340 @class = new Class4340();
			@class.Vendor = Enum586.const_0;
			@class.class3677_0 = Class3677.Current;
			return @class;
		}
	}

	public Class4340()
	{
		class3677_0 = Class3677.Current;
	}
}

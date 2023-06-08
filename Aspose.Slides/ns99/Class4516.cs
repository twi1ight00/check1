using ns103;
using ns120;

namespace ns99;

internal class Class4516
{
	private static Class4516 class4516_0;

	private Interface128 interface128_0;

	private Interface132 interface132_0;

	public static Class4516 Instance => class4516_0;

	public Interface128 ErrorHandlerFactory
	{
		get
		{
			return interface128_0;
		}
		set
		{
			interface128_0 = value;
		}
	}

	public Interface132 LoggerFactory
	{
		get
		{
			return interface132_0;
		}
		set
		{
			interface132_0 = value;
		}
	}

	static Class4516()
	{
		class4516_0 = new Class4516();
	}

	private Class4516()
	{
		interface128_0 = new Class4558();
		interface132_0 = new Class4515();
	}
}

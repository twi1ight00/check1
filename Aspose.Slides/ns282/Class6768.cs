using ns304;
using ns322;

namespace ns282;

internal class Class6768 : Interface365
{
	private readonly Class7397 class7397_0;

	private readonly Class7397 class7397_1;

	private readonly Class7685 class7685_0;

	public Class6768(Class7685 engine, Class7397 context, Class7397 function)
	{
		class7397_0 = function;
		class7397_1 = context;
		class7685_0 = engine;
	}

	public void imethod_0(Interface363 @event)
	{
		class7685_0.method_0(class7397_0, class7397_1, class7685_0.method_1(@event, typeof(Class7059)));
	}

	protected bool Equals(Class6768 other)
	{
		return object.Equals(class7397_0, other.class7397_0);
	}

	public override int GetHashCode()
	{
		if (class7397_0 == null)
		{
			return 0;
		}
		return class7397_0.GetHashCode();
	}

	public static bool operator ==(Class6768 left, Class6768 right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Class6768 left, Class6768 right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((Class6768)obj);
	}
}

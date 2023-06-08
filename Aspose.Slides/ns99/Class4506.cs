namespace ns99;

internal abstract class Class4506
{
	internal Class4506()
	{
	}

	public abstract override string ToString();

	public abstract override int GetHashCode();

	public static bool operator ==(Class4506 obj1, object obj2)
	{
		if ((object)obj1 != null)
		{
			return obj1.Equals(obj2);
		}
		if (obj2 == null)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(Class4506 obj1, object obj2)
	{
		if ((object)obj1 != null)
		{
			return !obj1.Equals(obj2);
		}
		if (obj2 == null)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		Class4508 @class = this as Class4508;
		if (obj is Class4508 class2 && (object)@class != null)
		{
			return @class.Value == class2.Value;
		}
		Class4507 class3 = this as Class4507;
		Class4507 class4 = obj as Class4507;
		if ((object)class3 != null && (object)class4 != null)
		{
			return class3.Value == class4.Value;
		}
		return false;
	}
}

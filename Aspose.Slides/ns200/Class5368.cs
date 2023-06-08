using ns175;

namespace ns200;

internal abstract class Class5368
{
	public abstract Interface177 vmethod_0(Class5738 userAgent);

	public abstract bool vmethod_1();

	public abstract string[] vmethod_2();

	public virtual Interface202 vmethod_3(Class5738 userAgent)
	{
		return null;
	}

	public bool method_0(string mimeType)
	{
		string[] array = vmethod_2();
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (array[num].Equals(mimeType))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}
}

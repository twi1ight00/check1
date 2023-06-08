using System.Collections;
using System.Text;

namespace ns184;

internal abstract class Class4986 : Interface161
{
	public static char char_0 = '#';

	private long long_0;

	protected Interface218 interface218_0;

	private ArrayList arrayList_0;

	public abstract string vmethod_0();

	public abstract char vmethod_1(char c);

	protected void method_0()
	{
		long_0++;
	}

	public bool method_1()
	{
		return long_0 > 0L;
	}

	public abstract bool vmethod_2(char c);

	public bool method_2()
	{
		return false;
	}

	public abstract string imethod_0();

	public abstract string imethod_1();

	public abstract ArrayList imethod_2();

	public abstract string imethod_3();

	public abstract Class5733 imethod_4();

	public int imethod_5(int size)
	{
		return imethod_6(size);
	}

	public abstract int imethod_6(int size);

	public abstract int imethod_7(int size);

	public abstract int imethod_8(int size);

	public abstract int imethod_9(int size);

	public abstract int imethod_10(int i, int size);

	public abstract int[] imethod_11();

	public abstract bool imethod_12();

	public abstract Hashtable imethod_13();

	public void method_3(Interface218 listener)
	{
		interface218_0 = listener;
	}

	protected void method_4(char c)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		if (arrayList_0.Count < 8 && !arrayList_0.Contains(c))
		{
			arrayList_0.Add(c);
			if (interface218_0 != null)
			{
				interface218_0.imethod_2(this, c, imethod_0());
			}
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('{');
		stringBuilder.Append(imethod_1());
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}
}

using ns56;

namespace ns24;

internal class Class345 : Class278
{
	public delegate void Delegate14();

	public Delegate14 delegate14_0;

	private short short_0;

	private bool bool_0;

	private Class1953 class1953_0;

	private bool bool_1;

	private uint uint_0;

	public short Depth
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public bool SaveAsEmptyElement
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

	public Class1953 EndParaRPr
	{
		get
		{
			return class1953_0;
		}
		set
		{
			class1953_0 = value;
		}
	}

	public bool SoftParagraph
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			method_0();
		}
	}

	internal uint Version => uint_0;

	private void method_0()
	{
		uint_0++;
	}
}

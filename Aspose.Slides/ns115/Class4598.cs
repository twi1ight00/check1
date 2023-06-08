using ns133;
using ns134;
using ns99;

namespace ns115;

internal class Class4598
{
	private Class4600 class4600_0;

	private Class4509 class4509_0;

	private Class4604 class4604_0;

	public Class4600 Position
	{
		get
		{
			return class4600_0;
		}
		set
		{
			class4600_0 = value;
		}
	}

	public Class4509 CTM
	{
		get
		{
			return class4509_0;
		}
		set
		{
			class4509_0 = value;
		}
	}

	internal Class4604 Path
	{
		get
		{
			return class4604_0;
		}
		set
		{
			class4604_0 = value;
		}
	}

	public Class4598()
	{
		CTM = new Class4509();
		class4600_0 = Class4600.class4600_0;
		Path = new Class4604();
	}
}

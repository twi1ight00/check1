using System;
using System.Xml;

namespace ns56;

internal abstract class Class1989 : Class1351
{
	public delegate Class1989 Delegate1822();

	public delegate void Delegate1823(Class1989 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public abstract Class1992 NvGraphicFramePr { get; }

	public abstract Class1976 Xfrm { get; }

	public abstract Class2346 Graphic { get; }

	public virtual Class1885 ExtLst => null;

	public virtual string Macro
	{
		get
		{
			throw new Exception("Access to only overriden property.");
		}
		set
		{
			throw new Exception("Access to only overriden property.");
		}
	}

	public virtual bool FPublished
	{
		get
		{
			throw new Exception("Access to only overriden property.");
		}
		set
		{
			throw new Exception("Access to only overriden property.");
		}
	}

	protected Class1989(XmlReader reader)
		: base(reader)
	{
	}

	protected Class1989()
	{
	}
}

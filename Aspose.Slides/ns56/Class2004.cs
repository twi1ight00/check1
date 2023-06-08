using System;
using System.Xml;

namespace ns56;

internal abstract class Class2004 : Class1351
{
	public delegate Class2004 Delegate1833();

	public delegate void Delegate1834(Class2004 elementData);

	public Class1922.Delegate1633 delegate1633_0;

	public Class1922.Delegate1635 delegate1635_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public abstract Class2007 NvPicPr { get; }

	public abstract Class1810 BlipFill { get; }

	public abstract Class1921 SpPr { get; }

	public abstract Class1922 Style { get; }

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

	protected Class2004(XmlReader reader)
		: base(reader)
	{
	}

	protected Class2004()
	{
	}
}

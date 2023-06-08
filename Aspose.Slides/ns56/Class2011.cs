using System;
using System.Xml;

namespace ns56;

internal abstract class Class2011 : Class1351
{
	public delegate Class2011 Delegate1842();

	public delegate void Delegate1843(Class2011 elementData);

	public Class1922.Delegate1633 delegate1633_0;

	public Class1922.Delegate1635 delegate1635_0;

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class1976.Delegate1795 delegate1795_0;

	public Class1976.Delegate1797 delegate1797_0;

	public abstract Class2015 NvSpPr { get; }

	public abstract Class1921 SpPr { get; }

	public abstract Class1922 Style { get; }

	public abstract Class1946 TxBody { get; }

	public virtual Class1885 ExtLst => null;

	public virtual bool UseBgFill
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

	public virtual string Textlink
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

	public virtual bool FLocksText
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

	public virtual string ModelId
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

	public virtual Class1976 TxXfrm => null;

	protected Class2011(XmlReader reader)
		: base(reader)
	{
	}

	protected Class2011()
	{
	}
}

using System;
using System.Xml;

namespace ns56;

internal abstract class Class1885 : Class1351
{
	public delegate void Delegate1535(Class1885 elementData);

	public delegate Class1885 Delegate1534();

	public Class1449.Delegate383 delegate383_0;

	public abstract Class1449[] ExtList { get; }

	public virtual bool Mod
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

	public Class1885(XmlReader reader)
		: base(reader)
	{
	}

	public Class1885()
	{
	}

	public Class1885 Clone()
	{
		Class1885 @class = (Class1885)GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
		@class.method_2(this);
		return @class;
	}

	private void method_2(Class1885 source)
	{
		Class1449[] extList = source.ExtList;
		foreach (Class1449 @class in extList)
		{
			delegate383_0().OuterXml = @class.OuterXml;
		}
	}

	internal bool Equals(Class1885 unsupportedProps)
	{
		if (unsupportedProps == null)
		{
			return false;
		}
		return ExtList.Equals(unsupportedProps.ExtList);
	}
}

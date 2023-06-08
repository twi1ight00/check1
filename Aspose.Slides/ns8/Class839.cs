using System;
using System.Runtime.CompilerServices;
using ns56;

namespace ns8;

internal class Class839 : IComparable<Class839>
{
	private Class2163 class2163_0;

	public Enum330 Type => class2163_0.Type;

	public string ModelId => class2163_0.ModelId;

	public string DestinationPointId => class2163_0.DestId;

	public uint DestinationPointOrder => class2163_0.DestOrd;

	public string PresentationId => class2163_0.PresId;

	public string SourcePointId => class2163_0.SrcId;

	public uint SourcePointOrder => class2163_0.SrcOrd;

	public string ParentTransitionPointId => class2163_0.ParTransId;

	public string SiblingTransitionPointId => class2163_0.SibTransId;

	public Class839(Class2163 cxnElementData)
	{
		class2163_0 = cxnElementData;
	}

	public Class839(Enum330 type)
	{
		class2163_0 = new Class2163();
		class2163_0.ModelId = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
		class2163_0.Type = type;
		class2163_0.PresId = string.Empty;
		class2163_0.DestId = string.Empty;
		class2163_0.ParTransId = "0";
		class2163_0.SibTransId = "0";
	}

	public void method_0(Class1073 point, Class840 allConnections)
	{
		if (point == null)
		{
			throw new ArgumentNullException("point");
		}
		class2163_0.SrcId = point.ModelId;
		uint num = 0u;
		foreach (Class839 allConnection in allConnections)
		{
			if (allConnection != this && allConnection.SourcePointId == SourcePointId && allConnection.Type == Type)
			{
				num++;
			}
		}
		class2163_0.SrcOrd = num;
	}

	public void method_1(Class1073 point, Class840 allConnections)
	{
		if (point == null)
		{
			throw new ArgumentNullException("point");
		}
		class2163_0.DestId = point.ModelId;
		uint num = 0u;
		foreach (Class839 allConnection in allConnections)
		{
			if (allConnection != this && allConnection.DestinationPointId == DestinationPointId && allConnection.Type == Type)
			{
				num++;
			}
		}
		class2163_0.DestOrd = num;
	}

	public void method_2(Class1073 point)
	{
		if (point == null)
		{
			throw new ArgumentNullException("point");
		}
		class2163_0.ParTransId = point.ModelId;
		point.ConnectionId = class2163_0.ModelId;
	}

	public void method_3(Class1073 point)
	{
		if (point == null)
		{
			throw new ArgumentNullException("point");
		}
		class2163_0.SibTransId = point.ModelId;
		point.ConnectionId = class2163_0.ModelId;
	}

	public void method_4(string layoutId)
	{
		if (layoutId == null)
		{
			throw new ArgumentNullException("layoutId");
		}
		class2163_0.PresId = layoutId;
	}

	public int CompareTo(Class839 other)
	{
		if (SourcePointOrder > other.SourcePointOrder)
		{
			return 1;
		}
		if (SourcePointOrder < other.SourcePointOrder)
		{
			return -1;
		}
		return 0;
	}

	[SpecialName]
	public static Class2163 smethod_0(Class839 connection)
	{
		return connection.class2163_0;
	}
}

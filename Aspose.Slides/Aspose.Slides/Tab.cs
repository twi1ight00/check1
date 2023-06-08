using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("2BDAD4D8-538D-4D32-961F-A2FCB122A7AC")]
public sealed class Tab : IComparable, ITab
{
	private double double_0;

	private TabAlignment tabAlignment_0;

	internal TabCollection tabCollection_0;

	public double Position
	{
		get
		{
			return double_0;
		}
		set
		{
			method_0(value);
		}
	}

	public TabAlignment Alignment
	{
		get
		{
			return tabAlignment_0;
		}
		set
		{
			tabAlignment_0 = value;
			method_2();
		}
	}

	IComparable ITab.AsIComparable => this;

	public Tab(double position, TabAlignment align)
	{
		double_0 = position;
		tabAlignment_0 = align;
	}

	internal void method_0(double value)
	{
		if (double_0 != value)
		{
			TabCollection tabCollection = tabCollection_0;
			tabCollection.method_0(double_0);
			double_0 = value;
			tabCollection.Add(this);
		}
	}

	internal void method_1(TabAlignment value)
	{
		tabAlignment_0 = value;
	}

	private void method_2()
	{
		if (tabCollection_0 != null)
		{
			tabCollection_0.method_1();
		}
	}

	public int CompareTo(object obj)
	{
		return Position.CompareTo(((Tab)obj).Position);
	}
}

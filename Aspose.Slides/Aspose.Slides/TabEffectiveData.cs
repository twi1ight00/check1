using System;

namespace Aspose.Slides;

public sealed class TabEffectiveData : IComparable, ITabEffectiveData, IEffectiveData
{
	private double double_0;

	private TabAlignment tabAlignment_0;

	public double Position => double_0;

	public TabAlignment Alignment => tabAlignment_0;

	IComparable ITabEffectiveData.AsIComparable => this;

	internal TabEffectiveData(ITab tab)
	{
		tabAlignment_0 = tab.Alignment;
		double_0 = tab.Position;
	}

	public int CompareTo(object obj)
	{
		return Position.CompareTo(((Tab)obj).Position);
	}
}

using ns56;

namespace ns8;

internal class Class130 : Class120
{
	public override bool HideLastTransition => true;

	public override bool vmethod_2(Class837 point)
	{
		point.ShapeContainer.Width = point.method_30(Enum305.const_62);
		point.ShapeContainer.Height = point.method_30(Enum305.const_16);
		foreach (Class837 child in point.Children)
		{
			child.ShapeContainer.Width = point.ShapeContainer.Width;
			child.ShapeContainer.Height = point.ShapeContainer.Height;
		}
		return true;
	}
}

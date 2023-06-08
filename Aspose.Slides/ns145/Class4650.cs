using ns139;

namespace ns145;

internal class Class4650 : Class4647
{
	public override double vmethod_0(double xAbsCoordinate, double yAbsCoordinate)
	{
		return xAbsCoordinate;
	}

	public override void vmethod_1(Class4616 pathDefinition, int pointNumber, double distance)
	{
		pathDefinition.double_0[pointNumber] += distance;
		pathDefinition.bool_1[pointNumber] = true;
	}
}

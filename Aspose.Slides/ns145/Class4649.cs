using ns139;

namespace ns145;

internal class Class4649 : Class4647
{
	public override double vmethod_0(double xAbsCoordinate, double yAbsCoordinate)
	{
		return yAbsCoordinate;
	}

	public override void vmethod_1(Class4616 pathDefinition, int pointNumber, double distance)
	{
		pathDefinition.double_1[pointNumber] += distance;
		pathDefinition.bool_0[pointNumber] = true;
	}
}

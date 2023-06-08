using System;
using ns139;
using ns144;

namespace ns145;

internal class Class4648 : Class4647
{
	private Class4644 class4644_0;

	private double double_0;

	public Class4648(Class4644 vector)
	{
		class4644_0 = vector;
		double_0 = Math.Sqrt(class4644_0.X * class4644_0.X + class4644_0.Y * class4644_0.Y);
	}

	public override double vmethod_0(double xAbsCoordinate, double yAbsCoordinate)
	{
		return (xAbsCoordinate * class4644_0.X + yAbsCoordinate * class4644_0.Y) / double_0;
	}

	public override void vmethod_1(Class4616 pathDefinition, int pointNumber, double distance)
	{
		double num = class4644_0.X * distance;
		double num2 = class4644_0.Y * distance;
		pathDefinition.double_0[pointNumber] += num;
		pathDefinition.double_1[pointNumber] += num2;
		pathDefinition.bool_1[pointNumber] = true;
		pathDefinition.bool_0[pointNumber] = true;
	}
}

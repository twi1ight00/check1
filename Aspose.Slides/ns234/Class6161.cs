using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns218;
using ns224;

namespace ns234;

internal static class Class6161
{
	public static Matrix smethod_0(Class6002 drMatrix)
	{
		return new Matrix(drMatrix.M11, drMatrix.M12, drMatrix.M21, drMatrix.M22, drMatrix.M31, drMatrix.M32);
	}

	public static Class6002 smethod_1(Matrix matrix)
	{
		float[] elements = matrix.Elements;
		return new Class6002(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
	}

	public static string smethod_2(Class6002 drMatrix)
	{
		return $"{Class5964.smethod_39(BitConverter.GetBytes(drMatrix.M11), 0, 4, reversed: true)}, {Class5964.smethod_39(BitConverter.GetBytes(drMatrix.M12), 0, 4, reversed: true)}, {Class5964.smethod_39(BitConverter.GetBytes(drMatrix.M21), 0, 4, reversed: true)}, {Class5964.smethod_39(BitConverter.GetBytes(drMatrix.M22), 0, 4, reversed: true)}, {Class5964.smethod_39(BitConverter.GetBytes(drMatrix.M31), 0, 4, reversed: true)}, {Class5964.smethod_39(BitConverter.GetBytes(drMatrix.M32), 0, 4, reversed: true)}";
	}

	public static string smethod_3(PointF point)
	{
		return $"{Class5964.smethod_39(BitConverter.GetBytes(point.X), 0, 4, reversed: true)}, {Class5964.smethod_39(BitConverter.GetBytes(point.Y), 0, 4, reversed: true)}";
	}

	public static string smethod_4(float value)
	{
		return Class5964.smethod_39(BitConverter.GetBytes(value), 0, 4, reversed: true);
	}

	public static string smethod_5(double value)
	{
		return Class5964.smethod_39(BitConverter.GetBytes(value), 0, 8, reversed: true);
	}
}

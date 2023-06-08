using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x9d12391da48d09f4
{
	private readonly ShapeBase x48154453a08515ea;

	private PointF[][] x390b4411c7482c91;

	internal x9d12391da48d09f4(ShapeBase node)
	{
		if (node == null)
		{
			throw new ArgumentNullException("node");
		}
		x48154453a08515ea = node;
	}

	internal static Point[][] xf8669b2717de66be(ShapeBase xda5bf54deb817e37)
	{
		x9d12391da48d09f4 x9d12391da48d09f5 = new x9d12391da48d09f4(xda5bf54deb817e37);
		x9d12391da48d09f5.x18dfca7c5fd2402f();
		Point[][] array = new Point[x9d12391da48d09f5.x390b4411c7482c91.Length][];
		for (int i = 0; i < x9d12391da48d09f5.x390b4411c7482c91.Length; i++)
		{
			int num = x9d12391da48d09f5.x390b4411c7482c91[i].Length;
			array[i] = new Point[num];
			for (int j = 0; j < num; j++)
			{
				ref Point reference = ref array[i][j];
				reference = x4574ea26106f0edb.x8d50b8a62ba1cd84(x9d12391da48d09f5.x390b4411c7482c91[i][j]);
			}
		}
		return array;
	}

	private void x18dfca7c5fd2402f()
	{
		Shape[] array;
		if (x48154453a08515ea.NodeType == NodeType.GroupShape)
		{
			array = new Shape[0];
			throw new NotImplementedException();
		}
		array = new Shape[1] { (Shape)x48154453a08515ea };
		x390b4411c7482c91 = new PointF[array.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			x390b4411c7482c91[i] = x594341bf1b265d31(array[i]);
		}
	}

	private PointF[] x594341bf1b265d31(Shape x5770cdefd8931aa9)
	{
		throw new NotImplementedException();
	}
}

using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal class x0aef601223d08f3b : x77fb5b1d5c73757b
{
	private static readonly char[] x7cbc59724f30bf73 = new char[3] { ' ', '.', ';' };

	internal x0aef601223d08f3b(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		string[] array = x153c99a852375422.x9f1a6a3451a38d10().Split(x7cbc59724f30bf73);
		if (array.Length == 6 && array[0] == "Microsoft" && array[1] == "Word")
		{
			int num = xca004f56614e2431.xa93402510be8434e(array[2]);
			int num2 = xca004f56614e2431.xa93402510be8434e(array[4]);
			base.x2c8c6741422a1298.BuiltInDocumentProperties.Version = (num << 16) | num2;
		}
	}
}

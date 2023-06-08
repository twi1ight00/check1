using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words;
using Aspose.Words.Drawing;
using x5794c252ba25e723;

namespace x3d94286fe72124a8;

internal class xd276f68a96277a27 : x795369ba3068bc66
{
	public SizeF[] xbe0f01716f917f22(Shape[] x5dba01b2084e8c53)
	{
		SizeF[] array = new SizeF[x5dba01b2084e8c53.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ref SizeF reference = ref array[i];
			reference = xdfaeeb042d114dff(x5dba01b2084e8c53[i]);
		}
		return array;
	}

	private SizeF xdfaeeb042d114dff(Shape x5770cdefd8931aa9)
	{
		x09c1a14290933027 x09c1a142909330272 = xb67c9673f4df2489(x5770cdefd8931aa9);
		xa37343ccb8cd8c70 x0f7b23d1c393aed = new xa37343ccb8cd8c70(new x7721ad963b03c6eb(x5770cdefd8931aa9), x09c1a142909330272.x1811cdb4b95dff7a, x09c1a142909330272.x33a4e223bc9c2d43, x09c1a142909330272.xdf8025e24643dbe1, x09c1a142909330272.xa00ce09851f40ee5, null);
		float xc8822d77ef1841c = x91be6b8f43d9bf39.xd08732447aa791e7(x5770cdefd8931aa9);
		return x91be6b8f43d9bf39.x03d870a6ff1ac3d3(x0f7b23d1c393aed, xc8822d77ef1841c).Size;
	}

	private x09c1a14290933027 xb67c9673f4df2489(Node x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.NodeType == NodeType.Shape)
		{
			return xb67c9673f4df2489(x5770cdefd8931aa9.ParentNode);
		}
		GroupShape groupShape = ((x5770cdefd8931aa9.NodeType == NodeType.GroupShape) ? ((GroupShape)x5770cdefd8931aa9) : null);
		if (groupShape == null)
		{
			return x09c1a14290933027.x45260ad4b94166f2;
		}
		CompositeNode parentNode = groupShape.ParentNode;
		x09c1a14290933027 x09c1a142909330272 = x09c1a14290933027.x45260ad4b94166f2;
		if (parentNode != null && parentNode.NodeType == NodeType.GroupShape)
		{
			x09c1a142909330272 = xb67c9673f4df2489(parentNode);
		}
		SizeF x437e3b626c0fdd = groupShape.x437e3b626c0fdd43;
		x54366fa5f75a02f7 x54366fa5f75a02f = xa99f8d94adfe1070.xd1f77e3bec02ca04(groupShape, x437e3b626c0fdd, x24045939618dc027: false);
		x54366fa5f75a02f.x490e30087768649f(x09c1a142909330272.x1811cdb4b95dff7a, MatrixOrder.Append);
		x54366fa5f75a02f7 x54366fa5f75a02f2 = xa99f8d94adfe1070.xd1f77e3bec02ca04(groupShape, x437e3b626c0fdd, x24045939618dc027: true);
		x54366fa5f75a02f2.x490e30087768649f(x09c1a142909330272.x1811cdb4b95dff7a, MatrixOrder.Append);
		SizeF sizeF = xa99f8d94adfe1070.xa85a34732ecd05c1(groupShape, x09c1a142909330272.x33a4e223bc9c2d43, x09c1a142909330272.xdf8025e24643dbe1);
		float width = sizeF.Width;
		float height = sizeF.Height;
		float scaleX = x437e3b626c0fdd.Width / (float)groupShape.x133d653c1b9b01f2 * width;
		float scaleY = x437e3b626c0fdd.Height / (float)groupShape.xc97e136f0019c237 * height;
		float rotation = (float)(groupShape.Rotation + (double)x09c1a142909330272.xa00ce09851f40ee5);
		return new x09c1a14290933027(x54366fa5f75a02f, scaleX, scaleY, rotation);
	}
}

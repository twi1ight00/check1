using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x06e283fdfa5dc5f0;
using x120d4bb5c80fb10c;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;
using x7a30b7d81100c71a;
using xf84f8427dc22d095;

namespace x3d94286fe72124a8;

internal class xc958d22004253850
{
	private xa37343ccb8cd8c70 x8cedcaa9a62c6e39;

	private readonly x91be6b8f43d9bf39 x1e6e05463d75dd68;

	private readonly x54b98d0096d7251a xa056586c1f99e199;

	private readonly Hashtable xfdb531283daf21e3;

	private x7721ad963b03c6eb x3f22d01e3191338d;

	private readonly bool x6f4fa2b2ec5cc5c0;

	internal xc958d22004253850(xfc96716110004aef textBuilder, x54b98d0096d7251a warningCallback, Hashtable shapesCache, bool isWordArtSimplified)
	{
		xa056586c1f99e199 = warningCallback;
		xfdb531283daf21e3 = shapesCache;
		x1e6e05463d75dd68 = new x91be6b8f43d9bf39(textBuilder);
		x6f4fa2b2ec5cc5c0 = isWordArtSimplified;
	}

	internal static xb8e7e788f6d59708 xe0bb10192c142499(x7721ad963b03c6eb x8d3f74e5f925679c, x54b98d0096d7251a x57fef5933b41d0c2)
	{
		ShapeBase xa9993ed2e0c = x8d3f74e5f925679c.xa9993ed2e0c64574;
		Document document = xa9993ed2e0c.x357c90b33d6bb8e6();
		xcde671c53995c411 xcde671c53995c = document.x410db0f4a89a6ef1(xa9993ed2e0c.x133a5347d32dce7a());
		if (xcde671c53995c != null)
		{
			ShapeBase shapeBase = xa9993ed2e0c;
			while (!shapeBase.IsTopLevel)
			{
				shapeBase = (ShapeBase)shapeBase.ParentNode;
			}
			bool x739586df98f871fe = document.xdeb77ea37ad74c56.x739586df98f871fe;
			document.xdeb77ea37ad74c56.x739586df98f871fe = true;
			xcde671c53995c.x64cf48da0043a586(shapeBase);
			document.xdeb77ea37ad74c56.x739586df98f871fe = x739586df98f871fe;
		}
		xc958d22004253850 xc958d220042538502 = new xc958d22004253850(null, x57fef5933b41d0c2, document.x0b16d2d2ced2de05, document.xdeb77ea37ad74c56.x4e89abab59063fe9);
		return xc958d220042538502.xe406325e56f74b46(x8d3f74e5f925679c);
	}

	[JavaConvertCheckedExceptions]
	internal xb8e7e788f6d59708 xe406325e56f74b46(x7721ad963b03c6eb x35ab30dc6767f3db)
	{
		return xe406325e56f74b46(x35ab30dc6767f3db, x0c7065950934043a: true);
	}

	[JavaConvertCheckedExceptions]
	internal xb8e7e788f6d59708 xe406325e56f74b46(x7721ad963b03c6eb x35ab30dc6767f3db, bool x0c7065950934043a)
	{
		ShapeBase shapeBase = x35ab30dc6767f3db.xa9993ed2e0c64574;
		x3f22d01e3191338d = x35ab30dc6767f3db;
		if (shapeBase.x96e55b5d052d1279)
		{
			return new xb8e7e788f6d59708();
		}
		xb8e7e788f6d59708 xb8e7e788f6d = xa05e1c47bb4e4c24(x35ab30dc6767f3db);
		if (xb8e7e788f6d != null)
		{
			return xb8e7e788f6d;
		}
		while (!shapeBase.IsTopLevel)
		{
			shapeBase = (ShapeBase)shapeBase.ParentNode;
		}
		xe406325e56f74b46((shapeBase != x35ab30dc6767f3db.xa9993ed2e0c64574) ? new x7721ad963b03c6eb(shapeBase) : x35ab30dc6767f3db, new x54366fa5f75a02f7(), 1f, 1f, 0f);
		xb8e7e788f6d59708 result = xa05e1c47bb4e4c24(x35ab30dc6767f3db);
		if (!x0c7065950934043a)
		{
			xfdb531283daf21e3[shapeBase] = null;
		}
		return result;
	}

	private void x48941dadb2260a5c(ShapeBase x5770cdefd8931aa9, xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xfdb531283daf21e3[x5770cdefd8931aa9] = new xc98afd2dce9d32d2(x08ce8f4769eb3234);
	}

	private xb8e7e788f6d59708 xa05e1c47bb4e4c24(x7721ad963b03c6eb x8d3f74e5f925679c)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = null;
		xc98afd2dce9d32d2 xc98afd2dce9d32d3 = (xc98afd2dce9d32d2)xfdb531283daf21e3[x8d3f74e5f925679c.xa9993ed2e0c64574];
		if (xc98afd2dce9d32d3 != null)
		{
			x8d3f74e5f925679c.xfe502558fa04ffb1 = xc98afd2dce9d32d3.x0858b12a935f219f(x8d3f74e5f925679c);
			xb8e7e788f6d = xc98afd2dce9d32d3.xa1eafe7821eb4aab.xfe8f67360e300e88();
			if (x8d3f74e5f925679c.x2edb8efcf734419a != null && x8d3f74e5f925679c.xa9993ed2e0c64574.Document.xe4ccd3ec7bc99ea4)
			{
				xb8e7e788f6d.xd6b6ed77479ef68c(x8d3f74e5f925679c.x2edb8efcf734419a.x83dd92921f575263);
			}
		}
		return xb8e7e788f6d;
	}

	private xb8e7e788f6d59708 xe406325e56f74b46(x7721ad963b03c6eb x8d3f74e5f925679c, x54366fa5f75a02f7 x9053b06061901181, float x50d264e6da53d913, float x2d2c4e2c948cba27, float xda04be0f5516c453)
	{
		if (x8d3f74e5f925679c.xa9993ed2e0c64574 == x3f22d01e3191338d.xa9993ed2e0c64574)
		{
			x8d3f74e5f925679c = x3f22d01e3191338d;
		}
		xb8e7e788f6d59708 xb8e7e788f6d = ((x8d3f74e5f925679c.xa9993ed2e0c64574.ShapeType == ShapeType.Group) ? xa29d2d9606943b3d(x8d3f74e5f925679c, x9053b06061901181, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453) : xf51bb9981f8d7796(x8d3f74e5f925679c, x9053b06061901181, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453));
		x48941dadb2260a5c(x8d3f74e5f925679c.xa9993ed2e0c64574, xb8e7e788f6d);
		return xb8e7e788f6d;
	}

	private xb8e7e788f6d59708 xa29d2d9606943b3d(x7721ad963b03c6eb x8d3f74e5f925679c, x54366fa5f75a02f7 x9053b06061901181, float x50d264e6da53d913, float x2d2c4e2c948cba27, float xda04be0f5516c453)
	{
		GroupShape groupShape = (GroupShape)x8d3f74e5f925679c.xa9993ed2e0c64574;
		SizeF x0ceec69a97f = (x8d3f74e5f925679c.x178374f0600f2696.IsEmpty ? groupShape.x437e3b626c0fdd43 : x8d3f74e5f925679c.x178374f0600f2696);
		x54366fa5f75a02f7 x54366fa5f75a02f = xa99f8d94adfe1070.xd1f77e3bec02ca04(groupShape, x0ceec69a97f, x24045939618dc027: false);
		x54366fa5f75a02f.x490e30087768649f(x9053b06061901181, MatrixOrder.Append);
		x54366fa5f75a02f7 x54366fa5f75a02f2 = xa99f8d94adfe1070.xd1f77e3bec02ca04(groupShape, x0ceec69a97f, x24045939618dc027: true);
		x54366fa5f75a02f2.x490e30087768649f(x9053b06061901181, MatrixOrder.Append);
		SizeF sizeF = xa99f8d94adfe1070.xa85a34732ecd05c1(groupShape, x50d264e6da53d913, x2d2c4e2c948cba27);
		x50d264e6da53d913 = sizeF.Width;
		x2d2c4e2c948cba27 = sizeF.Height;
		float x50d264e6da53d914 = x0ceec69a97f.Width / (float)groupShape.x133d653c1b9b01f2 * x50d264e6da53d913;
		float x2d2c4e2c948cba28 = x0ceec69a97f.Height / (float)groupShape.xc97e136f0019c237 * x2d2c4e2c948cba27;
		float xda04be0f5516c454 = (float)(groupShape.Rotation + (double)xda04be0f5516c453);
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		foreach (ShapeBase childNode in groupShape.ChildNodes)
		{
			if (groupShape.FlipOrientation != 0 && childNode.FlipOrientation == FlipOrientation.None)
			{
				childNode.FlipOrientation = groupShape.FlipOrientation;
			}
			xb8e7e788f6d59708 xda5bf54deb817e = xe406325e56f74b46(new x7721ad963b03c6eb(childNode), x54366fa5f75a02f, x50d264e6da53d914, x2d2c4e2c948cba28, xda04be0f5516c454);
			xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
		}
		return xb8e7e788f6d;
	}

	private xb8e7e788f6d59708 xf51bb9981f8d7796(x7721ad963b03c6eb x8d3f74e5f925679c, x54366fa5f75a02f7 x9053b06061901181, float x50d264e6da53d913, float x2d2c4e2c948cba27, float xda04be0f5516c453)
	{
		Shape shape = (Shape)x8d3f74e5f925679c.xa9993ed2e0c64574;
		x0603a93d29ca0b11(shape);
		xa1f42c6fd02ee601(x8d3f74e5f925679c, shape, x9053b06061901181, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453);
		if (x7ad8b429df4d1783.xbcb10825d2277113(shape))
		{
			if (shape.Stroked)
			{
				x431f7c0b6ad6b096();
			}
			else
			{
				x66d0167b6af07b8e(x8d3f74e5f925679c);
			}
			xae8a4529b38e6e18(shape);
		}
		else
		{
			if (x8cedcaa9a62c6e39.xdb6e255971c32d6d == null)
			{
				return new xb8e7e788f6d59708();
			}
			int x251e26ec1b1ddfdc = 0;
			for (int i = 0; i < x8cedcaa9a62c6e39.xdb6e255971c32d6d.Length; i++)
			{
				x44f2b8bf33b16275 x37169c88a38f2f9b = x8cedcaa9a62c6e39.xdb6e255971c32d6d[i];
				x3e07bba7d124ae86(x37169c88a38f2f9b, ref x251e26ec1b1ddfdc);
			}
		}
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7(1f, 0f, 0f, 1f, x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xe5aa6d515a201cc4.X, x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xe5aa6d515a201cc4.Y);
		if (x8cedcaa9a62c6e39.xa9993ed2e0c64574.TextPath.On)
		{
			xb8e7e788f6d = xd26a6cc3ef527529(xb8e7e788f6d);
		}
		if (shape.xc764a1afacb94b7e)
		{
			x4f609e90c933e95e(shape);
		}
		xf47dd3a54c81f26d(x8d3f74e5f925679c, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453, xb8e7e788f6d);
		return xb8e7e788f6d;
	}

	private void xa1f42c6fd02ee601(x7721ad963b03c6eb x8d3f74e5f925679c, Shape x5770cdefd8931aa9, x54366fa5f75a02f7 x9053b06061901181, float x50d264e6da53d913, float x2d2c4e2c948cba27, float xda04be0f5516c453)
	{
		if (x5770cdefd8931aa9.x6c285a52cba39f1f.x173949c9cf8653ad)
		{
			x8d3f74e5f925679c.x178374f0600f2696 = ((x5770cdefd8931aa9.x6c285a52cba39f1f.x9472539ef71e166c > 0.0) ? new SizeF((float)(x5770cdefd8931aa9.x6c285a52cba39f1f.x9472539ef71e166c * 0.009999999776482582) * x8d3f74e5f925679c.x8b3e254648679663, (float)x5770cdefd8931aa9.Height) : new SizeF((float)x5770cdefd8931aa9.Width, (float)x5770cdefd8931aa9.Height));
		}
		x8cedcaa9a62c6e39 = new xa37343ccb8cd8c70(x8d3f74e5f925679c, x9053b06061901181, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453, xa056586c1f99e199);
		if (x5770cdefd8931aa9.x3ffbaff53e6d8618 && !x1e6e05463d75dd68.x77b539f715547c1c)
		{
			x8d3f74e5f925679c.x178374f0600f2696 = x1e6e05463d75dd68.xdfaeeb042d114dff(x8cedcaa9a62c6e39);
			x8cedcaa9a62c6e39 = new xa37343ccb8cd8c70(x8d3f74e5f925679c, x9053b06061901181, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453, xa056586c1f99e199);
		}
	}

	private xb8e7e788f6d59708 xd26a6cc3ef527529(xb8e7e788f6d59708 x92ba3975b1e8ea20)
	{
		xb8e7e788f6d59708 xa1eafe7821eb4aab = null;
		if (x6f4fa2b2ec5cc5c0)
		{
			x92ba3975b1e8ea20 = x1b6f86a5902a66ab.xe406325e56f74b46(x8cedcaa9a62c6e39);
		}
		else
		{
			xa1eafe7821eb4aab = x23d03eff0543aa97.xe406325e56f74b46(x8cedcaa9a62c6e39);
		}
		x8cedcaa9a62c6e39.xa1eafe7821eb4aab = xa1eafe7821eb4aab;
		return x92ba3975b1e8ea20;
	}

	private void x4f609e90c933e95e(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.xc6152e5b7b3767b6 == xb156f8ae92094cbb.x1d03f9dbb48b31c4)
		{
			x936595b14a7c5251 x936595b14a7c = new x936595b14a7c5251(x8cedcaa9a62c6e39);
			x8cedcaa9a62c6e39.xa1eafe7821eb4aab = x936595b14a7c.xeb004ce5b82b6491(x8cedcaa9a62c6e39.xa1eafe7821eb4aab, x5770cdefd8931aa9.x1f468b359604fb97);
		}
	}

	private void x0603a93d29ca0b11(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.x4172593a937c6db2)
		{
			xa056586c1f99e199.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x3959df40367ac8a3.xe42bd130f1e95570, "Shape shadow effects are not supported");
		}
		if (x5770cdefd8931aa9.xc764a1afacb94b7e && x5770cdefd8931aa9.xc6152e5b7b3767b6 != xb156f8ae92094cbb.x1d03f9dbb48b31c4)
		{
			xa056586c1f99e199.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x3959df40367ac8a3.xe42bd130f1e95570, "Shape 3D effects are not supported in full");
		}
	}

	private void xf47dd3a54c81f26d(x7721ad963b03c6eb x8d3f74e5f925679c, float x50d264e6da53d913, float x2d2c4e2c948cba27, float xda04be0f5516c453, xb8e7e788f6d59708 x92ba3975b1e8ea20)
	{
		Shape shape = (Shape)x8d3f74e5f925679c.xa9993ed2e0c64574;
		if (x8cedcaa9a62c6e39.xa1eafe7821eb4aab != null)
		{
			x6607281c5523036c x1c1af4362d2b = new x6607281c5523036c();
			int xd44988f225497f3a = x8cedcaa9a62c6e39.xa1eafe7821eb4aab.xd44988f225497f3a;
			if (shape.x6c285a52cba39f1f.x173949c9cf8653ad)
			{
				xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
				x92ba3975b1e8ea20.xd6b6ed77479ef68c(xb8e7e788f6d);
				x92ba3975b1e8ea20 = xb8e7e788f6d;
				x91302f6870c85c5b(shape.x6c285a52cba39f1f.xceaa36575b797b5b, x8d3f74e5f925679c.x178374f0600f2696.Width, x8d3f74e5f925679c.x8b3e254648679663, xb8e7e788f6d);
			}
			x2edb8efcf734419a x2edb8efcf734419a = x8d3f74e5f925679c.x2edb8efcf734419a;
			x8469d73146678485(x92ba3975b1e8ea20, xd44988f225497f3a, x1c1af4362d2b, x2edb8efcf734419a);
			x0c2451b90bca33ec(x92ba3975b1e8ea20, shape, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453, x2edb8efcf734419a);
			x86593b7e2f85f761(x92ba3975b1e8ea20, xd44988f225497f3a, x1c1af4362d2b, x2edb8efcf734419a);
		}
		x1e6e05463d75dd68.xe406325e56f74b46(x8cedcaa9a62c6e39, x92ba3975b1e8ea20);
		if (shape.ParentNode != null && shape.ParentNode.NodeType == NodeType.GroupShape && x0d299f323d241756.x5959bccb67bbf051(shape.HRef))
		{
			x92ba3975b1e8ea20.xc9bcfb2d9630b0c7 = new xa702b771604efc86(shape.BoundsInPoints, shape.HRef);
		}
	}

	private static void x91302f6870c85c5b(x206d87dc07f8c9e2 x7717e14a55110734, float xce90ee8e49859281, float x3b4cc51c4f6eb865, xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		if (x08ce8f4769eb3234.x52dde376accdec7d == null)
		{
			x08ce8f4769eb3234.x52dde376accdec7d = new x54366fa5f75a02f7();
		}
		switch (x7717e14a55110734)
		{
		case x206d87dc07f8c9e2.x58d2ccae3c5cfd08:
			x08ce8f4769eb3234.x52dde376accdec7d.xce92de628aa023cf((x3b4cc51c4f6eb865 - xce90ee8e49859281) * 0.5f, 0f, MatrixOrder.Append);
			break;
		case x206d87dc07f8c9e2.x419ba17a5322627b:
			x08ce8f4769eb3234.x52dde376accdec7d.xce92de628aa023cf(x3b4cc51c4f6eb865 - xce90ee8e49859281, 0f, MatrixOrder.Append);
			break;
		}
	}

	private void x8469d73146678485(xb8e7e788f6d59708 x92ba3975b1e8ea20, int xee1fb1c009e6deae, x6607281c5523036c x1c1af4362d2b5504, x2edb8efcf734419a x1acbe2e91f909139)
	{
		for (int i = 0; i < xee1fb1c009e6deae; i++)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = (xab391c46ff9a0a38)((xbaec545ec01f92ca)x8cedcaa9a62c6e39.xa1eafe7821eb4aab).get_xe6d4b1b411ed94b5(i);
			if (xab391c46ff9a0a.x60465f602599d327 != null)
			{
				xab391c46ff9a0a38 xab391c46ff9a0a2 = x1c1af4362d2b5504.xe94da055c1b9a188(xab391c46ff9a0a, x2b818897b65c872e: false, xdb73611e5c07ce94: true);
				x92ba3975b1e8ea20.xd6b6ed77479ef68c(xab391c46ff9a0a2);
				x1acbe2e91f909139?.x485706149e408fe2(xab391c46ff9a0a2);
			}
		}
	}

	private void x0c2451b90bca33ec(xb8e7e788f6d59708 x92ba3975b1e8ea20, Shape x5770cdefd8931aa9, float x50d264e6da53d913, float x2d2c4e2c948cba27, float xda04be0f5516c453, x2edb8efcf734419a x1acbe2e91f909139)
	{
		if (x5770cdefd8931aa9.HasImage)
		{
			xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
			xb8e7e788f6d.x52dde376accdec7d = xa99f8d94adfe1070.x936ca47202325634(x5770cdefd8931aa9, x50d264e6da53d913, x2d2c4e2c948cba27, xda04be0f5516c453);
			ImageData imageData = x5770cdefd8931aa9.ImageData;
			byte[] array = (x54e1487157ae6d98(x5770cdefd8931aa9) ? xa348115f6b938752(x5770cdefd8931aa9) : x7ad8b429df4d1783.x91d8d16c995a775e(imageData));
			x72c34b8dbaec3734 x72c34b8dbaec = new x72c34b8dbaec3734(PointF.Empty, x8cedcaa9a62c6e39.x1f2f266ad77d3736, array, imageData.x33295b3b60c18456(), x7d78a235fde47f2c(imageData));
			x34a2c81a32d57957(x5770cdefd8931aa9, x72c34b8dbaec);
			xb8e7e788f6d.xd6b6ed77479ef68c(x72c34b8dbaec);
			x92ba3975b1e8ea20.xd6b6ed77479ef68c(xb8e7e788f6d);
			x1acbe2e91f909139?.xa9557f69810d0afe(array, x72c34b8dbaec.x6ae4612a8469678e);
		}
	}

	private static bool x54e1487157ae6d98(Shape x5770cdefd8931aa9)
	{
		return x5770cdefd8931aa9.x3b45b45d0f60a2d2 != null;
	}

	private static byte[] xa348115f6b938752(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.x3b45b45d0f60a2d2 == null)
		{
			return null;
		}
		return x5770cdefd8931aa9.x3b45b45d0f60a2d2.xcc18177a965e0313;
	}

	private static void x34a2c81a32d57957(Shape x5770cdefd8931aa9, x72c34b8dbaec3734 xe058541ca798c059)
	{
		ArrayList arrayList = new ArrayList();
		if (x5770cdefd8931aa9.x6b716952abd14950 != x26d9ecb4bdf0456d.x45260ad4b94166f2)
		{
			arrayList.Add(new x1975ae9f6890bb6e(x5770cdefd8931aa9.x6b716952abd14950));
		}
		x2bfc048c6117997a[] array = new x2bfc048c6117997a[arrayList.Count];
		arrayList.CopyTo(array);
		xe058541ca798c059.x819589f292a61f6b = array;
	}

	private static xf276f6a75b584d31 x7d78a235fde47f2c(ImageData xf1c258adc3c53c0e)
	{
		if (!xf1c258adc3c53c0e.x05c52fc2b5b2b094)
		{
			return null;
		}
		return new xf276f6a75b584d31(xf1c258adc3c53c0e.xa51f787cd3c1054d, 10);
	}

	private void x86593b7e2f85f761(xb8e7e788f6d59708 x92ba3975b1e8ea20, int xee1fb1c009e6deae, x6607281c5523036c x1c1af4362d2b5504, x2edb8efcf734419a x1acbe2e91f909139)
	{
		xb1ba701d4aec15c8 xb1ba701d4aec15c9 = new xb1ba701d4aec15c8();
		for (int i = 0; i < xee1fb1c009e6deae; i++)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = (xab391c46ff9a0a38)((xbaec545ec01f92ca)x8cedcaa9a62c6e39.xa1eafe7821eb4aab).get_xe6d4b1b411ed94b5(i);
			if (xab391c46ff9a0a.x9e5d5f9128c69a8f == null)
			{
				continue;
			}
			x1acbe2e91f909139?.x15ad6dda8b6cdb4c(xab391c46ff9a0a);
			xab391c46ff9a0a38[] array = xb1ba701d4aec15c9.xcfdb66715c8b7bf1(xab391c46ff9a0a, x8cedcaa9a62c6e39.xa9993ed2e0c64574.Stroke);
			if (array != null)
			{
				if (array[0].xd44988f225497f3a > 0)
				{
					x92ba3975b1e8ea20.xd6b6ed77479ef68c(array[0]);
				}
				if (array[1].xd44988f225497f3a > 0)
				{
					x92ba3975b1e8ea20.xd6b6ed77479ef68c(array[1]);
				}
			}
			xab391c46ff9a0a38[] array2 = x0c8c298e5b4ef6f5.x757450d4e4eec6d0(xab391c46ff9a0a);
			for (int j = 0; j < array2.Length; j++)
			{
				x92ba3975b1e8ea20.xd6b6ed77479ef68c(x1c1af4362d2b5504.xe94da055c1b9a188(array2[j], x2b818897b65c872e: true, xdb73611e5c07ce94: false));
			}
		}
	}

	private void xae8a4529b38e6e18(Shape x5770cdefd8931aa9)
	{
		if (x8cedcaa9a62c6e39.x8dc20c37aa4b28ef != null)
		{
			PointF[] x6fa2570084b2ad = new PointF[4]
			{
				PointF.Empty,
				new PointF(x5770cdefd8931aa9.CoordSize.Width, 0f),
				new PointF(x5770cdefd8931aa9.CoordSize.Width, x5770cdefd8931aa9.CoordSize.Height),
				new PointF(0f, x5770cdefd8931aa9.CoordSize.Height)
			};
			x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(x6fa2570084b2ad, x16aef18841fa33ad: false);
			xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38(null);
			xab391c46ff9a0a.x60465f602599d327 = x8cedcaa9a62c6e39.x8dc20c37aa4b28ef;
			xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e2.xa7b580afa8756d69(x6fa2570084b2ad, x7a848427f2a9a3b5: true));
			x8cedcaa9a62c6e39.xa1eafe7821eb4aab.xd6b6ed77479ef68c(xab391c46ff9a0a);
		}
	}

	private void x431f7c0b6ad6b096()
	{
		double strokeWeight = x8cedcaa9a62c6e39.xa9993ed2e0c64574.StrokeWeight;
		PointF pointF = x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.x80cf8ffbecbca30d();
		float x2a9085a8305df31b = (float)(strokeWeight / (double)pointF.Y);
		float x2d0cb225715e4c = (float)(strokeWeight / (double)pointF.Y);
		float xfb3d359e98811b9c = (float)(strokeWeight / (double)pointF.X);
		float x8cc48de2030b = (float)(strokeWeight / (double)pointF.X);
		PointF[] array = xa48f9fa3d0219bcd(x8cedcaa9a62c6e39.xa9993ed2e0c64574.CoordSize, x2a9085a8305df31b, x8cc48de2030b, x2d0cb225715e4c, xfb3d359e98811b9c);
		x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array, x16aef18841fa33ad: false);
		x0f224afd6fa95c60.xfea4fd3f1633453a(x8cedcaa9a62c6e39, array[0], array[1]);
		x0f224afd6fa95c60.xfea4fd3f1633453a(x8cedcaa9a62c6e39, array[2], array[3]);
		x0f224afd6fa95c60.xfea4fd3f1633453a(x8cedcaa9a62c6e39, array[4], array[5]);
		x0f224afd6fa95c60.xfea4fd3f1633453a(x8cedcaa9a62c6e39, array[6], array[7]);
	}

	private void x66d0167b6af07b8e(x7721ad963b03c6eb x8d3f74e5f925679c)
	{
		BorderCollection borders = x8cedcaa9a62c6e39.xa9993ed2e0c64574.ImageData.Borders;
		Border border = borders[BorderType.Top];
		Border border2 = borders[BorderType.Left];
		Border border3 = borders[BorderType.Right];
		Border border4 = borders[BorderType.Bottom];
		PointF pointF = x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.x80cf8ffbecbca30d();
		float num = (x8d3f74e5f925679c.x2cd066fdf892c9fb ? 0f : (border.xeae235558dc44397 / pointF.Y));
		float num2 = (x8d3f74e5f925679c.x6ffa01a29fd5c940 ? 0f : (border4.xeae235558dc44397 / pointF.Y));
		float num3 = (x8d3f74e5f925679c.x3e68ffe1419e6481 ? 0f : (border2.xeae235558dc44397 / pointF.X));
		float num4 = (x8d3f74e5f925679c.x7d3f5b36733451fa ? 0f : (border3.xeae235558dc44397 / pointF.X));
		PointF[] array = new PointF[2]
		{
			new PointF(0f - num3, 0f - num),
			new PointF((float)x8cedcaa9a62c6e39.xa9993ed2e0c64574.CoordSize.Width + num4, (float)x8cedcaa9a62c6e39.xa9993ed2e0c64574.CoordSize.Height + num2)
		};
		x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array, x16aef18841fa33ad: false);
		RectangleF xdc901b9828d8600c = new RectangleF(array[0], new SizeF(array[1].X - array[0].X, array[1].Y - array[0].Y));
		x5f887a65c13f569c x5f887a65c13f569c = new x5f887a65c13f569c(x9ec6ce5404580fa7.xa65184d44a47025b);
		x5f887a65c13f569c.xc28dff9f03c0d48f();
		x5f887a65c13f569c.xb1e2c9a68308ad60(xdc901b9828d8600c, border2, border3, border, border4);
		x5f887a65c13f569c.xb0770b4ea658e78d(x8cedcaa9a62c6e39.xa1eafe7821eb4aab);
	}

	private static PointF[] xa48f9fa3d0219bcd(Size x931b9f2b029e19c2, float x2a9085a8305df31b, float x8cc48de2030b0466, float x2d0cb225715e4c65, float xfb3d359e98811b9c)
	{
		float num = x2a9085a8305df31b * 0.5f;
		float num2 = xfb3d359e98811b9c * 0.5f;
		float num3 = x8cc48de2030b0466 * 0.5f;
		float num4 = x2d0cb225715e4c65 * 0.5f;
		return new PointF[8]
		{
			new PointF(0f - xfb3d359e98811b9c, 0f - num),
			new PointF((float)x931b9f2b029e19c2.Width + x8cc48de2030b0466, 0f - num),
			new PointF((float)x931b9f2b029e19c2.Width + num3, 0f),
			new PointF((float)x931b9f2b029e19c2.Width + num3, x931b9f2b029e19c2.Height),
			new PointF(0f - xfb3d359e98811b9c, (float)x931b9f2b029e19c2.Height + num4),
			new PointF((float)x931b9f2b029e19c2.Width + x8cc48de2030b0466, (float)x931b9f2b029e19c2.Height + num4),
			new PointF(0f - num2, 0f),
			new PointF(0f - num2, x931b9f2b029e19c2.Height)
		};
	}

	private void x3e07bba7d124ae86(x44f2b8bf33b16275 x37169c88a38f2f9b, ref int x251e26ec1b1ddfdc)
	{
		switch (x37169c88a38f2f9b.x4dd8a59ec8974a5f)
		{
		case x4dd8a59ec8974a5f.xd0baff30d99dc152:
			x251e26ec1b1ddfdc = xfe7f1ae385186d46(x37169c88a38f2f9b, x251e26ec1b1ddfdc);
			break;
		case x4dd8a59ec8974a5f.x102c43569e36d6d1:
			x251e26ec1b1ddfdc = xb6e4b7a13e1057cf(x37169c88a38f2f9b, x251e26ec1b1ddfdc, x7d15e7c89cebfd4a: false);
			break;
		case x4dd8a59ec8974a5f.x01b2723108ff3dfe:
			x8cedcaa9a62c6e39.xc71837477ad7a361();
			x8cedcaa9a62c6e39.x1219c4dfd5684616 = x8cedcaa9a62c6e39.xdbed53246e7dd53a[x251e26ec1b1ddfdc];
			x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4 = true;
			x251e26ec1b1ddfdc++;
			break;
		case x4dd8a59ec8974a5f.x8ffe90e7fbccfccd:
			x5d81ee813f580c38();
			break;
		case x4dd8a59ec8974a5f.x9fd888e65466818c:
			x8cedcaa9a62c6e39.x7c3d8cb25cd19d2f();
			break;
		case x4dd8a59ec8974a5f.x350c7c4c4aeebe37:
			x8cedcaa9a62c6e39.x273b54138ed7e7a4 = null;
			x251e26ec1b1ddfdc = x3298702e2fecfe73(x37169c88a38f2f9b, x251e26ec1b1ddfdc, x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4);
			break;
		case x4dd8a59ec8974a5f.x8dc4eedb9f218057:
			x8cedcaa9a62c6e39.xc71837477ad7a361();
			x251e26ec1b1ddfdc = x3298702e2fecfe73(x37169c88a38f2f9b, x251e26ec1b1ddfdc, x26c4af2ac5bf03af: false);
			break;
		case x4dd8a59ec8974a5f.x26a9b6a08a70bcb9:
			x8cedcaa9a62c6e39.xc71837477ad7a361();
			x251e26ec1b1ddfdc = x47b93873bcf17bfa(x37169c88a38f2f9b, x251e26ec1b1ddfdc, xe148aa9c5b3207a3: false, x26c4af2ac5bf03af: false);
			break;
		case x4dd8a59ec8974a5f.xc6c517e2ed4a7e97:
			x8cedcaa9a62c6e39.xc71837477ad7a361();
			x251e26ec1b1ddfdc = x47b93873bcf17bfa(x37169c88a38f2f9b, x251e26ec1b1ddfdc, xe148aa9c5b3207a3: true, x26c4af2ac5bf03af: false);
			break;
		case x4dd8a59ec8974a5f.x5fd023604497c8ef:
			x8cedcaa9a62c6e39.x273b54138ed7e7a4 = null;
			x251e26ec1b1ddfdc = x47b93873bcf17bfa(x37169c88a38f2f9b, x251e26ec1b1ddfdc, xe148aa9c5b3207a3: false, x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4);
			break;
		case x4dd8a59ec8974a5f.x27166c2759dd15ed:
			x8cedcaa9a62c6e39.x273b54138ed7e7a4 = null;
			x251e26ec1b1ddfdc = x47b93873bcf17bfa(x37169c88a38f2f9b, x251e26ec1b1ddfdc, xe148aa9c5b3207a3: true, x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4);
			break;
		case x4dd8a59ec8974a5f.xb9fb25f53beaeb97:
			x8cedcaa9a62c6e39.x273b54138ed7e7a4 = null;
			x251e26ec1b1ddfdc = x4f56637872ea62fe(x37169c88a38f2f9b, x251e26ec1b1ddfdc, x8f5a865b1b56bb14: true);
			break;
		case x4dd8a59ec8974a5f.xbfb6f7deb7122782:
			x8cedcaa9a62c6e39.x273b54138ed7e7a4 = null;
			x251e26ec1b1ddfdc = x4f56637872ea62fe(x37169c88a38f2f9b, x251e26ec1b1ddfdc, x8f5a865b1b56bb14: false);
			break;
		case x4dd8a59ec8974a5f.xaba04beace9e3ba6:
			x8cedcaa9a62c6e39.x6cd7659ca2021746.x60465f602599d327 = null;
			break;
		case x4dd8a59ec8974a5f.x59157f0bc21022ee:
			x8cedcaa9a62c6e39.x6cd7659ca2021746.x9e5d5f9128c69a8f = null;
			break;
		case x4dd8a59ec8974a5f.x1b75e1aaf09e9fd8:
			x251e26ec1b1ddfdc++;
			x8cedcaa9a62c6e39.x6cd7659ca2021746.x60465f602599d327 = x8cedcaa9a62c6e39.x8dc20c37aa4b28ef;
			break;
		default:
			throw new ArgumentOutOfRangeException("pathInfo");
		case x4dd8a59ec8974a5f.xf6c17f648b65c793:
		case x4dd8a59ec8974a5f.x43ebc9f6fe642c26:
		case x4dd8a59ec8974a5f.xcacbfbb8ebda9581:
		case x4dd8a59ec8974a5f.x972ee352bc10333a:
		case x4dd8a59ec8974a5f.x5385dbd3a02b9d51:
		case x4dd8a59ec8974a5f.x071db3f5ac4e06f1:
		case x4dd8a59ec8974a5f.x151dd09850c9ad99:
		case x4dd8a59ec8974a5f.xc2fb2c3f7acca9e7:
		case x4dd8a59ec8974a5f.x69878f92f4bc5951:
		case x4dd8a59ec8974a5f.x615f924a9b069c32:
		case x4dd8a59ec8974a5f.x172d8f34bea37b59:
		case x4dd8a59ec8974a5f.xfd6a3e688173e39d:
		case x4dd8a59ec8974a5f.x3c68d0a3c5adb970:
			break;
		}
	}

	private int x4f56637872ea62fe(x44f2b8bf33b16275 x37169c88a38f2f9b, int x251e26ec1b1ddfdc, bool x8f5a865b1b56bb14)
	{
		for (int i = 0; i < x37169c88a38f2f9b.x7bc0a12a325563e9; i++)
		{
			x9f05b21d15c11a03(x8a13c8a914177153(ref x251e26ec1b1ddfdc, x8f5a865b1b56bb14));
			x8f5a865b1b56bb14 = !x8f5a865b1b56bb14;
		}
		x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4 = false;
		return x251e26ec1b1ddfdc;
	}

	private x9fe47a4de491f4aa[] x8a13c8a914177153(ref int x251e26ec1b1ddfdc, bool x8f5a865b1b56bb14)
	{
		PointF[] array = new PointF[2]
		{
			x8cedcaa9a62c6e39.x1219c4dfd5684616,
			x8cedcaa9a62c6e39.xdbed53246e7dd53a[x251e26ec1b1ddfdc]
		};
		x8cedcaa9a62c6e39.x1219c4dfd5684616 = x8cedcaa9a62c6e39.xdbed53246e7dd53a[x251e26ec1b1ddfdc];
		x251e26ec1b1ddfdc++;
		float num = Math.Abs(array[1].X - array[0].X);
		float num2 = Math.Abs(array[1].Y - array[0].Y);
		PointF xab07b26048f600ba = (x8f5a865b1b56bb14 ? new PointF(array[0].X - num, array[1].Y - num2) : new PointF(array[1].X - num, array[0].Y - num2));
		SizeF x437e3b626c0fdd = new SizeF(num * 2f, num2 * 2f);
		float num3;
		float num4;
		if (array[0].X < array[1].X && array[0].Y < array[1].Y)
		{
			if (x8f5a865b1b56bb14)
			{
				num3 = 270f;
				num4 = 90f;
			}
			else
			{
				num3 = 180f;
				num4 = -90f;
			}
		}
		else if (array[0].X < array[1].X && array[0].Y > array[1].Y)
		{
			if (x8f5a865b1b56bb14)
			{
				num3 = 90f;
				num4 = -90f;
			}
			else
			{
				num3 = 180f;
				num4 = 90f;
			}
		}
		else if (array[0].X > array[1].X && array[0].Y > array[1].Y)
		{
			if (x8f5a865b1b56bb14)
			{
				num3 = 90f;
				num4 = 90f;
			}
			else
			{
				num3 = 0f;
				num4 = -90f;
			}
		}
		else if (x8f5a865b1b56bb14)
		{
			num3 = 270f;
			num4 = -90f;
		}
		else
		{
			num3 = 0f;
			num4 = 90f;
		}
		x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a();
		x1fb5d45c2d0b868a.xab07b26048f600ba = xab07b26048f600ba;
		x1fb5d45c2d0b868a.x437e3b626c0fdd43 = x437e3b626c0fdd;
		x1fb5d45c2d0b868a.xba40a5b113d122a1 = num3;
		x1fb5d45c2d0b868a.xae49680937687932 = num4;
		return x64e0614c76f963b6(x1fb5d45c2d0b868a);
	}

	private int xfe7f1ae385186d46(x44f2b8bf33b16275 x37169c88a38f2f9b, int x251e26ec1b1ddfdc)
	{
		PointF[] array = new PointF[1] { PointF.Empty };
		x60c040f35bb272aa x60c040f35bb272aa = x8cedcaa9a62c6e39.x273b54138ed7e7a4 as x60c040f35bb272aa;
		if (x60c040f35bb272aa == null)
		{
			x60c040f35bb272aa = new x60c040f35bb272aa();
			x8cedcaa9a62c6e39.x9f2a8e5b70f0bda8.xd6b6ed77479ef68c(x60c040f35bb272aa);
			x8cedcaa9a62c6e39.x273b54138ed7e7a4 = x60c040f35bb272aa;
			if (x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4)
			{
				ref PointF reference = ref array[0];
				reference = x8cedcaa9a62c6e39.x1219c4dfd5684616;
				x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array, x16aef18841fa33ad: false);
				x60c040f35bb272aa.x4d7474e8f1849803.Add(array[0]);
			}
		}
		int x7bc0a12a325563e = x37169c88a38f2f9b.x7bc0a12a325563e9;
		for (int i = 0; i < x7bc0a12a325563e; i++)
		{
			x8cedcaa9a62c6e39.x1219c4dfd5684616 = x8cedcaa9a62c6e39.xdbed53246e7dd53a[x251e26ec1b1ddfdc];
			ref PointF reference2 = ref array[0];
			reference2 = x8cedcaa9a62c6e39.x1219c4dfd5684616;
			x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array, x16aef18841fa33ad: false);
			x60c040f35bb272aa.x4d7474e8f1849803.Add(array[0]);
			x251e26ec1b1ddfdc++;
		}
		return x251e26ec1b1ddfdc;
	}

	private int x47b93873bcf17bfa(x44f2b8bf33b16275 x37169c88a38f2f9b, int x251e26ec1b1ddfdc, bool xe148aa9c5b3207a3, bool x26c4af2ac5bf03af)
	{
		int num = x37169c88a38f2f9b.x7bc0a12a325563e9 / 4;
		for (int i = 0; i < num; i++)
		{
			x9fe47a4de491f4aa[] array = xb00bc48d4b6ba4f5(ref x251e26ec1b1ddfdc, xe148aa9c5b3207a3);
			if (x26c4af2ac5bf03af)
			{
				xc3fa24824f8b7bdd(array);
				x26c4af2ac5bf03af = false;
			}
			x9f05b21d15c11a03(array);
		}
		x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4 = false;
		return x251e26ec1b1ddfdc;
	}

	private void xc3fa24824f8b7bdd(x9fe47a4de491f4aa[] x51efd71b3cdcbf9c)
	{
		if (x8cedcaa9a62c6e39.x9f2a8e5b70f0bda8.xd44988f225497f3a == 0)
		{
			PointF xaf4e0fbe61814cf = x51efd71b3cdcbf9c[0].xaf4e0fbe61814cf5;
			if (xaf4e0fbe61814cf.X != x8cedcaa9a62c6e39.x1219c4dfd5684616.X || xaf4e0fbe61814cf.Y != x8cedcaa9a62c6e39.x1219c4dfd5684616.Y)
			{
				PointF[] array = new PointF[1] { PointF.Empty };
				ref PointF reference = ref array[0];
				reference = x8cedcaa9a62c6e39.x1219c4dfd5684616;
				x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array, x16aef18841fa33ad: false);
				x60c040f35bb272aa x60c040f35bb272aa = new x60c040f35bb272aa();
				x60c040f35bb272aa.x4d7474e8f1849803.Add(array[0]);
				x60c040f35bb272aa.x4d7474e8f1849803.Add(xaf4e0fbe61814cf);
				x8cedcaa9a62c6e39.x9f2a8e5b70f0bda8.xd6b6ed77479ef68c(x60c040f35bb272aa);
			}
		}
	}

	private void x9f05b21d15c11a03(x9fe47a4de491f4aa[] x11c5e7fe758bb361)
	{
		for (int i = 0; i < x11c5e7fe758bb361.Length; i++)
		{
			x519b1bd0625473ff x519b1bd0625473ff = new x519b1bd0625473ff();
			x519b1bd0625473ff.x56b911bdb6515aed = x11c5e7fe758bb361[i];
			x8cedcaa9a62c6e39.x9f2a8e5b70f0bda8.xd6b6ed77479ef68c(x519b1bd0625473ff);
		}
	}

	private int x3298702e2fecfe73(x44f2b8bf33b16275 x37169c88a38f2f9b, int x251e26ec1b1ddfdc, bool x26c4af2ac5bf03af)
	{
		int num = x37169c88a38f2f9b.x7bc0a12a325563e9 / 3;
		for (int i = 0; i < num; i++)
		{
			x9fe47a4de491f4aa[] array = xaee6e3a18bcfc585(ref x251e26ec1b1ddfdc);
			if (x26c4af2ac5bf03af)
			{
				xc3fa24824f8b7bdd(array);
				x26c4af2ac5bf03af = false;
			}
			x9f05b21d15c11a03(array);
		}
		x8cedcaa9a62c6e39.x5cce5b9d6bbc69c4 = false;
		return x251e26ec1b1ddfdc;
	}

	private x9fe47a4de491f4aa[] xaee6e3a18bcfc585(ref int x251e26ec1b1ddfdc)
	{
		PointF[] array = new PointF[1] { x8cedcaa9a62c6e39.xdbed53246e7dd53a[x251e26ec1b1ddfdc] };
		PointF pointF = array[0];
		x251e26ec1b1ddfdc++;
		ref PointF reference = ref array[0];
		reference = x8cedcaa9a62c6e39.xdbed53246e7dd53a[x251e26ec1b1ddfdc];
		PointF pointF2 = array[0];
		x251e26ec1b1ddfdc++;
		PointF pointF3 = x8cedcaa9a62c6e39.xdbed53246e7dd53a[x251e26ec1b1ddfdc];
		x251e26ec1b1ddfdc++;
		x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a();
		x1fb5d45c2d0b868a.xba40a5b113d122a1 = 360f - pointF3.X / 65536f;
		x1fb5d45c2d0b868a.xae49680937687932 = (0f - pointF3.Y) / 65536f;
		x1fb5d45c2d0b868a.x437e3b626c0fdd43 = new SizeF(pointF2.X * 2f, pointF2.Y * 2f);
		x1fb5d45c2d0b868a.xab07b26048f600ba = new PointF(pointF.X - pointF2.X, pointF.Y - pointF2.Y);
		return x64e0614c76f963b6(x1fb5d45c2d0b868a);
	}

	private int xb6e4b7a13e1057cf(x44f2b8bf33b16275 x37169c88a38f2f9b, int x251e26ec1b1ddfdc, bool x7d15e7c89cebfd4a)
	{
		for (int i = 0; i < x37169c88a38f2f9b.x7bc0a12a325563e9; i++)
		{
			PointF[] array = new PointF[4]
			{
				PointF.Empty,
				PointF.Empty,
				PointF.Empty,
				PointF.Empty
			};
			Array.Copy(x8cedcaa9a62c6e39.xdbed53246e7dd53a, x251e26ec1b1ddfdc, array, 1, 3);
			PointF x1219c4dfd = x8cedcaa9a62c6e39.x1219c4dfd5684616;
			array[0] = x1219c4dfd;
			if (x7d15e7c89cebfd4a)
			{
				for (int j = 1; j < 4; j++)
				{
					PointF pointF = array[j];
					PointF pointF2 = new PointF(pointF.X + x1219c4dfd.X, pointF.Y + x1219c4dfd.Y);
					array[j] = pointF2;
				}
			}
			x251e26ec1b1ddfdc += 3;
			x8cedcaa9a62c6e39.x1219c4dfd5684616 = array[3];
			x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array, x16aef18841fa33ad: false);
			x8cedcaa9a62c6e39.x9f2a8e5b70f0bda8.xd6b6ed77479ef68c(new x519b1bd0625473ff(array));
		}
		x8cedcaa9a62c6e39.x273b54138ed7e7a4 = null;
		return x251e26ec1b1ddfdc;
	}

	private void x5d81ee813f580c38()
	{
		x8cedcaa9a62c6e39.x9f2a8e5b70f0bda8.x5e6c52cb3256cc85 = true;
	}

	private x9fe47a4de491f4aa[] xb00bc48d4b6ba4f5(ref int x251e26ec1b1ddfdc, bool xe148aa9c5b3207a3)
	{
		PointF[] array = new PointF[4]
		{
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty
		};
		Array.Copy(x8cedcaa9a62c6e39.xdbed53246e7dd53a, x251e26ec1b1ddfdc, array, 0, 4);
		x251e26ec1b1ddfdc += 4;
		PointF pointF = array[0];
		PointF pointF2 = array[1];
		float x = pointF.X;
		float y = pointF.Y;
		float x2 = pointF2.X;
		float y2 = pointF2.Y;
		if (pointF.X > pointF2.X)
		{
			x = pointF2.X;
			x2 = pointF.X;
		}
		if (pointF.Y > pointF2.Y)
		{
			y = pointF2.Y;
			y2 = pointF.Y;
		}
		float num = (x2 - x) * 0.5f;
		float num2 = (y2 - y) * 0.5f;
		float num3 = x + num;
		float num4 = y + num2;
		PointF pointF3 = new PointF(array[2].X - num3, array[2].Y - num4);
		PointF pointF4 = new PointF(array[3].X - num3, array[3].Y - num4);
		double num5 = pointF3.X;
		double d = num5 / Math.Sqrt((double)pointF3.X * (double)pointF3.X + (double)pointF3.Y * (double)pointF3.Y);
		double num6 = x15e971129fd80714.xc9211137ad7bfa2a(Math.Acos(d));
		if (pointF3.Y < 0f)
		{
			num6 = 360.0 - num6;
		}
		double num7 = pointF4.X;
		double d2 = num7 / Math.Sqrt((double)pointF4.X * (double)pointF4.X + (double)pointF4.Y * (double)pointF4.Y);
		double num8 = x15e971129fd80714.xc9211137ad7bfa2a(Math.Acos(d2));
		if (pointF4.Y < 0f)
		{
			num8 = 360.0 - num8;
		}
		double xba40a5b113d122a = num6;
		double xae49680937687932 = ((!xe148aa9c5b3207a3) ? ((num8 > num6) ? (num8 - 360.0 - num6) : (num8 - num6)) : ((num8 > num6) ? (num8 - num6) : (360.0 - num6 + num8)));
		x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a();
		x1fb5d45c2d0b868a.xba40a5b113d122a1 = xba40a5b113d122a;
		x1fb5d45c2d0b868a.xae49680937687932 = xae49680937687932;
		x1fb5d45c2d0b868a.x437e3b626c0fdd43 = new SizeF(x2 - x, y2 - y);
		x1fb5d45c2d0b868a.xab07b26048f600ba = new PointF(x, y);
		return x64e0614c76f963b6(x1fb5d45c2d0b868a);
	}

	private x9fe47a4de491f4aa[] x64e0614c76f963b6(x1fb5d45c2d0b868a xc919e9fef7dfced6)
	{
		x9fe47a4de491f4aa[] array = xc919e9fef7dfced6.x1a10ab118b131ef0();
		PointF[] array2 = new PointF[array.Length * 4];
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			ref PointF reference = ref array2[num];
			reference = array[i].xaf4e0fbe61814cf5;
			num++;
			ref PointF reference2 = ref array2[num];
			reference2 = array[i].xc7cf0e43653f9c41;
			num++;
			ref PointF reference3 = ref array2[num];
			reference3 = array[i].xf52fe1c3cad11afd;
			num++;
			ref PointF reference4 = ref array2[num];
			reference4 = array[i].x2271dea312f4a835;
			num++;
		}
		x8cedcaa9a62c6e39.xaeddb4fe9ae94a6a.xa4b699bd47eb7372(array2, x16aef18841fa33ad: false);
		num = 0;
		for (int j = 0; j < array.Length; j++)
		{
			x9fe47a4de491f4aa x9fe47a4de491f4aa = default(x9fe47a4de491f4aa);
			x9fe47a4de491f4aa.xaf4e0fbe61814cf5 = array2[num];
			num++;
			x9fe47a4de491f4aa.xc7cf0e43653f9c41 = array2[num];
			num++;
			x9fe47a4de491f4aa.xf52fe1c3cad11afd = array2[num];
			num++;
			x9fe47a4de491f4aa.x2271dea312f4a835 = array2[num];
			num++;
			array[j] = x9fe47a4de491f4aa;
		}
		return array;
	}
}

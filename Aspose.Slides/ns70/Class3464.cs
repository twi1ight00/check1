using System;
using System.Runtime.InteropServices;

namespace ns70;

internal sealed class Class3464 : Class3462
{
	private const string string_0 = "glu32.dll";

	public const uint uint_0 = 1u;

	public const uint uint_1 = 1u;

	public const uint uint_2 = 100900u;

	public const uint uint_3 = 100901u;

	public const uint uint_4 = 100902u;

	public const uint uint_5 = 100903u;

	public const uint uint_6 = 100800u;

	public const uint uint_7 = 100801u;

	public const uint uint_8 = 1u;

	public const uint uint_9 = 0u;

	public const uint uint_10 = 100000u;

	public const uint uint_11 = 100001u;

	public const uint uint_12 = 100002u;

	public const uint uint_13 = 100010u;

	public const uint uint_14 = 100011u;

	public const uint uint_15 = 100012u;

	public const uint uint_16 = 100013u;

	public const uint uint_17 = 100020u;

	public const uint uint_18 = 100021u;

	public const double double_0 = 1E+150;

	public const uint uint_19 = 100140u;

	public const uint uint_20 = 100141u;

	public const uint uint_21 = 100142u;

	public const uint uint_22 = 100130u;

	public const uint uint_23 = 100131u;

	public const uint uint_24 = 100132u;

	public const uint uint_25 = 100133u;

	public const uint uint_26 = 100134u;

	public const uint uint_27 = 100100u;

	public const uint uint_28 = 100101u;

	public const uint uint_29 = 100102u;

	public const uint uint_30 = 100103u;

	public const uint uint_31 = 100104u;

	public const uint uint_32 = 100105u;

	public const uint uint_33 = 100106u;

	public const uint uint_34 = 100107u;

	public const uint uint_35 = 100108u;

	public const uint uint_36 = 100109u;

	public const uint uint_37 = 100110u;

	public const uint uint_38 = 100111u;

	public const uint uint_39 = 100151u;

	public const uint uint_40 = 100152u;

	public const uint uint_41 = 100153u;

	public const uint uint_42 = 100154u;

	public const uint uint_43 = 100155u;

	public const uint uint_44 = 100156u;

	public const uint uint_45 = 100157u;

	public const uint uint_46 = 100158u;

	public const uint uint_47 = 100151u;

	public const uint uint_48 = 100152u;

	public const uint uint_49 = 100153u;

	public const uint uint_50 = 100154u;

	public const uint uint_51 = 100155u;

	public const uint uint_52 = 100156u;

	public const uint uint_53 = 100200u;

	public const uint uint_54 = 100201u;

	public const uint uint_55 = 100203u;

	public const uint uint_56 = 100204u;

	public const uint uint_57 = 100202u;

	public const uint uint_58 = 100205u;

	public const uint uint_59 = 100206u;

	public const uint uint_60 = 100207u;

	public const uint uint_61 = 100215u;

	public const uint uint_62 = 100216u;

	public const uint uint_63 = 100217u;

	public const uint uint_64 = 100210u;

	public const uint uint_65 = 100211u;

	public const uint uint_66 = 100240u;

	public const uint uint_67 = 100241u;

	public const uint uint_68 = 100251u;

	public const uint uint_69 = 100252u;

	public const uint uint_70 = 100253u;

	public const uint uint_71 = 100254u;

	public const uint uint_72 = 100255u;

	public const uint uint_73 = 100256u;

	public const uint uint_74 = 100257u;

	public const uint uint_75 = 100258u;

	public const uint uint_76 = 100259u;

	public const uint uint_77 = 100260u;

	public const uint uint_78 = 100261u;

	public const uint uint_79 = 100262u;

	public const uint uint_80 = 100263u;

	public const uint uint_81 = 100264u;

	public const uint uint_82 = 100265u;

	public const uint uint_83 = 100266u;

	public const uint uint_84 = 100267u;

	public const uint uint_85 = 100268u;

	public const uint uint_86 = 100269u;

	public const uint uint_87 = 100270u;

	public const uint uint_88 = 100271u;

	public const uint uint_89 = 100272u;

	public const uint uint_90 = 100273u;

	public const uint uint_91 = 100274u;

	public const uint uint_92 = 100275u;

	public const uint uint_93 = 100276u;

	public const uint uint_94 = 100277u;

	public const uint uint_95 = 100278u;

	public const uint uint_96 = 100279u;

	public const uint uint_97 = 100280u;

	public const uint uint_98 = 100281u;

	public const uint uint_99 = 100282u;

	public const uint uint_100 = 100283u;

	public const uint uint_101 = 100284u;

	public const uint uint_102 = 100285u;

	public const uint uint_103 = 100286u;

	public const uint uint_104 = 100287u;

	private Class3464()
	{
	}

	[DllImport("glu32.dll")]
	public static extern string gluErrorString(int errCode);

	[DllImport("glu32.dll")]
	public static extern string gluGetString(int name);

	[DllImport("glu32.dll")]
	public static extern void gluOrtho2D(double left, double right, double bottom, double top);

	[DllImport("glu32.dll")]
	public static extern void gluPerspective(double fovy, double aspect, double zNear, double zFar);

	[DllImport("glu32.dll")]
	public static extern void gluPickMatrix(double x, double y, double width, double height, int[] viewport);

	[DllImport("glu32.dll")]
	public static extern void gluLookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz);

	[DllImport("glu32.dll")]
	public static extern void gluProject(double objx, double objy, double objz, double[] modelMatrix, double[] projMatrix, int[] viewport, double[] winx, double[] winy, double[] winz);

	[DllImport("glu32.dll")]
	public static extern void gluUnProject(double winx, double winy, double winz, double[] modelMatrix, double[] projMatrix, int[] viewport, double[] objx, double[] objy, double[] objz);

	[DllImport("glu32.dll")]
	public static extern void gluScaleImage(int format, int widthin, int heightin, int typein, int[] datain, int widthout, int heightout, int typeout, int[] dataout);

	[DllImport("glu32.dll")]
	public static extern void gluBuild1DMipmaps(int target, int components, int width, int format, int type, int[] data);

	[DllImport("glu32.dll")]
	public static extern void gluBuild2DMipmaps(int target, int components, int width, int height, int format, int type, int[] data);

	[DllImport("glu32.dll")]
	public static extern IntPtr gluNewQuadric();

	[DllImport("glu32.dll")]
	public static extern void gluDeleteQuadric(IntPtr state);

	[DllImport("glu32.dll")]
	public static extern void gluQuadricNormals(IntPtr quadObject, int normals);

	[DllImport("glu32.dll")]
	public static extern void gluQuadricTexture(IntPtr quadObject, int textureCoords);

	[DllImport("glu32.dll")]
	public static extern void gluQuadricOrientation(IntPtr quadObject, int orientation);

	[DllImport("glu32.dll")]
	public static extern void gluQuadricDrawStyle(IntPtr quadObject, uint drawStyle);

	[DllImport("glu32.dll")]
	public static extern void gluDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops);

	[DllImport("glu32.dll")]
	public static extern void gluPartialDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle);

	[DllImport("glu32.dll")]
	public static extern void gluSphere(IntPtr qobj, double radius, int slices, int stacks);

	[DllImport("glu32.dll")]
	public static extern IntPtr gluNewTess();

	[DllImport("glu32.dll")]
	public static extern void gluDeleteTess(IntPtr tess);

	[DllImport("glu32.dll")]
	public static extern void gluTessBeginPolygon(IntPtr tess, IntPtr polygonData);

	[DllImport("glu32.dll")]
	public static extern void gluTessBeginContour(IntPtr tess);

	[DllImport("glu32.dll")]
	public static extern void gluTessVertex(IntPtr tess, double[] coords, double[] data);

	[DllImport("glu32.dll")]
	public static extern void gluTessEndContour(IntPtr tess);

	[DllImport("glu32.dll")]
	public static extern void gluTessEndPolygon(IntPtr tess);

	[DllImport("glu32.dll")]
	public static extern void gluTessProperty(IntPtr tess, int which, double value);

	[DllImport("glu32.dll")]
	public static extern void gluTessNormal(IntPtr tess, double x, double y, double z);

	[DllImport("glu32.dll")]
	public static extern void gluGetTessProperty(IntPtr tess, int which, double value);

	[DllImport("glu32.dll")]
	public static extern IntPtr gluNewNurbsRenderer();

	[DllImport("glu32.dll")]
	public static extern void gluDeleteNurbsRenderer(IntPtr nobj);

	[DllImport("glu32.dll")]
	public static extern void gluBeginSurface(IntPtr nobj);

	[DllImport("glu32.dll")]
	public static extern void gluBeginCurve(IntPtr nobj);

	[DllImport("glu32.dll")]
	public static extern void gluEndCurve(IntPtr nobj);

	[DllImport("glu32.dll")]
	public static extern void gluEndSurface(IntPtr nobj);

	[DllImport("glu32.dll")]
	public static extern void gluBeginTrim(IntPtr nobj);

	[DllImport("glu32.dll")]
	public static extern void gluEndTrim(IntPtr nobj);

	[DllImport("glu32.dll")]
	public static extern void gluPwlCurve(IntPtr nobj, int count, float array, int stride, uint type);

	[DllImport("glu32.dll")]
	public static extern void gluNurbsCurve(IntPtr nobj, int nknots, float[] knot, int stride, float[] ctlarray, int order, uint type);

	[DllImport("glu32.dll")]
	public static extern void gluNurbsSurface(IntPtr nobj, int sknotCount, float[] sknot, int tknotCount, float[] tknot, int sStride, int tStride, float[] ctlarray, int sorder, int torder, uint type);

	[DllImport("glu32.dll")]
	public static extern void gluLoadSamplingMatrices(IntPtr nobj, float[] modelMatrix, float[] projMatrix, int[] viewport);

	[DllImport("glu32.dll")]
	public static extern void gluNurbsProperty(IntPtr nobj, int property, float value);

	[DllImport("glu32.dll")]
	public static extern void gluGetNurbsProperty(IntPtr nobj, int property, float value);

	[DllImport("glu32.dll")]
	public static extern void IntPtrCallback(IntPtr nobj, int which, IntPtr callback);

	public string method_0(int errCode)
	{
		return "";
	}

	public string method_1(int name)
	{
		return "";
	}

	public void method_2(int format, int widthin, int heightin, int typein, int[] datain, int widthout, int heightout, int typeout, int[] dataout)
	{
	}

	public void method_3(int target, int components, int width, int format, int type, int[] data)
	{
	}

	public void method_4(int target, int components, int width, int height, int format, int type, int[] data)
	{
	}

	public void method_5(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops)
	{
	}

	public IntPtr method_6()
	{
		return IntPtr.Zero;
	}

	public void method_7(IntPtr tess)
	{
	}

	public void method_8(IntPtr tess, IntPtr polygonData)
	{
	}

	public void method_9(IntPtr tess)
	{
	}

	public void method_10(IntPtr tess, double[] coords, double[] data)
	{
	}

	public void method_11(IntPtr tess)
	{
	}

	public void method_12(IntPtr tess)
	{
	}

	public void method_13(IntPtr tess, int which, double value)
	{
	}

	public void method_14(IntPtr tess, double x, double y, double z)
	{
	}

	public void method_15(IntPtr tess, int which, double value)
	{
	}

	public void method_16(IntPtr nobj)
	{
	}

	public void method_17(IntPtr nobj)
	{
	}

	public void method_18(IntPtr nobj, int count, float array, int stride, int type)
	{
	}

	public void method_19(IntPtr nobj, float[] modelMatrix, float[] projMatrix, int[] viewport)
	{
	}

	public void method_20(IntPtr nobj, int property, float value)
	{
	}
}

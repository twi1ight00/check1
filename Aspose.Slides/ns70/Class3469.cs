using System;
using System.ComponentModel;
using System.Drawing;

namespace ns70;

internal sealed class Class3469 : IDisposable
{
	private readonly Class3461 class3461_0;

	private readonly IntPtr intptr_0 = IntPtr.Zero;

	private readonly IntPtr intptr_1 = IntPtr.Zero;

	private bool bool_0;

	public int Width => class3461_0.Width;

	public int Height => class3461_0.Height;

	public Bitmap method_0()
	{
		return Image.FromHbitmap(class3461_0.HBitmap);
	}

	public Class3469(int width, int height)
	{
		class3461_0 = new Class3461(width, height);
		try
		{
			try
			{
				intptr_1 = Class3465.smethod_2(class3461_0.HDC);
			}
			catch (Win32Exception ex)
			{
				if (ex.NativeErrorCode != 2000)
				{
					throw;
				}
				class3461_0.method_0();
				intptr_1 = Class3465.smethod_2(class3461_0.HDC);
			}
			intptr_0 = class3461_0.HDC;
			method_1();
		}
		catch
		{
			class3461_0.Dispose();
			throw;
		}
	}

	public void Dispose()
	{
		class3461_0.Dispose();
	}

	public void method_1()
	{
		Class3465.smethod_1(intptr_0, intptr_1);
	}

	public void method_2()
	{
		Class3463.smethod_3(intptr_0);
	}

	public void method_3(uint op, float value)
	{
		method_160();
		Class3465.glAccum(op, value);
		method_161();
	}

	public void method_4(uint mode)
	{
		method_160();
		Class3465.glBegin(mode);
		bool_0 = true;
		method_161();
	}

	public void method_5(uint target, uint texture)
	{
		method_160();
		Class3465.glBindTexture(target, texture);
		method_161();
	}

	public void method_6(uint sfactor, uint dfactor)
	{
		method_160();
		Class3465.glBlendFunc(sfactor, dfactor);
		method_161();
	}

	public void method_7(uint list)
	{
		method_160();
		Class3465.glCallList(list);
		method_161();
	}

	public void Clear(uint mask)
	{
		method_160();
		Class3465.glClear(mask);
		method_161();
	}

	public void method_8(float red, float green, float blue, float alpha)
	{
		method_160();
		Class3465.glClearColor(red, green, blue, alpha);
		method_161();
	}

	public void method_9(double depth)
	{
		method_160();
		Class3465.glClearDepth(depth);
		method_161();
	}

	public void method_10(float red, float green, float blue, float alpha)
	{
		method_160();
		Class3465.glColor4f(red, green, blue, alpha);
		method_161();
	}

	public void method_11(byte red, byte green, byte blue, byte alpha)
	{
		method_160();
		Class3465.glColorMask(red, green, blue, alpha);
		method_161();
	}

	public void method_12(uint list, int range)
	{
		method_160();
		Class3465.glDeleteLists(list, range);
		method_161();
	}

	public void method_13(IntPtr nurbsObject)
	{
		method_160();
		Class3464.gluDeleteNurbsRenderer(nurbsObject);
		method_161();
	}

	public void method_14(int n, uint[] textures)
	{
		method_160();
		Class3465.glDeleteTextures(n, textures);
		method_161();
	}

	public void method_15(IntPtr quadric)
	{
		method_160();
		Class3464.gluDeleteQuadric(quadric);
		method_161();
	}

	public void method_16(uint func)
	{
		method_160();
		Class3465.glDepthFunc(func);
		method_161();
	}

	public void method_17(byte flag)
	{
		method_160();
		Class3465.glDepthMask(flag);
		method_161();
	}

	public void method_18(uint cap)
	{
		method_160();
		Class3465.glDisable(cap);
		method_161();
	}

	public void method_19(uint array)
	{
		method_160();
		Class3465.glDisableClientState(array);
		method_161();
	}

	public void method_20(int width, int height, uint format, uint type, float[] pixels)
	{
		method_160();
		Class3465.glDrawPixels(width, height, format, type, pixels);
		method_161();
	}

	public void method_21(uint cap)
	{
		method_160();
		Class3465.glEnable(cap);
		method_161();
	}

	public void method_22(uint array)
	{
		method_160();
		Class3465.glEnableClientState(array);
		method_161();
	}

	public void method_23(uint cap, bool test)
	{
		if (test)
		{
			method_21(cap);
		}
		else
		{
			method_18(cap);
		}
	}

	public void method_24()
	{
		method_160();
		Class3465.glEnd();
		bool_0 = false;
		method_161();
	}

	public void method_25()
	{
		method_160();
		Class3465.glEndList();
		method_161();
	}

	public void method_26(IntPtr nurbsObject)
	{
		method_160();
		Class3464.gluEndSurface(nurbsObject);
		method_161();
	}

	public void method_27(double u)
	{
		method_160();
		Class3465.glEvalCoord1d(u);
		method_161();
	}

	public void method_28(double[] u)
	{
	}

	public void method_29(float u)
	{
		method_160();
		Class3465.glEvalCoord1f(u);
		method_161();
	}

	public void method_30(uint mode, int i1, int i2)
	{
		method_160();
		Class3465.glEvalMesh1(mode, i1, i2);
		method_161();
	}

	public void method_31(uint mode, int i1, int i2, int j1, int j2)
	{
		method_160();
		Class3465.glEvalMesh2(mode, i1, i2, j1, j2);
		method_161();
	}

	public void method_32(int size, uint type, float[] buffer)
	{
		method_160();
		Class3465.glFeedbackBuffer(size, type, buffer);
		method_161();
	}

	public void method_33()
	{
		method_160();
		Class3465.glFinish();
		method_161();
	}

	public void Flush()
	{
		method_160();
		Class3465.glFlush();
		method_161();
	}

	public void method_34(uint pname, float param)
	{
		method_160();
		Class3465.glFogf(pname, param);
		method_161();
	}

	public void method_35(uint pname, float[] parameters)
	{
		method_160();
		Class3465.glFogfv(pname, parameters);
		method_161();
	}

	public void method_36(uint pname, int param)
	{
		method_160();
		Class3465.glFogi(pname, param);
		method_161();
	}

	public void method_37(uint pname, int[] parameters)
	{
		method_160();
		Class3465.glFogiv(pname, parameters);
		method_161();
	}

	public void method_38(uint mode)
	{
		method_160();
		Class3465.glFrontFace(mode);
		method_161();
	}

	public void method_39(double left, double right, double bottom, double top, double zNear, double zFar)
	{
		method_160();
		Class3465.glFrustum(left, right, bottom, top, zNear, zFar);
		method_161();
	}

	public uint method_40(int range)
	{
		method_160();
		uint result = Class3465.glGenLists(range);
		method_161();
		return result;
	}

	public void method_41(int n, uint[] textures)
	{
		method_160();
		Class3465.glGenTextures(n, textures);
		method_161();
	}

	public void method_42(uint pname, byte[] parameters)
	{
		method_160();
		Class3465.glGetBooleanv(pname, parameters);
		method_161();
	}

	public void method_43(uint plane, double[] equation)
	{
	}

	public void method_44(uint pname, double[] parameters)
	{
		method_160();
		Class3465.glGetDoublev(pname, parameters);
		method_161();
	}

	public uint method_45()
	{
		return Class3465.glGetError();
	}

	public void method_46(uint pname, float[] parameters)
	{
		method_160();
		Class3465.glGetFloatv(pname, parameters);
		method_161();
	}

	public void method_47(uint pname, int[] parameters)
	{
		method_160();
		Class3465.glGetIntegerv(pname, parameters);
		method_161();
	}

	public string method_48(uint name)
	{
		return Class3465.glGetString(name);
	}

	public void method_49(uint target, uint mode)
	{
		method_160();
		Class3465.glHint(target, mode);
		method_161();
	}

	public void method_50()
	{
		method_160();
		Class3465.glInitNames();
		method_161();
	}

	public bool method_51(uint cap)
	{
		method_160();
		byte b = Class3465.glIsEnabled(cap);
		method_161();
		if (b != 0)
		{
			return true;
		}
		return false;
	}

	public byte method_52(uint list)
	{
		method_160();
		byte result = Class3465.glIsList(list);
		method_161();
		return result;
	}

	public byte method_53(uint texture)
	{
		return 0;
	}

	public void method_54(uint pname, float param)
	{
		method_160();
		Class3465.glLightModelf(pname, param);
		method_161();
	}

	public void method_55(uint pname, float[] parameters)
	{
		method_160();
		Class3465.glLightModelfv(pname, parameters);
		method_161();
	}

	public void method_56(uint pname, int param)
	{
		method_160();
		Class3465.glLightModeli(pname, param);
		method_161();
	}

	public void method_57(uint pname, int[] parameters)
	{
		method_160();
		Class3465.glLightModeliv(pname, parameters);
		method_161();
	}

	public void method_58(uint light, uint pname, float param)
	{
		method_160();
		Class3465.glLightf(light, pname, param);
		method_161();
	}

	public void method_59(uint light, uint pname, float[] parameters)
	{
		method_160();
		Class3465.glLightfv(light, pname, parameters);
		method_161();
	}

	public void method_60(uint light, uint pname, int param)
	{
		method_160();
		Class3465.glLighti(light, pname, param);
		method_161();
	}

	public void method_61(uint light, uint pname, int[] parameters)
	{
		method_160();
		Class3465.glLightiv(light, pname, parameters);
		method_161();
	}

	public void method_62(float width)
	{
		method_160();
		Class3465.glLineWidth(width);
		method_161();
	}

	public void method_63()
	{
		method_160();
		Class3465.glLoadIdentity();
		method_161();
	}

	public void method_64(uint name)
	{
		method_160();
		Class3465.glLoadName(name);
		method_161();
	}

	public void method_65(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz)
	{
		method_160();
		Class3464.gluLookAt(eyex, eyey, eyez, centerx, centery, centerz, upx, upy, upz);
		method_161();
	}

	public void method_66(uint target, double u1, double u2, int stride, int order, double[] points)
	{
		method_160();
		Class3465.glMap1d(target, u1, u2, stride, order, points);
		method_161();
	}

	public void method_67(uint target, float u1, float u2, int stride, int order, float[] points)
	{
		method_160();
		Class3465.glMap1f(target, u1, u2, stride, order, points);
		method_161();
	}

	public void method_68(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double[] points)
	{
		method_160();
		Class3465.glMap2d(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
		method_161();
	}

	public void method_69(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float[] points)
	{
		method_160();
		Class3465.glMap2f(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
		method_161();
	}

	public void method_70(int un, double u1, double u2)
	{
		method_160();
		Class3465.glMapGrid1d(un, u1, u2);
		method_161();
	}

	public void method_71(int un, float u1, float u2)
	{
		method_160();
		Class3465.glMapGrid1d(un, u1, u2);
		method_161();
	}

	public void method_72(int un, double u1, double u2, int vn, double v1, double v2)
	{
		method_160();
		Class3465.glMapGrid2d(un, u1, u2, vn, v1, v2);
		method_161();
	}

	public void method_73(int un, float u1, float u2, int vn, float v1, float v2)
	{
		method_160();
		Class3465.glMapGrid2f(un, u1, u2, vn, v1, v2);
		method_161();
	}

	public void method_74(uint face, uint pname, float param)
	{
		method_160();
		Class3465.glMaterialf(face, pname, param);
		method_161();
	}

	public void method_75(uint face, uint pname, float[] parameters)
	{
		method_160();
		Class3465.glMaterialfv(face, pname, parameters);
		method_161();
	}

	public void method_76(uint face, uint pname, int param)
	{
		method_160();
		Class3465.glMateriali(face, pname, param);
		method_161();
	}

	public void method_77(uint face, uint pname, int[] parameters)
	{
		method_160();
		Class3465.glMaterialiv(face, pname, parameters);
		method_161();
	}

	public void method_78(uint mode)
	{
		method_160();
		Class3465.glMatrixMode(mode);
		method_161();
	}

	public void method_79(double[] m)
	{
		method_160();
		Class3465.glMultMatrixd(m);
		method_161();
	}

	public void method_80(uint list, uint mode)
	{
		method_160();
		Class3465.glNewList(list, mode);
		method_161();
	}

	public IntPtr method_81()
	{
		method_160();
		IntPtr result = Class3464.gluNewNurbsRenderer();
		method_161();
		return result;
	}

	public IntPtr method_82()
	{
		method_160();
		IntPtr result = Class3464.gluNewQuadric();
		method_161();
		return result;
	}

	public void method_83(float[] v)
	{
		method_160();
		Class3465.glNormal3fv(v);
		method_161();
	}

	public void method_84(uint type, int stride, float[] pointer)
	{
		method_160();
		Class3465.glNormalPointer(type, stride, pointer);
		method_161();
	}

	public void method_85(IntPtr nurbsObject, int knotsCount, float[] knots, int stride, float[] controlPointsArray, int order, uint type)
	{
		method_160();
		Class3464.gluNurbsCurve(nurbsObject, knotsCount, knots, stride, controlPointsArray, order, type);
		method_161();
	}

	public void method_86(IntPtr nurbsObject, int property, float value)
	{
		method_160();
		Class3464.gluNurbsProperty(nurbsObject, property, value);
		method_161();
	}

	public void method_87(IntPtr nurbsObject, int sknotsCount, float[] sknots, int tknotsCount, float[] tknots, int sStride, int tStride, float[] controlPointsArray, int sOrder, int tOrder, uint type)
	{
		method_160();
		Class3464.gluNurbsSurface(nurbsObject, sknotsCount, sknots, tknotsCount, tknots, sStride, tStride, controlPointsArray, sOrder, tOrder, type);
		method_161();
	}

	public void method_88(double left, double right, double bottom, double top, double zNear, double zFar)
	{
		method_160();
		Class3465.glOrtho(left, right, bottom, top, zNear, zFar);
		method_161();
	}

	public void method_89(double left, double right, double bottom, double top)
	{
		method_160();
		Class3464.gluOrtho2D(left, right, bottom, top);
		method_161();
	}

	public void method_90(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle)
	{
		method_160();
		Class3464.gluPartialDisk(qobj, innerRadius, outerRadius, slices, loops, startAngle, sweepAngle);
		method_161();
	}

	public void method_91(float token)
	{
	}

	public void method_92(double fovy, double aspect, double zNear, double zFar)
	{
		method_160();
		Class3464.gluPerspective(fovy, aspect, zNear, zFar);
		method_161();
	}

	public void method_93(double x, double y, double width, double height, int[] viewport)
	{
		method_160();
		Class3464.gluPickMatrix(x, y, width, height, viewport);
		method_161();
	}

	public void method_94(float size)
	{
		method_160();
		Class3465.glPointSize(size);
		method_161();
	}

	public void method_95(uint face, uint mode)
	{
		method_160();
		Class3465.glPolygonMode(face, mode);
		method_161();
	}

	public void method_96()
	{
		method_160();
		Class3465.glPopAttrib();
		method_161();
	}

	public void method_97()
	{
		method_160();
		Class3465.glPopMatrix();
		method_161();
	}

	public void method_98()
	{
		method_160();
		Class3465.glPopName();
		method_161();
	}

	public void method_99(double objx, double objy, double objz, double[] modelMatrix, double[] projMatrix, int[] viewport, double[] winx, double[] winy, double[] winz)
	{
		method_160();
		Class3464.gluProject(objx, objy, objz, modelMatrix, projMatrix, viewport, winx, winy, winz);
		method_161();
	}

	public void method_100(uint mask)
	{
		method_160();
		Class3465.glPushAttrib(mask);
		method_161();
	}

	public void method_101()
	{
		method_160();
		Class3465.glPushMatrix();
		method_161();
	}

	public void method_102(uint name)
	{
		method_160();
		Class3465.glPushName(name);
		method_161();
	}

	public void method_103(IntPtr quadricObject, int normals)
	{
		method_160();
		Class3464.gluQuadricNormals(quadricObject, normals);
		method_161();
	}

	public void method_104(IntPtr quadricObject, int textureCoords)
	{
		method_160();
		Class3464.gluQuadricTexture(quadricObject, textureCoords);
		method_161();
	}

	public void method_105(IntPtr quadricObject, int orientation)
	{
		method_160();
		Class3464.gluQuadricOrientation(quadricObject, orientation);
		method_161();
	}

	public void method_106(IntPtr quadObject, uint drawStyle)
	{
		method_160();
		Class3464.gluQuadricDrawStyle(quadObject, drawStyle);
		method_161();
	}

	public void method_107(int x, int y)
	{
		method_160();
		Class3465.glRasterPos2i(x, y);
		method_161();
	}

	public void method_108(double x1, double y1, double x2, double y2)
	{
		method_160();
		Class3465.glRectd(x1, y1, x2, y2);
		method_161();
	}

	public void method_109(double[] v1, double[] v2)
	{
		method_160();
		Class3465.glRectdv(v1, v2);
		method_161();
	}

	public void method_110(float x1, float y1, float x2, float y2)
	{
		method_160();
		Class3465.glRectd(x1, y1, x2, y2);
		method_161();
	}

	public void method_111(float[] v1, float[] v2)
	{
		method_160();
		Class3465.glRectfv(v1, v2);
		method_161();
	}

	public void method_112(int x1, int y1, int x2, int y2)
	{
		method_160();
		Class3465.glRecti(x1, y1, x2, y2);
		method_161();
	}

	public void method_113(int[] v1, int[] v2)
	{
		method_160();
		Class3465.glRectiv(v1, v2);
		method_161();
	}

	public void method_114(short x1, short y1, short x2, short y2)
	{
		method_160();
		Class3465.glRects(x1, y1, x2, y2);
		method_161();
	}

	public void method_115(short[] v1, short[] v2)
	{
		method_160();
		Class3465.glRectsv(v1, v2);
		method_161();
	}

	public int method_116(uint mode)
	{
		method_160();
		int result = Class3465.glRenderMode(mode);
		method_161();
		return result;
	}

	public void method_117(double angle, double x, double y, double z)
	{
		method_160();
		Class3465.glRotated(angle, x, y, z);
		method_161();
	}

	public void method_118(float angle, float x, float y, float z)
	{
		method_160();
		Class3465.glRotatef(angle, x, y, z);
		method_161();
	}

	public void method_119(double anglex, double angley, double anglez)
	{
		method_160();
		Class3465.glRotated(anglex, 1.0, 0.0, 0.0);
		Class3465.glRotated(angley, 0.0, 1.0, 0.0);
		Class3465.glRotated(anglez, 0.0, 0.0, 1.0);
		method_161();
	}

	public void method_120(double x, double y, double z)
	{
		method_160();
		Class3465.glScaled(x, y, z);
		method_161();
	}

	public void method_121(float x, float y, float z)
	{
		method_160();
		Class3465.glScalef(x, y, z);
		method_161();
	}

	public void method_122(int x, int y, int width, int height)
	{
	}

	public void method_123(int size, uint[] buffer)
	{
		method_160();
		Class3465.glSelectBuffer(size, buffer);
		method_161();
	}

	public void method_124(uint mode)
	{
		method_160();
		Class3465.glShadeModel(mode);
		method_161();
	}

	public void method_125(IntPtr qobj, double radius, int slices, int stacks)
	{
		method_160();
		Class3464.gluSphere(qobj, radius, slices, stacks);
		method_161();
	}

	public void method_126(uint func, int reference, uint mask)
	{
		method_160();
		Class3465.glStencilFunc(func, reference, mask);
		method_161();
	}

	public void method_127(uint mask)
	{
		method_160();
		Class3465.glStencilMask(mask);
		method_161();
	}

	public void method_128(uint fail, uint zfail, uint zpass)
	{
		method_160();
		Class3465.glStencilOp(fail, zfail, zpass);
		method_161();
	}

	public void method_129(double s)
	{
		method_160();
		Class3465.glTexCoord1d(s);
		method_161();
	}

	public void method_130(double[] v)
	{
		method_160();
		if (v.Length == 1)
		{
			Class3465.glTexCoord1dv(v);
		}
		else if (v.Length == 2)
		{
			Class3465.glTexCoord2dv(v);
		}
		else if (v.Length == 3)
		{
			Class3465.glTexCoord3dv(v);
		}
		else if (v.Length == 4)
		{
			Class3465.glTexCoord4dv(v);
		}
		method_161();
	}

	public void method_131(float s)
	{
		method_160();
		Class3465.glTexCoord1f(s);
		method_161();
	}

	public void method_132(float[] v)
	{
		method_160();
		if (v.Length == 1)
		{
			Class3465.glTexCoord1fv(v);
		}
		else if (v.Length == 2)
		{
			Class3465.glTexCoord2fv(v);
		}
		else if (v.Length == 3)
		{
			Class3465.glTexCoord3fv(v);
		}
		else if (v.Length == 4)
		{
			Class3465.glTexCoord4fv(v);
		}
		method_161();
	}

	public void method_133(float[] v)
	{
		method_160();
		Class3465.glTexCoord2fv(v);
		method_161();
	}

	public void method_134(int s)
	{
		method_160();
		Class3465.glTexCoord1i(s);
		method_161();
	}

	public void method_135(int[] v)
	{
		method_160();
		if (v.Length == 1)
		{
			Class3465.glTexCoord1iv(v);
		}
		else if (v.Length == 2)
		{
			Class3465.glTexCoord2iv(v);
		}
		else if (v.Length == 3)
		{
			Class3465.glTexCoord3iv(v);
		}
		else if (v.Length == 4)
		{
			Class3465.glTexCoord4iv(v);
		}
		method_161();
	}

	public void method_136(short s)
	{
		method_160();
		Class3465.glTexCoord1s(s);
		method_161();
	}

	public void method_137(short[] v)
	{
		method_160();
		if (v.Length == 1)
		{
			Class3465.glTexCoord1sv(v);
		}
		else if (v.Length == 2)
		{
			Class3465.glTexCoord2sv(v);
		}
		else if (v.Length == 3)
		{
			Class3465.glTexCoord3sv(v);
		}
		else if (v.Length == 4)
		{
			Class3465.glTexCoord4sv(v);
		}
		method_161();
	}

	public void method_138(double s, double t)
	{
		method_160();
		Class3465.glTexCoord2d(s, t);
		method_161();
	}

	public void method_139(float s, float t)
	{
		method_160();
		Class3465.glTexCoord2f(s, t);
		method_161();
	}

	public void method_140(int s, int t)
	{
		method_160();
		Class3465.glTexCoord2i(s, t);
		method_161();
	}

	public void method_141(short s, short t)
	{
		method_160();
		Class3465.glTexCoord2s(s, t);
		method_161();
	}

	public void method_142(int size, uint type, int stride, float[] pointer)
	{
		method_160();
		Class3465.glTexCoordPointer(size, type, stride, pointer);
		method_161();
	}

	public void method_143(uint target, int level, int internalformat, int width, int border, uint format, uint type, byte[] pixels)
	{
		method_160();
		Class3465.glTexImage1D(target, level, internalformat, width, border, format, type, pixels);
		method_161();
	}

	public void method_144(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, byte[] pixels)
	{
		method_160();
		Class3465.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
		method_161();
	}

	public void method_145(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels)
	{
		method_160();
		Class3465.glTexImage2D_1(target, level, internalformat, width, height, border, format, type, pixels);
		method_161();
	}

	public void method_146(uint target, uint pname, float param)
	{
		method_160();
		Class3465.glTexParameterf(target, pname, param);
		method_161();
	}

	public void method_147(uint target, uint pname, float[] parameters)
	{
		method_160();
		Class3465.glTexParameterfv(target, pname, parameters);
		method_161();
	}

	public void method_148(uint target, uint pname, int param)
	{
		method_160();
		Class3465.glTexParameteri(target, pname, param);
		method_161();
	}

	public void method_149(uint target, uint pname, int[] parameters)
	{
		method_160();
		Class3465.glTexParameteriv(target, pname, parameters);
		method_161();
	}

	public void method_150(double x, double y, double z)
	{
		method_160();
		Class3465.glTranslated(x, y, z);
		method_161();
	}

	public void method_151(float x, float y, float z)
	{
		method_160();
		Class3465.glTranslatef(x, y, z);
		method_161();
	}

	public void method_152(double winx, double winy, double winz, double[] modelMatrix, double[] projMatrix, int[] viewport, double[] objx, double[] objy, double[] objz)
	{
		method_160();
		Class3464.gluUnProject(winx, winy, winz, modelMatrix, projMatrix, viewport, objx, objy, objz);
		method_161();
	}

	public double[] method_153(double winx, double winy, double winz)
	{
		method_160();
		double[] array = new double[16];
		double[] array2 = new double[16];
		int[] array3 = new int[4];
		method_44(2982u, array);
		method_44(2983u, array2);
		method_47(2978u, array3);
		double[] array4 = new double[1];
		double[] array5 = new double[1];
		double[] array6 = new double[1];
		Class3464.gluUnProject(winx, winy, winz, array, array2, array3, array4, array5, array6);
		method_161();
		return new double[3]
		{
			array4[0],
			array5[0],
			array6[0]
		};
	}

	public void method_154(double x, double y)
	{
		method_160();
		Class3465.glVertex2d(x, y);
		method_161();
	}

	public void method_155(double x, double y, double z)
	{
		method_160();
		Class3465.glVertex3d(x, y, z);
		method_161();
	}

	public void method_156(float x, float y, float z)
	{
		method_160();
		Class3465.glVertex3f(x, y, z);
		method_161();
	}

	public void method_157(float[] v)
	{
		method_160();
		if (v.Length == 2)
		{
			Class3465.glVertex2fv(v);
		}
		else if (v.Length == 3)
		{
			Class3465.glVertex3fv(v);
		}
		else if (v.Length == 4)
		{
			Class3465.glVertex4fv(v);
		}
		method_161();
	}

	public void method_158(int size, uint type, int stride, float[] pointer)
	{
		method_160();
		Class3465.glVertexPointer(size, type, stride, pointer);
		method_161();
	}

	public void method_159(int x, int y, int width, int height)
	{
		method_160();
		Class3465.glViewport(x, y, width, height);
		method_161();
	}

	private void method_160()
	{
		if (!bool_0)
		{
			method_45();
		}
	}

	private void method_161()
	{
		if (!bool_0)
		{
			uint num = method_45();
			if (num != 0)
			{
				throw new Exception8(num);
			}
		}
	}
}

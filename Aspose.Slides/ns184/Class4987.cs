using System;
using System.Collections;
using ns224;
using ns271;

namespace ns184;

internal class Class4987 : Class4986
{
	private Class5999 class5999_0;

	private float float_0;

	private string string_0;

	public Class4987(Class5999 font, string name)
	{
		class5999_0 = font;
		float_0 = (float)class5999_0.TrueTypeFont.EmHeight / 1000f;
		string_0 = name;
	}

	public override string vmethod_0()
	{
		return null;
	}

	public override char vmethod_1(char c)
	{
		return class5999_0.TrueTypeFont.Glyphs.method_0(c).CharCode;
	}

	public override bool vmethod_2(char c)
	{
		return class5999_0.TrueTypeFont.Glyphs[c] != null;
	}

	public override string imethod_0()
	{
		return string_0;
	}

	public override string imethod_1()
	{
		return class5999_0.TrueTypeFont.FullFontName;
	}

	public override ArrayList imethod_2()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(class5999_0.TrueTypeFont.FamilyName);
		return arrayList;
	}

	public override string imethod_3()
	{
		return imethod_0();
	}

	public override Class5733 imethod_4()
	{
		throw new NotImplementedException();
	}

	public override int imethod_6(int size)
	{
		return (int)((float)(class5999_0.TrueTypeFont.Ascent * size) / float_0);
	}

	public override int imethod_7(int size)
	{
		return (int)((float)(class5999_0.TrueTypeFont.CapHeight * size) / float_0);
	}

	public override int imethod_8(int size)
	{
		return (int)((float)(-class5999_0.TrueTypeFont.Descent * size) / float_0);
	}

	public override int imethod_9(int size)
	{
		return (int)((float)(class5999_0.TrueTypeFont.Height * size) / float_0);
	}

	public override int imethod_10(int i, int size)
	{
		Class6734 @class = class5999_0.TrueTypeFont.Glyphs.method_0((char)i);
		float num = @class.AdvanceWidth * size;
		num /= float_0;
		return (int)num;
	}

	public override int[] imethod_11()
	{
		throw new NotImplementedException();
	}

	public override bool imethod_12()
	{
		return false;
	}

	public override Hashtable imethod_13()
	{
		throw new NotImplementedException();
	}
}

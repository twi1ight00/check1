using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Xml;
using ns291;
using ns292;
using ns293;
using ns299;

namespace ns298;

internal class Class6871
{
	private readonly PointF pointF_0 = new PointF(0f, 0f);

	private bool bool_0;

	private Class6869 class6869_0;

	private float float_0 = 12f;

	private bool bool_1;

	private SizeF sizeF_0 = SizeF.Empty;

	internal bool IgnoreWhiteSpace
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Encoding Encoding => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	public bool Indent
	{
		get
		{
			return class6869_0.InnerWriter.Formatting == Formatting.Indented;
		}
		set
		{
			class6869_0.InnerWriter.Formatting = (value ? Formatting.Indented : Formatting.None);
		}
	}

	internal float CurrentFontSize
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal bool IsFixedLyaout
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal SizeF CurrentSvgPageSize
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public Class6871(Class6869 writer)
	{
		class6869_0 = writer;
	}

	public void method_0(Class6869 writer)
	{
		class6869_0 = writer;
	}

	public Class6871 method_1(Enum931 tag)
	{
		class6869_0.method_6(tag);
		return this;
	}

	public Class6871 method_2(Enum931 tag, string ns)
	{
		class6869_0.method_8(tag, ns);
		return this;
	}

	public Class6871 method_3()
	{
		class6869_0.method_9();
		return this;
	}

	public Class6871 method_4()
	{
		class6869_0.method_10();
		return this;
	}

	public Class6871 method_5(Enum929 attribute, string value)
	{
		class6869_0.method_13(attribute, value);
		return this;
	}

	public Class6871 method_6()
	{
		class6869_0.method_14();
		return this;
	}

	public Class6871 method_7(Enum930 style, string value)
	{
		class6869_0.method_15(style, value);
		return this;
	}

	public Class6871 method_8()
	{
		class6869_0.method_16();
		return this;
	}

	internal string method_9(out bool alreadyExist)
	{
		return class6869_0.method_17(out alreadyExist);
	}

	internal string method_10(string key, out bool alreadyExist)
	{
		return class6869_0.method_18(key, out alreadyExist);
	}

	internal void method_11(string stylesId)
	{
		class6869_0.method_19(stylesId);
	}

	public Class6871 method_12(string key, Class6866 builder)
	{
		class6869_0.method_20(key, builder);
		return this;
	}

	public Class6871 Write(string value)
	{
		Write(value, replaceReturn: false, addWhiteSpaceToLineEnd: true);
		return this;
	}

	public Class6871 method_13()
	{
		class6869_0.InnerWriter.WriteRaw("&nbsp;");
		return this;
	}

	public Class6871 Write(string value, bool replaceReturn, bool addWhiteSpaceToLineEnd)
	{
		if (IgnoreWhiteSpace)
		{
			class6869_0.Write($"{value}", replaceReturn, addWhiteSpaceToLineEnd);
		}
		else
		{
			class6869_0.Write(value, replaceReturn, addWhiteSpaceToLineEnd);
		}
		return this;
	}

	public Class6871 method_14(string ns, bool addIeStylesSepartion)
	{
		if (addIeStylesSepartion)
		{
			class6869_0.method_7();
		}
		method_2(Enum931.const_5, ns);
		return this;
	}

	public Class6871 method_15()
	{
		method_1(Enum931.const_4);
		return this;
	}

	public Class6871 method_16(string title)
	{
		method_1(Enum931.const_14);
		class6869_0.Write(title);
		method_4();
		return this;
	}

	public Class6871 method_17()
	{
		method_1(Enum931.const_1);
		return this;
	}

	public Class6871 method_18()
	{
		method_1(Enum931.const_6);
		return this;
	}

	public Class6871 method_19()
	{
		method_1(Enum931.const_20);
		return this;
	}

	public Class6871 method_20()
	{
		method_1(Enum931.const_22);
		return this;
	}

	public Class6871 method_21()
	{
		method_1(Enum931.const_21);
		return this;
	}

	public Class6871 method_22()
	{
		method_1(Enum931.const_7);
		return this;
	}

	public Class6871 method_23()
	{
		method_1(Enum931.const_8);
		return this;
	}

	public Class6871 method_24()
	{
		method_1(Enum931.const_2);
		return this;
	}

	public Class6871 method_25()
	{
		method_1(Enum931.const_11);
		return this;
	}

	public Class6871 method_26(string href)
	{
		method_1(Enum931.const_0).method_5(Enum929.const_15, href);
		return this;
	}

	public Class6871 method_27()
	{
		method_1(Enum931.const_15);
		return this;
	}

	public Class6871 method_28()
	{
		method_1(Enum931.const_19);
		return this;
	}

	public Class6871 method_29()
	{
		method_1(Enum931.const_18);
		return this;
	}

	public Class6871 method_30(string path, SizeF size, string altText, PointF location, int? zIndex)
	{
		method_36(path, size, altText, location, zIndex);
		return this;
	}

	public Class6871 method_31(string path, SizeF size, float indentLeft, float indentTop)
	{
		method_1(Enum931.const_10).method_5(Enum929.const_29, path);
		method_37(size);
		method_6().method_7(Enum930.const_41, "relative").method_7(Enum930.const_22, "block").method_7(Enum930.const_29, method_47(indentLeft))
			.method_7(Enum930.const_31, method_47(indentTop))
			.method_8();
		return this;
	}

	public Class6871 method_32(byte[] data, Enum922 type, string altText, int? zIndex)
	{
		string source = $"data:{Class6792.smethod_0(type)};charset=utf-8;base64,{Convert.ToBase64String(data, Base64FormattingOptions.None)}";
		method_33(source, altText, zIndex);
		return this;
	}

	public Class6871 method_33(string source, string altText, int? zIndex)
	{
		method_1(Enum931.const_10).method_5(Enum929.const_29, source).method_5(Enum929.const_1, altText ?? string.Empty);
		method_38(pointF_0, zIndex);
		method_3();
		return this;
	}

	public Class6871 method_34(byte[] data, Enum922 type, SizeF size, string altText, PointF location, int? zIndex)
	{
		string source = $"data:{Class6792.smethod_0(type)};charset=utf-8;base64,{Convert.ToBase64String(data, Base64FormattingOptions.None)}";
		method_36(source, size, altText, location, zIndex);
		return this;
	}

	private void method_35(string source, SizeF size, string altText, PointF location)
	{
		method_36(source, size, altText, location, null);
	}

	private void method_36(string source, SizeF size, string altText, PointF location, int? zIndex)
	{
		method_1(Enum931.const_10).method_5(Enum929.const_29, source);
		method_37(size);
		method_5(Enum929.const_1, altText ?? string.Empty);
		method_38(location, zIndex);
		method_3();
	}

	internal void method_37(SizeF size)
	{
		method_5(Enum929.const_37, method_47(size.Width));
		method_5(Enum929.const_14, method_47(size.Height));
	}

	private void method_38(PointF location, int? zIndex)
	{
		method_6().method_7(Enum930.const_41, "absolute").method_7(Enum930.const_25, method_47(location.X)).method_7(Enum930.const_45, method_47(location.Y));
		if (zIndex.HasValue)
		{
			method_7(Enum930.const_48, zIndex.Value.ToString(CultureInfo.InvariantCulture));
		}
		method_8();
	}

	public Class6871 method_39(byte[] data, Enum921 options)
	{
		return method_40(data, pointF_0, options);
	}

	public Class6871 method_40(byte[] data, PointF location, Enum921 options)
	{
		string source = "data:image/svg+xml;charset=utf-8;base64," + Convert.ToBase64String(data, Base64FormattingOptions.None);
		method_42(source, location, options);
		return this;
	}

	public Class6871 method_41(string path, Enum921 options)
	{
		return Svg(path, pointF_0, options);
	}

	public Class6871 Svg(string path, PointF location, Enum921 options)
	{
		method_42(path, location, options);
		return this;
	}

	private void method_42(string source, PointF location, Enum921 options)
	{
		if (options == Enum921.const_0 || options == Enum921.const_1)
		{
			method_1(Enum931.const_26).method_5(Enum929.const_41, source).method_5(Enum929.const_34, "image/svg+xml");
			method_38(location, null);
			if (!sizeF_0.IsEmpty)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("position:absolute; ").AppendFormat("width:{0}em; ", (sizeF_0.Width / CurrentFontSize).ToString("0.####", Class6872.HtmlCulture)).AppendFormat("height:{0}em;", (sizeF_0.Height / CurrentFontSize).ToString("0.####", Class6872.HtmlCulture));
				method_5(Enum929.const_30, stringBuilder.ToString());
			}
		}
		if (options == Enum921.const_0 || options == Enum921.const_2)
		{
			method_1(Enum931.const_25).method_5(Enum929.const_29, source).method_5(Enum929.const_34, "image/svg+xml");
			method_38(location, null);
			method_3();
		}
		if (options == Enum921.const_0 || options == Enum921.const_1)
		{
			if (options == Enum921.const_1)
			{
				Write(" ");
			}
			method_3();
		}
	}

	public Class6871 method_43()
	{
		method_1(Enum931.const_16);
		return this;
	}

	public Class6871 method_44()
	{
		method_1(Enum931.const_17);
		return this;
	}

	public Class6871 method_45()
	{
		method_1(Enum931.const_23);
		return this;
	}

	public Class6871 method_46(string name, string pubid, string sysid, string subset)
	{
		class6869_0.InnerWriter.WriteDocType(name, pubid, sysid, subset);
		return this;
	}

	internal string method_47(float value)
	{
		if (!IsFixedLyaout)
		{
			return value.ToString("0.######", Class6872.HtmlCulture) + "pt";
		}
		return (value / float_0).ToString("0.######", Class6872.HtmlCulture) + "em";
	}
}

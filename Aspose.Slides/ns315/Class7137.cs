using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using ns224;
using ns234;

namespace ns315;

internal class Class7137
{
	private StringBuilder stringBuilder_0;

	private Stack<string> stack_0;

	private CultureInfo cultureInfo_0 = new CultureInfo("en-US");

	private bool IsLastCharWhiteSpace
	{
		get
		{
			if (stringBuilder_0.Length == 0)
			{
				return false;
			}
			return char.IsWhiteSpace(stringBuilder_0[stringBuilder_0.Length - 1]);
		}
	}

	public string Content => stringBuilder_0.ToString();

	public Class7137(StringBuilder builder)
	{
		stringBuilder_0 = builder;
		stack_0 = new Stack<string>();
	}

	public Class7137(string value)
		: this(new StringBuilder(value))
	{
	}

	public Class7137()
		: this(new StringBuilder())
	{
	}

	public Class7137 Write(string value)
	{
		stringBuilder_0.Append(value);
		return this;
	}

	public Class7137 Write(string format, params object[] args)
	{
		stringBuilder_0.AppendFormat(cultureInfo_0, format, args);
		return this;
	}

	public Class7137 Write(float value)
	{
		stringBuilder_0.Append(value.ToString(cultureInfo_0));
		return this;
	}

	public Class7137 method_0(string value)
	{
		Write(value.Replace("&", "&amp;"));
		return this;
	}

	public Class7137 method_1()
	{
		Write("\n");
		return this;
	}

	public Class7137 method_2(int level)
	{
		for (int i = 0; i < level; i++)
		{
			Write("\t");
		}
		return this;
	}

	public Class7137 method_3()
	{
		Write(" ");
		return this;
	}

	public Class7137 method_4(bool checkPreviousChar)
	{
		if (checkPreviousChar)
		{
			if (!IsLastCharWhiteSpace)
			{
				method_3();
			}
		}
		else
		{
			method_3();
		}
		return this;
	}

	public Class7137 method_5(string name, float value)
	{
		method_4(checkPreviousChar: true);
		Write("{0}=\"{1}\"", name, value);
		return this;
	}

	public Class7137 method_6(Class6002 matrix)
	{
		method_4(checkPreviousChar: true);
		Write("transform=\"matrix({0} {1} {2} {3} {4} {5})\"", matrix.M11, matrix.M12, matrix.M21, matrix.M22, matrix.M31, matrix.M32);
		return this;
	}

	public Class7137 Write(Class5998 color)
	{
		Write("#{0}{1}{2}", Class6159.smethod_33(color.R), Class6159.smethod_33(color.G), Class6159.smethod_33(color.B));
		return this;
	}

	public Class7137 method_7()
	{
		Write(">");
		return this;
	}

	public Class7137 method_8()
	{
		method_10();
		return this;
	}

	private void method_9(string nodeName)
	{
		stack_0.Push(nodeName);
		Write("<{0}", nodeName);
	}

	private void method_10()
	{
		string text = stack_0.Peek();
		Write("</{0}>", text);
	}

	public Class7137 method_11()
	{
		method_9("g");
		return this;
	}

	public Class7137 method_12()
	{
		method_9("text");
		return this;
	}

	public Class7136 method_13()
	{
		return new Class7136(this).method_0();
	}

	public Class7137 method_14(PointF point)
	{
		Write("M{0} {1}", point.X, point.Y);
		return this;
	}

	public Class7137 method_15(PointF point)
	{
		Write("L{0} {1}", point.X, point.Y);
		return this;
	}

	public Class7137 method_16(PointF startPoint, PointF controlPoint1, PointF controlPoint2, PointF endPoint, bool continues)
	{
		if (!continues)
		{
			method_14(startPoint);
		}
		Write("C {0} {1} {2} {3} {4} {5}", controlPoint1.X, controlPoint1.Y, controlPoint2.X, controlPoint2.Y, endPoint.X, endPoint.Y);
		return this;
	}

	public override string ToString()
	{
		return Content;
	}
}

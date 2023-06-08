using System.Globalization;
using System.Text.RegularExpressions;

namespace ns28;

internal class Class487
{
	protected string string_0;

	protected double double_0;

	protected double double_1;

	protected double double_2;

	protected double double_3;

	protected double double_4;

	protected double double_5;

	protected double double_6;

	protected double double_7;

	protected double double_8;

	protected double double_9;

	protected double double_10;

	protected double double_11;

	protected double double_12;

	internal double MatrixA
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	internal double MatrixB
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	internal double MatrixC
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	internal double MatrixD
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	internal double MatrixE
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	internal double MatrixF
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	internal double Rotate
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	internal double ScaleX
	{
		get
		{
			return double_7;
		}
		set
		{
			double_7 = value;
		}
	}

	internal double ScaleY
	{
		get
		{
			return double_8;
		}
		set
		{
			double_8 = value;
		}
	}

	internal double SkewX
	{
		get
		{
			return double_9;
		}
		set
		{
			double_9 = value;
		}
	}

	internal double SkewY
	{
		get
		{
			return double_10;
		}
		set
		{
			double_10 = value;
		}
	}

	internal double TranslateX
	{
		get
		{
			return double_11;
		}
		set
		{
			double_11 = value;
		}
	}

	internal double TranslateY
	{
		get
		{
			return double_12;
		}
		set
		{
			double_12 = value;
		}
	}

	internal Class487()
	{
	}

	internal Class487(Class369 source, string AttributeName, string NameSpace)
	{
		if (source != null)
		{
			method_0(source, AttributeName, NameSpace);
		}
	}

	internal void method_0(Class369 source, string AttributeName, string NameSpace)
	{
		if (source != null)
		{
			string_0 = source.method_0(AttributeName, NameSpace, "matrix(0 0 0 0 0 0),translate(0),scale(0),rotate(0),skewX(0),skewY(0)");
		}
		else
		{
			string_0 = "matrix(0 0 0 0 0 0),translate(0),scale(0),rotate(0),skewX(0),skewY(0)";
		}
		if (string_0.IndexOf("matrix") > -1)
		{
			string[] array = method_1(string_0, "matrix");
			double_0 = double.Parse(array[0], CultureInfo.InvariantCulture);
			double_1 = double.Parse(array[1], CultureInfo.InvariantCulture);
			double_2 = double.Parse(array[2], CultureInfo.InvariantCulture);
			double_3 = double.Parse(array[3], CultureInfo.InvariantCulture);
			double_4 = double.Parse(array[4], CultureInfo.InvariantCulture);
			double_5 = double.Parse(array[5], CultureInfo.InvariantCulture);
		}
		if (string_0.IndexOf("scale") > -1)
		{
			string[] array2 = method_1(string_0, "scale");
			double_7 = double.Parse(array2[0].Replace('.', ','));
			double_8 = ((array2.Length == 2) ? double.Parse(array2[1], CultureInfo.InvariantCulture) : double_7);
		}
		if (string_0.IndexOf("rotate") > -1)
		{
			string[] array3 = method_1(string_0, "rotate");
			double_6 = double.Parse(array3[0], CultureInfo.InvariantCulture);
		}
		if (string_0.IndexOf("skewX") > -1)
		{
			string[] array4 = method_1(string_0, "skewX");
			double_9 = double.Parse(array4[0], CultureInfo.InvariantCulture);
		}
		if (string_0.IndexOf("translate") > -1)
		{
			string[] array5 = method_1(string_0, "translate");
			double_11 = source.method_34(array5[0]);
			double_12 = ((array5.Length == 2) ? source.method_34(array5[1]) : 0.0);
		}
		if (string_0.IndexOf("skewY") > -1)
		{
			string[] array6 = method_1(string_0, "skewY");
			double_10 = double.Parse(array6[0], CultureInfo.InvariantCulture);
		}
	}

	internal void Write(Class369 target, string AttributeName, string NameSpace)
	{
		string text = "";
		if (!double.IsNaN(double_0) && !double.IsNaN(double_1) && !double.IsNaN(double_2) && !double.IsNaN(double_3) && !double.IsNaN(double_4) && !double.IsNaN(double_5))
		{
			text += $"matrix({double_0.ToString(CultureInfo.InvariantCulture)} {double_1.ToString(CultureInfo.InvariantCulture)} {double_2.ToString(CultureInfo.InvariantCulture)} {double_3.ToString(CultureInfo.InvariantCulture)} {double_4.ToString(CultureInfo.InvariantCulture)} {double_5.ToString(CultureInfo.InvariantCulture)})";
		}
		if (!double.IsNaN(double_11))
		{
			text = text + " " + string.Format("translate({0}{2} {1}{2})", double_11.ToString(CultureInfo.InvariantCulture), double.IsNaN(double_12) ? "0" : double_12.ToString(CultureInfo.InvariantCulture), "cm");
		}
		if (!double.IsNaN(double_7))
		{
			text = text + " " + $"scale({double_7.ToString(CultureInfo.InvariantCulture)} {(double.IsNaN(double_8) ? double_7.ToString(CultureInfo.InvariantCulture) : double_8.ToString(CultureInfo.InvariantCulture))})";
		}
		if (!double.IsNaN(double_6))
		{
			text = text + " " + string.Format("rotate({0}{1})", double_6.ToString(CultureInfo.InvariantCulture), "deg");
		}
		if (!double.IsNaN(double_9))
		{
			text = text + " " + string.Format("skewX({0}{1})", double_9.ToString(CultureInfo.InvariantCulture), "deg");
		}
		if (!double.IsNaN(double_10))
		{
			text = text + " " + string.Format("skewY({0}{1})", double_10.ToString(CultureInfo.InvariantCulture), "deg");
		}
		if (text.IndexOf(' ') == 0)
		{
			text.Remove(1, 1);
		}
		target.SetAttribute(AttributeName, NameSpace, text);
	}

	private string[] method_1(string value, string name)
	{
		Regex regex = new Regex("\\b" + name + "\\s*\\([^\\(\\)]*\\)");
		Match match = regex.Match(value);
		string value2 = match.Value;
		MatchCollection matchCollection = Regex.Matches(value2, "[+-]?(\\d*\\.)?\\d+([eE][+-]?\\d+)?(cm|mm|in|pt)?");
		string[] array = new string[matchCollection.Count];
		for (int i = 0; i < matchCollection.Count; i++)
		{
			array[i] = matchCollection[i].Value;
		}
		return array;
	}
}

using System.Drawing;

namespace ns235;

internal abstract class Class6205 : Class6204
{
	private const bool bool_0 = true;

	internal const float float_0 = 1.75f;

	private string string_1;

	private PointF pointF_0 = PointF.Empty;

	private bool bool_1 = true;

	private string string_2 = string.Empty;

	private Class6213 class6213_0;

	private bool bool_2;

	public PointF Origin
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public abstract RectangleF BoundingBox { get; }

	public string Name => string_1;

	public bool IsEnabled
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

	internal bool UseCustomDraw
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public string Action
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public Class6213 CustomDraw
	{
		get
		{
			return class6213_0;
		}
		set
		{
			class6213_0 = value;
			bool_2 = class6213_0 != null;
		}
	}

	protected Class6205(PointF origin, string name)
	{
		pointF_0 = origin;
		string_1 = name;
	}

	protected Class6205()
	{
	}

	internal void method_0(string name)
	{
		string_1 = name;
	}
}

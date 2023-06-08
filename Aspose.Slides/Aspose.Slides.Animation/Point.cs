using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("9FA02C54-AF92-4AAF-8E6D-7EE9DA10B48E")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class Point : IPoint
{
	private float float_0 = float.NaN;

	private object object_0;

	private string string_0 = "";

	public float Time
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

	public object Value
	{
		get
		{
			return object_0;
		}
		set
		{
			method_0(value);
			object_0 = value;
		}
	}

	public string Formula
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Point()
	{
	}

	public Point(float time, object value, string formula)
	{
		float_0 = time;
		object_0 = value;
		string_0 = formula;
	}

	internal bool method_0(object val)
	{
		if (!(val.GetType() == typeof(bool)) && !(val.GetType() == typeof(ColorFormat)) && !(val.GetType() == typeof(float)) && !(val.GetType() == typeof(int)) && !(val.GetType() == typeof(string)))
		{
			throw new PptxException("Animation.Point, invalid property value type");
		}
		return true;
	}
}

namespace Aspose.Slides;

public sealed class FieldType : IFieldType
{
	private string string_0;

	private static FieldType fieldType_0 = new FieldType("slidenum");

	private static FieldType fieldType_1 = new FieldType("footer");

	private static FieldType fieldType_2 = new FieldType("datetime");

	private static FieldType fieldType_3 = new FieldType("datetime1");

	private static FieldType fieldType_4 = new FieldType("datetime2");

	private static FieldType fieldType_5 = new FieldType("datetime3");

	private static FieldType fieldType_6 = new FieldType("datetime4");

	private static FieldType fieldType_7 = new FieldType("datetime5");

	private static FieldType fieldType_8 = new FieldType("datetime6");

	private static FieldType fieldType_9 = new FieldType("datetime7");

	private static FieldType fieldType_10 = new FieldType("datetime8");

	private static FieldType fieldType_11 = new FieldType("datetime9");

	private static FieldType fieldType_12 = new FieldType("datetime10");

	private static FieldType fieldType_13 = new FieldType("datetime11");

	private static FieldType fieldType_14 = new FieldType("datetime12");

	private static FieldType fieldType_15 = new FieldType("datetime13");

	public string InternalString
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

	public static FieldType SlideNumber => fieldType_0;

	public static FieldType Footer => fieldType_1;

	public static FieldType DateTime => fieldType_2;

	public static FieldType DateTime1 => fieldType_3;

	public static FieldType DateTime2 => fieldType_4;

	public static FieldType DateTime3 => fieldType_5;

	public static FieldType DateTime4 => fieldType_6;

	public static FieldType DateTime5 => fieldType_7;

	public static FieldType DateTime6 => fieldType_8;

	public static FieldType DateTime7 => fieldType_9;

	public static FieldType DateTime8 => fieldType_10;

	public static FieldType DateTime9 => fieldType_11;

	public static FieldType DateTime10 => fieldType_12;

	public static FieldType DateTime11 => fieldType_13;

	public static FieldType DateTime12 => fieldType_14;

	public static FieldType DateTime13 => fieldType_15;

	public FieldType(string str)
	{
		string_0 = str;
	}

	public override bool Equals(object obj)
	{
		if (obj != null && obj is FieldType)
		{
			return string_0 == ((FieldType)obj).string_0;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return string_0.GetHashCode();
	}

	public static bool operator ==(FieldType a, FieldType b)
	{
		if (object.ReferenceEquals(a, null))
		{
			return object.ReferenceEquals(b, null);
		}
		return a.Equals(b);
	}

	public static bool operator !=(FieldType a, FieldType b)
	{
		if (object.ReferenceEquals(a, null))
		{
			return !object.ReferenceEquals(b, null);
		}
		return !a.Equals(b);
	}
}

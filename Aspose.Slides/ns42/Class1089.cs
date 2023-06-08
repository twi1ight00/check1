using Aspose.Slides;

namespace ns42;

internal class Class1089
{
	private string string_0;

	private string string_1;

	private string string_2;

	private NullableBool nullableBool_0;

	private bool bool_0;

	public string Target
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

	public string ShortType
	{
		get
		{
			string text = string_1;
			int num = text.LastIndexOf('/');
			if (num < 0)
			{
				return text;
			}
			return text.Substring(num + 1, text.Length - num - 1);
		}
	}

	public string Id => string_0;

	public string Type => string_1;

	public NullableBool External
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
		}
	}

	public bool Used
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

	public Class1089(string relId, string relType, string relTarget, NullableBool external)
	{
		string_0 = relId;
		string_1 = relType;
		string_2 = relTarget;
		nullableBool_0 = external;
		bool_0 = true;
	}

	public Class1089(Class1089 rel)
	{
		string_0 = rel.string_0;
		string_1 = rel.string_1;
		string_2 = rel.string_2;
		nullableBool_0 = rel.nullableBool_0;
		bool_0 = rel.bool_0;
	}
}

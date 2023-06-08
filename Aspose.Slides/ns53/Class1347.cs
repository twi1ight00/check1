namespace ns53;

internal class Class1347
{
	private string string_0;

	private string string_1;

	private string string_2;

	private Enum180 enum180_0;

	private Class1183 class1183_0;

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

	public Class1342 TargetPart
	{
		get
		{
			method_0();
			return TargetPartInternal;
		}
	}

	internal Class1342 TargetPartInternal
	{
		get
		{
			if (enum180_0 != Enum180.const_2)
			{
				return class1183_0.method_3(string_2);
			}
			return null;
		}
	}

	internal string ShortType
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

	public Enum180 TargetMode
	{
		get
		{
			return enum180_0;
		}
		set
		{
			enum180_0 = value;
		}
	}

	public Class1183 ParentPackage => class1183_0;

	public bool Used => bool_0;

	public void method_0()
	{
		bool_0 = true;
	}

	public Class1347(Class1183 parentPackage, string relId, string relType, string relTarget, Enum180 targetMode)
	{
		class1183_0 = parentPackage;
		string_0 = relId;
		string_1 = relType;
		string_2 = relTarget;
		enum180_0 = targetMode;
	}

	public Class1347(Class1184 parentPackage, Class1347 rel)
	{
		class1183_0 = parentPackage;
		string_0 = rel.string_0;
		string_1 = rel.string_1;
		string_2 = rel.string_2;
		enum180_0 = rel.enum180_0;
	}

	public override string ToString()
	{
		return "used==" + bool_0 + "; relId==" + string_0 + "; target==" + string_2;
	}
}

using ns36;

namespace ns37;

internal class Class743 : Interface8
{
	private object object_0;

	private bool bool_0;

	private string string_0;

	private Class742 class742_0;

	private Class743 class743_0;

	private bool bool_1;

	private bool bool_2;

	public object LabelValue
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public bool IsCulture
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

	public string SourceFormat
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

	public Interface7 Children => class742_0;

	public Interface8 Parent => class743_0;

	public bool IsDate
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

	public bool IsNull
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

	internal Class743(Class743 parent, object labelValue)
	{
		class743_0 = parent;
		object_0 = labelValue;
		class742_0 = new Class742(this);
		bool_0 = true;
		string_0 = "";
		IsDate = false;
		IsNull = false;
	}

	internal Class743 Clone()
	{
		Class743 @class = new Class743(class743_0, LabelValue);
		@class.IsCulture = IsCulture;
		@class.SourceFormat = SourceFormat;
		@class.IsDate = IsDate;
		return @class;
	}
}

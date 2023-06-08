namespace ns63;

internal class Class2729 : Class2727
{
	public static readonly string string_0 = "AS_UNIQUEID";

	public Class2679 PP9ShapeBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT9");
			if (@class != null)
			{
				return (Class2679)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2678 PP10ShapeBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT10");
			if (@class != null)
			{
				return (Class2678)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2677 PP11ShapeBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT11");
			if (@class != null)
			{
				return (Class2677)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2679 method_8()
	{
		Class2722 @class = method_6("___PPT9");
		if (@class == null)
		{
			@class = new Class2724();
			Class2843 class2 = new Class2843("___PPT9", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2679 class3 = new Class2679();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2679)@class.BinaryTagExtension;
	}

	public Class2678 method_9()
	{
		Class2722 @class = method_6("___PPT10");
		if (@class == null)
		{
			@class = new Class2724();
			Class2843 class2 = new Class2843("___PPT10", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2678 class3 = new Class2678();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2678)@class.BinaryTagExtension;
	}

	public Class2677 method_10()
	{
		Class2722 @class = method_6("___PPT11");
		if (@class == null)
		{
			@class = new Class2724();
			Class2843 class2 = new Class2843("___PPT11", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2677 class3 = new Class2677();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2677)@class.BinaryTagExtension;
	}
}

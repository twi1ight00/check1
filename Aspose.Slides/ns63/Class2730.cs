namespace ns63;

internal class Class2730 : Class2727
{
	public Class2683 PP9DocBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT9");
			if (@class != null)
			{
				return (Class2683)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2682 PP10DocBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT10");
			if (@class != null)
			{
				return (Class2682)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2680 PP11DocBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT11");
			if (@class != null)
			{
				return (Class2680)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2681 PP12DocBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT12");
			if (@class != null)
			{
				return (Class2681)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2683 method_8()
	{
		Class2722 @class = method_6("___PPT9");
		if (@class == null)
		{
			@class = new Class2725();
			Class2843 class2 = new Class2843("___PPT9", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2683 class3 = new Class2683();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2683)@class.BinaryTagExtension;
	}

	public Class2682 method_9()
	{
		Class2722 @class = method_6("___PPT10");
		if (@class == null)
		{
			@class = new Class2725();
			Class2843 class2 = new Class2843("___PPT10", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2682 class3 = new Class2682();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2682)@class.BinaryTagExtension;
	}

	public Class2680 method_10()
	{
		Class2722 @class = method_6("___PPT11");
		if (@class == null)
		{
			@class = new Class2725();
			Class2843 class2 = new Class2843("___PPT11", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2680 class3 = new Class2680();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2680)@class.BinaryTagExtension;
	}

	public Class2681 method_11()
	{
		Class2722 @class = method_6("___PPT12");
		if (@class == null)
		{
			@class = new Class2725();
			Class2843 class2 = new Class2843("___PPT12", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2681 class3 = new Class2681();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2681)@class.BinaryTagExtension;
	}
}

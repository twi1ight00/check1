namespace ns63;

internal class Class2728 : Class2727
{
	public Class2676 PP9SlideBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT9");
			if (@class != null)
			{
				return (Class2676)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2675 PP10SlideBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT10");
			if (@class != null)
			{
				return (Class2675)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2674 PP12SlideBinaryTagExtension
	{
		get
		{
			Class2722 @class = method_6("___PPT12");
			if (@class != null)
			{
				return (Class2674)@class.BinaryTagExtension;
			}
			return null;
		}
	}

	public Class2676 method_8()
	{
		Class2722 @class = method_6("___PPT9");
		if (@class == null)
		{
			@class = new Class2723();
			Class2843 class2 = new Class2843("___PPT9", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2676 class3 = new Class2676();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2676)@class.BinaryTagExtension;
	}

	public Class2675 method_9()
	{
		Class2722 @class = method_6("___PPT10");
		if (@class == null)
		{
			@class = new Class2723();
			Class2843 class2 = new Class2843("___PPT10", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2675 class3 = new Class2675();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2675)@class.BinaryTagExtension;
	}

	public Class2674 method_10()
	{
		Class2722 @class = method_6("___PPT12");
		if (@class == null)
		{
			@class = new Class2723();
			Class2843 class2 = new Class2843("___PPT12", 0);
			class2.ParentRecord = @class;
			@class.Records.Add(class2);
			Class2674 class3 = new Class2674();
			class3.ParentRecord = @class;
			@class.Records.Add(class3);
			@class.ParentRecord = this;
			base.Records.Add(@class);
			return class3;
		}
		return (Class2674)@class.BinaryTagExtension;
	}
}

using System;

namespace ns67;

internal sealed class Class3343 : ICloneable
{
	private Struct162 struct162_0;

	private Struct163 struct163_0;

	private Struct163 struct163_1;

	public Struct162 Anchor
	{
		get
		{
			return struct162_0;
		}
		set
		{
			struct162_0 = value;
		}
	}

	public Struct163 Normal
	{
		get
		{
			return struct163_0;
		}
		set
		{
			struct163_0 = value;
		}
	}

	public Struct163 Up
	{
		get
		{
			return struct163_1;
		}
		set
		{
			struct163_1 = value;
		}
	}

	public Class3343()
	{
		struct162_0 = new Struct162(0.0, 0.0, 0.0);
		struct163_0 = new Struct163(0.0, 0.0, 1.0);
		struct163_1 = new Struct163(0.0, 1.0, 0.0);
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3343 method_0()
	{
		Class3343 @class = new Class3343();
		@class.struct162_0 = struct162_0;
		@class.struct163_0 = struct163_0;
		@class.struct163_1 = struct163_1;
		return @class;
	}
}

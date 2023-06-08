using System;

namespace ns67;

internal sealed class Class3434 : ICloneable
{
	private Class3331 class3331_0 = new Class3339(Class3453.smethod_1(79, 129, 189));

	private Class3331 class3331_1 = new Class3339(Class3453.smethod_1(56, 93, 138));

	private Class3441 class3441_0 = new Class3441();

	private bool bool_0;

	private int int_0;

	private Class3326 class3326_0;

	private Class3374 class3374_0;

	private Class3372 class3372_0;

	public Class3331 ShapeFillMode
	{
		get
		{
			return class3331_0;
		}
		set
		{
			if (class3331_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3331_0 = value.vmethod_0();
			}
		}
	}

	public Class3331 LineFillMode
	{
		get
		{
			return class3331_1;
		}
		set
		{
			if (class3331_1 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3331_1 = value.vmethod_0();
			}
		}
	}

	public Class3441 LineStyle
	{
		get
		{
			return class3441_0;
		}
		set
		{
			if (class3441_0 != value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				class3441_0 = value.method_0();
			}
		}
	}

	public bool KeepTextFlat
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

	public int FlatTextZ
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Class3326 EffectProperties
	{
		get
		{
			return class3326_0;
		}
		set
		{
			if (class3326_0 != value)
			{
				class3326_0 = value?.vmethod_0();
			}
		}
	}

	public Class3374 Shape3DType
	{
		get
		{
			return class3374_0;
		}
		set
		{
			if (class3374_0 != value)
			{
				class3374_0 = value?.method_0();
			}
		}
	}

	public Class3372 Scene3D
	{
		get
		{
			return class3372_0;
		}
		set
		{
			if (value != class3372_0)
			{
				class3372_0 = value?.method_0();
			}
		}
	}

	public Class3434()
	{
		class3331_0 = new Class3339();
		class3331_1 = new Class3339();
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3434 method_0()
	{
		Class3434 @class = new Class3434();
		@class.ShapeFillMode = class3331_0;
		@class.LineFillMode = class3331_1;
		@class.LineStyle = class3441_0;
		@class.Scene3D = class3372_0;
		@class.KeepTextFlat = bool_0;
		@class.FlatTextZ = int_0;
		@class.Shape3DType = class3374_0;
		@class.EffectProperties = class3326_0;
		return @class;
	}

	internal void method_1(Class3434 parent)
	{
		throw new NotImplementedException();
	}

	internal void method_2(Enum492 fillMode)
	{
		switch (fillMode)
		{
		case Enum492.const_5:
			class3331_0 = new Class3336();
			return;
		case Enum492.const_0:
			if (class3331_0 == null)
			{
				class3331_0 = new Class3339();
			}
			return;
		}
		if (class3331_0 == null)
		{
			class3331_0 = new Class3339();
		}
		class3331_0.vmethod_1(fillMode);
	}
}

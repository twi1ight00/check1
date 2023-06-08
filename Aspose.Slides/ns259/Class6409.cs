using System;
using System.Collections.Generic;
using ns224;
using ns235;
using ns249;
using ns251;
using ns252;

namespace ns259;

internal class Class6409
{
	private Enum807 enum807_0;

	private double double_0 = -1.0;

	private List<Interface295> list_0 = new List<Interface295>();

	private bool bool_0 = true;

	private double double_1 = -1.0;

	public List<Interface295> PathParts => list_0;

	public double Width
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double Height
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public bool Stroke
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

	public Enum807 FillMode
	{
		get
		{
			return enum807_0;
		}
		set
		{
			enum807_0 = value;
		}
	}

	internal void method_0(Class6217 path, Interface296 context)
	{
		if (FillMode != Enum807.const_4)
		{
			vmethod_0(context, path);
		}
	}

	internal void method_1(Interface295 dmlPathPart)
	{
		if (dmlPathPart != null)
		{
			list_0.Add(dmlPathPart);
		}
	}

	internal Class6217 method_2(Interface296 drawingContext)
	{
		if (!Stroke && FillMode == Enum807.const_4)
		{
			return null;
		}
		try
		{
			Class6217 @class = new Class6217();
			vmethod_0(drawingContext, @class);
			if (Stroke)
			{
				@class.Pen = drawingContext.imethod_3();
			}
			@class.Brush = method_4(drawingContext, @class);
			return @class;
		}
		catch (Exception)
		{
			return null;
		}
	}

	protected virtual void vmethod_0(Interface296 drawingContext, Class6217 path)
	{
		drawingContext.imethod_2(Width, Height);
		Class6218 @class = null;
		foreach (Interface295 pathPart in PathParts)
		{
			if (@class == null)
			{
				@class = new Class6218();
			}
			pathPart.imethod_0(drawingContext, @class);
			bool flag = false;
			if (pathPart is Class6405)
			{
				flag = true;
			}
			if (pathPart is Class6408 && @class.Count > 0)
			{
				flag = true;
			}
			if (flag)
			{
				smethod_0(path, @class);
				@class = null;
			}
		}
		if (@class != null)
		{
			smethod_0(path, @class);
		}
	}

	private Interface275 method_3()
	{
		switch (FillMode)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum807.const_0:
			return new Class6313(Class6329.smethod_0(0.6));
		case Enum807.const_1:
			return new Class6313(Class6329.smethod_0(0.8));
		case Enum807.const_2:
			return new Class6314(Class6329.smethod_0(0.6));
		case Enum807.const_3:
			return new Class6314(Class6329.smethod_0(0.8));
		case Enum807.const_4:
		case Enum807.const_5:
			return null;
		}
	}

	private Class5990 method_4(Interface296 drawingContext, Class6217 path)
	{
		if (FillMode == Enum807.const_4)
		{
			return null;
		}
		Interface275 modifier = method_3();
		return drawingContext.imethod_4(modifier, path);
	}

	private static void smethod_0(Class6217 path, Class6218 figure)
	{
		if (figure.Count > 0)
		{
			path.Add(figure);
		}
	}
}

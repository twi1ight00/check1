using System.Collections.Generic;
using ns284;
using ns305;

namespace ns287;

internal class Class7011 : Class6983
{
	public string Cols
	{
		get
		{
			return method_45("cols", string.Empty);
		}
		set
		{
			method_21("cols", value);
		}
	}

	public string Rows
	{
		get
		{
			return method_45("rows", string.Empty);
		}
		set
		{
			method_21("rows", value);
		}
	}

	internal IList<Class7010> Frames
	{
		get
		{
			IList<Class7010> list = new List<Class7010>();
			foreach (Class7010 item in method_26("FRAME"))
			{
				list.Add(item);
			}
			return list;
		}
	}

	internal IList<Class7011> Framesets
	{
		get
		{
			IList<Class7011> list = new List<Class7011>();
			foreach (Class7011 item in method_26("FRAMESET"))
			{
				list.Add(item);
			}
			return list;
		}
	}

	internal IList<Class6983> Noframes
	{
		get
		{
			IList<Class6983> list = new List<Class6983>();
			foreach (Class7011 item in method_26("NOFRAMESET"))
			{
				list.Add(item);
			}
			return list;
		}
	}

	protected internal Class7011(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_56(this);
		method_48(visitor);
		visitor.imethod_57(this);
	}
}

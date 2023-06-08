using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns310;

internal class Class7123
{
	internal class Class7125
	{
		internal readonly Class7123 class7123_0;

		internal readonly Class7123 class7123_1;

		public virtual Class7123 Top => class7123_0;

		public virtual Class7123 Bottom => class7123_1;

		public Class7125(Class7123 top, Class7123 bottom)
		{
			if (top != null && top.vmethod_3() > 0)
			{
				class7123_0 = top;
			}
			else
			{
				class7123_0 = null;
			}
			if (bottom != null && bottom.vmethod_3() > 0)
			{
				class7123_1 = bottom;
			}
			else
			{
				class7123_1 = null;
			}
		}
	}

	internal Hashtable hashtable_0 = new Hashtable();

	public virtual RectangleF Bounds
	{
		get
		{
			IEnumerator enumerator = vmethod_2();
			if (!enumerator.MoveNext())
			{
				return default(RectangleF);
			}
			RectangleF result = default(RectangleF);
			while (enumerator.MoveNext())
			{
				_ = (Class7120)enumerator.Current;
				default(RectangleF).Inflate(result.Width, result.Height);
			}
			return result;
		}
	}

	public Class7123()
	{
	}

	public Class7123(GraphicsPath segment)
	{
		hashtable_0.Add(hashtable_0.Count, segment);
	}

	public virtual void vmethod_0(Interface378 segment)
	{
		hashtable_0.Add(hashtable_0.Count, segment);
	}

	public virtual Class7125 vmethod_1(float part)
	{
		IEnumerator enumerator = hashtable_0.GetEnumerator();
		Class7123 @class = new Class7123();
		Class7123 class2 = new Class7123();
		while (enumerator.MoveNext())
		{
			Interface378 @interface = (Interface378)((DictionaryEntry)enumerator.Current).Value;
			Class7126 class3 = @interface.imethod_0(part);
			if (class3 == null)
			{
				RectangleF rectangleF = default(RectangleF);
				if (rectangleF.Y > part)
				{
					class2.vmethod_0(@interface);
				}
				else if (rectangleF.Y == part)
				{
					if (rectangleF.Height != 0f)
					{
						class2.vmethod_0(@interface);
					}
					else
					{
						@class.vmethod_0(@interface);
					}
				}
			}
			else
			{
				Interface378[] array = class3.method_1();
				for (int i = 0; i < array.Length; i++)
				{
					@class.vmethod_0(array[i]);
				}
				Interface378[] array2 = class3.method_0();
				for (int j = 0; j < array2.Length; j++)
				{
					class2.vmethod_0(array2[j]);
				}
			}
		}
		return new Class7125(@class, class2);
	}

	public virtual IEnumerator vmethod_2()
	{
		return hashtable_0.GetEnumerator();
	}

	public virtual int vmethod_3()
	{
		return hashtable_0.Count;
	}
}

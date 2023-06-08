using System.Collections;
using System.Text;
using ns96;

namespace ns82;

internal class Class7336 : Interface388, Interface393
{
	protected Interface394 interface394_0;

	protected IList ilist_0;

	protected IDictionary idictionary_0;

	protected Class7205 class7205_0;

	protected int int_0;

	protected bool bool_0;

	protected int int_1;

	protected int int_2 = -1;

	public virtual Interface394 TokenSource
	{
		get
		{
			return interface394_0;
		}
		set
		{
			interface394_0 = value;
			ilist_0.Clear();
			int_2 = -1;
			int_0 = 0;
		}
	}

	public virtual string SourceName => TokenSource.SourceName;

	public Class7336()
	{
		int_0 = 0;
		ilist_0 = new ArrayList(500);
	}

	public Class7336(Interface394 tokenSource)
		: this()
	{
		interface394_0 = tokenSource;
	}

	public Class7336(Interface394 tokenSource, int channel)
		: this(tokenSource)
	{
		int_0 = channel;
	}

	public virtual Interface392 imethod_8(int k)
	{
		if (int_2 == -1)
		{
			vmethod_0();
		}
		if (k == 0)
		{
			return null;
		}
		if (k < 0)
		{
			return vmethod_11(-k);
		}
		if (int_2 + k - 1 >= ilist_0.Count)
		{
			return Class7346.interface392_0;
		}
		int num = int_2;
		for (int i = 1; i < k; i++)
		{
			num = vmethod_1(num + 1);
		}
		if (num >= ilist_0.Count)
		{
			return Class7346.interface392_0;
		}
		return (Interface392)ilist_0[num];
	}

	public virtual Interface392 imethod_9(int i)
	{
		return (Interface392)ilist_0[i];
	}

	public virtual string ToString(int start, int stop)
	{
		if (start >= 0 && stop >= 0)
		{
			if (int_2 == -1)
			{
				vmethod_0();
			}
			if (stop >= ilist_0.Count)
			{
				stop = ilist_0.Count - 1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = start; i <= stop; i++)
			{
				Interface392 @interface = (Interface392)ilist_0[i];
				stringBuilder.Append(@interface.Text);
			}
			return stringBuilder.ToString();
		}
		return null;
	}

	public virtual string ToString(Interface392 start, Interface392 stop)
	{
		if (start != null && stop != null)
		{
			return ToString(start.TokenIndex, stop.TokenIndex);
		}
		return null;
	}

	public virtual void imethod_0()
	{
		if (int_2 < ilist_0.Count)
		{
			int_2++;
			int_2 = vmethod_1(int_2);
		}
	}

	public virtual int imethod_1(int i)
	{
		return imethod_8(i).Type;
	}

	public virtual int imethod_2()
	{
		if (int_2 == -1)
		{
			vmethod_0();
		}
		int_1 = imethod_3();
		return int_1;
	}

	public virtual int imethod_3()
	{
		return int_2;
	}

	public virtual void imethod_4(int marker)
	{
		Seek(marker);
	}

	public virtual void imethod_5()
	{
		Seek(int_1);
	}

	public virtual void Reset()
	{
		int_2 = 0;
		int_1 = 0;
	}

	public virtual void imethod_6(int marker)
	{
	}

	public virtual void Seek(int index)
	{
		int_2 = index;
	}

	public virtual int imethod_7()
	{
		return ilist_0.Count;
	}

	protected virtual void vmethod_0()
	{
		int num = 0;
		Interface392 @interface = interface394_0.imethod_0();
		while (@interface != null && @interface.Type != -1)
		{
			bool flag = false;
			if (idictionary_0 != null)
			{
				object obj = idictionary_0[@interface.Type];
				if (obj != null)
				{
					@interface.Channel = (int)obj;
				}
			}
			if (class7205_0 != null && class7205_0.Contains(@interface.Type.ToString()))
			{
				flag = true;
			}
			else if (bool_0 && @interface.Channel != int_0)
			{
				flag = true;
			}
			if (!flag)
			{
				@interface.TokenIndex = num;
				ilist_0.Add(@interface);
				num++;
			}
			@interface = interface394_0.imethod_0();
		}
		int_2 = 0;
		int_2 = vmethod_1(int_2);
	}

	protected virtual int vmethod_1(int i)
	{
		int count = ilist_0.Count;
		while (i < count && ((Interface392)ilist_0[i]).Channel != int_0)
		{
			i++;
		}
		return i;
	}

	protected virtual int vmethod_2(int i)
	{
		while (i >= 0 && ((Interface392)ilist_0[i]).Channel != int_0)
		{
			i--;
		}
		return i;
	}

	public virtual void vmethod_3(int ttype, int channel)
	{
		if (idictionary_0 == null)
		{
			idictionary_0 = new Hashtable();
		}
		idictionary_0[ttype] = channel;
	}

	public virtual void vmethod_4(int ttype)
	{
		if (class7205_0 == null)
		{
			class7205_0 = new Class7205();
		}
		class7205_0.Add(ttype.ToString(), ttype);
	}

	public virtual void vmethod_5(bool discardOffChannelTokens)
	{
		bool_0 = discardOffChannelTokens;
	}

	public virtual IList vmethod_6()
	{
		if (int_2 == -1)
		{
			vmethod_0();
		}
		return ilist_0;
	}

	public virtual IList vmethod_7(int start, int stop)
	{
		return vmethod_8(start, stop, null);
	}

	public virtual IList vmethod_8(int start, int stop, Class7332 types)
	{
		if (int_2 == -1)
		{
			vmethod_0();
		}
		if (stop >= ilist_0.Count)
		{
			stop = ilist_0.Count - 1;
		}
		if (start < 0)
		{
			start = 0;
		}
		if (start > stop)
		{
			return null;
		}
		IList list = new ArrayList();
		for (int i = start; i <= stop; i++)
		{
			Interface392 @interface = (Interface392)ilist_0[i];
			if (types == null || types.vmethod_4(@interface.Type))
			{
				list.Add(@interface);
			}
		}
		if (list.Count == 0)
		{
			list = null;
		}
		return list;
	}

	public virtual IList vmethod_9(int start, int stop, IList types)
	{
		return vmethod_8(start, stop, new Class7332(types));
	}

	public virtual IList vmethod_10(int start, int stop, int ttype)
	{
		return vmethod_8(start, stop, Class7332.smethod_0(ttype));
	}

	protected virtual Interface392 vmethod_11(int k)
	{
		if (int_2 == -1)
		{
			vmethod_0();
		}
		if (k == 0)
		{
			return null;
		}
		if (int_2 - k < 0)
		{
			return null;
		}
		int num = int_2;
		for (int i = 1; i <= k; i++)
		{
			num = vmethod_2(num - 1);
		}
		if (num < 0)
		{
			return null;
		}
		return (Interface392)ilist_0[num];
	}

	public override string ToString()
	{
		if (int_2 == -1)
		{
			vmethod_0();
		}
		return ToString(0, ilist_0.Count - 1);
	}
}

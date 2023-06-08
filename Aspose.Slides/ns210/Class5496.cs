using System;
using System.Collections;
using System.Text;
using ns183;

namespace ns210;

internal class Class5496
{
	protected class Class5497 : Class5496
	{
		public Class5497()
			: this(null)
		{
		}

		public Class5497(ArrayList entries)
		{
		}

		public override int vmethod_0()
		{
			return int_0;
		}

		public override ArrayList vmethod_1()
		{
			return new ArrayList();
		}

		public override int vmethod_2()
		{
			return 0;
		}

		public override int vmethod_3(int gid)
		{
			return -1;
		}
	}

	protected class Class5501 : Class5496
	{
		public override int vmethod_0()
		{
			return int_1;
		}
	}

	protected abstract class Class5504 : Class5496
	{
		private int[] int_3;

		private int[] int_4;

		private int[] int_5;

		private int int_6 = -1;

		public Class5504(ArrayList entries)
		{
			method_0(entries);
		}

		public override int vmethod_0()
		{
			return int_2;
		}

		public override ArrayList vmethod_1()
		{
			ArrayList arrayList = new ArrayList();
			if (int_3 != null)
			{
				int i = 0;
				for (int num = int_3.Length; i < num; i++)
				{
					arrayList.Add(new Class5509(int_3[i], int_4[i], int_5[i]));
				}
			}
			return arrayList;
		}

		public override int vmethod_2()
		{
			return int_6 + 1;
		}

		public override int vmethod_3(int gid)
		{
			int num;
			if ((num = Array.BinarySearch(int_3, gid)) >= 0)
			{
				return vmethod_4(gid, int_3[num], int_5[num]);
			}
			if ((num = -(num + 1)) == 0)
			{
				return -1;
			}
			if (gid > int_4[--num])
			{
				return -1;
			}
			return vmethod_4(gid, int_3[num], int_5[num]);
		}

		public abstract int vmethod_4(int gid, int s, int m);

		private void method_0(ArrayList entries)
		{
			int num = 0;
			int count = entries.Count;
			int num2 = -1;
			int num3 = -1;
			int[] array = new int[count];
			int[] array2 = new int[count];
			int[] array3 = new int[count];
			Interface208 @interface = new Class5495(entries);
			while (@interface.imethod_0())
			{
				object obj = @interface.imethod_1();
				if (obj is Class5509)
				{
					Class5509 @class = (Class5509)obj;
					int num4 = @class.method_0();
					int num5 = @class.method_1();
					int num6 = @class.method_2();
					if (num4 >= 0 && num4 <= 65535)
					{
						if (num5 >= 0 && num5 <= 65535)
						{
							if (num4 <= num5)
							{
								if (num4 >= num2)
								{
									if (num6 >= 0)
									{
										array[num] = num4;
										num2 = (array2[num] = num5);
										array3[num] = num6;
										int num7;
										if ((num7 = num6 + (num5 - num4)) > num3)
										{
											num3 = num7;
										}
										num++;
										continue;
									}
									throw new Exception("illegal mapping index: " + num6);
								}
								throw new Exception("out of order glyph range: [" + num4 + "," + num5 + "]");
							}
							throw new Exception("illegal glyph range: [" + num4 + "," + num5 + "]: start index exceeds end index");
						}
						throw new Exception("illegal glyph range: [" + num4 + "," + num5 + "]: bad end index");
					}
					throw new Exception("illegal glyph range: [" + num4 + "," + num5 + "]: bad start index");
				}
				throw new Exception("illegal mapping entry, must be Integer: " + obj);
			}
			int_3 = array;
			int_4 = array2;
			int_5 = array3;
			int_6 = num3;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('{');
			int i = 0;
			for (int num = int_3.Length; i < num; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append('[');
				stringBuilder.Append(int_3[i].ToString());
				stringBuilder.Append(int_4[i].ToString());
				stringBuilder.Append("]:");
				stringBuilder.Append(int_5[i].ToString());
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}
	}

	internal class Class5509
	{
		private int int_0;

		private int int_1;

		private int int_2;

		public Class5509()
			: this(0, 0, 0)
		{
		}

		public Class5509(int gidStart, int gidEnd, int index)
		{
			if (gidStart >= 0 && gidEnd >= 0 && index >= 0)
			{
				if (gidStart > gidEnd)
				{
					throw new Exception();
				}
				int_0 = gidStart;
				int_1 = gidEnd;
				int_2 = index;
				return;
			}
			throw new Exception();
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int method_2()
		{
			return int_2;
		}

		public int[] method_3()
		{
			return new int[2] { int_0, int_1 };
		}

		public int[] method_4(int[] interval)
		{
			if (interval == null || interval.Length != 2)
			{
				throw new ArgumentException();
			}
			interval[0] = int_0;
			interval[1] = int_1;
			return interval;
		}

		public int method_5()
		{
			return int_0 - int_1;
		}
	}

	public static int int_0 = 0;

	public static int int_1 = 1;

	public static int int_2 = 2;

	public virtual int vmethod_0()
	{
		return -1;
	}

	public virtual ArrayList vmethod_1()
	{
		return null;
	}

	public virtual int vmethod_2()
	{
		return 0;
	}

	public virtual int vmethod_3(int gid)
	{
		return -1;
	}
}

using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells;
using ns2;
using ns59;

namespace ns27;

internal class Class585 : Class538
{
	private uint uint_0;

	private int int_0;

	private uint uint_1;

	private ArrayList arrayList_0;

	private int int_1;

	private long long_0;

	private Class1719[] class1719_0;

	private Regex regex_0;

	private Class978 class978_0;

	private bool bool_0 = true;

	private int int_2;

	private byte[] byte_1;

	internal Class585()
	{
		method_2(252);
		method_0(8);
		arrayList_0 = new ArrayList();
		regex_0 = new Regex("[^\\x00-\\x7f]+");
	}

	internal void method_4(Class1301 class1301_0)
	{
		int_0 = class1301_0.method_3();
		uint_0 = class1301_0.method_2();
		class1719_0 = class1301_0.class1719_0;
		uint_1 = (uint)Math.Max(int_0 / 128 + 1, 8);
	}

	internal void method_5(Class1301 class1301_0, Class978 class978_1)
	{
		int_0 = class978_1.int_2 + class978_1.arrayList_0.Count;
		uint_0 = class978_1.uint_0;
		class1719_0 = class1301_0.class1719_0;
		uint_1 = (uint)Math.Max(int_0 / 128 + 1, 8);
		class978_0 = class978_1;
	}

	internal void method_6(Class1725 class1725_0, WorksheetCollection worksheetCollection_0)
	{
		bool_0 = true;
		long_0 = class1725_0.method_10();
		int_2 += 12;
		method_8(class1725_0);
		byte_1 = null;
		class1719_0 = null;
		Class633 @class = new Class633();
		@class.method_4(class1725_0, arrayList_0);
		arrayList_0.Clear();
		arrayList_0 = null;
		int_2 = 0;
		int_0 = 0;
		int_1 = 0;
		uint_0 = 0u;
	}

	private void method_7(Class1725 class1725_0, int int_3)
	{
		if (bool_0)
		{
			class1725_0.method_7(method_1());
			class1725_0.method_7((short)(int_3 + 8));
			class1725_0.method_4(uint_0);
			class1725_0.method_5(int_0);
			class1725_0.method_1(byte_1, int_3);
			bool_0 = false;
		}
		else
		{
			class1725_0.method_8(60);
			class1725_0.method_7((short)int_3);
			class1725_0.method_1(byte_1, int_3);
		}
	}

	private void method_8(Class1725 class1725_0)
	{
		byte_1 = new byte[8216];
		int num = ((class978_0 == null) ? int_0 : class978_0.int_2);
		for (int i = 0; i < num; i++)
		{
			Class1719 @class = class1719_0[i];
			if ((long)i % (long)uint_1 == 0)
			{
				Struct92 @struct = default(Struct92);
				@struct.uint_0 = (uint)(long_0 + int_2);
				@struct.ushort_0 = (ushort)int_2;
				arrayList_0.Add(@struct);
			}
			if (@class == null)
			{
				method_13("r", null, class1725_0);
			}
			else if (@class.method_1())
			{
				method_13(@class.string_0, ((Class1720)@class).method_2(), class1725_0);
			}
			else
			{
				method_13(@class.string_0, null, class1725_0);
			}
		}
		if (class978_0 != null)
		{
			num = class978_0.arrayList_0.Count;
			for (int j = 0; j < num; j++)
			{
				if ((long)(j + class978_0.int_2) % (long)uint_1 == 0)
				{
					Struct92 struct2 = default(Struct92);
					struct2.uint_0 = (uint)(long_0 + int_2);
					struct2.ushort_0 = (ushort)int_2;
					arrayList_0.Add(struct2);
				}
				method_13((string)class978_0.arrayList_0[j], null, class1725_0);
			}
		}
		method_7(class1725_0, int_1);
	}

	private void method_9(string string_0, byte[] byte_2, Class1725 class1725_0)
	{
		if (int_1 + 3 + byte_2.Length > byte_1.Length)
		{
			if (int_1 + 3 < byte_1.Length)
			{
				Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
				byte_1[int_1 + 2] = 0;
				Array.Copy(byte_2, 0, byte_1, int_1 + 3, byte_1.Length - int_1 - 3);
				method_7(class1725_0, byte_1.Length);
				long_0 += (uint)(byte_1.Length + 4);
				if (bool_0)
				{
					long_0 += 8L;
				}
				int num = byte_1.Length - int_1 - 3;
				while (true)
				{
					byte_1 = new byte[8224];
					if (byte_2.Length - num <= 8223)
					{
						break;
					}
					Array.Copy(byte_2, num, byte_1, 1, 8223);
					num += 8223;
					method_7(class1725_0, byte_1.Length);
					long_0 += (uint)(byte_1.Length + 4);
					if (bool_0)
					{
						long_0 += 8L;
					}
				}
				Array.Copy(byte_2, num, byte_1, 1, byte_2.Length - num);
				int_1 = byte_2.Length - num + 1;
				int_2 = byte_2.Length - num + 5;
				return;
			}
			method_7(class1725_0, int_1);
			long_0 += (uint)(int_1 + 4);
			if (bool_0)
			{
				long_0 += 8L;
			}
			int_1 = 0;
			byte_1 = new byte[8224];
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, 0, 2);
			byte_1[2] = 0;
			if (byte_2.Length + 3 > 8224)
			{
				Array.Copy(byte_2, 0, byte_1, 3, 8221);
				int num = 8221;
				method_7(class1725_0, byte_1.Length);
				long_0 += (uint)(byte_1.Length + 4);
				if (bool_0)
				{
					long_0 += 8L;
				}
				while (true)
				{
					byte_1 = new byte[8224];
					if (byte_2.Length - num <= 8223)
					{
						break;
					}
					Array.Copy(byte_2, num, byte_1, 1, 8223);
					num += 8223;
					method_7(class1725_0, byte_1.Length);
					long_0 += (uint)(byte_1.Length + 4);
					if (bool_0)
					{
						long_0 += 8L;
					}
				}
				Array.Copy(byte_2, num, byte_1, 1, byte_2.Length - num);
				int_1 = byte_2.Length - num + 1;
				int_2 = byte_2.Length - num + 5;
			}
			else
			{
				Array.Copy(byte_2, 0, byte_1, 3, byte_2.Length);
				int_1 += 3 + byte_2.Length;
				int_2 += 3 + byte_2.Length;
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
			byte_1[int_1 + 2] = 0;
			Array.Copy(byte_2, 0, byte_1, int_1 + 3, byte_2.Length);
			int_1 += 3 + byte_2.Length;
			int_2 += 3 + byte_2.Length;
		}
	}

	private void method_10(string string_0, byte[] byte_2, byte[] byte_3, Class1725 class1725_0)
	{
		if (int_1 + 5 + byte_2.Length + byte_3.Length > byte_1.Length)
		{
			if (int_1 + 5 < byte_1.Length)
			{
				Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
				byte_1[int_1 + 2] = 8;
				Array.Copy(BitConverter.GetBytes((ushort)(byte_3.Length / 4)), 0, byte_1, int_1 + 3, 2);
				int_1 += 2;
				if (int_1 + 3 + byte_2.Length > byte_1.Length)
				{
					Array.Copy(byte_2, 0, byte_1, int_1 + 3, byte_1.Length - int_1 - 3);
					method_7(class1725_0, byte_1.Length);
					long_0 += (uint)(byte_1.Length + 4);
					if (bool_0)
					{
						long_0 += 8L;
					}
					int num = byte_1.Length - int_1 - 3;
					while (true)
					{
						byte_1 = new byte[8224];
						if (byte_2.Length - num <= 8223)
						{
							break;
						}
						Array.Copy(byte_2, num, byte_1, 1, 8223);
						num += 8223;
						method_7(class1725_0, byte_1.Length);
						long_0 += (uint)(byte_1.Length + 4);
						if (bool_0)
						{
							long_0 += 8L;
						}
					}
					Array.Copy(byte_2, num, byte_1, 1, byte_2.Length - num);
					int_1 = byte_2.Length - num + 1;
					int_2 = byte_2.Length - num + 5;
					if (int_1 + byte_3.Length > byte_1.Length)
					{
						int num2 = (byte_1.Length - int_1) / 4 * 4;
						Array.Copy(byte_3, 0, byte_1, int_1, num2);
						method_7(class1725_0, int_1 + num2);
						byte_1 = new byte[8224];
						int_1 = byte_3.Length - num2;
						int_2 = byte_3.Length - num2 + 4;
						Array.Copy(byte_3, num2, byte_1, 0, int_1);
					}
					else
					{
						Array.Copy(byte_3, 0, byte_1, int_1, byte_3.Length);
						int_1 += byte_3.Length;
						int_2 += byte_3.Length;
					}
					return;
				}
				int_1 += 3;
				Array.Copy(byte_2, 0, byte_1, int_1, byte_2.Length);
				int_1 += byte_2.Length;
				if (int_1 + byte_3.Length > byte_1.Length)
				{
					int num3 = (byte_1.Length - int_1) / 4 * 4;
					if (num3 != 0)
					{
						Array.Copy(byte_3, 0, byte_1, int_1, num3);
						method_7(class1725_0, int_1 + num3);
						byte_1 = new byte[8224];
						Array.Copy(byte_3, num3, byte_1, 0, byte_3.Length - num3);
						int_1 = byte_3.Length - num3;
						int_2 = byte_3.Length - num3 + 4;
					}
					else
					{
						method_7(class1725_0, int_1);
						byte_1 = new byte[8224];
						Array.Copy(byte_3, num3, byte_1, 0, byte_3.Length);
						int_1 = byte_3.Length;
						int_2 = byte_3.Length + 4;
					}
				}
				else
				{
					Array.Copy(byte_3, 0, byte_1, int_1, byte_3.Length);
					int_1 += byte_3.Length;
					int_2 += byte_2.Length + byte_3.Length;
				}
				return;
			}
			method_7(class1725_0, int_1);
			long_0 += (uint)(int_1 + 4);
			if (bool_0)
			{
				long_0 += 8L;
			}
			int_1 = 0;
			byte_1 = new byte[8224];
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, 0, 2);
			byte_1[2] = 8;
			Array.Copy(BitConverter.GetBytes((ushort)(byte_3.Length / 4)), 0, byte_1, 3, 2);
			if (byte_2.Length + 5 > 8224)
			{
				Array.Copy(byte_2, 0, byte_1, 5, 8221);
				int num = 8219;
				method_7(class1725_0, byte_1.Length);
				long_0 += (uint)(byte_1.Length + 4);
				if (bool_0)
				{
					long_0 += 8L;
				}
				while (true)
				{
					byte_1 = new byte[8224];
					if (byte_2.Length - num <= 8223)
					{
						break;
					}
					Array.Copy(byte_2, num, byte_1, 1, 8223);
					num += 8223;
					method_7(class1725_0, byte_1.Length);
					long_0 += (uint)(byte_1.Length + 4);
					if (bool_0)
					{
						long_0 += 8L;
					}
				}
				Array.Copy(byte_2, num, byte_1, 1, byte_2.Length - num);
				int_1 = byte_2.Length - num + 1;
				int_2 = byte_2.Length - num + 5;
			}
			else
			{
				Array.Copy(byte_2, 0, byte_1, 5, byte_2.Length);
				int_1 += 5 + byte_2.Length;
				int_2 += 5 + byte_2.Length;
			}
			if (int_1 + byte_3.Length > byte_1.Length)
			{
				int num4 = (byte_1.Length - int_1) / 4 * 4;
				if (num4 != 0)
				{
					Array.Copy(byte_3, 0, byte_1, int_1, num4);
					method_7(class1725_0, int_1 + num4);
					byte_1 = new byte[8224];
					Array.Copy(byte_3, num4, byte_1, 0, byte_3.Length - num4);
					int_1 = byte_3.Length - num4;
					int_2 = byte_3.Length - num4 + 4;
				}
				else
				{
					method_7(class1725_0, int_1);
					byte_1 = new byte[8224];
					Array.Copy(byte_3, num4, byte_1, 0, byte_3.Length);
					int_1 = byte_3.Length;
					int_2 = byte_3.Length + 4;
				}
			}
			else
			{
				Array.Copy(byte_3, 0, byte_1, int_1, byte_3.Length);
				int_1 += byte_3.Length;
				int_2 += byte_2.Length + byte_3.Length;
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
			byte_1[int_1 + 2] = 8;
			Array.Copy(BitConverter.GetBytes((ushort)(byte_3.Length / 4)), 0, byte_1, int_1 + 3, 2);
			Array.Copy(byte_2, 0, byte_1, int_1 + 5, byte_2.Length);
			int_1 += 5 + byte_2.Length;
			Array.Copy(byte_3, 0, byte_1, int_1, byte_3.Length);
			int_1 += byte_3.Length;
			int_2 += 5 + byte_2.Length + byte_3.Length;
		}
	}

	private void method_11(string string_0, byte[] byte_2, Class1725 class1725_0)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		if (int_1 + 5 + bytes.Length + byte_2.Length > byte_1.Length)
		{
			if (int_1 + 5 < byte_1.Length)
			{
				Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
				byte_1[int_1 + 2] = 9;
				Array.Copy(BitConverter.GetBytes((ushort)(byte_2.Length / 4)), 0, byte_1, int_1 + 3, 2);
				int_1 += 2;
				if (int_1 + 3 + bytes.Length > byte_1.Length)
				{
					int num = byte_1.Length - int_1 - 3;
					if (num % 2 != 0)
					{
						num--;
					}
					Array.Copy(bytes, 0, byte_1, int_1 + 3, num);
					method_7(class1725_0, int_1 + num + 3);
					long_0 += (uint)(int_1 + num + 7);
					if (bool_0)
					{
						long_0 += 8L;
					}
					string text = string_0.Substring(num / 2);
					byte[] bytes2 = Encoding.ASCII.GetBytes(text);
					string @string = Encoding.ASCII.GetString(bytes2);
					bool flag = true;
					if (@string != text)
					{
						bytes2 = Encoding.Unicode.GetBytes(text);
						flag = false;
					}
					int num2 = 0;
					if (flag)
					{
						while (true)
						{
							byte_1 = new byte[8224];
							if (bytes2.Length - num2 <= 8223)
							{
								break;
							}
							Array.Copy(bytes2, num2, byte_1, 1, 8223);
							num2 += 8223;
							method_7(class1725_0, byte_1.Length);
							long_0 += (uint)(byte_1.Length + 4);
							if (bool_0)
							{
								long_0 += 8L;
							}
						}
						Array.Copy(bytes2, num2, byte_1, 1, bytes2.Length - num2);
						int_1 = bytes2.Length - num2 + 1;
						int_2 = bytes2.Length - num2 + 5;
					}
					else
					{
						while (true)
						{
							byte_1 = new byte[8223];
							byte_1[0] = 1;
							if (bytes2.Length - num2 <= 8222)
							{
								break;
							}
							Array.Copy(bytes2, num2, byte_1, 1, 8222);
							num2 += 8222;
							method_7(class1725_0, byte_1.Length);
							long_0 += (uint)(byte_1.Length + 4);
							if (bool_0)
							{
								long_0 += 8L;
							}
						}
						Array.Copy(bytes2, num2, byte_1, 1, bytes2.Length - num2);
						int_1 = bytes2.Length - num2 + 1;
						int_2 = bytes2.Length - num2 + 5;
					}
					if (int_1 + byte_2.Length > byte_1.Length)
					{
						num = (byte_1.Length - int_1) / 4 * 4;
						if (num != 0)
						{
							Array.Copy(byte_2, 0, byte_1, int_1, num);
							method_7(class1725_0, int_1 + num);
							byte_1 = new byte[8224];
							Array.Copy(byte_2, num, byte_1, 0, byte_2.Length - num);
							int_1 = byte_2.Length - num;
							int_2 = byte_2.Length - num + 4;
						}
						else
						{
							method_7(class1725_0, int_1);
							byte_1 = new byte[8224];
							Array.Copy(byte_2, num, byte_1, 0, byte_2.Length);
							int_1 = byte_2.Length;
							int_2 = byte_2.Length + 4;
						}
					}
					else
					{
						Array.Copy(byte_2, 0, byte_1, int_1, byte_2.Length);
						int_1 += byte_2.Length;
						int_2 += bytes.Length + byte_2.Length;
					}
					return;
				}
				int_1 += 3;
				Array.Copy(bytes, 0, byte_1, int_1, bytes.Length);
				int_1 += bytes.Length;
				if (int_1 + byte_2.Length > byte_1.Length)
				{
					int num = (byte_1.Length - int_1) / 4 * 4;
					if (num != 0)
					{
						Array.Copy(byte_2, 0, byte_1, int_1, num);
						method_7(class1725_0, int_1 + num);
						byte_1 = new byte[8224];
						Array.Copy(byte_2, num, byte_1, 0, byte_2.Length - num);
						int_1 = byte_2.Length - num;
						int_2 = byte_2.Length - num + 4;
					}
					else
					{
						method_7(class1725_0, int_1);
						byte_1 = new byte[8224];
						Array.Copy(byte_2, num, byte_1, 0, byte_2.Length);
						int_1 = byte_2.Length;
						int_2 = byte_2.Length + 4;
					}
				}
				else
				{
					Array.Copy(byte_2, 0, byte_1, int_1, byte_2.Length);
					int_1 += byte_2.Length;
					int_2 += bytes.Length + byte_2.Length;
				}
				return;
			}
			method_7(class1725_0, int_1);
			long_0 += (uint)(int_1 + 4);
			if (bool_0)
			{
				long_0 += 8L;
			}
			int_1 = 0;
			byte_1 = new byte[8224];
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, 0, 2);
			byte_1[2] = 9;
			Array.Copy(BitConverter.GetBytes((ushort)(byte_2.Length / 4)), 0, byte_1, int_1 + 3, 2);
			int_1 += 2;
			if (bytes.Length + 3 > 8224)
			{
				Array.Copy(bytes, 0, byte_1, int_1 + 3, 8218);
				int num2 = 8218;
				method_7(class1725_0, 8223);
				long_0 += 8227L;
				if (bool_0)
				{
					long_0 += 8L;
				}
				string text2 = string_0.Substring(4109);
				byte[] bytes3 = Encoding.ASCII.GetBytes(text2);
				string string2 = Encoding.ASCII.GetString(bytes3);
				bool flag2 = true;
				if (string2 != text2)
				{
					bytes3 = Encoding.Unicode.GetBytes(text2);
					flag2 = false;
				}
				num2 = 0;
				if (flag2)
				{
					while (true)
					{
						byte_1 = new byte[8224];
						if (bytes3.Length - num2 <= 8223)
						{
							break;
						}
						Array.Copy(bytes3, num2, byte_1, 1, 8223);
						num2 += 8223;
						method_7(class1725_0, byte_1.Length);
						long_0 += (uint)(byte_1.Length + 4);
						if (bool_0)
						{
							long_0 += 8L;
						}
					}
					Array.Copy(bytes3, num2, byte_1, 1, bytes3.Length - num2);
					int_1 = bytes3.Length - num2 + 1;
					int_2 = bytes3.Length - num2 + 5;
				}
				else
				{
					while (true)
					{
						byte_1 = new byte[8223];
						byte_1[0] = 1;
						if (bytes3.Length - num2 <= 8222)
						{
							break;
						}
						Array.Copy(bytes3, num2, byte_1, 1, 8222);
						num2 += 8222;
						method_7(class1725_0, byte_1.Length);
						long_0 += (uint)(byte_1.Length + 4);
						if (bool_0)
						{
							long_0 += 8L;
						}
					}
					Array.Copy(bytes3, num2, byte_1, 1, bytes3.Length - num2);
					int_1 = bytes3.Length - num2 + 1;
					int_2 = bytes3.Length - num2 + 5;
				}
			}
			else
			{
				Array.Copy(bytes, 0, byte_1, int_1 + 3, bytes.Length);
				int_1 += 3 + bytes.Length;
				int_2 += 3 + bytes.Length;
			}
			if (int_1 + byte_2.Length > byte_1.Length)
			{
				int num = (byte_1.Length - int_1) / 4 * 4;
				if (num != 0)
				{
					Array.Copy(byte_2, 0, byte_1, int_1, num);
					method_7(class1725_0, int_1 + num);
					byte_1 = new byte[8224];
					Array.Copy(byte_2, num, byte_1, 0, byte_2.Length - num);
					int_1 = byte_2.Length - num;
					int_2 = byte_2.Length - num + 4;
				}
				else
				{
					method_7(class1725_0, int_1);
					byte_1 = new byte[8224];
					Array.Copy(byte_2, num, byte_1, 0, byte_2.Length);
					int_1 = byte_2.Length;
					int_2 = byte_2.Length + 4;
				}
			}
			else
			{
				Array.Copy(byte_2, 0, byte_1, int_1, byte_2.Length);
				int_1 += byte_2.Length;
				int_2 += bytes.Length + byte_2.Length;
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
			byte_1[int_1 + 2] = 9;
			Array.Copy(BitConverter.GetBytes((ushort)(byte_2.Length / 4)), 0, byte_1, int_1 + 3, 2);
			Array.Copy(bytes, 0, byte_1, int_1 + 5, bytes.Length);
			int_1 += 5 + bytes.Length;
			Array.Copy(byte_2, 0, byte_1, int_1, byte_2.Length);
			int_1 += byte_2.Length;
			int_2 += 5 + bytes.Length + byte_2.Length;
		}
	}

	private void method_12(string string_0, Class1725 class1725_0)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		if (int_1 + 3 + bytes.Length > byte_1.Length)
		{
			if (int_1 + 4 < byte_1.Length)
			{
				Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
				byte_1[int_1 + 2] = 1;
				int num = byte_1.Length - int_1 - 3;
				if (num % 2 != 0)
				{
					num--;
				}
				Array.Copy(bytes, 0, byte_1, int_1 + 3, num);
				method_7(class1725_0, int_1 + num + 3);
				long_0 += (uint)(int_1 + num + 7);
				if (bool_0)
				{
					long_0 += 8L;
				}
				string text = string_0.Substring(num / 2);
				byte[] bytes2 = Encoding.ASCII.GetBytes(text);
				string @string = Encoding.ASCII.GetString(bytes2);
				bool flag = true;
				if (@string != text)
				{
					bytes2 = Encoding.Unicode.GetBytes(text);
					flag = false;
				}
				int num2 = 0;
				if (flag)
				{
					while (true)
					{
						byte_1 = new byte[8224];
						if (bytes2.Length - num2 <= 8223)
						{
							break;
						}
						Array.Copy(bytes2, num2, byte_1, 1, 8223);
						num2 += 8223;
						method_7(class1725_0, byte_1.Length);
						long_0 += (uint)(byte_1.Length + 4);
						if (bool_0)
						{
							long_0 += 8L;
						}
					}
					Array.Copy(bytes2, num2, byte_1, 1, bytes2.Length - num2);
					int_1 = bytes2.Length - num2 + 1;
					int_2 = bytes2.Length - num2 + 5;
					return;
				}
				while (true)
				{
					byte_1 = new byte[8223];
					byte_1[0] = 1;
					if (bytes2.Length - num2 <= 8222)
					{
						break;
					}
					Array.Copy(bytes2, num2, byte_1, 1, 8222);
					num2 += 8222;
					method_7(class1725_0, byte_1.Length);
					long_0 += (uint)(byte_1.Length + 4);
					if (bool_0)
					{
						long_0 += 8L;
					}
				}
				Array.Copy(bytes2, num2, byte_1, 1, bytes2.Length - num2);
				int_1 = bytes2.Length - num2 + 1;
				int_2 = bytes2.Length - num2 + 5;
				return;
			}
			method_7(class1725_0, int_1);
			long_0 += (uint)(int_1 + 4);
			if (bool_0)
			{
				long_0 += 8L;
			}
			int_1 = 0;
			byte_1 = new byte[8224];
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, 0, 2);
			byte_1[2] = 1;
			if (bytes.Length + 3 > 8224)
			{
				Array.Copy(bytes, 0, byte_1, 3, 8220);
				int num2 = 8220;
				method_7(class1725_0, byte_1.Length - 1);
				long_0 += (uint)(byte_1.Length + 3);
				if (bool_0)
				{
					long_0 += 8L;
				}
				string text2 = string_0.Substring((byte_1.Length - 3) / 2);
				byte[] bytes3 = Encoding.ASCII.GetBytes(text2);
				string string2 = Encoding.ASCII.GetString(bytes3);
				bool flag2 = true;
				if (string2 != text2)
				{
					bytes3 = Encoding.Unicode.GetBytes(text2);
					flag2 = false;
				}
				num2 = 0;
				if (flag2)
				{
					while (true)
					{
						byte_1 = new byte[8224];
						if (bytes3.Length - num2 <= 8223)
						{
							break;
						}
						Array.Copy(bytes3, num2, byte_1, 1, 8223);
						num2 += 8223;
						method_7(class1725_0, byte_1.Length);
						long_0 += (uint)(byte_1.Length + 4);
						if (bool_0)
						{
							long_0 += 8L;
						}
					}
					Array.Copy(bytes3, num2, byte_1, 1, bytes3.Length - num2);
					int_1 = bytes3.Length - num2 + 1;
					int_2 = bytes3.Length - num2 + 5;
					return;
				}
				while (true)
				{
					byte_1 = new byte[8223];
					byte_1[0] = 1;
					if (bytes3.Length - num2 <= 8222)
					{
						break;
					}
					Array.Copy(bytes3, num2, byte_1, 1, 8222);
					num2 += 8222;
					method_7(class1725_0, byte_1.Length);
					long_0 += (uint)(byte_1.Length + 4);
					if (bool_0)
					{
						long_0 += 8L;
					}
				}
				Array.Copy(bytes3, num2, byte_1, 1, bytes3.Length - num2);
				int_1 = bytes3.Length - num2 + 1;
				int_2 = bytes3.Length - num2 + 5;
			}
			else
			{
				Array.Copy(bytes, 0, byte_1, 3, bytes.Length);
				int_1 += 3 + bytes.Length;
				int_2 += 3 + bytes.Length;
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_1, int_1, 2);
			byte_1[int_1 + 2] = 1;
			Array.Copy(bytes, 0, byte_1, int_1 + 3, bytes.Length);
			int_1 += 3 + bytes.Length;
			int_2 += 3 + bytes.Length;
		}
	}

	private void method_13(string string_0, byte[] byte_2, Class1725 class1725_0)
	{
		Match match = regex_0.Match(string_0);
		if (match.Success)
		{
			if (byte_2 != null && byte_2.Length != 0)
			{
				method_11(string_0, byte_2, class1725_0);
			}
			else
			{
				method_12(string_0, class1725_0);
			}
		}
		else if (byte_2 != null && byte_2.Length != 0)
		{
			method_10(string_0, Encoding.ASCII.GetBytes(string_0), byte_2, class1725_0);
		}
		else
		{
			method_9(string_0, Encoding.ASCII.GetBytes(string_0), class1725_0);
		}
	}
}

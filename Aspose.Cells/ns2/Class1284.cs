using System;
using System.Collections;
using System.IO;
using Aspose.Cells;
using ns20;
using ns38;
using ns57;
using ns59;

namespace ns2;

internal class Class1284
{
	private int int_0;

	private int int_1;

	private byte[] byte_0;

	private byte[] byte_1;

	private Workbook workbook_0;

	private ArrayList arrayList_0 = new ArrayList();

	private ArrayList arrayList_1 = new ArrayList();

	private ArrayList arrayList_2 = new ArrayList();

	private ArrayList arrayList_3 = new ArrayList();

	private ArrayList arrayList_4 = new ArrayList();

	public Class1284()
	{
		byte_0 = new byte[2];
		workbook_0 = new Workbook();
		workbook_0.Worksheets.Clear();
		workbook_0.Worksheets.method_32().method_4(0, 0);
	}

	public void Combine(string[] string_0, string string_1, string string_2)
	{
		FileStream fileStream = null;
		try
		{
			method_1(string_0);
			fileStream = Write(string_0, string_1, string_2);
			fileStream.Seek(0L, SeekOrigin.Begin);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Class1317 @class = new Class1317(WorksheetCollection.guid_0);
			@class.method_9().Add("Workbook", fileStream);
			@class.Save(string_2);
		}
		finally
		{
			fileStream?.Close();
			try
			{
				File.Delete(string_1);
			}
			catch
			{
			}
		}
	}

	private void method_0()
	{
		workbook_0.Worksheets.method_26();
	}

	private FileStream Write(string[] string_0, string string_1, string string_2)
	{
		bool flag = Class972.smethod_0() == Enum134.const_0;
		FileStream fileStream = File.Create(string_1);
		Class1725 class1725_ = new Class1725(fileStream);
		if (flag)
		{
			method_0();
		}
		workbook_0.Worksheets.method_27();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		Class982 class982_ = new Class982(workbook_0);
		int[] array = new int[workbook_0.Worksheets.Count];
		new Class537(workbook_0, class982_).Write(class1725_, array);
		GC.Collect();
		GC.WaitForPendingFinalizers();
		method_6(string_0, fileStream, string_2, array);
		if (flag)
		{
			long position = fileStream.Position;
			long offset = array[array.Length - 1];
			fileStream.Seek(offset, SeekOrigin.Begin);
			fileStream.Write(BitConverter.GetBytes((uint)position), 0, 4);
			fileStream.Seek(position, SeekOrigin.Begin);
			Worksheet worksheet_ = workbook_0.Worksheets[workbook_0.Worksheets.Count - 1];
			new Class723(worksheet_, new Class721(class982_, workbook_0.Worksheets.Count - 1)).Write(class1725_);
		}
		return fileStream;
	}

	private void method_1(string[] string_0)
	{
		for (int i = 0; i < string_0.Length; i++)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Workbook workbook = new Workbook();
			Class1317 @class = new Class1317(string_0[i]);
			Class1730 class2 = new Class1730(workbook);
			MemoryStream stream = @class.method_9().GetStream("Workbook");
			if (stream == null)
			{
				stream = @class.method_9().GetStream("WORKBOOK");
				@class.method_9().Remove("WORKBOOK");
			}
			else
			{
				@class.method_9().Remove("Workbook");
			}
			Class1723 class1723_ = new Class1723(stream);
			workbook.Worksheets.method_35();
			class2.method_9(class1723_);
			arrayList_0.Add(stream.Position);
			class1723_ = null;
			@class = null;
			class2 = null;
			stream.Close();
			stream = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			method_2(workbook);
			if (i == 0)
			{
				workbook_0.Worksheets.ActiveSheetIndex = workbook.Worksheets.ActiveSheetIndex;
			}
			workbook = null;
		}
	}

	private void method_2(Workbook workbook_1)
	{
		int count = workbook_0.Worksheets.Count;
		int count2 = workbook_0.Worksheets.Names.Count;
		Hashtable hashtable = new Hashtable();
		arrayList_4.Add(hashtable);
		for (int i = 0; i < workbook_1.Worksheets.Count; i++)
		{
			if (workbook_0.Worksheets[workbook_1.Worksheets[i].Name] != null)
			{
				workbook_0.Worksheets.Add();
			}
			else
			{
				workbook_0.Worksheets.Add(workbook_1.Worksheets[i].Name);
			}
			int num = workbook_1.Worksheets.method_32().method_10(workbook_1.Worksheets.method_36(), i, i);
			if (num != -1)
			{
				int num2 = workbook_0.Worksheets.method_32().method_10(workbook_0.Worksheets.method_36(), workbook_0.Worksheets.Count - 1, workbook_0.Worksheets.Count - 1);
				if (hashtable[num] == null)
				{
					hashtable.Add(num, num2);
				}
			}
		}
		Hashtable hashtable2 = new Hashtable();
		arrayList_3.Add(hashtable2);
		for (int j = 0; j < workbook_1.Worksheets.Names.Count; j++)
		{
			Name name = workbook_1.Worksheets.Names[j];
			Name name2 = new Name(workbook_0.Worksheets);
			name2.Copy(name);
			if (name.SheetIndex == 0)
			{
				if (workbook_0.Worksheets.Names[name.method_16()] != null)
				{
					name2.SheetIndex = name.method_24() + 1 + count;
				}
			}
			else
			{
				name2.SheetIndex = name.SheetIndex + count;
			}
			int num3 = workbook_0.Worksheets.Names.method_3(name2, bool_0: true);
			hashtable2.Add(j, num3);
		}
		for (int k = 0; k < workbook_1.Worksheets.Names.Count; k++)
		{
			Name name3 = workbook_0.Worksheets.Names[k + count2];
			if (name3.method_2() != null)
			{
				Class1258.smethod_17(name3.method_2(), -1, -1, hashtable, hashtable2);
			}
		}
		Hashtable hashtable3 = new Hashtable();
		arrayList_2.Add(hashtable3);
		Hashtable hashtable4 = new Hashtable();
		for (int l = 0; l < workbook_1.Worksheets.method_52().Count; l++)
		{
			Font font_ = (Font)workbook_1.Worksheets.method_52()[l];
			int num4 = workbook_0.Worksheets.method_64(font_);
			if (l < 4)
			{
				hashtable4.Add(l, num4);
			}
			else
			{
				hashtable4.Add(l + 1, num4);
			}
		}
		Class1683 @class = workbook_1.Worksheets.method_58();
		for (int m = 16; m < workbook_1.Worksheets.method_58().Count; m++)
		{
			Style style = @class[m];
			if (style.method_2() == null)
			{
				style.method_13(-1);
				int num5 = workbook_0.Worksheets.method_59(style);
				hashtable3.Add(m, num5);
			}
		}
		Hashtable hashtable5 = new Hashtable();
		arrayList_1.Add(hashtable5);
		Class1301 class1301_ = workbook_1.Worksheets.class1301_0;
		for (int n = 0; n < class1301_.class1719_0.Length; n++)
		{
			Class1719 class2 = class1301_.class1719_0[n];
			if (class2 != null)
			{
				if (class2.method_1())
				{
					Class1720 class1720_ = (Class1720)class2;
					int num6 = method_3(class1720_, hashtable4);
					hashtable5.Add(n, num6);
				}
				else
				{
					class2 = workbook_0.Worksheets.class1301_0.method_9(class2.string_0);
					hashtable5.Add(n, class2.int_1);
				}
			}
		}
	}

	private int method_3(Class1720 class1720_0, Hashtable hashtable_0)
	{
		byte[] array = class1720_0.method_2();
		for (int i = 0; i < array.Length; i += 4)
		{
			int num = BitConverter.ToUInt16(array, i + 2);
			object obj = hashtable_0[num];
			if (obj != null)
			{
				int num2 = (int)obj;
				if (num2 != num)
				{
					Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, i + 2, 2);
				}
			}
		}
		return workbook_0.Worksheets.class1301_0.method_12(class1720_0.string_0, array).int_1;
	}

	private void method_4(Stream stream_0, Stream stream_1)
	{
		stream_0.Read(byte_0, 0, 2);
		int_1 = BitConverter.ToUInt16(byte_0, 0) + 4;
		byte_1 = new byte[int_1];
		stream_0.Seek(-4L, SeekOrigin.Current);
		stream_0.Read(byte_1, 0, int_1);
		stream_1.Write(byte_1, 0, int_1);
	}

	private void method_5(Stream stream_0)
	{
		stream_0.Read(byte_0, 0, 2);
		int_1 = BitConverter.ToUInt16(byte_0, 0) + 4;
		byte_1 = new byte[int_1];
		stream_0.Seek(-4L, SeekOrigin.Current);
		stream_0.Read(byte_1, 0, int_1);
	}

	private void method_6(string[] string_0, Stream stream_0, string string_1, int[] int_2)
	{
		int num = 0;
		long num2 = 0L;
		int num3 = 0;
		long num4 = 0L;
		for (int i = 0; i < string_0.Length; i++)
		{
			Class1317 @class = new Class1317(string_0[i]);
			Stream stream = @class.method_9().GetStream("Workbook");
			if (stream == null)
			{
				stream = @class.method_9().GetStream("WORKBOOK");
				@class.method_9().Remove("WORKBOOK");
			}
			else
			{
				@class.method_9().Remove("Workbook");
			}
			@class = null;
			stream.Seek((long)arrayList_0[i], SeekOrigin.Begin);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			int num5 = 0;
			Hashtable hashtable = (Hashtable)arrayList_1[i];
			Hashtable hashtable2 = (Hashtable)arrayList_2[i];
			Hashtable hashtable_ = (Hashtable)arrayList_4[i];
			Hashtable hashtable_2 = (Hashtable)arrayList_3[i];
			while (stream.Position < stream.Length)
			{
				stream.Read(byte_0, 0, 2);
				int_0 = BitConverter.ToUInt16(byte_0, 0);
				switch (int_0)
				{
				case 85:
					if (num2 != 0)
					{
						num4 = stream_0.Position;
						stream_0.Seek(num2 + 16, SeekOrigin.Begin);
						stream_0.Write(BitConverter.GetBytes((uint)num4), 0, 4);
						stream_0.Seek(num4, SeekOrigin.Begin);
					}
					method_4(stream, stream_0);
					break;
				case 10:
					num5--;
					method_4(stream, stream_0);
					break;
				case 215:
					num3++;
					if (num2 != 0)
					{
						num4 = stream_0.Position;
						stream_0.Seek(num2 + 16 + 4 * num3, SeekOrigin.Begin);
						stream_0.Write(BitConverter.GetBytes((uint)num4), 0, 4);
						stream_0.Seek(num4, SeekOrigin.Begin);
					}
					method_4(stream, stream_0);
					break;
				case 189:
				{
					method_5(stream);
					int num14 = BitConverter.ToUInt16(byte_1, byte_1.Length - 2) - BitConverter.ToUInt16(byte_1, 6) + 1;
					for (int k = 0; k < num14; k++)
					{
						int num15 = BitConverter.ToUInt16(byte_1, 8 + 6 * k);
						if (num15 != 15)
						{
							int num16 = (int)hashtable2[num15];
							Array.Copy(BitConverter.GetBytes((ushort)num16), 0, byte_1, 8 + 6 * k, 2);
						}
					}
					stream_0.Write(byte_1, 0, byte_1.Length);
					break;
				}
				case 190:
				{
					method_5(stream);
					int num6 = BitConverter.ToUInt16(byte_1, byte_1.Length - 2) - BitConverter.ToUInt16(byte_1, 6) + 1;
					for (int j = 0; j < num6; j++)
					{
						int num7 = BitConverter.ToUInt16(byte_1, 8 + 2 * j);
						if (num7 != 15)
						{
							int num8 = (int)hashtable2[num7];
							Array.Copy(BitConverter.GetBytes((ushort)num8), 0, byte_1, 8 + 2 * j, 2);
						}
					}
					stream_0.Write(byte_1, 0, byte_1.Length);
					break;
				}
				case 6:
				case 518:
				{
					method_5(stream);
					int num11 = BitConverter.ToUInt16(byte_1, 8);
					if (num11 != 15)
					{
						int num12 = (int)hashtable2[num11];
						Array.Copy(BitConverter.GetBytes((ushort)num12), 0, byte_1, 8, 2);
					}
					int num13 = byte_1.Length - 24;
					byte[] array = new byte[num13];
					Array.Copy(byte_1, 24, array, 0, num13);
					Class1258.smethod_17(array, -1, -1, hashtable_, hashtable_2);
					Array.Copy(array, 0, byte_1, 24, num13);
					stream_0.Write(byte_1, 0, byte_1.Length);
					break;
				}
				case 520:
					method_5(stream);
					if ((byte_1[16] & 0x80u) != 0)
					{
						int num17 = BitConverter.ToUInt16(byte_1, 18) & 0xFFF;
						if (num17 != 15)
						{
							int num18 = (int)hashtable2[num17];
							byte[] bytes = BitConverter.GetBytes((ushort)num18);
							bytes[1] |= (byte)(byte_1[19] & 0xF0);
							Array.Copy(bytes, 0, byte_1, 18, 2);
						}
					}
					stream_0.Write(byte_1, 0, byte_1.Length);
					break;
				case 523:
					num2 = stream_0.Position;
					method_4(stream, stream_0);
					break;
				case 253:
				{
					method_5(stream);
					int num19 = BitConverter.ToUInt16(byte_1, 8);
					if (num19 != 15)
					{
						int num20 = (int)hashtable2[num19];
						Array.Copy(BitConverter.GetBytes((ushort)num20), 0, byte_1, 8, 2);
					}
					int num21 = BitConverter.ToInt32(byte_1, 10);
					object obj = hashtable[num21];
					int num22 = 0;
					num22 = ((obj != null) ? ((int)obj) : 0);
					workbook_0.Worksheets.class1301_0.class1719_0[num22].int_0++;
					Array.Copy(BitConverter.GetBytes(num22), 0, byte_1, 10, 4);
					stream_0.Write(byte_1, 0, byte_1.Length);
					break;
				}
				case 176:
				case 236:
					while (int_0 != 574)
					{
						stream.Read(byte_0, 0, 2);
						int_1 = BitConverter.ToUInt16(byte_0, 0);
						stream.Seek(int_1, SeekOrigin.Current);
						stream.Read(byte_0, 0, 2);
						int_0 = BitConverter.ToUInt16(byte_0, 0);
					}
					stream.Seek(-2L, SeekOrigin.Current);
					break;
				case 2057:
					if (num5 == 0)
					{
						num4 = stream_0.Position;
						long offset = int_2[num++];
						stream_0.Seek(offset, SeekOrigin.Begin);
						stream_0.Write(BitConverter.GetBytes((uint)num4), 0, 4);
						stream_0.Seek(num4, SeekOrigin.Begin);
						num3 = 0;
					}
					num5++;
					method_4(stream, stream_0);
					break;
				default:
					method_4(stream, stream_0);
					break;
				case 513:
				case 515:
				case 516:
				case 517:
				case 638:
				{
					method_5(stream);
					int num9 = BitConverter.ToUInt16(byte_1, 8);
					if (num9 != 15)
					{
						int num10 = (int)hashtable2[num9];
						Array.Copy(BitConverter.GetBytes((ushort)num10), 0, byte_1, 8, 2);
					}
					stream_0.Write(byte_1, 0, byte_1.Length);
					break;
				}
				case 574:
					method_5(stream);
					if (num - 1 == workbook_0.Worksheets.ActiveSheetIndex)
					{
						byte_1[5] |= 6;
					}
					else
					{
						byte_1[5] &= 249;
					}
					stream_0.Write(byte_1, 0, byte_1.Length);
					break;
				}
			}
			stream_0.Flush();
			@class = null;
			stream.Close();
			stream = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}

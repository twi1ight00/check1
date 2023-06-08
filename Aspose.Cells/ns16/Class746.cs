using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ns46;

namespace ns16;

[Guid("ebc25cf6-9120-4283-b972-0e5520d00005")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
internal class Class746 : IEnumerable<Class744>, IDisposable, IEnumerable
{
	private class Class747
	{
		public Enum34 enum34_0;

		public List<string> list_0;

		public List<string> list_1;

		private static Class747 class747_0;

		private static Class747 class747_1;

		private Class747(Enum34 enum34_1, List<string> list_2, List<string> list_3, List<string> list_4)
		{
			enum34_0 = enum34_1;
			list_0 = list_2;
			list_1 = list_3;
			list_0 = list_2;
		}

		public static Class747 smethod_0()
		{
			if (class747_0 == null)
			{
				class747_0 = smethod_2();
			}
			return class747_0;
		}

		public static Class747 smethod_1()
		{
			if (class747_1 == null)
			{
				class747_1 = smethod_3();
			}
			return class747_1;
		}

		private static Class747 smethod_2()
		{
			List<string> list = new List<string>(3);
			List<string> list_ = new List<string>(3);
			List<string> list_2 = new List<string>(7);
			list.Add("System.dll");
			list.Add("System.Windows.Forms.dll");
			list.Add("System.Drawing.dll");
			list.Add("Aspose.Cells.OpenXML.WinFormsSelfExtractorStub.resources");
			list.Add("Aspose.Cells.OpenXML.Forms.PasswordDialog.resources");
			list.Add("Aspose.Cells.OpenXML.Forms.ZipContentsDialog.resources");
			list.Add("WinFormsSelfExtractorStub.cs");
			list.Add("WinFormsSelfExtractorStub.Designer.cs");
			list.Add("PasswordDialog.cs");
			list.Add("PasswordDialog.Designer.cs");
			list.Add("ZipContentsDialog.cs");
			list.Add("ZipContentsDialog.Designer.cs");
			list.Add("FolderBrowserDialogEx.cs");
			return new Class747(Enum34.const_1, list, list_, list_2);
		}

		private static Class747 smethod_3()
		{
			List<string> list = new List<string>(1);
			List<string> list2 = new List<string>(1);
			list.Add("System.dll");
			list2.Add("CommandLineSelfExtractorStub.cs");
			return new Class747(Enum34.const_0, list, null, list2);
		}
	}

	private sealed class Class748 : IEnumerator<Class744>, IEnumerator, IDisposable
	{
		private Class744 class744_0;

		private int int_0;

		public Class746 class746_0;

		public Class744 class744_1;

		public Dictionary<string, Class744>.ValueCollection.Enumerator enumerator_0;

		Class744 IEnumerator<Class744>.Current => class744_0;

		object IEnumerator.Current => class744_0;

		private bool MoveNext()
		{
			try
			{
				switch (int_0)
				{
				case 0:
					int_0 = -1;
					enumerator_0 = class746_0.dictionary_0.Values.GetEnumerator();
					int_0 = 1;
					goto IL_004d;
				case 2:
					int_0 = 1;
					goto IL_004d;
				default:
					{
						return false;
					}
					IL_004d:
					if (!enumerator_0.MoveNext())
					{
						int_0 = -1;
						((IDisposable)enumerator_0).Dispose();
						goto default;
					}
					class744_1 = enumerator_0.Current;
					class744_0 = class744_1;
					int_0 = 2;
					return true;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		void IDisposable.Dispose()
		{
			switch (int_0)
			{
			case 1:
			case 2:
				try
				{
					break;
				}
				finally
				{
					int_0 = -1;
					((IDisposable)enumerator_0).Dispose();
				}
			}
		}

		public Class748(int int_1)
		{
			int_0 = int_1;
		}
	}

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private int int_0;

	private bool bool_3;

	private Enum42 enum42_0;

	private Enum26 enum26_0;

	private Delegate3 delegate3_0;

	private TextWriter textWriter_0;

	private bool bool_4;

	private Stream stream_0;

	private Stream stream_1;

	private ushort ushort_0;

	private ushort ushort_1;

	private uint uint_0;

	private int int_1;

	private uint uint_1;

	private Enum31 enum31_0;

	private bool bool_5;

	private Dictionary<string, Class744> dictionary_0;

	private List<Class744> list_0;

	private string string_0;

	private string string_1;

	private string string_2;

	internal string string_3;

	private bool bool_6 = true;

	private bool bool_7;

	private Enum43 enum43_0;

	private Enum29 enum29_0 = Enum29.const_1;

	private bool bool_8;

	private string string_4;

	private bool bool_9;

	private bool bool_10;

	private string string_5;

	private bool bool_11 = true;

	private object object_0 = new object();

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private Enum24 enum24_0;

	private bool bool_15;

	private long long_0 = -1L;

	private uint uint_2;

	private long long_1;

	private bool? nullable_0;

	internal bool bool_16;

	private Encoding encoding_0 = Encoding.GetEncoding("IBM437");

	private Enum33 enum33_0;

	private static Encoding encoding_1 = Encoding.GetEncoding("IBM437");

	private int int_2 = int_4;

	internal Stream10 stream10_0;

	private long long_2;

	private int int_3 = 16;

	internal Enum32 enum32_0;

	private bool bool_17;

	public static readonly int int_4 = 32768;

	private EventHandler<EventArgs3> eventHandler_0;

	private EventHandler<EventArgs1> eventHandler_1;

	private long long_3 = -99L;

	private EventHandler<EventArgs4> eventHandler_2;

	private EventHandler<EventArgs2> eventHandler_3;

	private EventHandler<EventArgs5> eventHandler_4;

	private static Class747[] class747_0 = new Class747[2]
	{
		Class747.smethod_0(),
		Class747.smethod_1()
	};

	public Class744 this[int int_5] => method_37()[int_5];

	public Class744 this[string string_6]
	{
		get
		{
			string text = Class742.smethod_1(string_6);
			if (dictionary_0.ContainsKey(text))
			{
				return dictionary_0[text];
			}
			text = text.Replace("/", "\\");
			if (dictionary_0.ContainsKey(text))
			{
				return dictionary_0[text];
			}
			return null;
		}
	}

	public string Name => string_0;

	public string Comment
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
			bool_9 = true;
		}
	}

	public int Count => dictionary_0.Count;

	public Class744 method_0(string string_6, Stream stream_2)
	{
		Class744 @class = Class744.smethod_3(string_6, stream_2);
		@class.method_6(DateTime.Now, DateTime.Now, DateTime.Now);
		if (method_15())
		{
			method_23().WriteLine("adding {0}...", string_6);
		}
		return method_3(@class);
	}

	internal void Add(Class1007 class1007_0, string string_6)
	{
		method_0(string_6, class1007_0.GetSource());
	}

	public void method_1()
	{
	}

	public void method_2()
	{
	}

	private Class744 method_3(Class744 class744_0)
	{
		class744_0.class751_0 = new Class751(this);
		class744_0.method_13(method_14());
		class744_0.method_15(method_12());
		class744_0.method_23(method_25());
		class744_0.method_25(method_26());
		class744_0.method_28(method_28());
		class744_0.method_30(method_19());
		class744_0.method_32(method_21());
		class744_0.Password = string_3;
		class744_0.method_21(method_27());
		class744_0.method_7(bool_6);
		class744_0.method_8(bool_7);
		method_4(class744_0.FileName, class744_0);
		method_62(class744_0);
		return class744_0;
	}

	internal void method_4(string string_6, Class744 class744_0)
	{
		dictionary_0.Add(string_6, class744_0);
		list_0 = null;
		bool_9 = true;
	}

	[SpecialName]
	public bool method_5()
	{
		return bool_0;
	}

	[SpecialName]
	public bool method_6()
	{
		return bool_1;
	}

	[SpecialName]
	public void method_7(bool bool_18)
	{
		bool_2 = bool_18;
	}

	[SpecialName]
	public int method_8()
	{
		return int_2;
	}

	[SpecialName]
	public int method_9()
	{
		return int_0;
	}

	[SpecialName]
	public bool method_10()
	{
		return bool_3;
	}

	[SpecialName]
	public Enum43 method_11()
	{
		return enum43_0;
	}

	[SpecialName]
	public Enum42 method_12()
	{
		return enum42_0;
	}

	[SpecialName]
	public void method_13(Enum42 enum42_1)
	{
		enum42_0 = enum42_1;
	}

	[SpecialName]
	public Enum29 method_14()
	{
		return enum29_0;
	}

	[SpecialName]
	internal bool method_15()
	{
		return textWriter_0 != null;
	}

	[SpecialName]
	public bool method_16()
	{
		return bool_4;
	}

	[SpecialName]
	public Enum32 method_17()
	{
		return enum32_0;
	}

	[SpecialName]
	public void method_18(Enum32 enum32_1)
	{
		enum32_0 = enum32_1;
	}

	[SpecialName]
	public Encoding method_19()
	{
		return encoding_0;
	}

	[SpecialName]
	public void method_20(Encoding encoding_2)
	{
		encoding_0 = encoding_2;
	}

	[SpecialName]
	public Enum33 method_21()
	{
		return enum33_0;
	}

	[SpecialName]
	public void method_22(Enum33 enum33_1)
	{
		enum33_0 = enum33_1;
	}

	[SpecialName]
	public static Encoding smethod_0()
	{
		return encoding_1;
	}

	[SpecialName]
	public TextWriter method_23()
	{
		return textWriter_0;
	}

	[SpecialName]
	public string method_24()
	{
		return string_5;
	}

	[SpecialName]
	public Enum26 method_25()
	{
		return enum26_0;
	}

	[SpecialName]
	public Enum31 method_26()
	{
		if (eventHandler_4 != null)
		{
			enum31_0 = Enum31.const_3;
		}
		return enum31_0;
	}

	[SpecialName]
	public Enum24 method_27()
	{
		return enum24_0;
	}

	[SpecialName]
	public Delegate3 method_28()
	{
		return delegate3_0;
	}

	[SpecialName]
	public int method_29()
	{
		return int_1;
	}

	[SpecialName]
	public void method_30(long long_4)
	{
		if (long_4 != 0 && long_4 != -1 && long_4 < 65536)
		{
			throw new ArgumentOutOfRangeException("ParallelDeflateThreshold should be -1, 0, or > 65536");
		}
		long_2 = long_4;
	}

	[SpecialName]
	public long method_31()
	{
		return long_2;
	}

	[SpecialName]
	public int method_32()
	{
		return int_3;
	}

	public override string ToString()
	{
		return $"ZipFile::{Name}";
	}

	internal void method_33()
	{
		bool_9 = true;
	}

	internal Stream method_34(uint uint_3)
	{
		if (uint_3 + 1 != uint_0 && (uint_3 != 0 || uint_0 != 0))
		{
			return Stream7.smethod_0(string_1 ?? string_0, uint_3, uint_0);
		}
		return method_46();
	}

	internal void Reset(bool bool_18)
	{
		if (!bool_15)
		{
			return;
		}
		using (Class746 @class = new Class746())
		{
			@class.string_1 = (@class.string_0 = (bool_18 ? (string_1 ?? string_0) : string_0));
			@class.method_20(method_19());
			@class.method_22(method_21());
			smethod_1(@class);
			foreach (Class744 item in @class)
			{
				using IEnumerator<Class744> enumerator2 = GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Class744 current2 = enumerator2.Current;
					if (item.FileName == current2.FileName)
					{
						current2.method_77(item);
						break;
					}
				}
			}
		}
		bool_15 = false;
	}

	public Class746()
	{
		method_36(null, null);
	}

	private void method_35()
	{
		StringComparer comparer = (method_16() ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
		dictionary_0 = ((dictionary_0 == null) ? new Dictionary<string, Class744>(comparer) : new Dictionary<string, Class744>(dictionary_0, comparer));
	}

	private void method_36(string string_6, TextWriter textWriter_1)
	{
		string_0 = string_6;
		textWriter_0 = textWriter_1;
		bool_9 = true;
		method_7(bool_18: true);
		method_13(Enum42.const_8);
		method_30(524288L);
		method_35();
		if (File.Exists(string_0))
		{
			if (method_5())
			{
				smethod_5(this);
			}
			else
			{
				smethod_1(this);
			}
			bool_8 = true;
		}
	}

	[SpecialName]
	private List<Class744> method_37()
	{
		if (list_0 == null)
		{
			list_0 = new List<Class744>(dictionary_0.Values);
		}
		return list_0;
	}

	public Class744 method_38(string string_6)
	{
		return this[string_6];
	}

	public Stream method_39(Class744 class744_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		class744_0.method_39(memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	public int method_40(string string_6, bool bool_18)
	{
		if (method_38(string_6) == null)
		{
			return -1;
		}
		return 1;
	}

	[SpecialName]
	public ICollection<Class744> method_41()
	{
		return dictionary_0.Values;
	}

	[SpecialName]
	public ICollection<Class744> method_42()
	{
		List<Class744> list = new List<Class744>();
		foreach (Class744 item in method_41())
		{
			list.Add(item);
		}
		list.Sort(new Class749(method_16()));
		return list.AsReadOnly();
	}

	public void method_43(Class744 class744_0)
	{
		if (class744_0 == null)
		{
			throw new ArgumentNullException("entry");
		}
		dictionary_0.Remove(Class742.smethod_1(class744_0.FileName));
		list_0 = null;
		bool_9 = true;
	}

	public void method_44(string string_6)
	{
		string string_7 = Class744.smethod_2(string_6, null);
		Class744 @class = this[string_7];
		if (@class == null)
		{
			throw new ArgumentException("The entry you specified was not found in the zip archive.");
		}
		method_43(@class);
	}

	public void method_45(string string_6)
	{
		method_44(string_6);
	}

	public void Dispose()
	{
		Dispose(bool_18: true);
		GC.SuppressFinalize(this);
	}

	public void Close()
	{
		Dispose();
	}

	protected virtual void Dispose(bool bool_18)
	{
		if (bool_5)
		{
			return;
		}
		if (bool_18)
		{
			if (bool_11 && stream_0 != null)
			{
				stream_0.Dispose();
				stream_0 = null;
			}
			if (string_4 != null && string_0 != null && stream_1 != null)
			{
				stream_1.Dispose();
				stream_1 = null;
			}
			if (stream10_0 != null)
			{
				stream10_0.Dispose();
				stream10_0 = null;
			}
		}
		bool_5 = true;
	}

	[SpecialName]
	internal Stream method_46()
	{
		if (stream_0 == null && (string_1 != null || string_0 != null))
		{
			stream_0 = File.Open(string_1 ?? string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			bool_11 = true;
		}
		return stream_0;
	}

	[SpecialName]
	private Stream method_47()
	{
		if (stream_1 != null)
		{
			return stream_1;
		}
		if (string_0 == null)
		{
			return stream_1;
		}
		if (int_1 != 0)
		{
			stream_1 = Stream7.smethod_1(string_0, int_1);
			return stream_1;
		}
		Class742.smethod_14(method_24() ?? Path.GetDirectoryName(string_0), out stream_1, out string_4);
		return stream_1;
	}

	[SpecialName]
	private string method_48()
	{
		if (string_0 == null)
		{
			return "(stream)";
		}
		return string_0;
	}

	internal bool method_49(Class744 class744_0, long long_4, long long_5)
	{
		EventHandler<EventArgs3> eventHandler = eventHandler_0;
		if (eventHandler != null)
		{
			EventArgs3 eventArgs = EventArgs3.smethod_0(method_48(), class744_0, long_4, long_5);
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_12 = true;
			}
		}
		return bool_12;
	}

	private void method_50(int int_5, Class744 class744_0, bool bool_18)
	{
		EventHandler<EventArgs3> eventHandler = eventHandler_0;
		if (eventHandler != null)
		{
			EventArgs3 eventArgs = new EventArgs3(method_48(), bool_18, dictionary_0.Count, int_5, class744_0);
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_12 = true;
			}
		}
	}

	private void method_51(Enum25 enum25_0)
	{
		EventHandler<EventArgs3> eventHandler = eventHandler_0;
		if (eventHandler != null)
		{
			EventArgs3 eventArgs = new EventArgs3(method_48(), enum25_0);
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_12 = true;
			}
		}
	}

	private void method_52()
	{
		EventHandler<EventArgs3> eventHandler = eventHandler_0;
		if (eventHandler != null)
		{
			EventArgs3 eventArgs = EventArgs3.smethod_1(method_48());
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_12 = true;
			}
		}
	}

	private void method_53()
	{
		EventHandler<EventArgs3> eventHandler = eventHandler_0;
		if (eventHandler != null)
		{
			EventArgs3 e = EventArgs3.smethod_2(method_48());
			eventHandler(this, e);
		}
	}

	private void method_54()
	{
		EventHandler<EventArgs1> eventHandler = eventHandler_1;
		if (eventHandler != null)
		{
			EventArgs1 e = EventArgs1.smethod_2(method_48());
			eventHandler(this, e);
		}
	}

	private void method_55()
	{
		EventHandler<EventArgs1> eventHandler = eventHandler_1;
		if (eventHandler != null)
		{
			EventArgs1 e = EventArgs1.smethod_4(method_48());
			eventHandler(this, e);
		}
	}

	internal void method_56(Class744 class744_0)
	{
		EventHandler<EventArgs1> eventHandler = eventHandler_1;
		if (eventHandler != null)
		{
			EventArgs1 e = EventArgs1.smethod_3(method_48(), class744_0, method_46().Position, method_58());
			eventHandler(this, e);
		}
	}

	internal void method_57(bool bool_18, Class744 class744_0)
	{
		EventHandler<EventArgs1> eventHandler = eventHandler_1;
		if (eventHandler != null)
		{
			EventArgs1 e = (bool_18 ? EventArgs1.smethod_0(method_48(), dictionary_0.Count) : EventArgs1.smethod_1(method_48(), class744_0, dictionary_0.Count));
			eventHandler(this, e);
		}
	}

	[SpecialName]
	private long method_58()
	{
		if (long_3 == -99)
		{
			long_3 = (bool_11 ? Class742.smethod_0(string_0) : (-1));
		}
		return long_3;
	}

	internal bool method_59(Class744 class744_0, long long_4, long long_5)
	{
		EventHandler<EventArgs4> eventHandler = eventHandler_2;
		if (eventHandler != null)
		{
			EventArgs4 eventArgs = EventArgs4.smethod_3(method_48(), class744_0, long_4, long_5);
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_13 = true;
			}
		}
		return bool_13;
	}

	internal bool method_60(Class744 class744_0, string string_6, bool bool_18)
	{
		EventHandler<EventArgs4> eventHandler = eventHandler_2;
		if (eventHandler != null)
		{
			EventArgs4 eventArgs = (bool_18 ? EventArgs4.smethod_0(method_48(), class744_0, string_6) : EventArgs4.smethod_2(method_48(), class744_0, string_6));
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_13 = true;
			}
		}
		return bool_13;
	}

	internal bool method_61(Class744 class744_0, string string_6)
	{
		EventHandler<EventArgs4> eventHandler = eventHandler_2;
		if (eventHandler != null)
		{
			EventArgs4 eventArgs = EventArgs4.smethod_1(method_48(), class744_0, string_6);
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_13 = true;
			}
		}
		return bool_13;
	}

	internal void method_62(Class744 class744_0)
	{
		EventHandler<EventArgs2> eventHandler = eventHandler_3;
		if (eventHandler != null)
		{
			EventArgs2 eventArgs = EventArgs2.smethod_0(method_48(), class744_0, dictionary_0.Count);
			eventHandler(this, eventArgs);
			if (eventArgs.method_2())
			{
				bool_14 = true;
			}
		}
	}

	internal bool method_63(Class744 class744_0, Exception exception_0)
	{
		if (eventHandler_4 != null)
		{
			lock (object_0)
			{
				EventArgs5 eventArgs = EventArgs5.smethod_0(Name, class744_0, exception_0);
				eventHandler_4(this, eventArgs);
				if (eventArgs.method_2())
				{
					bool_12 = true;
				}
			}
		}
		return bool_12;
	}

	public static Class746 Read(Stream stream_2)
	{
		return Read(stream_2, null, null, null);
	}

	private static Class746 Read(Stream stream_2, TextWriter textWriter_1, Encoding encoding_2, EventHandler<EventArgs1> eventHandler_5)
	{
		if (stream_2 == null)
		{
			throw new ArgumentNullException("zipStream");
		}
		Class746 @class = new Class746();
		@class.textWriter_0 = textWriter_1;
		@class.encoding_0 = encoding_2 ?? smethod_0();
		@class.enum33_0 = Enum33.const_3;
		if (eventHandler_5 != null)
		{
			@class.eventHandler_1 = (EventHandler<EventArgs1>)Delegate.Combine(@class.eventHandler_1, eventHandler_5);
		}
		@class.stream_0 = ((stream_2.Position == 0) ? stream_2 : new Stream2(stream_2));
		@class.bool_11 = false;
		if (@class.method_15())
		{
			@class.textWriter_0.WriteLine("reading from stream...");
		}
		smethod_1(@class);
		return @class;
	}

	private static void smethod_1(Class746 class746_0)
	{
		Stream stream = class746_0.method_46();
		try
		{
			class746_0.string_1 = class746_0.string_0;
			if (!stream.CanSeek)
			{
				smethod_5(class746_0);
				return;
			}
			class746_0.method_54();
			uint num = smethod_3(stream);
			if (num == 101010256)
			{
				return;
			}
			int num2 = 0;
			bool flag = false;
			long num3 = stream.Length - 64;
			long num4 = Math.Max(stream.Length - 16384, 10L);
			do
			{
				if (num3 < 0)
				{
					num3 = 0L;
				}
				stream.Seek(num3, SeekOrigin.Begin);
				long num5 = Class742.smethod_10(stream, 101010256);
				if (num5 != -1)
				{
					flag = true;
					continue;
				}
				if (num3 == 0)
				{
					break;
				}
				num2++;
				num3 -= 32 * (num2 + 1) * num2;
			}
			while (!flag && num3 > num4);
			if (flag)
			{
				class746_0.long_0 = stream.Position - 4;
				byte[] array = new byte[16];
				stream.Read(array, 0, array.Length);
				class746_0.uint_0 = BitConverter.ToUInt16(array, 2);
				if (class746_0.uint_0 == 65535)
				{
					throw new Exception1("Spanned archives with more than 65534 segments are not supported at this time.");
				}
				class746_0.uint_0++;
				uint num6 = BitConverter.ToUInt32(array, 12);
				if (num6 == uint.MaxValue)
				{
					smethod_2(class746_0);
				}
				else
				{
					class746_0.uint_2 = num6;
					stream.Seek(num6, SeekOrigin.Begin);
				}
				smethod_4(class746_0);
			}
			else
			{
				stream.Seek(0L, SeekOrigin.Begin);
				smethod_5(class746_0);
			}
		}
		catch (Exception exception_)
		{
			if (class746_0.bool_11 && class746_0.stream_0 != null)
			{
				class746_0.stream_0.Dispose();
				class746_0.stream_0 = null;
			}
			throw new Exception1("Cannot read that as a ZipFile", exception_);
		}
		class746_0.bool_9 = false;
	}

	private static void smethod_2(Class746 class746_0)
	{
		Stream stream = class746_0.method_46();
		byte[] array = new byte[16];
		stream.Seek(-40L, SeekOrigin.Current);
		stream.Read(array, 0, 16);
		long offset = BitConverter.ToInt64(array, 8);
		class746_0.uint_2 = uint.MaxValue;
		class746_0.long_1 = offset;
		stream.Seek(offset, SeekOrigin.Begin);
		uint num = (uint)Class742.smethod_8(stream);
		if (num != 101075792)
		{
			throw new Exception3($"  Bad signature (0x{num:X8}) looking for ZIP64 EoCD Record at position 0x{stream.Position:X8}");
		}
		stream.Read(array, 0, 8);
		long num2 = BitConverter.ToInt64(array, 0);
		array = new byte[num2];
		stream.Read(array, 0, array.Length);
		offset = BitConverter.ToInt64(array, 36);
		stream.Seek(offset, SeekOrigin.Begin);
	}

	private static uint smethod_3(Stream stream_2)
	{
		return (uint)Class742.smethod_8(stream_2);
	}

	private static void smethod_4(Class746 class746_0)
	{
		bool flag = false;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Class744 @class;
		while ((@class = Class744.smethod_0(class746_0, dictionary)) != null)
		{
			@class.method_1();
			class746_0.method_57(bool_18: true, null);
			if (class746_0.method_15())
			{
				class746_0.method_23().WriteLine("entry {0}", @class.FileName);
			}
			class746_0.dictionary_0.Add(@class.FileName, @class);
			if (@class.bool_10)
			{
				flag = true;
			}
			dictionary.Add(@class.FileName, null);
		}
		if (flag)
		{
			class746_0.method_18(Enum32.const_3);
		}
		if (class746_0.long_0 > 0)
		{
			class746_0.method_46().Seek(class746_0.long_0, SeekOrigin.Begin);
		}
		smethod_6(class746_0);
		if (class746_0.method_15() && !string.IsNullOrEmpty(class746_0.Comment))
		{
			class746_0.method_23().WriteLine("Zip file Comment: {0}", class746_0.Comment);
		}
		if (class746_0.method_15())
		{
			class746_0.method_23().WriteLine("read in {0} entries.", class746_0.dictionary_0.Count);
		}
		class746_0.method_55();
	}

	private static void smethod_5(Class746 class746_0)
	{
		class746_0.method_54();
		class746_0.dictionary_0 = new Dictionary<string, Class744>();
		if (class746_0.method_15())
		{
			if (class746_0.Name == null)
			{
				class746_0.method_23().WriteLine("Reading zip from stream...");
			}
			else
			{
				class746_0.method_23().WriteLine("Reading zip {0}...", class746_0.Name);
			}
		}
		bool flag = true;
		Class751 class751_ = new Class751(class746_0);
		Class744 @class;
		while ((@class = Class744.smethod_11(class751_, flag)) != null)
		{
			if (class746_0.method_15())
			{
				class746_0.method_23().WriteLine("  {0}", @class.FileName);
			}
			class746_0.dictionary_0.Add(@class.FileName, @class);
			flag = false;
		}
		try
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Class744 class2;
			while ((class2 = Class744.smethod_0(class746_0, dictionary)) != null)
			{
				Class744 class3 = class746_0.dictionary_0[class2.FileName];
				if (class3 != null)
				{
					class3.string_2 = class2.Comment;
					if (class2.method_18())
					{
						class3.method_33();
					}
				}
				dictionary.Add(class2.FileName, null);
			}
			if (class746_0.long_0 > 0)
			{
				class746_0.method_46().Seek(class746_0.long_0, SeekOrigin.Begin);
			}
			smethod_6(class746_0);
			if (class746_0.method_15() && !string.IsNullOrEmpty(class746_0.Comment))
			{
				class746_0.method_23().WriteLine("Zip file Comment: {0}", class746_0.Comment);
			}
		}
		catch (Exception1)
		{
		}
		catch (IOException)
		{
		}
		class746_0.method_55();
	}

	private static void smethod_6(Class746 class746_0)
	{
		Stream stream = class746_0.method_46();
		int num = Class742.smethod_6(stream);
		byte[] array = null;
		int num2 = 0;
		if ((long)num == 101075792)
		{
			array = new byte[52];
			stream.Read(array, 0, array.Length);
			long num3 = BitConverter.ToInt64(array, 0);
			if (num3 < 44)
			{
				throw new Exception1("Bad size in the ZIP64 Central Directory.");
			}
			class746_0.ushort_0 = BitConverter.ToUInt16(array, num2);
			num2 += 2;
			class746_0.ushort_1 = BitConverter.ToUInt16(array, num2);
			num2 += 2;
			class746_0.uint_0 = BitConverter.ToUInt32(array, num2);
			num2 += 2;
			array = new byte[num3 - 44];
			stream.Read(array, 0, array.Length);
			num = Class742.smethod_6(stream);
			if ((long)num != 117853008)
			{
				throw new Exception1("Inconsistent metadata in the ZIP64 Central Directory.");
			}
			array = new byte[16];
			stream.Read(array, 0, array.Length);
			num = Class742.smethod_6(stream);
		}
		if ((long)num != 101010256)
		{
			stream.Seek(-4L, SeekOrigin.Current);
			throw new Exception3($"Bad signature ({num:X8}) at position 0x{stream.Position:X8}");
		}
		array = new byte[16];
		class746_0.method_46().Read(array, 0, array.Length);
		if (class746_0.uint_0 == 0)
		{
			class746_0.uint_0 = BitConverter.ToUInt16(array, 2);
		}
		smethod_7(class746_0);
	}

	private static void smethod_7(Class746 class746_0)
	{
		byte[] array = new byte[2];
		class746_0.method_46().Read(array, 0, array.Length);
		short num = (short)(array[0] + array[1] * 256);
		if (num > 0)
		{
			array = new byte[num];
			class746_0.method_46().Read(array, 0, array.Length);
			string @string = class746_0.method_19().GetString(array, 0, array.Length);
			class746_0.Comment = @string;
		}
	}

	private void method_64(string string_6)
	{
		bool flag = false;
		int num = 3;
		for (int i = 0; i < num; i++)
		{
			if (flag)
			{
				break;
			}
			try
			{
				File.Delete(string_6);
				flag = true;
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("************************************************** Retry delete.");
				Thread.Sleep(200 + i * 200);
			}
		}
	}

	public void Save()
	{
		try
		{
			bool flag = false;
			bool_12 = false;
			uint_1 = 0u;
			method_52();
			if (method_47() == null)
			{
				throw new Exception4("You haven't specified where to save the zip.");
			}
			if (string_0 != null && string_0.EndsWith(".exe") && !bool_17)
			{
				throw new Exception4("You specified an EXE for a plain zip file.");
			}
			if (!bool_9)
			{
				method_53();
				if (method_15())
				{
					method_23().WriteLine("No save is necessary....");
				}
				return;
			}
			Reset(bool_18: true);
			if (method_15())
			{
				method_23().WriteLine("saving....");
			}
			if (dictionary_0.Count >= 65535 && enum32_0 == Enum32.const_0)
			{
				throw new Exception1("The number of entries is 65535 or greater. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
			}
			int num = 0;
			ICollection<Class744> collection = (method_6() ? method_42() : method_41());
			foreach (Class744 item in collection)
			{
				method_50(num, item, bool_18: true);
				item.Write(method_47());
				if (!bool_12)
				{
					num++;
					method_50(num, item, bool_18: false);
					if (!bool_12)
					{
						if (item.method_26())
						{
							flag |= item.method_11().Value;
						}
						continue;
					}
					break;
				}
				break;
			}
			if (bool_12)
			{
				return;
			}
			Stream7 stream = method_47() as Stream7;
			uint_1 = stream?.method_2() ?? 1;
			bool flag2 = Class750.smethod_0(method_47(), collection, uint_1, enum32_0, Comment, new Class751(this));
			method_51(Enum25.const_12);
			bool_10 = true;
			bool_9 = false;
			flag = flag || flag2;
			nullable_0 = flag;
			if (string_0 != null && (string_4 != null || stream != null))
			{
				method_47().Dispose();
				if (bool_12)
				{
					return;
				}
				if (bool_8 && stream_0 != null)
				{
					stream_0.Close();
					stream_0 = null;
					foreach (Class744 item2 in collection)
					{
						if (item2.stream_0 is Stream7 stream2)
						{
							stream2.Dispose();
						}
						item2.stream_0 = null;
					}
				}
				string text = null;
				if (File.Exists(string_0))
				{
					text = string_0 + "." + Path.GetRandomFileName();
					if (File.Exists(text))
					{
						method_64(text);
					}
					File.Move(string_0, text);
				}
				method_51(Enum25.const_13);
				File.Move((stream != null) ? stream.method_5() : string_4, string_0);
				method_51(Enum25.const_14);
				if (text != null)
				{
					try
					{
						if (File.Exists(text))
						{
							File.Delete(text);
						}
					}
					catch
					{
					}
				}
				bool_8 = true;
			}
			smethod_8(collection);
			method_53();
			bool_15 = true;
		}
		finally
		{
			method_66();
		}
	}

	private static void smethod_8(ICollection<Class744> icollection_0)
	{
		foreach (Class744 item in icollection_0)
		{
			item.method_89();
		}
	}

	private void method_65()
	{
		try
		{
			if (File.Exists(string_4))
			{
				File.Delete(string_4);
			}
		}
		catch (IOException ex)
		{
			if (method_15())
			{
				method_23().WriteLine("ZipFile::Save: could not delete temp file: {0}.", ex.Message);
			}
		}
	}

	private void method_66()
	{
		if (string_0 == null)
		{
			return;
		}
		if (stream_1 != null)
		{
			try
			{
				stream_1.Dispose();
			}
			catch (IOException)
			{
			}
		}
		stream_1 = null;
		if (string_4 != null)
		{
			method_65();
			string_4 = null;
		}
	}

	public void Save(Stream stream_2)
	{
		if (stream_2 == null)
		{
			throw new ArgumentNullException("outputStream");
		}
		if (!stream_2.CanWrite)
		{
			throw new ArgumentException("Must be a writable stream.", "outputStream");
		}
		string_0 = null;
		stream_1 = new Stream3(stream_2);
		bool_9 = true;
		bool_8 = false;
		Save();
	}

	public IEnumerator<Class744> GetEnumerator()
	{
		Class748 @class = new Class748(0);
		@class.class746_0 = this;
		return @class;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using ns218;

namespace ns276;

internal class Class6752 : IEnumerable, IDisposable
{
	private bool bool_0;

	private int int_0;

	private bool bool_1;

	private Enum914 enum914_0;

	public static readonly Encoding encoding_0 = Encoding.GetEncoding("IBM437");

	private Enum904 enum904_0;

	private Enum911 enum911_0;

	private Delegate2782 delegate2782_0;

	private Delegate2783 delegate2783_0;

	private TextWriter textWriter_0;

	private bool bool_2;

	private Stream stream_0;

	private Stream stream_1;

	private bool bool_3;

	private ArrayList arrayList_0;

	private bool bool_4;

	private string string_0;

	private string string_1;

	internal string string_2;

	private bool bool_5 = true;

	private bool bool_6;

	private Enum915 enum915_0;

	private long long_0;

	private bool bool_7;

	private string string_3;

	private bool bool_8;

	private bool bool_9;

	private string string_4;

	private bool bool_10 = true;

	private object object_0 = new object();

	private bool bool_11;

	private bool bool_12;

	private Enum903 enum903_0;

	private bool bool_13;

	private bool bool_14;

	private long long_1 = -1L;

	private Enum906 enum906_0;

	internal bool bool_15;

	private Encoding encoding_1 = Encoding.GetEncoding("IBM437");

	private int int_1 = 8192;

	internal Enum908 enum908_0;

	private EventHandler eventHandler_0;

	private EventHandler eventHandler_1;

	private long long_2 = -99L;

	private EventHandler eventHandler_2;

	private EventHandler eventHandler_3;

	private EventHandler eventHandler_4;

	public bool FullScan
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

	public int BufferSize
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int CodecBufferSize
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

	public bool FlattenFoldersOnExtract
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Enum915 Strategy
	{
		get
		{
			return enum915_0;
		}
		set
		{
			enum915_0 = value;
		}
	}

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Enum914 CompressionLevel
	{
		get
		{
			return enum914_0;
		}
		set
		{
			enum914_0 = value;
		}
	}

	public string Comment
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			bool_8 = true;
		}
	}

	public bool EmitTimesInWindowsFormatWhenSaving
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool EmitTimesInUnixFormatWhenSaving
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	internal bool Verbose => textWriter_0 != null;

	public bool CaseSensitiveRetrieval
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool UseUnicodeAsNecessary
	{
		get
		{
			return encoding_1 == Encoding.GetEncoding("UTF-8");
		}
		set
		{
			encoding_1 = (value ? Encoding.GetEncoding("UTF-8") : encoding_0);
		}
	}

	public Enum908 UseZip64WhenSaving
	{
		get
		{
			return enum908_0;
		}
		set
		{
			enum908_0 = value;
		}
	}

	public Enum906 RequiresZip64
	{
		get
		{
			if (arrayList_0.Count > 65534)
			{
				return Enum906.const_2;
			}
			if (bool_9 && !bool_8)
			{
				foreach (Class6751 item in arrayList_0)
				{
					if (item.RequiresZip64 == Enum906.const_2)
					{
						return Enum906.const_2;
					}
				}
				return Enum906.const_1;
			}
			return Enum906.const_0;
		}
	}

	public Enum906 OutputUsedZip64 => enum906_0;

	public Encoding ProvisionalAlternateEncoding
	{
		get
		{
			return encoding_1;
		}
		set
		{
			encoding_1 = value;
		}
	}

	public TextWriter StatusMessageTextWriter
	{
		get
		{
			return textWriter_0;
		}
		set
		{
			textWriter_0 = value;
		}
	}

	public bool ForceNoCompression
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public string TempFileFolder
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
			if (value == null || Directory.Exists(value))
			{
				return;
			}
			throw new FileNotFoundException($"That directory ({value}) does not exist.");
		}
	}

	public string Password
	{
		set
		{
			string_2 = value;
			if (string_2 == null)
			{
				Encryption = Enum903.const_0;
			}
			else if (Encryption == Enum903.const_0)
			{
				Encryption = Enum903.const_1;
			}
		}
	}

	public Enum904 ExtractExistingFile
	{
		get
		{
			return enum904_0;
		}
		set
		{
			enum904_0 = value;
		}
	}

	public Enum911 ZipErrorAction
	{
		get
		{
			return enum911_0;
		}
		set
		{
			enum911_0 = value;
		}
	}

	public Enum903 Encryption
	{
		get
		{
			return enum903_0;
		}
		set
		{
			if (value == Enum903.const_2)
			{
				throw new InvalidOperationException("You may not set Encryption to that value.");
			}
			enum903_0 = value;
		}
	}

	public Delegate2782 WillReadTwiceOnInflation
	{
		get
		{
			return delegate2782_0;
		}
		set
		{
			delegate2782_0 = value;
		}
	}

	public Delegate2783 WantCompression
	{
		get
		{
			return delegate2783_0;
		}
		set
		{
			delegate2783_0 = value;
		}
	}

	public static Version LibraryVersion => Assembly.GetExecutingAssembly().GetName().Version;

	internal Stream ReadStream
	{
		get
		{
			if (stream_0 == null && string_0 != null)
			{
				try
				{
					stream_0 = File.OpenRead(string_0);
					bool_10 = true;
				}
				catch (IOException innerException)
				{
					throw new Exception61("Error opening the file", innerException);
				}
			}
			return stream_0;
		}
	}

	public Class6751 this[int ix]
	{
		get
		{
			return (Class6751)arrayList_0[ix];
		}
		set
		{
			if (value != null)
			{
				throw new Exception61("You may not set this to a non-null ZipEntry value.", new ArgumentException("this[int]"));
			}
			method_2((Class6751)arrayList_0[ix]);
		}
	}

	public Class6751 this[string fileName]
	{
		get
		{
			foreach (Class6751 item in arrayList_0)
			{
				if (CaseSensitiveRetrieval)
				{
					if (!(item.FileName == fileName))
					{
						if (!(fileName.Replace("\\", "/") == item.FileName))
						{
							if (!(item.FileName.Replace("\\", "/") == fileName))
							{
								if (item.FileName.EndsWith("/"))
								{
									string text = item.FileName.Trim("/".ToCharArray());
									if (text == fileName)
									{
										return item;
									}
									if (fileName.Replace("\\", "/") == text)
									{
										return item;
									}
									if (text.Replace("\\", "/") == fileName)
									{
										return item;
									}
								}
								continue;
							}
							return item;
						}
						return item;
					}
					return item;
				}
				if (!Class5964.smethod_42(item.FileName, fileName))
				{
					if (!Class5964.smethod_42(fileName.Replace("\\", "/"), item.FileName))
					{
						if (!Class5964.smethod_42(item.FileName.Replace("\\", "/"), fileName))
						{
							if (item.FileName.EndsWith("/"))
							{
								string text2 = item.FileName.Trim("/".ToCharArray());
								if (Class5964.smethod_42(text2, fileName))
								{
									return item;
								}
								if (Class5964.smethod_42(fileName.Replace("\\", "/"), text2))
								{
									return item;
								}
								if (Class5964.smethod_42(text2.Replace("\\", "/"), fileName))
								{
									return item;
								}
							}
							continue;
						}
						return item;
					}
					return item;
				}
				return item;
			}
			return null;
		}
		set
		{
			if (value != null)
			{
				throw new ArgumentException("You may not set this to a non-null ZipEntry value.");
			}
			method_3(fileName);
		}
	}

	public ArrayList EntryFileNames
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			foreach (Class6751 item in arrayList_0)
			{
				arrayList.Add(item.FileName);
			}
			return arrayList;
		}
	}

	public ArrayList Entries => arrayList_0;

	public int Count => arrayList_0.Count;

	private Stream WriteStream
	{
		get
		{
			if (stream_1 == null && string_0 != null)
			{
				if (TempFileFolder == ".")
				{
					string_3 = Class6748.smethod_15();
				}
				else if (TempFileFolder != null)
				{
					string_3 = Path.Combine(TempFileFolder, Class6748.smethod_15());
				}
				else
				{
					string directoryName = Path.GetDirectoryName(string_0);
					string_3 = Path.Combine(directoryName, Class6748.smethod_15());
				}
				stream_1 = new FileStream(string_3, FileMode.CreateNew);
			}
			return stream_1;
		}
		set
		{
			if (value != null)
			{
				throw new Exception61("Whoa!", new ArgumentException("Cannot set the stream to a non-null value.", "value"));
			}
			stream_1 = null;
		}
	}

	private string ArchiveNameForEvent
	{
		get
		{
			if (string_0 == null)
			{
				return "(stream)";
			}
			return string_0;
		}
	}

	private long LengthOfReadStream
	{
		get
		{
			if (long_2 == -99L)
			{
				if (bool_10)
				{
					FileInfo fileInfo = new FileInfo(string_0);
					long_2 = fileInfo.Length;
				}
				else
				{
					long_2 = -1L;
				}
			}
			return long_2;
		}
	}

	internal long RelativeOffset => ReadStream.Position - long_0;

	public event EventHandler SaveProgress
	{
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ReadProgress
	{
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ExtractProgress
	{
		add
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler AddProgress
	{
		add
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler ZipError
	{
		add
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public override string ToString()
	{
		return $"ZipFile/{Name}";
	}

	internal void method_0()
	{
		bool_8 = true;
	}

	internal void Reset()
	{
		if (!bool_13)
		{
			return;
		}
		Class6752 @class = new Class6752();
		@class.string_0 = string_0;
		@class.ProvisionalAlternateEncoding = ProvisionalAlternateEncoding;
		smethod_3(@class);
		foreach (Class6751 item in (IEnumerable)@class)
		{
			foreach (Class6751 item2 in (IEnumerable)this)
			{
				if (item.FileName == item2.FileName)
				{
					item2.method_55(item);
				}
			}
		}
		bool_13 = false;
	}

	public Class6752(string fileName)
	{
		try
		{
			method_1(fileName, null);
		}
		catch (Exception innerException)
		{
			throw new Exception61($"{fileName} is not a valid zip file", innerException);
		}
	}

	public Class6752(string fileName, Encoding encoding)
	{
		try
		{
			method_1(fileName, null);
			ProvisionalAlternateEncoding = encoding;
		}
		catch (Exception innerException)
		{
			throw new Exception61($"{fileName} is not a valid zip file", innerException);
		}
	}

	public Class6752()
	{
		method_1(null, null);
	}

	public Class6752(Encoding encoding)
	{
		method_1(null, null);
		ProvisionalAlternateEncoding = encoding;
	}

	public Class6752(string fileName, TextWriter statusMessageWriter)
	{
		try
		{
			method_1(fileName, statusMessageWriter);
		}
		catch (Exception innerException)
		{
			throw new Exception61($"{fileName} is not a valid zip file", innerException);
		}
	}

	public Class6752(string fileName, TextWriter statusMessageWriter, Encoding encoding)
	{
		try
		{
			method_1(fileName, statusMessageWriter);
			ProvisionalAlternateEncoding = encoding;
		}
		catch (Exception innerException)
		{
			throw new Exception61($"{fileName} is not a valid zip file", innerException);
		}
	}

	public void Initialize(string fileName)
	{
		try
		{
			method_1(fileName, null);
		}
		catch (Exception innerException)
		{
			throw new Exception61($"{fileName} is not a valid zip file", innerException);
		}
	}

	private void method_1(string zipFileName, TextWriter statusMessageWriter)
	{
		string_0 = zipFileName;
		textWriter_0 = statusMessageWriter;
		bool_8 = true;
		CompressionLevel = Enum914.const_8;
		arrayList_0 = new ArrayList();
		if (File.Exists(string_0))
		{
			if (FullScan)
			{
				smethod_7(this);
			}
			else
			{
				smethod_3(this);
			}
			bool_7 = true;
		}
	}

	public void method_2(Class6751 entry)
	{
		if (!arrayList_0.Contains(entry))
		{
			throw new ArgumentException("The entry you specified does not exist in the zip archive.");
		}
		arrayList_0.Remove(entry);
		bool_8 = true;
	}

	public void method_3(string fileName)
	{
		string fileName2 = Class6751.smethod_0(fileName, null);
		Class6751 @class = this[fileName2];
		if (@class == null)
		{
			throw new ArgumentException("The entry you specified was not found in the zip archive.");
		}
		method_2(@class);
	}

	~Class6752()
	{
		Dispose(disposeManagedResources: false);
	}

	public void Dispose()
	{
		Dispose(disposeManagedResources: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposeManagedResources)
	{
		if (bool_3)
		{
			return;
		}
		if (disposeManagedResources)
		{
			if (bool_10 && stream_0 != null)
			{
				stream_0.Close();
				stream_0 = null;
			}
			if (string_3 != null && string_0 != null && stream_1 != null)
			{
				stream_1.Close();
				stream_1 = null;
			}
		}
		bool_3 = true;
	}

	public Class6751 method_4(string fileOrDirectoryName)
	{
		return method_5(fileOrDirectoryName, null);
	}

	public Class6751 method_5(string fileOrDirectoryName, string directoryPathInArchive)
	{
		if (File.Exists(fileOrDirectoryName))
		{
			return method_7(fileOrDirectoryName, directoryPathInArchive);
		}
		if (!Directory.Exists(fileOrDirectoryName))
		{
			throw new FileNotFoundException($"That file or directory ({fileOrDirectoryName}) does not exist!");
		}
		return method_34(fileOrDirectoryName, directoryPathInArchive);
	}

	public Class6751 method_6(string fileName)
	{
		return method_7(fileName, null);
	}

	public Class6751 method_7(string fileName, string directoryPathInArchive)
	{
		string nameInArchive = Class6751.smethod_0(fileName, directoryPathInArchive);
		Class6751 @class = Class6751.smethod_1(fileName, nameInArchive);
		@class.ForceNoCompression = ForceNoCompression;
		@class.ExtractExistingFile = ExtractExistingFile;
		@class.ZipErrorAction = ZipErrorAction;
		@class.WillReadTwiceOnInflation = WillReadTwiceOnInflation;
		@class.WantCompression = WantCompression;
		@class.ProvisionalAlternateEncoding = ProvisionalAlternateEncoding;
		@class.class6752_0 = this;
		@class.Encryption = Encryption;
		@class.Password = string_2;
		@class.EmitTimesInWindowsFormatWhenSaving = bool_5;
		@class.EmitTimesInUnixFormatWhenSaving = bool_6;
		if (Verbose)
		{
			StatusMessageTextWriter.WriteLine("adding {0}...", fileName);
		}
		method_32(@class);
		arrayList_0.Add(@class);
		method_55(@class);
		bool_8 = true;
		return @class;
	}

	public void method_8(ArrayList entriesToRemove)
	{
		foreach (object item in entriesToRemove)
		{
			if (item is Class6751 entry)
			{
				method_2(entry);
			}
			else if (item is string fileName)
			{
				method_3(fileName);
			}
		}
	}

	public void method_9(ArrayList fileNames)
	{
		method_11(fileNames, null);
	}

	public void method_10(ArrayList fileNames)
	{
		method_13(fileNames, null);
	}

	public void method_11(ArrayList fileNames, string directoryPathInArchive)
	{
		method_12(fileNames, preserveDirHierarchy: false, directoryPathInArchive);
	}

	public void method_12(ArrayList fileNames, bool preserveDirHierarchy, string directoryPathInArchive)
	{
		method_53();
		if (preserveDirHierarchy)
		{
			foreach (string fileName2 in fileNames)
			{
				if (directoryPathInArchive != null)
				{
					string directoryPathInArchive2 = Class6748.smethod_0(Path.Combine(directoryPathInArchive, Path.GetDirectoryName(fileName2)));
					method_7(fileName2, directoryPathInArchive2);
				}
				else
				{
					method_7(fileName2, null);
				}
			}
		}
		else
		{
			foreach (string fileName3 in fileNames)
			{
				method_7(fileName3, directoryPathInArchive);
			}
		}
		method_54();
	}

	public void method_13(ArrayList fileNames, string directoryPathInArchive)
	{
		method_53();
		foreach (string fileName in fileNames)
		{
			method_15(fileName, directoryPathInArchive);
		}
		method_54();
	}

	public Class6751 method_14(string fileName)
	{
		return method_15(fileName, null);
	}

	public Class6751 method_15(string fileName, string directoryPathInArchive)
	{
		string fileName2 = Class6751.smethod_0(fileName, directoryPathInArchive);
		if (this[fileName2] != null)
		{
			method_3(fileName2);
		}
		return method_7(fileName, directoryPathInArchive);
	}

	public Class6751 method_16(string directoryName)
	{
		return method_17(directoryName, null);
	}

	public Class6751 method_17(string directoryName, string directoryPathInArchive)
	{
		return method_36(directoryName, directoryPathInArchive, Enum901.const_1);
	}

	public void method_18(string itemName)
	{
		method_19(itemName, null);
	}

	public void method_19(string itemName, string directoryPathInArchive)
	{
		if (File.Exists(itemName))
		{
			method_15(itemName, directoryPathInArchive);
			return;
		}
		if (!Directory.Exists(itemName))
		{
			throw new FileNotFoundException($"That file or directory ({itemName}) does not exist!");
		}
		method_17(itemName, directoryPathInArchive);
	}

	[Obsolete("Please use method AddEntry(string, string, System.IO.Stream))")]
	public Class6751 method_20(string fileName, string directoryPathInArchive, Stream stream)
	{
		return method_24(fileName, directoryPathInArchive, stream);
	}

	[Obsolete("Please use method AddEntry(string, string, System.IO.Stream))")]
	public Class6751 method_21(string fileName, string directoryPathInArchive, Stream stream)
	{
		return method_24(fileName, directoryPathInArchive, stream);
	}

	public Class6751 method_22(string fileName, string directoryPathInArchive, string content)
	{
		return method_23(fileName, directoryPathInArchive, content, Encoding.Default);
	}

	public Class6751 method_23(string fileName, string directoryPathInArchive, string content, Encoding encoding)
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream, encoding);
		streamWriter.Write(content);
		streamWriter.Flush();
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return method_24(fileName, directoryPathInArchive, memoryStream);
	}

	public Class6751 method_24(string fileName, string directoryPathInArchive, Stream stream)
	{
		string nameInArchive = Class6751.smethod_0(fileName, directoryPathInArchive);
		Class6751 @class = Class6751.smethod_2(fileName, nameInArchive, isStream: true, stream);
		@class.ForceNoCompression = ForceNoCompression;
		@class.ExtractExistingFile = ExtractExistingFile;
		@class.ZipErrorAction = ZipErrorAction;
		@class.WillReadTwiceOnInflation = WillReadTwiceOnInflation;
		@class.WantCompression = WantCompression;
		@class.ProvisionalAlternateEncoding = ProvisionalAlternateEncoding;
		@class.class6752_0 = this;
		@class.Encryption = Encryption;
		@class.Password = string_2;
		@class.EmitTimesInWindowsFormatWhenSaving = bool_5;
		@class.EmitTimesInUnixFormatWhenSaving = bool_6;
		if (Verbose)
		{
			StatusMessageTextWriter.WriteLine("adding {0}...", fileName);
		}
		method_32(@class);
		arrayList_0.Add(@class);
		method_55(@class);
		bool_8 = true;
		return @class;
	}

	[Obsolete("Please use method AddEntry(string, String, string))")]
	public Class6751 method_25(string fileName, string directoryPathInArchive, string content)
	{
		return method_23(fileName, directoryPathInArchive, content, Encoding.Default);
	}

	public Class6751 method_26(string fileName, string directoryPathInArchive, string content)
	{
		return method_27(fileName, directoryPathInArchive, content, Encoding.Default);
	}

	public Class6751 method_27(string fileName, string directoryPathInArchive, string content, Encoding encoding)
	{
		string fileName2 = Class6751.smethod_0(fileName, directoryPathInArchive);
		if (this[fileName2] != null)
		{
			method_3(fileName2);
		}
		return method_23(fileName, directoryPathInArchive, content, encoding);
	}

	public Class6751 method_28(string fileName, string directoryPathInArchive, Stream stream)
	{
		string fileName2 = Class6751.smethod_0(fileName, directoryPathInArchive);
		if (this[fileName2] != null)
		{
			method_3(fileName2);
		}
		return method_24(fileName, directoryPathInArchive, stream);
	}

	[Obsolete("Please use method UpdateEntry()")]
	public Class6751 method_29(string fileName, string directoryPathInArchive, Stream stream)
	{
		return method_28(fileName, directoryPathInArchive, stream);
	}

	public Class6751 method_30(string fileName, string directoryPathInArchive, byte[] byteContent)
	{
		if (byteContent == null)
		{
			throw new ArgumentException("bad argument", "byteContent");
		}
		MemoryStream stream = new MemoryStream(byteContent);
		return method_24(fileName, directoryPathInArchive, stream);
	}

	public Class6751 method_31(string fileName, string directoryPathInArchive, byte[] byteContent)
	{
		string fileName2 = Class6751.smethod_0(fileName, directoryPathInArchive);
		if (this[fileName2] != null)
		{
			method_3(fileName2);
		}
		return method_30(fileName, directoryPathInArchive, byteContent);
	}

	private void method_32(Class6751 ze1)
	{
		foreach (Class6751 item in arrayList_0)
		{
			if (Class6748.smethod_2(ze1.FileName) == item.FileName)
			{
				throw new ArgumentException($"The entry '{ze1.FileName}' already exists in the zip archive.");
			}
		}
	}

	public Class6751 method_33(string directoryName)
	{
		return method_34(directoryName, null);
	}

	public Class6751 method_34(string directoryName, string directoryPathInArchive)
	{
		return method_36(directoryName, directoryPathInArchive, Enum901.const_0);
	}

	public Class6751 method_35(string directoryNameInArchive)
	{
		Class6751 @class = Class6751.smethod_1(directoryNameInArchive, directoryNameInArchive);
		@class.method_2();
		@class.enum909_0 = Enum909.const_2;
		@class.class6752_0 = this;
		method_32(@class);
		arrayList_0.Add(@class);
		method_55(@class);
		bool_8 = true;
		return @class;
	}

	private Class6751 method_36(string directoryName, string rootDirectoryPathInArchive, Enum901 action)
	{
		if (rootDirectoryPathInArchive == null)
		{
			rootDirectoryPathInArchive = string.Empty;
		}
		return method_37(directoryName, rootDirectoryPathInArchive, action, 0);
	}

	private Class6751 method_37(string directoryName, string rootDirectoryPathInArchive, Enum901 action, int level)
	{
		if (Verbose)
		{
			StatusMessageTextWriter.WriteLine("{0} {1}...", (action == Enum901.const_0) ? "adding" : "Adding or updating", directoryName);
		}
		if (level == 0)
		{
			method_53();
		}
		string text = rootDirectoryPathInArchive;
		Class6751 @class = null;
		if (level > 0)
		{
			int num = directoryName.Length;
			for (int num2 = level; num2 > 0; num2--)
			{
				num = directoryName.LastIndexOfAny("/\\".ToCharArray(), num - 1, num - 1);
			}
			text = directoryName.Substring(num + 1);
			text = Path.Combine(rootDirectoryPathInArchive, text);
		}
		if (level > 0 || rootDirectoryPathInArchive.Length != 0)
		{
			@class = Class6751.smethod_1(directoryName, text);
			@class.ProvisionalAlternateEncoding = ProvisionalAlternateEncoding;
			@class.method_2();
			@class.class6752_0 = this;
			Class6751 class2 = this[@class.FileName];
			if (class2 == null)
			{
				arrayList_0.Add(@class);
				bool_8 = true;
			}
			text = @class.FileName;
		}
		string[] files = Directory.GetFiles(directoryName);
		string[] array = files;
		foreach (string fileName in array)
		{
			if (action == Enum901.const_0)
			{
				method_7(fileName, text);
			}
			else
			{
				method_15(fileName, text);
			}
		}
		string[] directories = Directory.GetDirectories(directoryName);
		string[] array2 = directories;
		foreach (string directoryName2 in array2)
		{
			method_37(directoryName2, rootDirectoryPathInArchive, action, level + 1);
		}
		if (level == 0)
		{
			method_54();
		}
		return @class;
	}

	public static bool smethod_0(string zipFileName)
	{
		ArrayList messages;
		return smethod_1(zipFileName, fixIfNecessary: false, out messages);
	}

	public static bool smethod_1(string zipFileName, bool fixIfNecessary, out ArrayList messages)
	{
		ArrayList arrayList = new ArrayList();
		Class6752 @class = null;
		Class6752 class2 = null;
		bool flag = true;
		try
		{
			@class = new Class6752();
			@class.FullScan = true;
			@class.Initialize(zipFileName);
			class2 = Read(zipFileName);
			foreach (Class6751 item in (IEnumerable)@class)
			{
				foreach (Class6751 item2 in (IEnumerable)class2)
				{
					if (item.FileName == item2.FileName)
					{
						if (item.long_4 != item2.long_4)
						{
							flag = false;
							arrayList.Add($"{item.FileName}: mismatch in RelativeOffsetOfLocalHeader  (0x{item.long_4:X16} != 0x{item2.long_4:X16})");
						}
						if (item.long_0 != item2.long_0)
						{
							flag = false;
							arrayList.Add($"{item.FileName}: mismatch in CompressedSize  (0x{item.long_0:X16} != 0x{item2.long_0:X16})");
						}
						if (item.long_2 != item2.long_2)
						{
							flag = false;
							arrayList.Add($"{item.FileName}: mismatch in UncompressedSize  (0x{item.long_2:X16} != 0x{item2.long_2:X16})");
						}
						if (item.CompressionMethod != item2.CompressionMethod)
						{
							flag = false;
							arrayList.Add($"{item.FileName}: mismatch in CompressionMethod  (0x{item.CompressionMethod:X4} != 0x{item2.CompressionMethod:X4})");
						}
						if (item.Crc != item2.Crc)
						{
							flag = false;
							arrayList.Add($"{item.FileName}: mismatch in Crc32  (0x{item.Crc:X4} != 0x{item2.Crc:X4})");
						}
						break;
					}
				}
			}
			class2.Dispose();
			class2 = null;
			if (!flag && fixIfNecessary)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(zipFileName);
				fileNameWithoutExtension = $"{fileNameWithoutExtension}_fixed.zip";
				@class.Save(fileNameWithoutExtension);
			}
		}
		finally
		{
			@class?.Dispose();
			class2?.Dispose();
		}
		messages = arrayList;
		return flag;
	}

	public static void smethod_2(string zipFileName)
	{
		using Class6752 @class = new Class6752();
		@class.FullScan = true;
		@class.Initialize(zipFileName);
		@class.Save(zipFileName);
	}

	internal bool method_38(Class6751 entry, long bytesXferred, long totalBytesToXfer)
	{
		if (eventHandler_0 != null)
		{
			lock (object_0)
			{
				EventArgs10 eventArgs = EventArgs10.smethod_0(ArchiveNameForEvent, entry, bytesXferred, totalBytesToXfer);
				eventHandler_0(this, eventArgs);
				if (eventArgs.Cancel)
				{
					bool_11 = true;
				}
			}
		}
		return bool_11;
	}

	private void method_39(int current, Class6751 entry, bool before)
	{
		if (eventHandler_0 == null)
		{
			return;
		}
		lock (object_0)
		{
			EventArgs10 eventArgs = new EventArgs10(ArchiveNameForEvent, before, arrayList_0.Count, current, entry);
			eventHandler_0(this, eventArgs);
			if (eventArgs.Cancel)
			{
				bool_11 = true;
			}
		}
	}

	private void method_40(Enum912 eventFlavor)
	{
		if (eventHandler_0 == null)
		{
			return;
		}
		lock (object_0)
		{
			EventArgs10 eventArgs = new EventArgs10(ArchiveNameForEvent, eventFlavor);
			eventHandler_0(this, eventArgs);
			if (eventArgs.Cancel)
			{
				bool_11 = true;
			}
		}
	}

	private void method_41()
	{
		if (eventHandler_0 != null)
		{
			lock (object_0)
			{
				EventArgs10 e = EventArgs10.smethod_1(ArchiveNameForEvent);
				eventHandler_0(this, e);
			}
		}
	}

	private void method_42()
	{
		if (eventHandler_0 != null)
		{
			lock (object_0)
			{
				EventArgs10 e = EventArgs10.smethod_2(ArchiveNameForEvent);
				eventHandler_0(this, e);
			}
		}
	}

	private void method_43()
	{
		if (eventHandler_1 != null)
		{
			lock (object_0)
			{
				EventArgs8 e = EventArgs8.smethod_2(ArchiveNameForEvent);
				eventHandler_1(this, e);
			}
		}
	}

	private void method_44()
	{
		if (eventHandler_1 != null)
		{
			lock (object_0)
			{
				EventArgs8 e = EventArgs8.smethod_4(ArchiveNameForEvent);
				eventHandler_1(this, e);
			}
		}
	}

	internal void method_45(Class6751 entry)
	{
		if (eventHandler_1 != null)
		{
			lock (object_0)
			{
				EventArgs8 e = EventArgs8.smethod_3(ArchiveNameForEvent, entry, ReadStream.Position, LengthOfReadStream);
				eventHandler_1(this, e);
			}
		}
	}

	internal void method_46(bool before, Class6751 entry)
	{
		if (eventHandler_1 != null)
		{
			lock (object_0)
			{
				EventArgs8 e = (before ? EventArgs8.smethod_0(ArchiveNameForEvent, arrayList_0.Count) : EventArgs8.smethod_1(ArchiveNameForEvent, entry, arrayList_0.Count));
				eventHandler_1(this, e);
			}
		}
	}

	private void method_47(int current, bool before, Class6751 currentEntry, string path)
	{
		if (eventHandler_2 == null)
		{
			return;
		}
		lock (object_0)
		{
			EventArgs11 eventArgs = new EventArgs11(ArchiveNameForEvent, before, arrayList_0.Count, current, currentEntry, path);
			eventHandler_2(this, eventArgs);
			if (eventArgs.Cancel)
			{
				bool_12 = true;
			}
		}
	}

	internal bool method_48(Class6751 entry, long bytesWritten, long totalBytesToWrite)
	{
		if (eventHandler_2 != null)
		{
			lock (object_0)
			{
				EventArgs11 eventArgs = EventArgs11.smethod_5(ArchiveNameForEvent, entry, bytesWritten, totalBytesToWrite);
				eventHandler_2(this, eventArgs);
				if (eventArgs.Cancel)
				{
					bool_12 = true;
				}
			}
		}
		return bool_12;
	}

	internal bool method_49(Class6751 entry, string path, bool before)
	{
		if (eventHandler_2 != null)
		{
			lock (object_0)
			{
				EventArgs11 eventArgs = (before ? EventArgs11.smethod_0(ArchiveNameForEvent, entry, path) : EventArgs11.smethod_2(ArchiveNameForEvent, entry, path));
				eventHandler_2(this, eventArgs);
				if (eventArgs.Cancel)
				{
					bool_12 = true;
				}
			}
		}
		return bool_12;
	}

	internal bool method_50(Class6751 entry, string path)
	{
		if (eventHandler_2 != null)
		{
			lock (object_0)
			{
				EventArgs11 eventArgs = EventArgs11.smethod_1(ArchiveNameForEvent, entry, path);
				eventHandler_2(this, eventArgs);
				if (eventArgs.Cancel)
				{
					bool_12 = true;
				}
			}
		}
		return bool_12;
	}

	private void method_51(string path)
	{
		if (eventHandler_2 != null)
		{
			lock (object_0)
			{
				EventArgs11 e = EventArgs11.smethod_4(ArchiveNameForEvent, path);
				eventHandler_2(this, e);
			}
		}
	}

	private void method_52(string path)
	{
		if (eventHandler_2 != null)
		{
			lock (object_0)
			{
				EventArgs11 e = EventArgs11.smethod_3(ArchiveNameForEvent, path);
				eventHandler_2(this, e);
			}
		}
	}

	private void method_53()
	{
		if (eventHandler_3 != null)
		{
			lock (object_0)
			{
				EventArgs9 e = EventArgs9.smethod_1(ArchiveNameForEvent);
				eventHandler_3(this, e);
			}
		}
	}

	private void method_54()
	{
		if (eventHandler_3 != null)
		{
			lock (object_0)
			{
				EventArgs9 e = EventArgs9.smethod_2(ArchiveNameForEvent);
				eventHandler_3(this, e);
			}
		}
	}

	internal void method_55(Class6751 entry)
	{
		if (eventHandler_3 != null)
		{
			lock (object_0)
			{
				EventArgs9 e = EventArgs9.smethod_0(ArchiveNameForEvent, entry, arrayList_0.Count);
				eventHandler_3(this, e);
			}
		}
	}

	internal bool method_56(Class6751 entry, Exception exc)
	{
		if (eventHandler_4 != null)
		{
			lock (object_0)
			{
				EventArgs12 eventArgs = EventArgs12.smethod_0(Name, entry, exc);
				eventHandler_4(this, eventArgs);
				if (eventArgs.Cancel)
				{
					bool_11 = true;
				}
			}
		}
		return bool_11;
	}

	public void method_57(string path)
	{
		method_60(path, overrideExtractExistingProperty: true);
	}

	[Obsolete("Please use property ExtractExistingFile to specify overwrite behavior)")]
	public void method_58(string path, bool wantOverwrite)
	{
		ExtractExistingFile = (wantOverwrite ? Enum904.const_1 : Enum904.const_0);
		method_60(path, overrideExtractExistingProperty: true);
	}

	public void method_59(string path, Enum904 extractExistingFile)
	{
		ExtractExistingFile = extractExistingFile;
		method_60(path, overrideExtractExistingProperty: true);
	}

	private void method_60(string path, bool overrideExtractExistingProperty)
	{
		bool flag = Verbose;
		bool_15 = true;
		try
		{
			method_52(path);
			int num = 0;
			foreach (Class6751 item in arrayList_0)
			{
				if (flag)
				{
					StatusMessageTextWriter.WriteLine("\n{1,-22} {2,-8} {3,4}   {4,-8}  {0}", "Name", "Modified", "Size", "Ratio", "Packed");
					StatusMessageTextWriter.WriteLine(new string('-', 72));
					flag = false;
				}
				if (Verbose)
				{
					StatusMessageTextWriter.WriteLine("{1,-22} {2,-8} {3,4:F0}%   {4,-8} {0}", item.FileName, item.LastModified.ToString("yyyy-MM-dd HH:mm:ss"), item.UncompressedSize, item.CompressionRatio, item.CompressedSize);
					if (item.Comment != null && item.Comment.Length > 0)
					{
						StatusMessageTextWriter.WriteLine("  Comment: {0}", item.Comment);
					}
				}
				item.Password = string_2;
				method_47(num, before: true, item, path);
				if (overrideExtractExistingProperty)
				{
					item.ExtractExistingFile = ExtractExistingFile;
				}
				item.method_9(path);
				num++;
				method_47(num, before: false, item, path);
				if (bool_12)
				{
					break;
				}
			}
			foreach (Class6751 item2 in arrayList_0)
			{
				if (item2.IsDirectory || item2.FileName.EndsWith("/"))
				{
					string fileOrDirectory = (item2.FileName.StartsWith("/") ? Path.Combine(path, item2.FileName.Substring(1)) : Path.Combine(path, item2.FileName));
					item2.method_32(fileOrDirectory, isFile: false);
				}
			}
			method_51(path);
		}
		finally
		{
			bool_15 = false;
		}
	}

	[Obsolete("Please use method ZipEntry.Extract()")]
	public void method_61(string fileName)
	{
		Class6751 @class = this[fileName];
		if (ExtractExistingFile != 0)
		{
			@class.ExtractExistingFile = ExtractExistingFile;
		}
		@class.Password = string_2;
		@class.method_5();
	}

	[Obsolete("Please use method ZipEntry.Extract(string)")]
	public void method_62(string entryName, string directoryName)
	{
		Class6751 @class = this[entryName];
		if (ExtractExistingFile != 0)
		{
			@class.ExtractExistingFile = ExtractExistingFile;
		}
		@class.Password = string_2;
		@class.method_9(directoryName);
	}

	[Obsolete("Please use method ZipEntry.Extract(ExtractExistingFileAction)")]
	public void method_63(string entryName, bool wantOverwrite)
	{
		Class6751 @class = this[entryName];
		@class.ExtractExistingFile = (wantOverwrite ? Enum904.const_1 : Enum904.const_0);
		@class.Password = string_2;
		@class.method_9(Directory.GetCurrentDirectory());
	}

	[Obsolete("Please use method ZipEntry.Extract(ExtractExistingFileAction)")]
	public void method_64(string entryName, Enum904 extractExistingFile)
	{
		Class6751 @class = this[entryName];
		@class.ExtractExistingFile = extractExistingFile;
		@class.Password = string_2;
		@class.method_9(Directory.GetCurrentDirectory());
	}

	[Obsolete("Please use method ZipEntry.Extract(String,ExtractExistingFileAction)")]
	public void method_65(string entryName, string directoryName, bool wantOverwrite)
	{
		Class6751 @class = this[entryName];
		@class.Password = string_2;
		@class.ExtractExistingFile = (wantOverwrite ? Enum904.const_1 : Enum904.const_0);
		@class.method_9(directoryName);
	}

	[Obsolete("Please use method ZipEntry.Extract(string, ExtractExistingFileAction)")]
	public void method_66(string entryName, string directoryName, Enum904 extractExistingFile)
	{
		Class6751 @class = this[entryName];
		@class.ExtractExistingFile = extractExistingFile;
		@class.Password = string_2;
		@class.method_9(directoryName);
	}

	[Obsolete("Please use method ZipEntry.Extract(Stream)")]
	public void method_67(string entryName, Stream outputStream)
	{
		if (outputStream != null && outputStream.CanWrite)
		{
			if (entryName == null || entryName.Length == 0)
			{
				throw new Exception61("Cannot extract.", new ArgumentException("The file name must be neither null nor empty.", "entryName"));
			}
			Class6751 @class = this[entryName];
			@class.Password = string_2;
			@class.method_8(outputStream);
			return;
		}
		throw new Exception61("Cannot extract.", new ArgumentException("The OutputStream must be a writable stream.", "outputStream"));
	}

	public static Class6752 Read(string fileName)
	{
		return Read(fileName, null, encoding_0);
	}

	public static Class6752 Read(string fileName, EventHandler readProgress)
	{
		return Read(fileName, null, encoding_0, readProgress);
	}

	public static Class6752 Read(string fileName, TextWriter statusMessageWriter)
	{
		return Read(fileName, statusMessageWriter, encoding_0);
	}

	public static Class6752 Read(string fileName, TextWriter statusMessageWriter, EventHandler readProgress)
	{
		return Read(fileName, statusMessageWriter, encoding_0, readProgress);
	}

	public static Class6752 Read(string fileName, Encoding encoding)
	{
		return Read(fileName, null, encoding);
	}

	public static Class6752 Read(string fileName, Encoding encoding, EventHandler readProgress)
	{
		return Read(fileName, null, encoding, readProgress);
	}

	public static Class6752 Read(string fileName, TextWriter statusMessageWriter, Encoding encoding)
	{
		return Read(fileName, statusMessageWriter, encoding, null);
	}

	public static Class6752 Read(string fileName, TextWriter statusMessageWriter, Encoding encoding, EventHandler readProgress)
	{
		Class6752 @class = new Class6752();
		@class.ProvisionalAlternateEncoding = encoding;
		@class.textWriter_0 = statusMessageWriter;
		@class.string_0 = fileName;
		if (readProgress != null)
		{
			@class.eventHandler_1 = readProgress;
		}
		if (@class.Verbose)
		{
			@class.textWriter_0.WriteLine("reading from {0}...", fileName);
		}
		try
		{
			smethod_3(@class);
			@class.bool_7 = true;
			return @class;
		}
		catch (Exception innerException)
		{
			throw new Exception61($"{fileName} could not be read", innerException);
		}
	}

	public static Class6752 Read(Stream zipStream)
	{
		return Read(zipStream, null, encoding_0);
	}

	public static Class6752 Read(Stream zipStream, EventHandler readProgress)
	{
		return Read(zipStream, null, encoding_0, readProgress);
	}

	public static Class6752 Read(Stream zipStream, TextWriter statusMessageWriter)
	{
		return Read(zipStream, statusMessageWriter, encoding_0);
	}

	public static Class6752 Read(Stream zipStream, TextWriter statusMessageWriter, EventHandler readProgress)
	{
		return Read(zipStream, statusMessageWriter, encoding_0, readProgress);
	}

	public static Class6752 Read(Stream zipStream, Encoding encoding)
	{
		return Read(zipStream, null, encoding);
	}

	public static Class6752 Read(Stream zipStream, Encoding encoding, EventHandler readProgress)
	{
		return Read(zipStream, null, encoding, readProgress);
	}

	public static Class6752 Read(Stream zipStream, TextWriter statusMessageWriter, Encoding encoding)
	{
		return Read(zipStream, statusMessageWriter, encoding, null);
	}

	public static Class6752 Read(Stream zipStream, TextWriter statusMessageWriter, Encoding encoding, EventHandler readProgress)
	{
		if (zipStream == null)
		{
			throw new Exception61("Cannot read.", new ArgumentException("The stream must be non-null", "zipStream"));
		}
		Class6752 @class = new Class6752();
		@class.encoding_1 = encoding;
		if (readProgress != null)
		{
			@class.ReadProgress += readProgress;
		}
		@class.textWriter_0 = statusMessageWriter;
		@class.stream_0 = zipStream;
		@class.bool_10 = false;
		if (@class.Verbose)
		{
			@class.textWriter_0.WriteLine("reading from stream...");
		}
		smethod_3(@class);
		return @class;
	}

	public static Class6752 Read(byte[] buffer)
	{
		return Read(buffer, null, encoding_0);
	}

	public static Class6752 Read(byte[] buffer, TextWriter statusMessageWriter)
	{
		return Read(buffer, statusMessageWriter, encoding_0);
	}

	public static Class6752 Read(byte[] buffer, TextWriter statusMessageWriter, Encoding encoding)
	{
		Class6752 @class = new Class6752();
		@class.textWriter_0 = statusMessageWriter;
		@class.encoding_1 = encoding;
		@class.stream_0 = new MemoryStream(buffer);
		@class.bool_10 = true;
		if (@class.Verbose)
		{
			@class.textWriter_0.WriteLine("reading from byte[]...");
		}
		smethod_3(@class);
		return @class;
	}

	private static void smethod_3(Class6752 zf)
	{
		Stream readStream = zf.ReadStream;
		try
		{
			if (!readStream.CanSeek)
			{
				smethod_7(zf);
				return;
			}
			zf.method_43();
			zf.long_0 = readStream.Position;
			uint num = smethod_5(readStream);
			if (num == 101010256)
			{
				return;
			}
			int num2 = 0;
			bool flag = false;
			long num3 = readStream.Length - 64L;
			long num4 = Math.Max(readStream.Length - 16384L, 10L);
			do
			{
				readStream.Seek(num3, SeekOrigin.Begin);
				long num5 = Class6748.smethod_10(readStream, 101010256);
				if (num5 == -1L)
				{
					num2++;
					num3 -= 32 * (num2 + 1) * num2;
					if (num3 < 0L)
					{
						num3 = 0L;
					}
				}
				else
				{
					flag = true;
				}
			}
			while (!flag && num3 > num4);
			if (flag)
			{
				zf.long_1 = readStream.Position - 4L;
				byte[] array = new byte[16];
				zf.ReadStream.Read(array, 0, array.Length);
				uint num6 = (uint)(array[12] + array[13] * 256 + array[14] * 256 * 256 + array[15] * 256 * 256 * 256);
				if (num6 == uint.MaxValue)
				{
					smethod_4(zf);
				}
				else
				{
					zf.method_68(num6);
				}
				smethod_6(zf);
			}
			else
			{
				readStream.Seek(zf.long_0, SeekOrigin.Begin);
				smethod_7(zf);
			}
		}
		catch
		{
			if (zf.bool_10 && zf.stream_0 != null)
			{
				zf.stream_0.Close();
				zf.stream_0 = null;
			}
			throw;
		}
		zf.bool_8 = false;
	}

	private static void smethod_4(Class6752 zf)
	{
		Stream readStream = zf.ReadStream;
		byte[] array = new byte[16];
		readStream.Seek(-40L, SeekOrigin.Current);
		readStream.Read(array, 0, 16);
		long position = BitConverter.ToInt64(array, 8);
		zf.method_68(position);
		uint num = (uint)Class6748.smethod_8(readStream);
		if (num != 101075792)
		{
			throw new Exception63($"  ZipFile::Read(): Bad signature (0x{num:X8}) looking for ZIP64 EoCD Record at position 0x{readStream.Position:X8}");
		}
		readStream.Read(array, 0, 8);
		long num2 = BitConverter.ToInt64(array, 0);
		array = new byte[num2];
		readStream.Read(array, 0, array.Length);
		position = BitConverter.ToInt64(array, 36);
		zf.method_68(position);
	}

	private static uint smethod_5(Stream s)
	{
		return (uint)Class6748.smethod_8(s);
	}

	private static void smethod_6(Class6752 zf)
	{
		Class6751 @class;
		while ((@class = Class6751.smethod_3(zf)) != null)
		{
			@class.method_4();
			zf.method_46(before: true, null);
			if (zf.Verbose)
			{
				zf.StatusMessageTextWriter.WriteLine("entry {0}", @class.FileName);
			}
			zf.arrayList_0.Add(@class);
		}
		if (zf.long_1 > 0L)
		{
			zf.method_68(zf.long_1);
		}
		smethod_8(zf);
		if (zf.Verbose && zf.Comment != null && zf.Comment.Length > 0)
		{
			zf.StatusMessageTextWriter.WriteLine("Zip file Comment: {0}", zf.Comment);
		}
		if (zf.Verbose)
		{
			zf.StatusMessageTextWriter.WriteLine("read in {0} entries.", zf.arrayList_0.Count);
		}
		zf.method_44();
	}

	private static void smethod_7(Class6752 zf)
	{
		zf.method_43();
		zf.arrayList_0 = new ArrayList();
		if (zf.Verbose)
		{
			if (zf.Name == null)
			{
				zf.StatusMessageTextWriter.WriteLine("Reading zip from stream...");
			}
			else
			{
				zf.StatusMessageTextWriter.WriteLine("Reading zip {0}...", zf.Name);
			}
		}
		bool first = true;
		Class6751 @class;
		while ((@class = Class6751.Read(zf, first)) != null)
		{
			if (zf.Verbose)
			{
				zf.StatusMessageTextWriter.WriteLine("  {0}", @class.FileName);
			}
			zf.arrayList_0.Add(@class);
			first = false;
		}
		Class6751 class2;
		while ((class2 = Class6751.smethod_3(zf)) != null)
		{
			foreach (Class6751 item in zf.arrayList_0)
			{
				if (item.FileName == class2.FileName)
				{
					item.string_2 = class2.Comment;
					if (class2.AttributesIndicateDirectory)
					{
						item.method_2();
					}
					break;
				}
			}
		}
		if (zf.long_1 > 0L)
		{
			zf.method_68(zf.long_1);
		}
		smethod_8(zf);
		if (zf.Verbose && zf.Comment != null && zf.Comment.Length > 0)
		{
			zf.StatusMessageTextWriter.WriteLine("Zip file Comment: {0}", zf.Comment);
		}
		zf.method_44();
	}

	private static void smethod_8(Class6752 zf)
	{
		Stream readStream = zf.ReadStream;
		int num = Class6748.smethod_7(readStream);
		byte[] array;
		if (num == 101075792L)
		{
			array = new byte[52];
			readStream.Read(array, 0, array.Length);
			long num2 = BitConverter.ToInt64(array, 0);
			if (num2 < 44L)
			{
				throw new Exception61("Bad DataSize in the ZIP64 Central Directory.");
			}
			array = new byte[num2 - 44L];
			readStream.Read(array, 0, array.Length);
			num = Class6748.smethod_7(readStream);
			if (num != 117853008L)
			{
				throw new Exception61("Inconsistent metadata in the ZIP64 Central Directory.");
			}
			array = new byte[16];
			readStream.Read(array, 0, array.Length);
			num = Class6748.smethod_7(readStream);
		}
		if (num != 101010256L)
		{
			readStream.Seek(-4L, SeekOrigin.Current);
			throw new Exception63($"  ZipFile::Read(): Bad signature ({num:X8}) at position 0x{readStream.Position:X8}");
		}
		array = new byte[16];
		zf.ReadStream.Read(array, 0, array.Length);
		smethod_9(zf);
	}

	private static void smethod_9(Class6752 zf)
	{
		byte[] array = new byte[2];
		zf.ReadStream.Read(array, 0, array.Length);
		short num = (short)(array[0] + array[1] * 256);
		if (num > 0)
		{
			array = new byte[num];
			zf.ReadStream.Read(array, 0, array.Length);
			string @string = encoding_0.GetString(array, 0, array.Length);
			byte[] bytes = encoding_0.GetBytes(@string);
			if (smethod_10(array, bytes))
			{
				zf.Comment = @string;
				return;
			}
			Encoding encoding = ((zf.encoding_1.CodePage == 437) ? Encoding.UTF8 : zf.encoding_1);
			zf.Comment = encoding.GetString(array, 0, array.Length);
		}
	}

	private static bool smethod_10(byte[] a, byte[] b)
	{
		if (a.Length != b.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < a.Length)
			{
				if (a[num] != b[num])
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	internal void method_68(long position)
	{
		ReadStream.Seek(position + long_0, SeekOrigin.Begin);
	}

	public static bool smethod_11(string fileName)
	{
		return smethod_12(fileName, testExtract: false);
	}

	public static bool smethod_12(string fileName, bool testExtract)
	{
		bool result = false;
		try
		{
			if (!File.Exists(fileName))
			{
				return false;
			}
			using FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			result = smethod_13(stream, testExtract);
		}
		catch
		{
		}
		return result;
	}

	public static bool smethod_13(Stream stream, bool testExtract)
	{
		bool result = false;
		try
		{
			if (!stream.CanRead)
			{
				return false;
			}
			Stream @null = Stream.Null;
			using (Class6752 @class = Read(stream, null, Encoding.GetEncoding("IBM437")))
			{
				if (testExtract)
				{
					foreach (Class6751 item in (IEnumerable)@class)
					{
						if (!item.IsDirectory)
						{
							item.method_8(@null);
						}
					}
				}
			}
			result = true;
		}
		catch
		{
		}
		return result;
	}

	public void Save()
	{
		try
		{
			bool flag = false;
			bool_11 = false;
			method_41();
			if (WriteStream == null)
			{
				throw new Exception66("You haven't specified where to save the zip.");
			}
			if (string_0 != null && string_0.EndsWith(".exe"))
			{
				throw new Exception66("You specified an EXE for a plain zip file.");
			}
			if (!bool_8)
			{
				return;
			}
			if (Verbose)
			{
				StatusMessageTextWriter.WriteLine("saving....");
			}
			if (arrayList_0.Count >= 65535 && enum908_0 == Enum908.const_0)
			{
				throw new Exception61("The number of entries is 65535 or greater. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
			}
			int num = 0;
			foreach (Class6751 item in arrayList_0)
			{
				method_39(num, item, before: true);
				item.Write(WriteStream);
				if (!bool_11)
				{
					item.class6752_0 = this;
					num++;
					method_39(num, item, before: false);
					if (!bool_11)
					{
						if (item.IncludedInMostRecentSave)
						{
							flag |= item.OutputUsedZip64 == Enum906.const_2;
						}
						continue;
					}
					break;
				}
				break;
			}
			if (bool_11)
			{
				return;
			}
			method_71(WriteStream);
			method_40(Enum912.const_12);
			bool_9 = true;
			bool_8 = false;
			flag |= bool_14;
			enum906_0 = (flag ? Enum906.const_2 : Enum906.const_1);
			if (string_3 != null && string_0 != null)
			{
				WriteStream.Close();
				WriteStream = null;
				if (bool_11)
				{
					return;
				}
				if (bool_7 && stream_0 != null)
				{
					stream_0.Close();
					stream_0 = null;
				}
				if (bool_7)
				{
					File.Delete(string_0);
					method_40(Enum912.const_13);
					File.Move(string_3, string_0);
					method_40(Enum912.const_14);
				}
				else
				{
					File.Move(string_3, string_0);
				}
				bool_7 = true;
			}
			method_42();
			bool_13 = true;
		}
		finally
		{
			method_70();
		}
	}

	private void method_69()
	{
		try
		{
			if (File.Exists(string_3))
			{
				File.Delete(string_3);
			}
		}
		catch (Exception ex)
		{
			if (Verbose)
			{
				StatusMessageTextWriter.WriteLine("ZipFile::Save: could not delete temp file: {0}.", ex.Message);
			}
		}
	}

	private void method_70()
	{
		if (string_3 == null || string_0 == null)
		{
			return;
		}
		if (stream_1 != null)
		{
			try
			{
				stream_1.Close();
			}
			catch
			{
			}
			try
			{
				stream_1.Close();
			}
			catch
			{
			}
		}
		stream_1 = null;
		method_69();
		string_3 = null;
	}

	public void Save(string fileName)
	{
		if (string_0 == null)
		{
			stream_1 = null;
		}
		string_0 = fileName;
		if (Directory.Exists(string_0))
		{
			throw new Exception61("Bad Directory", new ArgumentException("That name specifies an existing directory. Please specify a filename.", "fileName"));
		}
		bool_8 = true;
		bool_7 = File.Exists(string_0);
		Save();
	}

	public void Save(Stream outputStream)
	{
		if (!outputStream.CanWrite)
		{
			throw new ArgumentException("The outputStream must be a writable stream.");
		}
		string_0 = null;
		stream_1 = new Stream10(outputStream);
		bool_8 = true;
		bool_7 = false;
		Save();
	}

	private void method_71(Stream s)
	{
		Stream10 stream = s as Stream10;
		long num = stream?.BytesWritten ?? s.Position;
		foreach (Class6751 item in arrayList_0)
		{
			if (item.IncludedInMostRecentSave)
			{
				item.method_44(s);
			}
		}
		long num2 = stream?.BytesWritten ?? s.Position;
		long num3 = num2 - num;
		bool_14 = enum908_0 == Enum908.const_3 || method_72() >= 65535 || num3 > 4294967295L || num > 4294967295L;
		if (bool_14)
		{
			if (enum908_0 == Enum908.const_0)
			{
				throw new Exception61("The archive requires a ZIP64 Central Directory. Consider setting the UseZip64WhenSaving property.");
			}
			method_73(s, num, num2);
		}
		method_74(s, num, num2);
	}

	private int method_72()
	{
		int num = 0;
		foreach (Class6751 item in arrayList_0)
		{
			if (item.IncludedInMostRecentSave)
			{
				num++;
			}
		}
		return num;
	}

	private void method_73(Stream s, long StartOfCentralDirectory, long EndOfCentralDirectory)
	{
		byte[] array = new byte[76];
		int num = 0;
		byte[] bytes = BitConverter.GetBytes(101075792u);
		Array.Copy(bytes, 0, array, 0, 4);
		num = 4;
		Array.Copy(BitConverter.GetBytes(44L), 0, array, 4, 8);
		num = 12;
		num = 13;
		array[12] = 45;
		num = 14;
		array[13] = 0;
		num = 15;
		array[14] = 45;
		num = 16;
		array[15] = 0;
		for (int i = 0; i < 8; i++)
		{
			array[num++] = 0;
		}
		long value = method_72();
		Array.Copy(BitConverter.GetBytes(value), 0, array, num, 8);
		num += 8;
		Array.Copy(BitConverter.GetBytes(value), 0, array, num, 8);
		num += 8;
		long value2 = EndOfCentralDirectory - StartOfCentralDirectory;
		Array.Copy(BitConverter.GetBytes(value2), 0, array, num, 8);
		num += 8;
		Array.Copy(BitConverter.GetBytes(StartOfCentralDirectory), 0, array, num, 8);
		num += 8;
		bytes = BitConverter.GetBytes(117853008u);
		Array.Copy(bytes, 0, array, num, 4);
		num += 4;
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = 0;
		Array.Copy(BitConverter.GetBytes(EndOfCentralDirectory), 0, array, num, 8);
		num += 8;
		array[num++] = 1;
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = 0;
		s.Write(array, 0, num);
	}

	private void method_74(Stream s, long StartOfCentralDirectory, long EndOfCentralDirectory)
	{
		int num = 0;
		int num2 = 24;
		byte[] array = null;
		short num3 = 0;
		if (Comment != null && Comment.Length != 0)
		{
			array = ProvisionalAlternateEncoding.GetBytes(Comment);
			num3 = (short)array.Length;
		}
		num2 += num3;
		byte[] array2 = new byte[num2];
		int num4 = 0;
		byte[] bytes = BitConverter.GetBytes(101010256u);
		Array.Copy(bytes, 0, array2, 0, 4);
		num4 = 4;
		num4 = 5;
		array2[4] = 0;
		num4 = 6;
		array2[5] = 0;
		num4 = 7;
		array2[6] = 0;
		num4 = 8;
		array2[7] = 0;
		if (method_72() < 65535 && enum908_0 != Enum908.const_3)
		{
			int num5 = method_72();
			array2[num4++] = (byte)((uint)num5 & 0xFFu);
			array2[num4++] = (byte)((num5 & 0xFF00) >> 8);
			array2[num4++] = (byte)((uint)num5 & 0xFFu);
			array2[num4++] = (byte)((num5 & 0xFF00) >> 8);
		}
		else
		{
			for (num = 0; num < 4; num++)
			{
				array2[num4++] = byte.MaxValue;
			}
		}
		long num6 = EndOfCentralDirectory - StartOfCentralDirectory;
		if (num6 < 4294967295L && StartOfCentralDirectory < 4294967295L)
		{
			array2[num4++] = (byte)((ulong)num6 & 0xFFuL);
			array2[num4++] = (byte)((num6 & 0xFF00L) >> 8);
			array2[num4++] = (byte)((num6 & 0xFF0000L) >> 16);
			array2[num4++] = (byte)((num6 & 0xFF000000L) >> 24);
			array2[num4++] = (byte)((ulong)StartOfCentralDirectory & 0xFFuL);
			array2[num4++] = (byte)((StartOfCentralDirectory & 0xFF00L) >> 8);
			array2[num4++] = (byte)((StartOfCentralDirectory & 0xFF0000L) >> 16);
			array2[num4++] = (byte)((StartOfCentralDirectory & 0xFF000000L) >> 24);
		}
		else
		{
			for (num = 0; num < 8; num++)
			{
				array2[num4++] = byte.MaxValue;
			}
		}
		if (Comment != null && Comment.Length != 0)
		{
			if (num3 + num4 + 2 > array2.Length)
			{
				num3 = (short)(array2.Length - num4 - 2);
			}
			array2[num4++] = (byte)((uint)num3 & 0xFFu);
			array2[num4++] = (byte)((num3 & 0xFF00) >> 8);
			if (num3 != 0)
			{
				for (num = 0; num < num3 && num4 + num < array2.Length; num++)
				{
					array2[num4 + num] = array[num];
				}
				num4 += num;
			}
		}
		else
		{
			array2[num4++] = 0;
			array2[num4++] = 0;
		}
		s.Write(array2, 0, num4);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return arrayList_0.GetEnumerator();
	}

	public IEnumerator method_75()
	{
		return arrayList_0.GetEnumerator();
	}
}

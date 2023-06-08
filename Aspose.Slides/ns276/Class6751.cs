using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ns276;

internal class Class6751
{
	private Enum904 enum904_0;

	private Enum911 enum911_0;

	private Delegate2782 delegate2782_0;

	private Delegate2783 delegate2783_0;

	internal Class6750 class6750_0;

	internal DateTime dateTime_0;

	private DateTime dateTime_1;

	private DateTime dateTime_2;

	private DateTime dateTime_3;

	private bool bool_0;

	private bool bool_1 = true;

	private bool bool_2;

	private bool bool_3 = true;

	private bool bool_4;

	internal string string_0;

	private string string_1;

	internal short short_0;

	internal short short_1;

	internal short short_2;

	internal string string_2;

	private bool bool_5;

	private byte[] byte_0;

	internal long long_0;

	internal long long_1;

	internal long long_2;

	internal int int_0;

	private bool bool_6;

	internal int int_1;

	internal byte[] byte_1;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private static Encoding encoding_0 = Encoding.GetEncoding("IBM437");

	private Encoding encoding_1 = Encoding.GetEncoding("IBM437");

	private Encoding encoding_2;

	internal Class6752 class6752_0;

	internal long long_3 = -1L;

	private byte[] byte_2;

	internal long long_4;

	private long long_5;

	internal int int_2;

	internal int int_3;

	private bool bool_11;

	private uint uint_0;

	internal string string_3;

	internal Enum909 enum909_0;

	internal Enum903 enum903_0;

	internal byte[] byte_3;

	internal Stream stream_0;

	private Stream stream_1;

	private Struct224 struct224_0;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private Enum906 enum906_0;

	private Enum906 enum906_1;

	private bool bool_15;

	private Enum910 enum910_0;

	private static DateTime dateTime_4 = new DateTime(1970, 1, 1, 0, 0, 0);

	private short short_3;

	private short short_4;

	private int int_4;

	private short short_5;

	private short short_6;

	private short short_7;

	private int int_5;

	private static Regex regex_0 = new Regex("(?i)^(.+)\\.(mp3|png|docx|xlsx|pptx|jpg|zip)$");

	public DateTime LastModified
	{
		get
		{
			return dateTime_0.ToLocalTime();
		}
		set
		{
			dateTime_0 = value;
			dateTime_1 = dateTime_0.ToUniversalTime();
			bool_7 = true;
		}
	}

	private int BufferSize => class6752_0.BufferSize;

	public DateTime ModifiedTime => dateTime_1;

	public DateTime AccessedTime => dateTime_2;

	public DateTime CreationTime => dateTime_3;

	public bool EmitTimesInWindowsFormatWhenSaving
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			bool_7 = true;
		}
	}

	public bool EmitTimesInUnixFormatWhenSaving
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			bool_7 = true;
		}
	}

	public Enum910 Timestamp => enum910_0;

	public FileAttributes Attributes
	{
		get
		{
			return (FileAttributes)int_4;
		}
		set
		{
			int_4 = (int)value;
			short_3 = 45;
			bool_7 = true;
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
			if (value != bool_4)
			{
				bool_4 = value;
				if (bool_4)
				{
					CompressionMethod = 0;
				}
			}
		}
	}

	internal string LocalFileName => string_0;

	public string FileName
	{
		get
		{
			return string_1;
		}
		set
		{
			if (value != null && value.Length != 0)
			{
				string text = smethod_0(value, null);
				if (!(string_1 == text))
				{
					if (class6752_0.EntryFileNames.Contains(text))
					{
						throw new Exception61($"Cannot rename {string_1} to {text}; an entry by that name already exists in the archive.");
					}
					string_1 = text;
					if (class6752_0 != null)
					{
						class6752_0.method_0();
					}
					bool_7 = true;
				}
				return;
			}
			throw new Exception61("The FileName must be non empty and non-null.");
		}
	}

	public Stream InputStream
	{
		get
		{
			return stream_1;
		}
		set
		{
			if (enum909_0 != Enum909.const_2)
			{
				throw new Exception61("You must not set the input stream for this ZipEntry.");
			}
			bool_12 = true;
			stream_1 = value;
		}
	}

	public bool InputStreamWasJitProvided => bool_12;

	public Enum909 Source => enum909_0;

	public short VersionNeeded => short_0;

	public string Comment
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
			bool_7 = true;
		}
	}

	public Enum906 RequiresZip64 => enum906_0;

	public Enum906 OutputUsedZip64 => enum906_1;

	public short BitField => short_1;

	public short CompressionMethod
	{
		get
		{
			return short_2;
		}
		set
		{
			if (value != short_2)
			{
				if (value != 0 && value != 8)
				{
					throw new InvalidOperationException("Unsupported compression method. Specify 8 or 0.");
				}
				if (enum909_0 == Enum909.const_3 && bool_9)
				{
					throw new InvalidOperationException("Cannot change compression method on encrypted entries read from archives.");
				}
				short_2 = value;
				bool_4 = short_2 == 0;
				bool_8 = true;
			}
		}
	}

	public long CompressedSize => long_0;

	public long UncompressedSize => long_2;

	public double CompressionRatio
	{
		get
		{
			if (UncompressedSize == 0L)
			{
				return 0.0;
			}
			return 100.0 * (1.0 - 1.0 * (double)CompressedSize / (1.0 * (double)UncompressedSize));
		}
	}

	public int Crc => int_1;

	public bool IsDirectory => bool_5;

	public bool UsesEncryption => Encryption != Enum903.const_0;

	public Enum903 Encryption
	{
		get
		{
			return enum903_0;
		}
		set
		{
			if (value != enum903_0)
			{
				if (value == Enum903.const_2)
				{
					throw new InvalidOperationException("You may not set Encryption to that value.");
				}
				if (enum909_0 == Enum909.const_3 && bool_9)
				{
					throw new InvalidOperationException("You cannot change the encryption method on encrypted entries read from archives.");
				}
				enum903_0 = value;
				bool_8 = true;
			}
		}
	}

	public string Password
	{
		set
		{
			string_3 = value;
			if (string_3 == null)
			{
				enum903_0 = Enum903.const_0;
				return;
			}
			if (enum909_0 == Enum909.const_3 && !bool_9)
			{
				bool_8 = true;
			}
			if (Encryption == Enum903.const_0)
			{
				enum903_0 = Enum903.const_1;
			}
		}
	}

	[Obsolete("Please use property ExtractExistingFile")]
	public bool OverwriteOnExtract
	{
		get
		{
			return ExtractExistingFile == Enum904.const_1;
		}
		set
		{
			ExtractExistingFile = (value ? Enum904.const_1 : Enum904.const_0);
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

	public bool IncludedInMostRecentSave => !bool_10;

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

	public bool UseUnicodeAsNecessary
	{
		get
		{
			return encoding_1 == Encoding.GetEncoding("UTF-8");
		}
		set
		{
			encoding_1 = (value ? Encoding.GetEncoding("UTF-8") : Class6752.encoding_0);
		}
	}

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

	public Encoding ActualEncoding => encoding_2;

	public bool IsText
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	internal int LengthOfCryptoHeaderBytes
	{
		get
		{
			if ((short_1 & 1) != 1)
			{
				return 0;
			}
			if (Encryption != Enum903.const_1)
			{
				throw new Exception61("internal error");
			}
			return 12;
		}
	}

	internal long FileDataPosition
	{
		get
		{
			if (long_3 == -1L)
			{
				method_3();
			}
			return long_3;
		}
	}

	private int LengthOfHeader
	{
		get
		{
			if (int_2 == 0)
			{
				method_3();
			}
			return int_2;
		}
	}

	internal bool AttributesIndicateDirectory
	{
		get
		{
			if (short_4 == 0)
			{
				return (int_4 & 0x10) == 16;
			}
			return false;
		}
	}

	internal Stream ArchiveStream
	{
		get
		{
			if (stream_0 == null && class6752_0 != null)
			{
				class6752_0.Reset();
				stream_0 = class6752_0.ReadStream;
			}
			return stream_0;
		}
	}

	private string UnsupportedAlgorithm => uint_0 switch
	{
		26113u => "DES", 
		26114u => "RC2", 
		26115u => "3DES-168", 
		0u => "--", 
		26126u => "PKWare AES128", 
		26127u => "PKWare AES192", 
		26128u => "PKWare AES256", 
		26121u => "3DES-112", 
		26400u => "Blowfish", 
		26401u => "Twofish", 
		26370u => "RC2", 
		26625u => "RC4", 
		_ => $"Unknown (0x{uint_0:X4})", 
	};

	private string UnsupportedCompressionMethod => short_2 switch
	{
		8 => "DEFLATE", 
		9 => "Deflate64", 
		0 => "Store", 
		1 => "Shrink", 
		98 => "PPMd", 
		19 => "LZ77", 
		14 => "LZMA", 
		_ => $"Unknown (0x{short_2:X4})", 
	};

	public void method_0(DateTime created, DateTime accessed, DateTime modified)
	{
		bool_0 = true;
		dateTime_3 = created.ToUniversalTime();
		dateTime_2 = accessed.ToUniversalTime();
		dateTime_1 = modified.ToUniversalTime();
		dateTime_0 = dateTime_1;
		bool_1 = true;
		bool_7 = true;
	}

	[Obsolete("Please use method SetEntryTimes(DateTime,DateTime,DateTime)")]
	public void method_1(DateTime created, DateTime accessed, DateTime modified)
	{
		method_0(created, accessed, modified);
	}

	internal static string smethod_0(string filename, string directoryPathInArchive)
	{
		string pathName = ((directoryPathInArchive == null) ? filename : ((directoryPathInArchive == null || directoryPathInArchive.Length == 0) ? Path.GetFileName(filename) : Path.Combine(directoryPathInArchive, Path.GetFileName(filename))));
		pathName = Class6748.smethod_2(pathName);
		pathName = Class6748.smethod_1(pathName);
		while (pathName.StartsWith("/"))
		{
			pathName = pathName.Substring(1);
		}
		return pathName;
	}

	internal static Class6751 smethod_1(string filename, string nameInArchive)
	{
		return smethod_2(filename, nameInArchive, isStream: false, null);
	}

	internal static Class6751 smethod_2(string filename, string nameInArchive, bool isStream, Stream stream)
	{
		if (filename != null && filename.Length != 0)
		{
			Class6751 @class = new Class6751();
			@class.short_3 = 45;
			if (isStream)
			{
				@class.enum909_0 = Enum909.const_2;
				@class.stream_1 = stream;
				@class.dateTime_1 = (@class.dateTime_2 = (@class.dateTime_3 = DateTime.UtcNow));
			}
			else
			{
				@class.enum909_0 = Enum909.const_1;
				@class.dateTime_1 = File.GetLastWriteTimeUtc(filename);
				@class.dateTime_3 = File.GetCreationTimeUtc(filename);
				@class.dateTime_2 = File.GetLastAccessTimeUtc(filename);
				if (File.Exists(filename) || Directory.Exists(filename))
				{
					@class.int_4 = (int)File.GetAttributes(filename);
				}
				@class.bool_0 = true;
			}
			@class.dateTime_0 = @class.dateTime_1;
			@class.string_0 = (isStream ? filename : Path.GetFullPath(filename));
			@class.string_1 = nameInArchive.Replace('\\', '/');
			return @class;
		}
		throw new Exception61("The entry name must be non-null and non-empty.");
	}

	internal void method_2()
	{
		bool_5 = true;
		if (!string_1.EndsWith("/"))
		{
			string_1 += "/";
		}
	}

	public override string ToString()
	{
		return $"ZipEntry/{FileName}";
	}

	private void method_3()
	{
		long position = ArchiveStream.Position;
		try
		{
			class6752_0.method_68(long_4);
		}
		catch (IOException innerException)
		{
			string message = $"Exception seeking  entry({FileName}) offset(0x{long_4:X8}) len(0x{ArchiveStream.Length:X8})";
			throw new Exception66(message, innerException);
		}
		byte[] array = new byte[30];
		ArchiveStream.Read(array, 0, array.Length);
		short num = (short)(array[26] + array[27] * 256);
		short num2 = (short)(array[28] + array[29] * 256);
		ArchiveStream.Seek(num + num2, SeekOrigin.Current);
		int_2 = 30 + num2 + num + LengthOfCryptoHeaderBytes;
		long_3 = long_4 + int_2;
		ArchiveStream.Seek(position, SeekOrigin.Begin);
	}

	internal void method_4()
	{
		long_3 = -1L;
		int_2 = 0;
	}

	internal static Class6751 smethod_3(Class6752 zf)
	{
		Stream readStream = zf.ReadStream;
		Encoding provisionalAlternateEncoding = zf.ProvisionalAlternateEncoding;
		int num = Class6748.smethod_7(readStream);
		if (smethod_4(num))
		{
			readStream.Seek(-4L, SeekOrigin.Current);
			if (num != 101010256L && num != 101075792L && num != 67324752)
			{
				throw new Exception63($"  ZipEntry::ReadDirEntry(): Bad signature (0x{num:X8}) at position 0x{readStream.Position:X8}");
			}
			return null;
		}
		int num2 = 46;
		byte[] array = new byte[42];
		int num3 = readStream.Read(array, 0, array.Length);
		if (num3 != array.Length)
		{
			return null;
		}
		Class6751 @class = new Class6751();
		@class.enum909_0 = Enum909.const_3;
		@class.stream_0 = readStream;
		@class.class6752_0 = zf;
		@class.short_3 = (short)(array[0] + array[1] * 256);
		@class.short_0 = (short)(array[2] + array[3] * 256);
		@class.short_1 = (short)(array[4] + array[5] * 256);
		@class.short_2 = (short)(array[6] + array[7] * 256);
		@class.int_0 = array[8] + array[9] * 256 + array[10] * 256 * 256 + array[11] * 256 * 256 * 256;
		@class.dateTime_0 = Class6748.smethod_13(@class.int_0);
		@class.enum910_0 |= Enum910.flag_1;
		@class.int_1 = array[12] + array[13] * 256 + array[14] * 256 * 256 + array[15] * 256 * 256 * 256;
		@class.long_0 = (uint)(array[16] + array[17] * 256 + array[18] * 256 * 256 + array[19] * 256 * 256 * 256);
		@class.long_2 = (uint)(array[20] + array[21] * 256 + array[22] * 256 * 256 + array[23] * 256 * 256 * 256);
		@class.short_5 = (short)(array[24] + array[25] * 256);
		@class.short_6 = (short)(array[26] + array[27] * 256);
		@class.short_7 = (short)(array[28] + array[29] * 256);
		@class.short_4 = (short)(array[32] + array[33] * 256);
		@class.int_4 = array[34] + array[35] * 256 + array[36] * 256 * 256 + array[37] * 256 * 256 * 256;
		@class.long_4 = (uint)(array[38] + array[39] * 256 + array[40] * 256 * 256 + array[41] * 256 * 256 * 256);
		@class.IsText = (@class.short_4 & 1) == 1;
		array = new byte[@class.short_5];
		num3 = readStream.Read(array, 0, array.Length);
		num2 += num3;
		if ((@class.short_1 & 0x800) == 2048)
		{
			@class.string_0 = Class6748.smethod_5(array);
		}
		else
		{
			@class.string_0 = Class6748.smethod_6(array, provisionalAlternateEncoding);
		}
		@class.string_1 = @class.string_0;
		if (@class.AttributesIndicateDirectory)
		{
			@class.method_2();
		}
		if (@class.string_0.EndsWith("/"))
		{
			@class.method_2();
		}
		@class.long_1 = @class.long_0;
		if ((@class.short_1 & 1) == 1)
		{
			@class.enum903_0 = Enum903.const_1;
			@class.bool_9 = true;
		}
		if (@class.short_6 > 0)
		{
			@class.bool_11 = @class.long_0 == 4294967295L || @class.long_2 == 4294967295L || @class.long_4 == 4294967295L;
			num2 += @class.method_38(@class.short_6);
			@class.long_1 = @class.long_0;
		}
		if (@class.enum903_0 == Enum903.const_1)
		{
			@class.long_1 -= 12L;
		}
		if ((@class.short_1 & 8) == 8)
		{
			if (@class.bool_11)
			{
				@class.int_3 += 24;
			}
			else
			{
				@class.int_3 += 16;
			}
		}
		if (@class.short_7 > 0)
		{
			array = new byte[@class.short_7];
			num3 = readStream.Read(array, 0, array.Length);
			num2 += num3;
			if ((@class.short_1 & 0x800) == 2048)
			{
				@class.string_2 = Class6748.smethod_5(array);
			}
			else
			{
				@class.string_2 = Class6748.smethod_6(array, provisionalAlternateEncoding);
			}
		}
		return @class;
	}

	internal static bool smethod_4(int signature)
	{
		return signature != 33639248;
	}

	public void method_5()
	{
		method_27(".", null, null);
	}

	[Obsolete("Please use method Extract(ExtractExistingFileAction)")]
	public void method_6(bool overwrite)
	{
		OverwriteOnExtract = overwrite;
		method_27(".", null, null);
	}

	public void method_7(Enum904 extractExistingFile)
	{
		ExtractExistingFile = extractExistingFile;
		method_27(".", null, null);
	}

	public void method_8(Stream stream)
	{
		method_27(null, stream, null);
	}

	public void method_9(string baseDirectory)
	{
		method_27(baseDirectory, null, null);
	}

	[Obsolete("Please use method Extract(String,ExtractExistingFileAction)")]
	public void method_10(string baseDirectory, bool overwrite)
	{
		OverwriteOnExtract = overwrite;
		method_27(baseDirectory, null, null);
	}

	public void method_11(string baseDirectory, Enum904 extractExistingFile)
	{
		ExtractExistingFile = extractExistingFile;
		method_27(baseDirectory, null, null);
	}

	public void method_12(string password)
	{
		method_27(".", null, password);
	}

	public void method_13(string baseDirectory, string password)
	{
		method_27(baseDirectory, null, password);
	}

	[Obsolete("Please use method ExtractWithPassword(ExtractExistingFileAction,String)")]
	public void method_14(bool overwrite, string password)
	{
		OverwriteOnExtract = overwrite;
		method_27(".", null, password);
	}

	public void method_15(Enum904 extractExistingFile, string password)
	{
		ExtractExistingFile = extractExistingFile;
		method_27(".", null, password);
	}

	[Obsolete("Please use method ExtractWithPassword(String,ExtractExistingFileAction,String)")]
	public void method_16(string baseDirectory, bool overwrite, string password)
	{
		OverwriteOnExtract = overwrite;
		method_27(baseDirectory, null, password);
	}

	public void method_17(string baseDirectory, Enum904 extractExistingFile, string password)
	{
		ExtractExistingFile = extractExistingFile;
		method_27(baseDirectory, null, password);
	}

	public void method_18(Stream stream, string password)
	{
		method_27(null, stream, password);
	}

	public Stream7 method_19()
	{
		return method_21((string_3 != null) ? string_3 : class6752_0.string_2);
	}

	public Stream7 method_20(string password)
	{
		return method_21(password);
	}

	private Stream7 method_21(string password)
	{
		method_34();
		method_33();
		method_35(password);
		if (enum909_0 != Enum909.const_3)
		{
			throw new Exception66("You must call ZipFile.Save before calling OpenReader.");
		}
		Stream archiveStream = ArchiveStream;
		class6752_0.method_68(FileDataPosition);
		Stream stream = archiveStream;
		if (Encryption == Enum903.const_1)
		{
			stream = new Stream11(archiveStream, class6750_0, Enum913.const_1);
		}
		return new Stream7((CompressionMethod == 8) ? new Stream8(stream, Enum916.const_1, leaveOpen: true) : stream, long_2);
	}

	private void method_22(long bytesWritten, long totalBytesToWrite)
	{
		bool_13 = class6752_0.method_48(this, bytesWritten, totalBytesToWrite);
	}

	private void method_23(string path)
	{
		if (!class6752_0.bool_15)
		{
			bool_13 = class6752_0.method_49(this, path, before: true);
		}
	}

	private void method_24(string path)
	{
		if (!class6752_0.bool_15)
		{
			class6752_0.method_49(this, path, before: false);
		}
	}

	private void method_25(string path)
	{
		bool_13 = class6752_0.method_50(this, path);
	}

	private void method_26(long bytesXferred, long totalBytesToXfer)
	{
		bool_13 = class6752_0.method_38(this, bytesXferred, totalBytesToXfer);
	}

	private static void smethod_5(string fileName)
	{
		if ((File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
		{
			File.SetAttributes(fileName, FileAttributes.Normal);
		}
		File.Delete(fileName);
	}

	private void method_27(string baseDir, Stream outstream, string password)
	{
		if (class6752_0 == null)
		{
			throw new Exception66("This ZipEntry is an orphan.");
		}
		class6752_0.Reset();
		if (enum909_0 != Enum909.const_3)
		{
			throw new Exception66("You must call ZipFile.Save before calling any Extract method.");
		}
		method_23(baseDir);
		bool_13 = false;
		string OutputFile = null;
		Stream stream = null;
		bool fileExistsBeforeExtraction = false;
		bool flag = false;
		try
		{
			method_34();
			method_33();
			if (method_36(baseDir, outstream, out OutputFile))
			{
				if (class6752_0.Verbose)
				{
					class6752_0.StatusMessageTextWriter.WriteLine("extract dir {0}...", OutputFile);
				}
				method_24(baseDir);
				return;
			}
			string text = ((password != null) ? password : ((string_3 != null) ? string_3 : class6752_0.string_2));
			if (UsesEncryption)
			{
				if (text == null)
				{
					throw new Exception62();
				}
				method_35(text);
			}
			if (OutputFile != null)
			{
				if (class6752_0.Verbose)
				{
					class6752_0.StatusMessageTextWriter.WriteLine("extract file {0}...", OutputFile);
				}
				if (!Directory.Exists(Path.GetDirectoryName(OutputFile)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(OutputFile));
				}
				else
				{
					flag = class6752_0.bool_15;
				}
				if (File.Exists(OutputFile))
				{
					fileExistsBeforeExtraction = true;
					switch (method_29(baseDir, OutputFile))
					{
					case 2:
						method_28(OutputFile, stream, fileExistsBeforeExtraction);
						return;
					case 1:
						return;
					}
				}
				stream = new FileStream(OutputFile, FileMode.CreateNew);
			}
			else
			{
				if (class6752_0.Verbose)
				{
					class6752_0.StatusMessageTextWriter.WriteLine("extract entry {0} to stream...", FileName);
				}
				stream = outstream;
			}
			if (bool_13)
			{
				method_28(OutputFile, stream, fileExistsBeforeExtraction);
				return;
			}
			int num = method_31(stream);
			if (bool_13)
			{
				method_28(OutputFile, stream, fileExistsBeforeExtraction);
				return;
			}
			if (num != int_1)
			{
				throw new Exception64("CRC error: the file being extracted appears to be corrupted. " + $"Expected 0x{int_1:X8}, Actual 0x{num:X8}");
			}
			if (OutputFile != null)
			{
				stream.Close();
				stream = null;
				method_32(OutputFile, isFile: true);
				if (flag && FileName.IndexOf('/') != -1)
				{
					string directoryName = Path.GetDirectoryName(FileName);
					if (class6752_0[directoryName] == null)
					{
						method_32(Path.GetDirectoryName(OutputFile), isFile: false);
					}
				}
				if ((short_3 & 0xFF00) == 2560 || (short_3 & 0xFF00) == 0)
				{
					File.SetAttributes(OutputFile, (FileAttributes)int_4);
				}
			}
			method_24(baseDir);
		}
		catch (Exception ex)
		{
			bool_13 = true;
			if (!(ex is Exception61))
			{
				throw new Exception61("Cannot extract", ex);
			}
			throw;
		}
		finally
		{
			method_28(OutputFile, stream, fileExistsBeforeExtraction);
		}
	}

	private void method_28(string TargetFile, Stream output, bool fileExistsBeforeExtraction)
	{
		if (bool_13 && TargetFile != null)
		{
			output?.Close();
			if (File.Exists(TargetFile) && (!fileExistsBeforeExtraction || ExtractExistingFile == Enum904.const_1))
			{
				File.Delete(TargetFile);
			}
		}
	}

	private int method_29(string baseDir, string TargetFile)
	{
		int num = 0;
		while (true)
		{
			switch (ExtractExistingFile)
			{
			case Enum904.const_3:
				if (num <= 0)
				{
					method_25(baseDir);
					if (bool_13)
					{
						return 2;
					}
					break;
				}
				throw new Exception61($"The file {TargetFile} already exists.");
			default:
				throw new Exception61($"The file {TargetFile} already exists.");
			case Enum904.const_1:
				if (class6752_0.Verbose)
				{
					class6752_0.StatusMessageTextWriter.WriteLine("the file {0} exists; deleting it...", TargetFile);
				}
				smethod_5(TargetFile);
				return 0;
			case Enum904.const_2:
				if (class6752_0.Verbose)
				{
					class6752_0.StatusMessageTextWriter.WriteLine("the file {0} exists; not extracting entry...", FileName);
				}
				method_24(baseDir);
				return 1;
			}
			num++;
		}
	}

	private void method_30(int nbytes)
	{
		if (nbytes == 0)
		{
			throw new Exception63($"bad read of entry {FileName} from compressed archive.");
		}
	}

	private int method_31(Stream output)
	{
		Stream archiveStream = ArchiveStream;
		class6752_0.method_68(FileDataPosition);
		byte[] array = new byte[BufferSize];
		long num = ((CompressionMethod == 8) ? UncompressedSize : long_1);
		Stream stream = ((Encryption != Enum903.const_1) ? archiveStream : new Stream11(archiveStream, class6750_0, Enum913.const_1));
		Stream stream2 = ((CompressionMethod == 8) ? new Stream8(stream, Enum916.const_1, leaveOpen: true) : stream);
		long num2 = 0L;
		using Stream7 stream3 = new Stream7(stream2);
		while (num > 0L)
		{
			int count = (int)((num > array.Length) ? array.Length : num);
			int num3 = stream3.Read(array, 0, count);
			method_30(num3);
			output.Write(array, 0, num3);
			num -= num3;
			num2 += num3;
			method_22(num2, UncompressedSize);
			if (bool_13)
			{
				break;
			}
		}
		return stream3.Crc;
	}

	internal void method_32(string fileOrDirectory, bool isFile)
	{
		if (bool_0)
		{
			if (isFile)
			{
				if (File.Exists(fileOrDirectory))
				{
					File.SetCreationTimeUtc(fileOrDirectory, dateTime_3);
					File.SetLastAccessTimeUtc(fileOrDirectory, dateTime_2);
					File.SetLastWriteTimeUtc(fileOrDirectory, dateTime_1);
				}
			}
			else if (Directory.Exists(fileOrDirectory))
			{
				Directory.SetCreationTimeUtc(fileOrDirectory, dateTime_3);
				Directory.SetLastAccessTimeUtc(fileOrDirectory, dateTime_2);
				Directory.SetLastWriteTimeUtc(fileOrDirectory, dateTime_1);
			}
		}
		else
		{
			DateTime lastWriteTime = Class6748.smethod_11(LastModified);
			if (isFile)
			{
				File.SetLastWriteTime(fileOrDirectory, lastWriteTime);
			}
			else
			{
				Directory.SetLastWriteTime(fileOrDirectory, lastWriteTime);
			}
		}
	}

	private void method_33()
	{
		if (Encryption != Enum903.const_1 && Encryption != 0)
		{
			if (uint_0 != 0)
			{
				throw new Exception61($"Cannot extract: Entry {FileName} is encrypted with an algorithm not supported by DotNetZip: {UnsupportedAlgorithm}");
			}
			throw new Exception61($"Cannot extract: Entry {FileName} uses an unsupported encryption algorithm ({(int)Encryption:X2})");
		}
	}

	private void method_34()
	{
		if (CompressionMethod != 0 && CompressionMethod != 8)
		{
			throw new Exception61($"Entry {FileName} uses an unsupported compression method (0x{CompressionMethod:X2}, {UnsupportedCompressionMethod})");
		}
	}

	private void method_35(string password)
	{
		if (password != null && Encryption == Enum903.const_1)
		{
			class6752_0.method_68(FileDataPosition - 12L);
			class6750_0 = Class6750.smethod_1(password, this);
		}
	}

	private bool method_36(string basedir, Stream outstream, out string OutputFile)
	{
		if (basedir != null)
		{
			string text = FileName;
			if (text.StartsWith("/"))
			{
				text = FileName.Substring(1);
			}
			if (class6752_0.FlattenFoldersOnExtract)
			{
				OutputFile = Path.Combine(basedir, (text.IndexOf('/') != -1) ? Path.GetFileName(text) : text);
			}
			else
			{
				OutputFile = Path.Combine(basedir, text);
			}
			if (!IsDirectory && !FileName.EndsWith("/"))
			{
				return false;
			}
			if (!Directory.Exists(OutputFile))
			{
				Directory.CreateDirectory(OutputFile);
				method_32(OutputFile, isFile: false);
			}
			else if (ExtractExistingFile == Enum904.const_1)
			{
				method_32(OutputFile, isFile: false);
			}
			return true;
		}
		if (outstream != null)
		{
			OutputFile = null;
			if (!IsDirectory && !FileName.EndsWith("/"))
			{
				return false;
			}
			return true;
		}
		throw new Exception61("Cannot extract.", new ArgumentException("Invalid input.", "outstream"));
	}

	private void method_37()
	{
		int_5++;
		long position = ArchiveStream.Position;
		class6752_0.method_68(long_4);
		byte[] array = new byte[30];
		ArchiveStream.Read(array, 0, array.Length);
		short num = (short)(array[26] + array[27] * 256);
		short extraFieldLength = (short)(array[28] + array[29] * 256);
		ArchiveStream.Seek(num, SeekOrigin.Current);
		method_38(extraFieldLength);
		ArchiveStream.Seek(position, SeekOrigin.Begin);
		int_5--;
	}

	private static bool smethod_6(Class6751 ze, Encoding defaultEncoding)
	{
		int num = 0;
		ze.long_4 = ze.class6752_0.RelativeOffset;
		int num2 = Class6748.smethod_7(ze.ArchiveStream);
		num = 4;
		if (smethod_8(num2))
		{
			ze.ArchiveStream.Seek(-4L, SeekOrigin.Current);
			if (smethod_4(num2) && num2 != 101010256L)
			{
				throw new Exception63($"  ZipEntry::ReadHeader(): Bad signature (0x{num2:X8}) at position  0x{ze.ArchiveStream.Position:X8}");
			}
			return false;
		}
		byte[] array = new byte[26];
		int num3 = ze.ArchiveStream.Read(array, 0, array.Length);
		if (num3 != array.Length)
		{
			return false;
		}
		num += num3;
		int num4 = 0;
		byte[] array2 = array;
		num4 = 1;
		byte num5 = array2[0];
		byte[] array3 = array;
		num4 = 2;
		ze.short_0 = (short)(num5 + array3[1] * 256);
		byte[] array4 = array;
		num4 = 3;
		byte num6 = array4[2];
		byte[] array5 = array;
		num4 = 4;
		ze.short_1 = (short)(num6 + array5[3] * 256);
		byte[] array6 = array;
		num4 = 5;
		byte num7 = array6[4];
		byte[] array7 = array;
		num4 = 6;
		ze.short_2 = (short)(num7 + array7[5] * 256);
		byte[] array8 = array;
		num4 = 7;
		byte num8 = array8[6];
		byte[] array9 = array;
		num4 = 8;
		int num9 = num8 + array9[7] * 256;
		byte[] array10 = array;
		num4 = 9;
		int num10 = num9 + array10[8] * 256 * 256;
		byte[] array11 = array;
		num4 = 10;
		ze.int_0 = num10 + array11[9] * 256 * 256 * 256;
		ze.dateTime_0 = Class6748.smethod_13(ze.int_0);
		ze.enum910_0 |= Enum910.flag_1;
		byte[] array12 = array;
		num4 = 11;
		byte num11 = array12[10];
		byte[] array13 = array;
		num4 = 12;
		int num12 = num11 + array13[11] * 256;
		byte[] array14 = array;
		num4 = 13;
		int num13 = num12 + array14[12] * 256 * 256;
		byte[] array15 = array;
		num4 = 14;
		ze.int_1 = num13 + array15[13] * 256 * 256 * 256;
		byte[] array16 = array;
		num4 = 15;
		byte num14 = array16[14];
		byte[] array17 = array;
		num4 = 16;
		int num15 = num14 + array17[15] * 256;
		byte[] array18 = array;
		num4 = 17;
		int num16 = num15 + array18[16] * 256 * 256;
		byte[] array19 = array;
		num4 = 18;
		ze.long_0 = (uint)(num16 + array19[17] * 256 * 256 * 256);
		byte[] array20 = array;
		num4 = 19;
		byte num17 = array20[18];
		byte[] array21 = array;
		num4 = 20;
		int num18 = num17 + array21[19] * 256;
		byte[] array22 = array;
		num4 = 21;
		int num19 = num18 + array22[20] * 256 * 256;
		byte[] array23 = array;
		num4 = 22;
		ze.long_2 = (uint)(num19 + array23[21] * 256 * 256 * 256);
		if ((int)ze.long_0 == -1 || (int)ze.long_2 == -1)
		{
			ze.bool_11 = true;
		}
		short num20 = (short)(array[num4++] + array[num4++] * 256);
		short extraFieldLength = (short)(array[num4++] + array[num4++] * 256);
		array = new byte[num20];
		num3 = ze.ArchiveStream.Read(array, 0, array.Length);
		num += num3;
		ze.encoding_2 = (((ze.short_1 & 0x800) == 2048) ? Encoding.UTF8 : defaultEncoding);
		ze.string_1 = ze.encoding_2.GetString(array, 0, array.Length);
		ze.string_0 = ze.string_1;
		if (ze.string_0.EndsWith("/"))
		{
			ze.method_2();
		}
		num += ze.method_38(extraFieldLength);
		ze.int_3 = 0;
		if (!ze.string_0.EndsWith("/") && (ze.short_1 & 8) == 8)
		{
			long position = ze.ArchiveStream.Position;
			bool flag = true;
			long num21 = 0L;
			int num22 = 0;
			while (flag)
			{
				num22++;
				ze.class6752_0.method_45(ze);
				long num23 = Class6748.smethod_10(ze.ArchiveStream, 134695760);
				if (num23 != -1L)
				{
					num21 += num23;
					if (ze.bool_11)
					{
						array = new byte[20];
						num3 = ze.ArchiveStream.Read(array, 0, array.Length);
						if (num3 != 20)
						{
							return false;
						}
						num4 = 0;
						byte[] array24 = array;
						num4 = 1;
						byte num24 = array24[0];
						byte[] array25 = array;
						num4 = 2;
						int num25 = num24 + array25[1] * 256;
						byte[] array26 = array;
						num4 = 3;
						int num26 = num25 + array26[2] * 256 * 256;
						byte[] array27 = array;
						num4 = 4;
						ze.int_1 = num26 + array27[3] * 256 * 256 * 256;
						ze.long_0 = BitConverter.ToInt64(array, 4);
						num4 = 12;
						ze.long_2 = BitConverter.ToInt64(array, 12);
						num4 = 20;
						ze.int_3 += 24;
					}
					else
					{
						array = new byte[12];
						num3 = ze.ArchiveStream.Read(array, 0, array.Length);
						if (num3 != 12)
						{
							return false;
						}
						num4 = 0;
						byte[] array28 = array;
						num4 = 1;
						byte num27 = array28[0];
						byte[] array29 = array;
						num4 = 2;
						int num28 = num27 + array29[1] * 256;
						byte[] array30 = array;
						num4 = 3;
						int num29 = num28 + array30[2] * 256 * 256;
						byte[] array31 = array;
						num4 = 4;
						ze.int_1 = num29 + array31[3] * 256 * 256 * 256;
						byte[] array32 = array;
						num4 = 5;
						byte num30 = array32[4];
						byte[] array33 = array;
						num4 = 6;
						int num31 = num30 + array33[5] * 256;
						byte[] array34 = array;
						num4 = 7;
						int num32 = num31 + array34[6] * 256 * 256;
						byte[] array35 = array;
						num4 = 8;
						ze.long_0 = (uint)(num32 + array35[7] * 256 * 256 * 256);
						byte[] array36 = array;
						num4 = 9;
						byte num33 = array36[8];
						byte[] array37 = array;
						num4 = 10;
						int num34 = num33 + array37[9] * 256;
						byte[] array38 = array;
						num4 = 11;
						int num35 = num34 + array38[10] * 256 * 256;
						byte[] array39 = array;
						num4 = 12;
						ze.long_2 = (uint)(num35 + array39[11] * 256 * 256 * 256);
						ze.int_3 += 16;
					}
					if (flag = num21 != ze.long_0)
					{
						ze.ArchiveStream.Seek(-12L, SeekOrigin.Current);
						num21 += 4L;
					}
					continue;
				}
				return false;
			}
			ze.ArchiveStream.Seek(position, SeekOrigin.Begin);
		}
		ze.long_1 = ze.long_0;
		if ((ze.short_1 & 1) == 1)
		{
			ze.byte_3 = new byte[12];
			num += smethod_7(ze.stream_0, ze.byte_3);
			ze.long_1 -= 12L;
		}
		ze.int_2 = num;
		ze.long_5 = ze.int_2 + ze.long_1 + ze.int_3;
		return true;
	}

	internal static int smethod_7(Stream s, byte[] buffer)
	{
		int num = s.Read(buffer, 0, 12);
		if (num != 12)
		{
			throw new Exception61($"Unexpected end of data at position 0x{s.Position:X8}");
		}
		return num;
	}

	private static bool smethod_8(int signature)
	{
		return signature != 67324752;
	}

	internal static Class6751 Read(Class6752 zf, bool first)
	{
		Stream readStream = zf.ReadStream;
		Encoding provisionalAlternateEncoding = zf.ProvisionalAlternateEncoding;
		Class6751 @class = new Class6751();
		@class.enum909_0 = Enum909.const_3;
		@class.class6752_0 = zf;
		@class.stream_0 = readStream;
		zf.method_46(before: true, null);
		if (first)
		{
			smethod_9(readStream);
		}
		if (!smethod_6(@class, provisionalAlternateEncoding))
		{
			return null;
		}
		@class.long_3 = @class.class6752_0.RelativeOffset;
		readStream.Seek(@class.long_1 + @class.int_3, SeekOrigin.Current);
		smethod_10(@class);
		zf.method_45(@class);
		zf.method_46(before: false, @class);
		return @class;
	}

	internal static void smethod_9(Stream s)
	{
		uint num = (uint)Class6748.smethod_8(s);
		if (num != 808471376)
		{
			s.Seek(-4L, SeekOrigin.Current);
		}
	}

	private static void smethod_10(Class6751 entry)
	{
		Stream archiveStream = entry.ArchiveStream;
		uint num = (uint)Class6748.smethod_8(archiveStream);
		if (num == entry.int_1)
		{
			int num2 = Class6748.smethod_8(archiveStream);
			if (num2 == entry.long_0)
			{
				num2 = Class6748.smethod_8(archiveStream);
				if (num2 != entry.long_2)
				{
					archiveStream.Seek(-12L, SeekOrigin.Current);
				}
			}
			else
			{
				archiveStream.Seek(-8L, SeekOrigin.Current);
			}
		}
		else
		{
			archiveStream.Seek(-4L, SeekOrigin.Current);
		}
	}

	internal int method_38(short extraFieldLength)
	{
		int num = 0;
		Stream archiveStream = ArchiveStream;
		if (extraFieldLength > 0)
		{
			byte[] array = (byte_1 = new byte[extraFieldLength]);
			num = archiveStream.Read(array, 0, array.Length);
			long posn = archiveStream.Position - num;
			int num2 = 0;
			while (num2 < array.Length)
			{
				int num3 = num2;
				ushort num4 = (ushort)(array[num2] + array[num2 + 1] * 256);
				short num5 = (short)(array[num2 + 2] + array[num2 + 3] * 256);
				num2 += 4;
				switch (num4)
				{
				case 10:
					num2 = method_43(array, num2, num5, posn);
					break;
				case 1:
					num2 = method_40(array, num2, num5, posn);
					break;
				case 22613:
					num2 = method_41(array, num2, num5, posn);
					break;
				case 21589:
					num2 = method_42(array, num2, num5, posn);
					break;
				case 23:
					num2 = method_39(array, num2);
					break;
				}
				num2 = num3 + num5 + 4;
			}
		}
		return num;
	}

	private int method_39(byte[] Buffer, int j)
	{
		j += 2;
		uint_0 = (ushort)(Buffer[j] + Buffer[j + 1] * 256);
		j += 2;
		enum903_0 = Enum903.const_2;
		return j;
	}

	private int method_40(byte[] Buffer, int j, short DataSize, long posn)
	{
		bool_11 = true;
		if (DataSize > 28)
		{
			throw new Exception63($"  Inconsistent datasize (0x{DataSize:X4}) for ZIP64 extra field at position 0x{posn:X16}");
		}
		int num = DataSize;
		if (long_2 == 4294967295L)
		{
			if (num < 8)
			{
				throw new Exception63(string.Format("  Missing data for ZIP64 extra field (Uncompressed Size) at position 0x{1:X16}", posn));
			}
			long_2 = BitConverter.ToInt64(Buffer, j);
			j += 8;
			num -= 8;
		}
		if (long_0 == 4294967295L)
		{
			if (num < 8)
			{
				throw new Exception63(string.Format("  Missing data for ZIP64 extra field (Compressed Size) at position 0x{1:X16}", posn));
			}
			long_0 = BitConverter.ToInt64(Buffer, j);
			j += 8;
			num -= 8;
		}
		if (long_4 == 4294967295L)
		{
			if (num < 8)
			{
				throw new Exception63(string.Format("  Missing data for ZIP64 extra field (Relative Offset) at position 0x{1:X16}", posn));
			}
			long_4 = BitConverter.ToInt64(Buffer, j);
			j += 8;
			num -= 8;
		}
		return j;
	}

	private int method_41(byte[] Buffer, int j, short DataSize, long posn)
	{
		if (DataSize != 12 && DataSize != 8)
		{
			throw new Exception63($"  Unexpected datasize (0x{DataSize:X4}) for InfoZip v1 extra field at position 0x{posn:X16}");
		}
		int num = BitConverter.ToInt32(Buffer, j);
		dateTime_1 = dateTime_4.AddSeconds(num);
		j += 4;
		num = BitConverter.ToInt32(Buffer, j);
		dateTime_2 = dateTime_4.AddSeconds(num);
		j += 4;
		dateTime_3 = DateTime.UtcNow;
		bool_0 = true;
		enum910_0 |= Enum910.flag_4;
		return j;
	}

	private int method_42(byte[] Buffer, int j, short DataSize, long posn)
	{
		if (DataSize != 13 && DataSize != 9 && DataSize != 5)
		{
			throw new Exception63($"  Unexpected datasize (0x{DataSize:X4}) for Extended Timestamp extra field at position 0x{posn:X16}");
		}
		int num = DataSize;
		if (DataSize != 13 && int_5 <= 1)
		{
			method_37();
		}
		else
		{
			byte b = Buffer[j++];
			num--;
			if (((uint)b & (true ? 1u : 0u)) != 0 && num >= 4)
			{
				int num2 = BitConverter.ToInt32(Buffer, j);
				dateTime_1 = dateTime_4.AddSeconds(num2);
				j += 4;
				num -= 4;
			}
			if ((b & 2u) != 0 && num >= 4)
			{
				int num3 = BitConverter.ToInt32(Buffer, j);
				dateTime_2 = dateTime_4.AddSeconds(num3);
				j += 4;
				num -= 4;
			}
			else
			{
				dateTime_2 = DateTime.UtcNow;
			}
			if ((b & 4u) != 0 && num >= 4)
			{
				int num4 = BitConverter.ToInt32(Buffer, j);
				dateTime_3 = dateTime_4.AddSeconds(num4);
				j += 4;
				num -= 4;
			}
			else
			{
				dateTime_3 = DateTime.UtcNow;
			}
			enum910_0 |= Enum910.flag_3;
			bool_0 = true;
			bool_2 = true;
		}
		return j;
	}

	private int method_43(byte[] Buffer, int j, short DataSize, long posn)
	{
		if (DataSize != 32)
		{
			throw new Exception63($"  Unexpected datasize (0x{DataSize:X4}) for NTFS times extra field at position 0x{posn:X16}");
		}
		j += 4;
		short num = (short)(Buffer[j] + Buffer[j + 1] * 256);
		short num2 = (short)(Buffer[j + 2] + Buffer[j + 3] * 256);
		j += 4;
		if (num == 1 && num2 == 24)
		{
			long fileTime = BitConverter.ToInt64(Buffer, j);
			dateTime_1 = DateTime.FromFileTimeUtc(fileTime);
			j += 8;
			fileTime = BitConverter.ToInt64(Buffer, j);
			dateTime_2 = DateTime.FromFileTimeUtc(fileTime);
			j += 8;
			fileTime = BitConverter.ToInt64(Buffer, j);
			dateTime_3 = DateTime.FromFileTimeUtc(fileTime);
			j += 8;
			bool_0 = true;
			enum910_0 |= Enum910.flag_2;
			bool_1 = true;
		}
		return j;
	}

	internal void method_44(Stream s)
	{
		method_45(s);
	}

	private void method_45(Stream s)
	{
		byte[] array = new byte[4096];
		int num = 0;
		num = 1;
		array[0] = 80;
		num = 2;
		array[1] = 75;
		num = 3;
		array[2] = 1;
		num = 4;
		array[3] = 2;
		num = 5;
		array[4] = (byte)((uint)short_3 & 0xFFu);
		num = 6;
		array[5] = (byte)((short_3 & 0xFF00) >> 8);
		short num2 = (short)((enum906_1 == Enum906.const_2) ? 45 : 20);
		array[num++] = (byte)((uint)num2 & 0xFFu);
		array[num++] = (byte)((num2 & 0xFF00) >> 8);
		short num3 = short_1;
		if (IsDirectory)
		{
			num3 = (short)(num3 & -9);
		}
		array[num++] = (byte)((uint)num3 & 0xFFu);
		array[num++] = (byte)((num3 & 0xFF00) >> 8);
		array[num++] = (byte)((uint)CompressionMethod & 0xFFu);
		array[num++] = (byte)((CompressionMethod & 0xFF00) >> 8);
		array[num++] = (byte)((uint)int_0 & 0xFFu);
		array[num++] = (byte)((int_0 & 0xFF00) >> 8);
		array[num++] = (byte)((int_0 & 0xFF0000) >> 16);
		array[num++] = (byte)((int_0 & 0xFF000000L) >> 24);
		array[num++] = (byte)((uint)int_1 & 0xFFu);
		array[num++] = (byte)((int_1 & 0xFF00) >> 8);
		array[num++] = (byte)((int_1 & 0xFF0000) >> 16);
		array[num++] = (byte)((int_1 & 0xFF000000L) >> 24);
		int num4 = 0;
		if (enum906_1 == Enum906.const_2)
		{
			for (num4 = 0; num4 < 8; num4++)
			{
				array[num++] = byte.MaxValue;
			}
		}
		else
		{
			array[num++] = (byte)((ulong)long_0 & 0xFFuL);
			array[num++] = (byte)((long_0 & 0xFF00L) >> 8);
			array[num++] = (byte)((long_0 & 0xFF0000L) >> 16);
			array[num++] = (byte)((long_0 & 0xFF000000L) >> 24);
			array[num++] = (byte)((ulong)long_2 & 0xFFuL);
			array[num++] = (byte)((long_2 & 0xFF00L) >> 8);
			array[num++] = (byte)((long_2 & 0xFF0000L) >> 16);
			array[num++] = (byte)((long_2 & 0xFF000000L) >> 24);
		}
		byte[] array2 = method_48();
		short num5 = (short)array2.Length;
		array[num++] = (byte)((uint)num5 & 0xFFu);
		array[num++] = (byte)((num5 & 0xFF00) >> 8);
		bool_14 = enum906_1 == Enum906.const_2;
		byte_1 = method_46(forCentralDirectory: true);
		short num6 = (short)((byte_1 != null) ? byte_1.Length : 0);
		array[num++] = (byte)((uint)num6 & 0xFFu);
		array[num++] = (byte)((num6 & 0xFF00) >> 8);
		int num7 = ((byte_0 != null) ? byte_0.Length : 0);
		if (num7 + num > array.Length)
		{
			num7 = array.Length - num;
		}
		array[num++] = (byte)((uint)num7 & 0xFFu);
		array[num++] = (byte)((num7 & 0xFF00) >> 8);
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = (byte)(bool_15 ? 1u : 0u);
		array[num++] = 0;
		array[num++] = (byte)((uint)int_4 & 0xFFu);
		array[num++] = (byte)((int_4 & 0xFF00) >> 8);
		array[num++] = (byte)((int_4 & 0xFF0000) >> 16);
		array[num++] = (byte)((int_4 & 0xFF000000L) >> 24);
		if (enum906_1 == Enum906.const_2)
		{
			for (num4 = 0; num4 < 4; num4++)
			{
				array[num++] = byte.MaxValue;
			}
		}
		else
		{
			array[num++] = (byte)((ulong)long_4 & 0xFFuL);
			array[num++] = (byte)((long_4 & 0xFF00L) >> 8);
			array[num++] = (byte)((long_4 & 0xFF0000L) >> 16);
			array[num++] = (byte)((long_4 & 0xFF000000L) >> 24);
		}
		for (num4 = 0; num4 < num5; num4++)
		{
			array[num + num4] = array2[num4];
		}
		num += num4;
		if (byte_1 != null)
		{
			for (num4 = 0; num4 < num6; num4++)
			{
				array[num + num4] = byte_1[num4];
			}
			num += num4;
		}
		if (num7 != 0)
		{
			for (num4 = 0; num4 < num7 && num + num4 < array.Length; num4++)
			{
				array[num + num4] = byte_0[num4];
			}
			num += num4;
		}
		s.Write(array, 0, num);
	}

	private byte[] method_46(bool forCentralDirectory)
	{
		ArrayList arrayList = new ArrayList();
		if (class6752_0.enum908_0 != 0)
		{
			int num = 4 + (forCentralDirectory ? 28 : 16);
			byte[] array = new byte[num];
			int num2 = 0;
			if (bool_14)
			{
				array[num2++] = 1;
				array[num2++] = 0;
			}
			else
			{
				array[num2++] = 153;
				array[num2++] = 153;
			}
			array[num2++] = (byte)(num - 4);
			array[num2++] = 0;
			Array.Copy(BitConverter.GetBytes(long_2), 0, array, num2, 8);
			num2 += 8;
			Array.Copy(BitConverter.GetBytes(long_0), 0, array, num2, 8);
			if (forCentralDirectory)
			{
				num2 += 8;
				Array.Copy(BitConverter.GetBytes(long_4), 0, array, num2, 8);
				num2 += 8;
				Array.Copy(BitConverter.GetBytes(0), 0, array, num2, 4);
			}
			arrayList.Add(array);
		}
		if (bool_0 && bool_1)
		{
			byte[] array = new byte[36]
			{
				10, 0, 32, 0, 0, 0, 0, 0, 1, 0,
				24, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0
			};
			long value = dateTime_1.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, 12, 8);
			value = dateTime_2.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, 20, 8);
			value = dateTime_3.ToFileTime();
			Array.Copy(BitConverter.GetBytes(value), 0, array, 28, 8);
			arrayList.Add(array);
		}
		if (bool_0 && bool_2)
		{
			int num3 = 9;
			if (!forCentralDirectory)
			{
				num3 += 8;
			}
			byte[] array = new byte[num3];
			int num4 = 0;
			byte[] array2 = array;
			num4 = 1;
			array2[0] = 85;
			byte[] array3 = array;
			num4 = 2;
			array3[1] = 84;
			byte[] array4 = array;
			num4 = 3;
			array4[2] = (byte)(num3 - 4);
			byte[] array5 = array;
			num4 = 4;
			array5[3] = 0;
			byte[] array6 = array;
			num4 = 5;
			array6[4] = 7;
			int value2 = (int)(dateTime_1 - dateTime_4).TotalSeconds;
			Array.Copy(BitConverter.GetBytes(value2), 0, array, 5, 4);
			num4 = 9;
			if (!forCentralDirectory)
			{
				value2 = (int)(dateTime_2 - dateTime_4).TotalSeconds;
				Array.Copy(BitConverter.GetBytes(value2), 0, array, num4, 4);
				num4 += 4;
				value2 = (int)(dateTime_3 - dateTime_4).TotalSeconds;
				Array.Copy(BitConverter.GetBytes(value2), 0, array, num4, 4);
				num4 += 4;
			}
			arrayList.Add(array);
		}
		byte[] array7 = null;
		if (arrayList.Count > 0)
		{
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < arrayList.Count; i++)
			{
				num5 += ((byte[])arrayList[i]).Length;
			}
			array7 = new byte[num5];
			for (int i = 0; i < arrayList.Count; i++)
			{
				Array.Copy((byte[])arrayList[i], 0, array7, num6, ((byte[])arrayList[i]).Length);
				num6 += ((byte[])arrayList[i]).Length;
			}
		}
		return array7;
	}

	private Encoding method_47()
	{
		byte_0 = encoding_0.GetBytes(string_2);
		string @string = encoding_0.GetString(byte_0, 0, byte_0.Length);
		if (@string == string_2)
		{
			return encoding_0;
		}
		byte_0 = encoding_1.GetBytes(string_2);
		return encoding_1;
	}

	private byte[] method_48()
	{
		string text = FileName.Replace("\\", "/");
		string text2;
		if (bool_3 && FileName.Length >= 3 && FileName[1] == ':' && text[2] == '/')
		{
			text2 = text.Substring(3);
		}
		else if (FileName.Length < 4 || text[0] != '/' || text[1] != '/')
		{
			text2 = ((FileName.Length < 3 || text[0] != '.' || text[1] != '/') ? text : text.Substring(2));
		}
		else
		{
			int num = text.IndexOf('/', 2);
			if (num == -1)
			{
				throw new ArgumentException("The path for that entry appears to be badly formatted");
			}
			text2 = text.Substring(num + 1);
		}
		byte[] bytes = encoding_0.GetBytes(text2);
		string @string = encoding_0.GetString(bytes, 0, bytes.Length);
		byte_0 = null;
		if (@string == text2)
		{
			if (string_2 != null && string_2.Length != 0)
			{
				Encoding encoding = method_47();
				if (encoding.CodePage == 437)
				{
					encoding_2 = encoding_0;
					return bytes;
				}
				encoding_2 = encoding;
				return encoding.GetBytes(text2);
			}
			encoding_2 = encoding_0;
			return bytes;
		}
		bytes = encoding_1.GetBytes(text2);
		if (string_2 != null && string_2.Length != 0)
		{
			byte_0 = encoding_1.GetBytes(string_2);
		}
		encoding_2 = encoding_1;
		return bytes;
	}

	private bool method_49()
	{
		if (long_2 < 16L)
		{
			return false;
		}
		if (short_2 == 0)
		{
			return false;
		}
		if (class6752_0.CompressionLevel == Enum914.const_0)
		{
			return false;
		}
		if (long_0 < long_2)
		{
			return false;
		}
		if (ForceNoCompression)
		{
			return false;
		}
		if (enum909_0 == Enum909.const_2 && !stream_1.CanSeek)
		{
			return false;
		}
		if (class6750_0 != null && CompressedSize - 12L <= UncompressedSize)
		{
			return false;
		}
		if (WillReadTwiceOnInflation != null)
		{
			return WillReadTwiceOnInflation(long_2, long_0, FileName);
		}
		return true;
	}

	private static bool smethod_11(string filename)
	{
		return !regex_0.IsMatch(filename);
	}

	private bool method_50()
	{
		if (string_0 != null)
		{
			return smethod_11(string_0);
		}
		if (string_1 != null)
		{
			return smethod_11(string_1);
		}
		return true;
	}

	private void method_51(int cycle)
	{
		if (cycle > 1)
		{
			short_2 = 0;
		}
		else if (IsDirectory)
		{
			short_2 = 0;
		}
		else
		{
			if (long_3 != -1L)
			{
				return;
			}
			if (enum909_0 == Enum909.const_2)
			{
				if (stream_1 != null && stream_1.CanSeek)
				{
					long length = stream_1.Length;
					if (length == 0L)
					{
						short_2 = 0;
						return;
					}
				}
			}
			else
			{
				FileInfo fileInfo = new FileInfo(LocalFileName);
				long length2 = fileInfo.Length;
				if (length2 == 0L)
				{
					short_2 = 0;
					return;
				}
			}
			if (!bool_4 && class6752_0.CompressionLevel != 0)
			{
				if (WantCompression != null)
				{
					short_2 = (short)(WantCompression(LocalFileName, string_1) ? 8 : 0);
				}
				else
				{
					short_2 = (short)(method_50() ? 8 : 0);
				}
			}
			else
			{
				short_2 = 0;
			}
		}
	}

	private void method_52(Stream s, int cycle)
	{
		int num = 0;
		long_4 = (s as Stream10)?.BytesWritten ?? s.Position;
		byte[] array = new byte[512];
		int num2 = 0;
		num2 = 1;
		array[0] = 80;
		num2 = 2;
		array[1] = 75;
		num2 = 3;
		array[2] = 3;
		num2 = 4;
		array[3] = 4;
		if (class6752_0.enum908_0 == Enum908.const_0 && (uint)long_4 >= uint.MaxValue)
		{
			throw new Exception61("Offset within the zip archive exceeds 0xFFFFFFFF. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
		}
		bool_14 = class6752_0.enum908_0 == Enum908.const_3 || (class6752_0.enum908_0 == Enum908.const_2 && !s.CanSeek);
		short num3 = (short)(bool_14 ? 45 : 20);
		array[num2++] = (byte)((uint)num3 & 0xFFu);
		array[num2++] = (byte)((num3 & 0xFF00) >> 8);
		byte[] array2 = method_48();
		short num4 = (short)array2.Length;
		short_1 = (short)(UsesEncryption ? 1 : 0);
		if (ActualEncoding.CodePage == Encoding.UTF8.CodePage)
		{
			short_1 = (short)((ushort)short_1 | 0x800);
		}
		if (!s.CanSeek)
		{
			short_1 = (short)((ushort)short_1 | 8);
		}
		short num5 = short_1;
		if (IsDirectory)
		{
			num5 = (short)(num5 & -9);
		}
		array[num2++] = (byte)((uint)num5 & 0xFFu);
		array[num2++] = (byte)((num5 & 0xFF00) >> 8);
		if (long_3 == -1L)
		{
			long_2 = 0L;
			long_0 = 0L;
			int_1 = 0;
			bool_6 = false;
		}
		method_51(cycle);
		array[num2++] = (byte)((uint)CompressionMethod & 0xFFu);
		array[num2++] = (byte)((CompressionMethod & 0xFF00) >> 8);
		int_0 = Class6748.smethod_14(LastModified);
		array[num2++] = (byte)((uint)int_0 & 0xFFu);
		array[num2++] = (byte)((int_0 & 0xFF00) >> 8);
		array[num2++] = (byte)((int_0 & 0xFF0000) >> 16);
		array[num2++] = (byte)((int_0 & 0xFF000000L) >> 24);
		array[num2++] = (byte)((uint)int_1 & 0xFFu);
		array[num2++] = (byte)((int_1 & 0xFF00) >> 8);
		array[num2++] = (byte)((int_1 & 0xFF0000) >> 16);
		array[num2++] = (byte)((int_1 & 0xFF000000L) >> 24);
		if (bool_14)
		{
			for (num = 0; num < 8; num++)
			{
				array[num2++] = byte.MaxValue;
			}
		}
		else
		{
			array[num2++] = (byte)((ulong)long_0 & 0xFFuL);
			array[num2++] = (byte)((long_0 & 0xFF00L) >> 8);
			array[num2++] = (byte)((long_0 & 0xFF0000L) >> 16);
			array[num2++] = (byte)((long_0 & 0xFF000000L) >> 24);
			array[num2++] = (byte)((ulong)long_2 & 0xFFuL);
			array[num2++] = (byte)((long_2 & 0xFF00L) >> 8);
			array[num2++] = (byte)((long_2 & 0xFF0000L) >> 16);
			array[num2++] = (byte)((long_2 & 0xFF000000L) >> 24);
		}
		array[num2++] = (byte)((uint)num4 & 0xFFu);
		array[num2++] = (byte)((num4 & 0xFF00) >> 8);
		byte_1 = method_46(forCentralDirectory: false);
		short num6 = (short)((byte_1 != null) ? byte_1.Length : 0);
		array[num2++] = (byte)((uint)num6 & 0xFFu);
		array[num2++] = (byte)((num6 & 0xFF00) >> 8);
		for (num = 0; num < array2.Length && num2 + num < array.Length; num++)
		{
			array[num2 + num] = array2[num];
		}
		num2 += num;
		if (byte_1 != null)
		{
			for (num = 0; num < byte_1.Length; num++)
			{
				array[num2 + num] = byte_1[num];
			}
			num2 += num;
		}
		int_2 = num2;
		s.Write(array, 0, num2);
		byte_2 = new byte[num2];
		for (num = 0; num < num2; num++)
		{
			byte_2[num] = array[num];
		}
	}

	private int method_53()
	{
		if (!bool_6)
		{
			Stream stream;
			if (enum909_0 == Enum909.const_2)
			{
				method_54();
				stream = stream_1;
			}
			else
			{
				stream = File.Open(LocalFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			}
			Class6740 @class = new Class6740();
			int_1 = @class.method_0(stream);
			if (stream_1 == null)
			{
				stream.Close();
			}
			bool_6 = true;
		}
		return int_1;
	}

	private void method_54()
	{
		if (stream_1 == null)
		{
			throw new Exception61($"The input stream is null for entry '{FileName}'.");
		}
		if (struct224_0.HasValue)
		{
			stream_1.Position = struct224_0.Value;
		}
		else if (stream_1.CanSeek)
		{
			struct224_0 = new Struct224(stream_1.Position);
		}
		else if (Encryption == Enum903.const_1)
		{
			throw new Exception61("It is not possible to use PKZIP encryption on a non-seekable stream");
		}
	}

	internal void method_55(Class6751 source)
	{
		long_3 = source.long_3;
		CompressionMethod = source.CompressionMethod;
		long_1 = source.long_1;
		long_2 = source.long_2;
		short_1 = source.short_1;
		enum909_0 = source.enum909_0;
		dateTime_0 = source.dateTime_0;
		dateTime_1 = source.dateTime_1;
		dateTime_2 = source.dateTime_2;
		dateTime_3 = source.dateTime_3;
		bool_0 = source.bool_0;
		bool_2 = source.bool_2;
		bool_1 = source.bool_1;
	}

	private void method_56(Stream s)
	{
		Stream stream = null;
		try
		{
			long_3 = s.Position;
		}
		catch
		{
		}
		Stream7 stream2;
		Stream10 stream3;
		try
		{
			long totalBytesToXfer = 0L;
			if (enum909_0 == Enum909.const_2)
			{
				method_54();
				stream = stream_1;
				try
				{
					totalBytesToXfer = stream_1.Length;
				}
				catch (NotSupportedException)
				{
				}
			}
			else
			{
				FileInfo fileInfo = new FileInfo(LocalFileName);
				totalBytesToXfer = fileInfo.Length;
				stream = File.Open(LocalFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			}
			stream2 = new Stream7(stream);
			stream3 = new Stream10(s);
			Stream stream4 = stream3;
			if (Encryption == Enum903.const_1)
			{
				stream4 = new Stream11(stream3, class6750_0, Enum913.const_0);
			}
			bool flag = false;
			Stream stream6;
			if (CompressionMethod == 8 && class6752_0.CompressionLevel != 0)
			{
				Stream8 stream5 = new Stream8(stream4, Enum916.const_0, class6752_0.CompressionLevel, leaveOpen: true);
				if (class6752_0.CodecBufferSize > 0)
				{
					stream5.BufferSize = class6752_0.CodecBufferSize;
				}
				stream5.Strategy = class6752_0.Strategy;
				flag = true;
				stream6 = stream5;
			}
			else
			{
				stream6 = stream4;
			}
			byte[] array = new byte[BufferSize];
			int count;
			while ((count = Class6748.smethod_18(stream2, array, 0, array.Length, FileName)) != 0)
			{
				stream6.Write(array, 0, count);
				method_26(stream2.TotalBytesSlurped, totalBytesToXfer);
				if (bool_13)
				{
					break;
				}
			}
			if (flag)
			{
				stream6.Close();
			}
			stream4.Flush();
			stream4.Close();
			int_3 = 0;
		}
		finally
		{
			if (enum909_0 != Enum909.const_2)
			{
				stream?.Close();
			}
		}
		if (bool_13)
		{
			return;
		}
		long_2 = stream2.TotalBytesSlurped;
		long_1 = stream3.BytesWritten;
		long_0 = long_1;
		int_1 = stream2.Crc;
		if (string_3 != null && Encryption == Enum903.const_1)
		{
			long_0 += 12L;
		}
		int num = 8;
		byte[] array2 = byte_2;
		num = 9;
		array2[8] = (byte)((uint)CompressionMethod & 0xFFu);
		byte[] array3 = byte_2;
		num = 10;
		array3[9] = (byte)((CompressionMethod & 0xFF00) >> 8);
		num = 14;
		byte[] array4 = byte_2;
		num = 15;
		array4[14] = (byte)((uint)int_1 & 0xFFu);
		byte[] array5 = byte_2;
		num = 16;
		array5[15] = (byte)((int_1 & 0xFF00) >> 8);
		byte[] array6 = byte_2;
		num = 17;
		array6[16] = (byte)((int_1 & 0xFF0000) >> 16);
		byte[] array7 = byte_2;
		num = 18;
		array7[17] = (byte)((int_1 & 0xFF000000L) >> 24);
		enum906_0 = ((long_0 >= 4294967295L || long_2 >= 4294967295L || long_4 >= 4294967295L) ? Enum906.const_2 : Enum906.const_1);
		if (class6752_0.enum908_0 == Enum908.const_0 && enum906_0 == Enum906.const_2)
		{
			throw new Exception61("Compressed or Uncompressed size, or offset exceeds the maximum value. Consider setting the UseZip64WhenSaving property on the ZipFile instance.");
		}
		enum906_1 = ((class6752_0.enum908_0 == Enum908.const_3 || enum906_0 == Enum906.const_2) ? Enum906.const_2 : Enum906.const_1);
		short num2 = (short)(byte_2[26] + byte_2[27] * 256);
		short num3 = (short)(byte_2[28] + byte_2[29] * 256);
		if (enum906_1 == Enum906.const_2)
		{
			byte_2[4] = 45;
			byte_2[5] = 0;
			for (int i = 0; i < 8; i++)
			{
				byte_2[num++] = byte.MaxValue;
			}
			num = 30 + num2;
			byte_2[num++] = 1;
			byte_2[num++] = 0;
			num += 2;
			Array.Copy(BitConverter.GetBytes(long_2), 0, byte_2, num, 8);
			num += 8;
			Array.Copy(BitConverter.GetBytes(long_0), 0, byte_2, num, 8);
		}
		else
		{
			byte_2[4] = 20;
			byte_2[5] = 0;
			num = 18;
			byte[] array8 = byte_2;
			num = 19;
			array8[18] = (byte)((ulong)long_0 & 0xFFuL);
			byte[] array9 = byte_2;
			num = 20;
			array9[19] = (byte)((long_0 & 0xFF00L) >> 8);
			byte[] array10 = byte_2;
			num = 21;
			array10[20] = (byte)((long_0 & 0xFF0000L) >> 16);
			byte[] array11 = byte_2;
			num = 22;
			array11[21] = (byte)((long_0 & 0xFF000000L) >> 24);
			byte[] array12 = byte_2;
			num = 23;
			array12[22] = (byte)((ulong)long_2 & 0xFFuL);
			byte[] array13 = byte_2;
			num = 24;
			array13[23] = (byte)((long_2 & 0xFF00L) >> 8);
			byte[] array14 = byte_2;
			num = 25;
			array14[24] = (byte)((long_2 & 0xFF0000L) >> 16);
			byte[] array15 = byte_2;
			num = 26;
			array15[25] = (byte)((long_2 & 0xFF000000L) >> 24);
			if (num3 != 0)
			{
				num = 30 + num2;
				short num4 = (short)(byte_2[num + 2] + byte_2[num + 3] * 256);
				if (num4 == 16)
				{
					byte_2[num++] = 153;
					byte_2[num++] = 153;
				}
			}
		}
		if ((short_1 & 8) != 8)
		{
			s.Seek(long_4, SeekOrigin.Begin);
			s.Write(byte_2, 0, byte_2.Length);
			if (s is Stream10 stream7)
			{
				stream7.method_0(byte_2.Length);
			}
			s.Seek(long_0, SeekOrigin.Current);
			return;
		}
		byte[] array16 = new byte[16 + ((enum906_1 == Enum906.const_2) ? 8 : 0)];
		num = 0;
		Array.Copy(BitConverter.GetBytes(134695760), 0, array16, 0, 4);
		num = 4;
		Array.Copy(BitConverter.GetBytes(int_1), 0, array16, 4, 4);
		num = 8;
		if (enum906_1 == Enum906.const_2)
		{
			Array.Copy(BitConverter.GetBytes(long_0), 0, array16, num, 8);
			num += 8;
			Array.Copy(BitConverter.GetBytes(long_2), 0, array16, num, 8);
			num += 8;
		}
		else
		{
			array16[num++] = (byte)((ulong)long_0 & 0xFFuL);
			array16[num++] = (byte)((long_0 & 0xFF00L) >> 8);
			array16[num++] = (byte)((long_0 & 0xFF0000L) >> 16);
			array16[num++] = (byte)((long_0 & 0xFF000000L) >> 24);
			array16[num++] = (byte)((ulong)long_2 & 0xFFuL);
			array16[num++] = (byte)((long_2 & 0xFF00L) >> 8);
			array16[num++] = (byte)((long_2 & 0xFF0000L) >> 16);
			array16[num++] = (byte)((long_2 & 0xFF000000L) >> 24);
		}
		s.Write(array16, 0, array16.Length);
		int_3 += array16.Length;
	}

	private void method_57(Exception e)
	{
		bool_13 = class6752_0.method_56(this, e);
	}

	internal void Write(Stream s)
	{
		bool flag = false;
		Stream10 stream = s as Stream10;
		while (enum909_0 != Enum909.const_3 || bool_8)
		{
			try
			{
				if (IsDirectory)
				{
					method_52(s, 1);
					enum906_0 = ((long_4 >= 4294967295L) ? Enum906.const_2 : Enum906.const_1);
					enum906_1 = ((class6752_0.enum908_0 == Enum908.const_3 || enum906_0 == Enum906.const_2) ? Enum906.const_2 : Enum906.const_1);
					return;
				}
				bool flag2 = true;
				int num = 0;
				do
				{
					num++;
					method_52(s, num);
					method_58(s);
					flag2 = num <= 1 && s.CanSeek && method_49();
					if (flag2)
					{
						s.Seek(long_4, SeekOrigin.Begin);
						s.SetLength(s.Position);
						stream?.method_0(long_5);
					}
				}
				while (flag2);
				bool_10 = false;
				flag = true;
			}
			catch (Exception ex)
			{
				Enum911 zipErrorAction = ZipErrorAction;
				int num2 = 0;
				while (true)
				{
					if (ZipErrorAction != 0)
					{
						if (ZipErrorAction != Enum911.const_1 && ZipErrorAction != Enum911.const_2)
						{
							if (num2 <= 0)
							{
								if (ZipErrorAction == Enum911.const_3)
								{
									method_57(ex);
									if (bool_13)
									{
										flag = true;
										break;
									}
								}
								num2++;
								continue;
							}
							throw;
						}
						if (!s.CanSeek)
						{
							throw;
						}
						long position = s.Position;
						s.Seek(long_4, SeekOrigin.Begin);
						long position2 = s.Position;
						s.SetLength(s.Position);
						stream?.method_0(position - position2);
						if (ZipErrorAction == Enum911.const_1)
						{
							if (class6752_0.StatusMessageTextWriter != null)
							{
								class6752_0.StatusMessageTextWriter.WriteLine("Skipping file {0} (exception: {1})", LocalFileName, ex.ToString());
							}
							bool_10 = true;
							flag = true;
						}
						else
						{
							ZipErrorAction = zipErrorAction;
						}
						break;
					}
					throw;
				}
			}
			if (flag)
			{
				return;
			}
		}
		method_60(s);
	}

	private void method_58(Stream outstream)
	{
		method_59(outstream);
		method_56(outstream);
		long_5 = int_2 + long_1 + int_3;
	}

	private void method_59(Stream outstream)
	{
		if (string_3 != null && Encryption == Enum903.const_1)
		{
			class6750_0 = Class6750.smethod_0(string_3);
			Random random = new Random();
			byte[] array = new byte[12];
			random.NextBytes(array);
			if ((short_1 & 8) == 8)
			{
				int_0 = Class6748.smethod_14(LastModified);
				array[11] = (byte)((uint)(int_0 >> 8) & 0xFFu);
			}
			else
			{
				method_53();
				array[11] = (byte)((uint)(int_1 >> 24) & 0xFFu);
			}
			byte[] array2 = class6750_0.method_1(array, array.Length);
			outstream.Write(array2, 0, array2.Length);
			int_2 += array2.Length;
		}
	}

	private void method_60(Stream outstream)
	{
		if (LengthOfHeader == 0)
		{
			throw new Exception66("Bad header length.");
		}
		Stream7 input = new Stream7(ArchiveStream);
		if (bool_7 || (bool_11 && class6752_0.UseZip64WhenSaving == Enum908.const_0) || (!bool_11 && class6752_0.UseZip64WhenSaving == Enum908.const_3))
		{
			method_61(outstream, input);
		}
		else
		{
			method_62(outstream, input);
		}
		enum906_0 = ((long_0 >= 4294967295L || long_2 >= 4294967295L || long_4 >= 4294967295L) ? Enum906.const_2 : Enum906.const_1);
		enum906_1 = ((class6752_0.enum908_0 == Enum908.const_3 || enum906_0 == Enum906.const_2) ? Enum906.const_2 : Enum906.const_1);
	}

	private void method_61(Stream outstream, Stream7 input1)
	{
		byte[] array = new byte[BufferSize];
		Stream archiveStream = ArchiveStream;
		long num = long_4;
		int lengthOfHeader = LengthOfHeader;
		method_52(outstream, 0);
		if (!FileName.EndsWith("/"))
		{
			long num2 = num + lengthOfHeader;
			num2 -= LengthOfCryptoHeaderBytes;
			int_2 += LengthOfCryptoHeaderBytes;
			class6752_0.method_68(num2);
			long num3 = long_0;
			while (num3 > 0L)
			{
				int count = (int)((num3 > array.Length) ? array.Length : num3);
				int num4 = input1.Read(array, 0, count);
				outstream.Write(array, 0, num4);
				num3 -= num4;
				method_26(input1.TotalBytesSlurped, long_0);
				if (bool_13)
				{
					break;
				}
			}
			if ((short_1 & 8) == 8)
			{
				int num5 = 16;
				if (bool_11)
				{
					num5 += 8;
				}
				byte[] buffer = new byte[num5];
				archiveStream.Read(buffer, 0, num5);
				if (bool_11 && class6752_0.UseZip64WhenSaving == Enum908.const_0)
				{
					outstream.Write(buffer, 0, 8);
					if (long_0 > 4294967295L)
					{
						throw new InvalidOperationException("ZIP64 is required");
					}
					outstream.Write(buffer, 8, 4);
					if (long_2 > 4294967295L)
					{
						throw new InvalidOperationException("ZIP64 is required");
					}
					outstream.Write(buffer, 16, 4);
					int_3 -= 8;
				}
				else if (!bool_11 && class6752_0.UseZip64WhenSaving == Enum908.const_3)
				{
					byte[] buffer2 = new byte[4];
					outstream.Write(buffer, 0, 8);
					outstream.Write(buffer, 8, 4);
					outstream.Write(buffer2, 0, 4);
					outstream.Write(buffer, 12, 4);
					outstream.Write(buffer2, 0, 4);
					int_3 += 8;
				}
				else
				{
					outstream.Write(buffer, 0, num5);
				}
			}
		}
		long_5 = int_2 + long_1 + int_3;
	}

	private void method_62(Stream outstream, Stream7 input1)
	{
		byte[] array = new byte[BufferSize];
		class6752_0.method_68(long_4);
		if (long_5 == 0L)
		{
			long_5 = int_2 + long_1 + int_3;
		}
		long_4 = (outstream as Stream10)?.BytesWritten ?? outstream.Position;
		long num = long_5;
		while (num > 0L)
		{
			int count = (int)((num > array.Length) ? array.Length : num);
			int num2 = input1.Read(array, 0, count);
			outstream.Write(array, 0, num2);
			num -= num2;
			method_26(input1.TotalBytesSlurped, long_5);
			if (bool_13)
			{
				break;
			}
		}
	}
}

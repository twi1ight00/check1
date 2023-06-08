using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[Serializable]
[XmlSchemaProvider("GetXsdType")]
public struct OracleString : IComparable, INullable, IXmlSerializable
{
	public static readonly OracleString Null;

	private string m_value;

	private bool m_bNotNull;

	private bool m_bCaseIgnored;

	public bool IsNull => !m_bNotNull;

	public bool IsCaseIgnored
	{
		get
		{
			return m_bCaseIgnored;
		}
		set
		{
			m_bCaseIgnored = value;
		}
	}

	public int Length
	{
		get
		{
			if (m_bNotNull)
			{
				return m_value.Length;
			}
			throw new OracleNullValueException();
		}
	}

	public char this[int index]
	{
		get
		{
			if (m_bNotNull)
			{
				return m_value.ToCharArray()[index];
			}
			throw new OracleNullValueException();
		}
	}

	public string Value
	{
		get
		{
			if (m_bNotNull)
			{
				return m_value;
			}
			throw new OracleNullValueException();
		}
	}

	static OracleString()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		return null;
	}

	void IXmlSerializable.ReadXml(XmlReader reader)
	{
		string attribute = reader.GetAttribute("null", "http://www.w3.org/2001/XMLSchema-instance");
		if (attribute == null || !XmlConvert.ToBoolean(attribute))
		{
			m_value = reader.ReadElementString();
			m_bNotNull = true;
		}
		else
		{
			m_value = null;
			m_bNotNull = false;
		}
		m_bCaseIgnored = true;
	}

	void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		if (m_bNotNull)
		{
			writer.WriteString(m_value);
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleString(string data)
		: this(data, isCaseIgnored: true)
	{
	}

	public OracleString(string data, bool isCaseIgnored)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::OracleString(1)\n");
		}
		if (data != null)
		{
			m_bNotNull = true;
			m_value = data;
		}
		else
		{
			m_bNotNull = false;
			m_value = null;
		}
		m_bCaseIgnored = isCaseIgnored;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleString::OracleString(1)\n");
		}
	}

	public OracleString(byte[] bytes, bool isUnicode)
		: this(bytes, isUnicode, isCaseIgnored: true)
	{
	}

	public OracleString(byte[] bytes, bool isUnicode, bool isCaseIgnored)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::OracleString(2)\n");
		}
		m_value = null;
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = 0;
		int srcLen = bytes.Length;
		if (!isUnicode)
		{
			GCHandle gCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
			try
			{
				num = OpsStr.BytesToUnicode(gCHandle.AddrOfPinnedObject(), srcLen, 0, -1, out m_value);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
				if (num != 0)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		else
		{
			Decoder decoder = Encoding.Unicode.GetDecoder();
			int charCount = decoder.GetCharCount(bytes, 0, bytes.Length);
			char[] array = new char[charCount];
			charCount = decoder.GetChars(bytes, 0, bytes.Length, array, 0);
			m_value = new string(array);
		}
		m_bCaseIgnored = isCaseIgnored;
		m_bNotNull = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleString::OracleString(2)\n");
		}
	}

	public OracleString(byte[] bytes, int index, int count, bool isUnicode)
		: this(bytes, index, count, isUnicode, isCaseIgnored: true)
	{
	}

	public OracleString(byte[] bytes, int index, int count, bool isUnicode, bool isCaseIgnored)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::OracleString(3)\n");
		}
		m_value = null;
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (index < 0 || index >= bytes.Length)
		{
			throw new IndexOutOfRangeException();
		}
		int num = 0;
		int srcLen = bytes.Length;
		if (!isUnicode)
		{
			GCHandle gCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
			try
			{
				num = OpsStr.BytesToUnicode(gCHandle.AddrOfPinnedObject(), srcLen, index, count, out m_value);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
				if (num != 0)
				{
					throw new OracleTypeException(num);
				}
			}
		}
		else
		{
			if (bytes.Length < count * 2)
			{
				count = bytes.Length / 2;
			}
			Decoder decoder = Encoding.Unicode.GetDecoder();
			int charCount = decoder.GetCharCount(bytes, index, count);
			char[] array = new char[charCount];
			charCount = decoder.GetChars(bytes, index, count, array, 0);
			if (count < charCount)
			{
				array[count] = '\0';
			}
			m_value = new string(array);
		}
		m_bCaseIgnored = isCaseIgnored;
		m_bNotNull = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleString::OracleString(3)\n");
		}
	}

	public static OracleString Concat(OracleString value1, OracleString value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::Concat()\n");
		}
		CompareNullEnum compareNullEnum = InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull);
		if (compareNullEnum != CompareNullEnum.BothNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::Concat()\n");
			}
			return Null;
		}
		if (value1.m_bCaseIgnored == value2.m_bCaseIgnored)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::Concat()\n");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder = stringBuilder.Append(value1.m_value);
			stringBuilder = stringBuilder.Append(value2.m_value);
			return new OracleString(stringBuilder.ToString(), value1.m_bCaseIgnored);
		}
		throw new OracleTypeException(ErrRes.TYP_COMPARE_COLLATION);
	}

	public static bool Equals(OracleString value1, OracleString value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::Equals()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::Equals()\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
			if (value1.m_bCaseIgnored == value2.m_bCaseIgnored)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleString::Equals()\n");
				}
				if (StringCompare(value1, value2, value1.m_bCaseIgnored) == 0)
				{
					return true;
				}
				return false;
			}
			throw new OracleTypeException(ErrRes.TYP_COMPARE_COLLATION);
		}
	}

	public static bool GreaterThan(OracleString value1, OracleString value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::GreaterThan()\n");
			}
			return true;
		default:
			if (value1.m_bCaseIgnored == value2.m_bCaseIgnored)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleString::GreaterThan()\n");
				}
				if (StringCompare(value1, value2, value1.m_bCaseIgnored) > 0)
				{
					return true;
				}
				return false;
			}
			throw new OracleTypeException(ErrRes.TYP_COMPARE_COLLATION);
		}
	}

	public static bool GreaterThanOrEqual(OracleString value1, OracleString value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleString::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleString::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleString::GreaterThanOrEqual()\n");
			}
			return true;
		default:
			if (value1.m_bCaseIgnored == value2.m_bCaseIgnored)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (ENTRY) OracleString::GreaterThanOrEqual()\n");
				}
				if (StringCompare(value1, value2, value1.m_bCaseIgnored) >= 0)
				{
					return true;
				}
				return false;
			}
			throw new OracleTypeException(ErrRes.TYP_COMPARE_COLLATION);
		}
	}

	public static bool LessThan(OracleString value1, OracleString value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::LessThan()\n");
			}
			return false;
		default:
			if (value1.m_bCaseIgnored == value2.m_bCaseIgnored)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleString::LessThan()\n");
				}
				if (StringCompare(value1, value2, value1.m_bCaseIgnored) < 0)
				{
					return true;
				}
				return false;
			}
			throw new OracleTypeException(ErrRes.TYP_COMPARE_COLLATION);
		}
	}

	public static bool LessThanOrEqual(OracleString value1, OracleString value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::LessThanOrEqual()\n");
			}
			return false;
		default:
			if (value1.m_bCaseIgnored == value2.m_bCaseIgnored)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleString::LessThanOrEqual()\n");
				}
				if (StringCompare(value1, value2, value1.m_bCaseIgnored) <= 0)
				{
					return true;
				}
				return false;
			}
			throw new OracleTypeException(ErrRes.TYP_COMPARE_COLLATION);
		}
	}

	public static bool NotEquals(OracleString value1, OracleString value2)
	{
		return !Equals(value1, value2);
	}

	public static bool operator ==(OracleString value1, OracleString value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleString value1, OracleString value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleString value1, OracleString value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleString value1, OracleString value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleString value1, OracleString value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleString value1, OracleString value2)
	{
		return NotEquals(value1, value2);
	}

	public static OracleString operator +(OracleString value1, OracleString value2)
	{
		return Concat(value1, value2);
	}

	public static explicit operator string(OracleString value1)
	{
		if (value1.m_bNotNull)
		{
			return value1.Value;
		}
		throw new OracleNullValueException();
	}

	public static implicit operator OracleString(string value1)
	{
		return new OracleString(value1);
	}

	public OracleString Clone()
	{
		return new OracleString(m_value, m_bCaseIgnored);
	}

	public int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleString))
		{
			throw new ArgumentException();
		}
		OracleString oraStr = (OracleString)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oraStr.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::CompareTo()\n");
			}
			return 1;
		default:
			if (m_bCaseIgnored == oraStr.m_bCaseIgnored)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleString::CompareTo()\n");
				}
				return StringCompare(this, oraStr, m_bCaseIgnored);
			}
			throw new OracleTypeException(ErrRes.TYP_COMPARE_COLLATION);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::Equals(1)\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::Equals(2)\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleString))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::Equals(2)\n");
			}
			return false;
		}
		OracleString value = (OracleString)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleString::Equals(2)\n");
		}
		return Equals(this, value);
	}

	public override int GetHashCode()
	{
		if (m_bNotNull)
		{
			return m_value.GetHashCode();
		}
		return 0;
	}

	public byte[] GetNonUnicodeBytes()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::GetNonUnicodeBytes()\n");
		}
		if (m_bNotNull)
		{
			int num = 0;
			IntPtr dst = IntPtr.Zero;
			uint dstLen = 0u;
			GCHandle gCHandle = GCHandle.Alloc(m_value, GCHandleType.Pinned);
			try
			{
				num = OpsStr.UnicodeToBytes(gCHandle.AddrOfPinnedObject(), m_value.Length, out dst, out dstLen);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (gCHandle.IsAllocated)
				{
					gCHandle.Free();
				}
				if (num != 0)
				{
					throw new OracleTypeException(num);
				}
			}
			byte[] array = new byte[dstLen];
			Marshal.Copy(dst, array, 0, (int)dstLen);
			Marshal.FreeCoTaskMem(dst);
			return array;
		}
		throw new OracleNullValueException();
	}

	public byte[] GetUnicodeBytes()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleString::GetUnicodeBytes()\n");
		}
		if (m_bNotNull)
		{
			Encoder encoder = Encoding.Unicode.GetEncoder();
			char[] array = m_value.ToCharArray();
			int byteCount = encoder.GetByteCount(array, 0, array.Length, flush: true);
			byte[] array2 = new byte[byteCount];
			byteCount = encoder.GetBytes(array, 0, array.Length, array2, 0, flush: true);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleString::GetUnicodeBytes()\n");
			}
			return array2;
		}
		throw new OracleNullValueException();
	}

	public override string ToString()
	{
		if (m_bNotNull)
		{
			return m_value;
		}
		return "null";
	}

	internal OracleString(IntPtr data, int count, bool isUnicode)
	{
		if (data != IntPtr.Zero)
		{
			if (isUnicode)
			{
				m_value = Marshal.PtrToStringUni(data, count);
			}
			else
			{
				int num = 0;
				string dst;
				try
				{
					num = OpsStr.BytesToUnicode(data, count, 0, count, out dst);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				if (num != 0)
				{
					throw new OracleTypeException(num);
				}
				m_value = dst;
			}
			m_bCaseIgnored = true;
			m_bNotNull = true;
		}
		else
		{
			m_bNotNull = false;
			m_bCaseIgnored = true;
			m_value = null;
		}
	}

	internal static int StringCompare(OracleString oraStr1, OracleString oraStr2, bool fCaseInsensitive)
	{
		int num = 0;
		num = (fCaseInsensitive ? 1 : 0);
		int res = 0;
		int num2 = 0;
		GCHandle gCHandle = GCHandle.Alloc(oraStr1.m_value, GCHandleType.Pinned);
		GCHandle gCHandle2 = GCHandle.Alloc(oraStr2.m_value, GCHandleType.Pinned);
		try
		{
			num2 = OpsStr.StrCompare(gCHandle.AddrOfPinnedObject(), oraStr1.m_value.Length, gCHandle2.AddrOfPinnedObject(), oraStr2.m_value.Length, num, out res);
			return res;
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
			if (gCHandle2.IsAllocated)
			{
				gCHandle2.Free();
			}
			if (num2 != 0)
			{
				throw new OracleTypeException(num2);
			}
		}
	}

	internal static string GetValue(IntPtr data, int count, bool isUnicode)
	{
		if (data != IntPtr.Zero)
		{
			if (isUnicode)
			{
				return Marshal.PtrToStringUni(data, count);
			}
			int num = 0;
			string dst;
			try
			{
				num = OpsStr.BytesToUnicode(data, count, 0, count, out dst);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			if (num != 0)
			{
				throw new OracleTypeException(num);
			}
			return dst;
		}
		return null;
	}
}

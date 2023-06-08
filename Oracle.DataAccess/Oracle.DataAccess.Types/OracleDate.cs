using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[Serializable]
[XmlSchemaProvider("GetXsdType")]
public struct OracleDate : IComparable, INullable, IXmlSerializable
{
	internal const byte MaxArrSize = 7;

	internal const byte YEAR = 0;

	internal const byte MONTH = 1;

	internal const byte DAY = 2;

	internal const byte HOUR = 3;

	internal const byte MINUTE = 4;

	internal const byte SECOND = 5;

	public static readonly OracleDate MaxValue;

	public static readonly OracleDate MinValue;

	public static readonly OracleDate Null;

	private OpoDatCtx m_opoDatCtx;

	private bool m_bNotNull;

	public unsafe byte[] BinData
	{
		get
		{
			if (m_bNotNull)
			{
				byte[] array = new byte[7];
				ToBytes(m_opoDatCtx.m_pValCtx, array);
				return array;
			}
			throw new OracleNullValueException();
		}
	}

	public bool IsNull => !m_bNotNull;

	public unsafe DateTime Value
	{
		get
		{
			if (m_bNotNull)
			{
				return DateTimeConv.GetDateTime(m_opoDatCtx.m_pValCtx, OracleDbType.Date, bCheck: false);
			}
			throw new OracleNullValueException();
		}
	}

	public int Year
	{
		get
		{
			if (m_bNotNull)
			{
				return GetDatData(0);
			}
			throw new OracleNullValueException();
		}
	}

	public int Month
	{
		get
		{
			if (m_bNotNull)
			{
				return GetDatData(1);
			}
			throw new OracleNullValueException();
		}
	}

	public int Day
	{
		get
		{
			if (m_bNotNull)
			{
				return GetDatData(2);
			}
			throw new OracleNullValueException();
		}
	}

	public int Hour
	{
		get
		{
			if (m_bNotNull)
			{
				return GetDatData(3);
			}
			throw new OracleNullValueException();
		}
	}

	public int Minute
	{
		get
		{
			if (m_bNotNull)
			{
				return GetDatData(4);
			}
			throw new OracleNullValueException();
		}
	}

	public int Second
	{
		get
		{
			if (m_bNotNull)
			{
				return GetDatData(5);
			}
			throw new OracleNullValueException();
		}
	}

	static OracleDate()
	{
		MaxValue = new OracleDate(9999, 12, 31, 23, 59, 59);
		MinValue = new OracleDate(-4712, 1, 1, 0, 0, 0);
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("DateTime", "http://www.w3.org/2001/XMLSchema");
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
			attribute = reader.ReadElementString();
			m_opoDatCtx = new OpoDatCtx(attribute);
			if (m_opoDatCtx.m_error != 0)
			{
				throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoDatCtx.m_error));
			}
			m_bNotNull = true;
		}
		else
		{
			m_bNotNull = false;
		}
	}

	unsafe void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		if (m_bNotNull)
		{
			int num = 0;
			string datStr;
			try
			{
				num = OpsDat.ToString(m_opoDatCtx.m_pValCtx, out datStr);
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
			writer.WriteString(datStr);
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleDate(int year, int month, int day, int hour, int minute, int second)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::OracleDate(1)\n");
		}
		if (!TimeStamp.IsValidDateTime(year, month, day, hour, minute, second, 0))
		{
			throw new ArgumentOutOfRangeException();
		}
		m_opoDatCtx = new OpoDatCtx(year, month, day, hour, minute, second);
		if (m_opoDatCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoDatCtx.m_error));
		}
		m_bNotNull = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDate::OracleDate(1)\n");
		}
	}

	public OracleDate(int year, int month, int day)
		: this(year, month, day, 0, 0, 0)
	{
	}

	public OracleDate(DateTime data)
		: this(data.Year, data.Month, data.Day, data.Hour, data.Minute, data.Second)
	{
	}

	public OracleDate(byte[] binData)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::OracleDate()\n");
		}
		if (binData == null)
		{
			throw new ArgumentNullException();
		}
		m_opoDatCtx = new OpoDatCtx(binData);
		if (m_opoDatCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoDatCtx.m_error));
		}
		m_bNotNull = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDate::OracleDate(2)\n");
		}
	}

	public OracleDate(string datStr)
	{
		if (datStr == null)
		{
			throw new ArgumentNullException();
		}
		m_opoDatCtx = new OpoDatCtx(datStr);
		if (m_opoDatCtx.m_error != 0)
		{
			throw new ArgumentException(OracleTypeException.GetTypeMsg(m_opoDatCtx.m_error));
		}
		m_bNotNull = true;
	}

	public static bool Equals(OracleDate value1, OracleDate value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::Equals(1)\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::Equals(1)\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::Equals(1)\n");
			}
			if (Compare(value1.m_opoDatCtx, value2.m_opoDatCtx) == 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThan(OracleDate value1, OracleDate value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThan()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThan()\n");
			}
			if (Compare(value1.m_opoDatCtx, value2.m_opoDatCtx) > 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool GreaterThanOrEqual(OracleDate value1, OracleDate value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThanOrEqual()\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GreaterThanOrEqual()\n");
			}
			if (Compare(value1.m_opoDatCtx, value2.m_opoDatCtx) >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThan(OracleDate value1, OracleDate value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThan()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThan()\n");
			}
			if (Compare(value1.m_opoDatCtx, value2.m_opoDatCtx) < 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool LessThanOrEqual(OracleDate value1, OracleDate value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThanOrEqual()\n");
			}
			return false;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::LessThanOrEqual()\n");
			}
			if (Compare(value1.m_opoDatCtx, value2.m_opoDatCtx) <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public static bool NotEquals(OracleDate value1, OracleDate value2)
	{
		return !Equals(value1, value2);
	}

	public unsafe static OracleDate GetSysDate()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::GetSysDate()\n");
		}
		int num = 0;
		OpoDatCtx ctx;
		try
		{
			num = OpsDat.AllocValCtxForSysDate(out var pValCtx);
			ctx = new OpoDatCtx(pValCtx);
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
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDate::GetSysDate()\n");
		}
		return new OracleDate(ctx);
	}

	public static OracleDate Parse(string datStr)
	{
		if (datStr == null)
		{
			throw new ArgumentNullException();
		}
		return new OracleDate(datStr);
	}

	public static bool operator ==(OracleDate value1, OracleDate value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleDate value1, OracleDate value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleDate value1, OracleDate value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleDate value1, OracleDate value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleDate value1, OracleDate value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleDate value1, OracleDate value2)
	{
		return NotEquals(value1, value2);
	}

	public unsafe static explicit operator OracleDate(OracleTimeStamp value1)
	{
		if (!value1.IsNull)
		{
			int num = 0;
			OpoDatValCtx* pDatCtx;
			try
			{
				num = OpsTSA.AllocValCtxForToDate(value1.GetValCtx(), out pDatCtx);
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
			OpoDatCtx ctx = new OpoDatCtx(pDatCtx);
			return new OracleDate(ctx);
		}
		return Null;
	}

	public static explicit operator OracleDate(string dateStr)
	{
		return new OracleDate(dateStr);
	}

	public unsafe static explicit operator DateTime(OracleDate value1)
	{
		if (value1.m_bNotNull)
		{
			return DateTimeConv.GetDateTime(value1.m_opoDatCtx.m_pValCtx, OracleDbType.Date, bCheck: false);
		}
		throw new OracleNullValueException();
	}

	public static explicit operator OracleDate(DateTime value1)
	{
		return new OracleDate(value1);
	}

	internal unsafe IntPtr AllocValCtxFromCtx()
	{
		IntPtr pNewCtx = IntPtr.Zero;
		int num = 0;
		num = OpsDat.AllocValCtxFromCtx(GetValCtx(), out pNewCtx);
		if (num != 0)
		{
			throw new OracleException(num, string.Empty, string.Empty, string.Empty);
		}
		return pNewCtx;
	}

	public int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleDate))
		{
			throw new ArgumentException();
		}
		OracleDate oracleDate = (OracleDate)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleDate.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::CompareTo()\n");
			}
			return 1;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::CompareTo()\n");
			}
			return Compare(m_opoDatCtx, oracleDate.m_opoDatCtx);
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::Equals()\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::Equals()\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleDate))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::Equals()\n");
			}
			return false;
		}
		OracleDate value = (OracleDate)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDate::Equals()\n");
		}
		return Equals(this, value);
	}

	public unsafe int GetDaysBetween(OracleDate value1)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::GetDaysBetween()\n");
		}
		if (m_bNotNull && value1.m_bNotNull)
		{
			int result = 0;
			int num = 0;
			try
			{
				num = OpsDat.GetDaysBetween(m_opoDatCtx.m_pValCtx, value1.m_opoDatCtx.m_pValCtx, &result);
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
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::GetDaysBetween()\n");
			}
			return result;
		}
		throw new OracleNullValueException();
	}

	public override int GetHashCode()
	{
		if (m_bNotNull)
		{
			return m_opoDatCtx.GetHashCode();
		}
		return 0;
	}

	public unsafe OracleTimeStamp ToOracleTimeStamp()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleDate::ToOracleTimeStamp()\n");
		}
		if (m_bNotNull)
		{
			int num = 0;
			OpoTSValCtx* pValCtx;
			try
			{
				num = OpsTS.AllocValCtxForFromDate(m_opoDatCtx.m_pValCtx, out pValCtx);
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
			OpoTSCtx ctx = new OpoTSCtx(pValCtx);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::ToOracleTimeStamp()\n");
			}
			return new OracleTimeStamp(ctx);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDate::ToOracleTimeStamp()\n");
		}
		return OracleTimeStamp.Null;
	}

	public unsafe override string ToString()
	{
		if (m_bNotNull)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleDate::ToString()\n");
			}
			int num = 0;
			string datStr;
			try
			{
				num = OpsDat.ToString(m_opoDatCtx.m_pValCtx, out datStr);
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
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleDate::ToString()\n");
			}
			return datStr;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleDate::ToString()\n");
		}
		return "null";
	}

	internal OracleDate(OpoDatCtx ctx)
	{
		m_opoDatCtx = ctx;
		m_bNotNull = true;
	}

	internal unsafe OracleDate(OpoDatValCtx* pCtx)
	{
		m_opoDatCtx = new OpoDatCtx(pCtx);
		m_bNotNull = true;
	}

	internal unsafe OracleDate(IntPtr pCtx)
	{
		m_opoDatCtx = new OpoDatCtx((OpoDatValCtx*)pCtx.ToPointer());
		m_bNotNull = true;
	}

	internal unsafe static bool ToBytes(OpoDatValCtx* pValCtx, byte[] bytes)
	{
		if (!TimeStamp.IsValidDateTime(pValCtx->m_year, pValCtx->m_month, pValCtx->m_day, pValCtx->m_hour, pValCtx->m_minute, pValCtx->m_second, 0))
		{
			throw new OracleTypeException(1866);
		}
		bytes[0] = (byte)(pValCtx->m_year / 100 + 100);
		bytes[1] = (byte)(pValCtx->m_year % 100 + 100);
		bytes[2] = pValCtx->m_month;
		bytes[3] = pValCtx->m_day;
		bytes[4] = (byte)(pValCtx->m_hour + 1);
		bytes[5] = (byte)(pValCtx->m_minute + 1);
		bytes[6] = (byte)(pValCtx->m_second + 1);
		return true;
	}

	internal unsafe static void ToBytes(OpoDatValCtx* pValCtx, byte* bytes)
	{
		*bytes = (byte)(pValCtx->m_year / 100 + 100);
		bytes[1] = (byte)(pValCtx->m_year % 100 + 100);
		bytes[2] = pValCtx->m_month;
		bytes[3] = pValCtx->m_day;
		bytes[4] = (byte)(pValCtx->m_hour + 1);
		bytes[5] = (byte)(pValCtx->m_minute + 1);
		bytes[6] = (byte)(pValCtx->m_second + 1);
	}

	internal unsafe static void ToBytes(OpoTSValCtx* pValCtx, byte* bytes)
	{
		*bytes = (byte)(pValCtx->m_year / 100 + 100);
		bytes[1] = (byte)(pValCtx->m_year % 100 + 100);
		bytes[2] = pValCtx->m_month;
		bytes[3] = pValCtx->m_day;
		bytes[4] = (byte)(pValCtx->m_hour + 1);
		bytes[5] = (byte)(pValCtx->m_minute + 1);
		bytes[6] = (byte)(pValCtx->m_second + 1);
	}

	internal unsafe OpoDatValCtx* GetValCtx()
	{
		return m_opoDatCtx.m_pValCtx;
	}

	internal unsafe int GetDatData(byte datComponent)
	{
		int result = 0;
		switch (datComponent)
		{
		case 0:
			result = m_opoDatCtx.m_pValCtx->m_year;
			break;
		case 1:
			result = m_opoDatCtx.m_pValCtx->m_month;
			break;
		case 2:
			result = m_opoDatCtx.m_pValCtx->m_day;
			break;
		case 3:
			result = m_opoDatCtx.m_pValCtx->m_hour;
			break;
		case 4:
			result = m_opoDatCtx.m_pValCtx->m_minute;
			break;
		case 5:
			result = m_opoDatCtx.m_pValCtx->m_second;
			break;
		}
		return result;
	}

	internal unsafe static int Compare(OpoDatCtx datCtx1, OpoDatCtx datCtx2)
	{
		int result = 0;
		int num = 0;
		try
		{
			num = OpsDat.Compare(datCtx1.m_pValCtx, datCtx2.m_pValCtx, ref result);
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
		return result;
	}
}

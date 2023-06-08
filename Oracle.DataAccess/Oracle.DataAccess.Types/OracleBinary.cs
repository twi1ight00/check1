using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[Serializable]
[XmlSchemaProvider("GetXsdType")]
public struct OracleBinary : IComparable, INullable, IXmlSerializable
{
	public static readonly OracleBinary Null;

	internal byte[] m_value;

	private bool m_bNotNull;

	public bool IsNull => !m_bNotNull;

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

	public byte this[int index]
	{
		get
		{
			if (m_bNotNull)
			{
				return m_value[index];
			}
			throw new OracleNullValueException();
		}
	}

	public byte[] Value
	{
		get
		{
			if (m_bNotNull)
			{
				byte[] array = new byte[m_value.Length];
				m_value.CopyTo(array, 0);
				return array;
			}
			throw new OracleNullValueException();
		}
	}

	static OracleBinary()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet)
	{
		return new XmlQualifiedName("base64Binary", "http://www.w3.org/2001/XMLSchema");
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
			m_value = Convert.FromBase64String(reader.ReadElementString());
			m_bNotNull = true;
		}
		else
		{
			m_value = null;
			m_bNotNull = false;
		}
	}

	void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		if (m_bNotNull)
		{
			writer.WriteString(Convert.ToBase64String(m_value));
		}
		else
		{
			writer.WriteAttributeString("xsi", "null", "http://www.w3.org/2001/XMLSchema-instance", "true");
		}
	}

	public OracleBinary(byte[] data)
	{
		if (data != null)
		{
			m_bNotNull = true;
			m_value = new byte[data.Length];
			data.CopyTo(m_value, 0);
		}
		else
		{
			m_bNotNull = false;
			m_value = null;
		}
	}

	internal OracleBinary(byte[] data, int index, int length)
	{
		if (data != null)
		{
			m_bNotNull = true;
			m_value = new byte[length];
			Array.Copy(data, index, m_value, 0, length);
		}
		else
		{
			m_bNotNull = false;
			m_value = null;
		}
	}

	internal OracleBinary(byte[] data, bool bCopy)
	{
		if (data != null)
		{
			m_bNotNull = true;
			if (bCopy)
			{
				m_value = new byte[data.Length];
				data.CopyTo(m_value, 0);
			}
			else
			{
				m_value = data;
			}
		}
		else
		{
			m_bNotNull = false;
			m_value = null;
		}
	}

	public static OracleBinary Concat(OracleBinary value1, OracleBinary value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::appConcat()\n");
		}
		CompareNullEnum compareNullEnum = InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull);
		if (compareNullEnum != CompareNullEnum.BothNotNull)
		{
			return Null;
		}
		byte[] value3 = value1.m_value;
		byte[] value4 = value2.m_value;
		byte[] array = new byte[value3.Length + value4.Length];
		Array.Copy(value3, array, value3.Length);
		Array.Copy(value4, 0, array, value3.Length, value4.Length);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBinary::Concat()\n");
		}
		return new OracleBinary(array);
	}

	public static bool Equals(OracleBinary value1, OracleBinary value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::Equals(1)\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(1)\n");
			}
			return true;
		default:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(1)\n");
			}
			return false;
		case CompareNullEnum.BothNotNull:
		{
			byte[] value3 = value1.m_value;
			byte[] value4 = value2.m_value;
			if (value3.Length != value4.Length)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(1)\n");
				}
				return false;
			}
			for (int i = 0; i < value3.Length; i++)
			{
				if (value3[i] != value4[i])
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(1)\n");
					}
					return false;
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(1)\n");
			}
			return true;
		}
		}
	}

	public static bool GreaterThan(OracleBinary value1, OracleBinary value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::GreaterThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThan()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThan()\n");
			}
			return true;
		default:
		{
			byte[] value3 = value1.m_value;
			byte[] value4 = value2.m_value;
			int num = 0;
			num = ((value3.Length > value4.Length) ? value4.Length : value3.Length);
			for (int i = 0; i < num; i++)
			{
				if (value3[i] == value4[i])
				{
					continue;
				}
				if (value3[i] > value4[i])
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThan()\n");
					}
					return true;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThan()\n");
				}
				return false;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThan()\n");
			}
			if (value3.Length > value4.Length)
			{
				return true;
			}
			return false;
		}
		}
	}

	public static bool GreaterThanOrEqual(OracleBinary value1, OracleBinary value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::GreaterThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThanOrEqual()\n");
			}
			return false;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThanOrEqual()\n");
			}
			return true;
		default:
		{
			byte[] value3 = value1.m_value;
			byte[] value4 = value2.m_value;
			int num = 0;
			num = ((value3.Length > value4.Length) ? value4.Length : value3.Length);
			for (int i = 0; i < num; i++)
			{
				if (value3[i] == value4[i])
				{
					continue;
				}
				if (value3[i] > value4[i])
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThanOrEqual()\n");
					}
					return true;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThanOrEqual()\n");
				}
				return false;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::GreaterThanOrEqual()\n");
			}
			if (value3.Length >= value4.Length)
			{
				return true;
			}
			return false;
		}
		}
	}

	public static bool LessThan(OracleBinary value1, OracleBinary value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::LessThan()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThan()\n");
			}
			return false;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThan()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThan()\n");
			}
			return false;
		default:
		{
			byte[] value3 = value1.m_value;
			byte[] value4 = value2.m_value;
			int num = 0;
			num = ((value3.Length > value4.Length) ? value4.Length : value3.Length);
			for (int i = 0; i < num; i++)
			{
				if (value3[i] == value4[i])
				{
					continue;
				}
				if (value3[i] < value4[i])
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThan()\n");
					}
					return true;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThan()\n");
				}
				return false;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThan()\n");
			}
			if (value3.Length < value4.Length)
			{
				return true;
			}
			return false;
		}
		}
	}

	public static bool LessThanOrEqual(OracleBinary value1, OracleBinary value2)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::LessThanOrEqual()\n");
		}
		switch (InternalTypes.CompareNull(!value1.m_bNotNull, !value2.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThanOrEqual()\n");
			}
			return true;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThanOrEqual()\n");
			}
			return false;
		default:
		{
			byte[] value3 = value1.m_value;
			byte[] value4 = value2.m_value;
			int num = 0;
			num = ((value3.Length > value4.Length) ? value4.Length : value3.Length);
			for (int i = 0; i < num; i++)
			{
				if (value3[i] == value4[i])
				{
					continue;
				}
				if (value3[i] < value4[i])
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThanOrEqual()\n");
					}
					return true;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThanOrEqual()\n");
				}
				return false;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::LessThanOrEqual()\n");
			}
			if (value3.Length <= value4.Length)
			{
				return true;
			}
			return false;
		}
		}
	}

	public static bool NotEquals(OracleBinary value1, OracleBinary value2)
	{
		return !Equals(value1, value2);
	}

	public static bool operator ==(OracleBinary value1, OracleBinary value2)
	{
		return Equals(value1, value2);
	}

	public static bool operator >(OracleBinary value1, OracleBinary value2)
	{
		return GreaterThan(value1, value2);
	}

	public static bool operator >=(OracleBinary value1, OracleBinary value2)
	{
		return GreaterThanOrEqual(value1, value2);
	}

	public static bool operator <(OracleBinary value1, OracleBinary value2)
	{
		return LessThan(value1, value2);
	}

	public static bool operator <=(OracleBinary value1, OracleBinary value2)
	{
		return LessThanOrEqual(value1, value2);
	}

	public static bool operator !=(OracleBinary value1, OracleBinary value2)
	{
		return NotEquals(value1, value2);
	}

	public static OracleBinary operator +(OracleBinary value1, OracleBinary value2)
	{
		return Concat(value1, value2);
	}

	public static explicit operator byte[](OracleBinary value1)
	{
		if (value1.m_bNotNull)
		{
			return value1.m_value;
		}
		throw new OracleNullValueException();
	}

	public static implicit operator OracleBinary(byte[] value1)
	{
		return new OracleBinary(value1);
	}

	public int CompareTo(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::CompareTo()\n");
		}
		if (obj.GetType() != typeof(OracleBinary))
		{
			throw new ArgumentException();
		}
		OracleBinary oracleBinary = (OracleBinary)obj;
		switch (InternalTypes.CompareNull(!m_bNotNull, !oracleBinary.m_bNotNull))
		{
		case CompareNullEnum.BothNull:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::CompareTo()\n");
			}
			return 0;
		case CompareNullEnum.FirstNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::CompareTo()\n");
			}
			return -1;
		case CompareNullEnum.SecondNullOnly:
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::CompareTo()\n");
			}
			return 1;
		default:
		{
			byte[] value = m_value;
			byte[] value2 = oracleBinary.m_value;
			int num = 0;
			num = ((value.Length > value2.Length) ? value2.Length : value.Length);
			for (int i = 0; i < num; i++)
			{
				if (value[i] == value2[i])
				{
					continue;
				}
				if (value[i] < value2[i])
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (EXIT)  OracleBinary::CompareTo()\n");
					}
					return -1;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBinary::CompareTo()\n");
				}
				return 1;
			}
			if (value.Length == value2.Length)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  OracleBinary::CompareTo()\n");
				}
				return 0;
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::CompareTo()\n");
			}
			if (value.Length < value2.Length)
			{
				return -1;
			}
			return 1;
		}
		}
	}

	public override bool Equals(object obj)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleBinary::Equals(2)\n");
		}
		if (obj == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(2)\n");
			}
			return false;
		}
		if (obj.GetType() != typeof(OracleBinary))
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(2)\n");
			}
			return false;
		}
		OracleBinary value = (OracleBinary)obj;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleBinary::Equals(2)\n");
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

	public override string ToString()
	{
		if (m_bNotNull)
		{
			return string.Concat(GetType(), "(", m_value.Length, ")");
		}
		return "null";
	}
}

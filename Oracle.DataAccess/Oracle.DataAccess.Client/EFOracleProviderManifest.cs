using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.Common.Utils;
using System.Data.Metadata.Edm;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Oracle.DataAccess.Client;

internal class EFOracleProviderManifest : DbXmlEnabledProviderManifest
{
	internal const string ProviderInvariantName = "Oracle.DataAccess.Client";

	internal const string TokenOracle9iR2 = "9.2";

	internal const string TokenOracle10gR1 = "10.1";

	internal const string TokenOracle10gR2 = "10.2";

	internal const string TokenOracle11gR1 = "11.1";

	internal const string TokenOracle11gR2 = "11.2";

	internal const string TokenOracle12gR1 = "12.1";

	internal const string TokenOracle12gR2 = "12.2";

	internal const char LikeEscapeChar = '\\';

	internal const string LikeEscapeCharToString = "\\";

	private const int BinaryMaxSize = 2000;

	private const int Nvarchar2MaxSize = 2000;

	private const int NcharMaxSize = 1000;

	private const int Varchar2MaxSize = 4000;

	internal static bool m_bMapNumberToBoolean = false;

	internal static bool m_bMapNumberToByte = false;

	internal static int m_edmMappingMaxBOOL = 1;

	internal static int m_edmMappingMaxBYTE = 3;

	internal static int m_edmMappingMaxINT16 = 5;

	internal static int m_edmMappingMaxINT32 = 10;

	internal static int m_edmMappingMaxINT64 = 19;

	private EFOracleVersion _version = EFOracleVersion.Oracle11gR2;

	private string _token = "11.2";

	private ReadOnlyCollection<PrimitiveType> _primitiveTypes;

	private ReadOnlyCollection<EdmFunction> _functions;

	internal string Token => _token;

	public EFOracleProviderManifest(string manifestToken)
		: base(GetProviderManifest())
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderManifest::EFOracleProviderManifest()\n");
		}
		_version = EFOracleVersionUtils.GetStorageVersion(manifestToken);
		_token = manifestToken;
		EFOracleProviderServices.FireEdmInUseEvent();
		int num = 0;
		m_bMapNumberToBoolean = false;
		if ((num = RegAndConfigRdr.GetMaxPrecision("BOOL")) > 0)
		{
			m_edmMappingMaxBOOL = num;
			m_bMapNumberToBoolean = true;
		}
		int num2 = 0;
		m_bMapNumberToByte = false;
		if ((num2 = RegAndConfigRdr.GetMaxPrecision("BYTE")) > 0)
		{
			m_edmMappingMaxBYTE = num2;
			m_bMapNumberToByte = true;
		}
		int num3 = 0;
		if ((num3 = RegAndConfigRdr.GetMaxPrecision("INT16")) > 0)
		{
			m_edmMappingMaxINT16 = num3;
		}
		int num4 = 0;
		if ((num4 = RegAndConfigRdr.GetMaxPrecision("INT32")) > 0)
		{
			m_edmMappingMaxINT32 = num4;
		}
		int num5 = 0;
		if ((num5 = RegAndConfigRdr.GetMaxPrecision("INT64")) > 0)
		{
			m_edmMappingMaxINT64 = num5;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  EFOracleProviderManifest::EFOracleProviderManifest()\n");
		}
	}

	private static XmlReader GetProviderManifest()
	{
		return GetXmlResource("Oracle.DataAccess.src.EntityFramework.Resources.EFOracleProviderManifest.xml");
	}

	internal static string EscapeLikeText(string text, bool alwaysEscapeEscapeChar, out bool usedEscapeChar)
	{
		usedEscapeChar = false;
		if (!text.Contains("%") && !text.Contains("_") && (!alwaysEscapeEscapeChar || !text.Contains("\\")))
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		foreach (char c in text)
		{
			if (c == '%' || c == '_' || c == '\\')
			{
				stringBuilder.Append('\\');
				usedEscapeChar = true;
			}
			stringBuilder.Append(c);
		}
		return stringBuilder.ToString();
	}

	protected override XmlReader GetDbInformation(string informationType)
	{
		if (informationType == DbProviderManifest.StoreSchemaDefinition)
		{
			return GetStoreSchemaDescription();
		}
		if (informationType == DbProviderManifest.StoreSchemaMapping)
		{
			return GetStoreSchemaMapping();
		}
		if (informationType == DbProviderManifest.ConceptualSchemaDefinition)
		{
			return null;
		}
		throw new ProviderIncompatibleException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, informationType));
	}

	public override ReadOnlyCollection<PrimitiveType> GetStoreTypes()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderManifest::GetStoreTypes()\n");
		}
		if (_primitiveTypes == null && EFOracleVersionUtils.IsVersionX(_version))
		{
			if (_version < EFOracleVersion.Oracle10gR1)
			{
				List<PrimitiveType> list = new List<PrimitiveType>(base.GetStoreTypes());
				list.RemoveAll(delegate(PrimitiveType primitiveType)
				{
					string text = primitiveType.Name.ToLowerInvariant();
					return text.Equals("binary_float", StringComparison.Ordinal) || text.Equals("binary_double", StringComparison.Ordinal);
				});
				_primitiveTypes = list.AsReadOnly();
			}
			else
			{
				_primitiveTypes = base.GetStoreTypes();
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  EFOracleProviderManifest::GetStoreTypes()\n");
		}
		return _primitiveTypes;
	}

	public override ReadOnlyCollection<EdmFunction> GetStoreFunctions()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderManifest::GetStoreFunctions()\n");
		}
		if (_functions == null && EFOracleVersionUtils.IsVersionX(_version))
		{
			_functions = base.GetStoreFunctions();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) EFOracleProviderManifest::GetStoreFunctions()\n");
		}
		return _functions;
	}

	public override TypeUsage GetEdmType(TypeUsage storeType)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderManifest::GetEdmType()\n");
		}
		EntityUtils.CheckArgumentNull(storeType, "storeType");
		string text = storeType.EdmType.Name.ToLowerInvariant();
		if (!base.StoreTypeNameToEdmPrimitiveType.ContainsKey(text))
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", text));
		}
		PrimitiveType primitiveType = base.StoreTypeNameToEdmPrimitiveType[text];
		int maxLength = 0;
		bool isUnicode = true;
		bool flag = false;
		bool flag2 = true;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) EFOracleProviderManifest::GetEdmType()\n");
		}
		PrimitiveTypeKind primitiveTypeKind;
		switch (text)
		{
		case "int":
		case "smallint":
		case "binary_integer":
		case "pl/sql boolean":
			return TypeUsage.CreateDefaultTypeUsage(primitiveType);
		case "mlslabel":
			return TypeUsage.CreateBinaryTypeUsage(primitiveType, isFixedLength: true, 12345);
		case "varchar2":
			primitiveTypeKind = PrimitiveTypeKind.String;
			flag2 = !MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
			isUnicode = false;
			flag = false;
			break;
		case "char":
			primitiveTypeKind = PrimitiveTypeKind.String;
			flag2 = !MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
			isUnicode = false;
			flag = true;
			break;
		case "nvarchar2":
			primitiveTypeKind = PrimitiveTypeKind.String;
			flag2 = !MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
			isUnicode = true;
			flag = false;
			break;
		case "nchar":
			primitiveTypeKind = PrimitiveTypeKind.String;
			flag2 = !MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
			isUnicode = true;
			flag = true;
			break;
		case "clob":
		case "long":
			primitiveTypeKind = PrimitiveTypeKind.String;
			flag2 = true;
			isUnicode = false;
			flag = false;
			break;
		case "xmltype":
		case "nclob":
			primitiveTypeKind = PrimitiveTypeKind.String;
			flag2 = true;
			isUnicode = true;
			flag = false;
			break;
		case "blob":
		case "bfile":
			primitiveTypeKind = PrimitiveTypeKind.Binary;
			flag2 = true;
			flag = false;
			break;
		case "raw":
			primitiveTypeKind = PrimitiveTypeKind.Binary;
			flag2 = !MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
			flag = false;
			if (maxLength == 16)
			{
				return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Guid));
			}
			break;
		case "long raw":
			primitiveTypeKind = PrimitiveTypeKind.Binary;
			flag2 = !MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
			flag = false;
			break;
		case "guid":
		case "binary_float":
		case "binary_double":
			return TypeUsage.CreateDefaultTypeUsage(primitiveType);
		case "rowid":
		case "urowid":
			primitiveTypeKind = PrimitiveTypeKind.String;
			flag2 = !MetadataHelpers.TryGetMaxLength(storeType, out maxLength);
			isUnicode = false;
			flag = false;
			break;
		case "float":
		{
			if (MetadataHelpers.TryGetPrecision(storeType, out var precision2) && MetadataHelpers.TryGetScale(storeType, out var scale2))
			{
				byte precision3 = byte.Parse(((int)((double)Convert.ToInt32(precision2) * 0.30103 + 1.0)).ToString());
				return TypeUsage.CreateDecimalTypeUsage(primitiveType, precision3, scale2);
			}
			return TypeUsage.CreateDecimalTypeUsage(primitiveType);
		}
		case "number":
		{
			if (MetadataHelpers.TryGetPrecision(storeType, out var precision) && MetadataHelpers.TryGetScale(storeType, out var scale))
			{
				if ((scale == 0 && precision == 1) || (m_bMapNumberToBoolean && scale == 0 && precision <= (byte)m_edmMappingMaxBOOL))
				{
					if (EFOracleProviderServices.m_GetDbProviderManifestTokenWasCalled)
					{
						if (EFOracleProviderServices.m_Entered_Edm_Query6 && !m_bMapNumberToBoolean)
						{
							if (m_bMapNumberToByte && precision <= (byte)m_edmMappingMaxBYTE)
							{
								return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Byte));
							}
							return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Int16));
						}
						return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Boolean));
					}
					if (m_bMapNumberToBoolean && precision <= (byte)m_edmMappingMaxBOOL)
					{
						return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Boolean));
					}
					if (m_bMapNumberToByte && precision <= (byte)m_edmMappingMaxBYTE)
					{
						return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Byte));
					}
					return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Int16));
				}
				if (m_bMapNumberToByte && scale == 0 && precision <= (byte)m_edmMappingMaxBYTE)
				{
					return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Byte));
				}
				if (scale == 0 && precision <= (byte)m_edmMappingMaxINT16)
				{
					return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Int16));
				}
				if (scale == 0 && precision <= (byte)m_edmMappingMaxINT32)
				{
					return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Int32));
				}
				if (scale == 0 && precision <= (byte)m_edmMappingMaxINT64)
				{
					return TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Int64));
				}
				return TypeUsage.CreateDecimalTypeUsage(primitiveType, precision, scale);
			}
			return TypeUsage.CreateDecimalTypeUsage(primitiveType);
		}
		case "date":
			return TypeUsage.CreateDateTimeTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.DateTime), null);
		case "timestamp":
		{
			if (MetadataHelpers.TryGetByteFacetValue(storeType, "Precision", out var byteValue))
			{
				return TypeUsage.CreateDateTimeTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.DateTime), byteValue);
			}
			return TypeUsage.CreateDateTimeTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.DateTime), 9);
		}
		case "timestamp with time zone":
			return TypeUsage.CreateDateTimeOffsetTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.DateTimeOffset), 9);
		case "timestamp with local time zone":
			return TypeUsage.CreateDateTimeTypeUsage(PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.DateTime), byte.MaxValue);
		case "interval year to month":
			return TypeUsage.CreateDecimalTypeUsage(primitiveType, 250, 0);
		case "interval day to second":
			return TypeUsage.CreateDecimalTypeUsage(primitiveType, 251, 0);
		default:
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", text));
		}
		switch (primitiveTypeKind)
		{
		case PrimitiveTypeKind.String:
			if (!flag2)
			{
				return TypeUsage.CreateStringTypeUsage(primitiveType, isUnicode, flag, maxLength);
			}
			return TypeUsage.CreateStringTypeUsage(primitiveType, isUnicode, flag);
		case PrimitiveTypeKind.Binary:
			if (!flag2)
			{
				return TypeUsage.CreateBinaryTypeUsage(primitiveType, flag, maxLength);
			}
			return TypeUsage.CreateBinaryTypeUsage(primitiveType, flag);
		default:
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", text));
		}
	}

	public override TypeUsage GetStoreType(TypeUsage edmType)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderManifest::GetStoreType()\n");
		}
		EntityUtils.CheckArgumentNull(edmType, "edmType");
		if (!(edmType.EdmType is PrimitiveType primitiveType))
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", edmType.EdmType.FullName));
		}
		ReadOnlyMetadataCollection<Facet> facets = edmType.Facets;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) EFOracleProviderManifest::GetStoreType()\n");
		}
		switch (primitiveType.PrimitiveTypeKind)
		{
		case PrimitiveTypeKind.Boolean:
			return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], (byte)m_edmMappingMaxBOOL, 0);
		case PrimitiveTypeKind.Byte:
			return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], (byte)m_edmMappingMaxBYTE, 0);
		case PrimitiveTypeKind.Int16:
			return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], (byte)m_edmMappingMaxINT16, 0);
		case PrimitiveTypeKind.Int32:
			return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], (byte)m_edmMappingMaxINT32, 0);
		case PrimitiveTypeKind.Int64:
			return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], (byte)m_edmMappingMaxINT64, 0);
		case PrimitiveTypeKind.Guid:
			return TypeUsage.CreateBinaryTypeUsage(base.StoreTypeNameToStorePrimitiveType["raw"], isFixedLength: true, 16);
		case PrimitiveTypeKind.Double:
			if (_version < EFOracleVersion.Oracle10gR1)
			{
				return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"]);
			}
			return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["binary_double"]);
		case PrimitiveTypeKind.Single:
			if (_version < EFOracleVersion.Oracle10gR1)
			{
				return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"]);
			}
			return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["binary_float"]);
		case PrimitiveTypeKind.Decimal:
		{
			if (MetadataHelpers.TryGetPrecision(edmType, out var precision) && MetadataHelpers.TryGetScale(edmType, out var scale))
			{
				if (precision == 250 && scale == 0)
				{
					return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["interval year to month"], 9, 0);
				}
				if (precision == 251 && scale == 0)
				{
					return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["interval day to second"], 9, 0);
				}
				return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], precision, scale);
			}
			if (MetadataHelpers.TryGetPrecision(edmType, out precision))
			{
				return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], precision, 0);
			}
			if (MetadataHelpers.TryGetScale(edmType, out scale))
			{
				return TypeUsage.CreateDecimalTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"], 38, scale);
			}
			return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["number"]);
		}
		case PrimitiveTypeKind.Binary:
		{
			bool flag = facets["FixedLength"].Value != null && (bool)facets["FixedLength"].Value;
			Facet facet = facets["MaxLength"];
			bool flag2 = facet.IsUnbounded || facet.Value == null || (int)facet.Value > 2000;
			int num = ((!flag2) ? ((int)facet.Value) : int.MinValue);
			if (flag)
			{
				return TypeUsage.CreateBinaryTypeUsage(base.StoreTypeNameToStorePrimitiveType["raw"], isFixedLength: true, flag2 ? 2000 : num);
			}
			if (flag2)
			{
				return TypeUsage.CreateBinaryTypeUsage(base.StoreTypeNameToStorePrimitiveType["blob"], isFixedLength: false);
			}
			return TypeUsage.CreateBinaryTypeUsage(base.StoreTypeNameToStorePrimitiveType["raw"], isFixedLength: false, num);
		}
		case PrimitiveTypeKind.String:
		{
			bool flag3 = facets["Unicode"].Value == null || (bool)facets["Unicode"].Value;
			bool flag4 = facets["FixedLength"].Value != null && (bool)facets["FixedLength"].Value;
			Facet facet2 = facets["MaxLength"];
			bool flag5 = facet2.IsUnbounded || facet2.Value == null || (int)facet2.Value > (flag3 ? 2000 : 4000);
			int num2 = ((!flag5) ? ((int)facet2.Value) : int.MinValue);
			if (flag3)
			{
				if (flag4)
				{
					return TypeUsage.CreateStringTypeUsage(base.StoreTypeNameToStorePrimitiveType["nchar"], isUnicode: true, isFixedLength: true, flag5 ? 1000 : num2);
				}
				if (flag5)
				{
					return TypeUsage.CreateStringTypeUsage(base.StoreTypeNameToStorePrimitiveType["nclob"], isUnicode: true, isFixedLength: false);
				}
				return TypeUsage.CreateStringTypeUsage(base.StoreTypeNameToStorePrimitiveType["nvarchar2"], isUnicode: true, isFixedLength: false, num2);
			}
			if (flag4)
			{
				return TypeUsage.CreateStringTypeUsage(base.StoreTypeNameToStorePrimitiveType["char"], isUnicode: false, isFixedLength: true, flag5 ? 4000 : num2);
			}
			if (flag5)
			{
				return TypeUsage.CreateStringTypeUsage(base.StoreTypeNameToStorePrimitiveType["clob"], isUnicode: false, isFixedLength: false);
			}
			return TypeUsage.CreateStringTypeUsage(base.StoreTypeNameToStorePrimitiveType["varchar2"], isUnicode: false, isFixedLength: false, num2);
		}
		case PrimitiveTypeKind.DateTime:
			if (facets != null && facets["Precision"].Value != null)
			{
				byte b = (byte)facets["Precision"].Value;
				if (b > 9)
				{
					return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["timestamp with local time zone"]);
				}
				return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["timestamp"]);
			}
			return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["date"]);
		case PrimitiveTypeKind.DateTimeOffset:
			return TypeUsage.CreateDefaultTypeUsage(base.StoreTypeNameToStorePrimitiveType["timestamp with time zone"]);
		default:
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", primitiveType.PrimitiveTypeKind.ToString()));
		}
	}

	public override bool SupportsEscapingLikeArgument(out char escapeCharacter)
	{
		escapeCharacter = '\\';
		return true;
	}

	public override string EscapeLikeArgument(string argument)
	{
		bool usedEscapeChar;
		return EscapeLikeText(argument, alwaysEscapeEscapeChar: true, out usedEscapeChar);
	}

	private XmlReader GetStoreSchemaMapping()
	{
		return GetXmlResource("Oracle.DataAccess.src.EntityFramework.Resources.EFOracleStoreSchemaMapping.msl");
	}

	private XmlReader GetStoreSchemaDescription()
	{
		if (EFOracleVersionUtils.IsVersionX(_version))
		{
			return GetXmlResource("Oracle.DataAccess.src.EntityFramework.Resources.EFOracleStoreSchemaDefinition.ssdl");
		}
		return null;
	}

	internal static XmlReader GetXmlResource(string resourceName)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(resourceName);
		return XmlReader.Create(manifestResourceStream, null, resourceName);
	}
}

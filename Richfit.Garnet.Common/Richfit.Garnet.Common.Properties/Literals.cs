using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Richfit.Garnet.Common.Properties;

/// <summary>
///   一个强类型的资源类，用于查找本地化的字符串等。
/// </summary>
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class Literals
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	/// <summary>
	///   返回此类使用的缓存的 ResourceManager 实例。
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager temp = new ResourceManager("Richfit.Garnet.Common.Properties.Literals", typeof(Literals).Assembly);
				resourceMan = temp;
			}
			return resourceMan;
		}
	}

	/// <summary>
	///   使用此强类型资源类，为所有资源查找
	///   重写当前线程的 CurrentUICulture 属性。
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	/// <summary>
	///   查找类似 The action is null. 的本地化字符串。
	/// </summary>
	public static string MSG_ActionNull => ResourceManager.GetString("MSG_ActionNull", resourceCulture);

	/// <summary>
	///   查找类似 The array and target array are different. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayDifferent => ResourceManager.GetString("MSG_ArrayDifferent", resourceCulture);

	/// <summary>
	///   查找类似 The length of array is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayLengthError => ResourceManager.GetString("MSG_ArrayLengthError", resourceCulture);

	/// <summary>
	///   查找类似 The arrays '{0}' and '{1}' are not same length. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayLengthNotSame_2 => ResourceManager.GetString("MSG_ArrayLengthNotSame_2", resourceCulture);

	/// <summary>
	///   查找类似 The arrays '{0}', '{1}' and '{2}' are not same length. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayLengthNotSame_3 => ResourceManager.GetString("MSG_ArrayLengthNotSame_3", resourceCulture);

	/// <summary>
	///   查找类似 The rank of array is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayRankError => ResourceManager.GetString("MSG_ArrayRankError", resourceCulture);

	/// <summary>
	///   查找类似 The rank of array '{0}' is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayRankError_1 => ResourceManager.GetString("MSG_ArrayRankError_1", resourceCulture);

	/// <summary>
	///   查找类似 The length of array in rank '{0}' is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayRankLengthError_1 => ResourceManager.GetString("MSG_ArrayRankLengthError_1", resourceCulture);

	/// <summary>
	///   查找类似 The arrays '{0}' and '{1}' are not same rank. 的本地化字符串。
	/// </summary>
	public static string MSG_ArrayRankNotSame_2 => ResourceManager.GetString("MSG_ArrayRankNotSame_2", resourceCulture);

	/// <summary>
	///   查找类似 The char '{0}' is not a hex symbol. 的本地化字符串。
	/// </summary>
	public static string MSG_CharNotHexSymbol_1 => ResourceManager.GetString("MSG_CharNotHexSymbol_1", resourceCulture);

	/// <summary>
	///   查找类似 The collection is empty. 的本地化字符串。
	/// </summary>
	public static string MSG_CollectionEmpty => ResourceManager.GetString("MSG_CollectionEmpty", resourceCulture);

	/// <summary>
	///   查找类似 The compression type '{0}' is not supported. 的本地化字符串。
	/// </summary>
	public static string MSG_CompressionTypeNotSupported_1 => ResourceManager.GetString("MSG_CompressionTypeNotSupported_1", resourceCulture);

	/// <summary>
	///   查找类似 Data column '{0}' is duplicate. 的本地化字符串。
	/// </summary>
	public static string MSG_DataColumnDuplication_1 => ResourceManager.GetString("MSG_DataColumnDuplication_1", resourceCulture);

	/// <summary>
	///   查找类似 The data column '{0}' is not found. 的本地化字符串。
	/// </summary>
	public static string MSG_DataColumnNotFound_1 => ResourceManager.GetString("MSG_DataColumnNotFound_1", resourceCulture);

	/// <summary>
	///   查找类似 The data row is not found. 的本地化字符串。
	/// </summary>
	public static string MSG_DataRowNotFound => ResourceManager.GetString("MSG_DataRowNotFound", resourceCulture);

	/// <summary>
	///   查找类似 Can't delete directory '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_DeleteDirectoryError_1 => ResourceManager.GetString("MSG_DeleteDirectoryError_1", resourceCulture);

	/// <summary>
	///   查找类似 The key '{0}' has existed in dictionary. 的本地化字符串。
	/// </summary>
	public static string MSG_DictionaryKeyExisted_1 => ResourceManager.GetString("MSG_DictionaryKeyExisted_1", resourceCulture);

	/// <summary>
	///   查找类似 The key '{0}' is not found in dictionary. 的本地化字符串。
	/// </summary>
	public static string MSG_DictionaryKeyNotFound_1 => ResourceManager.GetString("MSG_DictionaryKeyNotFound_1", resourceCulture);

	/// <summary>
	///   查找类似 The directory '{0}' already exists. 的本地化字符串。
	/// </summary>
	public static string MSG_DirectoryExists_1 => ResourceManager.GetString("MSG_DirectoryExists_1", resourceCulture);

	/// <summary>
	///   查找类似 The directory '{0}' is not empty. 的本地化字符串。
	/// </summary>
	public static string MSG_DirectoryNotEmpty_1 => ResourceManager.GetString("MSG_DirectoryNotEmpty_1", resourceCulture);

	/// <summary>
	///   查找类似 The directory '{0}' is not found. 的本地化字符串。
	/// </summary>
	public static string MSG_DirectoryNotFound_1 => ResourceManager.GetString("MSG_DirectoryNotFound_1", resourceCulture);

	/// <summary>
	///   查找类似 The format of encrypted data is error. 的本地化字符串。
	/// </summary>
	public static string MSG_EncryptedDataFormatError => ResourceManager.GetString("MSG_EncryptedDataFormatError", resourceCulture);

	/// <summary>
	///   查找类似 Does not support the specified encryption algorithm '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_EncryptionAlgorithmNotSupport_1 => ResourceManager.GetString("MSG_EncryptionAlgorithmNotSupport_1", resourceCulture);

	/// <summary>
	///   查找类似 The specified encryption algorithm '{0}' is not a '{1}'. 的本地化字符串。
	/// </summary>
	public static string MSG_EncryptionAlgorithmTypeError_2 => ResourceManager.GetString("MSG_EncryptionAlgorithmTypeError_2", resourceCulture);

	/// <summary>
	///   查找类似 Can't create exception instance. 的本地化字符串。
	/// </summary>
	public static string MSG_ExceptionCreatingFailed => ResourceManager.GetString("MSG_ExceptionCreatingFailed", resourceCulture);

	/// <summary>
	///   查找类似 The exception creator is null. 的本地化字符串。
	/// </summary>
	public static string MSG_ExceptionCreatorNull => ResourceManager.GetString("MSG_ExceptionCreatorNull", resourceCulture);

	/// <summary>
	///   查找类似 The exception type does not inherit from System.Exception. 的本地化字符串。
	/// </summary>
	public static string MSG_ExceptionTypeError => ResourceManager.GetString("MSG_ExceptionTypeError", resourceCulture);

	/// <summary>
	///   查找类似 The exception type is null. 的本地化字符串。
	/// </summary>
	public static string MSG_ExceptionTypeNull => ResourceManager.GetString("MSG_ExceptionTypeNull", resourceCulture);

	/// <summary>
	///   查找类似 The expected exception does not inherit from System.Exception. 的本地化字符串。
	/// </summary>
	public static string MSG_ExpectedExceptionError => ResourceManager.GetString("MSG_ExpectedExceptionError", resourceCulture);

	/// <summary>
	///   查找类似 The expected exception is not occured. 的本地化字符串。
	/// </summary>
	public static string MSG_ExpectedExceptionNotOccured => ResourceManager.GetString("MSG_ExpectedExceptionNotOccured", resourceCulture);

	/// <summary>
	///   查找类似 The type of expected exception is null. 的本地化字符串。
	/// </summary>
	public static string MSG_ExpectedExceptionTypeNull => ResourceManager.GetString("MSG_ExpectedExceptionTypeNull", resourceCulture);

	/// <summary>
	///   查找类似 The file '{0}' already exists. 的本地化字符串。
	/// </summary>
	public static string MSG_FileExistsException_1 => ResourceManager.GetString("MSG_FileExistsException_1", resourceCulture);

	/// <summary>
	///   查找类似 The file '{0}' is not found. 的本地化字符串。
	/// </summary>
	public static string MSG_FileNotFoundException_1 => ResourceManager.GetString("MSG_FileNotFoundException_1", resourceCulture);

	/// <summary>
	///   查找类似 The format of hex number is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_HexNumberFormatError => ResourceManager.GetString("MSG_HexNumberFormatError", resourceCulture);

	/// <summary>
	///   查找类似 Then length of the hex string should be a multiple of 2. 的本地化字符串。
	/// </summary>
	public static string MSG_HexStringLengthError => ResourceManager.GetString("MSG_HexStringLengthError", resourceCulture);

	/// <summary>
	///   查找类似 The index '{0}' is greater than the high bound '{1}'. 的本地化字符串。
	/// </summary>
	public static string MSG_IndexGreaterThanHighBound_2 => ResourceManager.GetString("MSG_IndexGreaterThanHighBound_2", resourceCulture);

	/// <summary>
	///   查找类似 The index '{0}' is less than the low bound '{1}'. 的本地化字符串。
	/// </summary>
	public static string MSG_IndexLessThanLowBound_2 => ResourceManager.GetString("MSG_IndexLessThanLowBound_2", resourceCulture);

	/// <summary>
	///   查找类似 The index '{0}' is out of range. 的本地化字符串。
	/// </summary>
	public static string MSG_IndexOutOfRange_1 => ResourceManager.GetString("MSG_IndexOutOfRange_1", resourceCulture);

	/// <summary>
	///   查找类似 The type is not inherited from target type '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_InheritedTypeError_1 => ResourceManager.GetString("MSG_InheritedTypeError_1", resourceCulture);

	/// <summary>
	///   查找类似 Invalid accessibility level. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidAccessibilityLevel => ResourceManager.GetString("MSG_InvalidAccessibilityLevel", resourceCulture);

	/// <summary>
	///   查找类似 Can't convert the value to type '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidCast_1 => ResourceManager.GetString("MSG_InvalidCast_1", resourceCulture);

	/// <summary>
	///   查找类似 Can't convert the value '{0}' to type '{1}'. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidCast_2 => ResourceManager.GetString("MSG_InvalidCast_2", resourceCulture);

	/// <summary>
	///   查找类似 The code page '{0}' is invalid. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidCodePage_1 => ResourceManager.GetString("MSG_InvalidCodePage_1", resourceCulture);

	/// <summary>
	///   查找类似 The kind of date '{0}' is invalid. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidDateTimeKind_1 => ResourceManager.GetString("MSG_InvalidDateTimeKind_1", resourceCulture);

	/// <summary>
	///   查找类似 The directory path '{0}' is invalid. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidDirectoryPath_1 => ResourceManager.GetString("MSG_InvalidDirectoryPath_1", resourceCulture);

	/// <summary>
	///   查找类似 The file path '{0}' is invalid. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidFilePath_1 => ResourceManager.GetString("MSG_InvalidFilePath_1", resourceCulture);

	/// <summary>
	///   查找类似 The format provider is invalid. 的本地化字符串。
	/// </summary>
	public static string MSG_InvalidFormatProvider => ResourceManager.GetString("MSG_InvalidFormatProvider", resourceCulture);

	/// <summary>
	///   查找类似 Invoking instance method without instance object. 的本地化字符串。
	/// </summary>
	public static string MSG_InvokeInstanceMethodWithoutObject => ResourceManager.GetString("MSG_InvokeInstanceMethodWithoutObject", resourceCulture);

	/// <summary>
	///   查找类似 The json string is unrecognized. 的本地化字符串。
	/// </summary>
	public static string MSG_JsonUnrecognized => ResourceManager.GetString("MSG_JsonUnrecognized", resourceCulture);

	/// <summary>
	///   查找类似 The list is empty. 的本地化字符串。
	/// </summary>
	public static string MSG_ListEmpty => ResourceManager.GetString("MSG_ListEmpty", resourceCulture);

	/// <summary>
	///   查找类似 The invoking method '{0}' is not support. 的本地化字符串。
	/// </summary>
	public static string MSG_MethodInvokedNotSupport_1 => ResourceManager.GetString("MSG_MethodInvokedNotSupport_1", resourceCulture);

	/// <summary>
	///   查找类似 The constructor dose not exists. 的本地化字符串。
	/// </summary>
	public static string MSG_MissingConstructor => ResourceManager.GetString("MSG_MissingConstructor", resourceCulture);

	/// <summary>
	///   查找类似 Property '{0}' does not exist. 的本地化字符串。
	/// </summary>
	public static string MSG_MissingProperty_1 => ResourceManager.GetString("MSG_MissingProperty_1", resourceCulture);

	/// <summary>
	///   查找类似 The format of number is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_NumberFormatError => ResourceManager.GetString("MSG_NumberFormatError", resourceCulture);

	/// <summary>
	///   查找类似 The object is an array. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectArray => ResourceManager.GetString("MSG_ObjectArray", resourceCulture);

	/// <summary>
	///   查找类似 The object is disposed. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectDisposed => ResourceManager.GetString("MSG_ObjectDisposed", resourceCulture);

	/// <summary>
	///   查找类似 The null reference is used to invoke instance properties. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectInstancePropertyWithNullReference => ResourceManager.GetString("MSG_ObjectInstancePropertyWithNullReference", resourceCulture);

	/// <summary>
	///   查找类似 The object does not contains 'Memberwise' method. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectNoMemberwiseClone => ResourceManager.GetString("MSG_ObjectNoMemberwiseClone", resourceCulture);

	/// <summary>
	///   查找类似 The object is not an array. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectNotArray => ResourceManager.GetString("MSG_ObjectNotArray", resourceCulture);

	/// <summary>
	///   查找类似 The object is not a instance of class or interface. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectNotOfReferenceType => ResourceManager.GetString("MSG_ObjectNotOfReferenceType", resourceCulture);

	/// <summary>
	///   查找类似 The object is not a instance of the type. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectNotOfType => ResourceManager.GetString("MSG_ObjectNotOfType", resourceCulture);

	/// <summary>
	///   查找类似 The object is not a instance of value type. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectNotOfValueType => ResourceManager.GetString("MSG_ObjectNotOfValueType", resourceCulture);

	/// <summary>
	///   查找类似 The object is not support comparison. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectNotSupportComparison => ResourceManager.GetString("MSG_ObjectNotSupportComparison", resourceCulture);

	/// <summary>
	///   查找类似 The object is a instance of the type. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectOfType => ResourceManager.GetString("MSG_ObjectOfType", resourceCulture);

	/// <summary>
	///   查找类似 The property type is not match with expected type. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectPropertyTypeNotMatch => ResourceManager.GetString("MSG_ObjectPropertyTypeNotMatch", resourceCulture);

	/// <summary>
	///   查找类似 The property type is not match with the value. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectPropertyTypeValueNotMatch => ResourceManager.GetString("MSG_ObjectPropertyTypeValueNotMatch", resourceCulture);

	/// <summary>
	///   查找类似 The property is unreadable. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectPropertyUnreadable => ResourceManager.GetString("MSG_ObjectPropertyUnreadable", resourceCulture);

	/// <summary>
	///   查找类似 The property is unwritable. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectPropertyUnwritable => ResourceManager.GetString("MSG_ObjectPropertyUnwritable", resourceCulture);

	/// <summary>
	///   查找类似 The null reference is assigned to a property of value type. 的本地化字符串。
	/// </summary>
	public static string MSG_ObjectValueTypePropertyWithNullReference => ResourceManager.GetString("MSG_ObjectValueTypePropertyWithNullReference", resourceCulture);

	/// <summary>
	///   查找类似 The platform arichitecture is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_PlatformArchitectureException => ResourceManager.GetString("MSG_PlatformArchitectureException", resourceCulture);

	/// <summary>
	///   查找类似 The predicate is not matched. 的本地化字符串。
	/// </summary>
	public static string MSG_PredicateNotMatched => ResourceManager.GetString("MSG_PredicateNotMatched", resourceCulture);

	/// <summary>
	///   查找类似 The predicate is null. 的本地化字符串。
	/// </summary>
	public static string MSG_PredicateNull => ResourceManager.GetString("MSG_PredicateNull", resourceCulture);

	/// <summary>
	///   查找类似 Property '{0}' already exists. 的本地化字符串。
	/// </summary>
	public static string MSG_PropertyExists_1 => ResourceManager.GetString("MSG_PropertyExists_1", resourceCulture);

	/// <summary>
	///   查找类似 Property '{0}' does not match. 的本地化字符串。
	/// </summary>
	public static string MSG_PropertyTypeNotMatch_1 => ResourceManager.GetString("MSG_PropertyTypeNotMatch_1", resourceCulture);

	/// <summary>
	///   查找类似 The each value of weights for radix parse must be greater than 0. 的本地化字符串。
	/// </summary>
	public static string MSG_RadixParseWeigthsOutOfRange => ResourceManager.GetString("MSG_RadixParseWeigthsOutOfRange", resourceCulture);

	/// <summary>
	///   查找类似 The cache capacity of regex manager is out of range. 的本地化字符串。
	/// </summary>
	public static string MSG_RegexManagerCacheCapacityOutOfRange => ResourceManager.GetString("MSG_RegexManagerCacheCapacityOutOfRange", resourceCulture);

	/// <summary>
	///   查找类似 The regex object is null. 的本地化字符串。
	/// </summary>
	public static string MSG_RegexManagerRegexNull => ResourceManager.GetString("MSG_RegexManagerRegexNull", resourceCulture);

	/// <summary>
	///   查找类似 The regex expression is empty. 的本地化字符串。
	/// </summary>
	public static string MSG_RegexManagerRegexTextEmpty => ResourceManager.GetString("MSG_RegexManagerRegexTextEmpty", resourceCulture);

	/// <summary>
	///   查找类似 The RSA CRT info is incomplete. 的本地化字符串。
	/// </summary>
	public static string MSG_RSAIncompleteCrtInfo => ResourceManager.GetString("MSG_RSAIncompleteCrtInfo", resourceCulture);

	/// <summary>
	///   查找类似 The RSA private key is imcomplete. 的本地化字符串。
	/// </summary>
	public static string MSG_RSAIncompletePrivateKey => ResourceManager.GetString("MSG_RSAIncompletePrivateKey", resourceCulture);

	/// <summary>
	///   查找类似 The RSA public key is imcomplete. 的本地化字符串。
	/// </summary>
	public static string MSG_RSAIncompletePublicKey => ResourceManager.GetString("MSG_RSAIncompletePublicKey", resourceCulture);

	/// <summary>
	///   查找类似 The message too long to process. 的本地化字符串。
	/// </summary>
	public static string MSG_RSAMessageTooLong => ResourceManager.GetString("MSG_RSAMessageTooLong", resourceCulture);

	/// <summary>
	///   查找类似 The RSA OAEP decoding is error. 的本地化字符串。
	/// </summary>
	public static string MSG_RSAOAEPDecodeError => ResourceManager.GetString("MSG_RSAOAEPDecodeError", resourceCulture);

	/// <summary>
	///   查找类似 The RSA options is error. 的本地化字符串。
	/// </summary>
	public static string MSG_RSAOptionError => ResourceManager.GetString("MSG_RSAOptionError", resourceCulture);

	/// <summary>
	///   查找类似 The RSA PKCS 1.5 decoding is error. 的本地化字符串。
	/// </summary>
	public static string MSG_RSAPKCS15DecodeError => ResourceManager.GetString("MSG_RSAPKCS15DecodeError", resourceCulture);

	/// <summary>
	///   查找类似 All of element satisfies the condition in predicate. 的本地化字符串。
	/// </summary>
	public static string MSG_SequenceAllElementInPredicate => ResourceManager.GetString("MSG_SequenceAllElementInPredicate", resourceCulture);

	/// <summary>
	///   查找类似 The any one element of sequence satisfies the condition in predicate. 的本地化字符串。
	/// </summary>
	public static string MSG_SequenceAnyOneElementInPredicate => ResourceManager.GetString("MSG_SequenceAnyOneElementInPredicate", resourceCulture);

	/// <summary>
	///   查找类似 The any one element of sequence does not satisfies the condition in predicate. 的本地化字符串。
	/// </summary>
	public static string MSG_SequenceAnyOneElementNotInPredicate => ResourceManager.GetString("MSG_SequenceAnyOneElementNotInPredicate", resourceCulture);

	/// <summary>
	///   查找类似 The sequence is empty. 的本地化字符串。
	/// </summary>
	public static string MSG_SequenceEmpty => ResourceManager.GetString("MSG_SequenceEmpty", resourceCulture);

	/// <summary>
	///   查找类似 The one or more elements satisfies the condition in predicate. 的本地化字符串。
	/// </summary>
	public static string MSG_SequenceMoreElementsInPredicate => ResourceManager.GetString("MSG_SequenceMoreElementsInPredicate", resourceCulture);

	/// <summary>
	///   查找类似 No element satisfies the condition in predicate. 的本地化字符串。
	/// </summary>
	public static string MSG_SequenceNotElementInPredicate => ResourceManager.GetString("MSG_SequenceNotElementInPredicate", resourceCulture);

	/// <summary>
	///   查找类似 The sequence is null or empty. 的本地化字符串。
	/// </summary>
	public static string MSG_SequenceNullOrEmpty => ResourceManager.GetString("MSG_SequenceNullOrEmpty", resourceCulture);

	/// <summary>
	///   查找类似 The current stream does not support reading. 的本地化字符串。
	/// </summary>
	public static string MSG_StreamNotSupportRead => ResourceManager.GetString("MSG_StreamNotSupportRead", resourceCulture);

	/// <summary>
	///   查找类似 The current stream does not support seeking. 的本地化字符串。
	/// </summary>
	public static string MSG_StreamNotSupportSeek => ResourceManager.GetString("MSG_StreamNotSupportSeek", resourceCulture);

	/// <summary>
	///   查找类似 The current stream does not support writing. 的本地化字符串。
	/// </summary>
	public static string MSG_StreamNotSupportWrite => ResourceManager.GetString("MSG_StreamNotSupportWrite", resourceCulture);

	/// <summary>
	///   查找类似 The length of string is error, it should be equal to {0}. 的本地化字符串。
	/// </summary>
	public static string MSG_StringLengthError_1 => ResourceManager.GetString("MSG_StringLengthError_1", resourceCulture);

	/// <summary>
	///   查找类似 The string is null or empty. 的本地化字符串。
	/// </summary>
	public static string MSG_StringNullOrEmpty => ResourceManager.GetString("MSG_StringNullOrEmpty", resourceCulture);

	/// <summary>
	///   查找类似 The string is null, empty or white space. 的本地化字符串。
	/// </summary>
	public static string MSG_StringNullOrWhiteSpace => ResourceManager.GetString("MSG_StringNullOrWhiteSpace", resourceCulture);

	/// <summary>
	///   查找类似 The switch index is out of range. 的本地化字符串。
	/// </summary>
	public static string MSG_SwitchIndexOutOfRange => ResourceManager.GetString("MSG_SwitchIndexOutOfRange", resourceCulture);

	/// <summary>
	///   查找类似 The type '{0}' is not an Enum type. 的本地化字符串。
	/// </summary>
	public static string MSG_TypeNotEnum_1 => ResourceManager.GetString("MSG_TypeNotEnum_1", resourceCulture);

	/// <summary>
	///   查找类似 The type dose not inherit from the target type '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_TypeNotInheritFromTarget_1 => ResourceManager.GetString("MSG_TypeNotInheritFromTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The type is not the target type '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_TypeNotTarget_1 => ResourceManager.GetString("MSG_TypeNotTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The instance type is null. 的本地化字符串。
	/// </summary>
	public static string MSG_TypeNull => ResourceManager.GetString("MSG_TypeNull", resourceCulture);

	/// <summary>
	///   查找类似 The value is equal to the default value of its type. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueDefault => ResourceManager.GetString("MSG_ValueDefault", resourceCulture);

	/// <summary>
	///   查找类似 The value is equal to the value. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueEqualToTarget => ResourceManager.GetString("MSG_ValueEqualToTarget", resourceCulture);

	/// <summary>
	///   查找类似 The value is equal to the value '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueEqualToTarget_1 => ResourceManager.GetString("MSG_ValueEqualToTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueError => ResourceManager.GetString("MSG_ValueError", resourceCulture);

	/// <summary>
	///   查找类似 The value '{0}' is incorrect. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueError_1 => ResourceManager.GetString("MSG_ValueError_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is false. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueFalse => ResourceManager.GetString("MSG_ValueFalse", resourceCulture);

	/// <summary>
	///   查找类似 The value is greater than or equal to the target. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueGreaterThanOrEqualToTarget => ResourceManager.GetString("MSG_ValueGreaterThanOrEqualToTarget", resourceCulture);

	/// <summary>
	///   查找类似 The value is greater than or equal to the target '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueGreaterThanOrEqualToTarget_1 => ResourceManager.GetString("MSG_ValueGreaterThanOrEqualToTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is greater than the target. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueGreaterThanTarget => ResourceManager.GetString("MSG_ValueGreaterThanTarget", resourceCulture);

	/// <summary>
	///   查找类似 The value is greater than the target '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueGreaterThanTarget_1 => ResourceManager.GetString("MSG_ValueGreaterThanTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is in range. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueInRange => ResourceManager.GetString("MSG_ValueInRange", resourceCulture);

	/// <summary>
	///   查找类似 The value '{0}' is in range. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueInRange_1 => ResourceManager.GetString("MSG_ValueInRange_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is in the targets. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueInTargets => ResourceManager.GetString("MSG_ValueInTargets", resourceCulture);

	/// <summary>
	///   查找类似 The value is less than or equal to the target. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueLessThanOrEqualToTarget => ResourceManager.GetString("MSG_ValueLessThanOrEqualToTarget", resourceCulture);

	/// <summary>
	///   查找类似 The value is less than or equal to the target '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueLessThanOrEqualToTarget_1 => ResourceManager.GetString("MSG_ValueLessThanOrEqualToTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is less than the target. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueLessThanTarget => ResourceManager.GetString("MSG_ValueLessThanTarget", resourceCulture);

	/// <summary>
	///   查找类似 The value is less than the target '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueLessThanTarget_1 => ResourceManager.GetString("MSG_ValueLessThanTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is not equal to the default value of its type. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNotDefault => ResourceManager.GetString("MSG_ValueNotDefault", resourceCulture);

	/// <summary>
	///   查找类似 The value is not equal to the target. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNotEqualToTarget => ResourceManager.GetString("MSG_ValueNotEqualToTarget", resourceCulture);

	/// <summary>
	///   查找类似 The value is not equal to the target '{0}'. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNotEqualToTarget_1 => ResourceManager.GetString("MSG_ValueNotEqualToTarget_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is not found. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNotFound => ResourceManager.GetString("MSG_ValueNotFound", resourceCulture);

	/// <summary>
	///   查找类似 The value is not in the targets. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNotInTargets => ResourceManager.GetString("MSG_ValueNotInTargets", resourceCulture);

	/// <summary>
	///   查找类似 The value is not null. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNotNull => ResourceManager.GetString("MSG_ValueNotNull", resourceCulture);

	/// <summary>
	///   查找类似 The value is null. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNull => ResourceManager.GetString("MSG_ValueNull", resourceCulture);

	/// <summary>
	///   查找类似 The value '{0}' is null. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNull_1 => ResourceManager.GetString("MSG_ValueNull_1", resourceCulture);

	/// <summary>
	///   查找类似 The value is Null or DBNull. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNullOrDBNull => ResourceManager.GetString("MSG_ValueNullOrDBNull", resourceCulture);

	/// <summary>
	///   查找类似 The value is Null or the default value of its type. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueNullOrDefault => ResourceManager.GetString("MSG_ValueNullOrDefault", resourceCulture);

	/// <summary>
	///   查找类似 The value is out of range. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueOutOfRange => ResourceManager.GetString("MSG_ValueOutOfRange", resourceCulture);

	/// <summary>
	///   查找类似 The value '{0}' is out of range. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueOutOfRange_1 => ResourceManager.GetString("MSG_ValueOutOfRange_1", resourceCulture);

	/// <summary>
	///   查找类似 The min value is greater than max value. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueRangeMinGreaterThanMax => ResourceManager.GetString("MSG_ValueRangeMinGreaterThanMax", resourceCulture);

	/// <summary>
	///   查找类似 The object is true. 的本地化字符串。
	/// </summary>
	public static string MSG_ValueTrue => ResourceManager.GetString("MSG_ValueTrue", resourceCulture);

	/// <summary>
	///   查找类似 The watching timer has initialized. 的本地化字符串。
	/// </summary>
	public static string MSG_WatchingTimerInitialized => ResourceManager.GetString("MSG_WatchingTimerInitialized", resourceCulture);

	/// <summary>
	///   查找类似 The watching timer is null. 的本地化字符串。
	/// </summary>
	public static string MSG_WatchingTimerNull => ResourceManager.GetString("MSG_WatchingTimerNull", resourceCulture);

	/// <summary>
	///   查找类似 The property '{0}' is not found in xml element '{1}', 的本地化字符串。
	/// </summary>
	public static string MSG_XmlPropertyNotFound_2 => ResourceManager.GetString("MSG_XmlPropertyNotFound_2", resourceCulture);

	internal Literals()
	{
	}
}

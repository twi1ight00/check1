using System;

namespace AutoMapper.Internal;

public static class FeatureDetector
{
	public static Func<Type, bool> IsIDataRecordType = (Type t) => false;

	private static bool? _isEnumGetNamesSupported;

	public static bool IsEnumGetNamesSupported
	{
		get
		{
			if (!_isEnumGetNamesSupported.HasValue)
			{
				_isEnumGetNamesSupported = ResolveIsEnumGetNamesSupported();
			}
			return _isEnumGetNamesSupported.Value;
		}
	}

	private static bool ResolveIsEnumGetNamesSupported()
	{
		return (object)typeof(Enum).GetMethod("GetNames") != null;
	}
}

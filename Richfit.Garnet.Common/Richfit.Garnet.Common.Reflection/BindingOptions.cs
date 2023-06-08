using System.Reflection;

namespace Richfit.Garnet.Common.Reflection;

/// <summary>
/// 类型成员绑定枚举常量
/// </summary>
public static class BindingOptions
{
	/// <summary>
	/// 获取当前类型中定义的公共和非公共的静态和实例成员，以及基类中定义的非私有实例成员
	/// </summary>
	public const BindingFlags All = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的公共和非公共的静态和实例成员
	/// </summary>
	public const BindingFlags Declared = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的公共和非公共的静态和实例成员，以及基类中定义的非私有静态和实例成员
	/// </summary>
	public const BindingFlags Flatten = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

	/// <summary>
	/// 获取当前类型中定义的公共和非公共的静态成员
	/// </summary>
	public const BindingFlags Static = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的公共和非公共的静态成员，以及基类中定义的非私有的静态成员
	/// </summary>
	public const BindingFlags StaticFlatten = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

	/// <summary>
	/// 获取当前类型中定义的公共和非公共的实例成员，以及基类中定义的非私有实例成员
	/// </summary>
	public const BindingFlags Instance = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的公共和非公共的实例成员
	/// </summary>
	public const BindingFlags InstanceDeclared = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的公共静态和实例成员，以及基类中定义的公共实例成员
	/// </summary>
	public const BindingFlags Public = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

	/// <summary>
	/// 获取当前类型中定义的公共静态和实例成员
	/// </summary>
	public const BindingFlags PublicDeclared = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

	/// <summary>
	/// 获取当前类型中定义的公共静态和实例成员，以及基类中定义的公共静态和实例成员
	/// </summary>
	public const BindingFlags PublicFlatten = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;

	/// <summary>
	/// 获取当前类型中定义的公共静态成员
	/// </summary>
	public const BindingFlags PublicStatic = BindingFlags.Static | BindingFlags.Public;

	/// <summary>
	/// 获取当前类型中定义的公共静态成员，以及基类中定义的公共静态成员
	/// </summary>
	public const BindingFlags PublicStaticFlatten = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;

	/// <summary>
	/// 获取当前类型中定义的公共实例成员，以及基类中定义的公共实例成员
	/// </summary>
	public const BindingFlags PublicInstance = BindingFlags.Instance | BindingFlags.Public;

	/// <summary>
	/// 获取当前类型中定义的公共实例成员
	/// </summary>
	public const BindingFlags PublicInstanceDeclared = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;

	/// <summary>
	/// 获取当前类型中定义的非公共静态和实例成员，以及基类中定义的非公共非私有的实例成员
	/// </summary>
	public const BindingFlags NonPublic = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的非公共静态和实例成员
	/// </summary>
	public const BindingFlags NonPublicDeclared = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的非公共静态和实例成员，以及基类中定义的非公共非私有的静态和实例成员
	/// </summary>
	public const BindingFlags NonPublicFlatten = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

	/// <summary>
	/// 获取当前类型中定义的非公共静态成员
	/// </summary>
	public const BindingFlags NonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的非公共静态成员，以及基类中定义的非公共非私有的静态成员
	/// </summary>
	public const BindingFlags NonPublicStaticFlatten = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

	/// <summary>
	/// 获取当前类型中定义的非公共实例成员，以及基类中的非公共非私有的实例成员
	/// </summary>
	public const BindingFlags NonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;

	/// <summary>
	/// 获取当前类型中定义的非公共实例成员
	/// </summary>
	public const BindingFlags NonPublicInstanceDeclared = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic;
}

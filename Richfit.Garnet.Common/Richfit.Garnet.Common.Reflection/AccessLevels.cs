using System;

namespace Richfit.Garnet.Common.Reflection;

/// <summary>
/// 访问级别类型枚举
/// </summary>
[Flags]
public enum AccessLevels
{
	/// <summary>
	/// 未指定
	/// </summary>
	Unspecified = 0,
	/// <summary>
	/// 公共成员，全局可访问
	/// public
	/// </summary>
	Public = 1,
	/// <summary>
	/// 可由派生类（无论其位置如何）和同一程序集中的类调用
	/// internal protected
	/// </summary>
	FamilyOrAssembly = 2,
	/// <summary>
	/// 只对同一程序集中的其他类型可见，而对该程序集以外的派生类型则不可见
	/// internal
	/// </summary>
	Assembly = 4,
	/// <summary>
	/// 仅在其类和派生类内可见
	/// protected
	/// </summary>
	Family = 8,
	/// <summary>
	/// 可由派生类调用，但仅当这些派生类在同一程序集中时
	/// internal private
	/// </summary>
	FamilyAndAssembly = 0x10,
	/// <summary>
	/// 此成员是否是私有的，声明类外不可访问
	/// private
	/// </summary>
	Private = 0x20,
	/// <summary>
	/// 非公共成员
	/// </summary>
	NonPublic = 0x3F,
	/// <summary>
	/// 实例成员
	/// </summary>
	Instance = 0x100,
	/// <summary>
	/// 静态成员
	/// </summary>
	Static = 0x200,
	/// <summary>
	/// 静态成员和实例成员
	/// </summary>
	Both = 0x300,
	/// <summary>
	/// 公共实例成员
	/// </summary>
	PublicInstance = 0x101,
	/// <summary>
	/// 非公共实例成员
	/// </summary>
	NonPublicInstance = 0x13F,
	/// <summary>
	/// 可由派生类（无论其位置如何）和同一程序集中的类调用的实例成员
	/// </summary>
	FamilyOrAssemblyInstance = 0x102,
	/// <summary>
	/// 只对同一程序集中的其他类型可见，而对该程序集以外的派生类型则不可见的实例成员
	/// </summary>
	AssemblyInstance = 0x104,
	/// <summary>
	/// 仅在其类和派生类内可见的实例成员
	/// </summary>
	FamilyInstance = 0x108,
	/// <summary>
	/// 仅当这些派生类在同一程序集中时可由派生类调用的实例成员
	/// </summary>
	FamilyAndAssemblyInstance = 0x110,
	/// <summary>
	/// 私有的实例成员
	/// </summary>
	PrivateInstance = 0x120,
	/// <summary>
	/// 公共静态成员
	/// </summary>
	PublicStatic = 0x201,
	/// <summary>
	/// 非公共静态成员
	/// </summary>
	NonPublicStatic = 0x23F,
	/// <summary>
	/// 可由派生类（无论其位置如何）和同一程序集中的类调用的静态成员
	/// </summary>
	FamilyOrAssemblyStatic = 0x202,
	/// <summary>
	/// 只对同一程序集中的其他类型可见，而对该程序集以外的派生类型则不可见的静态成员
	/// </summary>
	AssemblyStatic = 0x204,
	/// <summary>
	/// 仅在其类和派生类内可见的静态成员
	/// </summary>
	FamilyStatic = 0x208,
	/// <summary>
	/// 仅当这些派生类在同一程序集中时可由派生类调用的静态成员
	/// </summary>
	FamilyAndAssemblyStatic = 0x210,
	/// <summary>
	/// 私有的静态成员
	/// </summary>
	PrivateStatic = 0x220,
	/// <summary>
	/// 公共静态成员和实例成员
	/// </summary>
	PublicBoth = 0x301,
	/// <summary>
	/// 非公共静态成员和实例成员
	/// </summary>
	NonPublicBoth = 0x33F,
	/// <summary>
	/// 可由派生类（无论其位置如何）和同一程序集中的类调用的静态成员和实例成员
	/// </summary>
	FamilyOrAssemblyBoth = 0x302,
	/// <summary>
	/// 只对同一程序集中的其他类型可见，而对该程序集以外的派生类型则不可见的静态成员和实例成员
	/// </summary>
	AssemblyBoth = 0x304,
	/// <summary>
	/// 仅在其类和派生类内可见的静态成员和实例成员
	/// </summary>
	FamilyBoth = 0x308,
	/// <summary>
	/// 仅当这些派生类在同一程序集中时可由派生类调用的静态成员和实例成员
	/// </summary>
	FamilyAndAssemblyBoth = 0x310,
	/// <summary>
	/// 私有的静态成员和实例成员
	/// </summary>
	PrivateBoth = 0x320
}

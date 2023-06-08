using System;
using AutoMapper;

namespace Richfit.Garnet.Common.Mapping;

/// <summary>
/// 类型映射器接口
/// </summary>
public interface ITypeMapper
{
	/// <summary>
	/// 获取或者设置是否允许映射的目标对象是否可以包含null
	/// </summary>
	bool AllowNullDestinationValues { get; set; }

	/// <summary>
	/// 获取映射配置对象
	/// </summary>
	IConfiguration Configuration { get; }

	/// <summary>
	/// 获取AutoMapper映射处理引擎
	/// </summary>
	IMappingEngine Engine { get; }

	/// <summary>
	/// 添加全局忽略的属性筛选条件
	/// </summary>
	/// <param name="prefix">需要忽略不处理的成员的名称前缀</param>
	void AddGlobalIgnore(string prefix);

	/// <summary>
	/// 添加映射配置
	/// </summary>
	/// <param name="profile">映射配置对象</param>
	void AddProfile(Profile profile);

	/// <summary>
	/// 添加映射配置
	/// </summary>
	/// <typeparam name="P">映射配置对象类型</typeparam>
	void AddProfile<P>() where P : Profile, new();

	/// <summary>
	/// 验证映射配置是否有效
	/// </summary>
	void AssertConfigurationIsValid();

	/// <summary>
	/// 验证映射规则是否有效
	/// </summary>
	/// <param name="typeMap">待验证的类型映射规则</param>
	void AssertConfigurationIsValid(TypeMap typeMap);

	/// <summary>
	/// 验证映射配置是否有效
	/// </summary>
	/// <param name="profileName">待验证的配置文件名称</param>
	void AssertConfigurationIsValid(string profileName);

	/// <summary>
	/// 创建类型间的映射规则
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="memberList">成员映射规则</param>
	/// <returns>映射配置表达式</returns>
	IMappingExpression<S, T> CreateMap<S, T>(MemberList memberList = MemberList.Destination);

	/// <summary>
	/// 添加类型间的映射规则
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="memberList">成员映射规则</param>
	/// <returns>映射配置表达式</returns>
	IMappingExpression CreateMap(Type sourceType, Type targetType, MemberList memberList = MemberList.Destination);

	/// <summary>
	/// 创建映射配置
	/// </summary>
	/// <param name="profileName">映射配置名称</param>
	/// <returns>映射配置表达式</returns>
	IProfileExpression CreateProfile(string profileName);

	/// <summary>
	/// 创建映射配置
	/// </summary>
	/// <param name="profileName">映射配置名称</param>
	/// <param name="profileConfiguring">映射配置表达式设置方法</param>
	void CreateProfile(string profileName, Action<IProfileExpression> profileConfiguring);

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	T DynamicMap<T>(object source);

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	T DynamicMap<S, T>(S source);

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	void DynamicMap<S, T>(S source, T target);

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源对象类型</param>
	/// <param name="targetType">映射的目标对象类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	object DynamicMap(object source, Type sourceType, Type targetType);

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	void DynamicMap(object source, object target, Type sourceType, Type targetType);

	/// <summary>
	/// 查找类型映射定义
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <returns>类型映射定义对象</returns>
	TypeMap FindTypeMapFor<S, T>();

	/// <summary>
	/// 查找类型映射定义
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>类型映射定义对象</returns>
	TypeMap FindTypeMapFor(Type sourceType, Type targetType);

	/// <summary>
	/// 获取全部类型映射定义
	/// </summary>
	/// <returns>类型映射定义对象数组</returns>
	TypeMap[] GetAllTypeMaps();

	/// <summary>
	/// 检测两个类型之间是否已经存在通过 <see cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap``2(AutoMapper.MemberList)" /> 方法建立的映射逻辑
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <returns>如果已经定义了两个类型之间的映射返回true，否则返回false</returns>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool HasMap<S, T>();

	/// <summary>
	/// 检测两个类型之间是否已经存在通过 <see cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" /> 方法建立的映射逻辑        
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>如果已经定义了两个类型之间的映射返回true，否则返回false</returns>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool HasMap(Type sourceType, Type targetType);

	/// <summary>
	/// 检测源类型是否可以映射到目标类型。是否已经定义类型间映射规则，或者存在指定的两个类型间的 AutoMapper 默认映射器。
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <returns>如果源类型可以映射到目标类型返回true，否则返回false。</returns>
	/// <remarks>
	/// 如果已经通过 <see cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap``2(AutoMapper.MemberList)" /> 方法建立 <typeparamref name="S" /> 和 <typeparamref name="T" /> 这两种类型之间映射关系，
	/// 或者 <typeparamref name="S" /> 和 <typeparamref name="T" /> 这两种类型之间存在 AutoMapper 支持的默认转换，则返回 true；否则返回 false。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool IsMappable<S, T>();

	/// <summary>
	/// 检测源类型是否可以映射到目标类型。是否已经定义类型间映射规则，或者存在指定的两个类型间的 AutoMapper 默认映射器。
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>如果源类型可以映射到目标类型返回true，否则返回false。</returns>
	/// <remarks>
	/// 如果已经通过 <see cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" /> 方法建立 <paramref name="sourceType" /> 和 <paramref name="targetType" /> 这两种类型之间映射关系，
	/// 或者 <paramref name="sourceType" /> 和 <paramref name="targetType" /> 这两种类型之间存在 AutoMapper 支持的默认转换，则返回 true；否则返回 false。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.ITypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool IsMappable(Type sourceType, Type targetType);

	/// <summary>
	/// 初始化数据映射器实例
	/// </summary>
	/// <param name="configuring">初始化动作</param>
	void Initialize(Action<IConfiguration> configuring);

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T Map<T>(object source);

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T Map<S, T>(S source);

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	void Map<S, T>(S source, T target);

	/// <summary>
	/// 把源对象映射为目标对象
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	object Map(object source, Type sourceType, Type targetType);

	/// <summary>
	/// 把源对象映射为目标对象
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	void Map(object source, object target, Type sourceType, Type targetType);

	/// <summary>
	/// 重置数据映射器实例
	/// </summary>
	void Reset();

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T StaticMap<T>(object source, Action<IMappingOperationOptions> opts = null);

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T StaticMap<S, T>(S source, Action<IMappingOperationOptions> opts = null);

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="opts">映射参数对象</param>
	void StaticMap<S, T>(S source, T target, Action<IMappingOperationOptions> opts = null);

	/// <summary>
	/// 根据创建的映射定义，把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	object StaticMap(object source, Type sourceType, Type targetType, Action<IMappingOperationOptions> opts = null);

	/// <summary>
	/// 根据创建的映射定义，把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="opts">映射参数对象</param>
	void StaticMap(object source, object target, Type sourceType, Type targetType, Action<IMappingOperationOptions> opts = null);
}

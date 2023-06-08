using System;
using System.Linq;
using AutoMapper;
using AutoMapper.Mappers;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Mapping;

/// <summary>
/// 基于AutoMapper的类型映射器
/// </summary>
public class TypeMapper : ITypeMapper
{
	/// <summary>
	/// 映射器加载器
	/// </summary>
	private static Lazy<TypeMapper> mapperLoader = new Lazy<TypeMapper>(() => new TypeMapper(), isThreadSafe: true);

	/// <summary>
	/// 映射配置源
	/// </summary>
	private ConfigurationStore configuration;

	/// <summary>
	/// AutoMapper数据映射引擎
	/// </summary>
	private MappingEngine engine;

	/// <summary>
	/// 是否是全局映射器
	/// </summary>
	private bool singletonMode;

	/// <summary>
	/// 获取当前类型映射器
	/// </summary>
	public static ITypeMapper Default => mapperLoader.Value;

	/// <summary>
	/// 获取或者设置是否允许映射的目标对象是否可以包含null
	/// </summary>
	bool ITypeMapper.AllowNullDestinationValues
	{
		get
		{
			return singletonMode ? Mapper.AllowNullDestinationValues : configuration.AllowNullDestinationValues;
		}
		set
		{
			if (singletonMode)
			{
				Mapper.AllowNullDestinationValues = value;
			}
			else
			{
				configuration.AllowNullDestinationValues = value;
			}
		}
	}

	/// <summary>
	/// 获取映射配置对象
	/// </summary>
	IConfiguration ITypeMapper.Configuration => singletonMode ? Mapper.Configuration : configuration;

	/// <summary>
	/// 获取AutoMapper映射处理引擎
	/// </summary>
	IMappingEngine ITypeMapper.Engine => singletonMode ? Mapper.Engine : engine;

	/// <summary>
	/// 创建类型间的映射规则
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="memberList">成员映射规则</param>
	/// <returns>映射配置表达式</returns>
	public static IMappingExpression<S, T> CreateMap<S, T>(MemberList memberList = MemberList.Destination)
	{
		return Default.CreateMap<S, T>(memberList);
	}

	/// <summary>
	/// 添加类型间的映射规则
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="memberList">成员映射规则</param>
	/// <returns>映射配置表达式</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static IMappingExpression CreateMap(Type sourceType, Type targetType, MemberList memberList = MemberList.Destination)
	{
		return Default.CreateMap(sourceType, targetType, memberList);
	}

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	public static T DynamicMap<T>(object source)
	{
		return Default.DynamicMap<T>(source);
	}

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
	public static T DynamicMap<S, T>(S source)
	{
		return Default.DynamicMap<S, T>(source);
	}

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
	public static void DynamicMap<S, T>(S source, T target)
	{
		Default.DynamicMap(source, target);
	}

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源对象类型</param>
	/// <param name="targetType">映射的目标对象类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	public static object DynamicMap(object source, Type sourceType, Type targetType)
	{
		return Default.DynamicMap(source, sourceType, targetType);
	}

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	public static void DynamicMap(object source, object target, Type sourceType, Type targetType)
	{
		Default.DynamicMap(source, target, sourceType, targetType);
	}

	/// <summary>
	/// 检测源类型是否可以映射到目标类型。是否已经定义类型间映射规则，或者存在指定的两个类型间的 AutoMapper 默认映射器。
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <returns>如果源类型可以映射到目标类型返回true，否则返回false。</returns>
	/// <remarks>
	/// 如果已经通过 <see cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" /> 方法建立 <typeparamref name="S" /> 和 <typeparamref name="T" /> 这两种类型之间映射关系，
	/// 或者 <typeparamref name="S" /> 和 <typeparamref name="T" /> 这两种类型之间存在 AutoMapper 支持的默认转换，则返回 true；否则返回 false。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	public static bool IsMappable<S, T>()
	{
		return Default.IsMappable<S, T>();
	}

	/// <summary>
	/// 检测源类型是否可以映射到目标类型。是否已经定义类型间映射规则，或者存在指定的两个类型间的 AutoMapper 默认映射器。
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>如果源类型可以映射到目标类型返回true，否则返回false。</returns>
	/// <remarks>
	/// 如果已经通过 <see cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" /> 方法建立 <paramref name="sourceType" /> 和 <paramref name="targetType" /> 这两种类型之间映射关系，
	/// 或者 <paramref name="sourceType" /> 和 <paramref name="targetType" /> 这两种类型之间存在 AutoMapper 支持的默认转换，则返回 true；否则返回 false。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	public static bool IsMappable(Type sourceType, Type targetType)
	{
		return Default.IsMappable(sourceType, targetType);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	public static T Map<T>(object source)
	{
		return Default.Map<T>(source);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	public static T Map<S, T>(S source)
	{
		return Default.Map<S, T>(source);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	public static void Map<S, T>(S source, T target)
	{
		Default.Map(source, target);
	}

	/// <summary>
	/// 把源对象映射为目标对象
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static object Map(object source, Type sourceType, Type targetType)
	{
		return Default.Map(source, sourceType, targetType);
	}

	/// <summary>
	/// 把源对象映射为目标对象
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static void Map(object source, object target, Type sourceType, Type targetType)
	{
		Default.Map(source, target, sourceType, targetType);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	public static T StaticMap<T>(object source, Action<IMappingOperationOptions> opts = null)
	{
		return Default.StaticMap<T>(source, opts);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	public static T StaticMap<S, T>(S source, Action<IMappingOperationOptions> opts = null)
	{
		return Default.StaticMap<S, T>(source, opts);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="opts">映射参数对象</param>
	public static void StaticMap<S, T>(S source, T target, Action<IMappingOperationOptions> opts = null)
	{
		Default.StaticMap(source, target, opts);
	}

	/// <summary>
	/// 根据创建的映射定义，把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static object StaticMap(object source, Type sourceType, Type targetType, Action<IMappingOperationOptions> opts = null)
	{
		return Default.StaticMap(source, sourceType, targetType, opts);
	}

	/// <summary>
	/// 根据创建的映射定义，把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="opts">映射参数对象</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static void StaticMap(object source, object target, Type sourceType, Type targetType, Action<IMappingOperationOptions> opts = null)
	{
		Default.StaticMap(source, target, sourceType, targetType, opts);
	}

	/// <summary>
	/// 初始化具有独立映射配置的映射器实例，实例具有独立的映射配置数据
	/// </summary>
	public TypeMapper()
		: this(singletonMode: true)
	{
	}

	/// <summary>
	/// 根据指定模式初始化映射器实例
	/// </summary>
	/// <param name="singletonMode">是否创建单例模式的映射器</param>
	public TypeMapper(bool singletonMode)
	{
		this.singletonMode = singletonMode;
		Initialize();
	}

	/// <summary>
	/// 初始化数据映射器实例
	/// </summary>
	private void Initialize()
	{
		if (singletonMode)
		{
			configuration = null;
			engine = null;
		}
		else
		{
			configuration = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
			engine = new MappingEngine(configuration);
		}
	}

	/// <summary>
	/// 添加全局忽略的属性筛选条件
	/// </summary>
	/// <param name="prefix">需要忽略不处理的成员的名称前缀</param>
	/// <exception cref="T:System.ArgumentNullException">名称前缀 <paramref name="prefix" /> 为空或者空串。</exception>
	void ITypeMapper.AddGlobalIgnore(string prefix)
	{
		prefix.GuardNotNullAndEmpty("prefix");
		if (singletonMode)
		{
			Mapper.AddGlobalIgnore(prefix);
		}
		else
		{
			configuration.AddGlobalIgnore(prefix);
		}
	}

	/// <summary>
	/// 添加映射配置
	/// </summary>
	/// <param name="profile">映射配置对象</param>
	/// <exception cref="T:System.ArgumentNullException">映射配置对象 <paramref name="profile" /> 为空。</exception>
	void ITypeMapper.AddProfile(Profile profile)
	{
		profile.GuardNotNull("profile");
		if (singletonMode)
		{
			Mapper.AddProfile(profile);
		}
		else
		{
			configuration.AddProfile(profile);
		}
	}

	/// <summary>
	/// 添加映射配置
	/// </summary>
	/// <typeparam name="P">映射配置对象类型</typeparam>
	void ITypeMapper.AddProfile<P>()
	{
		if (singletonMode)
		{
			Mapper.AddProfile<P>();
		}
		else
		{
			configuration.AddProfile<P>();
		}
	}

	/// <summary>
	/// 验证映射配置是否有效
	/// </summary>
	void ITypeMapper.AssertConfigurationIsValid()
	{
		if (singletonMode)
		{
			Mapper.AssertConfigurationIsValid();
		}
		else
		{
			configuration.AssertConfigurationIsValid();
		}
	}

	/// <summary>
	/// 验证映射规则是否有效
	/// </summary>
	/// <param name="typeMap">待验证的类型映射规则</param>
	/// <exception cref="T:System.ArgumentNullException">类型映射规则 <paramref name="typeMap" /> 为空。</exception>
	void ITypeMapper.AssertConfigurationIsValid(TypeMap typeMap)
	{
		typeMap.GuardNotNull("type mapping");
		if (singletonMode)
		{
			Mapper.AssertConfigurationIsValid(typeMap);
		}
		else
		{
			configuration.AssertConfigurationIsValid(typeMap);
		}
	}

	/// <summary>
	/// 验证映射配置是否有效
	/// </summary>
	/// <param name="profileName">待验证的配置文件名称</param>
	/// <exception cref="T:System.ArgumentNullException">配置文件名称 <paramref name="profileName" /> 为空。</exception>
	void ITypeMapper.AssertConfigurationIsValid(string profileName)
	{
		profileName.GuardNotNull("profile name");
		if (singletonMode)
		{
			Mapper.AssertConfigurationIsValid(profileName);
		}
		else
		{
			configuration.AssertConfigurationIsValid(profileName);
		}
	}

	/// <summary>
	/// 创建类型间的映射规则
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="memberList">成员映射规则</param>
	/// <returns>映射配置表达式</returns>
	IMappingExpression<S, T> ITypeMapper.CreateMap<S, T>(MemberList memberList)
	{
		if (singletonMode)
		{
			return Mapper.CreateMap<S, T>(memberList);
		}
		return configuration.CreateMap<S, T>(memberList);
	}

	/// <summary>
	/// 添加类型间的映射规则
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="memberList">成员映射规则</param>
	/// <returns>映射配置表达式</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	IMappingExpression ITypeMapper.CreateMap(Type sourceType, Type targetType, MemberList memberList)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		if (singletonMode)
		{
			return Mapper.CreateMap(sourceType, targetType, memberList);
		}
		return configuration.CreateMap(sourceType, targetType, memberList);
	}

	/// <summary>
	/// 创建映射配置
	/// </summary>
	/// <param name="profileName">映射配置名称</param>
	/// <returns>映射配置表达式</returns>
	/// <exception cref="T:System.ArgumentNullException">映射配置名称为空。</exception>
	IProfileExpression ITypeMapper.CreateProfile(string profileName)
	{
		profileName.GuardNotNull("profile name");
		if (singletonMode)
		{
			return Mapper.CreateProfile(profileName);
		}
		return configuration.CreateProfile(profileName);
	}

	/// <summary>
	/// 创建映射配置
	/// </summary>
	/// <param name="profileName">映射配置名称</param>
	/// <param name="profileConfiguring">映射配置表达式设置方法</param>
	/// <exception cref="T:System.ArgumentNullException">映射配置名称 <paramref name="profileName" /> 为空；或者映射配置设置方法 <paramref name="profileConfiguring" /> 为空。</exception>
	void ITypeMapper.CreateProfile(string profileName, Action<IProfileExpression> profileConfiguring)
	{
		profileName.GuardNotNull("profile name");
		profileConfiguring.GuardNotNull("profile configuring");
		if (singletonMode)
		{
			Mapper.CreateProfile(profileName, profileConfiguring);
		}
		else
		{
			configuration.CreateProfile(profileName, profileConfiguring);
		}
	}

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	T ITypeMapper.DynamicMap<T>(object source)
	{
		if (singletonMode)
		{
			return Mapper.DynamicMap<T>(source);
		}
		return engine.DynamicMap<T>(source);
	}

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
	T ITypeMapper.DynamicMap<S, T>(S source)
	{
		if (singletonMode)
		{
			return Mapper.DynamicMap<S, T>(source);
		}
		return engine.DynamicMap<S, T>(source);
	}

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
	void ITypeMapper.DynamicMap<S, T>(S source, T target)
	{
		if (singletonMode)
		{
			Mapper.DynamicMap(source, target);
		}
		else
		{
			engine.DynamicMap(source, target);
		}
	}

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源对象类型</param>
	/// <param name="targetType">映射的目标对象类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	object ITypeMapper.DynamicMap(object source, Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		if (singletonMode)
		{
			return Mapper.DynamicMap(source, sourceType, targetType);
		}
		return engine.DynamicMap(source, sourceType, targetType);
	}

	/// <summary>
	/// 把源对象动态映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>
	/// 如果当前没有定义源类型和目标类型之间的映射规则，则先创建映射规则再进行映射处理。
	/// </remarks>
	void ITypeMapper.DynamicMap(object source, object target, Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		if (singletonMode)
		{
			Mapper.DynamicMap(source, target, sourceType, targetType);
		}
		else
		{
			engine.DynamicMap(source, target, sourceType, targetType);
		}
	}

	/// <summary>
	/// 查找类型映射定义
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <returns>类型映射定义对象</returns>
	TypeMap ITypeMapper.FindTypeMapFor<S, T>()
	{
		return ((ITypeMapper)this).FindTypeMapFor(typeof(S), typeof(T));
	}

	/// <summary>
	/// 查找类型映射定义
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>类型映射定义对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	TypeMap ITypeMapper.FindTypeMapFor(Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		if (singletonMode)
		{
			return Mapper.FindTypeMapFor(sourceType, targetType);
		}
		return configuration.FindTypeMapFor(sourceType, targetType);
	}

	/// <summary>
	/// 获取全部类型映射定义
	/// </summary>
	/// <returns>类型映射定义对象数组</returns>
	TypeMap[] ITypeMapper.GetAllTypeMaps()
	{
		if (singletonMode)
		{
			return Mapper.GetAllTypeMaps();
		}
		return configuration.GetAllTypeMaps();
	}

	/// <summary>
	/// 检测两个类型之间是否已经存在通过 <see cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" /> 方法建立的映射逻辑
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <returns>如果已经定义了两个类型之间的映射返回true，否则返回false</returns>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool ITypeMapper.HasMap<S, T>()
	{
		return ((ITypeMapper)this).HasMap(typeof(S), typeof(T));
	}

	/// <summary>
	/// 检测两个类型之间是否已经存在通过 <see cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" /> 方法建立的映射逻辑        
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>如果已经定义了两个类型之间的映射返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool ITypeMapper.HasMap(Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		if (singletonMode)
		{
			return Mapper.FindTypeMapFor(sourceType, targetType).IsNotNull();
		}
		return configuration.FindTypeMapFor(sourceType, targetType).IsNotNull();
	}

	/// <summary>
	/// 检测源类型是否可以映射到目标类型。是否已经定义类型间映射规则，或者存在指定的两个类型间的 AutoMapper 默认映射器。
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <returns>如果源类型可以映射到目标类型返回true，否则返回false。</returns>
	/// <remarks>
	/// 如果已经通过 <see cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" /> 方法建立 <typeparamref name="S" /> 和 <typeparamref name="T" /> 这两种类型之间映射关系，
	/// 或者 <typeparamref name="S" /> 和 <typeparamref name="T" /> 这两种类型之间存在 AutoMapper 支持的默认转换，则返回 true；否则返回 false。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool ITypeMapper.IsMappable<S, T>()
	{
		return ((ITypeMapper)this).IsMappable(typeof(S), typeof(T));
	}

	/// <summary>
	/// 检测源类型是否可以映射到目标类型。是否已经定义类型间映射规则，或者存在指定的两个类型间的 AutoMapper 默认映射器。
	/// </summary>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>如果源类型可以映射到目标类型返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>
	/// 如果已经通过 <see cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" /> 方法建立 <paramref name="sourceType" /> 和 <paramref name="targetType" /> 这两种类型之间映射关系，
	/// 或者 <paramref name="sourceType" /> 和 <paramref name="targetType" /> 这两种类型之间存在 AutoMapper 支持的默认转换，则返回 true；否则返回 false。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap``2(AutoMapper.MemberList)" />
	/// <seealso cref="M:Richfit.Garnet.Common.Mapping.TypeMapper.CreateMap(System.Type,System.Type,AutoMapper.MemberList)" />
	bool ITypeMapper.IsMappable(Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		TypeMap typeMap;
		IObjectMapper mapper;
		if (singletonMode)
		{
			typeMap = Mapper.FindTypeMapFor(sourceType, targetType);
			ResolutionContext context2 = new ResolutionContext(typeMap, sourceType.CreateDefault(), sourceType, targetType, new MappingOperationOptions());
			mapper = Mapper.Configuration.As<IConfigurationProvider>().GetMappers().FirstOrDefault((IObjectMapper m) => m.IsMatch(context2));
			return mapper.IsNotNull();
		}
		typeMap = configuration.FindTypeMapFor(sourceType, targetType);
		ResolutionContext context = new ResolutionContext(typeMap, sourceType.CreateDefault(), sourceType, targetType, new MappingOperationOptions());
		mapper = configuration.GetMappers().FirstOrDefault((IObjectMapper m) => m.IsMatch(context));
		return mapper.IsNotNull();
	}

	/// <summary>
	/// 初始化数据映射器实例
	/// </summary>
	/// <param name="configuring">初始化动作</param>
	/// <exception cref="T:System.ArgumentNullException">初始化动作为空。</exception>
	void ITypeMapper.Initialize(Action<IConfiguration> configuring)
	{
		configuring.GuardNotNull("Configuring");
		if (singletonMode)
		{
			Mapper.Initialize(configuring);
			return;
		}
		((ITypeMapper)this).Reset();
		configuring(configuration);
		configuration.Seal();
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T ITypeMapper.Map<T>(object source)
	{
		if (((ITypeMapper)this).IsMappable(source.IsNull() ? typeof(object) : source.GetType(), typeof(T)))
		{
			return ((ITypeMapper)this).StaticMap<T>(source, (Action<IMappingOperationOptions>)null);
		}
		return ((ITypeMapper)this).DynamicMap<T>(source);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T ITypeMapper.Map<S, T>(S source)
	{
		if (((ITypeMapper)this).IsMappable<S, T>())
		{
			return ((ITypeMapper)this).StaticMap<S, T>(source, (Action<IMappingOperationOptions>)null);
		}
		return ((ITypeMapper)this).DynamicMap<S, T>(source);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	void ITypeMapper.Map<S, T>(S source, T target)
	{
		if (((ITypeMapper)this).IsMappable<S, T>())
		{
			((ITypeMapper)this).StaticMap(source, target, (Action<IMappingOperationOptions>)null);
		}
		else
		{
			((ITypeMapper)this).DynamicMap(source, target);
		}
	}

	/// <summary>
	/// 把源对象映射为目标对象
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <returns>映射生成的目标类型对象</returns>
	object ITypeMapper.Map(object source, Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		if (((ITypeMapper)this).IsMappable(sourceType, targetType))
		{
			return ((ITypeMapper)this).StaticMap(source, sourceType, targetType, (Action<IMappingOperationOptions>)null);
		}
		return ((ITypeMapper)this).DynamicMap(source, sourceType, targetType);
	}

	/// <summary>
	/// 把源对象映射为目标对象
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	void ITypeMapper.Map(object source, object target, Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		if (((ITypeMapper)this).IsMappable(sourceType, targetType))
		{
			((ITypeMapper)this).StaticMap(source, target, sourceType, targetType, (Action<IMappingOperationOptions>)null);
		}
		else
		{
			((ITypeMapper)this).DynamicMap(source, target, sourceType, targetType);
		}
	}

	/// <summary>
	/// 重置数据映射器实例
	/// </summary>
	void ITypeMapper.Reset()
	{
		if (singletonMode)
		{
			Mapper.Reset();
		}
		else
		{
			Initialize();
		}
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T ITypeMapper.StaticMap<T>(object source, Action<IMappingOperationOptions> opts)
	{
		opts = opts.IfNull(delegate
		{
		});
		if (singletonMode)
		{
			return Mapper.Map<T>(source, opts);
		}
		return engine.Map<T>(source, opts);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="opts">映射参数对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	T ITypeMapper.StaticMap<S, T>(S source, Action<IMappingOperationOptions> opts)
	{
		opts = opts.IfNull(delegate
		{
		});
		if (singletonMode)
		{
			return Mapper.Map<S, T>(source, opts);
		}
		return engine.Map<S, T>(source, opts);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="opts">映射参数对象</param>
	void ITypeMapper.StaticMap<S, T>(S source, T target, Action<IMappingOperationOptions> opts)
	{
		opts = opts.IfNull(delegate
		{
		});
		if (singletonMode)
		{
			Mapper.Map(source, target, opts);
		}
		else
		{
			engine.Map(source, target, opts);
		}
	}

	/// <summary>
	/// 根据创建的映射定义，把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="opts">映射参数对象</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <returns>映射生成的目标类型对象</returns>
	object ITypeMapper.StaticMap(object source, Type sourceType, Type targetType, Action<IMappingOperationOptions> opts)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		opts = opts.IfNull(delegate
		{
		});
		if (singletonMode)
		{
			return Mapper.Map(source, sourceType, targetType, opts);
		}
		return engine.Map(source, sourceType, targetType, opts);
	}

	/// <summary>
	/// 根据创建的映射定义，把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <param name="opts">映射参数对象</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	void ITypeMapper.StaticMap(object source, object target, Type sourceType, Type targetType, Action<IMappingOperationOptions> opts)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		opts = opts.IfNull(delegate
		{
		});
		if (singletonMode)
		{
			Mapper.Map(source, target, sourceType, targetType, opts);
		}
		else
		{
			engine.Map(source, target, sourceType, targetType, opts);
		}
	}
}

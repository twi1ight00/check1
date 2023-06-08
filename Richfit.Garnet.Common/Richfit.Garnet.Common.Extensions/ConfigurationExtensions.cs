using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Configuration.Configuration" /> 对象扩展方法
/// </summary>
public static class ConfigurationExtensions
{
	/// <summary>
	/// 枚举当前配置源中的全部配置节，包括配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中的全部配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<ConfigurationSection> AllSections(this Configuration config)
	{
		return config.AllSections<ConfigurationSection>();
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节，包括配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">枚举的配置节类型</param>
	/// <returns>当前配置源中指定类型的配置节的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空</exception>
	public static IEnumerable<ConfigurationSection> AllSections(this Configuration config, Type sectionType)
	{
		config.GuardNotNull("config");
		sectionType.GuardNotNull("section type");
		return config.Sections(sectionType).Concat(config.SectionGroups().SelectMany((ConfigurationSectionGroup g) => g.AllSections(sectionType)));
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的全部配置节，包括配置节组中的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<T> AllSections<T>(this Configuration config) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		return config.Sections<T>().Concat(config.SectionGroups().SelectMany((ConfigurationSectionGroup g) => g.AllSections<T>()));
	}

	/// <summary>
	/// 枚举当前配置节组中的全部配置节，包括子配置节组中的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<ConfigurationSection> AllSections(this ConfigurationSectionGroup group)
	{
		return group.AllSections<ConfigurationSection>();
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的全部配置节，包括子配置节组中的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="sectionType">枚举的配置节类型</param>
	/// <returns>当前配置节组的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSection> AllSections(this ConfigurationSectionGroup group, Type sectionType)
	{
		group.GuardNotNull("group");
		sectionType.GuardNotNull("section type");
		return group.Sections(sectionType).Concat(group.SectionGroups().SelectMany((ConfigurationSectionGroup g) => g.AllSections(sectionType)));
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的全部配置节，包括配置节组中的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组的指定类型的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<T> AllSections<T>(this ConfigurationSectionGroup group) where T : ConfigurationSection
	{
		group.GuardNotNull("group");
		return group.Sections<T>().Concat(group.SectionGroups().SelectMany((ConfigurationSectionGroup g) => g.AllSections<T>()));
	}

	/// <summary>
	/// 检测当前配置源中是否包含指定类型的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">筛选配置节类型</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含指定类型的配置节，返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置源类型 <paramref name="sectionType" /> 为空。</exception>
	public static bool ContainsSection(this Configuration config, Type sectionType, bool includeGroup = false)
	{
		config.GuardNotNull("config");
		sectionType.GuardNotNull("section type");
		if (includeGroup)
		{
			return config.AllSections(sectionType).Any();
		}
		return config.Sections(sectionType).Any();
	}

	/// <summary>
	/// 检测当前配置源中是否包含与给定名称匹配的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionName">匹配配置节名称</param>
	/// <param name="ignoreCase">配置节名称是否区分大小写</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含与给定名称匹配的配置节返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节名称 <paramref name="sectionName" /> 为空。</exception>
	public static bool ContainsSection(this Configuration config, string sectionName, bool ignoreCase = false, bool includeGroup = false)
	{
		config.GuardNotNull("config");
		sectionName.GuardNotNull("section name");
		if (includeGroup)
		{
			return (from s in config.AllSections()
				where s.SectionInformation.SectionName.EqualOrdinal(sectionName, ignoreCase)
				select s).Any();
		}
		return (from s in config.Sections()
			where s.SectionInformation.SectionName.EqualOrdinal(sectionName, ignoreCase)
			select s).Any();
	}

	/// <summary>
	/// 检测当前配置源中是否包含满足条件的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含满足条件的配置节返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsSection(this Configuration config, Func<ConfigurationSection, bool> predicate, bool includeGroup = false)
	{
		config.GuardNotNull("config");
		predicate.GuardNotNull("predicate");
		if (includeGroup)
		{
			return config.AllSections().Where(predicate).Any();
		}
		return config.Sections().Where(predicate).Any();
	}

	/// <summary>
	/// 检测当前配置源中是否包含指定类型的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含指定类型的配置节返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static bool ContainsSection<T>(this Configuration config, bool includeGroup = false) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		if (includeGroup)
		{
			return config.AllSections<T>().Any();
		}
		return config.Sections<T>().Any();
	}

	/// <summary>
	/// 检测当前配置源中是否包含与给定名称匹配的指定类型的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionName">匹配的配置节名称</param>
	/// <param name="ignoreCase">配置节名称是否区分大小写</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含具有匹配名称的指定类型的配置节返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节名称 <paramref name="sectionName" /> 为空。</exception>
	public static bool ContainsSection<T>(this Configuration config, string sectionName, bool ignoreCase = false, bool includeGroup = false) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		sectionName.GuardNotNull("section name");
		if (includeGroup)
		{
			return (from s in config.AllSections<T>()
				where s.SectionInformation.SectionName.EqualOrdinal(sectionName, ignoreCase)
				select s).Any();
		}
		return (from s in config.Sections<T>()
			where s.SectionInformation.SectionName.EqualOrdinal(sectionName, ignoreCase)
			select s).Any();
	}

	/// <summary>
	/// 检测当前配置源中是否包含满足指定条件的指定类型的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含具有匹配名称的指定类型的配置节返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool ContainsSection<T>(this Configuration config, Func<T, bool> predicate, bool includeGroup = false) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		predicate.GuardNotNull("predicate");
		if (includeGroup)
		{
			return config.AllSections<T>().Where(predicate).Any();
		}
		return config.Sections<T>().Where(predicate).Any();
	}

	/// <summary>
	/// 获取当前配置源中定义的全部配置节，包括各个配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>配置源中定义的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static ConfigurationSection[] GetAllSections(this Configuration config)
	{
		return config.GetAllSections<ConfigurationSection>();
	}

	/// <summary>
	/// 获取当前配置源中符合条件的全部配置节，包括各个配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>配置源中符合条件的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection[] GetAllSections(this Configuration config, Func<ConfigurationSection, bool> predicate)
	{
		return config.GetAllSections<ConfigurationSection>(predicate);
	}

	/// <summary>
	/// 获取当前配置源中定义的指定类型的全部配置节，包括各个配置节组中的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>配置源中定义的指定类型的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static T[] GetAllSections<T>(this Configuration config) where T : ConfigurationSection
	{
		return config.AllSections<T>().ToArray();
	}

	/// <summary>
	/// 获取当前配置源中满足筛选条件的指定类型的全部配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>配置源中满足筛选条件的指定类型的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetAllSections<T>(this Configuration config, Func<T, bool> predicate) where T : ConfigurationSection
	{
		return config.AllSections<T>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前配置节组中定义的全部配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中定义的全部配置节，包括各个子配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static ConfigurationSection[] GetAllSections(this ConfigurationSectionGroup group)
	{
		return group.GetAllSections<ConfigurationSection>();
	}

	/// <summary>
	/// 获取当前配置节组中符合筛选条件的指定类型的配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置节组中符合筛选条件的指定类型的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection[] GetAllSections(this ConfigurationSectionGroup group, Func<ConfigurationSection, bool> predicate)
	{
		return group.GetAllSections<ConfigurationSection>(predicate);
	}

	/// <summary>
	/// 获取当前配置节组中定义的指定类型的全部配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中定义的指定类型的全部配置节，包括各个子配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static T[] GetAllSections<T>(this ConfigurationSectionGroup group) where T : ConfigurationSection
	{
		return group.AllSections<T>().ToArray();
	}

	/// <summary>
	/// 获取当前配置节组中符合筛选条件的指定类型的配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置节组中符合筛选条件的指定类型的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetAllSections<T>(this ConfigurationSectionGroup group, Func<T, bool> predicate) where T : ConfigurationSection
	{
		group.GuardNotNull("group");
		predicate.GuardNotNull("predicate");
		return group.AllSections<T>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前配置源中的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中的第一个配置节，如果当前配置源不包含配置节返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static ConfigurationSection GetFirstSection(this Configuration config)
	{
		config.GuardNotNull("config");
		return config.Sections().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中指定类型的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">获取的配置节类型</param>
	/// <returns>当前配置源中指定类型的第一个配置节；如果没有指定类型的配置节返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static ConfigurationSection GetFirstSection(this Configuration config, Type sectionType)
	{
		config.GuardNotNull("config");
		sectionType.GuardNotNull("section type");
		return config.Sections(sectionType).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中指定类型的第一个配置节
	/// </summary>
	/// <typeparam name="T">获取的配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的第一个配置节；如果没有指定类型的配置节返回空。</returns>
	public static T GetFirstSection<T>(this Configuration config) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		return config.Sections<T>().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中与指定名称匹配的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionName">配置节名称</param>
	/// <param name="ignoreCase">配置节名称是否忽略大小写</param>
	/// <returns>返回找到的第一个配置节，如果未找到返回空</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节名称 <paramref name="sectionName" /> 为空。</exception>
	public static ConfigurationSection GetSection(this Configuration config, string sectionName, bool ignoreCase = false)
	{
		return config.GetSection<ConfigurationSection>(sectionName, ignoreCase);
	}

	/// <summary>
	/// 获取当前配置源中指定类型并与指定名称匹配的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">获取的配置节类型</param>
	/// <param name="sectionName">配置节名称</param>
	/// <param name="ignoreCase">配置节名称是否忽略大小写</param>
	/// <returns>回找到的第一个配置节，如果未找到返回空</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节类型 <paramref name="sectionType" /> 为空；或者配置节名称 <paramref name="sectionName" /> 为空。</exception>
	public static ConfigurationSection GetSection(this Configuration config, Type sectionType, string sectionName, bool ignoreCase = false)
	{
		sectionName = sectionName.Replace('\\', '/');
		return config.AllSections(sectionType).FirstOrDefault((ConfigurationSection s) => s.SectionInformation.SectionName.EqualOrdinal(sectionName, ignoreCase));
	}

	/// <summary>
	/// 获取当前配置源中满足指定条件的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置源中满足指定条件的第一个配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空，或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection GetSection(this Configuration config, Func<ConfigurationSection, bool> predicate)
	{
		config.GuardNotNull("config");
		predicate.GuardNotNull("predicate");
		return config.AllSections().Where(predicate).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中指定类型和节名称的第一个配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionName">配置节名称</param>
	/// <param name="ignoreCase">配置节名称是否忽略大小写</param>
	/// <returns>返回找到的第一个配置节，如果未找到返回空</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空，或者配置节名称 <paramref name="sectionName" /> 为空。</exception>
	public static T GetSection<T>(this Configuration config, string sectionName, bool ignoreCase = false) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		sectionName.GuardNotNull("section name");
		if (ignoreCase)
		{
			sectionName = sectionName.Replace('\\', '/');
			return config.AllSections<T>().FirstOrDefault((T s) => s.SectionInformation.SectionName.EqualOrdinal(sectionName, ignoreCase));
		}
		return (T)config.GetSection(sectionName);
	}

	/// <summary>
	/// 获取当前配置源中满足指定条件的第一个配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置源中满足指定条件的第一个配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空，或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T GetSection<T>(this Configuration config, Func<T, bool> predicate) where T : ConfigurationSection
	{
		return config.AllSections<T>().Where(predicate).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中所有配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中所有的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static ConfigurationSection[] GetSections(this Configuration config)
	{
		return config.GetSections<ConfigurationSection>();
	}

	/// <summary>
	/// 获取当前配置源中符合条件的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置源中符合条件的配置节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection[] GetSections(this Configuration config, Func<ConfigurationSection, bool> predicate)
	{
		return config.GetSections<ConfigurationSection>(predicate);
	}

	/// <summary>
	/// 获取当前配置源中指定类型的所有配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的配置节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static T[] GetSections<T>(this Configuration config) where T : ConfigurationSection
	{
		return config.Sections<T>().ToArray();
	}

	/// <summary>
	/// 获取当前配置源中满足条件的所有配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置源中符合条件的配置节数组</returns>
	public static T[] GetSections<T>(this Configuration config, Func<T, bool> predicate) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		predicate.GuardNotNull("predicate");
		return config.Sections<T>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 枚举当前配置源中的配置节组
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中的配置节组序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(this Configuration config)
	{
		return config.SectionGroups<ConfigurationSectionGroup>();
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节组
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="groupType">枚举的配置节组类型</param>
	/// <returns>当前配置源中指定类型的配置节组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节组类型 <paramref name="groupType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(this Configuration config, Type groupType)
	{
		config.GuardNotNull("config");
		groupType.GuardNotNull("group type");
		return from g in config.SectionGroups()
			where groupType.IsAssignableFrom(g.GetType())
			select g;
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节组
	/// </summary>
	/// <typeparam name="T">枚举的配置节组类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的配置节组序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<T> SectionGroups<T>(this Configuration config) where T : ConfigurationSectionGroup
	{
		config.GuardNotNull("config");
		return config.SectionGroups.OfType<T>();
	}

	/// <summary>
	/// 枚举当前配置节组中的配置节组
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中的配置节组序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(this ConfigurationSectionGroup group)
	{
		return group.SectionGroups<ConfigurationSectionGroup>();
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的配置节组
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="groupType">枚举的配置节组类型</param>
	/// <returns>当前配置节组中指定类型的配置节组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节组类型 <paramref name="groupType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(this ConfigurationSectionGroup group, Type groupType)
	{
		group.GuardNotNull("group");
		groupType.GuardNotNull("group type");
		return from g in @group.SectionGroups()
			where groupType.IsAssignableFrom(g.GetType())
			select g;
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的配置节组
	/// </summary>
	/// <typeparam name="T">枚举的配置节组类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中指定类型的配置节组序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<T> SectionGroups<T>(this ConfigurationSectionGroup group) where T : ConfigurationSectionGroup
	{
		group.GuardNotNull("section group");
		return group.SectionGroups.OfType<T>();
	}

	/// <summary>
	/// 枚举当前配置源中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(this Configuration config)
	{
		return config.Sections<ConfigurationSection>();
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">枚举的配置节的类型</param>
	/// <returns>当前配置源中指定类型的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(this Configuration config, Type sectionType)
	{
		config.GuardNotNull("config");
		sectionType.GuardNotNull("section type");
		return from s in config.Sections()
			where sectionType.IsAssignableFrom(s.GetType())
			select s;
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<T> Sections<T>(this Configuration config) where T : ConfigurationSection
	{
		config.GuardNotNull("config");
		return config.Sections.OfType<T>();
	}

	/// <summary>
	/// 枚举当前配置节组中的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(this ConfigurationSectionGroup group)
	{
		return group.Sections<ConfigurationSection>();
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="sectionType">枚举的配置节类型</param>
	/// <returns>当前配置节组中指定类型的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(this ConfigurationSectionGroup group, Type sectionType)
	{
		group.GuardNotNull("group");
		sectionType.GuardNotNull("section type");
		return from s in @group.Sections()
			where sectionType.IsAssignableFrom(s.GetType())
			select s;
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中指定类型的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<T> Sections<T>(this ConfigurationSectionGroup group) where T : ConfigurationSection
	{
		group.GuardNotNull("group");
		return group.Sections.OfType<T>();
	}
}

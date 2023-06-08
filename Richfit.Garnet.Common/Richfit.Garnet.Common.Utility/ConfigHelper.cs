#define DEBUG
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 配置辅助类
/// </summary>
public static class ConfigHelper
{
	/// <summary>
	/// 枚举当前配置源中的全部配置节，包括配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中的全部配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<ConfigurationSection> AllSections(Configuration config)
	{
		return AllSections<ConfigurationSection>(config);
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节，包括配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">枚举的配置节类型</param>
	/// <returns>当前配置源中指定类型的配置节的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空</exception>
	public static IEnumerable<ConfigurationSection> AllSections(Configuration config, Type sectionType)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(sectionType, "section type");
		return Sections(config, sectionType).Concat(SectionGroups(config).SelectMany((ConfigurationSectionGroup g) => AllSections(g, sectionType)));
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的全部配置节，包括配置节组中的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<T> AllSections<T>(Configuration config) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		return Sections<T>(config).Concat(SectionGroups(config).SelectMany((ConfigurationSectionGroup g) => AllSections<T>(g)));
	}

	/// <summary>
	/// 枚举当前配置节组中的全部配置节，包括子配置节组中的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<ConfigurationSection> AllSections(ConfigurationSectionGroup group)
	{
		return AllSections<ConfigurationSection>(group);
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的全部配置节，包括子配置节组中的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="sectionType">枚举的配置节类型</param>
	/// <returns>当前配置节组的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSection> AllSections(ConfigurationSectionGroup group, Type sectionType)
	{
		Guard.AssertNotNull(group, "group");
		Guard.AssertNotNull(sectionType, "section type");
		return Sections(group, sectionType).Concat(SectionGroups(group).SelectMany((ConfigurationSectionGroup g) => AllSections(g, sectionType)));
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的全部配置节，包括配置节组中的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组的指定类型的全部配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<T> AllSections<T>(ConfigurationSectionGroup group) where T : ConfigurationSection
	{
		Guard.AssertNotNull(group, "group");
		return Sections<T>(group).Concat(SectionGroups(group).SelectMany((ConfigurationSectionGroup g) => AllSections<T>(g)));
	}

	/// <summary>
	/// 检测当前配置源中是否包含指定类型的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">筛选配置节类型</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含指定类型的配置节，返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置源类型 <paramref name="sectionType" /> 为空。</exception>
	public static bool ContainsSection(Configuration config, Type sectionType, bool includeGroup = false)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(sectionType, "section type");
		if (includeGroup)
		{
			return AllSections(config, sectionType).Any();
		}
		return Sections(config, sectionType).Any();
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
	public static bool ContainsSection(Configuration config, string sectionName, bool ignoreCase = false, bool includeGroup = false)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(sectionName, "section name");
		if (includeGroup)
		{
			return (from s in AllSections(config)
				where TextHelper.EqualOrdinal(s.SectionInformation.SectionName, sectionName, ignoreCase)
				select s).Any();
		}
		return (from s in Sections(config)
			where TextHelper.EqualOrdinal(s.SectionInformation.SectionName, sectionName, ignoreCase)
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
	public static bool ContainsSection(Configuration config, Func<ConfigurationSection, bool> predicate, bool includeGroup = false)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(predicate, "predicate");
		if (includeGroup)
		{
			return AllSections(config).Where(predicate).Any();
		}
		return Sections(config).Where(predicate).Any();
	}

	/// <summary>
	/// 检测当前配置源中是否包含指定类型的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="includeGroup">是否遍历配置源中的配置节组</param>
	/// <returns>如果包含指定类型的配置节返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static bool ContainsSection<T>(Configuration config, bool includeGroup = false) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		if (includeGroup)
		{
			return AllSections<T>(config).Any();
		}
		return Sections<T>(config).Any();
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
	public static bool ContainsSection<T>(Configuration config, string sectionName, bool ignoreCase = false, bool includeGroup = false) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(sectionName, "section name");
		if (includeGroup)
		{
			return (from s in AllSections<T>(config)
				where TextHelper.EqualOrdinal(s.SectionInformation.SectionName, sectionName, ignoreCase)
				select s).Any();
		}
		return (from s in Sections<T>(config)
			where TextHelper.EqualOrdinal(s.SectionInformation.SectionName, sectionName, ignoreCase)
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
	public static bool ContainsSection<T>(Configuration config, Func<T, bool> predicate, bool includeGroup = false) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(predicate, "predicate");
		if (includeGroup)
		{
			return AllSections<T>(config).Where(predicate).Any();
		}
		return Sections<T>(config).Where(predicate).Any();
	}

	/// <summary>
	/// 获取当前配置源中定义的全部配置节，包括各个配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>配置源中定义的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static ConfigurationSection[] GetAllSections(Configuration config)
	{
		return GetAllSections<ConfigurationSection>(config);
	}

	/// <summary>
	/// 获取当前配置源中符合条件的全部配置节，包括各个配置节组中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>配置源中符合条件的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection[] GetAllSections(Configuration config, Func<ConfigurationSection, bool> predicate)
	{
		return ConfigHelper.GetAllSections<ConfigurationSection>(config, predicate);
	}

	/// <summary>
	/// 获取当前配置源中定义的指定类型的全部配置节，包括各个配置节组中的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>配置源中定义的指定类型的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static T[] GetAllSections<T>(Configuration config) where T : ConfigurationSection
	{
		return AllSections<T>(config).ToArray();
	}

	/// <summary>
	/// 获取当前配置源中满足筛选条件的指定类型的全部配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>配置源中满足筛选条件的指定类型的全部配置节，包括各个配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetAllSections<T>(Configuration config, Func<T, bool> predicate) where T : ConfigurationSection
	{
		return AllSections<T>(config).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前配置节组中定义的全部配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中定义的全部配置节，包括各个子配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static ConfigurationSection[] GetAllSections(ConfigurationSectionGroup group)
	{
		return GetAllSections<ConfigurationSection>(group);
	}

	/// <summary>
	/// 获取当前配置节组中符合筛选条件的指定类型的配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置节组中符合筛选条件的指定类型的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection[] GetAllSections(ConfigurationSectionGroup group, Func<ConfigurationSection, bool> predicate)
	{
		return ConfigHelper.GetAllSections<ConfigurationSection>(group, predicate);
	}

	/// <summary>
	/// 获取当前配置节组中定义的指定类型的全部配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中定义的指定类型的全部配置节，包括各个子配置节组中定义的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static T[] GetAllSections<T>(ConfigurationSectionGroup group) where T : ConfigurationSection
	{
		return AllSections<T>(group).ToArray();
	}

	/// <summary>
	/// 获取当前配置节组中符合筛选条件的指定类型的配置节，包括各个子配置节组中定义的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="group">当前配置节组</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置节组中符合筛选条件的指定类型的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetAllSections<T>(ConfigurationSectionGroup group, Func<T, bool> predicate) where T : ConfigurationSection
	{
		Guard.AssertNotNull(group, "group");
		Guard.AssertNotNull(predicate, "predicate");
		return AllSections<T>(group).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前配置源中的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中的第一个配置节，如果当前配置源不包含配置节返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static ConfigurationSection GetFirstSection(Configuration config)
	{
		Guard.AssertNotNull(config, "config");
		return Sections(config).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中指定类型的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">获取的配置节类型</param>
	/// <returns>当前配置源中指定类型的第一个配置节；如果没有指定类型的配置节返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static ConfigurationSection GetFirstSection(Configuration config, Type sectionType)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(sectionType, "section type");
		return Sections(config, sectionType).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中指定类型的第一个配置节
	/// </summary>
	/// <typeparam name="T">获取的配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的第一个配置节；如果没有指定类型的配置节返回空。</returns>
	public static T GetFirstSection<T>(Configuration config) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		return Sections<T>(config).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中与指定名称匹配的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionName">配置节名称</param>
	/// <param name="ignoreCase">配置节名称是否忽略大小写</param>
	/// <returns>返回找到的第一个配置节，如果未找到返回空</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节名称 <paramref name="sectionName" /> 为空。</exception>
	public static ConfigurationSection GetSection(Configuration config, string sectionName, bool ignoreCase = false)
	{
		return GetSection<ConfigurationSection>(config, sectionName, ignoreCase);
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
	public static ConfigurationSection GetSection(Configuration config, Type sectionType, string sectionName, bool ignoreCase = false)
	{
		sectionName = sectionName.Replace('\\', '/');
		return AllSections(config, sectionType).FirstOrDefault((ConfigurationSection s) => TextHelper.EqualOrdinal(s.SectionInformation.SectionName, sectionName, ignoreCase));
	}

	/// <summary>
	/// 获取当前配置源中满足指定条件的第一个配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置源中满足指定条件的第一个配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空，或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection GetSection(Configuration config, Func<ConfigurationSection, bool> predicate)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(predicate, "predicate");
		return AllSections(config).Where(predicate).FirstOrDefault();
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
	public static T GetSection<T>(Configuration config, string sectionName, bool ignoreCase = false) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(sectionName, "section name");
		if (ignoreCase)
		{
			sectionName = sectionName.Replace('\\', '/');
			return AllSections<T>(config).FirstOrDefault((T s) => TextHelper.EqualOrdinal(s.SectionInformation.SectionName, sectionName, ignoreCase));
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
	public static T GetSection<T>(Configuration config, Func<T, bool> predicate) where T : ConfigurationSection
	{
		return AllSections<T>(config).Where(predicate).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前配置源中所有配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中所有的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static ConfigurationSection[] GetSections(Configuration config)
	{
		return GetSections<ConfigurationSection>(config);
	}

	/// <summary>
	/// 获取当前配置源中符合条件的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置源中符合条件的配置节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者配置节筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConfigurationSection[] GetSections(Configuration config, Func<ConfigurationSection, bool> predicate)
	{
		return ConfigHelper.GetSections<ConfigurationSection>(config, predicate);
	}

	/// <summary>
	/// 获取当前配置源中指定类型的所有配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中指定类型的配置节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static T[] GetSections<T>(Configuration config) where T : ConfigurationSection
	{
		return Sections<T>(config).ToArray();
	}

	/// <summary>
	/// 获取当前配置源中满足条件的所有配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="config">当前配置源</param>
	/// <param name="predicate">配置节筛选条件</param>
	/// <returns>当前配置源中符合条件的配置节数组</returns>
	public static T[] GetSections<T>(Configuration config, Func<T, bool> predicate) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(predicate, "predicate");
		return Sections<T>(config).Where(predicate).ToArray();
	}

	/// <summary>
	/// 枚举当前配置源中的配置节组
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源中的配置节组序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(Configuration config)
	{
		return SectionGroups<ConfigurationSectionGroup>(config);
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节组
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="groupType">枚举的配置节组类型</param>
	/// <returns>当前配置源中指定类型的配置节组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节组类型 <paramref name="groupType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(Configuration config, Type groupType)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(groupType, "group type");
		return from g in SectionGroups(config)
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
	public static IEnumerable<T> SectionGroups<T>(Configuration config) where T : ConfigurationSectionGroup
	{
		Guard.AssertNotNull(config, "config");
		return config.SectionGroups.OfType<T>();
	}

	/// <summary>
	/// 枚举当前配置节组中的配置节组
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中的配置节组序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(ConfigurationSectionGroup group)
	{
		return SectionGroups<ConfigurationSectionGroup>(group);
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的配置节组
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="groupType">枚举的配置节组类型</param>
	/// <returns>当前配置节组中指定类型的配置节组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节组类型 <paramref name="groupType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSectionGroup> SectionGroups(ConfigurationSectionGroup group, Type groupType)
	{
		Guard.AssertNotNull(group, "group");
		Guard.AssertNotNull(groupType, "group type");
		return from g in SectionGroups(@group)
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
	public static IEnumerable<T> SectionGroups<T>(ConfigurationSectionGroup group) where T : ConfigurationSectionGroup
	{
		Guard.AssertNotNull(group, "section group");
		return group.SectionGroups.OfType<T>();
	}

	/// <summary>
	/// 枚举当前配置源中的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <returns>当前配置源的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(Configuration config)
	{
		return Sections<ConfigurationSection>(config);
	}

	/// <summary>
	/// 枚举当前配置源中指定类型的配置节
	/// </summary>
	/// <param name="config">当前配置源</param>
	/// <param name="sectionType">枚举的配置节的类型</param>
	/// <returns>当前配置源中指定类型的配置节</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置源为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(Configuration config, Type sectionType)
	{
		Guard.AssertNotNull(config, "config");
		Guard.AssertNotNull(sectionType, "section type");
		return from s in Sections(config)
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
	public static IEnumerable<T> Sections<T>(Configuration config) where T : ConfigurationSection
	{
		Guard.AssertNotNull(config, "config");
		return config.Sections.OfType<T>();
	}

	/// <summary>
	/// 枚举当前配置节组中的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <returns>当前配置节组中的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(ConfigurationSectionGroup group)
	{
		return Sections<ConfigurationSection>(group);
	}

	/// <summary>
	/// 枚举当前配置节组中指定类型的配置节
	/// </summary>
	/// <param name="group">当前配置节组</param>
	/// <param name="sectionType">枚举的配置节类型</param>
	/// <returns>当前配置节组中指定类型的配置节序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前配置节组为空；或者枚举的配置节类型 <paramref name="sectionType" /> 为空。</exception>
	public static IEnumerable<ConfigurationSection> Sections(ConfigurationSectionGroup group, Type sectionType)
	{
		Guard.AssertNotNull(group, "group");
		Guard.AssertNotNull(sectionType, "section type");
		return from s in Sections(@group)
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
	public static IEnumerable<T> Sections<T>(ConfigurationSectionGroup group) where T : ConfigurationSection
	{
		Guard.AssertNotNull(group, "group");
		return group.Sections.OfType<T>();
	}
}

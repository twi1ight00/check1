using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;

namespace Richfit.Garnet.Common.LDAP;

/// <summary>
/// AD帮助类
/// </summary>
public class Directory : IDisposable
{
	/// <summary>
	/// 目录路径
	/// </summary>
	private string path = string.Empty;

	/// <summary>
	/// 用户名
	/// </summary>
	private string userName = string.Empty;

	/// <summary>
	/// 用户密码
	/// </summary>
	private string password = string.Empty;

	/// <summary>
	/// 目录项目实体
	/// </summary>
	private DirectoryEntry entry = null;

	/// <summary>
	/// 查询表达式
	/// </summary>
	private string query = string.Empty;

	/// <summary>
	/// 目录搜索器
	/// </summary>
	private DirectorySearcher searcher = null;

	/// <summary>
	/// 排序表达式
	/// </summary>
	private string sortBy = string.Empty;

	/// <summary>
	/// 服务器AD路径
	/// </summary>
	public virtual string Path
	{
		get
		{
			return path;
		}
		set
		{
			path = value;
			if (entry != null)
			{
				entry.Close();
				entry.Dispose();
				entry = null;
			}
			if (searcher != null)
			{
				searcher.Dispose();
				searcher = null;
			}
			entry = new DirectoryEntry(path, userName, password, AuthenticationTypes.Secure);
			searcher = new DirectorySearcher(entry);
			searcher.Filter = Query;
			searcher.PageSize = 1000;
		}
	}

	/// <summary>
	/// 登陆用户名
	/// </summary>
	public virtual string UserName
	{
		get
		{
			return userName;
		}
		set
		{
			userName = value;
			if (entry != null)
			{
				entry.Close();
				entry.Dispose();
				entry = null;
			}
			if (searcher != null)
			{
				searcher.Dispose();
				searcher = null;
			}
			entry = new DirectoryEntry(path, userName, password, AuthenticationTypes.Secure);
			searcher = new DirectorySearcher(entry);
			searcher.Filter = Query;
			searcher.PageSize = 1000;
		}
	}

	/// <summary>
	/// 登陆密码
	/// </summary>
	public virtual string Password
	{
		get
		{
			return password;
		}
		set
		{
			password = value;
			if (entry != null)
			{
				entry.Close();
				entry.Dispose();
				entry = null;
			}
			if (searcher != null)
			{
				searcher.Dispose();
				searcher = null;
			}
			entry = new DirectoryEntry(path, userName, password, AuthenticationTypes.Secure);
			searcher = new DirectorySearcher(entry);
			searcher.Filter = Query;
			searcher.PageSize = 1000;
		}
	}

	/// <summary>
	/// 查询条件
	/// </summary>
	public virtual string Query
	{
		get
		{
			return query;
		}
		set
		{
			query = value;
			searcher.Filter = query;
		}
	}

	/// <summary>
	/// 信息排序的属性
	/// </summary>
	public virtual string SortBy
	{
		get
		{
			return sortBy;
		}
		set
		{
			sortBy = value;
			searcher.Sort.PropertyName = sortBy;
			searcher.Sort.Direction = SortDirection.Ascending;
		}
	}

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="query">目录查询条件</param>
	/// <param name="userName">登陆用户名</param>
	/// <param name="password">登陆密码</param>
	/// <param name="path">LDAP server的路径</param>
	public Directory(string query, string userName, string password, string path)
	{
		entry = new DirectoryEntry(path, userName, password, AuthenticationTypes.Secure);
		Path = path;
		UserName = userName;
		Password = password;
		Query = query;
		searcher = new DirectorySearcher(entry);
		searcher.Filter = query;
		searcher.PageSize = 1000;
	}

	/// <summary>
	/// 检测用户是否认证
	/// </summary>
	/// <returns>true if they were authenticated properly, false otherwise</returns>
	public virtual bool Authenticate()
	{
		try
		{
			if (!entry.Guid.ToString().ToLower().Trim()
				.Equals(string.Empty))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	/// <summary>
	/// 关闭目录对象对象并释放与此组件关联的任何系统资源。
	/// </summary>
	public virtual void Close()
	{
		entry.Close();
	}

	/// <summary>
	/// 查询组成员列表
	/// </summary>
	/// <param name="groupName">The group's name</param>
	/// <returns>A list of the members</returns>
	public virtual List<Entry> FindActiveGroupMembers(string groupName)
	{
		try
		{
			List<Entry> entries = FindGroups("cn=" + groupName);
			return (entries.Count < 1) ? new List<Entry>() : FindActiveUsersAndGroups("memberOf=" + entries[0].DistinguishedName);
		}
		catch
		{
			return new List<Entry>();
		}
	}

	/// <summary>
	/// 查询所有活跃的组
	/// </summary>
	/// <param name="filter">Filter used to modify the query</param>
	/// <param name="args">Additional arguments (used in string formatting</param>
	/// <returns>A list of all active groups' entries</returns>
	public virtual List<Entry> FindActiveGroups(string filter, params object[] args)
	{
		filter = string.Format(filter, args);
		filter = $"(&((userAccountControl:1.2.840.113556.1.4.803:=512)(!(userAccountControl:1.2.840.113556.1.4.803:=2))(!(cn=*$)))({filter}))";
		return FindGroups(filter);
	}

	/// <summary>
	/// 查询所有活跃的用户
	/// </summary>
	/// <param name="filter">Filter used to modify the query</param>
	/// <param name="args">Additional arguments (used in string formatting</param>
	/// <returns>A list of all active users' entries</returns>
	public virtual List<Entry> FindActiveUsers(string filter, params object[] args)
	{
		filter = string.Format(filter, args);
		filter = $"(&((userAccountControl:1.2.840.113556.1.4.803:=512)(!(userAccountControl:1.2.840.113556.1.4.803:=2))(!(cn=*$)))({filter}))";
		return FindUsers(filter);
	}

	/// <summary>
	/// 查询所有活跃的组和用户
	/// </summary>
	/// <param name="filter">Filter used to modify the query</param>
	/// <param name="args">Additional arguments (used in string formatting</param>
	/// <returns>A list of all active groups' entries</returns>
	public virtual List<Entry> FindActiveUsersAndGroups(string filter, params object[] args)
	{
		filter = string.Format(filter, args);
		filter = $"(&((userAccountControl:1.2.840.113556.1.4.803:=512)(!(userAccountControl:1.2.840.113556.1.4.803:=2))(!(cn=*$)))({filter}))";
		return FindUsersAndGroups(filter);
	}

	/// <summary>
	/// 查询返回所有满足条件的信息
	/// </summary>
	/// <returns>A list of all entries that match the query</returns>
	public virtual List<Entry> FindAll()
	{
		List<Entry> returnedResults = new List<Entry>();
		using (SearchResultCollection results = searcher.FindAll())
		{
			foreach (SearchResult result in results)
			{
				returnedResults.Add(new Entry(result.GetDirectoryEntry()));
			}
		}
		return returnedResults;
	}

	/// <summary>
	/// 查询所有的computer信息
	/// </summary>
	/// <param name="filter">Filter used to modify the query</param>
	/// <param name="args">Additional arguments (used in string formatting</param>
	/// <returns>A list of all computers meeting the specified Filter</returns>
	public virtual List<Entry> FindComputers(string filter, params object[] args)
	{
		filter = string.Format(filter, args);
		filter = $"(&(objectClass=computer)({filter}))";
		searcher.Filter = filter;
		return FindAll();
	}

	/// <summary>
	/// 查询所有的组（包含DISABLED和ACTIVE）
	/// </summary>
	/// <param name="filter">filter used to modify the query</param>
	/// <param name="args">Additional arguments (used in string formatting</param>
	/// <returns>A list of all groups meeting the specified Filter</returns>
	public virtual List<Entry> FindGroups(string filter, params object[] args)
	{
		filter = string.Format(filter, args);
		filter = $"(&(objectClass=Group)(objectCategory=Group)({filter}))";
		searcher.Filter = filter;
		return FindAll();
	}

	/// <summary>
	/// 查询一个满足条件的实体
	/// </summary>
	/// <returns>A single entry matching the query</returns>
	public virtual Entry FindOne()
	{
		return new Entry(searcher.FindOne().GetDirectoryEntry());
	}

	/// <summary>
	/// 查询所有的用户和组（（包含DISABLED和ACTIVE））
	/// </summary>
	/// <param name="filter">Filter used to modify the query</param>
	/// <param name="args">Additional arguments (used in string formatting</param>
	/// <returns>A list of all users and groups meeting the specified Filter</returns>
	public virtual List<Entry> FindUsersAndGroups(string filter, params object[] args)
	{
		filter = string.Format(filter, args);
		filter = $"(&(|(&(objectClass=Group)(objectCategory=Group))(&(objectClass=User)(objectCategory=Person)))({filter}))";
		searcher.Filter = filter;
		return FindAll();
	}

	/// <summary>
	/// 通过用户名查找账户信息
	/// </summary>
	/// <param name="userName">User name to search by</param>
	/// <returns>The user's entry</returns>
	public virtual Entry FindUserByUserName(string userName)
	{
		if (string.IsNullOrEmpty(userName))
		{
			throw new ArgumentNullException("UserName");
		}
		return FindUsers("samAccountName=" + userName).FirstOrDefault();
	}

	/// <summary>
	/// 根据过滤条件查找所有AD用户（包含DISABLED和ACTIVE）
	/// </summary>
	/// <param name="filter">Filter used to modify the query</param>
	/// <param name="args">Additional arguments (used in string formatting</param>
	/// <returns>A list of all users meeting the specified Filter</returns>
	public virtual List<Entry> FindUsers(string filter, params object[] args)
	{
		filter = string.Format(filter, args);
		filter = $"(&(objectClass=User)(objectCategory=Person)({filter}))";
		searcher.Filter = filter;
		return FindAll();
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public void Dispose()
	{
		if (entry != null)
		{
			entry.Close();
			entry.Dispose();
			entry = null;
		}
		if (searcher != null)
		{
			searcher.Dispose();
			searcher = null;
		}
	}
}

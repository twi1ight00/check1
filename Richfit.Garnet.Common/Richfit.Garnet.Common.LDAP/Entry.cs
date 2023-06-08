using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace Richfit.Garnet.Common.LDAP;

/// <summary>
/// AD目录条目封装类
/// </summary>
public class Entry : IDisposable
{
	/// <summary>
	/// Actual base directory entry
	/// </summary>
	public virtual DirectoryEntry DirectoryEntry { get; set; }

	/// <summary>
	/// 邮箱属性
	/// </summary>
	public virtual string Email
	{
		get
		{
			return (string)GetValue("mail");
		}
		set
		{
			SetValue("mail", value);
		}
	}

	/// <summary>
	/// distinguished name property for this entry
	/// </summary>
	public virtual string DistinguishedName
	{
		get
		{
			return (string)GetValue("distinguishedname");
		}
		set
		{
			SetValue("distinguishedname", value);
		}
	}

	/// <summary>
	/// country code property for this entry
	/// </summary>
	public virtual string CountryCode
	{
		get
		{
			return (string)GetValue("countrycode");
		}
		set
		{
			SetValue("countrycode", value);
		}
	}

	/// <summary>
	/// company property for this entry
	/// </summary>
	public virtual string Company
	{
		get
		{
			return (string)GetValue("company");
		}
		set
		{
			SetValue("company", value);
		}
	}

	/// <summary>
	/// MemberOf property for this entry
	/// </summary>
	public virtual List<string> MemberOf
	{
		get
		{
			List<string> values = new List<string>();
			PropertyValueCollection collection = DirectoryEntry.Properties["memberof"];
			foreach (object item in collection)
			{
				values.Add((string)item);
			}
			return values;
		}
	}

	/// <summary>
	/// display name property for this entry
	/// </summary>
	public virtual string DisplayName
	{
		get
		{
			return (string)GetValue("displayname");
		}
		set
		{
			SetValue("displayname", value);
		}
	}

	/// <summary>
	/// initials property for this entry
	/// </summary>
	public virtual string Initials
	{
		get
		{
			return (string)GetValue("initials");
		}
		set
		{
			SetValue("initials", value);
		}
	}

	/// <summary>
	/// title property for this entry
	/// </summary>
	public virtual string Title
	{
		get
		{
			return (string)GetValue("title");
		}
		set
		{
			SetValue("title", value);
		}
	}

	/// <summary>
	/// samaccountname property for this entry
	/// </summary>
	public virtual string SamAccountName
	{
		get
		{
			return (string)GetValue("samaccountname");
		}
		set
		{
			SetValue("samaccountname", value);
		}
	}

	/// <summary>
	/// givenname property for this entry
	/// </summary>
	public virtual string GivenName
	{
		get
		{
			return (string)GetValue("givenname");
		}
		set
		{
			SetValue("givenname", value);
		}
	}

	/// <summary>
	/// cn property for this entry
	/// </summary>
	public virtual string CN
	{
		get
		{
			return (string)GetValue("cn");
		}
		set
		{
			SetValue("cn", value);
		}
	}

	/// <summary>
	/// name property for this entry
	/// </summary>
	public virtual string Name
	{
		get
		{
			return (string)GetValue("name");
		}
		set
		{
			SetValue("name", value);
		}
	}

	/// <summary>
	/// office property for this entry
	/// </summary>
	public virtual string Office
	{
		get
		{
			return (string)GetValue("physicaldeliveryofficename");
		}
		set
		{
			SetValue("physicaldeliveryofficename", value);
		}
	}

	/// <summary>
	/// telephone number property for this entry
	/// </summary>
	public virtual string TelephoneNumber
	{
		get
		{
			return (string)GetValue("telephonenumber");
		}
		set
		{
			SetValue("telephonenumber", value);
		}
	}

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="directoryEntry">Directory entry for the item</param>
	public Entry(DirectoryEntry directoryEntry)
	{
		DirectoryEntry = directoryEntry;
	}

	/// <summary>
	/// 保存条目属性的修改
	/// </summary>
	public virtual void Save()
	{
		if (DirectoryEntry == null)
		{
			throw new NullReferenceException("DirectoryEntry shouldn't be null");
		}
		DirectoryEntry.CommitChanges();
	}

	/// <summary>
	/// 获得条目属性的值
	/// </summary>
	/// <param name="property">Property you want the information about</param>
	/// <returns>an object containing the property's information</returns>
	public virtual object GetValue(string property)
	{
		return DirectoryEntry.Properties[property]?.Value;
	}

	/// <summary>
	/// 获得条目属性(集合)的某个索引的值
	/// </summary>
	/// <param name="property">Property you want the information about</param>
	/// <param name="index">Index of the property to return</param>
	/// <returns>an object containing the property's information</returns>
	public virtual object GetValue(string property, int index)
	{
		return DirectoryEntry.Properties[property]?[index];
	}

	/// <summary>
	/// 给某条目属性赋值
	/// </summary>
	/// <param name="property">Property of the entry to set</param>
	/// <param name="value">Value to set the property to</param>
	public virtual void SetValue(string property, object value)
	{
		PropertyValueCollection collection = DirectoryEntry.Properties[property];
		if (collection != null)
		{
			collection.Value = value;
		}
	}

	/// <summary>
	/// 给某条目属性（集合）的某索引赋值
	/// </summary>
	/// <param name="property">Property of the entry to set</param>
	/// <param name="index">Index of the property to set</param>
	/// <param name="value">Value to set the property to</param>
	public virtual void SetValue(string property, int index, object value)
	{
		PropertyValueCollection collection = DirectoryEntry.Properties[property];
		if (collection != null)
		{
			collection[index] = value;
		}
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public void Dispose()
	{
		if (DirectoryEntry != null)
		{
			DirectoryEntry.Dispose();
			DirectoryEntry = null;
		}
	}
}

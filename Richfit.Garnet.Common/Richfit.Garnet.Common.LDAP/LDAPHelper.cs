using System;

namespace Richfit.Garnet.Common.LDAP;

/// <summary>
/// LDAP静态帮助类
/// </summary>
public static class LDAPHelper
{
	/// <summary>
	///  LDAP认证用户是否通过
	/// </summary>
	/// <param name="server">AD服务器域名或者IP地址</param>
	/// <param name="userAccount">用户帐号</param>
	/// <param name="password">用户密码</param>
	/// <returns>认证通过返回true，否则false</returns>
	public static bool AuthenticateUser(string server, string userAccount, string password)
	{
		string path = "LDAP://" + server;
		using Directory directory = new Directory(string.Empty, userAccount, password, path);
		return directory.Authenticate();
	}

	/// <summary>
	/// 获得某用户的AD属相的值
	/// </summary>
	/// <param name="server">AD服务器域名或者IP地址</param>
	/// <param name="commonAccount">认证的公共帐号</param>
	/// <param name="commonPassword">认证的公共帐号密码</param>
	/// <param name="userAccount">用户的帐号</param>
	/// <param name="property">AD属性：如：DisplayName etc</param>
	/// <returns>属性值</returns>
	public static object GetUserProperty(string server, string commonAccount, string commonPassword, string userAccount, string property)
	{
		string path = "LDAP://" + server;
		using Directory directory = new Directory(string.Empty, commonAccount, commonPassword, path);
		using Entry entry = directory.FindUserByUserName(userAccount);
		return entry?.GetValue(property);
	}

	/// <summary>
	/// 检查某用户在AD中是否存在
	/// </summary>
	/// <param name="server"></param>
	/// <param name="commonAccount"></param>
	/// <param name="commonPassword"></param>
	/// <param name="userAccount"></param>
	/// <returns></returns>
	public static bool UserExists(string server, string commonAccount, string commonPassword, string userAccount)
	{
		string path = "LDAP://" + server;
		using Directory directory = new Directory(string.Empty, commonAccount, commonPassword, path);
		Entry entry = null;
		try
		{
			entry = directory.FindUserByUserName(userAccount);
			return entry != null;
		}
		catch (Exception)
		{
			return false;
		}
		finally
		{
			entry?.Dispose();
		}
	}

	/// <summary>
	/// 修改用户AD密码，此方法要求修改的密码通过AD服务器密码设置安全性检测，如不满足会报错
	/// </summary>
	/// <param name="server">AD服务器域名或者IP地址</param>
	/// <param name="userAccount">用户的帐号</param>
	/// <param name="oldPassword">用户的帐号就密码</param>
	/// <param name="newPassword">用户的帐号新密码</param>
	public static void ChangePassword(string server, string userAccount, string oldPassword, string newPassword)
	{
		string path = "LDAP://" + server;
		using Directory directory = new Directory(string.Empty, userAccount, oldPassword, path);
		using Entry entry = directory.FindUserByUserName(userAccount);
		entry.DirectoryEntry.Invoke("ChangePassword", oldPassword, newPassword);
		entry.Save();
	}
}

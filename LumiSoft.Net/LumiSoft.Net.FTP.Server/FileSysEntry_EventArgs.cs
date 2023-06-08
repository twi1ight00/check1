using System;
using System.Data;
using System.IO;

namespace LumiSoft.Net.FTP.Server;

public class FileSysEntry_EventArgs
{
	private FTP_Session m_pSession = null;

	private string m_Name = "";

	private string m_NewName = "";

	private bool m_Validated = true;

	private Stream m_FileStream = null;

	private DataSet m_DsDirInfo = null;

	public FTP_Session Session => m_pSession;

	public string Name => m_Name;

	public string NewName => m_NewName;

	public Stream FileStream
	{
		get
		{
			return m_FileStream;
		}
		set
		{
			m_FileStream = value;
		}
	}

	public bool Validated
	{
		get
		{
			return m_Validated;
		}
		set
		{
			m_Validated = value;
		}
	}

	public DataSet DirInfo => m_DsDirInfo;

	public FileSysEntry_EventArgs(FTP_Session session, string name, string newName)
	{
		m_Name = name;
		m_NewName = newName;
		m_DsDirInfo = new DataSet();
		DataTable dataTable = m_DsDirInfo.Tables.Add("DirInfo");
		dataTable.Columns.Add("Name");
		dataTable.Columns.Add("Date", typeof(DateTime));
		dataTable.Columns.Add("Size", typeof(long));
		dataTable.Columns.Add("IsDirectory", typeof(bool));
	}
}

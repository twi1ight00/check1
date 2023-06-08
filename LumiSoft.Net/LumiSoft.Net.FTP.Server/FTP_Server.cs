using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace LumiSoft.Net.FTP.Server;

public class FTP_Server : SocketServer<FTP_Session>
{
	public event ValidateIPHandler ValidateIPAddress = null;

	public event AuthUserEventHandler AuthUser = null;

	public event FileSysEntryEventHandler GetDirInfo = null;

	public event FileSysEntryEventHandler DirExists = null;

	public event FileSysEntryEventHandler CreateDir = null;

	public event FileSysEntryEventHandler DeleteDir = null;

	public event FileSysEntryEventHandler FileExists = null;

	public event FileSysEntryEventHandler StoreFile = null;

	public event FileSysEntryEventHandler GetFile = null;

	public event FileSysEntryEventHandler DeleteFile = null;

	public event FileSysEntryEventHandler RenameDirFile = null;

	public event LogEventHandler SessionLog = null;

	public FTP_Server()
	{
		base.BindInfo = new BindInfo[1]
		{
			new BindInfo(IPAddress.Any, 21, ssl: false, null)
		};
	}

	protected override void InitNewSession(Socket socket, BindInfo bindInfo)
	{
		SocketLogger logWriter = new SocketLogger(socket, this.SessionLog);
		FTP_Session fTP_Session = new FTP_Session(socket, this, Guid.NewGuid().ToString(), logWriter);
	}

	internal virtual bool OnValidate_IpAddress(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
	{
		ValidateIP_EventArgs validateIP_EventArgs = new ValidateIP_EventArgs(localEndPoint, remoteEndPoint);
		if (this.ValidateIPAddress != null)
		{
			this.ValidateIPAddress(this, validateIP_EventArgs);
		}
		return validateIP_EventArgs.Validated;
	}

	internal virtual bool OnAuthUser(FTP_Session session, string userName, string passwData, string data, AuthType authType)
	{
		AuthUser_EventArgs authUser_EventArgs = new AuthUser_EventArgs(session, userName, passwData, data, authType);
		if (this.AuthUser != null)
		{
			this.AuthUser(this, authUser_EventArgs);
		}
		return authUser_EventArgs.Validated;
	}

	internal FileSysEntry_EventArgs OnGetDirInfo(FTP_Session session, string dir)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, dir, "");
		if (this.GetDirInfo != null)
		{
			this.GetDirInfo(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs;
	}

	internal bool OnDirExists(FTP_Session session, string dir)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, dir, "");
		if (this.DirExists != null)
		{
			this.DirExists(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.Validated;
	}

	internal bool OnCreateDir(FTP_Session session, string dir)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, dir, "");
		if (this.CreateDir != null)
		{
			this.CreateDir(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.Validated;
	}

	internal bool OnDeleteDir(FTP_Session session, string dir)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, dir, "");
		if (this.DeleteDir != null)
		{
			this.DeleteDir(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.Validated;
	}

	internal bool OnRenameDirFile(FTP_Session session, string from, string to)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, from, to);
		if (this.RenameDirFile != null)
		{
			this.RenameDirFile(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.Validated;
	}

	internal bool OnFileExists(FTP_Session session, string file)
	{
		file = file.Substring(0, file.Length - 1);
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, file, "");
		if (this.FileExists != null)
		{
			this.FileExists(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.Validated;
	}

	internal Stream OnGetFile(FTP_Session session, string file)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, file, "");
		if (this.GetFile != null)
		{
			this.GetFile(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.FileStream;
	}

	internal Stream OnStoreFile(FTP_Session session, string file)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, file, "");
		if (this.StoreFile != null)
		{
			this.StoreFile(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.FileStream;
	}

	internal bool OnDeleteFile(FTP_Session session, string file)
	{
		FileSysEntry_EventArgs fileSysEntry_EventArgs = new FileSysEntry_EventArgs(session, file, "");
		if (this.DeleteFile != null)
		{
			this.DeleteFile(this, fileSysEntry_EventArgs);
		}
		return fileSysEntry_EventArgs.Validated;
	}
}

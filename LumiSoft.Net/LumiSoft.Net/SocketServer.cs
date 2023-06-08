using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace LumiSoft.Net;

public class SocketServer<T> : Component
{
	private struct QueuedConnection
	{
		private Socket m_pSocket;

		private BindInfo m_pBindInfo;

		public Socket Socket => m_pSocket;

		public BindInfo BindInfo => m_pBindInfo;

		public QueuedConnection(Socket socket, BindInfo bindInfo)
		{
			m_pSocket = socket;
			m_pBindInfo = bindInfo;
		}
	}

	private Hashtable m_pSessions = null;

	private Queue<QueuedConnection> m_pQueuedConnections = null;

	private bool m_Running = false;

	private System.Timers.Timer m_pTimer = null;

	private BindInfo[] m_pBindInfo = null;

	private string m_HostName = "";

	private int m_SessionIdleTimeOut = 30000;

	private int m_MaxConnections = 1000;

	private int m_MaxBadCommands = 8;

	private bool m_LogCmds = false;

	[Obsolete("Use property BindInfo instead !", true)]
	public IPEndPoint IPEndPoint
	{
		get
		{
			return new IPEndPoint(BindInfo[0].IP, BindInfo[0].Port);
		}
		set
		{
			BindInfo = new BindInfo[1]
			{
				new BindInfo(value.Address, value.Port, ssl: false, null)
			};
		}
	}

	public BindInfo[] BindInfo
	{
		get
		{
			return m_pBindInfo;
		}
		set
		{
			if (value == null)
			{
				throw new NullReferenceException("BindInfo can't be null !");
			}
			bool flag = false;
			if (m_pBindInfo.Length != value.Length)
			{
				flag = true;
			}
			else
			{
				for (int i = 0; i < m_pBindInfo.Length; i++)
				{
					if (!m_pBindInfo[i].IP.Equals(value[i].IP))
					{
						flag = true;
					}
					else if (!m_pBindInfo[i].Port.Equals(value[i].Port))
					{
						flag = true;
					}
					else if (!m_pBindInfo[i].SSL.Equals(value[i].SSL))
					{
						flag = true;
					}
					else if (m_pBindInfo[i].SSL_Certificate == null && value[i].SSL_Certificate != null)
					{
						flag = true;
					}
					else if (value[i].SSL_Certificate == null && m_pBindInfo[i].SSL_Certificate != null)
					{
						flag = true;
					}
					else if ((m_pBindInfo[i].SSL_Certificate != null || value[i].SSL_Certificate != null) && !m_pBindInfo[i].SSL_Certificate.Equals(value[i].SSL_Certificate))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				bool running = m_Running;
				if (running)
				{
					StopServer();
				}
				m_pBindInfo = value;
				if (running)
				{
					StartServer();
				}
			}
		}
	}

	public int MaxConnections
	{
		get
		{
			return m_MaxConnections;
		}
		set
		{
			m_MaxConnections = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return m_Running;
		}
		set
		{
			if ((value != m_Running) & !base.DesignMode)
			{
				if (value)
				{
					StartServer();
				}
				else
				{
					StopServer();
				}
			}
		}
	}

	public bool LogCommands
	{
		get
		{
			return m_LogCmds;
		}
		set
		{
			m_LogCmds = value;
		}
	}

	public int SessionIdleTimeOut
	{
		get
		{
			return m_SessionIdleTimeOut;
		}
		set
		{
			m_SessionIdleTimeOut = value;
		}
	}

	public int MaxBadCommands
	{
		get
		{
			return m_MaxBadCommands;
		}
		set
		{
			m_MaxBadCommands = value;
		}
	}

	public string HostName
	{
		get
		{
			return m_HostName;
		}
		set
		{
			if (value.Length > 0)
			{
				m_HostName = value;
			}
		}
	}

	public Hashtable Sessions => m_pSessions;

	public event ErrorEventHandler SysError = null;

	public SocketServer()
	{
		m_pSessions = new Hashtable();
		m_pQueuedConnections = new Queue<QueuedConnection>();
		m_pTimer = new System.Timers.Timer(15000.0);
		m_pBindInfo = new BindInfo[1]
		{
			new BindInfo(IPAddress.Any, 10000, ssl: false, null)
		};
		m_HostName = System.Net.Dns.GetHostName();
		m_pTimer.AutoReset = true;
		m_pTimer.Elapsed += m_pTimer_Elapsed;
	}

	public new void Dispose()
	{
		base.Dispose();
		StopServer();
	}

	public void StartServer()
	{
		if (!m_Running)
		{
			m_Running = true;
			Thread thread = new Thread(StartProcCons);
			thread.Start();
			Thread thread2 = new Thread(StartProcQueuedCons);
			thread2.Start();
			m_pTimer.Enabled = true;
		}
	}

	public void StopServer()
	{
		if (!m_Running)
		{
			return;
		}
		m_Running = false;
		BindInfo[] pBindInfo = m_pBindInfo;
		foreach (BindInfo bindInfo in pBindInfo)
		{
			if (bindInfo.Tag != null)
			{
				((Socket)bindInfo.Tag).Close();
				bindInfo.Tag = null;
			}
		}
		Thread.Sleep(100);
	}

	private void StartProcCons()
	{
		try
		{
			CircleCollection<BindInfo> circleCollection = new CircleCollection<BindInfo>();
			BindInfo[] pBindInfo = m_pBindInfo;
			foreach (BindInfo bindInfo in pBindInfo)
			{
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Bind(new IPEndPoint(bindInfo.IP, bindInfo.Port));
				socket.Listen(500);
				bindInfo.Tag = socket;
				circleCollection.Add(bindInfo);
			}
			while (m_Running)
			{
				if (m_pSessions.Count > m_MaxConnections)
				{
					while (m_pSessions.Count > m_MaxConnections)
					{
						Thread.Sleep(100);
					}
				}
				BindInfo bindInfo = circleCollection.Next();
				if (m_Running && ((Socket)bindInfo.Tag).Poll(0, SelectMode.SelectRead))
				{
					Socket socket = ((Socket)bindInfo.Tag).Accept();
					lock (m_pQueuedConnections)
					{
						m_pQueuedConnections.Enqueue(new QueuedConnection(socket, bindInfo));
					}
				}
				Thread.Sleep(2);
			}
		}
		catch (SocketException ex)
		{
			if (ex.ErrorCode != 10004)
			{
				OnSysError("WE MUST NEVER REACH HERE !!! StartProcCons:", ex);
			}
		}
		catch (Exception x)
		{
			OnSysError("WE MUST NEVER REACH HERE !!! StartProcCons:", x);
		}
	}

	private void StartProcQueuedCons()
	{
		try
		{
			while (m_Running)
			{
				if (m_pQueuedConnections.Count > 0)
				{
					QueuedConnection queuedConnection;
					lock (m_pQueuedConnections)
					{
						queuedConnection = m_pQueuedConnections.Dequeue();
					}
					try
					{
						InitNewSession(queuedConnection.Socket, queuedConnection.BindInfo);
					}
					catch (Exception x)
					{
						OnSysError("StartProcQueuedCons InitNewSession():", x);
					}
				}
				else
				{
					Thread.Sleep(10);
				}
			}
		}
		catch (Exception x)
		{
			OnSysError("WE MUST NEVER REACH HERE !!! StartProcQueuedCons:", x);
		}
	}

	protected internal void AddSession(object session)
	{
		lock (m_pSessions)
		{
			m_pSessions.Add(session.GetHashCode(), session);
		}
	}

	protected internal void RemoveSession(object session)
	{
		lock (m_pSessions)
		{
			m_pSessions.Remove(session.GetHashCode());
		}
	}

	protected internal void OnSysError(string text, Exception x)
	{
		if (this.SysError != null)
		{
			this.SysError(this, new Error_EventArgs(x, new StackTrace()));
		}
	}

	private void OnSessionTimeoutTimer()
	{
		try
		{
			lock (m_pSessions)
			{
				ISocketServerSession[] array = new ISocketServerSession[m_pSessions.Count];
				m_pSessions.Values.CopyTo(array, 0);
				for (int i = 0; i < array.Length; i++)
				{
					try
					{
						if (DateTime.Now > array[i].SessionLastDataTime.AddMilliseconds(SessionIdleTimeOut))
						{
							array[i].OnSessionTimeout();
						}
					}
					catch (Exception x)
					{
						OnSysError("OnTimer:", x);
					}
				}
			}
		}
		catch (Exception x)
		{
			OnSysError("WE MUST NEVER REACH HERE !!! OnTimer:", x);
		}
	}

	private void m_pTimer_Elapsed(object sender, ElapsedEventArgs e)
	{
		OnSessionTimeoutTimer();
	}

	protected virtual void InitNewSession(Socket socket, BindInfo bindInfo)
	{
	}
}

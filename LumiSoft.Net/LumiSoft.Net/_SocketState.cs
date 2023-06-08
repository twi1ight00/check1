using System.IO;

namespace LumiSoft.Net;

internal class _SocketState
{
	private ReadType m_RecvType;

	private Stream m_pStream = null;

	private string m_RemFromEnd = "";

	private object m_Tag = null;

	private SocketCallBack m_pCallback = null;

	private int m_NextRead = 1;

	private long m_ReadCount = 0L;

	private long m_MaxLength = 1000L;

	private long m_LenthToRead = 0L;

	private byte[] m_RecvBuffer = null;

	private _FixedStack m_pStack = null;

	public _FixedStack Stack => m_pStack;

	public ReadType ReadType => m_RecvType;

	public SocketCallBack Callback => m_pCallback;

	public Stream Stream => m_pStream;

	public string RemFromEnd => m_RemFromEnd;

	public long MaxLength => m_MaxLength;

	public long LenthToRead => m_LenthToRead;

	public byte[] RecvBuffer
	{
		get
		{
			return m_RecvBuffer;
		}
		set
		{
			m_RecvBuffer = value;
		}
	}

	public int NextRead
	{
		get
		{
			return m_NextRead;
		}
		set
		{
			m_NextRead = value;
		}
	}

	public long ReadCount
	{
		get
		{
			return m_ReadCount;
		}
		set
		{
			m_ReadCount = value;
		}
	}

	public object Tag
	{
		get
		{
			return m_Tag;
		}
		set
		{
			m_Tag = value;
		}
	}

	public _SocketState(Stream strm, long maxLength, string terminator, string removeFromEnd, object tag, SocketCallBack callBack)
	{
		m_pStream = strm;
		m_MaxLength = maxLength;
		m_RemFromEnd = removeFromEnd;
		m_Tag = tag;
		m_pCallback = callBack;
		m_pStack = new _FixedStack(terminator);
		m_RecvType = ReadType.Terminator;
	}

	public _SocketState(Stream strm, long lengthToRead, long maxLength, object tag, SocketCallBack callBack)
	{
		m_pStream = strm;
		m_LenthToRead = lengthToRead;
		m_MaxLength = maxLength;
		m_Tag = tag;
		m_pCallback = callBack;
		m_RecvType = ReadType.Length;
	}
}

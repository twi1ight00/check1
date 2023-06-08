using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LumiSoft.Net;

[Obsolete("Use SocketEx instead !")]
public class BufferedSocket
{
	private Socket m_pSocket = null;

	private byte[] m_Buffer = null;

	private long m_BufPos = 0L;

	private bool m_Closed = false;

	private Encoding m_pEncoding = null;

	private SocketLogger m_pLogger = null;

	public Encoding SocketEncoding
	{
		get
		{
			return m_pEncoding;
		}
		set
		{
			m_pEncoding = value;
		}
	}

	public SocketLogger Logger
	{
		get
		{
			return m_pLogger;
		}
		set
		{
			m_pLogger = value;
		}
	}

	internal Socket Socket => m_pSocket;

	internal byte[] Buffer => m_Buffer;

	public int Available => m_Buffer.Length - (int)m_BufPos + m_pSocket.Available;

	public bool Connected => m_pSocket.Connected;

	public bool IsClosed => m_Closed;

	public EndPoint LocalEndPoint => m_pSocket.LocalEndPoint;

	public EndPoint RemoteEndPoint => m_pSocket.RemoteEndPoint;

	public int AvailableInBuffer => m_Buffer.Length - (int)m_BufPos;

	public event EventHandler Activity = null;

	public BufferedSocket(Socket socket)
	{
		m_pSocket = socket;
		m_Buffer = new byte[0];
		m_pEncoding = Encoding.Default;
	}

	public void Connect(EndPoint remoteEP)
	{
		m_pSocket.Connect(remoteEP);
	}

	public IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback callback, object state)
	{
		return m_pSocket.BeginConnect(remoteEP, callback, state);
	}

	public void EndConnect(IAsyncResult asyncResult)
	{
		m_pSocket.EndConnect(asyncResult);
	}

	public int Receive(byte[] buffer)
	{
		if (AvailableInBuffer == 0)
		{
			byte[] array = new byte[10000];
			int num = m_pSocket.Receive(array);
			if (num != array.Length)
			{
				m_Buffer = new byte[num];
				Array.Copy(array, 0, m_Buffer, 0, num);
			}
			else
			{
				m_Buffer = array;
			}
			m_BufPos = 0L;
		}
		return ReceiveFromFuffer(buffer);
	}

	public void BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
	{
		m_pSocket.BeginReceive(buffer, offset, size, socketFlags, callback, state);
	}

	public int EndReceive(IAsyncResult asyncResult)
	{
		return m_pSocket.EndReceive(asyncResult);
	}

	public int Send(byte[] buffer)
	{
		return m_pSocket.Send(buffer);
	}

	public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags)
	{
		return m_pSocket.Send(buffer, offset, size, socketFlags);
	}

	public void SetSocketOption(SocketOptionLevel otpionLevel, SocketOptionName optionName, int optionValue)
	{
		m_pSocket.SetSocketOption(otpionLevel, optionName, optionValue);
	}

	public void Bind(EndPoint localEP)
	{
		m_pSocket.Bind(localEP);
	}

	public void Shutdown(SocketShutdown how)
	{
		m_Closed = true;
		m_pSocket.Shutdown(how);
	}

	public void Close()
	{
		m_Closed = true;
		m_pSocket.Close();
		m_Buffer = new byte[0];
	}

	public int ReceiveFromFuffer(byte[] buffer)
	{
		int availableInBuffer = AvailableInBuffer;
		if (availableInBuffer > buffer.Length)
		{
			Array.Copy(m_Buffer, m_BufPos, buffer, 0L, buffer.Length);
			m_BufPos += buffer.Length;
			return buffer.Length;
		}
		Array.Copy(m_Buffer, m_BufPos, buffer, 0L, availableInBuffer);
		m_Buffer = new byte[0];
		m_BufPos = 0L;
		return availableInBuffer;
	}

	internal void AppendBuffer(byte[] data, int length)
	{
		if (m_Buffer.Length == 0)
		{
			m_Buffer = new byte[length];
			Array.Copy(data, 0, m_Buffer, 0, length);
			return;
		}
		byte[] array = new byte[m_Buffer.Length + length];
		Array.Copy(m_Buffer, 0, array, 0, m_Buffer.Length);
		Array.Copy(data, 0, array, m_Buffer.Length, length);
		m_Buffer = array;
	}

	public string ReadLine()
	{
		return ReadLine(1024L);
	}

	public string ReadLine(long maxLength)
	{
		return ReadLine(maxLength, trim: true);
	}

	public string ReadLine(long maxLength, bool trim)
	{
		using MemoryStream memoryStream = new MemoryStream();
		ReadReplyCode readReplyCode = ReadData(memoryStream, maxLength, "\r\n", "\r\n");
		if (readReplyCode != 0)
		{
			throw new ReadException(readReplyCode, readReplyCode.ToString());
		}
		if (trim)
		{
			return m_pEncoding.GetString(memoryStream.ToArray()).Trim();
		}
		return m_pEncoding.GetString(memoryStream.ToArray());
	}

	public void BeginReadLine(Stream strm, long maxLength, object tag, SocketCallBack callBack)
	{
		BeginReadData(strm, maxLength, "\r\n", "\r\n", tag, callBack);
	}

	public void SendLine(string line)
	{
		if (!line.EndsWith("\r\n"))
		{
			line += "\r\n";
		}
		byte[] bytes = m_pEncoding.GetBytes(line);
		int num = m_pSocket.Send(bytes);
		if (num != bytes.Length)
		{
			throw new Exception("Send error, didn't send all bytes !");
		}
		if (m_pLogger != null)
		{
			m_pLogger.AddSendEntry(line, bytes.Length);
		}
		OnActivity();
	}

	public void BeginSendLine(string line, SocketCallBack callBack)
	{
		BeginSendLine(line, null, callBack);
	}

	public void BeginSendLine(string line, object tag, SocketCallBack callBack)
	{
		if (!line.EndsWith("\r\n"))
		{
			line += "\r\n";
		}
		BeginSendData(new MemoryStream(m_pEncoding.GetBytes(line)), tag, callBack);
	}

	public ReadReplyCode ReadData(Stream storeStream, long maxLength, string terminator, string removeFromEnd)
	{
		if (storeStream == null)
		{
			throw new Exception("Parameter storeStream can't be null !");
		}
		ReadReplyCode readReplyCode = ReadReplyCode.Ok;
		try
		{
			_FixedStack fixedStack = new _FixedStack(terminator);
			long num = 0L;
			int num2 = 1;
			while (num2 > 0)
			{
				byte[] array = new byte[num2];
				int num3 = Receive(array);
				if (num3 > 0)
				{
					num += num3;
					if (num <= maxLength)
					{
						storeStream.Write(array, 0, num3);
					}
					num2 = fixedStack.Push(array, num3);
					OnActivity();
					continue;
				}
				return ReadReplyCode.SocketClosed;
			}
			if (num > maxLength)
			{
				return ReadReplyCode.LengthExceeded;
			}
			if (readReplyCode == ReadReplyCode.Ok && removeFromEnd.Length > 0)
			{
				storeStream.SetLength(storeStream.Length - removeFromEnd.Length);
			}
			if (m_pLogger != null)
			{
				if (storeStream is MemoryStream && storeStream.Length < 200)
				{
					MemoryStream memoryStream = (MemoryStream)storeStream;
					m_pLogger.AddReadEntry(m_pEncoding.GetString(memoryStream.ToArray()), num);
				}
				else
				{
					m_pLogger.AddReadEntry("Big binary, readed " + num + " bytes.", num);
				}
			}
		}
		catch (Exception ex)
		{
			readReplyCode = ReadReplyCode.UnKnownError;
			if (ex is SocketException)
			{
				SocketException ex2 = (SocketException)ex;
				if (ex2.ErrorCode == 10060)
				{
					return ReadReplyCode.TimeOut;
				}
			}
		}
		return readReplyCode;
	}

	public ReadReplyCode ReadData(Stream storeStream, long countToRead, bool storeToStream)
	{
		ReadReplyCode result = ReadReplyCode.Ok;
		try
		{
			long num = 0L;
			while (num < countToRead)
			{
				byte[] buffer = new byte[4000];
				if (countToRead - num < 4000)
				{
					buffer = new byte[countToRead - num];
				}
				int num2 = Receive(buffer);
				if (num2 > 0)
				{
					num += num2;
					if (storeToStream)
					{
						storeStream.Write(buffer, 0, num2);
					}
					OnActivity();
					continue;
				}
				return ReadReplyCode.SocketClosed;
			}
			if (m_pLogger != null)
			{
				m_pLogger.AddReadEntry("Big binary, readed " + num + " bytes.", num);
			}
		}
		catch (Exception ex)
		{
			result = ReadReplyCode.UnKnownError;
			if (ex is SocketException)
			{
				SocketException ex2 = (SocketException)ex;
				if (ex2.ErrorCode == 10060)
				{
					return ReadReplyCode.TimeOut;
				}
			}
		}
		return result;
	}

	public ReadReplyCode ReadData(Stream storeStream, long maxLength)
	{
		try
		{
			byte[] buffer = new byte[4000];
			long num = 0L;
			int num2 = Receive(buffer);
			while (num2 > 0)
			{
				num += num2;
				if (num <= maxLength)
				{
					storeStream.Write(buffer, 0, num2);
				}
				buffer = new byte[4000];
				num2 = Receive(buffer);
				OnActivity();
			}
			if (num > maxLength)
			{
				return ReadReplyCode.LengthExceeded;
			}
			if (m_pLogger != null)
			{
				m_pLogger.AddReadEntry("Big binary, readed " + num + " bytes.", num);
			}
		}
		catch (Exception ex)
		{
			if (ex is SocketException)
			{
				SocketException ex2 = (SocketException)ex;
				if (ex2.ErrorCode == 10060)
				{
					return ReadReplyCode.TimeOut;
				}
			}
			return ReadReplyCode.UnKnownError;
		}
		return ReadReplyCode.Ok;
	}

	public void SendData(string data)
	{
		SendData(new MemoryStream(m_pEncoding.GetBytes(data)));
	}

	public void SendData(byte[] data)
	{
		SendData(new MemoryStream(data));
	}

	public void SendData(Stream dataStream)
	{
		byte[] array = new byte[4000];
		long num = 0L;
		int num2 = dataStream.Read(array, 0, array.Length);
		while (num2 > 0)
		{
			int num3 = m_pSocket.Send(array, num2, SocketFlags.None);
			if (num3 != num2)
			{
				throw new Exception("Send error, didn't send all bytes !");
			}
			num += num2;
			num2 = dataStream.Read(array, 0, array.Length);
			OnActivity();
		}
		if (m_pLogger != null)
		{
			if (dataStream is MemoryStream && dataStream.Length < 200)
			{
				MemoryStream memoryStream = (MemoryStream)dataStream;
				m_pLogger.AddSendEntry(m_pEncoding.GetString(memoryStream.ToArray()), num);
			}
			else
			{
				m_pLogger.AddSendEntry("Big binary, sended " + num + " bytes.", num);
			}
		}
	}

	public void BeginReadData(Stream strm, long maxLength, string terminator, string removeFromEnd, object tag, SocketCallBack callBack)
	{
		_SocketState state = new _SocketState(strm, maxLength, terminator, removeFromEnd, tag, callBack);
		ProccessData_Term(state);
	}

	public void BeginReadData(Stream strm, long lengthToRead, long maxLength, object tag, SocketCallBack callBack)
	{
		_SocketState state = new _SocketState(strm, lengthToRead, maxLength, tag, callBack);
		ProccessData_Len(state);
	}

	private void OnRecievedData(IAsyncResult a)
	{
		_SocketState socketState = (_SocketState)a.AsyncState;
		try
		{
			if (!IsClosed)
			{
				int num = EndReceive(a);
				if (num > 0)
				{
					AppendBuffer(socketState.RecvBuffer, num);
					if (socketState.ReadType == ReadType.Terminator)
					{
						ProccessData_Term(socketState);
					}
					else
					{
						ProccessData_Len(socketState);
					}
				}
				else if (socketState.Callback != null)
				{
					socketState.Callback(SocketCallBackResult.SocketClosed, socketState.ReadCount, null, socketState.Tag);
				}
			}
			OnActivity();
		}
		catch (Exception x)
		{
			if (socketState.Callback != null)
			{
				socketState.Callback(SocketCallBackResult.Exception, socketState.ReadCount, x, socketState.Tag);
			}
		}
	}

	private void ProccessData_Term(_SocketState state)
	{
		while (state.NextRead > 0)
		{
			if (AvailableInBuffer < state.NextRead)
			{
				byte[] array2 = (state.RecvBuffer = new byte[4000]);
				BeginReceive(array2, 0, array2.Length, SocketFlags.None, OnRecievedData, state);
				return;
			}
			byte[] array3 = new byte[state.NextRead];
			int num = ReceiveFromFuffer(array3);
			state.ReadCount += num;
			if (state.ReadCount < state.MaxLength)
			{
				state.Stream.Write(array3, 0, num);
			}
			state.NextRead = state.Stack.Push(array3, num);
		}
		if (state.ReadCount < state.MaxLength)
		{
			if (state.RemFromEnd.Length > 0 && state.Stream.Length > state.RemFromEnd.Length)
			{
				state.Stream.SetLength(state.Stream.Length - state.RemFromEnd.Length);
			}
			state.Stream.Position = 0L;
			if (m_pLogger != null)
			{
				if (state.Stream.Length < 200 && state.Stream is MemoryStream)
				{
					MemoryStream memoryStream = (MemoryStream)state.Stream;
					m_pLogger.AddReadEntry(m_pEncoding.GetString(memoryStream.ToArray()), state.ReadCount);
				}
				else
				{
					m_pLogger.AddReadEntry("Big binary, readed " + state.ReadCount + " bytes.", state.ReadCount);
				}
			}
			if (state.Callback != null)
			{
				state.Callback(SocketCallBackResult.Ok, state.ReadCount, null, state.Tag);
			}
		}
		else if (state.Callback != null)
		{
			state.Callback(SocketCallBackResult.LengthExceeded, state.ReadCount, null, state.Tag);
		}
	}

	private void ProccessData_Len(_SocketState state)
	{
		long num = AvailableInBuffer;
		if (num > 0)
		{
			byte[] array = new byte[num];
			if (num > state.LenthToRead - state.ReadCount)
			{
				array = new byte[state.LenthToRead - state.ReadCount];
			}
			int num2 = ReceiveFromFuffer(array);
			state.ReadCount += array.Length;
			if (state.ReadCount < state.MaxLength)
			{
				state.Stream.Write(array, 0, array.Length);
			}
		}
		if (state.ReadCount == state.LenthToRead)
		{
			if (state.ReadCount > state.MaxLength)
			{
				if (state.Callback != null)
				{
					state.Callback(SocketCallBackResult.LengthExceeded, state.ReadCount, null, state.Tag);
				}
				return;
			}
			if (m_pLogger != null)
			{
				m_pLogger.AddReadEntry("Big binary, readed " + state.ReadCount + " bytes.", state.ReadCount);
			}
			if (state.Callback != null)
			{
				state.Callback(SocketCallBackResult.Ok, state.ReadCount, null, state.Tag);
			}
		}
		else
		{
			byte[] array3 = (state.RecvBuffer = new byte[1024]);
			BeginReceive(array3, 0, array3.Length, SocketFlags.None, OnRecievedData, state);
		}
	}

	public void BeginSendData(string data, object tag, SocketCallBack callBack)
	{
		BeginSendData(new MemoryStream(m_pEncoding.GetBytes(data)), tag, callBack);
	}

	public void BeginSendData(Stream strm, object tag, SocketCallBack callBack)
	{
		SendDataBlock(strm, tag, callBack);
	}

	private void OnSendedData(IAsyncResult a)
	{
		object[] array = (object[])a.AsyncState;
		Stream stream = (Stream)array[0];
		object tag = array[1];
		SocketCallBack socketCallBack = (SocketCallBack)array[2];
		try
		{
			int num = m_pSocket.EndSend(a);
			if (stream.Position < stream.Length)
			{
				SendDataBlock(stream, tag, socketCallBack);
			}
			else
			{
				if (m_pLogger != null)
				{
					if (stream is MemoryStream && stream.Length < 200)
					{
						MemoryStream memoryStream = (MemoryStream)stream;
						m_pLogger.AddSendEntry(m_pEncoding.GetString(memoryStream.ToArray()), stream.Length);
					}
					else
					{
						m_pLogger.AddSendEntry("Big binary, readed " + stream.Position + " bytes.", stream.Length);
					}
				}
				socketCallBack?.Invoke(SocketCallBackResult.Ok, stream.Position, null, tag);
			}
			OnActivity();
		}
		catch (Exception x)
		{
			socketCallBack?.Invoke(SocketCallBackResult.Exception, stream.Position, x, tag);
		}
	}

	private void SendDataBlock(Stream strm, object tag, SocketCallBack callBack)
	{
		byte[] array = new byte[4000];
		int size = strm.Read(array, 0, array.Length);
		m_pSocket.BeginSend(array, 0, size, SocketFlags.None, OnSendedData, new object[3] { strm, tag, callBack });
	}

	private void OnActivity()
	{
		if (this.Activity != null)
		{
			this.Activity(this, new EventArgs());
		}
	}
}

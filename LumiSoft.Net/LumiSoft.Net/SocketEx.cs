using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LumiSoft.Net;

public class SocketEx : IDisposable
{
	private delegate void BufferDataBlockCompleted(Exception x, object tag);

	private struct _BeginWritePeriodTerminated_State
	{
		private Stream m_Stream;

		private bool m_CloseStream;

		private object m_Tag;

		private SocketCallBack m_Callback;

		private bool m_HasCRLF;

		private int m_LastByte;

		private int m_CountSent;

		public Stream Stream => m_Stream;

		public bool CloseStream => m_CloseStream;

		public object Tag => m_Tag;

		public SocketCallBack Callback => m_Callback;

		public bool HasCRLF
		{
			get
			{
				return m_HasCRLF;
			}
			set
			{
				m_HasCRLF = value;
			}
		}

		public int LastByte
		{
			get
			{
				return m_LastByte;
			}
			set
			{
				m_LastByte = value;
			}
		}

		public int CountSent
		{
			get
			{
				return m_CountSent;
			}
			set
			{
				m_CountSent = value;
			}
		}

		public _BeginWritePeriodTerminated_State(Stream stream, bool closeStream, object tag, SocketCallBack callback)
		{
			m_Stream = stream;
			m_CloseStream = closeStream;
			m_Tag = tag;
			m_Callback = callback;
			m_HasCRLF = false;
			m_LastByte = -1;
			m_CountSent = 0;
		}
	}

	private Socket m_pSocket = null;

	private NetworkStream m_pSocketStream = null;

	private SslStream m_pSslStream = null;

	private bool m_SSL = false;

	private byte[] m_Buffer = null;

	private int m_OffsetInBuffer = 0;

	private int m_AvailableInBuffer = 0;

	private Encoding m_pEncoding = null;

	private SocketLogger m_pLogger = null;

	private string m_Host = "";

	private DateTime m_LastActivityDate;

	private long m_ReadedCount = 0L;

	private long m_WrittenCount = 0L;

	public Encoding Encoding
	{
		get
		{
			return m_pEncoding;
		}
		set
		{
			if (m_pEncoding == null)
			{
				throw new ArgumentNullException("Encoding");
			}
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

	public Socket RawSocket => m_pSocket;

	public bool Connected => m_pSocket != null && m_pSocket.Connected;

	public EndPoint LocalEndPoint
	{
		get
		{
			if (m_pSocket == null)
			{
				return null;
			}
			return m_pSocket.LocalEndPoint;
		}
	}

	public EndPoint RemoteEndPoint
	{
		get
		{
			if (m_pSocket == null)
			{
				return null;
			}
			return m_pSocket.RemoteEndPoint;
		}
	}

	public bool SSL => m_SSL;

	public long ReadedCount => m_ReadedCount;

	public long WrittenCount => m_WrittenCount;

	public DateTime LastActivity => m_LastActivityDate;

	public SocketEx()
	{
		m_Buffer = new byte[8000];
		m_pEncoding = Encoding.UTF8;
		m_LastActivityDate = DateTime.Now;
		m_pSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	}

	public SocketEx(Socket socket)
	{
		m_Buffer = new byte[8000];
		m_pEncoding = Encoding.UTF8;
		m_LastActivityDate = DateTime.Now;
		m_pSocket = socket;
		m_pSocketStream = new NetworkStream(socket, ownsSocket: false);
	}

	public void Dispose()
	{
		Disconnect();
	}

	public void Connect(IPEndPoint endpoint)
	{
		Connect(endpoint.Address.ToString(), endpoint.Port, ssl: false);
	}

	public void Connect(IPEndPoint endpoint, bool ssl)
	{
		Connect(endpoint.Address.ToString(), endpoint.Port, ssl);
	}

	public void Connect(string host, int port)
	{
		Connect(host, port, ssl: false);
	}

	public void Connect(string host, int port, bool ssl)
	{
		m_pSocket.Connect(host, port);
		m_Host = host;
		m_pSocketStream = new NetworkStream(m_pSocket, ownsSocket: false);
		if (ssl)
		{
			SwitchToSSL_AsClient();
		}
	}

	public void Disconnect()
	{
		lock (this)
		{
			m_pSocket.Close();
			m_SSL = false;
			m_pSocketStream = null;
			m_pSslStream = null;
			m_pSocket = null;
			m_OffsetInBuffer = 0;
			m_AvailableInBuffer = 0;
			m_Host = "";
			m_ReadedCount = 0L;
			m_WrittenCount = 0L;
		}
	}

	public void Shutdown(SocketShutdown how)
	{
		m_pSocket.Shutdown(how);
	}

	public void Bind(EndPoint loaclEP)
	{
		m_pSocket.Bind(loaclEP);
	}

	public void Listen(int backlog)
	{
		m_pSocket.Listen(backlog);
	}

	public SocketEx Accept(bool ssl)
	{
		Socket socket = m_pSocket.Accept();
		return new SocketEx(socket);
	}

	public void SwitchToSSL(X509Certificate certificate)
	{
		if (m_SSL)
		{
			throw new Exception("Error can't switch to SSL, socket is already in SSL mode !");
		}
		SslStream sslStream = new SslStream(m_pSocketStream);
		sslStream.AuthenticateAsServer(certificate);
		m_SSL = true;
		m_pSslStream = sslStream;
	}

	public void SwitchToSSL_AsClient()
	{
		if (m_SSL)
		{
			throw new Exception("Error can't switch to SSL, socket is already in SSL mode !");
		}
		SslStream sslStream = new SslStream(m_pSocketStream, leaveInnerStreamOpen: true, RemoteCertificateValidationCallback);
		sslStream.AuthenticateAsClient(m_Host);
		m_SSL = true;
		m_pSslStream = sslStream;
	}

	private bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		if (sslPolicyErrors == SslPolicyErrors.None || sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch)
		{
			return true;
		}
		return false;
	}

	public int ReadByte()
	{
		BufferDataBlock();
		if (m_AvailableInBuffer == 0)
		{
			m_OffsetInBuffer = 0;
			m_AvailableInBuffer = 0;
			return -1;
		}
		m_OffsetInBuffer++;
		m_AvailableInBuffer--;
		return m_Buffer[m_OffsetInBuffer - 1];
	}

	public string ReadLine()
	{
		return ReadLine(4000);
	}

	public string ReadLine(int maxLineLength)
	{
		return m_pEncoding.GetString(ReadLineByte(maxLineLength));
	}

	public byte[] ReadLineByte(int maxLineLength)
	{
		MemoryStream memoryStream = new MemoryStream();
		ReadLine(memoryStream, maxLineLength);
		return memoryStream.ToArray();
	}

	public void ReadLine(Stream stream, int maxLineLength)
	{
		int num = ReadByte();
		int num2 = ReadByte();
		int num3 = 2;
		while (num2 > -1)
		{
			if (num == 13 && num2 == 10)
			{
				if (m_pLogger != null)
				{
					if (stream.CanSeek && stream.Length < 200)
					{
						byte[] array = new byte[stream.Length];
						stream.Position = 0L;
						stream.Read(array, 0, array.Length);
						m_pLogger.AddReadEntry(m_pEncoding.GetString(array), num3);
					}
					else
					{
						m_pLogger.AddReadEntry("Big binary line, readed " + num3 + " bytes.", num3);
					}
				}
				stream.Flush();
				if (num3 > maxLineLength)
				{
					throw new ReadException(ReadReplyCode.LengthExceeded, "Maximum allowed line length exceeded !");
				}
				return;
			}
			if (num3 < maxLineLength)
			{
				stream.WriteByte((byte)num);
			}
			num = num2;
			num2 = ReadByte();
			num3++;
		}
		throw new ReadException(ReadReplyCode.SocketClosed, "Socket closed !");
	}

	public void ReadSpecifiedLength(int lengthToRead, Stream storeStream)
	{
		while (lengthToRead > 0)
		{
			BufferDataBlock();
			if (m_AvailableInBuffer == 0)
			{
				m_OffsetInBuffer = 0;
				m_AvailableInBuffer = 0;
				throw new Exception("Socket shutdowned, all data wans't readed !");
			}
			if (m_AvailableInBuffer >= lengthToRead)
			{
				storeStream.Write(m_Buffer, m_OffsetInBuffer, lengthToRead);
				storeStream.Flush();
				m_OffsetInBuffer += lengthToRead;
				m_AvailableInBuffer -= lengthToRead;
				lengthToRead = 0;
				if (m_pLogger != null)
				{
					if (storeStream.CanSeek && storeStream.Length < 200)
					{
						byte[] array = new byte[storeStream.Length];
						storeStream.Position = 0L;
						storeStream.Read(array, 0, array.Length);
						m_pLogger.AddReadEntry(m_pEncoding.GetString(array), lengthToRead);
					}
					else
					{
						m_pLogger.AddReadEntry("Big binary data, readed " + lengthToRead + " bytes.", lengthToRead);
					}
				}
			}
			else
			{
				storeStream.Write(m_Buffer, m_OffsetInBuffer, m_AvailableInBuffer);
				storeStream.Flush();
				lengthToRead -= m_AvailableInBuffer;
				m_OffsetInBuffer = 0;
				m_AvailableInBuffer = 0;
			}
		}
	}

	public string ReadPeriodTerminated(int maxLength)
	{
		MemoryStream memoryStream = new MemoryStream();
		ReadPeriodTerminated(memoryStream, maxLength);
		return m_pEncoding.GetString(memoryStream.ToArray());
	}

	public void ReadPeriodTerminated(Stream stream, int maxLength)
	{
		byte[] array = new byte[8000];
		int num = 0;
		int num2 = ReadByte();
		int num3 = ReadByte();
		int num4 = 2;
		bool flag = false;
		bool flag2 = false;
		while (num3 > -1)
		{
			if (flag)
			{
				flag = false;
				if (num3 == 46)
				{
					flag2 = true;
					num3 = ReadByte();
				}
			}
			else if (num2 == 13 && num3 == 10)
			{
				flag = true;
				if (flag2)
				{
					if (num > 0)
					{
						stream.Write(array, 0, num);
						num = 0;
					}
					if (m_pLogger != null)
					{
						if (stream.CanSeek && stream.Length < 200)
						{
							byte[] array2 = new byte[stream.Length];
							stream.Position = 0L;
							stream.Read(array2, 0, array2.Length);
							m_pLogger.AddReadEntry(m_pEncoding.GetString(array2), num4);
						}
						else
						{
							m_pLogger.AddReadEntry("Big binary data, readed " + num4 + " bytes.", num4);
						}
					}
					if (num4 > maxLength)
					{
						throw new ReadException(ReadReplyCode.LengthExceeded, "Maximum allowed line length exceeded !");
					}
					return;
				}
			}
			if (flag2 && num3 != 13 && num3 != 10)
			{
				flag2 = false;
			}
			if (num4 < maxLength)
			{
				if (num > array.Length - 2)
				{
					stream.Write(array, 0, num);
					num = 0;
				}
				array[num] = (byte)num2;
				num++;
			}
			num2 = num3;
			num3 = ReadByte();
			num4++;
		}
		throw new Exception("Socket shutdowned and data wasn't <CRLF>.<CRLF> terminated !");
	}

	public void Write(string data)
	{
		Write(new MemoryStream(m_pEncoding.GetBytes(data)));
	}

	public void Write(byte[] data)
	{
		Write(new MemoryStream(data));
	}

	public void Write(Stream stream)
	{
		byte[] array = new byte[4000];
		int num = 0;
		for (int num2 = stream.Read(array, 0, array.Length); num2 > 0; num2 = stream.Read(array, 0, array.Length))
		{
			if (m_SSL)
			{
				m_pSslStream.Write(array, 0, num2);
				m_pSslStream.Flush();
			}
			else
			{
				m_pSocketStream.Write(array, 0, num2);
			}
			num += num2;
			m_WrittenCount += num2;
			m_LastActivityDate = DateTime.Now;
		}
		if (m_pLogger != null)
		{
			if (num < 200)
			{
				m_pLogger.AddSendEntry(m_pEncoding.GetString(array, 0, num), num);
			}
			else
			{
				m_pLogger.AddSendEntry("Big binary data, sent " + num + " bytes.", num);
			}
		}
	}

	public void Write(Stream stream, long count)
	{
		byte[] array = new byte[4000];
		int num = 0;
		int num2 = 0;
		num2 = ((count - num <= array.Length) ? stream.Read(array, 0, (int)(count - num)) : stream.Read(array, 0, array.Length));
		while (num < count)
		{
			if (m_SSL)
			{
				m_pSslStream.Write(array, 0, num2);
				m_pSslStream.Flush();
			}
			else
			{
				m_pSocketStream.Write(array, 0, num2);
			}
			num += num2;
			m_WrittenCount += num2;
			m_LastActivityDate = DateTime.Now;
			num2 = ((count - num <= array.Length) ? stream.Read(array, 0, (int)(count - num)) : stream.Read(array, 0, array.Length));
		}
		if (m_pLogger != null)
		{
			if (num < 200)
			{
				m_pLogger.AddSendEntry(m_pEncoding.GetString(array, 0, num), num);
			}
			else
			{
				m_pLogger.AddSendEntry("Big binary data, sent " + num + " bytes.", num);
			}
		}
	}

	public void WriteLine(string line)
	{
		WriteLine(m_pEncoding.GetBytes(line));
	}

	public void WriteLine(byte[] line)
	{
		m_pSocket.NoDelay = true;
		if (line.Length < 2 || (line[line.Length - 2] != 13 && line[line.Length - 1] != 10))
		{
			byte[] array = new byte[line.Length + 2];
			Array.Copy(line, array, line.Length);
			array[array.Length - 2] = 13;
			array[array.Length - 1] = 10;
			line = array;
		}
		if (m_SSL)
		{
			m_pSslStream.Write(line);
		}
		else
		{
			m_pSocketStream.Write(line, 0, line.Length);
		}
		m_WrittenCount += line.Length;
		m_LastActivityDate = DateTime.Now;
		if (m_pLogger != null)
		{
			if (line.Length < 200)
			{
				m_pLogger.AddSendEntry(m_pEncoding.GetString(line), line.Length);
			}
			else
			{
				m_pLogger.AddSendEntry("Big binary line, sent " + line.Length + " bytes.", line.Length);
			}
		}
	}

	public void WritePeriodTerminated(string data)
	{
		WritePeriodTerminated(new MemoryStream(m_pEncoding.GetBytes(data)));
	}

	public void WritePeriodTerminated(Stream stream)
	{
		int num = 0;
		byte[] array = new byte[4000];
		int num2 = 0;
		bool flag = false;
		int num3 = -1;
		for (int num4 = stream.ReadByte(); num4 > -1; num4 = stream.ReadByte())
		{
			if (num3 == 13 && num4 == 10)
			{
				flag = true;
			}
			else if (flag)
			{
				if (num4 == 46)
				{
					array[num2] = 46;
					num2++;
				}
				flag = false;
			}
			array[num2] = (byte)num4;
			num2++;
			num3 = num4;
			if (num2 > 3990)
			{
				if (m_SSL)
				{
					m_pSslStream.Write(array, 0, num2);
				}
				else
				{
					m_pSocketStream.Write(array, 0, num2);
				}
				num += num2;
				m_WrittenCount += num2;
				m_LastActivityDate = DateTime.Now;
				num2 = 0;
			}
		}
		if (!flag)
		{
			array[num2] = 13;
			num2++;
			array[num2] = 10;
			num2++;
		}
		array[num2] = 46;
		num2++;
		array[num2] = 13;
		num2++;
		array[num2] = 10;
		num2++;
		if (m_SSL)
		{
			m_pSslStream.Write(array, 0, num2);
		}
		else
		{
			m_pSocketStream.Write(array, 0, num2);
		}
		num += num2;
		m_WrittenCount += num2;
		m_LastActivityDate = DateTime.Now;
		if (m_pLogger != null)
		{
			if (num < 200)
			{
				m_pLogger.AddSendEntry(m_pEncoding.GetString(array), array.Length);
			}
			else
			{
				m_pLogger.AddSendEntry("Binary data, sent " + num + " bytes.", num);
			}
		}
	}

	public void BeginReadLine(Stream stream, int maxLineLength, object tag, SocketCallBack callback)
	{
		TryToReadLine(callback, tag, stream, maxLineLength, -1, 0);
	}

	private void TryToReadLine(SocketCallBack callback, object tag, Stream stream, int maxLineLength, int lastByte, int readedCount)
	{
		if (m_AvailableInBuffer == 0)
		{
			BeginBufferDataBlock(OnBeginReadLineBufferingCompleted, new object[6] { callback, tag, stream, maxLineLength, lastByte, readedCount });
			return;
		}
		if (lastByte == -1)
		{
			lastByte = ReadByte();
			readedCount++;
			if (m_AvailableInBuffer == 0)
			{
				BeginBufferDataBlock(OnBeginReadLineBufferingCompleted, new object[6] { callback, tag, stream, maxLineLength, lastByte, readedCount });
				return;
			}
		}
		int num = ReadByte();
		readedCount++;
		while (num > -1)
		{
			if (lastByte == 13 && num == 10)
			{
				if (m_pLogger != null)
				{
					if (stream.CanSeek && stream.Length < 200)
					{
						byte[] array = new byte[stream.Length];
						stream.Position = 0L;
						stream.Read(array, 0, array.Length);
						m_pLogger.AddReadEntry(m_pEncoding.GetString(array), readedCount);
					}
					else
					{
						m_pLogger.AddReadEntry("Big binary line, readed " + readedCount + " bytes.", readedCount);
					}
				}
				if (readedCount > maxLineLength)
				{
					callback?.Invoke(SocketCallBackResult.LengthExceeded, 0L, new ReadException(ReadReplyCode.LengthExceeded, "Maximum allowed data length exceeded !"), tag);
				}
				callback?.Invoke(SocketCallBackResult.Ok, readedCount, null, tag);
				return;
			}
			if (readedCount < maxLineLength)
			{
				stream.WriteByte((byte)lastByte);
			}
			lastByte = num;
			if (m_AvailableInBuffer > 0)
			{
				num = ReadByte();
				readedCount++;
				continue;
			}
			BeginBufferDataBlock(OnBeginReadLineBufferingCompleted, new object[6] { callback, tag, stream, maxLineLength, lastByte, readedCount });
			return;
		}
		callback?.Invoke(SocketCallBackResult.Exception, 0L, new Exception("Never should reach there ! method TryToReadLine out of while loop."), tag);
	}

	private void OnBeginReadLineBufferingCompleted(Exception x, object tag)
	{
		object[] array = (object[])tag;
		SocketCallBack socketCallBack = (SocketCallBack)array[0];
		object tag2 = array[1];
		Stream stream = (Stream)array[2];
		int maxLineLength = (int)array[3];
		int lastByte = (int)array[4];
		int readedCount = (int)array[5];
		if (x == null)
		{
			if (m_AvailableInBuffer == 0)
			{
				socketCallBack(SocketCallBackResult.SocketClosed, 0L, null, tag2);
			}
			else
			{
				TryToReadLine(socketCallBack, tag2, stream, maxLineLength, lastByte, readedCount);
			}
		}
		else
		{
			socketCallBack(SocketCallBackResult.Exception, 0L, x, tag2);
		}
	}

	public void BeginReadSpecifiedLength(Stream stream, int lengthToRead, object tag, SocketCallBack callback)
	{
		TryToReadReadSpecifiedLength(stream, lengthToRead, tag, callback, 0);
	}

	private void TryToReadReadSpecifiedLength(Stream stream, int lengthToRead, object tag, SocketCallBack callback, int readedCount)
	{
		if (m_AvailableInBuffer == 0)
		{
			BeginBufferDataBlock(OnBeginReadSpecifiedLengthBufferingCompleted, new object[5] { callback, tag, stream, lengthToRead, readedCount });
			return;
		}
		int num = lengthToRead - readedCount;
		if (num > m_AvailableInBuffer)
		{
			stream.Write(m_Buffer, m_OffsetInBuffer, m_AvailableInBuffer);
			stream.Flush();
			readedCount += m_AvailableInBuffer;
			m_OffsetInBuffer = 0;
			m_AvailableInBuffer = 0;
			BeginBufferDataBlock(OnBeginReadSpecifiedLengthBufferingCompleted, new object[5] { callback, tag, stream, lengthToRead, readedCount });
			return;
		}
		stream.Write(m_Buffer, m_OffsetInBuffer, num);
		stream.Flush();
		readedCount += num;
		m_OffsetInBuffer += num;
		m_AvailableInBuffer -= num;
		if (m_pLogger != null)
		{
			if (stream.CanSeek && stream.Length < 200)
			{
				byte[] array = new byte[stream.Length];
				stream.Position = 0L;
				stream.Read(array, 0, array.Length);
				m_pLogger.AddReadEntry(m_pEncoding.GetString(array), lengthToRead);
			}
			else
			{
				m_pLogger.AddReadEntry("Big binary data, readed " + readedCount + " bytes.", readedCount);
			}
		}
		callback?.Invoke(SocketCallBackResult.Ok, readedCount, null, tag);
	}

	private void OnBeginReadSpecifiedLengthBufferingCompleted(Exception x, object tag)
	{
		object[] array = (object[])tag;
		SocketCallBack socketCallBack = (SocketCallBack)array[0];
		object tag2 = array[1];
		Stream stream = (Stream)array[2];
		int lengthToRead = (int)array[3];
		int readedCount = (int)array[4];
		if (x == null)
		{
			if (m_AvailableInBuffer == 0)
			{
				socketCallBack(SocketCallBackResult.SocketClosed, 0L, null, tag2);
			}
			else
			{
				TryToReadReadSpecifiedLength(stream, lengthToRead, tag2, socketCallBack, readedCount);
			}
		}
		else
		{
			socketCallBack(SocketCallBackResult.Exception, 0L, x, tag2);
		}
	}

	public void BeginReadPeriodTerminated(Stream stream, int maxLength, object tag, SocketCallBack callback)
	{
		TryToReadPeriodTerminated(callback, tag, stream, maxLength, -1, 0, lineBreak: false, expectCRLF: false);
	}

	private void TryToReadPeriodTerminated(SocketCallBack callback, object tag, Stream stream, int maxLength, int lastByte, int readedCount, bool lineBreak, bool expectCRLF)
	{
		if (m_AvailableInBuffer == 0)
		{
			BeginBufferDataBlock(OnBeginReadPeriodTerminatedBufferingCompleted, new object[8] { callback, tag, stream, maxLength, lastByte, readedCount, lineBreak, expectCRLF });
			return;
		}
		if (lastByte == -1)
		{
			lastByte = ReadByte();
			readedCount++;
			if (m_AvailableInBuffer == 0)
			{
				BeginBufferDataBlock(OnBeginReadPeriodTerminatedBufferingCompleted, new object[8] { callback, tag, stream, maxLength, lastByte, readedCount, lineBreak, expectCRLF });
				return;
			}
		}
		byte[] array = new byte[8000];
		int num = 0;
		int num2 = ReadByte();
		readedCount++;
		while (num2 > -1)
		{
			if (lineBreak)
			{
				lineBreak = false;
				if (num2 == 46)
				{
					expectCRLF = true;
					if (m_AvailableInBuffer <= 0)
					{
						if (num > 0)
						{
							stream.Write(array, 0, num);
							num = 0;
						}
						BeginBufferDataBlock(OnBeginReadPeriodTerminatedBufferingCompleted, new object[8] { callback, tag, stream, maxLength, lastByte, readedCount, lineBreak, expectCRLF });
						return;
					}
					num2 = ReadByte();
					readedCount++;
				}
			}
			else if (lastByte == 13 && num2 == 10)
			{
				lineBreak = true;
				if (expectCRLF)
				{
					if (num > 0)
					{
						stream.Write(array, 0, num);
						num = 0;
					}
					if (m_pLogger != null)
					{
						if (stream.CanSeek && stream.Length < 200)
						{
							byte[] array2 = new byte[stream.Length];
							stream.Position = 0L;
							stream.Read(array2, 0, array2.Length);
							m_pLogger.AddReadEntry(m_pEncoding.GetString(array2), readedCount);
						}
						else
						{
							m_pLogger.AddReadEntry("Big binary data, readed " + readedCount + " bytes.", readedCount);
						}
					}
					if (readedCount > maxLength)
					{
						callback?.Invoke(SocketCallBackResult.LengthExceeded, 0L, new ReadException(ReadReplyCode.LengthExceeded, "Maximum allowed data length exceeded !"), tag);
					}
					else
					{
						callback?.Invoke(SocketCallBackResult.Ok, readedCount, null, tag);
					}
					return;
				}
			}
			if (expectCRLF && num2 != 13 && num2 != 10)
			{
				expectCRLF = false;
			}
			if (readedCount < maxLength)
			{
				if (num > array.Length - 2)
				{
					stream.Write(array, 0, num);
					num = 0;
				}
				array[num] = (byte)lastByte;
				num++;
			}
			lastByte = num2;
			if (m_AvailableInBuffer > 0)
			{
				num2 = ReadByte();
				readedCount++;
				continue;
			}
			if (num > 0)
			{
				stream.Write(array, 0, num);
				num = 0;
			}
			BeginBufferDataBlock(OnBeginReadPeriodTerminatedBufferingCompleted, new object[8] { callback, tag, stream, maxLength, lastByte, readedCount, lineBreak, expectCRLF });
			return;
		}
		callback?.Invoke(SocketCallBackResult.Exception, 0L, new Exception("Never should reach there ! method TryToReadPeriodTerminated out of while loop."), tag);
	}

	private void OnBeginReadPeriodTerminatedBufferingCompleted(Exception x, object tag)
	{
		object[] array = (object[])tag;
		SocketCallBack socketCallBack = (SocketCallBack)array[0];
		object tag2 = array[1];
		Stream stream = (Stream)array[2];
		int maxLength = (int)array[3];
		int lastByte = (int)array[4];
		int readedCount = (int)array[5];
		bool lineBreak = (bool)array[6];
		bool expectCRLF = (bool)array[7];
		if (x == null)
		{
			if (m_AvailableInBuffer == 0)
			{
				socketCallBack(SocketCallBackResult.SocketClosed, 0L, null, tag2);
			}
			else
			{
				TryToReadPeriodTerminated(socketCallBack, tag2, stream, maxLength, lastByte, readedCount, lineBreak, expectCRLF);
			}
		}
		else
		{
			socketCallBack(SocketCallBackResult.Exception, 0L, x, tag2);
		}
	}

	public void BeginWrite(Stream stream, object tag, SocketCallBack callback)
	{
		m_pSocket.NoDelay = false;
		BeginProcessingWrite(stream, tag, callback, 0);
	}

	private void BeginProcessingWrite(Stream stream, object tag, SocketCallBack callback, int countSent)
	{
		byte[] array = new byte[4000];
		int num = stream.Read(array, 0, array.Length);
		if (num > 0)
		{
			countSent += num;
			m_WrittenCount += num;
			if (m_SSL)
			{
				m_pSslStream.BeginWrite(array, 0, num, OnBeginWriteCallback, new object[4] { stream, tag, callback, countSent });
			}
			else
			{
				m_pSocketStream.BeginWrite(array, 0, num, OnBeginWriteCallback, new object[4] { stream, tag, callback, countSent });
			}
			return;
		}
		if (m_pLogger != null)
		{
			if (stream.CanSeek && stream.Length < 200)
			{
				byte[] array2 = new byte[stream.Length];
				stream.Position = 0L;
				stream.Read(array2, 0, array2.Length);
				m_pLogger.AddSendEntry(m_pEncoding.GetString(array2), countSent);
			}
			else
			{
				m_pLogger.AddSendEntry("Big binary data, sent " + countSent + " bytes.", countSent);
			}
		}
		callback?.Invoke(SocketCallBackResult.Ok, countSent, null, tag);
	}

	private void OnBeginWriteCallback(IAsyncResult ar)
	{
		object[] array = (object[])ar.AsyncState;
		Stream stream = (Stream)array[0];
		object tag = array[1];
		SocketCallBack socketCallBack = (SocketCallBack)array[2];
		int countSent = (int)array[3];
		try
		{
			if (m_SSL)
			{
				m_pSslStream.EndWrite(ar);
			}
			else
			{
				m_pSocketStream.EndWrite(ar);
			}
			m_LastActivityDate = DateTime.Now;
			BeginProcessingWrite(stream, tag, socketCallBack, countSent);
		}
		catch (Exception x)
		{
			socketCallBack?.Invoke(SocketCallBackResult.Exception, 0L, x, tag);
		}
	}

	public void BeginWriteLine(string line, SocketCallBack callback)
	{
		m_pSocket.NoDelay = true;
		BeginWriteLine(line, null, callback);
	}

	public void BeginWriteLine(string line, object tag, SocketCallBack callback)
	{
		m_pSocket.NoDelay = true;
		if (!line.EndsWith("\r\n"))
		{
			line += "\r\n";
		}
		byte[] bytes = m_pEncoding.GetBytes(line);
		if (m_SSL)
		{
			m_pSslStream.BeginWrite(bytes, 0, bytes.Length, OnBeginWriteLineCallback, new object[3] { tag, callback, bytes });
		}
		else
		{
			m_pSocketStream.BeginWrite(bytes, 0, bytes.Length, OnBeginWriteLineCallback, new object[3] { tag, callback, bytes });
		}
	}

	private void OnBeginWriteLineCallback(IAsyncResult ar)
	{
		object[] array = (object[])ar.AsyncState;
		object tag = array[0];
		SocketCallBack socketCallBack = (SocketCallBack)array[1];
		byte[] array2 = (byte[])array[2];
		try
		{
			if (m_SSL)
			{
				m_pSslStream.EndWrite(ar);
			}
			else
			{
				m_pSocketStream.EndWrite(ar);
			}
			m_WrittenCount += array2.Length;
			m_LastActivityDate = DateTime.Now;
			if (m_pLogger != null)
			{
				if (array2.Length < 200)
				{
					m_pLogger.AddSendEntry(m_pEncoding.GetString(array2), array2.Length);
				}
				else
				{
					m_pLogger.AddSendEntry("Big binary line, sent " + array2.Length + " bytes.", array2.Length);
				}
			}
			socketCallBack?.Invoke(SocketCallBackResult.Ok, array2.Length, null, tag);
		}
		catch (Exception x)
		{
			socketCallBack?.Invoke(SocketCallBackResult.Exception, 0L, x, tag);
		}
	}

	public void BeginWritePeriodTerminated(Stream stream, object tag, SocketCallBack callback)
	{
		BeginWritePeriodTerminated(stream, closeStream: false, tag, callback);
	}

	public void BeginWritePeriodTerminated(Stream stream, bool closeStream, object tag, SocketCallBack callback)
	{
		m_pSocket.NoDelay = false;
		_BeginWritePeriodTerminated_State state = new _BeginWritePeriodTerminated_State(stream, closeStream, tag, callback);
		BeginProcessingWritePeriodTerminated(state);
	}

	private void BeginProcessingWritePeriodTerminated(_BeginWritePeriodTerminated_State state)
	{
		byte[] array = new byte[4000];
		int num = 0;
		for (int num2 = state.Stream.ReadByte(); num2 > -1; num2 = state.Stream.ReadByte())
		{
			if (state.LastByte == 13 && num2 == 10)
			{
				state.HasCRLF = true;
			}
			else if (state.HasCRLF)
			{
				if (num2 == 46)
				{
					array[num] = 46;
					num++;
				}
				state.HasCRLF = false;
			}
			array[num] = (byte)num2;
			num++;
			state.LastByte = num2;
			if (num > 3990)
			{
				state.CountSent += num;
				m_WrittenCount += num;
				if (m_SSL)
				{
					m_pSslStream.BeginWrite(array, 0, num, OnBeginWritePeriodTerminatedCallback, state);
				}
				else
				{
					m_pSocketStream.BeginWrite(array, 0, num, OnBeginWritePeriodTerminatedCallback, state);
				}
				return;
			}
		}
		if (!state.HasCRLF)
		{
			array[num] = 13;
			num++;
			array[num] = 10;
			num++;
		}
		array[num] = 46;
		num++;
		array[num] = 13;
		num++;
		array[num] = 10;
		num++;
		if (m_SSL)
		{
			m_pSslStream.Write(array, 0, num);
		}
		else
		{
			m_pSocketStream.Write(array, 0, num);
		}
		state.CountSent += num;
		m_WrittenCount += num;
		m_LastActivityDate = DateTime.Now;
		if (m_pLogger != null)
		{
			if (state.CountSent < 200)
			{
				m_pLogger.AddSendEntry(m_pEncoding.GetString(array), array.Length);
			}
			else
			{
				m_pLogger.AddSendEntry("Binary data, sent " + state.CountSent + " bytes.", state.CountSent);
			}
		}
		if (state.CloseStream)
		{
			try
			{
				state.Stream.Close();
			}
			catch
			{
			}
		}
		if (state.Callback != null)
		{
			state.Callback(SocketCallBackResult.Ok, state.CountSent, null, state.Tag);
		}
	}

	private void OnBeginWritePeriodTerminatedCallback(IAsyncResult ar)
	{
		_BeginWritePeriodTerminated_State state = (_BeginWritePeriodTerminated_State)ar.AsyncState;
		try
		{
			if (m_SSL)
			{
				m_pSslStream.EndWrite(ar);
			}
			else
			{
				m_pSocketStream.EndWrite(ar);
			}
			m_LastActivityDate = DateTime.Now;
			BeginProcessingWritePeriodTerminated(state);
		}
		catch (Exception x)
		{
			if (state.CloseStream)
			{
				try
				{
					state.Stream.Close();
				}
				catch
				{
				}
			}
			if (state.Callback != null)
			{
				state.Callback(SocketCallBackResult.Exception, 0L, x, state.Tag);
			}
		}
	}

	private void BufferDataBlock()
	{
		lock (this)
		{
			if (m_AvailableInBuffer == 0)
			{
				m_OffsetInBuffer = 0;
				if (m_SSL)
				{
					m_AvailableInBuffer = m_pSslStream.Read(m_Buffer, 0, m_Buffer.Length);
				}
				else
				{
					m_AvailableInBuffer = m_pSocket.Receive(m_Buffer);
				}
				m_ReadedCount += m_AvailableInBuffer;
				m_LastActivityDate = DateTime.Now;
			}
		}
	}

	private void BeginBufferDataBlock(BufferDataBlockCompleted callback, object tag)
	{
		if (m_AvailableInBuffer == 0)
		{
			m_OffsetInBuffer = 0;
			if (m_SSL)
			{
				m_pSslStream.BeginRead(m_Buffer, 0, m_Buffer.Length, OnBeginBufferDataBlockCallback, new object[2] { callback, tag });
			}
			else
			{
				m_pSocket.BeginReceive(m_Buffer, 0, m_Buffer.Length, SocketFlags.None, OnBeginBufferDataBlockCallback, new object[2] { callback, tag });
			}
		}
	}

	private void OnBeginBufferDataBlockCallback(IAsyncResult ar)
	{
		object[] array = (object[])ar.AsyncState;
		BufferDataBlockCompleted bufferDataBlockCompleted = (BufferDataBlockCompleted)array[0];
		object tag = array[1];
		try
		{
			if (m_pSocket == null || !m_pSocket.Connected)
			{
				m_AvailableInBuffer = 0;
			}
			else if (m_SSL)
			{
				m_AvailableInBuffer = m_pSslStream.EndRead(ar);
			}
			else
			{
				m_AvailableInBuffer = m_pSocket.EndReceive(ar);
			}
			m_ReadedCount += m_AvailableInBuffer;
			m_LastActivityDate = DateTime.Now;
			bufferDataBlockCompleted?.Invoke(null, tag);
		}
		catch (Exception x)
		{
			bufferDataBlockCompleted?.Invoke(x, tag);
		}
	}
}

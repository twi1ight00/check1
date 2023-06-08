using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Enyim.Caching.Memcached;

[DebuggerDisplay("[ Address: {endpoint}, IsAlive = {IsAlive} ]")]
public class PooledSocket : IDisposable
{
	/// <summary>
	/// Supports exactly one reader and writer, but they can do IO concurrently
	/// </summary>
	private class AsyncSocketHelper
	{
		private const int ChunkSize = 65536;

		private PooledSocket socket;

		private SlidingBuffer asyncBuffer;

		private SocketAsyncEventArgs readEvent;

		private int remainingRead;

		private int expectedToRead;

		private AsyncIOArgs pendingArgs;

		private int isAborted;

		private ManualResetEvent readInProgressEvent;

		public AsyncSocketHelper(PooledSocket socket)
		{
			this.socket = socket;
			asyncBuffer = new SlidingBuffer(65536);
			readEvent = new SocketAsyncEventArgs();
			readEvent.Completed += AsyncReadCompleted;
			readEvent.SetBuffer(new byte[65536], 0, 65536);
			readInProgressEvent = new ManualResetEvent(initialState: false);
		}

		/// <summary>
		/// returns true if io is pending
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public bool Read(AsyncIOArgs p)
		{
			int count = p.Count;
			if (count < 1)
			{
				throw new ArgumentOutOfRangeException("count", "count must be > 0");
			}
			expectedToRead = p.Count;
			pendingArgs = p;
			p.Fail = false;
			p.Result = null;
			if (asyncBuffer.Available >= count)
			{
				PublishResult(isAsync: false);
				return false;
			}
			remainingRead = count - asyncBuffer.Available;
			isAborted = 0;
			BeginReceive();
			return true;
		}

		public void DiscardBuffer()
		{
			asyncBuffer.UnsafeClear();
		}

		private void BeginReceive()
		{
			while (remainingRead > 0)
			{
				readInProgressEvent.Reset();
				if (socket.socket.ReceiveAsync(readEvent))
				{
					if (!readInProgressEvent.WaitOne(socket.socket.ReceiveTimeout))
					{
						AbortReadAndTryPublishError(markAsDead: false);
					}
					break;
				}
				EndReceive();
			}
		}

		private void AsyncReadCompleted(object sender, SocketAsyncEventArgs e)
		{
			if (EndReceive())
			{
				BeginReceive();
			}
		}

		private void AbortReadAndTryPublishError(bool markAsDead)
		{
			if (markAsDead)
			{
				socket.isAlive = false;
			}
			if (Interlocked.CompareExchange(ref isAborted, 1, 0) == 0)
			{
				remainingRead = 0;
				AsyncIOArgs p = pendingArgs;
				p.Fail = true;
				p.Result = null;
				pendingArgs.Next(p);
			}
		}

		/// <summary>
		/// returns true when io is pending
		/// </summary>
		/// <returns></returns>
		private bool EndReceive()
		{
			readInProgressEvent.Set();
			int read = readEvent.BytesTransferred;
			if (readEvent.SocketError != 0 || read == 0)
			{
				AbortReadAndTryPublishError(markAsDead: true);
				return false;
			}
			remainingRead -= read;
			asyncBuffer.Append(readEvent.Buffer, 0, read);
			if (remainingRead <= 0)
			{
				PublishResult(isAsync: true);
				return false;
			}
			return true;
		}

		private void PublishResult(bool isAsync)
		{
			AsyncIOArgs retval = pendingArgs;
			byte[] data = new byte[expectedToRead];
			asyncBuffer.Read(data, 0, retval.Count);
			pendingArgs.Result = data;
			if (isAsync)
			{
				pendingArgs.Next(pendingArgs);
			}
		}
	}

	private class BasicNetworkStream : Stream
	{
		private Socket socket;

		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public BasicNetworkStream(Socket socket)
		{
			this.socket = socket;
		}

		public override void Flush()
		{
		}

		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			SocketError errorCode;
			IAsyncResult retval = socket.BeginReceive(buffer, offset, count, SocketFlags.None, out errorCode, callback, state);
			if (errorCode == SocketError.Success)
			{
				return retval;
			}
			throw new IOException($"Failed to read from the socket '{socket.RemoteEndPoint}'. Error: {errorCode}");
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			SocketError errorCode;
			int retval = socket.EndReceive(asyncResult, out errorCode);
			if (errorCode == SocketError.Success && retval > 0)
			{
				return retval;
			}
			throw new IOException($"Failed to read from the socket '{socket.RemoteEndPoint}'. Error: {errorCode}");
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			SocketError errorCode;
			int retval = socket.Receive(buffer, offset, count, SocketFlags.None, out errorCode);
			if (errorCode == SocketError.Success && retval > 0)
			{
				return retval;
			}
			throw new IOException(string.Format("Failed to read from the socket '{0}'. Error: {1}", socket.RemoteEndPoint, (errorCode == SocketError.Success) ? "?" : errorCode.ToString()));
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}
	}

	private static readonly ILog log = LogManager.GetLogger(typeof(PooledSocket));

	private bool isAlive;

	private Socket socket;

	private IPEndPoint endpoint;

	private BufferedStream inputStream;

	private AsyncSocketHelper helper;

	/// <summary>
	/// The ID of this instance. Used by the <see cref="T:MemcachedServer" /> to identify the instance in its inner lists.
	/// </summary>
	public readonly Guid InstanceId = Guid.NewGuid();

	public Action<PooledSocket> CleanupCallback { get; set; }

	public int Available => socket.Available;

	public bool IsAlive => isAlive;

	public PooledSocket(IPEndPoint endpoint, TimeSpan connectionTimeout, TimeSpan receiveTimeout)
	{
		isAlive = true;
		Socket socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		socket.NoDelay = true;
		int timeout = ((connectionTimeout == TimeSpan.MaxValue) ? (-1) : ((int)connectionTimeout.TotalMilliseconds));
		socket.SendTimeout = (socket.ReceiveTimeout = ((receiveTimeout == TimeSpan.MaxValue) ? (-1) : ((int)receiveTimeout.TotalMilliseconds)));
		socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, optionValue: true);
		ConnectWithTimeout(socket, endpoint, timeout);
		this.socket = socket;
		this.endpoint = endpoint;
		inputStream = new BufferedStream(new BasicNetworkStream(socket));
	}

	private static void ConnectWithTimeout(Socket socket, IPEndPoint endpoint, int timeout)
	{
		ManualResetEvent mre = new ManualResetEvent(initialState: false);
		socket.BeginConnect(endpoint, delegate(IAsyncResult iar)
		{
			try
			{
				using (iar.AsyncWaitHandle)
				{
					socket.EndConnect(iar);
				}
			}
			catch
			{
			}
			mre.Set();
		}, null);
		if (!mre.WaitOne(timeout) || !socket.Connected)
		{
			using (socket)
			{
				throw new TimeoutException("Could not connect to " + endpoint);
			}
		}
	}

	public void Reset()
	{
		inputStream.Flush();
		if (helper != null)
		{
			helper.DiscardBuffer();
		}
		int available = socket.Available;
		if (available > 0)
		{
			if (log.IsWarnEnabled)
			{
				log.WarnFormat("Socket bound to {0} has {1} unread data! This is probably a bug in the code. InstanceID was {2}.", socket.RemoteEndPoint, available, InstanceId);
			}
			byte[] data = new byte[available];
			Read(data, 0, available);
			if (log.IsWarnEnabled)
			{
				log.Warn(Encoding.ASCII.GetString(data));
			}
		}
		if (log.IsDebugEnabled)
		{
			log.DebugFormat("Socket {0} was reset", InstanceId);
		}
	}

	/// <summary>
	/// Releases all resources used by this instance and shuts down the inner <see cref="T:Socket" />. This instance will not be usable anymore.
	/// </summary>
	/// <remarks>Use the IDisposable.Dispose method if you want to release this instance back into the pool.</remarks>
	public void Destroy()
	{
		Dispose(disposing: true);
	}

	~PooledSocket()
	{
		try
		{
			Dispose(disposing: true);
		}
		catch
		{
		}
	}

	protected void Dispose(bool disposing)
	{
		if (disposing)
		{
			GC.SuppressFinalize(this);
			try
			{
				if (socket != null)
				{
					try
					{
						socket.Close();
					}
					catch
					{
					}
				}
				if (inputStream != null)
				{
					inputStream.Dispose();
				}
				inputStream = null;
				socket = null;
				CleanupCallback = null;
				return;
			}
			catch (Exception e)
			{
				log.Error(e);
				return;
			}
		}
		CleanupCallback?.Invoke(this);
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: false);
	}

	private void CheckDisposed()
	{
		if (socket == null)
		{
			throw new ObjectDisposedException("PooledSocket");
		}
	}

	/// <summary>
	/// Reads the next byte from the server's response.
	/// </summary>
	/// <remarks>This method blocks and will not return until the value is read.</remarks>
	public int ReadByte()
	{
		CheckDisposed();
		try
		{
			return inputStream.ReadByte();
		}
		catch (IOException)
		{
			isAlive = false;
			throw;
		}
	}

	/// <summary>
	/// Reads data from the server into the specified buffer.
	/// </summary>
	/// <param name="buffer">An array of <see cref="T:System.Byte" /> that is the storage location for the received data.</param>
	/// <param name="offset">The location in buffer to store the received data.</param>
	/// <param name="count">The number of bytes to read.</param>
	/// <remarks>This method blocks and will not return until the specified amount of bytes are read.</remarks>
	public void Read(byte[] buffer, int offset, int count)
	{
		CheckDisposed();
		int read = 0;
		int shouldRead = count;
		while (read < count)
		{
			try
			{
				int currentRead = inputStream.Read(buffer, offset, shouldRead);
				if (currentRead >= 1)
				{
					read += currentRead;
					offset += currentRead;
					shouldRead -= currentRead;
				}
			}
			catch (IOException)
			{
				isAlive = false;
				throw;
			}
		}
	}

	public void Write(byte[] data, int offset, int length)
	{
		CheckDisposed();
		socket.Send(data, offset, length, SocketFlags.None, out var status);
		if (status != 0)
		{
			isAlive = false;
			ThrowHelper.ThrowSocketWriteError(endpoint, status);
		}
	}

	public void Write(IList<ArraySegment<byte>> buffers)
	{
		CheckDisposed();
		socket.Send(buffers, SocketFlags.None, out var status);
		if (status != 0)
		{
			isAlive = false;
			ThrowHelper.ThrowSocketWriteError(endpoint, status);
		}
	}

	/// <summary>
	/// Receives data asynchronously. Returns true if the IO is pending. Returns false if the socket already failed or the data was available in the buffer.
	/// p.Next will only be called if the call completes asynchronously.
	/// </summary>
	public bool ReceiveAsync(AsyncIOArgs p)
	{
		CheckDisposed();
		if (!IsAlive)
		{
			p.Fail = true;
			p.Result = null;
			return false;
		}
		if (helper == null)
		{
			helper = new AsyncSocketHelper(this);
		}
		return helper.Read(p);
	}
}

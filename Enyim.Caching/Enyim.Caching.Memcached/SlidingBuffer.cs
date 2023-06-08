using System;
using System.Threading;
using Enyim.Collections;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Supports exactly one reader and writer, but they can access the buffer concurrently.
/// </summary>
internal class SlidingBuffer
{
	private class Segment
	{
		public readonly byte[] Data;

		public int WriteOffset;

		public int ReadOffset;

		public Segment(byte[] data)
		{
			Data = data;
		}
	}

	private readonly InterlockedQueue<Segment> buffers;

	private readonly int chunkSize;

	private Segment lastSegment;

	private int available;

	public int Available => available;

	public SlidingBuffer(int chunkSize)
	{
		this.chunkSize = chunkSize;
		buffers = new InterlockedQueue<Segment>();
	}

	public int Read(byte[] buffer, int offset, int count)
	{
		int read = 0;
		Segment segment;
		while (read < count && buffers.Peek(out segment))
		{
			int available = Math.Min(segment.WriteOffset - segment.ReadOffset, count - read);
			if (available > 0)
			{
				Buffer.BlockCopy(segment.Data, segment.ReadOffset, buffer, offset + read, available);
				read += available;
				segment.ReadOffset += available;
			}
			if (segment.ReadOffset == segment.WriteOffset && lastSegment != segment)
			{
				buffers.Dequeue(out segment);
			}
		}
		Interlocked.Add(ref this.available, -read);
		return read;
	}

	public void Append(byte[] buffer, int offset, int count)
	{
		if (buffer == null || buffer.Length == 0 || count == 0)
		{
			return;
		}
		Segment last = lastSegment;
		bool shouldQueue = false;
		if (count > chunkSize)
		{
			last = new Segment(new byte[count]);
			shouldQueue = true;
		}
		else
		{
			int remaining = ((last != null) ? (last.Data.Length - last.WriteOffset) : 0);
			if (remaining < count)
			{
				last = new Segment(new byte[chunkSize]);
				shouldQueue = true;
			}
		}
		Buffer.BlockCopy(buffer, offset, last.Data, last.WriteOffset, count);
		if (shouldQueue)
		{
			Interlocked.Exchange(ref lastSegment, last);
			buffers.Enqueue(last);
		}
		Interlocked.Add(ref last.WriteOffset, count);
		Interlocked.Add(ref available, count);
	}

	public void UnsafeClear()
	{
		lastSegment = null;
		Segment tmp;
		while (buffers.Dequeue(out tmp))
		{
		}
		available = 0;
	}
}

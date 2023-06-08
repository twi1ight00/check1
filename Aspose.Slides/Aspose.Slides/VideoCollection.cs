using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ns223;

namespace Aspose.Slides;

public class VideoCollection : ICollection, IEnumerable, IEnumerable<IVideo>, IVideoCollection
{
	private readonly List<IVideo> list_0;

	private readonly Presentation presentation_0;

	private static readonly string[] string_0 = new string[14]
	{
		"video/mpeg", "mpg", "video/avi", "avi", "video/x-ms-wmv", "wmv", "video/unknown", "3gp", "video/unknown", "3g2",
		"video/unknown", "mp4", "video/unknown", "mkv"
	};

	private static readonly ushort[][] ushort_0 = new ushort[7][]
	{
		new ushort[4] { 0, 0, 1, 4016 },
		new ushort[16]
		{
			82, 73, 70, 70, 65280, 65280, 65280, 65280, 65, 86,
			73, 32, 76, 73, 83, 84
		},
		new ushort[16]
		{
			48, 38, 178, 117, 142, 102, 207, 17, 166, 217,
			0, 170, 0, 98, 206, 108
		},
		new ushort[11]
		{
			0, 0, 0, 20, 102, 116, 121, 112, 51, 103,
			112
		},
		new ushort[11]
		{
			0, 0, 0, 32, 102, 116, 121, 112, 51, 103,
			112
		},
		new ushort[8] { 0, 0, 0, 65280, 102, 116, 121, 112 },
		new ushort[16]
		{
			26, 69, 223, 163, 147, 66, 130, 136, 109, 97,
			116, 114, 111, 115, 107, 97
		}
	};

	public int Count => list_0.Count;

	public IVideo this[int index] => (Video)list_0[index];

	ICollection IVideoCollection.AsICollection => this;

	IEnumerable IVideoCollection.AsIEnumerable => this;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	internal VideoCollection(Presentation parent)
	{
		list_0 = new List<IVideo>();
		presentation_0 = parent;
	}

	public IVideo AddVideo(IVideo video)
	{
		Video video2 = (Video)video;
		foreach (Video item in list_0)
		{
			if (video2 == item)
			{
				return video;
			}
		}
		return AddVideo(video2.data, video2.PPTXUnsupportedProps.ContentType, video2.PPTXUnsupportedProps.Extension);
	}

	public IVideo AddVideo(Stream stream)
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[4096];
		while (true)
		{
			int num = stream.Read(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num);
		}
		array = memoryStream.ToArray();
		return AddVideo(array, null, null);
	}

	public IVideo AddVideo(byte[] videoData)
	{
		return AddVideo((byte[])videoData.Clone(), null, null);
	}

	internal Video AddVideo(byte[] videoData, string contentType, string extension)
	{
		uint num = Class5979.smethod_2(videoData);
		foreach (Video item in list_0)
		{
			if (item.CRC != num || item.data.Length != videoData.Length)
			{
				continue;
			}
			byte[] data = item.data;
			bool flag = false;
			for (int i = 0; i < videoData.Length; i++)
			{
				if (videoData[i] != data[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return item;
			}
		}
		int num2 = smethod_0(videoData);
		string text = "video/unknown";
		string text2 = "video";
		if (num2 >= 0)
		{
			text = string_0[num2 * 2];
			text2 = string_0[num2 * 2 + 1];
		}
		if (contentType == null || contentType.Length == 0)
		{
			contentType = text;
		}
		if (extension == null || extension.Length == 0)
		{
			extension = text2;
		}
		Video video2 = new Video(videoData, contentType, extension, presentation_0);
		list_0.Add(video2);
		return video2;
	}

	private static int smethod_0(byte[] data)
	{
		int num = 0;
		while (true)
		{
			if (num < ushort_0.Length)
			{
				ushort[] array = ushort_0[num];
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
				{
					ushort num2 = array[i];
					byte b = (byte)(~(num2 >> 8));
					if ((b & num2) != (b & data[i]))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	void ICollection.CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	public IEnumerator<IVideo> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}

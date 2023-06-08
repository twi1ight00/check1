using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ns223;

namespace Aspose.Slides;

public class AudioCollection : ICollection, IEnumerable, IEnumerable<IAudio>, IAudioCollection
{
	private readonly List<IAudio> list_0;

	private Presentation presentation_0;

	private static readonly string[] string_0 = new string[10] { "audio/wav", "wav", "audio/x-ms-wma", "wma", "audio/unknown", "mp3", "audio/unknown", "mp3", "audio/unknown", "m4a" };

	private static readonly ushort[][] ushort_0 = new ushort[5][]
	{
		new ushort[16]
		{
			82, 73, 70, 70, 65280, 65280, 65280, 65280, 87, 65,
			86, 69, 102, 109, 116, 32
		},
		new ushort[16]
		{
			48, 38, 178, 117, 142, 102, 207, 17, 166, 217,
			0, 170, 0, 98, 206, 108
		},
		new ushort[3] { 73, 68, 51 },
		new ushort[2] { 255, 8176 },
		new ushort[12]
		{
			0, 0, 0, 65280, 102, 116, 121, 112, 77, 52,
			65, 32
		}
	};

	public int Count => list_0.Count;

	public IAudio this[int index] => list_0[index];

	ICollection IAudioCollection.AsICollection => this;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	IEnumerable IAudioCollection.AsIEnumerable => this;

	internal AudioCollection(Presentation parent)
	{
		list_0 = new List<IAudio>();
		presentation_0 = parent;
	}

	public IAudio AddAudio(IAudio audio)
	{
		Audio audio2 = (Audio)audio;
		foreach (Audio item in list_0)
		{
			if (audio2 == item)
			{
				return audio;
			}
		}
		return AddAudio(audio2.data, audio2.PPTXUnsupportedProps.ContentType, audio2.PPTXUnsupportedProps.Extension);
	}

	public IAudio AddAudio(Stream stream)
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
		return AddAudio(array, null, null);
	}

	public IAudio AddAudio(byte[] audioData)
	{
		return AddAudio((byte[])audioData.Clone(), null, null);
	}

	internal Audio AddAudio(byte[] audioData, string contentType, string extension)
	{
		uint num = Class5979.smethod_2(audioData);
		foreach (Audio item in list_0)
		{
			if (item.CRC != num || item.data.Length != audioData.Length)
			{
				continue;
			}
			byte[] data = item.data;
			bool flag = false;
			for (int i = 0; i < audioData.Length; i++)
			{
				if (audioData[i] != data[i])
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
		int num2 = smethod_0(audioData);
		string text = "audio/unknown";
		string text2 = "audio";
		if (num2 >= 0)
		{
			text = string_0[num2 * 2];
			text2 = string_0[num2 * 2 + 1];
		}
		if (string.IsNullOrEmpty(contentType))
		{
			contentType = text;
		}
		if (string.IsNullOrEmpty(extension))
		{
			extension = text2;
		}
		Audio audio2 = new Audio(audioData, contentType, extension, presentation_0);
		list_0.Add(audio2);
		return audio2;
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

	public IEnumerator<IAudio> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}

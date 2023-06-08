using System;
using System.IO;
using Aspose.Slides;
using ns63;

namespace ns15;

internal static class Class209
{
	public static int smethod_0(IAudio sound, Class856 context)
	{
		Class2734 soundCollection = smethod_1(context);
		return smethod_2((Audio)sound, soundCollection);
	}

	private static Class2734 smethod_1(Class856 context)
	{
		Class2688 documentContainer = context.PptBinaryFile.PowerPointDocumentStream.DocumentContainer;
		Class2734 @class = documentContainer.SoundCollection;
		if (@class == null)
		{
			@class = new Class2734();
			@class.SoundCollectionAtom.SoundIdSeed = 0;
			documentContainer.method_2(@class);
		}
		return @class;
	}

	private static int smethod_2(Audio sound, Class2734 soundCollection)
	{
		int num = smethod_3(soundCollection);
		Class2733 @class = new Class2733();
		soundCollection.Records.Add(@class);
		@class.SoundName.String = sound.PPTUnsupportedProps.SoundName;
		string text = Path.GetExtension(sound.PPTUnsupportedProps.SoundName) ?? string.Empty;
		if (!text.Equals(".wav", StringComparison.OrdinalIgnoreCase) && !text.Equals(".aif", StringComparison.OrdinalIgnoreCase))
		{
			@class.SoundExtension.String = "wave";
		}
		else
		{
			@class.SoundExtension.String = text;
		}
		@class.Id = num;
		@class.SoundDataBlob.Data = sound.BinaryData;
		return num;
	}

	private static int smethod_3(Class2734 soundCollection)
	{
		return ++soundCollection.SoundCollectionAtom.SoundIdSeed;
	}
}

using System;
using Aspose.Slides;
using ns24;

namespace ns4;

internal class Class144 : IPresentationComponent
{
	private IPresentationComponent ipresentationComponent_0;

	private Class355 class355_0 = new Class355();

	private Class139 class139_0;

	private Class143 class143_0;

	private Class143 class143_1;

	private Class143 class143_2;

	private Class143 class143_3;

	private Class143 class143_4;

	private Class143 class143_5;

	private Class143 class143_6;

	private Class143 class143_7;

	private Class143 class143_8;

	private Class143 class143_9;

	private Class143 class143_10;

	private Class143 class143_11;

	private Class143 class143_12;

	private Class142 class142_0;

	private Class142 class142_1;

	private Class142 class142_2;

	private Class142 class142_3;

	private Class142 class142_4;

	private Class142 class142_5;

	private Class142 class142_6;

	private Class142 class142_7;

	private Class142 class142_8;

	private Class142 class142_9;

	private Class142 class142_10;

	private Class142 class142_11;

	private Class142 class142_12;

	internal Class355 PPTXUnsupportedProps => class355_0;

	public IPresentation Presentation => ipresentationComponent_0.Presentation;

	internal Class139 TblBackgroundStyle => class139_0;

	internal Class143 WholeTbl => class143_0;

	internal Class143 Band1H => class143_1;

	internal Class143 Band2H => class143_2;

	internal Class143 Band1V => class143_3;

	internal Class143 Band2V => class143_4;

	internal Class143 LastCol => class143_5;

	internal Class143 FirstCol => class143_6;

	internal Class143 LastRow => class143_7;

	internal Class143 SeCell => class143_8;

	internal Class143 SwCell => class143_9;

	internal Class143 FirstRow => class143_10;

	internal Class143 NeCell => class143_11;

	internal Class143 NwCell => class143_12;

	internal Class142 WholeTblText => class142_0;

	internal Class142 Band1HText => class142_1;

	internal Class142 Band2HText => class142_2;

	internal Class142 Band1VText => class142_3;

	internal Class142 Band2VText => class142_4;

	internal Class142 LastColText => class142_5;

	internal Class142 FirstColText => class142_6;

	internal Class142 LastRowText => class142_7;

	internal Class142 SeCellText => class142_8;

	internal Class142 SwCellText => class142_9;

	internal Class142 FirstRowText => class142_10;

	internal Class142 NeCellText => class142_11;

	internal Class142 NwCellText => class142_12;

	internal uint Version => class139_0.Version + class143_0.Version + class143_1.Version + class143_2.Version + class143_3.Version + class143_4.Version + class143_5.Version + class143_6.Version + class143_7.Version + class143_8.Version + class143_9.Version + class143_10.Version + class143_11.Version + class143_12.Version + class142_0.Version + class142_1.Version + class142_2.Version + class142_3.Version + class142_4.Version + class142_5.Version + class142_6.Version + class142_7.Version + class142_8.Version + class142_9.Version + class142_10.Version + class142_11.Version + class142_12.Version;

	internal Class144(IPresentationComponent parent, Guid id, string name)
	{
		ipresentationComponent_0 = parent;
		PPTXUnsupportedProps.Id = id;
		PPTXUnsupportedProps.Name = name;
		class139_0 = new Class139(this);
		class143_0 = new Class143(this);
		class143_1 = new Class143(this);
		class143_2 = new Class143(this);
		class143_3 = new Class143(this);
		class143_4 = new Class143(this);
		class143_5 = new Class143(this);
		class143_6 = new Class143(this);
		class143_7 = new Class143(this);
		class143_8 = new Class143(this);
		class143_9 = new Class143(this);
		class143_10 = new Class143(this);
		class143_11 = new Class143(this);
		class143_12 = new Class143(this);
		class142_0 = new Class142(this);
		class142_1 = new Class142(this);
		class142_2 = new Class142(this);
		class142_3 = new Class142(this);
		class142_4 = new Class142(this);
		class142_5 = new Class142(this);
		class142_6 = new Class142(this);
		class142_7 = new Class142(this);
		class142_8 = new Class142(this);
		class142_9 = new Class142(this);
		class142_10 = new Class142(this);
		class142_11 = new Class142(this);
		class142_12 = new Class142(this);
	}
}

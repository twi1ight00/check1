using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ns277;
using ns284;
using ns287;
using ns296;
using ns305;
using ns306;
using ns73;
using ns84;

namespace ns286;

internal class Class6886 : IEnumerable, IEnumerable<Class6886.Class6887>
{
	public class Class6887
	{
		private string string_0;

		private string string_1;

		public string Name => string_0;

		public string Value
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		public Class6887(string name, string value)
		{
			string_0 = name;
			string_1 = value;
		}
	}

	public class Class6888
	{
		public const string string_0 = "editbox";

		public const string string_1 = "combobox";

		public const string string_2 = "button";

		public const string string_3 = "radiobutton";

		public const string string_4 = "checkbox";

		public const string string_5 = "end";

		public const string string_6 = "content";
	}

	private Dictionary<string, Class6887> dictionary_0 = new Dictionary<string, Class6887>();

	private Class6772 class6772_0;

	public int Count => dictionary_0.Count;

	public string AbsolutePosition
	{
		get
		{
			return method_2("absolute-position");
		}
		set
		{
			method_1("absolute-position", value);
		}
	}

	public string ActiveState
	{
		get
		{
			return method_2("active-state");
		}
		set
		{
			method_1("active-state", value);
		}
	}

	public string AlignmentAdjust
	{
		get
		{
			return method_2("alignment-adjust");
		}
		set
		{
			method_1("alignment-adjust", value);
		}
	}

	public string AlignmentBaseline
	{
		get
		{
			return method_2("alignment-baseline");
		}
		set
		{
			method_1("alignment-baseline", value);
		}
	}

	public string AllowedHeightScale
	{
		get
		{
			return method_2("allowed-height-scale");
		}
		set
		{
			method_1("allowed-height-scale", value);
		}
	}

	public string AllowedWidthScale
	{
		get
		{
			return method_2("allowed-width-scale");
		}
		set
		{
			method_1("allowed-width-scale", value);
		}
	}

	public string AutoRestore
	{
		get
		{
			return method_2("auto-restore");
		}
		set
		{
			method_1("auto-restore", value);
		}
	}

	public string Azimuth
	{
		get
		{
			return method_2("azimuth");
		}
		set
		{
			method_1("azimuth", value);
		}
	}

	public string Background
	{
		get
		{
			return method_2("background");
		}
		set
		{
			method_1("background", value);
		}
	}

	public string BackgroundAttachment
	{
		get
		{
			return method_2("background-attachment");
		}
		set
		{
			method_1("background-attachment", value);
		}
	}

	public string BackgroundColor
	{
		get
		{
			return method_2("background-color");
		}
		set
		{
			method_1("background-color", value);
		}
	}

	public string BackgroundImage
	{
		get
		{
			return method_2("background-image");
		}
		set
		{
			method_1("background-image", value);
		}
	}

	public string BackgroundPosition
	{
		get
		{
			return method_2("background-position");
		}
		set
		{
			method_1("background-position", value);
		}
	}

	public string BackgroundPositionHorizontal
	{
		get
		{
			return method_2("background-position-horizontal");
		}
		set
		{
			method_1("background-position-horizontal", value);
		}
	}

	public string BackgroundPositionVertical
	{
		get
		{
			return method_2("background-position-vertical");
		}
		set
		{
			method_1("background-position-vertical", value);
		}
	}

	public string BackgroundRepeat
	{
		get
		{
			return method_2("background-repeat");
		}
		set
		{
			method_1("background-repeat", value);
		}
	}

	public string BaselineShift
	{
		get
		{
			return method_2("baseline-shift");
		}
		set
		{
			method_1("baseline-shift", value);
		}
	}

	public string BlankOrNotBlank
	{
		get
		{
			return method_2("blank-or-not-blank");
		}
		set
		{
			method_1("blank-or-not-blank", value);
		}
	}

	public string BlockProgressionDimension
	{
		get
		{
			return method_2("block-progression-dimension");
		}
		set
		{
			method_1("block-progression-dimension", value);
		}
	}

	public string Border
	{
		get
		{
			return method_2("border");
		}
		set
		{
			method_1("border", value);
		}
	}

	public string BorderAfterColor
	{
		get
		{
			return method_2("border-after-color");
		}
		set
		{
			method_1("border-after-color", value);
		}
	}

	public string BorderAfterPrecedence
	{
		get
		{
			return method_2("border-after-precedence");
		}
		set
		{
			method_1("border-after-precedence", value);
		}
	}

	public string BorderAfterStyle
	{
		get
		{
			return method_2("border-after-style");
		}
		set
		{
			method_1("border-after-style", value);
		}
	}

	public string BorderAfterWidth
	{
		get
		{
			return method_2("border-after-width");
		}
		set
		{
			method_1("border-after-width", value);
		}
	}

	public string BorderBeforeColor
	{
		get
		{
			return method_2("border-before-color");
		}
		set
		{
			method_1("border-before-color", value);
		}
	}

	public string BorderBeforePrecedence
	{
		get
		{
			return method_2("border-before-precedence");
		}
		set
		{
			method_1("border-before-precedence", value);
		}
	}

	public string BorderBeforeStyle
	{
		get
		{
			return method_2("border-before-style");
		}
		set
		{
			method_1("border-before-style", value);
		}
	}

	public string BorderBeforeWidth
	{
		get
		{
			return method_2("border-before-width");
		}
		set
		{
			method_1("border-before-width", value);
		}
	}

	public string BorderBottom
	{
		get
		{
			return method_2("border-bottom");
		}
		set
		{
			method_1("border-bottom", value);
		}
	}

	public string BorderBottomColor
	{
		get
		{
			return method_2("border-bottom-color");
		}
		set
		{
			method_1("border-bottom-color", value);
		}
	}

	public string BorderBottomStyle
	{
		get
		{
			return method_2("border-bottom-style");
		}
		set
		{
			method_1("border-bottom-style", value);
		}
	}

	public string BorderBottomWidth
	{
		get
		{
			return method_2("border-bottom-width");
		}
		set
		{
			method_1("border-bottom-width", value);
		}
	}

	public string BorderCollapse
	{
		get
		{
			return method_2("border-collapse");
		}
		set
		{
			method_1("border-collapse", value);
		}
	}

	public string BorderColor
	{
		get
		{
			return method_2("border-color");
		}
		set
		{
			method_1("border-color", value);
		}
	}

	public string BorderEndColor
	{
		get
		{
			return method_2("border-end-color");
		}
		set
		{
			method_1("border-end-color", value);
		}
	}

	public string BorderEndPrecedence
	{
		get
		{
			return method_2("border-end-precedence");
		}
		set
		{
			method_1("border-end-precedence", value);
		}
	}

	public string BorderEndStyle
	{
		get
		{
			return method_2("border-end-style");
		}
		set
		{
			method_1("border-end-style", value);
		}
	}

	public string BorderEndWidth
	{
		get
		{
			return method_2("border-end-width");
		}
		set
		{
			method_1("border-end-width", value);
		}
	}

	public string BorderLeft
	{
		get
		{
			return method_2("border-left");
		}
		set
		{
			method_1("border-left", value);
		}
	}

	public string BorderLeftColor
	{
		get
		{
			return method_2("border-left-color");
		}
		set
		{
			method_1("border-left-color", value);
		}
	}

	public string BorderLeftStyle
	{
		get
		{
			return method_2("border-left-style");
		}
		set
		{
			method_1("border-left-style", value);
		}
	}

	public string BorderLeftWidth
	{
		get
		{
			return method_2("border-left-width");
		}
		set
		{
			method_1("border-left-width", value);
		}
	}

	public string BorderRight
	{
		get
		{
			return method_2("border-right");
		}
		set
		{
			method_1("border-right", value);
		}
	}

	public string BorderRightColor
	{
		get
		{
			return method_2("border-right-color");
		}
		set
		{
			method_1("border-right-color", value);
		}
	}

	public string BorderRightStyle
	{
		get
		{
			return method_2("border-right-style");
		}
		set
		{
			method_1("border-right-style", value);
		}
	}

	public string BorderTopLeftRadiusHorizontal
	{
		get
		{
			return method_2("border-top-left-radius-h");
		}
		set
		{
			method_1("border-top-left-radius-h", value);
		}
	}

	public string BorderTopLeftRadiusVertical
	{
		get
		{
			return method_2("border-top-left-radius-w");
		}
		set
		{
			method_1("border-top-left-radius-w", value);
		}
	}

	public string BorderTopRightRadiusHorizontal
	{
		get
		{
			return method_2("border-top-right-radius-w");
		}
		set
		{
			method_1("border-top-right-radius-w", value);
		}
	}

	public string BorderTopRightRadiusVertical
	{
		get
		{
			return method_2("border-top-right-radius--w");
		}
		set
		{
			method_1("border-top-right-radius--w", value);
		}
	}

	public string BorderBottomRightRadiusHorizontal
	{
		get
		{
			return method_2("border-bottom-right-radius-w");
		}
		set
		{
			method_1("border-bottom-right-radius-w", value);
		}
	}

	public string BorderBottomRightRadiusVertical
	{
		get
		{
			return method_2("border-bottom-right-radius-w");
		}
		set
		{
			method_1("border-bottom-right-radius-w", value);
		}
	}

	public string BorderBottomLeftRadiusHorizontal
	{
		get
		{
			return method_2("border-bottom-left-radius-w");
		}
		set
		{
			method_1("border-bottom-left-radius-w", value);
		}
	}

	public string BorderBottomLeftRadiusVertical
	{
		get
		{
			return method_2("border-bottom-left-radius-w");
		}
		set
		{
			method_1("border-bottom-left-radius-w", value);
		}
	}

	public string BorderRightWidth
	{
		get
		{
			return method_2("border-right-width");
		}
		set
		{
			method_1("border-right-width", value);
		}
	}

	public string BorderSeparation
	{
		get
		{
			return method_2("border-separation");
		}
		set
		{
			method_1("border-separation", value);
		}
	}

	public string BorderSpacing
	{
		get
		{
			return method_2("border-spacing");
		}
		set
		{
			method_1("border-spacing", value);
		}
	}

	public string BorderStartColor
	{
		get
		{
			return method_2("border-start-color");
		}
		set
		{
			method_1("border-start-color", value);
		}
	}

	public string BorderStartPrecedence
	{
		get
		{
			return method_2("border-start-precedence");
		}
		set
		{
			method_1("border-start-precedence", value);
		}
	}

	public string BorderStartStyle
	{
		get
		{
			return method_2("border-start-style");
		}
		set
		{
			method_1("border-start-style", value);
		}
	}

	public string BorderStartWidth
	{
		get
		{
			return method_2("border-start-width");
		}
		set
		{
			method_1("border-start-width", value);
		}
	}

	public string BorderStyle
	{
		get
		{
			return method_2("border-style");
		}
		set
		{
			method_1("border-style", value);
		}
	}

	public string BorderTop
	{
		get
		{
			return method_2("border-top");
		}
		set
		{
			method_1("border-top", value);
		}
	}

	public string BorderTopColor
	{
		get
		{
			return method_2("border-top-color");
		}
		set
		{
			method_1("border-top-color", value);
		}
	}

	public string BorderTopStyle
	{
		get
		{
			return method_2("border-top-style");
		}
		set
		{
			method_1("border-top-style", value);
		}
	}

	public string BorderTopWidth
	{
		get
		{
			return method_2("border-top-width");
		}
		set
		{
			method_1("border-top-width", value);
		}
	}

	public string BorderWidth
	{
		get
		{
			return method_2("border-width");
		}
		set
		{
			method_1("border-width", value);
		}
	}

	public string Bottom
	{
		get
		{
			return method_2("bottom");
		}
		set
		{
			method_1("bottom", value);
		}
	}

	public string BreakAfter
	{
		get
		{
			return method_2("break-after");
		}
		set
		{
			method_1("break-after", value);
		}
	}

	public string BreakBefore
	{
		get
		{
			return method_2("break-before");
		}
		set
		{
			method_1("break-before", value);
		}
	}

	public string CaptionSide
	{
		get
		{
			return method_2("caption-side");
		}
		set
		{
			method_1("caption-side", value);
		}
	}

	public string CaseName
	{
		get
		{
			return method_2("case-name");
		}
		set
		{
			method_1("case-name", value);
		}
	}

	public string CaseTitle
	{
		get
		{
			return method_2("case-title");
		}
		set
		{
			method_1("case-title", value);
		}
	}

	public string ChangeBarClass
	{
		get
		{
			return method_2("change-bar-class");
		}
		set
		{
			method_1("change-bar-class", value);
		}
	}

	public string ChangeBarColor
	{
		get
		{
			return method_2("change-bar-color");
		}
		set
		{
			method_1("change-bar-color", value);
		}
	}

	public string ChangeBarOffset
	{
		get
		{
			return method_2("change-bar-offset");
		}
		set
		{
			method_1("change-bar-offset", value);
		}
	}

	public string ChangeBarPlacement
	{
		get
		{
			return method_2("change-bar-placement");
		}
		set
		{
			method_1("change-bar-placement", value);
		}
	}

	public string ChangeBarStyle
	{
		get
		{
			return method_2("change-bar-style");
		}
		set
		{
			method_1("change-bar-style", value);
		}
	}

	public string ChangeBarWidth
	{
		get
		{
			return method_2("change-bar-width");
		}
		set
		{
			method_1("change-bar-width", value);
		}
	}

	public string Character
	{
		get
		{
			return method_2("character");
		}
		set
		{
			method_1("character", value);
		}
	}

	public string Clear
	{
		get
		{
			return method_2("clear");
		}
		set
		{
			method_1("clear", value);
		}
	}

	public string Clip
	{
		get
		{
			return method_2("clip");
		}
		set
		{
			method_1("clip", value);
		}
	}

	public string Color
	{
		get
		{
			return method_2("color");
		}
		set
		{
			method_1("color", value);
		}
	}

	public string ColorProfileName
	{
		get
		{
			return method_2("color-profile-name");
		}
		set
		{
			method_1("color-profile-name", value);
		}
	}

	public string ColumnCount
	{
		get
		{
			return method_2("column-count");
		}
		set
		{
			method_1("column-count", value);
		}
	}

	public string ColumnGap
	{
		get
		{
			return method_2("column-gap");
		}
		set
		{
			method_1("column-gap", value);
		}
	}

	public string ColumnNumber
	{
		get
		{
			return method_2("column-number");
		}
		set
		{
			method_1("column-number", value);
		}
	}

	public string ColumnWidth
	{
		get
		{
			return method_2("column-width");
		}
		set
		{
			method_1("column-width", value);
		}
	}

	public string ContentHeight
	{
		get
		{
			return method_2("content-height");
		}
		set
		{
			method_1("content-height", value);
		}
	}

	public string ContentType
	{
		get
		{
			return method_2("content-type");
		}
		set
		{
			method_1("content-type", value);
		}
	}

	public string ContentWidth
	{
		get
		{
			return method_2("content-width");
		}
		set
		{
			method_1("content-width", value);
		}
	}

	public string ControlType
	{
		get
		{
			return method_2("control-type");
		}
		set
		{
			method_1("control-type", value);
		}
	}

	public string ControlHeight
	{
		get
		{
			return method_2("control-height");
		}
		set
		{
			method_1("control-height", value);
		}
	}

	public string ControlValue
	{
		get
		{
			return method_2("control-value");
		}
		set
		{
			method_1("control-value", value);
		}
	}

	public string ControlSelected
	{
		get
		{
			return method_2("control-selected");
		}
		set
		{
			method_1("control-selected", value);
		}
	}

	public string ControlWidth
	{
		get
		{
			return method_2("control-width");
		}
		set
		{
			method_1("control-width", value);
		}
	}

	public string Country
	{
		get
		{
			return method_2("country");
		}
		set
		{
			method_1("country", value);
		}
	}

	public string Cue
	{
		get
		{
			return method_2("cue");
		}
		set
		{
			method_1("cue", value);
		}
	}

	public string CueAfter
	{
		get
		{
			return method_2("cue-after");
		}
		set
		{
			method_1("cue-after", value);
		}
	}

	public string CueBefore
	{
		get
		{
			return method_2("cue-before");
		}
		set
		{
			method_1("cue-before", value);
		}
	}

	public string DestinationPlacementOffset
	{
		get
		{
			return method_2("destination-placement-offset");
		}
		set
		{
			method_1("destination-placement-offset", value);
		}
	}

	public string Direction
	{
		get
		{
			return method_2("direction");
		}
		set
		{
			method_1("direction", value);
		}
	}

	public string DisplayAlign
	{
		get
		{
			return method_2("display-align");
		}
		set
		{
			method_1("display-align", value);
		}
	}

	public string DominantBaseline
	{
		get
		{
			return method_2("dominant-baseline");
		}
		set
		{
			method_1("dominant-baseline", value);
		}
	}

	public string Elevation
	{
		get
		{
			return method_2("elevation");
		}
		set
		{
			method_1("elevation", value);
		}
	}

	public string EmptyCells
	{
		get
		{
			return method_2("empty-cells");
		}
		set
		{
			method_1("empty-cells", value);
		}
	}

	public string EndIndent
	{
		get
		{
			return method_2("end-indent");
		}
		set
		{
			method_1("end-indent", value);
		}
	}

	public string EndsRow
	{
		get
		{
			return method_2("ends-row");
		}
		set
		{
			method_1("ends-row", value);
		}
	}

	public string Extent
	{
		get
		{
			return method_2("extent");
		}
		set
		{
			method_1("extent", value);
		}
	}

	public string ExternalDestination
	{
		get
		{
			return method_2("external-destination");
		}
		set
		{
			method_1("external-destination", value);
		}
	}

	public string Float
	{
		get
		{
			return method_2("float");
		}
		set
		{
			method_1("float", value);
		}
	}

	public string FlowMapName
	{
		get
		{
			return method_2("flow-map-name");
		}
		set
		{
			method_1("flow-map-name", value);
		}
	}

	public string FlowMapReference
	{
		get
		{
			return method_2("flow-map-reference");
		}
		set
		{
			method_1("flow-map-reference", value);
		}
	}

	public string FlowName
	{
		get
		{
			return method_2("flow-name");
		}
		set
		{
			method_1("flow-name", value);
		}
	}

	public string FlowNameReference
	{
		get
		{
			return method_2("flow-name-reference");
		}
		set
		{
			method_1("flow-name-reference", value);
		}
	}

	public string Font
	{
		get
		{
			return method_2("font");
		}
		set
		{
			method_1("font", value);
		}
	}

	public string FontFamily
	{
		get
		{
			return method_2("font-family");
		}
		set
		{
			method_1("font-family", value);
		}
	}

	public string FontSelectionStrategy
	{
		get
		{
			return method_2("font-selection-strategy");
		}
		set
		{
			method_1("font-selection-strategy", value);
		}
	}

	public string FontSize
	{
		get
		{
			return method_2("font-size");
		}
		set
		{
			method_1("font-size", value);
		}
	}

	public string FontSizeAdjust
	{
		get
		{
			return method_2("font-size-adjust");
		}
		set
		{
			method_1("font-size-adjust", value);
		}
	}

	public string FontStretch
	{
		get
		{
			return method_2("font-stretch");
		}
		set
		{
			method_1("font-stretch", value);
		}
	}

	public string FontStyle
	{
		get
		{
			return method_2("font-style");
		}
		set
		{
			method_1("font-style", value);
		}
	}

	public string FontVariant
	{
		get
		{
			return method_2("font-variant");
		}
		set
		{
			method_1("font-variant", value);
		}
	}

	public string FontWeight
	{
		get
		{
			return method_2("font-weight");
		}
		set
		{
			method_1("font-weight", value);
		}
	}

	public string ForcePageCount
	{
		get
		{
			return method_2("force-page-count");
		}
		set
		{
			method_1("force-page-count", value);
		}
	}

	public string Format
	{
		get
		{
			return method_2("format");
		}
		set
		{
			method_1("format", value);
		}
	}

	public string GlyphOrientationHorizontal
	{
		get
		{
			return method_2("glyph-orientation-horizontal");
		}
		set
		{
			method_1("glyph-orientation-horizontal", value);
		}
	}

	public string GlyphOrientationVertical
	{
		get
		{
			return method_2("glyph-orientation-vertical");
		}
		set
		{
			method_1("glyph-orientation-vertical", value);
		}
	}

	public string GroupingSeparator
	{
		get
		{
			return method_2("grouping-separator");
		}
		set
		{
			method_1("grouping-separator", value);
		}
	}

	public string GroupingSize
	{
		get
		{
			return method_2("grouping-size");
		}
		set
		{
			method_1("grouping-size", value);
		}
	}

	public string Height
	{
		get
		{
			return method_2("height");
		}
		set
		{
			method_1("height", value);
		}
	}

	public string Hyphenate
	{
		get
		{
			return method_2("hyphenate");
		}
		set
		{
			method_1("hyphenate", value);
		}
	}

	public string HyphenationCharacter
	{
		get
		{
			return method_2("hyphenation-character");
		}
		set
		{
			method_1("hyphenation-character", value);
		}
	}

	public string HyphenationKeep
	{
		get
		{
			return method_2("hyphenation-keep");
		}
		set
		{
			method_1("hyphenation-keep", value);
		}
	}

	public string HyphenationLadderCount
	{
		get
		{
			return method_2("hyphenation-ladder-count");
		}
		set
		{
			method_1("hyphenation-ladder-count", value);
		}
	}

	public string HyphenationPushCharacterCount
	{
		get
		{
			return method_2("hyphenation-push-character-count");
		}
		set
		{
			method_1("hyphenation-push-character-count", value);
		}
	}

	public string HyphenationRemainCharacterCount
	{
		get
		{
			return method_2("hyphenation-remain-character-count");
		}
		set
		{
			method_1("hyphenation-remain-character-count", value);
		}
	}

	public string Id
	{
		get
		{
			return method_2("id");
		}
		set
		{
			method_1("id", value);
		}
	}

	public string IndexClass
	{
		get
		{
			return method_2("index-class");
		}
		set
		{
			method_1("index-class", value);
		}
	}

	public string IndexKey
	{
		get
		{
			return method_2("index-key");
		}
		set
		{
			method_1("index-key", value);
		}
	}

	public string IndicateDestination
	{
		get
		{
			return method_2("indicate-destination");
		}
		set
		{
			method_1("indicate-destination", value);
		}
	}

	public string InitialPageNumber
	{
		get
		{
			return method_2("initial-page-number");
		}
		set
		{
			method_1("initial-page-number", value);
		}
	}

	public string InlineProgressionDimension
	{
		get
		{
			return method_2("inline-progression-dimension");
		}
		set
		{
			method_1("inline-progression-dimension", value);
		}
	}

	public string InternalDestination
	{
		get
		{
			return method_2("internal-destination");
		}
		set
		{
			method_1("internal-destination", value);
		}
	}

	public string IntrinsicScaleValue
	{
		get
		{
			return method_2("intrinsic-scale-value");
		}
		set
		{
			method_1("intrinsic-scale-value", value);
		}
	}

	public string IntrusionDisplace
	{
		get
		{
			return method_2("intrusion-displace");
		}
		set
		{
			method_1("intrusion-displace", value);
		}
	}

	public string KeepTogether
	{
		get
		{
			return method_2("keep-together");
		}
		set
		{
			method_1("keep-together", value);
		}
	}

	public string KeepWithNext
	{
		get
		{
			return method_2("keep-with-next");
		}
		set
		{
			method_1("keep-with-next", value);
		}
	}

	public string KeepWithPrevious
	{
		get
		{
			return method_2("keep-with-previous");
		}
		set
		{
			method_1("keep-with-previous", value);
		}
	}

	public string Language
	{
		get
		{
			return method_2("language");
		}
		set
		{
			method_1("language", value);
		}
	}

	public string LastLineEndIndent
	{
		get
		{
			return method_2("last-line-end-indent");
		}
		set
		{
			method_1("last-line-end-indent", value);
		}
	}

	public string LeaderAlignment
	{
		get
		{
			return method_2("leader-alignment");
		}
		set
		{
			method_1("leader-alignment", value);
		}
	}

	public string LeaderLength
	{
		get
		{
			return method_2("leader-length");
		}
		set
		{
			method_1("leader-length", value);
		}
	}

	public string LeaderPattern
	{
		get
		{
			return method_2("leader-pattern");
		}
		set
		{
			method_1("leader-pattern", value);
		}
	}

	public string LeaderPatternWidth
	{
		get
		{
			return method_2("leader-pattern-width");
		}
		set
		{
			method_1("leader-pattern-width", value);
		}
	}

	public string Left
	{
		get
		{
			return method_2("left");
		}
		set
		{
			method_1("left", value);
		}
	}

	public string LetterSpacing
	{
		get
		{
			return method_2("letter-spacing");
		}
		set
		{
			method_1("letter-spacing", value);
		}
	}

	public string LetterValue
	{
		get
		{
			return method_2("letter-value");
		}
		set
		{
			method_1("letter-value", value);
		}
	}

	public string LinefeedTreatment
	{
		get
		{
			return method_2("linefeed-treatment");
		}
		set
		{
			method_1("linefeed-treatment", value);
		}
	}

	public string LineHeight
	{
		get
		{
			return method_2("line-height");
		}
		set
		{
			method_1("line-height", value);
		}
	}

	public string LineHeightShiftAdjustment
	{
		get
		{
			return method_2("line-height-shift-adjustment");
		}
		set
		{
			method_1("line-height-shift-adjustment", value);
		}
	}

	public string LineStackingStrategy
	{
		get
		{
			return method_2("line-stacking-strategy");
		}
		set
		{
			method_1("line-stacking-strategy", value);
		}
	}

	public string Margin
	{
		get
		{
			return method_2("margin");
		}
		set
		{
			method_1("margin", value);
		}
	}

	public string MarginBottom
	{
		get
		{
			return method_2("margin-bottom");
		}
		set
		{
			method_1("margin-bottom", value);
		}
	}

	public string MarginLeft
	{
		get
		{
			return method_2("margin-left");
		}
		set
		{
			method_1("margin-left", value);
		}
	}

	public string MarginRight
	{
		get
		{
			return method_2("margin-right");
		}
		set
		{
			method_1("margin-right", value);
		}
	}

	public string MarginTop
	{
		get
		{
			return method_2("margin-top");
		}
		set
		{
			method_1("margin-top", value);
		}
	}

	public string MarkerClassName
	{
		get
		{
			return method_2("marker-class-name");
		}
		set
		{
			method_1("marker-class-name", value);
		}
	}

	public string MasterName
	{
		get
		{
			return method_2("master-name");
		}
		set
		{
			method_1("master-name", value);
		}
	}

	public string MasterReference
	{
		get
		{
			return method_2("master-reference");
		}
		set
		{
			method_1("master-reference", value);
		}
	}

	public string MaxHeight
	{
		get
		{
			return method_2("max-height");
		}
		set
		{
			method_1("max-height", value);
		}
	}

	public string MaximumRepeats
	{
		get
		{
			return method_2("maximum-repeats");
		}
		set
		{
			method_1("maximum-repeats", value);
		}
	}

	public string MaxWidth
	{
		get
		{
			return method_2("max-width");
		}
		set
		{
			method_1("max-width", value);
		}
	}

	public string MediaUsage
	{
		get
		{
			return method_2("media-usage");
		}
		set
		{
			method_1("media-usage", value);
		}
	}

	public string MergePagesAcrossIndexKeyReferences
	{
		get
		{
			return method_2("merge-pages-across-index-key-references");
		}
		set
		{
			method_1("merge-pages-across-index-key-references", value);
		}
	}

	public string MergeRangesAcrossIndexKeyReferences
	{
		get
		{
			return method_2("merge-ranges-across-index-key-references");
		}
		set
		{
			method_1("merge-ranges-across-index-key-references", value);
		}
	}

	public string MergeSequentialPageNumbers
	{
		get
		{
			return method_2("merge-sequential-page-numbers");
		}
		set
		{
			method_1("merge-sequential-page-numbers", value);
		}
	}

	public string MinHeight
	{
		get
		{
			return method_2("min-height");
		}
		set
		{
			method_1("min-height", value);
		}
	}

	public string MinWidth
	{
		get
		{
			return method_2("min-width");
		}
		set
		{
			method_1("min-width", value);
		}
	}

	public string NumberColumnsRepeated
	{
		get
		{
			return method_2("number-columns-repeated");
		}
		set
		{
			method_1("number-columns-repeated", value);
		}
	}

	public string NumberColumnsSpanned
	{
		get
		{
			return method_2("number-columns-spanned");
		}
		set
		{
			method_1("number-columns-spanned", value);
		}
	}

	public string NumberRowsSpanned
	{
		get
		{
			return method_2("number-rows-spanned");
		}
		set
		{
			method_1("number-rows-spanned", value);
		}
	}

	public string OddOrEven
	{
		get
		{
			return method_2("odd-or-even");
		}
		set
		{
			method_1("odd-or-even", value);
		}
	}

	public string Orphans
	{
		get
		{
			return method_2("orphans");
		}
		set
		{
			method_1("orphans", value);
		}
	}

	public string Overflow
	{
		get
		{
			return method_2("overflow");
		}
		set
		{
			method_1("overflow", value);
		}
	}

	public string Outline
	{
		get
		{
			return method_2("outline");
		}
		set
		{
			method_1("outline", value);
		}
	}

	public string OutlineWidth
	{
		get
		{
			return method_2("outline-width");
		}
		set
		{
			method_1("outline-width", value);
		}
	}

	public string OutlineStyle
	{
		get
		{
			return method_2("outline-style");
		}
		set
		{
			method_1("outline-style", value);
		}
	}

	public string OutlineColor
	{
		get
		{
			return method_2("outline-color");
		}
		set
		{
			method_1("outline-color", value);
		}
	}

	public string Padding
	{
		get
		{
			return method_2("padding");
		}
		set
		{
			method_1("padding", value);
		}
	}

	public string PaddingAfter
	{
		get
		{
			return method_2("padding-after");
		}
		set
		{
			method_1("padding-after", value);
		}
	}

	public string PaddingBefore
	{
		get
		{
			return method_2("padding-before");
		}
		set
		{
			method_1("padding-before", value);
		}
	}

	public string PaddingBottom
	{
		get
		{
			return method_2("padding-bottom");
		}
		set
		{
			method_1("padding-bottom", value);
		}
	}

	public string PaddingEnd
	{
		get
		{
			return method_2("padding-end");
		}
		set
		{
			method_1("padding-end", value);
		}
	}

	public string PaddingLeft
	{
		get
		{
			return method_2("padding-left");
		}
		set
		{
			method_1("padding-left", value);
		}
	}

	public string PaddingRight
	{
		get
		{
			return method_2("padding-right");
		}
		set
		{
			method_1("padding-right", value);
		}
	}

	public string PaddingStart
	{
		get
		{
			return method_2("padding-start");
		}
		set
		{
			method_1("padding-start", value);
		}
	}

	public string PaddingTop
	{
		get
		{
			return method_2("padding-top");
		}
		set
		{
			method_1("padding-top", value);
		}
	}

	public string PageBreakAfter
	{
		get
		{
			return method_2("page-break-after");
		}
		set
		{
			method_1("page-break-after", value);
		}
	}

	public string PageBreakBefore
	{
		get
		{
			return method_2("page-break-before");
		}
		set
		{
			method_1("page-break-before", value);
		}
	}

	public string PageBreakInside
	{
		get
		{
			return method_2("page-break-inside");
		}
		set
		{
			method_1("page-break-inside", value);
		}
	}

	public string PageCitationStrategy
	{
		get
		{
			return method_2("page-citation-strategy");
		}
		set
		{
			method_1("page-citation-strategy", value);
		}
	}

	public string PageHeight
	{
		get
		{
			return method_2("page-height");
		}
		set
		{
			method_1("page-height", value);
		}
	}

	public string PageNumberTreatment
	{
		get
		{
			return method_2("page-number-treatment");
		}
		set
		{
			method_1("page-number-treatment", value);
		}
	}

	public string PagePosition
	{
		get
		{
			return method_2("page-position");
		}
		set
		{
			method_1("page-position", value);
		}
	}

	public string PageWidth
	{
		get
		{
			return method_2("page-width");
		}
		set
		{
			method_1("page-width", value);
		}
	}

	public string Pause
	{
		get
		{
			return method_2("pause");
		}
		set
		{
			method_1("pause", value);
		}
	}

	public string PauseAfter
	{
		get
		{
			return method_2("pause-after");
		}
		set
		{
			method_1("pause-after", value);
		}
	}

	public string PauseBefore
	{
		get
		{
			return method_2("pause-before");
		}
		set
		{
			method_1("pause-before", value);
		}
	}

	public string Pitch
	{
		get
		{
			return method_2("pitch");
		}
		set
		{
			method_1("pitch", value);
		}
	}

	public string PitchRange
	{
		get
		{
			return method_2("pitch-range");
		}
		set
		{
			method_1("pitch-range", value);
		}
	}

	public string PlayDuring
	{
		get
		{
			return method_2("play-during");
		}
		set
		{
			method_1("play-during", value);
		}
	}

	public string Position
	{
		get
		{
			return method_2("position");
		}
		set
		{
			method_1("position", value);
		}
	}

	public string Precedence
	{
		get
		{
			return method_2("precedence");
		}
		set
		{
			method_1("precedence", value);
		}
	}

	public string ProvisionalDistanceBetweenStarts
	{
		get
		{
			return method_2("provisional-distance-between-starts");
		}
		set
		{
			method_1("provisional-distance-between-starts", value);
		}
	}

	public string ProvisionalLabelSeparation
	{
		get
		{
			return method_2("provisional-label-separation");
		}
		set
		{
			method_1("provisional-label-separation", value);
		}
	}

	public string ReferenceOrientation
	{
		get
		{
			return method_2("reference-orientation");
		}
		set
		{
			method_1("reference-orientation", value);
		}
	}

	public string RefId
	{
		get
		{
			return method_2("ref-id");
		}
		set
		{
			method_1("ref-id", value);
		}
	}

	public string RefIndexKey
	{
		get
		{
			return method_2("ref-index-key");
		}
		set
		{
			method_1("ref-index-key", value);
		}
	}

	public string RegionName
	{
		get
		{
			return method_2("region-name");
		}
		set
		{
			method_1("region-name", value);
		}
	}

	public string RegionNameReference
	{
		get
		{
			return method_2("region-name-reference");
		}
		set
		{
			method_1("region-name-reference", value);
		}
	}

	public string RelativeAlign
	{
		get
		{
			return method_2("relative-align");
		}
		set
		{
			method_1("relative-align", value);
		}
	}

	public string RelativePosition
	{
		get
		{
			return method_2("relative-position");
		}
		set
		{
			method_1("relative-position", value);
		}
	}

	public string RenderingIntent
	{
		get
		{
			return method_2("rendering-intent");
		}
		set
		{
			method_1("rendering-intent", value);
		}
	}

	public string RetrieveBoundary
	{
		get
		{
			return method_2("retrieve-boundary");
		}
		set
		{
			method_1("retrieve-boundary", value);
		}
	}

	public string RetrieveBoundaryWithinTable
	{
		get
		{
			return method_2("retrieve-boundary-within-table");
		}
		set
		{
			method_1("retrieve-boundary-within-table", value);
		}
	}

	public string RetrieveClassName
	{
		get
		{
			return method_2("retrieve-class-name");
		}
		set
		{
			method_1("retrieve-class-name", value);
		}
	}

	public string RetrievePosition
	{
		get
		{
			return method_2("retrieve-position");
		}
		set
		{
			method_1("retrieve-position", value);
		}
	}

	public string RetrievePositionWithinTable
	{
		get
		{
			return method_2("retrieve-position-within-table");
		}
		set
		{
			method_1("retrieve-position-within-table", value);
		}
	}

	public string Richness
	{
		get
		{
			return method_2("richness");
		}
		set
		{
			method_1("richness", value);
		}
	}

	public string Right
	{
		get
		{
			return method_2("right");
		}
		set
		{
			method_1("right", value);
		}
	}

	public string Role
	{
		get
		{
			return method_2("role");
		}
		set
		{
			method_1("role", value);
		}
	}

	public string RuleStyle
	{
		get
		{
			return method_2("rule-style");
		}
		set
		{
			method_1("rule-style", value);
		}
	}

	public string RuleThickness
	{
		get
		{
			return method_2("rule-thickness");
		}
		set
		{
			method_1("rule-thickness", value);
		}
	}

	public string ScaleOption
	{
		get
		{
			return method_2("scale-option");
		}
		set
		{
			method_1("scale-option", value);
		}
	}

	public string Scaling
	{
		get
		{
			return method_2("scaling");
		}
		set
		{
			method_1("scaling", value);
		}
	}

	public string ScalingMethod
	{
		get
		{
			return method_2("scaling-method");
		}
		set
		{
			method_1("scaling-method", value);
		}
	}

	public string ScoreSpaces
	{
		get
		{
			return method_2("score-spaces");
		}
		set
		{
			method_1("score-spaces", value);
		}
	}

	public string Script
	{
		get
		{
			return method_2("script");
		}
		set
		{
			method_1("script", value);
		}
	}

	public string ShowDestination
	{
		get
		{
			return method_2("show-destination");
		}
		set
		{
			method_1("show-destination", value);
		}
	}

	public string Size
	{
		get
		{
			return method_2("size");
		}
		set
		{
			method_1("size", value);
		}
	}

	public string SourceDocument
	{
		get
		{
			return method_2("source-document");
		}
		set
		{
			method_1("source-document", value);
		}
	}

	public string SpaceAfter
	{
		get
		{
			return method_2("space-after");
		}
		set
		{
			method_1("space-after", value);
		}
	}

	public string SpaceBefore
	{
		get
		{
			return method_2("space-before");
		}
		set
		{
			method_1("space-before", value);
		}
	}

	public string SpaceEnd
	{
		get
		{
			return method_2("space-end");
		}
		set
		{
			method_1("space-end", value);
		}
	}

	public string SpaceStart
	{
		get
		{
			return method_2("space-start");
		}
		set
		{
			method_1("space-start", value);
		}
	}

	public string Span
	{
		get
		{
			return method_2("span");
		}
		set
		{
			method_1("span", value);
		}
	}

	public string Speak
	{
		get
		{
			return method_2("speak");
		}
		set
		{
			method_1("speak", value);
		}
	}

	public string SpeakHeader
	{
		get
		{
			return method_2("speak-header");
		}
		set
		{
			method_1("speak-header", value);
		}
	}

	public string SpeakNumeral
	{
		get
		{
			return method_2("speak-numeral");
		}
		set
		{
			method_1("speak-numeral", value);
		}
	}

	public string SpeakPunctuation
	{
		get
		{
			return method_2("speak-punctuation");
		}
		set
		{
			method_1("speak-punctuation", value);
		}
	}

	public string SpeechRate
	{
		get
		{
			return method_2("speech-rate");
		}
		set
		{
			method_1("speech-rate", value);
		}
	}

	public string Src
	{
		get
		{
			return method_2("src");
		}
		set
		{
			method_1("src", value);
		}
	}

	public string StartIndent
	{
		get
		{
			return method_2("start-indent");
		}
		set
		{
			method_1("start-indent", value);
		}
	}

	public string StartingState
	{
		get
		{
			return method_2("starting-state");
		}
		set
		{
			method_1("starting-state", value);
		}
	}

	public string StartsRow
	{
		get
		{
			return method_2("starts-row");
		}
		set
		{
			method_1("starts-row", value);
		}
	}

	public string Stress
	{
		get
		{
			return method_2("stress");
		}
		set
		{
			method_1("stress", value);
		}
	}

	public string SuppressAtLineBreak
	{
		get
		{
			return method_2("suppress-at-line-break");
		}
		set
		{
			method_1("suppress-at-line-break", value);
		}
	}

	public string SwitchTo
	{
		get
		{
			return method_2("switch-to");
		}
		set
		{
			method_1("switch-to", value);
		}
	}

	public string TableLayout
	{
		get
		{
			return method_2("table-layout");
		}
		set
		{
			method_1("table-layout", value);
		}
	}

	public string TableOmitFooterAtBreak
	{
		get
		{
			return method_2("table-omit-footer-at-break");
		}
		set
		{
			method_1("table-omit-footer-at-break", value);
		}
	}

	public string TableOmitHeaderAtBreak
	{
		get
		{
			return method_2("table-omit-header-at-break");
		}
		set
		{
			method_1("table-omit-header-at-break", value);
		}
	}

	public string TargetPresentationContext
	{
		get
		{
			return method_2("target-presentation-context");
		}
		set
		{
			method_1("target-presentation-context", value);
		}
	}

	public string TargetProcessingContext
	{
		get
		{
			return method_2("target-processing-context");
		}
		set
		{
			method_1("target-processing-context", value);
		}
	}

	public string TargetStylesheet
	{
		get
		{
			return method_2("target-stylesheet");
		}
		set
		{
			method_1("target-stylesheet", value);
		}
	}

	public string TextAlign
	{
		get
		{
			return method_2("text-align");
		}
		set
		{
			method_1("text-align", value);
		}
	}

	public string TextAlignLast
	{
		get
		{
			return method_2("text-align-last");
		}
		set
		{
			method_1("text-align-last", value);
		}
	}

	public string TextAltitude
	{
		get
		{
			return method_2("text-altitude");
		}
		set
		{
			method_1("text-altitude", value);
		}
	}

	public string TextDecoration
	{
		get
		{
			return method_2("text-decoration");
		}
		set
		{
			method_1("text-decoration", value);
		}
	}

	public string TextDepth
	{
		get
		{
			return method_2("text-depth");
		}
		set
		{
			method_1("text-depth", value);
		}
	}

	public string TextIndent
	{
		get
		{
			return method_2("text-indent");
		}
		set
		{
			method_1("text-indent", value);
		}
	}

	public string TextShadow
	{
		get
		{
			return method_2("text-shadow");
		}
		set
		{
			method_1("text-shadow", value);
		}
	}

	public string TextTransform
	{
		get
		{
			return method_2("text-transform");
		}
		set
		{
			method_1("text-transform", value);
		}
	}

	public string Top
	{
		get
		{
			return method_2("top");
		}
		set
		{
			method_1("top", value);
		}
	}

	public string TreatAsWordSpace
	{
		get
		{
			return method_2("treat-as-word-space");
		}
		set
		{
			method_1("treat-as-word-space", value);
		}
	}

	public string UnicodeBidi
	{
		get
		{
			return method_2("unicode-bidi");
		}
		set
		{
			method_1("unicode-bidi", value);
		}
	}

	public string VerticalAlign
	{
		get
		{
			return method_2("vertical-align");
		}
		set
		{
			method_1("vertical-align", value);
		}
	}

	public string Visibility
	{
		get
		{
			return method_2("visibility");
		}
		set
		{
			method_1("visibility", value);
		}
	}

	public string VoiceFamily
	{
		get
		{
			return method_2("voice-family");
		}
		set
		{
			method_1("voice-family", value);
		}
	}

	public string Volume
	{
		get
		{
			return method_2("volume");
		}
		set
		{
			method_1("volume", value);
		}
	}

	public string WhiteSpace
	{
		get
		{
			return method_2("white-space");
		}
		set
		{
			method_1("white-space", value);
		}
	}

	public string WhiteSpaceCollapse
	{
		get
		{
			return method_2("white-space-collapse");
		}
		set
		{
			method_1("white-space-collapse", value);
		}
	}

	public string WhiteSpaceTreatment
	{
		get
		{
			return method_2("white-space-treatment");
		}
		set
		{
			method_1("white-space-treatment", value);
		}
	}

	public string Widows
	{
		get
		{
			return method_2("widows");
		}
		set
		{
			method_1("widows", value);
		}
	}

	public string Width
	{
		get
		{
			return method_2("width");
		}
		set
		{
			method_1("width", value);
		}
	}

	public string WordSpacing
	{
		get
		{
			return method_2("word-spacing");
		}
		set
		{
			method_1("word-spacing", value);
		}
	}

	public string WrapOption
	{
		get
		{
			return method_2("wrap-option");
		}
		set
		{
			method_1("wrap-option", value);
		}
	}

	public string WritingMode
	{
		get
		{
			return method_2("writing-mode");
		}
		set
		{
			method_1("writing-mode", value);
		}
	}

	public string XmlLang
	{
		get
		{
			return method_2("xml:lang");
		}
		set
		{
			method_1("xml:lang", value);
		}
	}

	public string ZIndex
	{
		get
		{
			return method_2("z-index");
		}
		set
		{
			method_1("z-index", value);
		}
	}

	public string BackgroundAllPage
	{
		get
		{
			return method_2("background-all-page");
		}
		set
		{
			method_1("background-all-page", value);
		}
	}

	public string HtmlBody
	{
		get
		{
			return method_2("html-body");
		}
		set
		{
			method_1("html-body", value);
		}
	}

	public Class6886(Class6772 builder)
	{
		class6772_0 = builder;
	}

	public Class6886(Class6772 builder, Class6983 element, Interface355 settings)
		: this(builder, element, element.StyleDeclarationInternal, settings)
	{
	}

	public Class6886(Class6772 builder, Class6983 element, Class4347 model, Interface355 settings)
		: this(builder)
	{
		Initialize(element, model, settings);
	}

	public IEnumerator<Class6887> GetEnumerator()
	{
		return dictionary_0.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private Class6887 method_0(string name)
	{
		if (dictionary_0.ContainsKey(name))
		{
			return dictionary_0[name];
		}
		return null;
	}

	private void method_1(string name, string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			if (dictionary_0.ContainsKey(name))
			{
				dictionary_0.Remove(name);
			}
		}
		else if (dictionary_0.ContainsKey(name))
		{
			dictionary_0[name].Value = value;
		}
		else
		{
			dictionary_0.Add(name, new Class6887(name, value));
		}
	}

	private string method_2(string name)
	{
		return method_0(name)?.Value;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (IEnumerator<Class6887> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class6887 current = enumerator.Current;
				stringBuilder.AppendFormat("{0}=\"{1}\" ", current.Name, current.Value);
			}
		}
		if (stringBuilder.Length == 0)
		{
			return string.Empty;
		}
		return stringBuilder.ToString(0, stringBuilder.Length - 1);
	}

	public void Initialize(Class6983 element, Class4347 model, Interface355 settings)
	{
		Id = class6772_0.Binder.method_0(element);
		foreach (Enum600 item in model.method_5())
		{
			if (!model.method_3(item, element) || (element is Class6995 && (Enum600.const_61 == item || Enum600.const_53 == item || Enum600.const_36 == item || Enum600.const_48 == item)))
			{
				continue;
			}
			switch (item)
			{
			case Enum600.const_90:
				if (element.TagName == "TABLE")
				{
					if (model.Direction == Enum632.const_0)
					{
						WritingMode = "lr-tb";
					}
					else
					{
						WritingMode = "rl-tb";
					}
				}
				Direction = Class4342.smethod_2(model.Direction);
				break;
			case Enum600.const_92:
				DominantBaseline = Class4342.smethod_2(model.DominantBaseline);
				break;
			case Enum600.const_81:
				ColumnWidth = model.Column.Width.ToString();
				break;
			case Enum600.const_2:
				AlignmentAdjust = model.AlignmentAdjust.ToString();
				break;
			case Enum600.const_3:
				AlignmentBaseline = Class4342.smethod_2(model.AlignmentBaseline);
				break;
			case Enum600.const_14:
				Azimuth = model.Azimuth.ToString();
				break;
			case Enum600.const_16:
				Background = model.Background.ToString();
				break;
			case Enum600.const_17:
				BackgroundAttachment = Class4342.smethod_2(model.Background.Attachment);
				break;
			case Enum600.const_19:
				BackgroundColor = new Class6809(element, model.Background.Color).vmethod_0();
				break;
			case Enum600.const_20:
				BackgroundImage = new Class6810(element, settings, class6772_0).vmethod_0();
				break;
			case Enum600.const_22:
				BackgroundPositionHorizontal = model.Background.Position.Horizontal.ToString();
				BackgroundPositionVertical = model.Background.Position.Vertical.ToString();
				break;
			case Enum600.const_23:
				BackgroundRepeat = new Class6811(element).vmethod_0();
				break;
			case Enum600.const_25:
				BaselineShift = model.BaselineShift.ToString();
				break;
			case Enum600.const_31:
				Border = model.Border.ToString();
				break;
			case Enum600.const_32:
				BorderBottom = model.Border.Bottom.ToString();
				break;
			case Enum600.const_33:
				BorderBottomColor = new Class6809(element, model.Border.Bottom.Color).vmethod_0();
				break;
			case Enum600.const_34:
				BorderBottomLeftRadiusHorizontal = model.Border.Radius.BottomLeft.Horizontal.ToString();
				BorderBottomLeftRadiusVertical = model.Border.Radius.BottomLeft.Vertical.ToString();
				break;
			case Enum600.const_35:
				BorderBottomRightRadiusHorizontal = model.Border.Radius.BottomRight.Horizontal.ToString();
				BorderBottomRightRadiusVertical = model.Border.Radius.BottomRight.Vertical.ToString();
				break;
			case Enum600.const_36:
				BorderBottomStyle = Class4342.smethod_2(model.Border.Bottom.Style);
				break;
			case Enum600.const_37:
				BorderBottomWidth = model.Border.Bottom.Width.ToString();
				break;
			case Enum600.const_38:
				BorderCollapse = Class4342.smethod_2(model.Border.Collapse);
				break;
			case Enum600.const_47:
				BorderLeftColor = new Class6809(element, model.Border.Left.Color).vmethod_0();
				break;
			case Enum600.const_48:
				BorderLeftStyle = Class4342.smethod_2(model.Border.Left.Style);
				break;
			case Enum600.const_49:
				BorderLeftWidth = model.Border.Left.Width.ToString();
				break;
			case Enum600.const_52:
				BorderRightColor = new Class6809(element, model.Border.Right.Color).vmethod_0();
				break;
			case Enum600.const_53:
				BorderRightStyle = Class4342.smethod_2(model.Border.Right.Style);
				break;
			case Enum600.const_54:
				BorderRightWidth = model.Border.Right.Width.ToString();
				break;
			case Enum600.const_55:
				BorderSpacing = model.Border.Spacing.ToString();
				break;
			case Enum600.const_58:
				BorderTopColor = new Class6809(element, model.Border.Top.Color).vmethod_0();
				break;
			case Enum600.const_59:
				BorderTopLeftRadiusHorizontal = model.Border.Radius.TopLeft.Horizontal.ToString();
				BorderTopLeftRadiusVertical = model.Border.Radius.TopLeft.Vertical.ToString();
				break;
			case Enum600.const_60:
				BorderTopRightRadiusHorizontal = model.Border.Radius.TopRight.Horizontal.ToString();
				BorderTopRightRadiusVertical = model.Border.Radius.TopRight.Vertical.ToString();
				break;
			case Enum600.const_61:
				BorderTopStyle = Class4342.smethod_2(model.Border.Top.Style);
				break;
			case Enum600.const_62:
				BorderTopWidth = model.Border.Top.Width.ToString();
				break;
			case Enum600.const_64:
				Bottom = model.Bottom.ToString();
				break;
			case Enum600.const_68:
				CaptionSide = Class4342.smethod_2(model.CaptionSide);
				break;
			case Enum600.const_69:
				Clear = Class4342.smethod_2(model.Clear);
				break;
			case Enum600.const_70:
				Clip = model.Clip.ToString();
				break;
			case Enum600.const_71:
				Color = new Class6809(element, model.Color).vmethod_0();
				break;
			case Enum600.const_72:
				ColumnCount = model.Column.Count.ToString();
				break;
			case Enum600.const_74:
				ColumnGap = model.Column.Gap.ToString();
				break;
			case Enum600.const_110:
				Float = Class4342.smethod_2(model.Float);
				break;
			case Enum600.const_112:
				Font = model.Font.ToString();
				break;
			case Enum600.const_113:
				FontFamily = new Class6812(element).vmethod_0();
				break;
			case Enum600.const_115:
				FontSize = new Class6808(element).vmethod_0();
				break;
			case Enum600.const_116:
				FontSizeAdjust = model.Font.SizeAdjust.ToString();
				break;
			case Enum600.const_117:
				FontStretch = Class4342.smethod_2(model.Font.Stretch);
				break;
			case Enum600.const_118:
				FontStyle = Class4342.smethod_2(model.Font.Style);
				break;
			case Enum600.const_120:
				FontVariant = Class4342.smethod_2(model.Font.Variant.Caps);
				break;
			case Enum600.const_126:
				FontWeight = new Class6813(element).vmethod_0();
				break;
			case Enum600.const_99:
				Elevation = model.Elevation.ToString();
				break;
			case Enum600.const_100:
				EmptyCells = Class4342.smethod_2(model.EmptyCells);
				break;
			case Enum600.const_149:
				Left = model.Left.ToString();
				break;
			case Enum600.const_150:
				LetterSpacing = model.LetterSpacing.ToString();
				break;
			case Enum600.const_152:
				LineHeight = model.LineHeight.ToString();
				break;
			case Enum600.const_156:
				LineStackingStrategy = Class4342.smethod_2(model.LineStacking.Strategy);
				break;
			case Enum600.const_161:
				Margin = model.Margin.ToString();
				break;
			case Enum600.const_162:
				if (element.TagName == "P" && !element.method_9(element.NamespaceURI))
				{
					break;
				}
				if (!model.Margin.Bottom.Auto && model.Margin.Bottom.Value.Value == 1.12f && model.Margin.Bottom.Value.Type == Enum634.const_2 && element is Class7030)
				{
					Class7050 class3 = element.OwnerDocument.Doctype as Class7050;
					if (smethod_1<Class7038>(element))
					{
						if (class3 != null && class3.IsHTMLStrict)
						{
							MarginBottom = model.Margin.Bottom.ToString();
						}
						else
						{
							MarginBottom = "auto";
						}
					}
					else
					{
						MarginBottom = model.Margin.Bottom.ToString();
					}
				}
				else
				{
					MarginBottom = model.Margin.Bottom.ToString();
				}
				break;
			case Enum600.const_163:
				if (!(element.TagName == "P") || element.method_9(element.NamespaceURI))
				{
					MarginLeft = model.Margin.Left.ToString();
				}
				break;
			case Enum600.const_164:
				if (!(element.TagName == "P") || element.method_9(element.NamespaceURI))
				{
					MarginRight = model.Margin.Right.ToString();
				}
				break;
			case Enum600.const_165:
				if (element.TagName == "P" && !element.method_9(element.NamespaceURI))
				{
					break;
				}
				if (!model.Margin.Top.Auto && model.Margin.Top.Value.Value == 1.12f && model.Margin.Top.Value.Type == Enum634.const_2 && element is Class7030)
				{
					Class7050 class2 = element.OwnerDocument.Doctype as Class7050;
					if (smethod_0<Class7038>(element))
					{
						if (class2 != null && class2.IsHTMLStrict)
						{
							MarginTop = model.Margin.Top.ToString();
						}
						else
						{
							MarginTop = "auto";
						}
					}
					else
					{
						MarginTop = model.Margin.Top.ToString();
					}
				}
				else
				{
					MarginTop = model.Margin.Top.ToString();
				}
				break;
			case Enum600.const_141:
			{
				if (element.StyleDeclarationInternal.Position == Enum633.const_2)
				{
					Height = model.Height.ToString();
					break;
				}
				Class6983 @class = element.ParentNode as Class6983;
				if (!model.Height.IsAuto && model.Height.Value.Type == Enum634.const_1 && @class != null)
				{
					if (!@class.StyleDeclarationInternal.Height.IsAuto && @class.StyleDeclarationInternal.Height.Value.Type != Enum634.const_1)
					{
						float unitValue = @class.StyleDeclarationInternal.Height.Value.Value / 100f * model.Height.Value.Value;
						string contentHeight = (Height = new Class4337(unitValue, @class.StyleDeclarationInternal.Height.Value.Type).ToString());
						ContentHeight = contentHeight;
					}
					else if (@class.TagName.EndsWith("body", StringComparison.OrdinalIgnoreCase))
					{
						Height = model.Height.ToString();
					}
				}
				else
				{
					string contentHeight2 = (Height = model.Height.ToString());
					ContentHeight = contentHeight2;
				}
				break;
			}
			case Enum600.const_220:
				Richness = model.Richness.ToString();
				break;
			case Enum600.const_221:
				Right = model.Right.ToString();
				break;
			case Enum600.const_172:
				MaxHeight = model.MaxHeight.ToString();
				break;
			case Enum600.const_173:
				MaxWidth = model.MaxWidth.ToString();
				break;
			case Enum600.const_174:
				MinHeight = model.MinHeight.ToString();
				break;
			case Enum600.const_175:
				MinWidth = model.MinWidth.ToString();
				break;
			case Enum600.const_186:
				Orphans = model.Orphans.ToString();
				break;
			case Enum600.const_188:
			{
				if (!model.Outline.Color.Invert)
				{
					OutlineColor = new Class6809(element, model.Outline.Color.Color).vmethod_0();
					break;
				}
				Color color = model.Background.Color;
				color = System.Drawing.Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
				OutlineColor = new Class6809(element, color).vmethod_0();
				break;
			}
			case Enum600.const_190:
				OutlineStyle = Class4342.smethod_2(model.Outline.Style);
				break;
			case Enum600.const_191:
				OutlineWidth = model.Outline.Width.ToString();
				break;
			case Enum600.const_195:
				Overflow = Class4342.smethod_2(model.Overflow.X);
				break;
			case Enum600.const_196:
				Overflow = Class4342.smethod_2(model.Overflow.Y);
				break;
			case Enum600.const_197:
				Padding = model.Padding.ToString();
				break;
			case Enum600.const_198:
				PaddingBottom = model.Padding.Bottom.ToString();
				break;
			case Enum600.const_199:
				PaddingLeft = model.Padding.Left.ToString();
				break;
			case Enum600.const_200:
				PaddingRight = model.Padding.Right.ToString();
				break;
			case Enum600.const_201:
				PaddingTop = model.Padding.Top.ToString();
				break;
			case Enum600.const_202:
				PageBreakAfter = Class4342.smethod_2(model.PageBreakAfter);
				break;
			case Enum600.const_203:
				PageBreakBefore = Class4342.smethod_2(model.PageBreakBefore);
				break;
			case Enum600.const_204:
				PageBreakInside = Class4342.smethod_2(model.PageBreakInside);
				break;
			case Enum600.const_211:
				Pitch = model.Pitch.ToString();
				break;
			case Enum600.const_212:
				PitchRange = model.PitchRange.ToString();
				break;
			case Enum600.const_213:
				PlayDuring = model.PlayDuring.ToString();
				break;
			case Enum600.const_214:
				_ = model.Display.Value;
				if (model.Position == Enum633.const_1)
				{
					if (element.FirstChild != null && element.FirstChild is Class6994 && ((Class6994)element.FirstChild).Type.ToLowerInvariant() == "image/svg+xml")
					{
						Position = "absolute";
					}
					else
					{
						Position = "absoluterelative";
					}
				}
				else if (model.Position != 0)
				{
					Position = Class4342.smethod_2(model.Position);
				}
				break;
			case Enum600.const_245:
				TextDecoration = new Class6807(element, model).vmethod_0();
				break;
			case Enum600.const_237:
				TableLayout = Class4342.smethod_2(model.TableLayout);
				break;
			case Enum600.const_239:
				TextAlign = Class4342.smethod_2(model.TextAlign);
				break;
			case Enum600.const_240:
				TextAlignLast = Class4342.smethod_2(model.TextAlignLast);
				break;
			case Enum600.const_257:
				TextShadow = model.TextShadow.ToString();
				break;
			case Enum600.const_259:
				TextTransform = Class4342.smethod_2(model.TextTransform);
				break;
			case Enum600.const_261:
				Top = model.Top.ToString();
				break;
			case Enum600.const_253:
				TextIndent = model.TextIndent.ToString();
				break;
			case Enum600.const_282:
				WhiteSpace = Class4342.smethod_2(model.WhiteSpace);
				if (model.WhiteSpace == Enum611.const_1)
				{
					WhiteSpaceCollapse = "false";
					WrapOption = "no-wrap";
					LinefeedTreatment = "preserve";
					WhiteSpaceTreatment = "preserve";
				}
				break;
			case Enum600.const_283:
				Widows = model.Widows.ToString();
				break;
			case Enum600.const_284:
				if (!(element is Class7035) && !(element is Class6995) && !(element is Class7003) && !(element is Class7042) && element.StyleDeclarationInternal.Display.Value != 0)
				{
					Width = model.Width.ToString();
				}
				else if (element.TagName == "IMG")
				{
					string contentWidth = (Width = model.Width.ToString());
					ContentWidth = contentWidth;
				}
				break;
			case Enum600.const_286:
				WordSpacing = model.WordSpacing.ToString();
				break;
			case Enum600.const_287:
				WritingMode = Class4342.smethod_2(model.WritingMode);
				break;
			case Enum600.const_288:
				ZIndex = model.ZIndex.ToString();
				break;
			case Enum600.const_290:
				BreakAfter = Class4342.smethod_2(model.BreakAfter);
				break;
			case Enum600.const_291:
				BreakBefore = Class4342.smethod_2(model.BreakBefore);
				break;
			case Enum600.const_270:
				UnicodeBidi = Class4342.smethod_2(model.UnicodeBidi);
				break;
			case Enum600.const_271:
				if (element.StyleDeclarationInternal.Display.Value == Enum630.const_14 && element.StyleDeclarationInternal.VerticalAlign.IsEnumValue)
				{
					switch (element.StyleDeclarationInternal.VerticalAlign.Align)
					{
					case Enum631.const_3:
						DisplayAlign = "before";
						break;
					case Enum631.const_5:
						DisplayAlign = "center";
						break;
					case Enum631.const_6:
						DisplayAlign = "after";
						break;
					}
				}
				VerticalAlign = model.VerticalAlign.ToString();
				break;
			case Enum600.const_272:
				Visibility = Class4342.smethod_2(model.Visibility);
				break;
			}
		}
	}

	private static bool smethod_0<TParent>(Class6982 element) where TParent : Class6982
	{
		while (element != null && element.PreviousSibling == null && element.ParentNode != null && element.ParentNode.NodeType == Enum969.const_0)
		{
			element = (Class6982)element.ParentNode;
			if (element is TParent)
			{
				return true;
			}
		}
		return false;
	}

	private static bool smethod_1<TParent>(Class6982 element) where TParent : Class6982
	{
		while (element != null && element.NextSibling == null && element.ParentNode != null && element.ParentNode.NodeType == Enum969.const_0)
		{
			element = (Class6982)element.ParentNode;
			if (element is TParent)
			{
				return true;
			}
		}
		return false;
	}

	public Class6886 method_3(Class6886 properties)
	{
		foreach (Class6887 property in properties)
		{
			method_1(property.Name, property.Value);
		}
		return this;
	}
}

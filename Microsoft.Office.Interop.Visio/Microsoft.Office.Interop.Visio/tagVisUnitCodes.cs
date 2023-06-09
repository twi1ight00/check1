using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C00-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisUnitCodes
{
	visNumber = 32,
	visPercent = 33,
	visAcre = 36,
	visHectare = 37,
	visDate = 40,
	visDurationUnits = 42,
	visElapsedWeek = 43,
	visElapsedDay = 44,
	visElapsedHour = 45,
	visElapsedMin = 46,
	visElapsedSec = 47,
	visTypeUnits = 48,
	visPicasAndPoints = 49,
	visPoints = 50,
	visPicas = 51,
	visCicerosAndDidots = 52,
	visDidots = 53,
	visCiceros = 54,
	visPageUnits = 63,
	visDrawingUnits = 64,
	visInches = 65,
	visFeet = 66,
	visFeetAndInches = 67,
	visMiles = 68,
	visCentimeters = 69,
	visMillimeters = 70,
	visMeters = 71,
	visKilometers = 72,
	visInchFrac = 73,
	visMileFrac = 74,
	visYards = 75,
	visNautMiles = 76,
	visAngleUnits = 80,
	visDegrees = 81,
	visDegreeMinSec = 82,
	visRadians = 83,
	visMin = 84,
	visSec = 85,
	visUnitsGUID = 95,
	visCurrency = 111,
	visUnitsNURBS = 138,
	visUnitsPolyline = 139,
	visUnitsPoint = 225,
	visUnitsString = 231,
	visUnitsColor = 251,
	visNoCast = 252,
	visUnitsInval = 255
}

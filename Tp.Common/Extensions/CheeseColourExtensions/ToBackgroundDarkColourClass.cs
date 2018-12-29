using Tp.Common.Constants;

namespace Tp.Common.Extensions.CheeseColourExtensions
{
    public static partial class CheeseColourExtensions
    {
        public static string ToBackgroundDarkColourClass(this CheeseColour cheeseColour)
        {
            return $"bg-{cheeseColour.ToColourClass()}-dark";
        }
    }
}
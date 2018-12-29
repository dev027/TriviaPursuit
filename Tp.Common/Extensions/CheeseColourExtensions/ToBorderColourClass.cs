using Tp.Common.Constants;

namespace Tp.Common.Extensions.CheeseColourExtensions
{
    public static partial class CheeseColourExtensions
    {
        public static string ToBackgroundColourClass(this CheeseColour cheeseColour)
        {
            return $"bg-{cheeseColour.ToColourClass()}";
        }
    }
}
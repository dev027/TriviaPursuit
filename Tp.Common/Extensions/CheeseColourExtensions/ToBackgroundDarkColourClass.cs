using Tp.Common.Constants;

namespace Tp.Common.Extensions.CheeseColourExtensions
{
    public static partial class CheeseColourExtensions
    {
        public static string ToDarkBackgroundColourClass(this CheeseColour cheeseColour)
        {
            return cheeseColour.ToBackgroundColourClass() + "-dark";
        }
    }
}
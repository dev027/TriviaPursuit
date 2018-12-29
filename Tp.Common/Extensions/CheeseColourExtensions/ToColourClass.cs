using System;
using Tp.Common.Constants;

namespace Tp.Common.Extensions.CheeseColourExtensions
{
    public static partial class CheeseColourExtensions
    {
        internal static string ToColourClass(this CheeseColour cheeseColour)
        {
            switch(cheeseColour)
            {
                case CheeseColour.Yellow:
                    return "yellow";
                case CheeseColour.Orange:
                    return "warning";
                case CheeseColour.Red:
                    return "danger";
                case CheeseColour.Pink:
                    return "pink";
                case CheeseColour.Blue:
                    return "info";
                case CheeseColour.Green:
                    return "success";
                default:
                    throw new ArgumentOutOfRangeException(nameof(cheeseColour), cheeseColour, null);
            }
        }
    }
}
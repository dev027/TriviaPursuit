using System;
using Tp.Common.Constants;

namespace Tp.Common.Extensions.CheeseColourExtensions
{
    public static partial class CheeseColourExtensions
    {
        public static string ToBackgroundColourClass(this CheeseColour cheeseColour)
        {
            switch(cheeseColour)
            {
                case CheeseColour.Yellow:
                    return "bg-yellow";
                case CheeseColour.Orange:
                    return "bg-warning";
                case CheeseColour.Red:
                    return "bg-danger";
                case CheeseColour.Pink:
                    return "bg-pink";
                case CheeseColour.Blue:
                    return "bg-info";
                case CheeseColour.Green:
                    return "bg-success";
                default:
                    throw new ArgumentOutOfRangeException(nameof(cheeseColour), cheeseColour, null);
            }
        }
    }
}
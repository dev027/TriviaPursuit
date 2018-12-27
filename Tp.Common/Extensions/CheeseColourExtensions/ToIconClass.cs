using System;
using Tp.Common.Constants;

namespace Tp.Common.Extensions.CheeseColourExtensions
{
    public static partial class CheeseColourExtensions
    {
        public static string ToIconClass(this CheeseColour cheeseColour)
        {
            switch(cheeseColour)
            {
                case CheeseColour.Yellow:
                    return "fa fa-history";
                case CheeseColour.Orange:
                    return "fa fa-soccer-ball-o";
                case CheeseColour.Red:
                    return "fa fa-paint-brush";
                case CheeseColour.Pink:
                    return "fa fa-film";
                case CheeseColour.Blue:
                    return "fa fa-globe";
                case CheeseColour.Green:
                    return "fa fa-plug";
                default:
                    throw new ArgumentOutOfRangeException(nameof(cheeseColour), cheeseColour, null);
            }
        }
    }
}
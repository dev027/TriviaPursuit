﻿using Tp.Common.Constants;

namespace Tp.Common.Extensions.CheeseColourExtensions
{
    public static partial class CheeseColourExtensions
    {
        public static string ToBorderColourClass(this CheeseColour cheeseColour)
        {
            return $"border-{cheeseColour.ToColourClass()}";
        }
    }
}
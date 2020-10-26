﻿namespace VL.TimelineCore
{
    internal static class BooleanBoxes
    {
        internal static object TrueBox = true;
        internal static object FalseBox = false;
 
        internal static object Box(bool value)
        {
            if (value)
            {
                return TrueBox;
            }
            else
            {
                return FalseBox;
            }
        }
    }
}
using System;
using StupidPrincess.Renderables;

namespace StupidPrincess
{
    public static class WindowSizingTool
    {
        public static Size GetWindowSize()
        {
            return new Size((int)(Console.LargestWindowWidth*.9), (int)(Console.LargestWindowHeight*.9)) ;
        }
    }
}

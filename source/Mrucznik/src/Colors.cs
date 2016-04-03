using SampSharp.GameMode.SAMP;
using CX = System.Drawing;

namespace Mrucznik
{
    public struct Colors
    {
        public static Color Error => CX.Color.FromArgb(0xFF, 0x00, 0x00).ToArgb();
        public static Color Failure => CX.Color.FromArgb(0xB0, 0xB0, 0xFF).ToArgb();
        public static Color Warning => CX.Color.FromArgb(0xF0, 0x90, 0x40).ToArgb();
        public static Color Info => CX.Color.FromArgb(0xB4, 0xB5, 0xB7).ToArgb();
        public static Color GoodInfo => CX.Color.FromArgb(0x33, 0xCC, 0xFF).ToArgb();
        public static Color BadInfo => CX.Color.FromArgb(0xFF, 0x63, 0x47).ToArgb();
        public static Color Offer => CX.Color.FromArgb(0xDD, 0xA0, 0xDD).ToArgb();
        public static Color Punishment => CX.Color.FromArgb(0xFF, 0x00, 0x00).ToArgb();
        public static Color CommandHelp => CX.Color.FromArgb(0xAF, 0xAF, 0xAF).ToArgb();
        public static Color CommandInfo => CX.Color.FromArgb(0xAF, 0xAF, 0xAF).ToArgb();
    }
}

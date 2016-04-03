using SampSharp.GameMode.SAMP;
using CX = System.Drawing;

namespace Mrucznik
{
    public struct Colors
    {
        public static Color Error => CX.Color.Red.ToArgb();
        public static Color Warning => CX.Color.FromArgb(240, 144, 64).ToArgb();
        public static Color Info => CX.Color.Silver.ToArgb();
        public static Color GoodInfo => CX.Color.FromArgb(31, 247, 197).ToArgb();
        public static Color BadInfo => CX.Color.FromArgb(206, 124, 0).ToArgb();
        public static Color Offer => CX.Color.FromArgb(51, 204, 255).ToArgb();
        public static Color Punishment => CX.Color.FromArgb(0xFF, 0x63, 0x47).ToArgb();
        public static Color CommandFeedback => CX.Color.Gray.ToArgb();
    }
}

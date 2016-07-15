using SampSharp.GameMode.SAMP;
using CX = System.Drawing;

namespace Mrucznik
{
    public struct Colors
    {
        //Messages
        public static Color Error => CX.Color.Red.ToArgb();
        public static Color Warning => CX.Color.DarkOrange.ToArgb();
        public static Color Info => CX.Color.Silver.ToArgb();
        public static Color GoodInfo => CX.Color.Aquamarine.ToArgb();
        public static Color BadInfo => CX.Color.LightCoral.ToArgb();
        public static Color Offer => CX.Color.FromArgb(51, 204, 255).ToArgb();
        public static Color Punishment => CX.Color.Tomato.ToArgb();
        public static Color CommandFeedback => CX.Color.Gray.ToArgb();
    }
}

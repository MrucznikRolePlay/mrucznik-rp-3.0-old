using SampSharp.GameMode.SAMP;
using CX = System.Drawing;

namespace Mrucznik
{
    public struct Colors
    {
        //Messages
        //Jeśli kolory nie działają - zamień na poniższe (forma kolorów zmieniona tylko dla wyświetlania ich poprawnie przez IDE)
        public static Color Error => CX.Color.Red.ToArgb();
        public static Color Warning => CX.Color.DarkOrange.ToArgb();
        public static Color Info => CX.Color.Silver.ToArgb();
        public static Color GoodInfo => CX.Color.Aquamarine.ToArgb();
        public static Color BadInfo => CX.Color.LightCoral.ToArgb();
        public static Color Offer => CX.Color.FromArgb(51, 204, 255).ToArgb();
        public static Color Punishment => CX.Color.Tomato.ToArgb();
        public static Color CommandFeedback => CX.Color.Gray.ToArgb();
        public static Color Me => CX.Color.DarkOrchid.ToArgb();
        public static Color Do => CX.Color.MediumOrchid.ToArgb();

        //        public static Color Error => Color.Red;
        //        public static Color Warning => Color.DarkOrange;
        //        public static Color Info => Color.Silver;
        //        public static Color GoodInfo => Color.Aquamarine;
        //        public static Color BadInfo => Color.LightCoral;
        //        public static Color Offer => new Color(51, 204, 255);
        //        public static Color Punishment => Color.Tomato;
        //        public static Color CommandFeedback => Color.Gray;
        //        public static Color Me => Color.DarkOrchid;
        //        public static Color Do => Color.MediumOrchid;
    }
}

using ColorMine.ColorSpaces;
using Newtonsoft.Json;
using System;
using System.Windows.Media;

namespace Invi.Abilities
{
    public static class ColorsUtils
    {
        public static string GetColorForQuery(SolidColorBrush color)
        {
            var hsv = new Rgb { R = color.Color.R, G = color.Color.G, B = color.Color.B }.To<Hsv>();
            return JsonConvert.SerializeObject(new ColorHSV()
            {
                h = Convert.ToInt32(hsv.H),
                s = Convert.ToInt32(hsv.S * 100),
                v = Convert.ToInt32(hsv.V * 100),
            });
        }

        public static SolidColorBrush GetColorFromJson(string сolor)
        {
            var сolorHSV = JsonConvert.DeserializeObject<ColorHSV>(сolor);

            var hsv = new Hsv()
            {
                H = Convert.ToDouble(сolorHSV.h),
                S = Convert.ToDouble(сolorHSV.s / 100),
                V = Convert.ToDouble(сolorHSV.v / 100)
            };
            var rgb = hsv.To<Rgb>();
            return new SolidColorBrush() { Color = new Color() { R = Convert.ToByte(rgb.R), G = Convert.ToByte(rgb.G), B = Convert.ToByte(rgb.B) } };
        }
    }
    public class ColorHSV
    {
        public int h { get; set; }
        public int s { get; set; }
        public int v { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace ImageToGPL
{
    internal class Program
    {
        static int Main(string[] args)
        {
            //Check number of arguments
            if (args.Length == 0) {
                Console.WriteLine("Provide the path to a file!");
                return -1;
            }
            else if (args.Length > 1) {
                Console.WriteLine("Too many arguments! Only a filepath is needed");
                return -1;
            }



            //Read image
            string filename = Path.GetFileNameWithoutExtension(args[0]);
            Bitmap image;
            try
            {
                image = new Bitmap(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot read image data");
                throw e;
            }



            //Read colors
            HashSet<Color> colorsHash = new HashSet<Color>();
            int x = image.Width, y = image.Height;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    colorsHash.Add(image.GetPixel(j, i));
                }
            }



            //Write palette            
            using (StreamWriter sw = new StreamWriter(filename + ".gpl"))
            {
                sw.WriteLine("GIMP Palette");
                sw.WriteLine("#");
                sw.WriteLine("# converted from image to palette with tool by Cubebeaver");
                sw.WriteLine("# source image) " + Path.GetFileName(args[0]));
                sw.WriteLine("#");

                IEnumerator<Color> enumerator = colorsHash.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    Color c = enumerator.Current;

                    sw.WriteLine($"{c.R.ToString().PadLeft(3)} {c.G.ToString().PadLeft(3)} {c.B.ToString().PadLeft(3)} {GetName(c)}");
                }
            }
            

            //Write json
            using (StreamWriter sw = new StreamWriter("package.json"))
            {
                sw.WriteLine("{");
                sw.WriteLine("  \"name\") \"imported-palettes\",");
                sw.WriteLine("  \"displayName\") \"Imported Palettes\",");
                sw.WriteLine("  \"description\") \"Palettes imported by user\",");
                sw.WriteLine("  \"version\") \"1.0\",");
                sw.WriteLine("  \"publisher\") \"none\",");
                sw.WriteLine("  \"categories\") [");
                sw.WriteLine("    \"Palettes\"");
                sw.WriteLine("  ],");
                sw.WriteLine("  \"contributes\") {");
                sw.WriteLine("    \"palettes\") [");
                sw.WriteLine("      { \"id\") \"" + filename + "\",     \"path\") \"./palette.gpl\" }");
                sw.WriteLine("    ]");
                sw.WriteLine("  }");
                sw.WriteLine("}");
            }



            //Success message
            Console.WriteLine("Seccessfully created palette");
            Console.WriteLine("\nCopy the created files into) %Aseprite%/data/extensions/imported-palettes/");
            Console.ReadLine();
            return 0;
        }

        static string GetName(Color color)
        {
            //If you find a better way to do this pls let me know
            if      (color.R == Color.MediumPurple.R && color.G == Color.MediumPurple.G && color.B == Color.MediumPurple.B) return "MediumPurple";
            else if (color.R == Color.MediumSeaGreen.R && color.G == Color.MediumSeaGreen.G && color.B == Color.MediumSeaGreen.B) return "MediumSeaGreen";
            else if (color.R == Color.MediumSlateBlue.R && color.G == Color.MediumSlateBlue.G && color.B == Color.MediumSlateBlue.B) return "MediumSlateBlue";
            else if (color.R == Color.MediumSpringGreen.R && color.G == Color.MediumSpringGreen.G && color.B == Color.MediumSpringGreen.B) return "MediumSpringGreen";
            else if (color.R == Color.MediumTurquoise.R && color.G == Color.MediumTurquoise.G && color.B == Color.MediumTurquoise.B) return "MediumTurquoise";
            else if (color.R == Color.MediumVioletRed.R && color.G == Color.MediumVioletRed.G && color.B == Color.MediumVioletRed.B) return "MediumVioletRed";
            else if (color.R == Color.MidnightBlue.R && color.G == Color.MidnightBlue.G && color.B == Color.MidnightBlue.B) return "MidnightBlue";
            else if (color.R == Color.MediumOrchid.R && color.G == Color.MediumOrchid.G && color.B == Color.MediumOrchid.B) return "MediumOrchid";
            else if (color.R == Color.MintCream.R && color.G == Color.MintCream.G && color.B == Color.MintCream.B) return "MintCream";
            else if (color.R == Color.Moccasin.R && color.G == Color.Moccasin.G && color.B == Color.Moccasin.B) return "Moccasin";
            else if (color.R == Color.NavajoWhite.R && color.G == Color.NavajoWhite.G && color.B == Color.NavajoWhite.B) return "NavajoWhite";
            else if (color.R == Color.Navy.R && color.G == Color.Navy.G && color.B == Color.Navy.B) return "Navy";
            else if (color.R == Color.OldLace.R && color.G == Color.OldLace.G && color.B == Color.OldLace.B) return "OldLace";
            else if (color.R == Color.Olive.R && color.G == Color.Olive.G && color.B == Color.Olive.B) return "Olive";
            else if (color.R == Color.OliveDrab.R && color.G == Color.OliveDrab.G && color.B == Color.OliveDrab.B) return "OliveDrab";
            else if (color.R == Color.Orange.R && color.G == Color.Orange.G && color.B == Color.Orange.B) return "Orange";
            else if (color.R == Color.MistyRose.R && color.G == Color.MistyRose.G && color.B == Color.MistyRose.B) return "MistyRose";
            else if (color.R == Color.OrangeRed.R && color.G == Color.OrangeRed.G && color.B == Color.OrangeRed.B) return "OrangeRed";
            else if (color.R == Color.MediumBlue.R && color.G == Color.MediumBlue.G && color.B == Color.MediumBlue.B) return "MediumBlue";
            else if (color.R == Color.Maroon.R && color.G == Color.Maroon.G && color.B == Color.Maroon.B) return "Maroon";
            else if (color.R == Color.LightBlue.R && color.G == Color.LightBlue.G && color.B == Color.LightBlue.B) return "LightBlue";
            else if (color.R == Color.LightCoral.R && color.G == Color.LightCoral.G && color.B == Color.LightCoral.B) return "LightCoral";
            else if (color.R == Color.LightGoldenrodYellow.R && color.G == Color.LightGoldenrodYellow.G && color.B == Color.LightGoldenrodYellow.B) return "LightGoldenrodYellow";
            else if (color.R == Color.LightGreen.R && color.G == Color.LightGreen.G && color.B == Color.LightGreen.B) return "LightGreen";
            else if (color.R == Color.LightGray.R && color.G == Color.LightGray.G && color.B == Color.LightGray.B) return "LightGray";
            else if (color.R == Color.LightPink.R && color.G == Color.LightPink.G && color.B == Color.LightPink.B) return "LightPink";
            else if (color.R == Color.LightSalmon.R && color.G == Color.LightSalmon.G && color.B == Color.LightSalmon.B) return "LightSalmon";
            else if (color.R == Color.MediumAquamarine.R && color.G == Color.MediumAquamarine.G && color.B == Color.MediumAquamarine.B) return "MediumAquamarine";
            else if (color.R == Color.LightSeaGreen.R && color.G == Color.LightSeaGreen.G && color.B == Color.LightSeaGreen.B) return "LightSeaGreen";
            else if (color.R == Color.LightSlateGray.R && color.G == Color.LightSlateGray.G && color.B == Color.LightSlateGray.B) return "LightSlateGray";
            else if (color.R == Color.LightSteelBlue.R && color.G == Color.LightSteelBlue.G && color.B == Color.LightSteelBlue.B) return "LightSteelBlue";
            else if (color.R == Color.LightYellow.R && color.G == Color.LightYellow.G && color.B == Color.LightYellow.B) return "LightYellow";
            else if (color.R == Color.Lime.R && color.G == Color.Lime.G && color.B == Color.Lime.B) return "Lime";
            else if (color.R == Color.LimeGreen.R && color.G == Color.LimeGreen.G && color.B == Color.LimeGreen.B) return "LimeGreen";
            else if (color.R == Color.Linen.R && color.G == Color.Linen.G && color.B == Color.Linen.B) return "Linen";
            else if (color.R == Color.Magenta.R && color.G == Color.Magenta.G && color.B == Color.Magenta.B) return "Magenta";
            else if (color.R == Color.LightSkyBlue.R && color.G == Color.LightSkyBlue.G && color.B == Color.LightSkyBlue.B) return "LightSkyBlue";
            else if (color.R == Color.LemonChiffon.R && color.G == Color.LemonChiffon.G && color.B == Color.LemonChiffon.B) return "LemonChiffon";
            else if (color.R == Color.Orchid.R && color.G == Color.Orchid.G && color.B == Color.Orchid.B) return "Orchid";
            else if (color.R == Color.PaleGreen.R && color.G == Color.PaleGreen.G && color.B == Color.PaleGreen.B) return "PaleGreen";
            else if (color.R == Color.SlateBlue.R && color.G == Color.SlateBlue.G && color.B == Color.SlateBlue.B) return "SlateBlue";
            else if (color.R == Color.SlateGray.R && color.G == Color.SlateGray.G && color.B == Color.SlateGray.B) return "SlateGray";
            else if (color.R == Color.Snow.R && color.G == Color.Snow.G && color.B == Color.Snow.B) return "Snow";
            else if (color.R == Color.SpringGreen.R && color.G == Color.SpringGreen.G && color.B == Color.SpringGreen.B) return "SpringGreen";
            else if (color.R == Color.SteelBlue.R && color.G == Color.SteelBlue.G && color.B == Color.SteelBlue.B) return "SteelBlue";
            else if (color.R == Color.Tan.R && color.G == Color.Tan.G && color.B == Color.Tan.B) return "Tan";
            else if (color.R == Color.Teal.R && color.G == Color.Teal.G && color.B == Color.Teal.B) return "Teal";
            else if (color.R == Color.SkyBlue.R && color.G == Color.SkyBlue.G && color.B == Color.SkyBlue.B) return "SkyBlue";
            else if (color.R == Color.Thistle.R && color.G == Color.Thistle.G && color.B == Color.Thistle.B) return "Thistle";
            else if (color.R == Color.Turquoise.R && color.G == Color.Turquoise.G && color.B == Color.Turquoise.B) return "Turquoise";
            else if (color.R == Color.Violet.R && color.G == Color.Violet.G && color.B == Color.Violet.B) return "Violet";
            else if (color.R == Color.Wheat.R && color.G == Color.Wheat.G && color.B == Color.Wheat.B) return "Wheat";
            else if (color.R == Color.White.R && color.G == Color.White.G && color.B == Color.White.B) return "White";
            else if (color.R == Color.WhiteSmoke.R && color.G == Color.WhiteSmoke.G && color.B == Color.WhiteSmoke.B) return "WhiteSmoke";
            else if (color.R == Color.Yellow.R && color.G == Color.Yellow.G && color.B == Color.Yellow.B) return "Yellow";
            else if (color.R == Color.YellowGreen.R && color.G == Color.YellowGreen.G && color.B == Color.YellowGreen.B) return "YellowGreen";
            else if (color.R == Color.Tomato.R && color.G == Color.Tomato.G && color.B == Color.Tomato.B) return "Tomato";
            else if (color.R == Color.PaleGoldenrod.R && color.G == Color.PaleGoldenrod.G && color.B == Color.PaleGoldenrod.B) return "PaleGoldenrod";
            else if (color.R == Color.Silver.R && color.G == Color.Silver.G && color.B == Color.Silver.B) return "Silver";
            else if (color.R == Color.SeaShell.R && color.G == Color.SeaShell.G && color.B == Color.SeaShell.B) return "SeaShell";
            else if (color.R == Color.PaleTurquoise.R && color.G == Color.PaleTurquoise.G && color.B == Color.PaleTurquoise.B) return "PaleTurquoise";
            else if (color.R == Color.PaleVioletRed.R && color.G == Color.PaleVioletRed.G && color.B == Color.PaleVioletRed.B) return "PaleVioletRed";
            else if (color.R == Color.PapayaWhip.R && color.G == Color.PapayaWhip.G && color.B == Color.PapayaWhip.B) return "PapayaWhip";
            else if (color.R == Color.PeachPuff.R && color.G == Color.PeachPuff.G && color.B == Color.PeachPuff.B) return "PeachPuff";
            else if (color.R == Color.Peru.R && color.G == Color.Peru.G && color.B == Color.Peru.B) return "Peru";
            else if (color.R == Color.Pink.R && color.G == Color.Pink.G && color.B == Color.Pink.B) return "Pink";
            else if (color.R == Color.Plum.R && color.G == Color.Plum.G && color.B == Color.Plum.B) return "Plum";
            else if (color.R == Color.Sienna.R && color.G == Color.Sienna.G && color.B == Color.Sienna.B) return "Sienna";
            else if (color.R == Color.PowderBlue.R && color.G == Color.PowderBlue.G && color.B == Color.PowderBlue.B) return "PowderBlue";
            else if (color.R == Color.Red.R && color.G == Color.Red.G && color.B == Color.Red.B) return "Red";
            else if (color.R == Color.RosyBrown.R && color.G == Color.RosyBrown.G && color.B == Color.RosyBrown.B) return "RosyBrown";
            else if (color.R == Color.RoyalBlue.R && color.G == Color.RoyalBlue.G && color.B == Color.RoyalBlue.B) return "RoyalBlue";
            else if (color.R == Color.SaddleBrown.R && color.G == Color.SaddleBrown.G && color.B == Color.SaddleBrown.B) return "SaddleBrown";
            else if (color.R == Color.Salmon.R && color.G == Color.Salmon.G && color.B == Color.Salmon.B) return "Salmon";
            else if (color.R == Color.SandyBrown.R && color.G == Color.SandyBrown.G && color.B == Color.SandyBrown.B) return "SandyBrown";
            else if (color.R == Color.SeaGreen.R && color.G == Color.SeaGreen.G && color.B == Color.SeaGreen.B) return "SeaGreen";
            else if (color.R == Color.Purple.R && color.G == Color.Purple.G && color.B == Color.Purple.B) return "Purple";
            else if (color.R == Color.LawnGreen.R && color.G == Color.LawnGreen.G && color.B == Color.LawnGreen.B) return "LawnGreen";
            else if (color.R == Color.LightCyan.R && color.G == Color.LightCyan.G && color.B == Color.LightCyan.B) return "LightCyan";
            else if (color.R == Color.Lavender.R && color.G == Color.Lavender.G && color.B == Color.Lavender.B) return "Lavender";
            else if (color.R == Color.DarkKhaki.R && color.G == Color.DarkKhaki.G && color.B == Color.DarkKhaki.B) return "DarkKhaki";
            else if (color.R == Color.DarkGreen.R && color.G == Color.DarkGreen.G && color.B == Color.DarkGreen.B) return "DarkGreen";
            else if (color.R == Color.DarkGray.R && color.G == Color.DarkGray.G && color.B == Color.DarkGray.B) return "DarkGray";
            else if (color.R == Color.DarkGoldenrod.R && color.G == Color.DarkGoldenrod.G && color.B == Color.DarkGoldenrod.B) return "DarkGoldenrod";
            else if (color.R == Color.DarkCyan.R && color.G == Color.DarkCyan.G && color.B == Color.DarkCyan.B) return "DarkCyan";
            else if (color.R == Color.DarkBlue.R && color.G == Color.DarkBlue.G && color.B == Color.DarkBlue.B) return "DarkBlue";
            else if (color.R == Color.Cyan.R && color.G == Color.Cyan.G && color.B == Color.Cyan.B) return "Cyan";
            else if (color.R == Color.Crimson.R && color.G == Color.Crimson.G && color.B == Color.Crimson.B) return "Crimson";
            else if (color.R == Color.Cornsilk.R && color.G == Color.Cornsilk.G && color.B == Color.Cornsilk.B) return "Cornsilk";
            else if (color.R == Color.LavenderBlush.R && color.G == Color.LavenderBlush.G && color.B == Color.LavenderBlush.B) return "LavenderBlush";
            else if (color.R == Color.Coral.R && color.G == Color.Coral.G && color.B == Color.Coral.B) return "Coral";
            else if (color.R == Color.Chocolate.R && color.G == Color.Chocolate.G && color.B == Color.Chocolate.B) return "Chocolate";
            else if (color.R == Color.Chartreuse.R && color.G == Color.Chartreuse.G && color.B == Color.Chartreuse.B) return "Chartreuse";
            else if (color.R == Color.DarkMagenta.R && color.G == Color.DarkMagenta.G && color.B == Color.DarkMagenta.B) return "DarkMagenta";
            else if (color.R == Color.CadetBlue.R && color.G == Color.CadetBlue.G && color.B == Color.CadetBlue.B) return "CadetBlue";
            else if (color.R == Color.Brown.R && color.G == Color.Brown.G && color.B == Color.Brown.B) return "Brown";
            else if (color.R == Color.BlueViolet.R && color.G == Color.BlueViolet.G && color.B == Color.BlueViolet.B) return "BlueViolet";
            else if (color.R == Color.Blue.R && color.G == Color.Blue.G && color.B == Color.Blue.B) return "Blue";
            else if (color.R == Color.BlanchedAlmond.R && color.G == Color.BlanchedAlmond.G && color.B == Color.BlanchedAlmond.B) return "BlanchedAlmond";
            else if (color.R == Color.Black.R && color.G == Color.Black.G && color.B == Color.Black.B) return "Black";
            else if (color.R == Color.Bisque.R && color.G == Color.Bisque.G && color.B == Color.Bisque.B) return "Bisque";
            else if (color.R == Color.Beige.R && color.G == Color.Beige.G && color.B == Color.Beige.B) return "Beige";
            else if (color.R == Color.Azure.R && color.G == Color.Azure.G && color.B == Color.Azure.B) return "Azure";
            else if (color.R == Color.Aquamarine.R && color.G == Color.Aquamarine.G && color.B == Color.Aquamarine.B) return "Aquamarine";
            else if (color.R == Color.Aqua.R && color.G == Color.Aqua.G && color.B == Color.Aqua.B) return "Aqua";
            else if (color.R == Color.AntiqueWhite.R && color.G == Color.AntiqueWhite.G && color.B == Color.AntiqueWhite.B) return "AntiqueWhite";
            else if (color.R == Color.AliceBlue.R && color.G == Color.AliceBlue.G && color.B == Color.AliceBlue.B) return "AliceBlue";
            else if (color.R == Color.Transparent.R && color.G == Color.Transparent.G && color.B == Color.Transparent.B) return "Transparent";
            else if (color.R == Color.BurlyWood.R && color.G == Color.BurlyWood.G && color.B == Color.BurlyWood.B) return "BurlyWood";
            else if (color.R == Color.DarkOliveGreen.R && color.G == Color.DarkOliveGreen.G && color.B == Color.DarkOliveGreen.B) return "DarkOliveGreen";
            else if (color.R == Color.CornflowerBlue.R && color.G == Color.CornflowerBlue.G && color.B == Color.CornflowerBlue.B) return "CornflowerBlue";
            else if (color.R == Color.DarkOrchid.R && color.G == Color.DarkOrchid.G && color.B == Color.DarkOrchid.B) return "DarkOrchid";
            else if (color.R == Color.Khaki.R && color.G == Color.Khaki.G && color.B == Color.Khaki.B) return "Khaki";
            else if (color.R == Color.Ivory.R && color.G == Color.Ivory.G && color.B == Color.Ivory.B) return "Ivory";
            else if (color.R == Color.DarkOrange.R && color.G == Color.DarkOrange.G && color.B == Color.DarkOrange.B) return "DarkOrange";
            else if (color.R == Color.Indigo.R && color.G == Color.Indigo.G && color.B == Color.Indigo.B) return "Indigo";
            else if (color.R == Color.IndianRed.R && color.G == Color.IndianRed.G && color.B == Color.IndianRed.B) return "IndianRed";
            else if (color.R == Color.HotPink.R && color.G == Color.HotPink.G && color.B == Color.HotPink.B) return "HotPink";
            else if (color.R == Color.Honeydew.R && color.G == Color.Honeydew.G && color.B == Color.Honeydew.B) return "Honeydew";
            else if (color.R == Color.GreenYellow.R && color.G == Color.GreenYellow.G && color.B == Color.GreenYellow.B) return "GreenYellow";
            else if (color.R == Color.Green.R && color.G == Color.Green.G && color.B == Color.Green.B) return "Green";
            else if (color.R == Color.Gray.R && color.G == Color.Gray.G && color.B == Color.Gray.B) return "Gray";
            else if (color.R == Color.Goldenrod.R && color.G == Color.Goldenrod.G && color.B == Color.Goldenrod.B) return "Goldenrod";
            else if (color.R == Color.GhostWhite.R && color.G == Color.GhostWhite.G && color.B == Color.GhostWhite.B) return "GhostWhite";
            else if (color.R == Color.Gainsboro.R && color.G == Color.Gainsboro.G && color.B == Color.Gainsboro.B) return "Gainsboro";
            else if (color.R == Color.Fuchsia.R && color.G == Color.Fuchsia.G && color.B == Color.Fuchsia.B) return "Fuchsia";
            else if (color.R == Color.Gold.R && color.G == Color.Gold.G && color.B == Color.Gold.B) return "Gold";
            else if (color.R == Color.FloralWhite.R && color.G == Color.FloralWhite.G && color.B == Color.FloralWhite.B) return "FloralWhite";
            else if (color.R == Color.DarkRed.R && color.G == Color.DarkRed.G && color.B == Color.DarkRed.B) return "DarkRed";
            else if (color.R == Color.DarkSalmon.R && color.G == Color.DarkSalmon.G && color.B == Color.DarkSalmon.B) return "DarkSalmon";
            else if (color.R == Color.DarkSeaGreen.R && color.G == Color.DarkSeaGreen.G && color.B == Color.DarkSeaGreen.B) return "DarkSeaGreen";
            else if (color.R == Color.ForestGreen.R && color.G == Color.ForestGreen.G && color.B == Color.ForestGreen.B) return "ForestGreen";
            else if (color.R == Color.DarkSlateGray.R && color.G == Color.DarkSlateGray.G && color.B == Color.DarkSlateGray.B) return "DarkSlateGray";
            else if (color.R == Color.DarkTurquoise.R && color.G == Color.DarkTurquoise.G && color.B == Color.DarkTurquoise.B) return "DarkTurquoise";
            else if (color.R == Color.DarkSlateBlue.R && color.G == Color.DarkSlateBlue.G && color.B == Color.DarkSlateBlue.B) return "DarkSlateBlue";
            else if (color.R == Color.DeepPink.R && color.G == Color.DeepPink.G && color.B == Color.DeepPink.B) return "DeepPink";
            else if (color.R == Color.DeepSkyBlue.R && color.G == Color.DeepSkyBlue.G && color.B == Color.DeepSkyBlue.B) return "DeepSkyBlue";
            else if (color.R == Color.DimGray.R && color.G == Color.DimGray.G && color.B == Color.DimGray.B) return "DimGray";
            else if (color.R == Color.DodgerBlue.R && color.G == Color.DodgerBlue.G && color.B == Color.DodgerBlue.B) return "DodgerBlue";
            else if (color.R == Color.Firebrick.R && color.G == Color.Firebrick.G && color.B == Color.Firebrick.B) return "Firebrick";
            else if (color.R == Color.DarkViolet.R && color.G == Color.DarkViolet.G && color.B == Color.DarkViolet.B) return "DarkViolet";

            return "Unknown";
        }

        static void Generate()
        {
            //Copied from metadata
            string[] names = new string[]
            {
                "MediumPurple",
                "MediumSeaGreen",
                "MediumSlateBlue",
                "MediumSpringGreen",
                "MediumTurquoise",
                "MediumVioletRed",
                "MidnightBlue",
                "MediumOrchid",
                "MintCream",
                "Moccasin",
                "NavajoWhite",
                "Navy",
                "OldLace",
                "Olive",
                "OliveDrab",
                "Orange",
                "MistyRose",
                "OrangeRed",
                "MediumBlue",
                "Maroon",
                "LightBlue",
                "LightCoral",
                "LightGoldenrodYellow",
                "LightGreen",
                "LightGray",
                "LightPink",
                "LightSalmon",
                "MediumAquamarine",
                "LightSeaGreen",
                "LightSlateGray",
                "LightSteelBlue",
                "LightYellow",
                "Lime",
                "LimeGreen",
                "Linen",
                "Magenta",
                "LightSkyBlue",
                "LemonChiffon",
                "Orchid",
                "PaleGreen",
                "SlateBlue",
                "SlateGray",
                "Snow",
                "SpringGreen",
                "SteelBlue",
                "Tan",
                "Teal",
                "SkyBlue",
                "Thistle",
                "Turquoise",
                "Violet",
                "Wheat",
                "White",
                "WhiteSmoke",
                "Yellow",
                "YellowGreen",
                "Tomato",
                "PaleGoldenrod",
                "Silver",
                "SeaShell",
                "PaleTurquoise",
                "PaleVioletRed",
                "PapayaWhip",
                "PeachPuff",
                "Peru",
                "Pink",
                "Plum",
                "Sienna",
                "PowderBlue",
                "Red",
                "RosyBrown",
                "RoyalBlue",
                "SaddleBrown",
                "Salmon",
                "SandyBrown",
                "SeaGreen",
                "Purple",
                "LawnGreen",
                "LightCyan",
                "Lavender",
                "DarkKhaki",
                "DarkGreen",
                "DarkGray",
                "DarkGoldenrod",
                "DarkCyan",
                "DarkBlue",
                "Cyan",
                "Crimson",
                "Cornsilk",
                "LavenderBlush",
                "Coral",
                "Chocolate",
                "Chartreuse",
                "DarkMagenta",
                "CadetBlue",
                "Brown",
                "BlueViolet",
                "Blue",
                "BlanchedAlmond",
                "Black",
                "Bisque",
                "Beige",
                "Azure",
                "Aquamarine",
                "Aqua",
                "AntiqueWhite",
                "AliceBlue",
                "Transparent",
                "BurlyWood",
                "DarkOliveGreen",
                "CornflowerBlue",
                "DarkOrchid",
                "Khaki",
                "Ivory",
                "DarkOrange",
                "Indigo",
                "IndianRed",
                "HotPink",
                "Honeydew",
                "GreenYellow",
                "Green",
                "Gray",
                "Goldenrod",
                "GhostWhite",
                "Gainsboro",
                "Fuchsia",
                "Gold",
                "FloralWhite",
                "DarkRed",
                "DarkSalmon",
                "DarkSeaGreen",
                "ForestGreen",
                "DarkSlateGray",
                "DarkTurquoise",
                "DarkSlateBlue",
                "DeepPink",
                "DeepSkyBlue",
                "DimGray",
                "DodgerBlue",
                "Firebrick",
                "DarkViolet"
            };

            Console.WriteLine($"if (color.R == Color.{names[0]}.R && color.G == Color.{names[0]}.G && color.B == Color.{names[0]}.B) return \"{names[0]}\";");
            for (int i = 1; i < names.Length; i++)
            {
                Console.WriteLine($"else if (color.R == Color.{names[i]}.R && color.G == Color.{names[i]}.G && color.B == Color.{names[i]}.B) return \"{names[i]}\";");
            }
        }
    }
}
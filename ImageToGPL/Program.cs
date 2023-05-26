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



/*
Absolute Zero		#0048ba
Acid Green		#b0bf1a
AliceBlue		#f0f8ff
Alizarin crimson		#e32636
Amaranth		#e52b50
Amber		#ffbf00
Amethyst		#9966cc
AntiqueWhite		#faebd7
AntiqueWhite1		#ffefdb
AntiqueWhite2		#eedfcc
AntiqueWhite3		#cdc0b0
AntiqueWhite4		#8b8378
Apricot		#fbceb1
Aqua		#00ffff
Aquamarine1		#7fffd4
Aquamarine2		#76eec6
Aquamarine4		#458b74
Army Green		#4b5320
Arylide Yellow		#e9d66b
Ash Grey		#b2beb5
Asparagus		#87a96b
Aureolin		#fdee00
Azure1		#f0ffff
Azure2		#e0eeee
Azure3		#c1cdcd
Azure4		#838b8b
Baby Blue		#89cff0
Baby Pink		#f4c2c2
Baker-Miller Pink		#ff91af
Banana Mania		#fae7b5
Banana Yellow		#ffe135
Barn Red		#7c0a02
Battleship Gray		#848482
Beaver		#9f8170
Beige		#f5f5dc
Bisque1		#ffe4c4
Bisque2		#eed5b7
Bisque3		#cdb79e
Bisque4		#8b7d6b
Bistre		#3d2b1f
Bitter Lemon		#cae00d
Bitter Lime		#bfff00
Bittersweet		#fe6f5e
Bittersweet Shimmer		#bf4f51
Black		#000000
Black Coffee		#3b2f2f
Black Olive		#3b3c36
Black Shadows		#bfafb2
BlanchedAlmond		#ffebcd
Bleu de France		#318ce7
Blond		#faf0be
Blue (Pantone)		#0018a8
Blue Bell		#a2a2d0
Blue Green		#0d98ba
Blue1		#0000ff
Blue2		#0000ee
Blue4		#00008b
BlueViolet		#8a2be2
Bole		#79443b
Bone		#e3dac9
Boysenberry		#873260
Brandeis Blue		#0070ff
Brass		#b5a642
Brick Red		#cb4154
Bright Cerulean		#1dacd6
Bright Green		#66ff00
Bright Lavender		#bf94e4
Bright Lilac		#d891ef
Bright Maroon		#c32148
Bright Navy Blue		#1974d2
Bright Turquoise		#08e8de
Bright Ube		#d19fe8
Brilliant Rose		#ff55a3
Brink Pink		#fb607f
British Racing Green		#004225
Bronze		#cd7f32
Brown		#a52a2a
Brown1		#ff4040
Brown2		#ee3b3b
Brown3		#cd3333
Brown4		#8b2323
Brunswick Green		#1b4d3e
Bubble Gum		#ffc1cc
Buff		#f0dc82
Bulgarian Rose		#480607
Burgundy		#800020
Burlywood		#deb887
Burlywood1		#ffd39b
Burlywood2		#eec591
Burlywood3		#cdaa7d
Burlywood4		#8b7355
Burnished Brown		#a17a74
Burnt Orange		#cc5500
Burnt Sienna		#e97451
Burnt Umber		#8a3324
Byzantine		#bd33a4
Byzantium		#702963
Cadet Grey		#91a3b0
CadetBlue		#5f9ea0
CadetBlue1		#98f5ff
CadetBlue2		#8ee5ee
CadetBlue3		#7ac5cd
CadetBlue4		#53868b
Cadmium Green		#006b3c
Cadmium Orange		#ed872d
Cadmium Red		#e30022
Cadmium Yellow		#fff600
Cambridge Blue		#a3c1ad
Camel		#c19a6b
Cameo Pink		#efbbcc
Camouflage Green		#78866b
Canary		#ffff99
Canary Yellow		#ffef00
Candy Apple Red		#ff0800
Candy Pink		#e4717a
Caput Mortuum		#592720
Cardinal		#c41e3a
Caribbean Green		#00cc99
Carmine		#960018
Carmine Pink		#eb4c42
Carnation Pink		#ffa6c9
Carnelian		#b31b1b
Carolina Blue		#56a0d3
Carrot Orange		#ed9121
Castleton Green		#00563f
Cedar Chest		#c95a49
Celadon		#ace1af
Celadon Green		#2f847c
Celeste		#b2ffff
Celtic Blue		#246bce
Cerise		#de3163
Cerulean		#007ba7
Cerulean Blue		#2a52be
Cerulean Frost		#6d9bc3
Cg Blue		#007aa5
Chamoisee		#a0785a
Champagne		#f7e7ce
Charcoal		#36454f
Chartreuse1		#7fff00
Chartreuse2		#76ee00
Chartreuse3		#66cd00
Chartreuse4		#458b00
Cherry Blossom Pink		#ffb7c5
Chestnut		#954535
Chocolate		#d2691e
Chocolate1		#ff7f24
Chocolate2		#ee7621
Chocolate3		#cd661d
Chrome Yellow		#ffa700
Cinereous		#98817b
Cinnabar		#e34234
Citrine		#e4d00a
Citron		#9fa91f
Claret		#7f1734
Cobalt		#0047ab
Coffee		#6f4e37
Cool Grey		#8c92ac
Copper		#b87333
Copper Red		#cb6d51
Copper Rose		#996666
Coquelicot		#ff3800
Coral		#ff7f50
Coral Pink		#f88379
Coral1		#ff7256
Coral2		#ee6a50
Coral3		#cd5b45
Coral4		#8b3e2f
Cordovan		#893f45
Corn		#fbec5d
CornflowerBlue		#6495ed
Cornsilk1		#fff8dc
Cornsilk2		#eee8cd
Cornsilk3		#cdc8b1
Cornsilk4		#8b8878
Cosmic Cobalt		#2e2d88
Cosmic Latte		#fff8e7
Cotton Candy		#ffbcd9
Cream		#fffdd0
Crimson		#dc143c
Crystal		#a7d8de
Cyan1		#00ffff
Cyan2		#00eeee
Cyan3		#00cdcd
Cyan4		#008b8b
Cyclamen		#f56fa1
Daffodil		#ffff31
Dandelion		#f0e130
Dark Brown		#654321
Dark Byzantium		#5d3954
Dark Jungle Green		#1a2421
Dark Lavender		#734f96
Dark Moss Green		#4a5d23
Dark Pastel Green		#03c03c
Dark Sienna		#3c1414
Dark Sky Blue		#8cbed6
Dark Spring Green		#177245
DarkGoldenrod		#b8860b
DarkGoldenrod1		#ffb90f
DarkGoldenrod2		#eead0e
DarkGoldenrod3		#cd950c
DarkGoldenrod4		#8b6508
DarkGreen		#006400
DarkKhaki		#bdb76b
DarkOliveGreen		#556b2f
DarkOliveGreen1		#caff70
DarkOliveGreen2		#bcee68
DarkOliveGreen3		#a2cd5a
DarkOliveGreen4		#6e8b3d
DarkOrange		#ff8c00
DarkOrange1		#ff7f00
DarkOrange2		#ee7600
DarkOrange3		#cd6600
DarkOrange4		#8b4500
DarkOrchid		#9932cc
DarkOrchid1		#bf3eff
DarkOrchid2		#b23aee
DarkOrchid3		#9a32cd
DarkOrchid4		#68228b
DarkSalmon		#e9967a
DarkSeaGreen		#8fbc8f
DarkSeaGreen1		#c1ffc1
DarkSeaGreen2		#b4eeb4
DarkSeaGreen3		#9bcd9b
DarkSeaGreen4		#698b69
DarkSlateBlue		#483d8b
DarkSlateGray		#2f4f4f
DarkSlateGray1		#97ffff
DarkSlateGray2		#8deeee
DarkSlateGray3		#79cdcd
DarkSlateGray4		#528b8b
DarkTurquoise		#00ced1
DarkViolet		#9400d3
Dartmouth Green		#00703c
Deep Cerise		#da3287
Deep Champagne		#fad6a5
Deep Fuchsia		#c154c1
Deep Jungle Green		#004b49
Deep Peach		#ffcba4
Deep Saffron		#ff9933
Deep Space Sparkle		#4a646c
Deep chestnut		#b94e48
DeepPink1		#ff1493
DeepPink2		#ee1289
DeepPink3		#cd1076
DeepPink4		#8b0a50
DeepSkyBlue1		#00bfff
DeepSkyBlue2		#00b2ee
DeepSkyBlue3		#009acd
DeepSkyBlue4		#00688b
Denim		#1560bd
Denim Blue		#2243b6
Desert Sand		#edc9af
DimGray		#696969
DodgerBlue1		#1e90ff
DodgerBlue2		#1c86ee
DodgerBlue3		#1874cd
DodgerBlue4		#104e8b
Dogwood Rose		#d71868
Dutch White		#efdfbb
Earth Yellow		#e1a95f
Ebony		#555d50
Eggplant		#614051
Eggshell		#f0ead6
Egyptian Blue		#1034a6
Electric Blue		#7df9ff
Electric Indigo		#6f00ff
Electric Lime		#ccff00
Electric Purple		#bf00ff
Emerald		#50c878
Eminence		#6c3082
Eton Blue		#96c8a2
Falu Red		#801818
Fawn		#e5aa70
Feldgrau		#4d5d53
Fern Green		#4f7942
Ferrari Red		#ff2800
Fire Opal		#e95c4b
Firebrick		#b22222
Firebrick1		#ff3030
Firebrick2		#ee2c2c
Firebrick3		#cd2626
Firebrick4		#8b1a1a
Flamingo Pink		#fc8eac
FloralWhite		#fffaf0
Flourescent Blue		#15f4ee
Forest Green		#228b22
ForestGreen		#228b22
French Beige		#a67b5b
French Bistre		#856d4d
French Blue		#0072bb
French Lilac		#86608e
French Mauve		#d473d4
French Pink		#fd6c9e
French Rose		#f64a8a
French Sky Blue		#77b5fe
French Violet		#8806ce
Frostbite		#e936a7
Fuchsia Purple		#cc397b
Fuchsia Rose		#c74375
Fulvous		#e48400
Fuzzy Wuzzy		#87421f
GO Green		#00ab66
Gainsboro		#dcdcdc
Gamboge		#e49b0f
Generic Viridian		#007f66
GhostWhite		#f8f8ff
Ginger		#b06500
Glaucous		#6082b6
Glossy Grape		#ab92b3
Gold Fusion		#85754e
Gold1		#ffd700
Gold2		#eec900
Gold3		#cdad00
Gold4		#8b7500
Golden Brown		#996515
Golden Poppy		#fcc200
Golden Yellow		#ffdf00
Goldenrod		#daa520
Goldenrod1		#ffc125
Goldenrod2		#eeb422
Goldenrod3		#cd9b1d
Goldenrod4		#8b6914
Granite Gray		#676767
Granny Smith Apple		#a8e4a0
Gray		#bebebe
Gray1		#030303
Gray10		#1a1a1a
Gray11		#1c1c1c
Gray12		#1f1f1f
Gray13		#212121
Gray14		#242424
Gray15		#262626
Gray16		#292929
Gray17		#2b2b2b
Gray18		#2e2e2e
Gray19		#303030
Gray2		#050505
Gray20		#333333
Gray21		#363636
Gray22		#383838
Gray23		#3b3b3b
Gray24		#3d3d3d
Gray25		#404040
Gray26		#424242
Gray27		#454545
Gray28		#474747
Gray29		#4a4a4a
Gray3		#080808
Gray30		#4d4d4d
Gray31		#4f4f4f
Gray32		#525252
Gray33		#545454
Gray34		#575757
Gray35		#595959
Gray36		#5c5c5c
Gray37		#5e5e5e
Gray38		#616161
Gray39		#636363
Gray4		#0a0a0a
Gray40		#666666
Gray41		#696969
Gray42		#6b6b6b
Gray43		#6e6e6e
Gray44		#707070
Gray45		#737373
Gray46		#757575
Gray47		#787878
Gray48		#7a7a7a
Gray49		#7d7d7d
Gray5		#0d0d0d
Gray50		#7f7f7f
Gray51		#828282
Gray52		#858585
Gray53		#878787
Gray54		#8a8a8a
Gray55		#8c8c8c
Gray56		#8f8f8f
Gray57		#919191
Gray58		#949494
Gray59		#969696
Gray6		#0f0f0f
Gray60		#999999
Gray61		#9c9c9c
Gray62		#9e9e9e
Gray63		#a1a1a1
Gray64		#a3a3a3
Gray65		#a6a6a6
Gray66		#a8a8a8
Gray67		#ababab
Gray68		#adadad
Gray69		#b0b0b0
Gray7		#121212
Gray70		#b3b3b3
Gray71		#b5b5b5
Gray72		#b8b8b8
Gray73		#bababa
Gray74		#bdbdbd
Gray75		#bfbfbf
Gray76		#c2c2c2
Gray77		#c4c4c4
Gray78		#c7c7c7
Gray79		#c9c9c9
Gray8		#141414
Gray80		#cccccc
Gray81		#cfcfcf
Gray82		#d1d1d1
Gray83		#d4d4d4
Gray84		#d6d6d6
Gray85		#d9d9d9
Gray86		#dbdbdb
Gray87		#dedede
Gray88		#e0e0e0
Gray89		#e3e3e3
Gray9		#171717
Gray90		#e5e5e5
Gray91		#e8e8e8
Gray92		#ebebeb
Gray93		#ededed
Gray94		#f0f0f0
Gray95		#f2f2f2
Gray97		#f7f7f7
Gray98		#fafafa
Gray99		#fcfcfc
Green (Crayola)		#1cac78
Green (Pantone)		#00ad43
Green (Pigment)		#00a550
Green Lizard		#a7f432
Green Sheen		#6eaea1
Green1		#00ff00
Green2		#00ee00
Green3		#00cd00
Green4		#008b00
GreenYellow		#adff2f
Grullo		#a99a86
Gunmetal		#2a3439
Han Blue		#446ccf
Han Purple		#5218fa
Harlequin		#3fff00
Harvest Gold		#da9100
Heliotrope		#df73ff
Hollywood Cerise		#f400a1
Honeydew1		#f0fff0
Honeydew2		#e0eee0
Honeydew3		#c1cdc1
Honeydew4		#838b83
Honolulu Blue		#006db0
Hot Magenta		#ff1dce
HotPink		#ff69b4
HotPink1		#ff6eb4
HotPink2		#ee6aa7
HotPink3		#cd6090
HotPink4		#8b3a62
Hunter Green		#355e3b
Iceberg		#71a6d2
Icterine		#fcf75e
Illuminating Emerald		#319177
Imperial Red		#ed2939
Inchworm		#b2ec5d
India Green		#138808
Indian Yellow		#e3a857
IndianRed		#cd5c5c
IndianRed1		#ff6a6a
IndianRed2		#ee6363
IndianRed3		#cd5555
IndianRed4		#8b3a3a
Indigo		#4b0082
International Orange		#ff4f00
Iris		#5a4fcf
Isabelline		#f4f0ec
Ivory1		#fffff0
Ivory2		#eeeee0
Ivory3		#cdcdc1
Ivory4		#8b8b83
Jade		#00a86b
Japanese Carmine		#9d2933
Jasmine		#f8de7e
Jazzberry Jam		#a50b5e
Jonquil		#f4ca16
Jungle Green		#29ab87
Kelly Green		#4cbb17
Keppel		#3ab09e
Key Lime		#e8f48c
Khaki		#f0e68c
Khaki1		#fff68f
Khaki2		#eee685
Khaki3		#cdc673
Khaki4		#8b864e
Kombu Green		#354230
Languid Lavender		#d6cadd
Lapis Lazuli		#26619c
Laser Lemon		#ffff66
Laurel Green		#a9ba9d
Lavender		#e6e6fa
Lavender (Floral)		#b57edc
Lavender Blue		#ccccff
Lavender Gray		#c4c3d0
LavenderBlush1		#fff0f5
LavenderBlush2		#eee0e5
LavenderBlush3		#cdc1c5
LavenderBlush4		#8b8386
LawnGreen		#7cfc00
Lemon		#fff700
Lemon Curry		#cca01d
Lemon Glacier		#fdff00
Lemon Meringue		#f6eabe
Lemon Yellow		#fff44f
LemonChiffon1		#fffacd
LemonChiffon2		#eee9bf
LemonChiffon3		#cdc9a5
LemonChiffon4		#8b8970
Light		#eedd82
Light Cornflower Blue		#93ccea
Light French Beige		#c8ad7f
Light Orange		#fed8b1
Light Periwinkle		#c5cbe1
LightBlue		#add8e6
LightBlue1		#bfefff
LightBlue2		#b2dfee
LightBlue3		#9ac0cd
LightBlue4		#68838b
LightCoral		#f08080
LightCyan1		#e0ffff
LightCyan2		#d1eeee
LightCyan3		#b4cdcd
LightCyan4		#7a8b8b
LightGoldenrod1		#ffec8b
LightGoldenrod2		#eedc82
LightGoldenrod3		#cdbe70
LightGoldenrod4		#8b814c
LightGoldenrodYellow		#fafad2
LightGray		#d3d3d3
LightPink		#ffb6c1
LightPink1		#ffaeb9
LightPink2		#eea2ad
LightPink3		#cd8c95
LightPink4		#8b5f65
LightSalmon1		#ffa07a
LightSalmon2		#ee9572
LightSalmon3		#cd8162
LightSalmon4		#8b5742
LightSeaGreen		#20b2aa
LightSkyBlue		#87cefa
LightSkyBlue1		#b0e2ff
LightSkyBlue2		#a4d3ee
LightSkyBlue3		#8db6cd
LightSkyBlue4		#607b8b
LightSlateBlue		#8470ff
LightSlateGray		#778899
LightSteelBlue		#b0c4de
LightSteelBlue1		#cae1ff
LightSteelBlue2		#bcd2ee
LightSteelBlue3		#a2b5cd
LightSteelBlue4		#6e7b8b
LightYellow1		#ffffe0
LightYellow2		#eeeed1
LightYellow3		#cdcdb4
LightYellow4		#8b8b7a
Lilac		#c8a2c8
Lilac Luster		#ae98aa
LimeGreen		#32cd32
Lincoln Green		#195905
Linen		#faf0e6
Little Boy Blue		#6ca0dc
MSU Green		#18453b
Macaroni and Cheese		#ffbd88
Madder Lake		#cc3336
Magenta		#ff00ff
Magenta (Crayola)		#f653a6
Magenta (Pantone)		#d0417e
Magenta Haze		#9f4576
Magenta2		#ee00ee
Magenta3		#cd00cd
Magenta4		#8b008b
Magic Mint		#aaf0d1
Mahogany		#c04000
Majorelle Blue		#6050dc
Malachite		#0bda51
Manatee		#979aaa
Mandarin		#f37a48
Mango		#fdbe02
Mango Tango		#ff8243
Mantis		#74c365
Marigold		#eaa221
Maroon		#b03060
Maroon1		#ff34b3
Maroon2		#ee30a7
Maroon3		#cd2990
Maroon4		#8b1c62
Mauve		#e0b0ff
Mauve Taupe		#915f6d
Mauvelous		#ef98aa
Maximum Blue Green		#30bfbf
Maximum Blue Purple		#acace6
Maximum Green		#5e8c31
Maxmum Blue		#47abcc
May Green		#4c9141
Maya Blue		#73c2fb
Medium		#66cdaa
Medium Aquamarine		#66ddaa
Medium Candy Apple Red		#e2062c
Medium Carmine		#af4035
Medium Champagne		#f3e5ab
MediumAquamarine		#66cdaa
MediumBlue		#0000cd
MediumOrchid		#ba55d3
MediumOrchid1		#e066ff
MediumOrchid2		#d15fee
MediumOrchid3		#b452cd
MediumOrchid4		#7a378b
MediumPurple		#9370db
MediumPurple1		#ab82ff
MediumPurple2		#9f79ee
MediumPurple3		#8968cd
MediumPurple4		#5d478b
MediumSeaGreen		#3cb371
MediumSlateBlue		#7b68ee
MediumSpringGreen		#00fa9a
MediumTurquoise		#48d1cc
MediumVioletRed		#c71585
Mellow Apricot		#f8b878
Melon		#febaad
Metallic Gold		#d3af37
Metallic Seaweed		#0a7e8c
Metallic Sunburst		#9c7c38
Mexican Pink		#e4007c
Middle Blue		#7ed4e6
Middle Blue Green		#8dd9cc
Middle Blue Purple		#8b72be
Middle Green		#4d8c57
Middle Green Yellow		#acbf60
Middle Grey		#8b8680
Middle Purple		#d982b5
Middle Red		#e58e73
Middle Red Purple		#a55353
Middle Yellow		#ffeb00
Middle Yellow Red		#ecb176
Midnight Green		#004953
MidnightBlue		#191970
Mikado Yellow		#ffc40c
Mimi Pink		#ffdae9
Mindaro		#e3f988
Minion Yellow		#f5e050
Mint		#3eb489
Mint Green		#98ff98
MintCream		#f5fffa
Misty Moss		#bbb477
MistyRose1		#ffe4e1
MistyRose2		#eed5d2
MistyRose3		#cdb7b5
MistyRose4		#8b7d7b
Moccasin		#ffe4b5
Mode Beige		#967117
Moss Green		#8a9a5b
Mountain Meadow		#30ba8f
Mountbatten Pink		#997a8d
Mulberry		#c54b8c
Mustard		#ffdb58
Myrtle Green		#317873
Mystic Maroon		#ad4379
Nadeshiko Pink		#f6adc6
NavajoWhite1		#ffdead
NavajoWhite2		#eecfa1
NavajoWhite3		#cdb38b
NavajoWhite4		#8b795e
NavyBlue		#000080
Neon Blue		#4666ff
Neon Carrot		#ffa343
Neon Fuchsia		#fe4164
Neon Green		#39ff14
Nickel		#727472
Nyanza		#e9ffdb
Ocean Blue		#4f42b5
Ocean Green		#48bf91
Ochre		#cc7722
Old Burgundy		#43302e
Old Gold		#cfb53b
Old Lavender		#796878
Old Mauve		#673147
Old Rose		#c08081
OldLace		#fdf5e6
Olive		#808000
Olive Green		#b5b35c
OliveDrab		#6b8e23
OliveDrab1		#c0ff3e
OliveDrab2		#b3ee3a
OliveDrab4		#698b22
Olivine		#9ab973
Opal		#a8c3bc
Opera Maue		#b784a7
Orange (Crayola)		#ff5800
Orange Peel		#ff9f00
Orange Soda		#fa5b3d
Orange1		#ffa500
Orange2		#ee9a00
Orange3		#cd8500
Orange4		#8b5a00
OrangeRed1		#ff4500
OrangeRed2		#ee4000
OrangeRed3		#cd3700
OrangeRed4		#8b2500
Orchid		#da70d6
Orchid (Crayola)		#e29cd2
Orchid Pink		#f2bdcd
Orchid1		#ff83fa
Orchid2		#ee7ae9
Orchid3		#cd69c9
Orchid4		#8b4789
Outrageous Orange		#ff6e4a
Oxblood		#4a0000
Oxford Blue		#002147
Pacific Blue		#1ca9c9
Palatinate Purple		#682860
Pale		#db7093
Pale Aqua		#bcd4e6
Pale Cerulean		#9bc4e2
Pale Pink		#fadadd
Pale Silver		#c9c0bb
Pale Spring Bud		#ecebbd
PaleGoldenrod		#eee8aa
PaleGreen		#98fb98
PaleGreen1		#9aff9a
PaleGreen2		#90ee90
PaleGreen3		#7ccd7c
PaleGreen4		#548b54
PaleTurquoise		#afeeee
PaleTurquoise1		#bbffff
PaleTurquoise2		#aeeeee
PaleTurquoise3		#96cdcd
PaleTurquoise4		#668b8b
PaleVioletRed		#db7093
PaleVioletRed1		#ff82ab
PaleVioletRed2		#ee799f
PaleVioletRed3		#cd6889
PaleVioletRed4		#8b475d
Pansy Purple		#78184a
PapayaWhip		#ffefd5
Paradise Pink		#e63e62
Pastel Pink		#dea5a4
Patriarch (Purple)		#800080
Peach		#ffe5b4
PeachPuff1		#ffdab9
PeachPuff2		#eecbad
PeachPuff3		#cdaf95
PeachPuff4		#8b7765
Pear		#d1e231
Pearly Purple		#b768a2
Persian Blue		#1c39bb
Persian Green		#00a693
Persian Indigo		#32127a
Persian Orange		#d99058
Persian Pink		#f77fbe
Persian Plum		#701c1c
Persian Red		#cc3333
Persian Rose		#fe28a2
Pewter Blue		#8ba8b7
Phthalo Blue		#000f89
Phthalo Green		#123524
Pictorial Carmine		#c30b4e
Piggy Pink		#fddde6
Pine Green		#01796f
Pine Tree		#2a2f23
Pink		#ffc0cb
Pink (Pantone)		#d74894
Pink Flamingo		#fc74fd
Pink Sherbet		#f78fa7
Pink1		#ffb5c5
Pink2		#eea9b8
Pink3		#cd919e
Pink4		#8b636c
Pistachio		#93c572
Platinum		#e5e4e2
Plum		#8e4585
Plum1		#ffbbff
Plum2		#eeaeee
Plum3		#cd96cd
Plum4		#8b668b
Plump Purple		#5946b2
Portland Orange		#ff5a36
PowderBlue		#b0e0e6
Prussian Blue		#003153
Puce		#cc8899
Pumpkin		#ff7518
Purple		#a020f0
Purple1		#9b30ff
Purple2		#912cee
Purple3		#7d26cd
Purple4		#551a8b
Quinacridone Magenta		#8e3a59
Radical Red		#ff355e
Raspberry		#e30b5d
Razzmatazz		#e3256b
Rebeccapurple		#663399
Red Orange		#ff5349
Red1		#ff0000
Red2		#ee0000
Red3		#cd0000
Red4		#8b0000
Redwood		#a45a52
Rifle Green		#444c38
Rocket Metallic		#8a7f80
Rose		#ff007f
Rose Bonbon		#f9429e
Rose Dust		#9e5e6f
Rose Pink		#ff66cc
Rose Taupe		#905d5d
Rosewood		#65000b
RosyBrown		#bc8f8f
RosyBrown1		#ffc1c1
RosyBrown2		#eeb4b4
RosyBrown3		#cd9b9b
RosyBrown4		#8b6969
RoyalBlue		#4169e1
RoyalBlue1		#4876ff
RoyalBlue2		#436eee
RoyalBlue3		#3a5fcd
RoyalBlue4		#27408b
Ruby		#e0115f
Russet		#80461b
Russian Green		#679267
Russian Violet		#32174d
Rust		#b7410e
SaddleBrown		#8b4513
Saffron		#f4c430
Sage		#bcb88a
Salmon		#fa8072
Salmon1		#ff8c69
Salmon2		#ee8262
Salmon3		#cd7054
Salmon4		#8b4c39
SandyBrown		#f4a460
Sap Green		#507d2a
Sapphire		#0f52ba
Scarlet		#ff2400
School Bus Yellow		#ffd800
SeaGreen1		#54ff9f
SeaGreen2		#4eee94
SeaGreen3		#43cd80
SeaGreen4		#2e8b57
Seal Brown		#59260b
Seashell1		#fff5ee
Seashell2		#eee5de
Seashell3		#cdc5bf
Seashell4		#8b8682
Selective Yellow		#ffba00
Sepia		#704214
Shamrock Green		#009e60
Shocking Pink		#fc0fc0
Sienna		#a0522d
Sienna1		#ff8247
Sienna2		#ee7942
Sienna3		#cd6839
Sienna4		#8b4726
Silver		#c0c0c0
Silver Pink		#c4aead
Sinopia		#cb410b
Skobeloff		#007474
SkyBlue		#87ceeb
SkyBlue1		#87ceff
SkyBlue2		#7ec0ee
SkyBlue3		#6ca6cd
SkyBlue4		#4a708b
SlateBlue		#6a5acd
SlateBlue1		#836fff
SlateBlue2		#7a67ee
SlateBlue3		#6959cd
SlateBlue4		#473c8b
SlateGray		#708090
SlateGray1		#c6e2ff
SlateGray2		#b9d3ee
SlateGray3		#9fb6cd
SlateGray4		#6c7b8b
Smoky Black		#100c08
Snow1		#fffafa
Snow2		#eee9e9
Snow3		#cdc9c9
Snow4		#8b8989
Spanish Bistre		#807532
Spanish Orange		#e86100
Spanish Pink		#f7bfbe
Spanish Viridian		#007f5c
Spring Bud		#a7fc00
Spring Frost		#87ff2a
SpringGreen1		#00ff7f
SpringGreen2		#00ee76
SpringGreen3		#00cd66
SpringGreen4		#008b45
Steel Pink		#cc33cc
SteelBlue		#4682b4
SteelBlue1		#63b8ff
SteelBlue2		#5cacee
SteelBlue3		#4f94cd
SteelBlue4		#36648b
Straw		#e4d96f
Sunglow		#ffcc33
Super Pink		#cf6ba9
Sweet Brown		#a83731
Tan		#d2b48c
Tan1		#ffa54f
Tan2		#ee9a49
Tan3		#cd853f
Tan4		#8b5a2b
Tangerine		#f28500
Tart Orange		#fb4d46
Taupe		#483c32
Taupe Gray		#8b8589
Tea Green		#d0f0c0
Teal		#008080
Teal Blue		#367588
Terra Cotta		#e2725b
Thistle		#d8bfd8
Thistle1		#ffe1ff
Thistle2		#eed2ee
Thistle3		#cdb5cd
Thistle4		#8b7b8b
Tiffany Blue		#0abab5
Timberwolf		#dbd7d2
Titanium Yellow		#eee600
Tomato1		#ff6347
Tomato2		#ee5c42
Tomato3		#cd4f39
Tomato4		#8b3626
Tropical Rainforest		#00755e
Tumbleweed		#deaa88
Turquoise		#40e0d0
Turquoise Blue		#00ffef
Turquoise1		#00f5ff
Turquoise2		#00e5ee
Turquoise3		#00c5cd
Turquoise4		#00868b
Tuscan Red		#7c4848
Tuscany		#c09999
Twilight Lavender		#8a496b
Tyrian Purple		#66023c
UP Forest Green		#014421
UP Maroon		#7b1113
Ultra Pink		#ff6fff
Ultramarine		#3f00ff
Ultramarine Blue		#4166f5
Unbleached Silk		#ffddca
United Nations Blue		#5b92e5
Upsdell Red		#ae2029
Van Dyke Brown		#664228
Vanilla		#f3e5ab
Vanilla Ice		#f38fa9
Vegas Gold		#c5b358
Venetian Red		#c80815
Verdigris		#43b3ae
Vermillion		#e34234
Violet		#ee82ee
VioletRed		#d02090
VioletRed1		#ff3e96
VioletRed2		#ee3a8c
VioletRed3		#cd3278
VioletRed4		#8b2252
Viridian		#40826d
Viridian Green		#009698
Vivid Burgundy		#9f1d35
Vivid Sky Blue		#00ccff
Vivid Tangerine		#ffa089
Vivid Violet		#9f00ff
Volt		#ceff00
Warm Black		#004242
Wheat		#f5deb3
Wheat1		#ffe7ba
Wheat2		#eed8ae
Wheat3		#cdba96
Wheat4		#8b7e66
White		#ffffff
WhiteSmoke		#f5f5f5
Wild Blue Yonder		#a2add0
Wild Orchid		#d470a2
Wild Strawberry		#ff43a4
Windsor Tan		#a75502
Wine		#722f37
Wintergreen Dream		#56887d
Wisteria		#c9a0dc
Xanadu		#738678
Yellow Orange		#ffae42
Yellow Pantone		#fedf00
Yellow1		#ffff00
Yellow2		#eeee00
Yellow3		#cdcd00
Yellow4		#8b8b00
YellowGreen		#9acd32
Zaffre		#0014a8
Zomp		#39a78e
 
 
 */
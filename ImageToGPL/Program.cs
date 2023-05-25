using System;
using System.IO;
using System.Drawing;

namespace ImageToGPL
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0) {
                Console.WriteLine("Provide the path to a file!");
                return -1;
            }
            else if (args.Length > 1) {
                Console.WriteLine("Too many arguments!");
                return -1;
            }


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
            Color[] colors = image.Palette.Entries;

            using (StreamWriter sw = new StreamWriter(filename + ".gpl"))
            {
                sw.WriteLine("GIMP Palette");
                sw.WriteLine("#");
                sw.WriteLine("# converted from image to palette with tool by Cubebeaver");
                sw.WriteLine("# source image: " + Path.GetFileName(args[0]));
                sw.WriteLine("#");


                foreach (Color c in colors)
                {
                    sw.WriteLine($"{c.R.ToString().PadLeft(3)} {c.G.ToString().PadLeft(3)} {c.B.ToString().PadLeft(3)} Untitled");
                }
            }

            using (StreamWriter sw = new StreamWriter("package.json"))
            {
                sw.WriteLine("{");
                sw.WriteLine("  \"name\": \"imported-palettes\",");
                sw.WriteLine("  \"displayName\": \"Imported Palettes\",");
                sw.WriteLine("  \"description\": \"Palettes imported by user\",");
                sw.WriteLine("  \"version\": \"1.0\",");
                sw.WriteLine("  \"publisher\": \"none\",");
                sw.WriteLine("  \"categories\": [");
                sw.WriteLine("    \"Palettes\"");
                sw.WriteLine("  ],");
                sw.WriteLine("  \"contributes\": {");
                sw.WriteLine("    \"palettes\": [");
                sw.WriteLine("      { \"id\": \"" + filename + "\",     \"path\": \"./palette.gpl\" }");
                sw.WriteLine("    ]");
                sw.WriteLine("  }");
                sw.WriteLine("}");
            }

            Console.WriteLine("Seccessfully created palette");
            Console.WriteLine("\nCopy the created files into: %Aseprite%/data/extensions/imported-palettes/");
            Console.WriteLine("You need to create the imported-palettes folder");
            Console.WriteLine("If you import more palettes add a new element to the palettes list");

            return 0;
        }
    }
}

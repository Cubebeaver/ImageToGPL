# ImageToGPL by Cubebeaver
Converts images to GPL color palettes

The program only needs one argument: the path to the file you want to convert.

The profram will create a .gpl and a .json file.
In your <Aseprite installation folder>/data/extensions folder you shuld create a folder named "imported-palettes" and put the generated files into that.

In case you generate multiple palettes you need to add extra lines to the .json file into the "palettes" field like this:
"palettes": [
  { "id": "palette_name0",     "path": "./palette0.gpl" },
  { "id": "palette_name1",     "path": "./palette1.gpl" },
  { "id": "palette_name2",     "path": "./palette2.gpl" },
  ...
]

Sm4sh-Tools
===========
[Bug Tracker](http://www.github.com/sammi-husky/sm4sh-tools/issues) | [Request a feature or tool.](https://github.com/Sammi-Husky/Sm4sh-Tools/issues?q=is%3Aopen+is%3Aissue+label%3Aenhancement) | [![Build status](https://ci.appveyor.com/api/projects/status/e6q6vbdgjs4eoop5?svg=true)](https://ci.appveyor.com/project/Sammi-Husky/sm4sh-tools)

Miscellaneous tools for dealing with Smash 4 files.
##Requirements##
- .NET Framework 4.0
- Visual Studio 2015

##Contents##
- **[SM4SHCommand](https://github.com/Sammi-Husky/Sm4sh-Tools/tree/master/AnimCmd)**
  - Aims to be a fully fledged moveset editor including features like syntax highlighting and a model/animation/hitbox previewer.

- **[DTLS](https://github.com/Sammi-Husky/Sm4sh-Tools/tree/master/DTLS)**
  - Extractor for 3ds and wiiU dt archives. Also supports extracting game patches and patching the DT archive. Though currently cannot fully rebuild it, and the patched files must not be larger than the original.
   ```
  - Unpack dt: <dt file(s)> <ls file>
  - Unpack Update: <resource file>
  - Patch Archive: -r <dt file(s)> <ls file> <patch folder>
   ```
  
- **[PACKManager](https://github.com/Sammi-Husky/Sm4sh-Tools/tree/master/PACKManager)**
  - Used to unpack and repack .pac files, most commonly used to pack .omo animation files together.

- **[PARAM](https://github.com/Sammi-Husky/Sm4sh-Tools/tree/master/PARAM)**
  - Editor used to open / edit / view smash 4's param files. 
  - Due to the way the game handles param files, it's near impossible to fully rebuild or properly display some files. However, around 80%+ or more of them will work fine. Includes standard templates used to label entries. (right click a group to open the file and apply lables to all entries in a group)

## Building
  - Checkout the repo: `git checkout https://github.com/Sammi-Husky/Sm4sh-Tools.git`
  - Use the Solution file to build the projects.

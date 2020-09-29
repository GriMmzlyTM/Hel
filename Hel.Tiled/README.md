# Hel.Tiled - Tiled Tilemap loader

Hel.Tiled is a completely decoupled Tiled map loader. Although Hel.Tiled is used in Hel.Engine, you can use it
with any framework you want. 

Hel.Tiled is not currently stable.

Highest tested TILED version: [1.4.2](https://github.com/bjorn/tiled/releases/tag/v1.4.2)

**Hel.Tiled currently only supports JSON files**
## Installation

Nuget packages are planned once Hel.Tiled has a stable release. Until then, you'll need to clone the repo
and add Hel.Tiled as a reference in your project if you want to use it.

## Usage

[Full release documentation](https://grimmzlytm.github.io/Hel/hel-tiled/Hel.Tiled.html)

Usage depends on if this library is being used on its own or through Hel.Engine.

#### Hel.Engine usage
Using **Hel.Tiled** in **Hel.Engine** is very simple.

```c#
// Call the static tilemap loader in Hel.Engine and pass the path to your json file
// stored in Content.
var tilemap = TiledLoader.TilemapLoader("myFile.json");
```
You can now use the tilemap object. This will also load the proper textures.

#### Hel.Tiled usage

```c#
// Call the tilemap loader
var tilemap = TiledFactory.LoadTilemap(@"path/to/file.json");
```

This will load the tilemap and its tilesets. Tileset textures will **NOT** be loaded however. 

## Contributing
Please view Contributing.md

## License
Please mention Hel.Tiled and provide a link if you choose to use it in your project.   
[MIT](https://choosealicense.com/licenses/mit/)
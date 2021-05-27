# DTG-2020
> This repo requires Git LFS support, install it from [here](https://git-lfs.github.com/) or from your preffered package manager
## Required Software
 - Git and Git LFS
 - Unity 2020.2.0a18 - To build and edit levels
 - Code Editor (e.g. Jetbrains Rider, Visual Studio etc.) - To Edit Code
 - Image editors (e.g. Glimpse, Photoshop, Piskel)
 - Blender - 3D Modeling, UV Mapping, Texture Editing

## VS Code Intellisense (Linux)
1. Install Mono Complete and DotNet SDK

	Example (Fedora)
```bash
 $ sudo dnf install dotnet-sdk-5.0 monocomplete
```
2. Configure Unity Preferences, Edit > Preferences > External Tools,
	select VS Code (usr/bin/code or bin/code) as the default editor.
3. In the same menu select the following to generate .csproj files for
	- Embedded Packages
	- Local Packages
	- Git Packages
	- Built In Packages
	
	and regenerate the project files
4. Install the VS Code C# Extension
5. Go Manage (the cog icon) > Extension Settings and set "Use Global Mono" to "always"

## Todo
- [x] Player Movement
	- [x] Walking
	- [x] Jumping
	- [x] Grappling Hook
		- [ ] ~~Refined Line Collision~~
		- [ ] Prevent Player From Phasing Through Surfaces by Using The Grappling Hook
	- [x] Underwater Vertical Movement
- [x] Torch (Environment)
	- [x] Bloom
	- [x] 2D Light
	- [x] Particles
- [ ] Handheld Torch
	- [x] Bloom
	- [x] 2D Light
	- [x] Particles
	- [x] Switching Directions
	- [ ] Throwing Mechanic
	- [ ] Fire Mechanic
	- [x] Extinguishes Underwater
- [ ] Crystal
	- [x] Bloom
	- [x] Light Effects
	- [ ] Particles
	- [x] Animations
	- [x] Item Effects
- [x] Pause Screen
	- [x] Blur Effect
	- [x] Stop Time
	- [x] Fade In
	- [x] Fade Out
- [ ] Water
	- [x] Shader Overhaul
		- [x] Waves  
		- [x] Tiles
	- [x] Particles
		- [x] Physics
		- [x] Textures
	- [ ] Level Elements
		- [x] Walls and Floor Behind Water
		- [x] Spikes
		- [x] Bubbles
		- [ ] Falling Level Segments
	- [x] Buoyancy
- [ ] Vegetation
## Attribution
- This project uses the [Fira Type Face](github.com/mozilla/Fira). Thanks [Mozilla](www.mozilla.org) and Contributors for your hard work.

# UPM Embed

A Unity editor extension that allows you to easily embed UPM (Unity Package Manager) packages as local copies in your project for modification and customization.

## Overview

**upm-embed** provides a simple context menu option to convert UPM packages from remote references to local embedded copies within your Unity project. This is particularly useful when you need to:

- Modify package source code for your specific needs
- Debug package functionality during development
- Create custom versions of existing packages
- Ensure package availability regardless of external dependencies

## Features

- **One-click embedding**: Right-click on any package in the Packages folder and select "Embed Package"
- **Unity 2019.2+ support**: Compatible with Unity 2019.2 and later versions
- **Seamless integration**: Uses Unity's built-in Package Manager API
- **Automatic refresh**: Project automatically refreshes after embedding

## Installation

### Method 1: Download and Import
1. Download the latest release or clone this repository
2. Copy the `Assets/EmbedPackage` folder to your Unity project's `Assets` folder
3. Unity will automatically compile the extension

### Method 2: Git Submodule
```bash
cd your-unity-project
git submodule add https://github.com/liortal53/upm-embed.git Assets/EmbedPackage
```

### Method 3: UPM Git URL (Unity 2019.3+)
1. Open Unity Package Manager
2. Click the `+` button and select "Add package from git URL"
3. Enter: `https://github.com/liortal53/upm-embed.git?path=Assets/EmbedPackage`

## Usage

1. **Open your Unity project** and ensure the UPM Embed extension is installed
2. **Navigate to the Project window** and expand the `Packages` folder
3. **Right-click on any package** you want to embed (packages must be direct children of the Packages folder)
4. **Select "Embed Package"** from the context menu
5. **Wait for the process to complete** - Unity will automatically refresh and the package will be moved to your project's `Packages` folder as a local copy

### Before Embedding
```
Packages/
├── com.unity.package-name@1.0.0 (remote)
└── manifest.json
```

### After Embedding
```
Packages/
├── com.unity.package-name/ (local copy)
│   ├── package.json
│   ├── Runtime/
│   └── Editor/
└── manifest.json
```

## Requirements

- **Unity Version**: 2019.2 or later
- **Platform**: All platforms supported by Unity
- **Dependencies**: None (uses built-in Unity Package Manager API)

## Project Structure

```
Assets/
└── EmbedPackage/
    ├── package.json              # UPM package definition
    ├── EmbedPackages.asmdef      # Assembly definition
    └── Scripts/
        └── EmbedPackage.cs       # Main extension script
```

## How It Works

The extension uses Unity's `PackageManager.Client.Embed()` API to convert remote package references to local copies. When you select "Embed Package":

1. The extension identifies the selected package name
2. Calls `Client.Embed(packageName)` to perform the embedding
3. Triggers `AssetDatabase.Refresh()` to update the project view

## Troubleshooting

### Package not appearing in context menu
- Ensure the package is a direct child of the `Packages` folder
- The extension only works with packages in the `Packages/` directory

### Embedding fails
- Check the Console for error messages
- Ensure you have write permissions in your project directory
- Verify the package is properly installed via Package Manager

### Unity version compatibility
- This extension requires Unity 2019.2 or later
- For older Unity versions, manual package copying is required

## Contributing

Contributions are welcome! Please feel free to:

- Report bugs or issues
- Submit feature requests
- Create pull requests with improvements
- Share feedback and suggestions

### Development Setup
1. Fork this repository
2. Create a new Unity project (2019.2+)
3. Copy the `Assets/EmbedPackage` folder to your project
4. Make your changes and test thoroughly
5. Submit a pull request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

- **Author**: Lior Tal
- **Repository**: [github.com/liortal53/upm-embed](https://github.com/liortal53/upm-embed)
- **Issues**: [Report issues](https://github.com/liortal53/upm-embed/issues)

## Changelog

### Version 0.1.0
- Initial release
- Basic package embedding functionality
- Unity 2019.2+ support
- Context menu integration

---

*Made with ❤️ for the Unity community*

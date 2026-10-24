# Snipping Tool Remastered

A legacy Windows screenshot utility built with C# and Windows Forms. This repository continues work originally based on [Hyperdesktop2](https://github.com/michaelmob/Hyperdesktop2).

> **Maintenance status:** The original project was discontinued. The `fix/hidpi-capture-and-security` branch contains proposed fixes that are still undergoing review. Do not consider them production-tested until a Windows build and functional tests pass.

## Features

- Capture the primary display, foreground window, or a selected region.
- Select areas across the Windows virtual desktop, including monitors with negative coordinates.
- Save screenshots locally as PNG, JPG, or BMP.
- Optionally edit captures before saving or uploading.
- Upload to Imgur and copy an uploaded image link to the clipboard.
- Run from the Windows notification area and register global capture shortcuts.

## System requirements

- Windows with .NET Framework 4.8.
- Visual Studio with .NET desktop development tools (for building from source).
- Network access and a valid Imgur client ID for uploads.

**Windows only:** This is a Windows Forms application using Windows APIs. The older README's cross-platform claim was incorrect.

## Build from source

1. Clone this repository and open `Snipping Tool Remastered.sln` in Visual Studio on Windows.
2. Restore the NuGet packages required by the solution.
3. Build the solution using the `Release` configuration.
4. Test locally before distributing the executable.

**Known build limitation:** The legacy project contains a machine-specific `DeepAI.dll` reference and older bundled dependencies. A clean build may require further dependency cleanup. A successful reproducible build has not yet been verified.

## Capture shortcuts

| Shortcut | Action |
| --- | --- |
| Ctrl + Shift + 3 | Capture the primary screen |
| Ctrl + Shift + 4 | Select a rectangular region |
| Ctrl + Shift + 5 | Capture the foreground window |

Global shortcuts can fail to register when another application already owns them.

## HiDPI and multi-monitor support

The proposed fix enables per-monitor DPI awareness and uses virtual-desktop coordinates to improve capture alignment on scaled and multiple displays. It also corrects the native window-rectangle layout.

Before merging or releasing, verify captures at 100%, 125%, 150%, and 200% scaling, including mixed-DPI monitors positioned to the left or above the primary monitor. Custom capture boundaries must also be tested.

## Screenshots and logo

The previous README embedded two images hosted on Discord's attachment CDN. Those links are no longer accessible through the checked public endpoints, and neither file was found in the repository or its inspected README history.

The original images have **not** been recovered. No replacement screenshot is presented as genuine. To restore them, obtain the originals from the project's maintainers or create fresh screenshots from a working Windows build, then commit the files under a local `docs/images/` directory and reference them with relative paths.

The application icon remains tracked at `Snipping Tool Remastered/icon/Snipping_Tool_Remastered.ico`.

## Security and privacy

- Screenshots may contain sensitive data. Review an image before uploading it to a third-party service.
- Imgur uploads leave your device; do not assume they are private or confidential.
- The legacy codebase includes older dependencies and security-sensitive functionality. Review and test changes before releasing.
- Review the application configuration before enabling launch at Windows startup.

## Credits

- Original codebase: [michaelmob/Hyperdesktop2](https://github.com/michaelmob/Hyperdesktop2)
- Continuation and modifications: Nova (qzxtu)
- License: [GPL-3.0](LICENSE)

## Support

Use [GitHub Issues](https://github.com/fl2on/Snipping-Tool-Remastered-Discontinued/issues) to report reproducible defects or submit improvements.

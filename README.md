![Screenshot](https://github.com/LePopal/PRACT/blob/GUI/PRACT_GUI/Pictures/PRACT_GUI_BackupMusic1.png)

# PRACT
**Popal's Rekordbox.xml Analysis and Clean up Tool** is a program design to address several limitations in the Rekordbox Library management features including:
* Listing duplicate tracks
* Listing tracks not listed in any playlists
* Listing un-prepared tracks
* Listing files on disk that are not referenced in the library
* Exporting the list of missings files
* Copy music files to another location (v0.6)

PRACT will analyze a  library exported as an XML File then export some m3u8 files containing references to the duplicate, unlisted, unprepared, unreferenced and missing tracks. You can then import those list as a playlist in Rekordbox for further investigation.

## Author

Axel Pironio ([popal.fr](http://popal.fr)).

If you would like to support my work, you can make a [small donatation through Paypal](https://www.paypal.me/jmgcuc). Thank you very much!

## Requirements

PRACT is designed to run on Windows 10 with the .Net Core 3.1 Desktop Runtime and Rekordbox up to 5.x.

## Installation

1. Make sure you have installed the [latest .Net Core 3.1 Desktop runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1)
2. Unzip the portable version of your choice (see releases) to the folder of choice

## Usage

Starting from version 0.5.0 PRACT a Windows Application. It's designed to run on Windows 10 or higher.

1. Install PRACT using the provided installer or the portable version
1. In Rekordbox, export your library as an XML File : *File / Export collection in .xml Format*
2. In PRACT, choose File / Open and select your exported library
3. Choose any of the options and click "Process"

The result will be a set of M3U8 playlists you just need to import in Rekordbox or a music player of your choice.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Project status

PRACT is in active development. Adaptation to Rekordbox v6 is planned. Please feel free to open an issue should you encounter any repeatable problem.

## License
[Apache 2.0](https://choosealicense.com/licenses/apache-2.0/)

Rekordbox and Pioneer DJ are trademarks from AlphaTheta Corporation. The author is not affiliated with AlphaTheta Corporation.

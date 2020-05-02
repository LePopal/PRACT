# PRACT
**Popal's Rekordbox.xml Analysis and Clean up Tool** is a program design to address several limitations in the Rekordbox Library management features including:
* Listing duplicate tracks
* Listing tracks not listed in any playlists
* Listing un-prepared tracks
* Listing files on disk that are not referenced in the library
* Exporting the list of missings files

PRACT will analyze a  library exported as an XML File then export some m3u8 files containing references to the duplicate, unlisted, unprepared, unreferenced and missing tracks. You can then import those list as a playlist in Rekordbox for further investigation.

## Author

Axel Pironio ([popal.fr](http://popal.fr)).

## Requirements

PRACT is designed to run on Windows 10 with the .Net Core 3.1 Desktop Runtime and Rekordbox up to 5.x.

## Installation

1. Make sure you have installed the [latest .Net Core 3.1 Desktop runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1)
2. Unzip the portable version of your choice (see releases) to the folder of choice

## Usage

PRACT is a command line program only and as such may require advanced Windows or MS-DOS knowledge.

1. In Rekordbox, export your library as an XML File : *File / Export collection in .xml Format*
2. In Windows, open a command-line prompt : open the Start Menu and type "cmd", the choose "Command Prompt" (it should be the first of the list)
3. Navigate to the folder where you unzipped PRACT
4. Type "PRACT" to see the list of available options

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Project status

PRACT is in active development. Adaptation to Rekordbox v6 is planned. Please feel free to open an issue should you encounter any repeatable problem.

## License
[Apache 2.0](https://choosealicense.com/licenses/apache-2.0/)

Rekordbox and Pioneer DJ are trademarks from AlphaTheta Corporation. The author is not affiliated with AlphaTheta Corporation.
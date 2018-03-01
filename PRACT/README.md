# PRACT
Popal's Rekordbox.xml Analysis and Clean up Tool

### Version 0.2 :
- New playlists generated :
	- Missing tracks : tracks present in the library but not on disk, sorted by location
	- Untagged tracks : tracks not properly tagged i.e. tracks without Name or Artist, tracks with the same Name and Artist, tracks containing the word "Various"
- Minor bugfix

### Version 0.1.1 :
- First GitHub Push

### Version 0.1 :
- Loads a Rekordbox.xml into memory
- Generates playlists :
	- Unanalyzed tracks
	- Duplicate tracks (same title, same artist)
	- Orphaned tracks (tracks that appear in no playlists)
- Run "PRACT.exe -- help" without quotes for usage

<!--Version 0.3
- New Option : destroy
	- run PRACT.exe -p | playlist <playlist> to locally delete every file on that playlist
	- WARNING : This operation is undoable and will physically delete the files with no chance of recovery !
- -->
# UndoStripperForArtRageScripts
A simple tool for the [ArtRage](https://www.artrage.com/) drawing program. The tool strips out strokes that were removed with an Undo event from ArtRage script recordings. This tool has been built in [Unity](https://unity3d.com/).

# Download

Get the latest version [from the releases page](https://github.com/bitbutter/UndoStripperForArtRageScripts/releases).

# Instructions

* Duplicate an existing ArtRage script file that has Undo events in it.

* Open the duplicated file in Sublime Text. Delete any 'NUL' items you see inside the Header block.

* Select all the text in the file and copy it to the clipboard.

* Launch UndoStripperForArtRageScripts and click the 'Process' button. After a short delay the background will turn green. Then go back to the text editor and paste the clipboard contents back in, overwriting the selection. Save the file.

* When you run the new file in ArtRage it will play back without showing any strokes that you used the Undo function to remove while drawing.

These instructions are displayed in the tool window too.

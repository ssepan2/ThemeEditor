VisualThemeEditor v2.1 for Visual Studio 2012 and Later


Purpose:
Tool to edit Visual Studio 2012 (and later) Themes, including Express Editions.


Usage notes:

~Select Version and Edition.
~Select Theme and Category.
~Select Color name, and edit Foreground and / or Background.
~Click 'Save Color'.


Enhancements:

~2.2:
~Updated Ssepan.* to 2.6
~updated to Framework 4.8
~converted to SDK style project

2.1:
~Updated Ssepan.* to 2.6

2.0:
~Moved domain classes into class library (DLL).
~Branched and modified in Visual Studio 2013 Express Desktop.
~Added error handling, logging, and display.
~Added display and handling of Alpha channel info.
~Added options for varying by Version and Edition.
~Added form resizing.
~Added ability to inspect data at run-time, via PropertyDialog.
~Omitted ObjectDumper, since PropertyDialog will allow run-time inspection of data.
~Added Help|About attributions.

1.0
~Legacy app (http://bchavez.bitarmory.com/archive/2012/08/27/modify-visual-studio-2012-dark-and-light-themes.aspx), 
written by Brian Chavez (http://twitter.com/bchavez) 

Fixes:
~Added checking of Alpha channel to prevent loss of transparency definitions, and the ability to manually repair.

Known Issues:
~Running this app under Vista or Windows 7 requires that the library that writes to the event log (Ssepan.Utility.dll) have its name added to the list of allowed 'sources'. Rather than do it manually, the one way to be sure to get it right is to simply run the application the first time As Administrator, and the settings will be added. After that you may run it normally. To register additional DLLs for the event log, you can use this trick any time you get an error indicating that you cannot write to it. Or you can manually register DLLs by adding a key called '<filename>.dll' under HKLM\System\CurrentControlSet\services\eventlog\Application\, and adding the string value 'EventMessageFile' with the value like <C>:\<Windows>\Microsoft.NET\Framework\v2.0.50727\EventLogMessages.dll (where the drive letter and Windows folder match your system). Status: work-around. 

Possible Enhancements:
~Use MVC or MVVM, and databinding, to control changes to data and perform updates to UI.


Steve Sepan
ssepanus@yahoo.com
4/18/2014
@REM TODO: NUGET.exe sollte über Standard-Pfad für Nuget CLI aufgerufen werden (evtl. im build process abrufen/installieren?) 
@REM "..\..\..\oqtane.framework\oqtane.package\nuget.exe" pack ToSic.Oqt.Themes.ToShineBs5.nuspec 

 XCOPY "*.nupkg" "..\..\website\wwwroot\Themes\" /Y

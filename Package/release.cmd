"..\..\oqtane.framework\oqtane.package\nuget.exe" pack ToSic.Oqt.Themes.ToSicStatus.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y

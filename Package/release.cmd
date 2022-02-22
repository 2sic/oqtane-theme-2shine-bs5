"..\..\oqtane.framework\oqtane.package\nuget.exe" pack ToSic.Oqt.Themes.ToShineBs5.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y

XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js" "..\Client\dist\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I
XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js.map" "..\Client\dist\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I
XCOPY "..\Client\src\navigation.json" "..\Client\dist\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I

"..\..\oqtane.framework\oqtane.package\nuget.exe" pack ToSic.Oqt.Themes.ToShineBs5.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y

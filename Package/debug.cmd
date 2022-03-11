XCOPY "..\Client\bin\Debug\net6.0\ToSic.Oqt.Themes.ToShineBs5.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Client\bin\Debug\net6.0\ToSic.Oqt.Themes.ToShineBs5.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Client\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I
XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js.map" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I
XCOPY "..\Client\global-settings.json" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I

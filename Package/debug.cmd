XCOPY "..\Client\bin\Debug\net6.0\ToSic.Oqt.Themes.ToShineBs5.Client.Oqtane.dll" "..\..\website\bin\Debug\net6.0\" /Y
XCOPY "..\Client\bin\Debug\net6.0\ToSic.Oqt.Themes.ToShineBs5.Client.Oqtane.pdb" "..\..\website\bin\Debug\net6.0\" /Y

XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js" "..\Client\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I
XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js.map" "..\Client\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I
XCOPY "..\Client\src\navigation.json" "..\Client\wwwroot\Themes\ToSic.Oqt.Themes.ToShineBs5" /Y /S /I

XCOPY "..\Client\wwwroot\*" "..\..\website\wwwroot\" /Y /S /I

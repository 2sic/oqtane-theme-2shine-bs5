XCOPY "..\Client\bin\Debug\net6.0\ToSic.Oqt.Themes.ToSicStatus.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Client\bin\Debug\net6.0\ToSic.Oqt.Themes.ToSicStatus.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y

XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js" "..\Client\wwwroot\Themes\ToSic.Oqt.Themes.ToSicStatus" /Y /S /I
XCOPY "..\Client\node_modules\bootstrap\dist\js\bootstrap.bundle.min.js.map" "..\Client\wwwroot\Themes\ToSic.Oqt.Themes.ToSicStatus" /Y /S /I
XCOPY "..\Client\src\navigation.json" "..\Client\wwwroot\Themes\ToSic.Oqt.Themes.ToSicStatus" /Y /S /I

XCOPY "..\Client\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I

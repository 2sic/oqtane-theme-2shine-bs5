"..\NugetCLI\nuget.exe" pack ToSic.Oqt.Themes.ToSicStatus.nuspec 
XCOPY "*.nupkg" "..\..\website\wwwroot\Themes\" /Y

"..\NugetCLI\nuget.exe" pack ToSic.Oqt.Themes.ToShineBs5.nuspec 
XCOPY "*.nupkg" "..\..\website\wwwroot\Themes\" /Y

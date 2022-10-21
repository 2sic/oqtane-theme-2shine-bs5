require("jsonc-require");
const shell = require("shelljs");
const path = require("path");
const fs = require("fs");

let themeConfig = require("../../build-theme.json");

if (!themeConfig || !themeConfig.OqtaneRoot) {
  themeConfig = {
    OqtaneRoot: "../web",
    PublishDebug: false,
    Publish: {
      Watch: true,
      Build: true,
      RestartOqtane: true,
    },
  };
}

if (!path.isAbsolute(themeConfig.OqtaneRoot)) {
  themeConfig.OqtaneRoot = path.normalize(
    path.join("..", themeConfig.OqtaneRoot)
  );
}

if (themeConfig.Publish.Build) {
  publish(themeConfig.Publish.RestartOqtane);
}

function publish(restart = false) {
  console.log(
    `copy theme to oqtane dir specified in build-theme.json: '${themeConfig.OqtaneRoot}'`
  );
  const appOfflinePath = path.join(themeConfig.OqtaneRoot, "app_offline.htm");

  // create app_offline.htm; stops iis app
  if (restart)
    fs.writeFileSync(appOfflinePath, "2shine Theme update running ...");

  // copy *.nupkg to InstallPackages
  shell.cp(
    "-Rf",
    "bin/Release/*.nupkg",
    "../InstallPackages"
  );

  shell.cp(
    "-Rf",
    "bin/Release/*.nupkg",
    path.join(themeConfig.OqtaneRoot, "wwwroot", "Themes")
  );

  // remove app_offline.htm; restarts iis app
  if (restart) fs.unlinkSync(appOfflinePath);
}

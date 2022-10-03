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

if (!themeConfig.OqtaneBin) {
  themeConfig.OqtaneBin = path.join(
    themeConfig.OqtaneRoot,
    "bin",
    "Debug",
    "net6.0"
  );
}

if (!path.isAbsolute(themeConfig.OqtaneRoot)) {
  themeConfig.OqtaneRoot = path.normalize(
    path.join("..", themeConfig.OqtaneRoot)
  );
}

if (!path.isAbsolute(themeConfig.OqtaneBin)) {
  themeConfig.OqtaneBin = path.normalize(
    path.join("..", themeConfig.OqtaneBin)
  );
}

if (themeConfig.Publish.Watch) {
  publish(themeConfig.Publish.RestartOqtane);
}

function publish(restart = false) {
  const appOfflinePath = path.join(themeConfig.OqtaneRoot, "app_offline.htm");

  // create app_offline.htm; stops iis app
  if (restart)
    fs.writeFileSync(appOfflinePath, "2shine Theme update running ...");

  shell.cp("-Rf", "bin/Debug/net6.0/*", themeConfig.OqtaneBin);

  // remove app_offline.htm; restarts iis app
  if (restart) fs.unlinkSync(appOfflinePath);
}

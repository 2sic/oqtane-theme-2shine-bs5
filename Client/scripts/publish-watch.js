require("jsonc-require");
const shell = require("shelljs");
const path = require("path");
const fs = require("fs");

let themeConfig = require("../theme.jsonc");

if (!themeConfig || !themeConfig.OqtaneRoot) {
  themeConfig = {
      OqtaneRoot: "../web",
      OqtaneWwwRoot: "../web",
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

if (!path.isAbsolute(themeConfig.OqtaneWwwRoot)) {
    themeConfig.OqtaneWwwRoot = path.normalize(
        path.join("..", themeConfig.OqtaneWwwRoot)
    );
}

if (themeConfig.Publish.Watch) {
  publish(themeConfig.Publish.RestartOqtane);
}

function publish(restart = false) {
  console.log(`copy theme to oqtane dir`);
  const appOfflinePath = path.join(themeConfig.OqtaneRoot, "app_offline.htm");

  // create app_offline.htm; stops iis app
  if (restart)
    fs.writeFileSync(appOfflinePath, "2shine Theme update running ...");

  shell.cp("-Rf", "bin/Debug/net6.0/*", themeConfig.OqtaneRoot);

  // remove app_offline.htm; restarts iis app
  if (restart) fs.unlinkSync(appOfflinePath);
}

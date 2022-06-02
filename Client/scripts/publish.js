require("jsonc-require");
const shell = require("shelljs");
const path = require("path");

let themeConfig = require("../theme.jsonc");

if (!themeConfig || !themeConfig.OqtaneRoot) {
  themeConfig = {
    OqtaneRoot: "../web",
    PublishDebug: false,
  };
}

if (!path.isAbsolute(themeConfig.OqtaneRoot)) {
  themeConfig.OqtaneRoot = `../${themeConfig.OqtaneRoot}`;
}

if (themeConfig.PublishDebug) {
  console.log(`copy theme to oqtane dir`);
  shell.cp("-Rf", "bin/Debug/net6.0/*", themeConfig.OqtaneRoot);
}

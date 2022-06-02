let shell = require("shelljs");
let themeConfig = require("../theme.json");

if (!themeConfig || !themeConfig.OqtaneRootReleativePath) {
  themeConfig = {
    OqtaneRootReleativePath: "../website",
    PublishDebugBuildToOqtane: false,
  };
}

if (themeConfig.PublishDebugBuildToOqtane) {
  console.log(`copy theme to oqtane dir`);
  shell.cp(
    "-Rf",
    "bin/Debug/net6.0/*",
    `../${themeConfig.OqtaneRootReleativePath}`
  );
}

require("jsonc-require");
const shell = require("shelljs");
let themeConfig = require("../../build-theme.json");

if (!themeConfig || !themeConfig.ThemeName) {
  themeConfig = {
    ThemeName: "ToSic.Themes.ToShineBs5",
  };
}

console.log(`cleaning dist directory`);
shell.rm("-rf", `wwwroot/*`);

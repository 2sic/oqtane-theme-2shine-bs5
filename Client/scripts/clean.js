require("jsonc-require");
const shell = require("shelljs");
let themeConfig = require("../theme.json");

if (!themeConfig || !themeConfig.ThemeName) {
  themeConfig = {
    ThemeName: "ToSic.Oqt.Themes.ToShineBs5",
  };
}

console.log(`cleaning dist directory`);
shell.rm("-rf", `dist/*`);

let shell = require("shelljs");
let themeConfig = require("../theme.json");

if (!themeConfig || !themeConfig.ThemeName) {
  themeConfig = {
    ThemeName: "ToSic.Oqt.Themes.ToShineBs5",
  };
}
console.log(
  `cleaning dist directory dist/wwwroot/Themes/${themeConfig.ThemeName}`
);
shell.rm("-rf", `dist/wwwroot/Themes/${themeConfig.ThemeName}/*`);
console.log("done");

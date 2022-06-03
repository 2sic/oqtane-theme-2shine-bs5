require("jsonc-require");
const replace = require("replace-in-file");
const shell = require("shelljs");
const path = require("path");
const fs = require("fs");

const defaultThemeName = "ToSic.Oqt.Themes.ToShineBs5";

let themeConfig = require("../theme.jsonc");
if (!themeConfig || !themeConfig.ThemeName) {
  themeConfig = {
    ThemeName: "ToSic.Oqt.Themes.ToShineBs5",
  };
}

if (themeConfig.ThemeName === defaultThemeName) {
} else {
  const options = {
    files: ["**/*.razor", "**/*.cs", "**/*.csproj", "**/*.sln"],
    ignore: [
      "obj/**",
      "bin/**",
      "node_modules/**",
      "scripts/**",
      "dist/**",
      ".temp_cache/**",
      ".vscode/**",
    ],
    from: RegExp(defaultThemeName, "g"),
    to: themeConfig.ThemeName,
  };

  try {
    const results = replace.sync(options);
    console.log("Replacement results:", results);
  } catch (error) {
    console.error("Error occurred:", error);
  }
}

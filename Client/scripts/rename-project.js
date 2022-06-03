require("jsonc-require");
const replace = require("replace-in-file");
const shell = require("shelljs");
const path = require("path");
const fs = require("fs");

const prompt = require("prompt");
const properties = [
  {
    description: "Theme-Name (namespace eg. ToSic.Oqt.Themes.MyFancyTheme)",
    name: "newThemeName",
    required: true,
    validator: /^(@?[a-z_A-Z]\w+(?:\.@?[a-z_A-Z]\w+)*)+$/,
    warning: "your theme name must be a valid c# namespace",
  },
];

prompt.start();
prompt.get(properties, function (err, result) {
  if (err) {
    return onErr(err);
  }

  renameTheme(result.newThemeName);
});

function onErr(err) {
  console.log(err);
  return 1;
}

function renameTheme(newThemeName) {
  const defaultThemeName = "ToSic.Oqt.Themes.ToShineBs5";
  if (newThemeName === defaultThemeName) {
    console.log("Theme already renamed");
  } else {
    const options = {
      files: ["**/*.razor", "**/*.cs", "**/*.csproj", "../*.sln"],
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
      to: newThemeName,
    };
    try {
      const results = replace.sync(options);
      console.log("Replacement results:", results);
      const defaultCsharpProject = "ToSic.Oqt.Themes.ToShineBs5.Client.csproj";
      const defaultVsSolution = "../ToSic.Oqt.Themes.ToShineBs5.sln";
      if (fs.existsSync(defaultCsharpProject))
        fs.renameSync(defaultCsharpProject, `${newThemeName}.Client.csproj`);
      if (fs.existsSync(defaultVsSolution))
        fs.renameSync(defaultVsSolution, `../${newThemeName}.sln`);
    } catch (error) {
      console.error("Error occurred:", error);
    }
  }
}

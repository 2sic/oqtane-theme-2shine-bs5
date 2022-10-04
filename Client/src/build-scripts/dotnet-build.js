const fs = require("fs");

if (!fs.existsSync("node_modules")) {
  const npm = require("npm");
  npm.load(function (err) {
    npm.on("log", function (message) {
      console.log(message);
    });

    npm.commands.ci([], function (er, data) {
      build();
    });
  });
} else {
  build();
}

function build() {
  const shell = require("shelljs");
  shell.exec("dotnet build -c Release", {
    silent: false,
    async: false,
  });

  console.log("\x1b[32m%s\x1b[0m", "DONE");
}

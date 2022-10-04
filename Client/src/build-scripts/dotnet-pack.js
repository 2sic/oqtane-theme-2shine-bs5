const fs = require("fs");

if (!fs.existsSync("node_modules")) {
  const npm = require("npm");
  npm.load(function (err) {
    npm.on("log", function (message) {
      console.log(message);
    });

    npm.commands.ci([], function (er, data) {
      packPublish();
    });
  });
} else {
  packPublish();
}

function packPublish() {
  const shell = require("shelljs");

  shell.exec(
    "dotnet pack -c Release --no-build -p:NuspecFile=Package/Theme.nuspec",
    {
      silent: false,
      async: false,
    }
  );

  shell.exec("node src/build-scripts/publish-build-pack.js", {
    silent: false,
    async: false,
  });

  console.log("\x1b[32m%s\x1b[0m", "DONE");
}

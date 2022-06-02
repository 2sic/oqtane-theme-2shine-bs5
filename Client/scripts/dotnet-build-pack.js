const shell = require("shelljs");

shell.exec("dotnet build -c Release", {
  silent: false,
  async: false,
});

shell.exec("dotnet pack -c Release --no-build", {
  silent: false,
  async: false,
});

shell.exec("npm run publish-build-pack", {
  silent: false,
  async: false,
});

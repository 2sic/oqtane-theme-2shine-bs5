const shell = require("shelljs");
shell.exec("dotnet watch build -c Debug", {
  silent: false,
  async: false,
});

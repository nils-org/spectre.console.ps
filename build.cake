var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var rootDir = Directory(".");
var srcDir = rootDir + Directory("src");
var binDir = rootDir + Directory("bin");

Task("Clean")
.Does(() => {
   CleanDirectory(binDir);
});

Task("Compile")
.Does(() => {
   var binModule = binDir + Directory("bin");
   CreateDirectory(binModule);
   DotNetPublish(
      srcDir + File("spectre.console.ps/spectre.console.ps.csproj"), 
      new DotNetPublishSettings
      {
         OutputDirectory = binModule
      });
   CopyFiles((srcDir + File("spectre.console.ps.ps?1")).Path.FullPath, binDir);
});

Task("Default")
 .IsDependentOn("Clean")
 .IsDependentOn("Compile");

RunTarget(target);
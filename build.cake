#addin nuget:?package=Cake.Coverlet

//ARGUMENTS
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var infrBaseDir = Argument("infrBaseDir", "StarWarsKb.Infrastructure");
var backBaseDir = Argument("backBaseDir", "StarWarsKb.Back");
var frontBaseDir = Argument("frontBaseDir", "StarWarsKb.Front");

//PREPARATION

//TASKS
Task("CleanAllOutputDirs")
.Does(() =>
{
    CleanDirectory($"./{infrBaseDir}/bin/{configuration}");
    Information($"clean {infrBaseDir} output dir");

    CleanDirectory($"./{backBaseDir}/bin/{configuration}");
    Information($"clean {backBaseDir} output dir");

    CleanDirectory($"./{frontBaseDir}/bin/{configuration}");
    Information($"clean {frontBaseDir} output dir");
});

Task("ReleaseBuildAll")
.IsDependentOn("CleanAllOutputDirs")
.Does(()=>
{
     DotNetCoreBuild("./StarWarsKb.sln", new DotNetCoreBuildSettings
     {
        Configuration = configuration,
     });
});

Task("Test")
    .IsDependentOn("ReleaseBuildAll")
    .Does(() =>
{
    DotNetTest("./StarWarsKb.sln", new DotNetCoreTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
    });
});

Task("TestCoverage")
    .IsDependentOn("Test")
    .Does(() =>
{
    var testSettings = new DotNetCoreTestSettings { 
        Configuration = configuration,
        NoBuild = true,       
    };

    var coverletSettings = new CoverletSettings {
        CollectCoverage = true,
        CoverletOutputFormat = CoverletOutputFormat.opencover,
        CoverletOutputDirectory = Directory(@".\coverage-results\"),
        CoverletOutputName = $"results-{DateTime.UtcNow:dd-MM-yyyy-HH-mm-ss-FFF}",
    };

    DotNetCoreTest("./StarWarsKb.sln", testSettings, coverletSettings);
});

RunTarget(target);
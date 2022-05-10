//ARGUMENTS
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

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

RunTarget(target);

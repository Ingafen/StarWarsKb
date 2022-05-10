//ARGUMENTS
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//PREPARATION

//TASKS
Task("HelloWorld")
.Does(() =>
{
    Information("Hello, World!");
});

RunTarget(target);
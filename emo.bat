@echo off
cls
SET EnableNuGetPackageRestore=true
if not exist "tools\emo\tools\emo.exe" (
	"tools\nuget\nuget.exe" "install" "emo" "-OutputDirectory" "tools" "-ExcludeVersion"
)

"tools\emo\tools\emo.exe" --debug

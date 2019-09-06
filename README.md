This is a default build for all C# projects as of right now.

Mostly created so I don't have to build a new one each time.

Also allows me to easily clone certain configurations I want.

# Before Beginning

## Change:
    
    * ../DefaultForVSCode/ to ../YourProjectName/
    
    * ./DefaultForVSCode.csproj to ./YourProjectName.csproj

    * namespace DefaultForVSCode to namespace YourProjectName
    
    *In launch.json "program": change DefaultForVSCode.dll to YourProjectName.dll

# Basic Info for Help

## To remove a folder if .gitignore isn't doing it

git rm -r --cached .
git add .
git commit -am "Remove ignored files"

## To change from external terminal

    * in your launch.json change "console":"externalTerminal" to "internalTerminal"

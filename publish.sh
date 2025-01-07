# /bin/bash -ex
rm -rf _publish
dotnet clean src
dotnet publish src/SwApiNet -o _publish

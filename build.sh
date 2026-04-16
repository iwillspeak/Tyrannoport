#! /usr/bin/env bash

if [ -z "$BUILD_SOURCEBRANCH" ]
then
    echo "Initialising local branch state"
    BUILD_SOURCEBRANCH=`git branch --show-current`
fi

set -euox pipefail

dotnet --version

## Generate Version Information
dotnet tool restore
version=$(dotnet tool run minver --default-pre-release-identifiers preview)
versionFlags="/P:Version=${version} /P:InformationalVersion=${version}"

## Run the Build
dotnet build --configuration Release $versionFlags
dotnet test --no-build --framework net8.0 --configuration Release $versionFlags --collect:"XPlat Code Coverage" --logger 'trx' --logger 'console;verbosity=normal'
dotnet pack -o PublishOutput --configuration Release $versionFlags

## Pack up the code coverage results
dotnet reportgenerator -reports:**/TestResults/**/coverage.cobertura.xml -targetdir:CoverageReport  -reporttypes:HtmlInline_AzurePipelines

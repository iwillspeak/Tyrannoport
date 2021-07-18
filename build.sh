#! /usr/bin/env bash

if [ -z "$BUILD_SOURCEBRANCH" ]
then
    echo "Initialising local branch state"
    BUILD_SOURCEBRANCH=`git branch --show-current`
fi

set -euox pipefail

dotnet --version --verbose

## Generate Version Information
dotnet tool restore
export $(dotnet tool run octoversion --CurrentBranch=${BUILD_SOURCEBRANCH} --OutputFormats:0=Environment | xargs)
versionFlags="/P:Version=${OCTOVERSION_NuGetVersion} /P:InformationalVersion=${OCTOVERSION_InformationalVersion}"

## Run the Build
dotnet build --configuration Release $versionFlags
dotnet test --no-build --configuration Release $versionFlags --collect:"XPlat Code Coverage" --logger 'trx' --logger 'console;verbosity=normal'
dotnet pack -o PublishOutput --configuration Release $versionFlags

## Pack up the code coverage results
dotnet reportgenerator -reports:**/TestResults/**/coverage.cobertura.xml -targetdir:CoverageReport  -reporttypes:HtmlInline_AzurePipelines
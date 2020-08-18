"%ProgramFiles%\dotnet\dotnet.exe" clean
"%ProgramFiles%\dotnet\dotnet.exe" build
"%ProgramFiles%\dotnet\dotnet.exe" test ../Geektrust_FamilyTreeChallenge.Tests
"%ProgramFiles%\dotnet\dotnet.exe" run --project ../Geektrust_FamilyTreeChallenge
PAUSE
# LibGio.Bindings
Binding between `libgio` (gsettings) and the Dotnet world.

## Tests
To avoid running the tests within Visual Studio, you can filter the tests to remove the Trait by adding the search condition to : `-Trait:"Integration"`.

**Future:** Use some kind of attribute to skip those tests in the VS UI: https://github.com/AArnott/Xunit.SkippableFact/pull/7#issuecomment-393395780

## Integration tests
From a linux console, ensure that you have `gsettings`, `glib-compile-schemas` and an active `dbus` session.
```sh
GSETTINGS_SCHEMA_DIR=~/schemas/ dotnet test --filter Category=Integration
```
# LibGio.Bindings
Binding between `libgio` (gsettings) and the Dotnet world.

## Tests
To avoid running the tests within Visual Studio, you can filter the tests to remove the Trait by adding the search condition to : `-Trait:"Integration"`.

**Future:** Use some kind of attribute to skip those tests in the VS UI: https://github.com/AArnott/Xunit.SkippableFact/pull/7#issuecomment-393395780

## Integration tests
From a linux console, ensure that you have `gsettings`, `glib-compile-schemas` and an active `dbus` session.
```sh
# If DBus is not started:
# > exec dbus-run-session -- bash
# ---
# Here we filter on the integration tests, but you can also run all the tests
GSETTINGS_SCHEMA_DIR=~/schemas/ dotnet test --filter Category=Integration
```

## Ideas
- Create a project in FSharp in order to play arround the settings
- Complete more tests
- Make the application/tests run in docker (maybe?), I currently use SubSystem Linux in windows and it works. But it's a bit painful.
- Create the Nuget package
- Create automated build
- Look at possible memory leak due to the memory *(need to free... sometimes some stuff... It's a bit herratic, like GString. I am trying to encapsulate so the people who uses the lib, don't need to manage the memory... but still)*
- Write an article?

## What is implemented
- **[Partly]** GSettings
- **[Partly]** GAction
- **[Partly]** GVariantType
- **[Partly]** GVariant
- **[Partly]** GString
- **[Not started]** GSettingsSchema

[More details in the Excel within this folder](./ImplementedFeatures.xlsx)

# License
![License MIT](https://img.shields.io/github/license/Nordes/HoNoSoFt.LibGio.Bindings.svg)
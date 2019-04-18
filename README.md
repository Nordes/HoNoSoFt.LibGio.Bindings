# LibGio.Bindings
Binding between `libgio` (gsettings) and the Dotnet world.

## Tests
To avoid running the tests within Visual Studio, you can filter the tests to remove the Trait by adding the search condition to : `-Trait:"Integration"`.

**Future:** Use some kind of attribute to skip those tests in the VS UI: https://github.com/AArnott/Xunit.SkippableFact/pull/7#issuecomment-393395780

## Integration tests
From a linux console, ensure that you have `gsettings`, `glib-compile-schemas` and an active `dbus` session.
```sh
# If DBus is not started (e.g.: WSL):
# > exec dbus-run-session -- bash
# ---
> GSETTINGS_SCHEMA_DIR=~/schemas/ dotnet test
```

During the test, we compile the schema included in the project and then move it into the home folder in order to compile it. Once it is compiled, the integration tests use that schema as a default schema to query.

## Sample Application
### FSharp Implementation
Basically a small application written in F#. It basically show a little the schemas and the key. Eventually it would be nice to also play with the value and etc.

### C# Implementation
A very small app consuming the api. The current state is basically the beginning of a program. There's a project in order to make it more usable. That being said, F# or C#, the code is relatively similar in order to call the Library.

## Ideas
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

# Run from VSCode windows + WSL
> https://github.com/OmniSharp/omnisharp-vscode/wiki/Windows-Subsystem-for-Linux

# License
![License MIT](https://img.shields.io/github/license/Nordes/HoNoSoFt.LibGio.Bindings.svg)


# Full Stack Development

A consolidated repository of multiple .NET MVC sample projects used for coursework and practice. Each project is self-contained with its own solution and runs independently.

## Projects
- AutomaticEncoding9 — `AutomaticEncoding9/AutomaticEncoding9.slnx`
- Bundling9 — `Bundling9/Bundling9.sln`
- Calculator9 — `Calculator9/Calculator.sln`
- Intro9 — `Intro9/Intro.sln`
- MvcMovies9 — `MvcMovies9/MvcMovies9.sln`
- MvcMusicStore — `MvcMusicStore/MvcMusicStore9.sln`
- PartialView9 (multi-project) — `PartialView9/PartialView9.sln`
- Register9 — `Register9/Register9.sln`
- Stars — `Stars/Stars.sln`
- Travel9 — `Travel9/Travel9.sln`
- RichPanel9 — `RichPanel9/RichPanel9.sln`

> Note: Some folders in this README are summarized. Explore each directory for controllers, models, views, and static assets.

## Prerequisites
- .NET SDK 9.0 installed (`dotnet --version` to verify)
- macOS with zsh shell (commands below use zsh)

## Quick Start (per project)
1. Navigate into a project folder (one that contains a `.sln` or `.csproj`).
2. Restore dependencies and run:

```zsh
# Example for MvcMovies9
cd "MvcMovies9/MvcMovies9"
dotnet restore
dotnet run
```

3. Open the printed URL (typically `http://localhost:5xxx`) in your browser.

## Common Tasks
- Build: `dotnet build`
- Run: `dotnet run`
- Test (if present): `dotnet test`

## Repository Layout
Top-level folders correspond to separate .NET projects/solutions. Typical structure:
- `Controllers/`, `Models/`, `Views/`, `wwwroot/`: MVC components
- `appsettings.json`, `appsettings.Development.json`: configuration
- `Program.cs`: application entry point

## Contributing / Notes
- This repository uses a root-level `.gitignore` tailored for .NET, macOS, and editor artifacts.
- If you add new projects, keep them in their own folder with a `.sln` and `.csproj` for clarity.

 
````markdown
# Full Stack Development

A consolidated repository of multiple .NET MVC sample projects used for coursework and practice. Each project is self-contained with its own solution and runs independently.

## Projects
- AutomaticEncoding9 — `AutomaticEncoding9/AutomaticEncoding9.slnx`
- Bundling9 — `Bundling9/Bundling9.sln`
- Calculator9 — `Calculator9/Calculator.sln`
- Intro9 — `Intro9/Intro.sln`
- MvcMovies9 — `MvcMovies9/MvcMovies9.sln`
- MvcMusicStore — `MvcMusicStore/MvcMusicStore9.sln`
- PartialView9 (multi-project) — `PartialView9/PartialView9.sln`
- Register9 — `Register9/Register9.sln`
- Stars — `Stars/Stars.sln`
- Travel9 — `Travel9/Travel9.sln`

> Note: Some folders in this README are summarized. Explore each directory for controllers, models, views, and static assets.

## Prerequisites
- .NET SDK & ASP.NET Core runtime **9.0** installed (`dotnet --version` and `dotnet --list-runtimes` to verify)
- macOS with zsh shell (commands below use zsh)

## Quick Start (per project)
1. Navigate into a project folder (one that contains a `.sln` or `.csproj`).
2. Restore dependencies and run:

```zsh
# Example for MvcMovies9
cd "MvcMovies9/MvcMovies9"
dotnet restore
dotnet run
```

3. Open the printed URL (typically `http://localhost:5xxx`) in your browser.

## Run Locally (recommended)

- Requirement: .NET SDK + ASP.NET Core runtime **9.0** (projects target `net9.0`). Verify installed runtimes:

```zsh
dotnet --version
dotnet --list-runtimes
```

- macOS/Homebrew quick install (example used while developing):

```zsh
# Tap contains specific 9.x SDK casks used here
brew tap isen-ng/dotnet-sdk-versions
# Full Stack Development

Consolidated workspace of multiple ASP.NET Core (MVC) sample projects used for coursework and practice. Each project is self-contained and has its own solution (`.sln`) and project (`.csproj`).

## Projects (at root)
- `AutomaticEncoding9/` — `AutomaticEncoding9/AutomaticEncoding9.slnx`
- `Bundling9/` — `Bundling9/Bundling9.sln`
- `Calculator9/` — `Calculator9/Calculator.sln`
- `Intro9/` — `Intro9/Intro.sln`
- `MvcMovies9/` — `MvcMovies9/MvcMovies9.sln`
- `MvcMusicStore/` — `MvcMusicStore/MvcMusicStore9.sln`
- `PartialView9/` — `PartialView9/PartialView9.sln` (multi-project)
- `Register9/` — `Register9/Register9.sln`
- `Stars9/` — `Stars/Stars.sln`
- `Travel9/` — `Travel9/Travel9.sln`
- `RichPanel9/` — `RichPanel9/RichPanel9.sln`

Explore each folder for controllers, models, views, static assets, and solution files.

## Prerequisites
- .NET SDK 9.0 (projects target `net9.0`) — verify with

```zsh
dotnet --version
dotnet --list-runtimes
```

- Recommended: Install the matching ASP.NET Core runtime if not present.

## Quick Start (run a single project)
1. Change into the project folder that contains the `.sln` or `.csproj` you want to run.

```zsh
# Example: run MvcMovies9
cd "MvcMovies9/MvcMovies9"
dotnet restore
dotnet run
```

2. The app will print a local URL (for example `http://localhost:5xxx`). Open that URL in your browser.

Tip: For development, you can also use `dotnet watch run` in many projects to get hot reload while editing.

## Common Commands
- Restore: `dotnet restore`
- Build: `dotnet build`
- Run: `dotnet run`
- Watch (hot reload): `dotnet watch run`
- Test (if a test project exists): `dotnet test`

## Repository Layout
- Top-level folders each contain one or more related projects/solutions.
- Typical ASP.NET Core MVC project contains: `Controllers/`, `Models/`, `Views/`, `wwwroot/`, `Program.cs`, `appsettings.json`.

## Troubleshooting
- If a project fails with a runtime error, check `dotnet --list-runtimes` and install the missing runtime for .NET 9.
- If pages appear to re-submit forms on refresh, check for Post-Redirect-Get (PRG) patterns in the controllers (some sample apps implement PRG).

## Contributing
- Keep new exercises/projects in their own folder with a `.sln` and `.csproj`.
- Update this README when adding or removing projects.

 
 

If you'd like, I can:
- Add per-project README fragments (run notes or important routes),
- Add a `scripts/` helper for common CLI tasks, or
- Run a specific project and confirm it starts locally.

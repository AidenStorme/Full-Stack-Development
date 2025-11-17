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

## Publishing to GitHub
This repository was initialized locally. If you need to push to a new GitHub repo named `Full-Stack-Development`:

1. Create an empty repository on GitHub (GitHub repo names cannot contain spaces). Suggested name: `Full-Stack-Development`.
2. Add the remote and push:

```zsh
cd "/Users/aidenstorme/Library/CloudStorage/OneDrive-HogeschoolVIVES/School/Full Stack/Oefeningen"
git remote add origin https://github.com/<YOUR_USERNAME>/Full-Stack-Development.git
git branch -M main
git push -u origin main
```

If you prefer SSH:
```zsh
git remote add origin git@github.com:<YOUR_USERNAME>/Full-Stack-Development.git
git branch -M main
git push -u origin main
```
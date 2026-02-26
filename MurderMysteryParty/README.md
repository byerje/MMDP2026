# Murder Mystery Dinner Party - 1920's SpeakEasy Gala 2026

A Blazor Server web application for hosting an interactive murder mystery dinner party set in the 1920s prohibition era.

## Overview

This application provides an immersive experience for guests attending a murder mystery dinner party. Guests can receive character assignments through QR code scanning (simulated with a button click) and explore detailed character profiles to prepare for their roles.

## Features

- **Character Assignment System**: Guests can scan a QR code (simulated) to receive a random character assignment
- **Character Profiles**: Detailed information about all 20 characters including backgrounds, secrets, and costume suggestions
- **1920s Themed Interface**: Art deco styling and speakeasy atmosphere
- **Responsive Navigation**: Easy switching between invitation and character list pages

## Characters

The application includes 20 unique characters from the 1920s era:

1. Zetta Zarbo - Silent Film Star
2. Hal Sapone - Crime Boss (South Side Gang)
3. Mona Crawfish - Marathon Dancing Champion
4. Kara Low - Nightclub Singer
5. Beanie O'Dannon - Crime Boss (Northern Outfit)
6. Haddie Drinx - Waitress
7. Lola Glass - Waitress
8. Tommy "Four Guns" Beagle - Enforcer
9. Handsome Sam McWarthy - Enforcer
10. Hershey Bar - Baseball Player & Jazz Musician
11. Wyleen Black - Tabloid Reporter
12. Harry Looper - Silent Film Actor
13. Jazzy Fringe - Flapper & Singer
14. Chuck Limberger - American Pilot
15. Marlie Maplin - Silent Film Star
16. Ray Stingray - Novelist
17. Ruby "Red" Callahan - Bootlegger
18. Prof. Alistair Finch - Inventor
19. Daisy LaRue - Chorus Girl
20. Officer Clyde Mulligan - Prohibition Agent

## Technology Stack

- **Framework**: Blazor Server (.NET 8)
- **Language**: C#
- **Styling**: CSS with 1920s Art Deco theme
- **Architecture**: Server-side rendering with interactive components

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- Visual Studio Code or Visual Studio

### Running the Application

1. Clone or download this repository
2. Open a terminal in the project directory
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the project:
   ```bash
   dotnet build
   ```
5. Run the application:
   ```bash
   dotnet run --project MurderMysteryParty.csproj
   ```
6. Open your browser and navigate to the URL shown in the console (typically `http://localhost:5059`)

### Using VS Code Tasks

The project includes a VS Code task configuration. You can:
- Press `Ctrl+Shift+P` (Windows/Linux) or `Cmd+Shift+P` (Mac)
- Type "Tasks: Run Task"
- Select "Run Blazor App"

## Project Structure

```
├── Components/
│   ├── Layout/           # Navigation and layout components
│   └── Pages/            # Razor pages
│       ├── Home.razor    # Main invitation page
│       └── Characters.razor # Character list page
├── Models/
│   └── Character.cs      # Character model
├── Services/
│   └── CharacterService.cs # Character management service
├── wwwroot/             # Static files
└── Program.cs           # Application startup
```

## Features in Detail

### Home Page (Invitation)
- Displays the party invitation with 1920s styling
- Event details and dress code information
- QR code simulation for character assignment
- Navigation to character list

### Character Assignment
- Random assignment from available characters
- Prevents duplicate assignments
- Basic character information displayed upon assignment
- Reset functionality for testing

### Characters Page
- Grid layout of all 20 characters
- Detailed character profiles including:
  - Personal background
  - Personality traits
  - Goals and motivations
  - Secrets (for role-playing)
  - Costume suggestions
- Visual indicators for assigned vs. available characters
- Character assignment reset functionality

## Customization

### Adding New Characters
1. Edit `Services/CharacterService.cs`
2. Add new `Character` objects to the `InitializeCharacters()` method
3. Update the character count in documentation

### Styling
- Main styles are embedded in Razor components
- Color scheme uses gold (#d4af37) and dark themes
- Art Deco inspired design elements

## Development Notes

- The application uses Blazor Server for real-time interactivity
- Character assignments are stored in memory (reset on app restart)
- QR code functionality is simulated with a button click
- Responsive design works on desktop and mobile devices

## Future Enhancements

Potential features to add:
- Real QR code generation and scanning
- Database persistence for character assignments
- Admin panel for managing assignments
- Email integration for character details
- Timer for game phases
- Clue distribution system
- Voting mechanism for mystery solution

## License

This project is provided as-is for educational and entertainment purposes.
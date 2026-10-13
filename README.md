# WorkshopRSVP

WorkshopRSVP is an ASP.NET Core MVC application for CST8359 Lab 3. It preserves the default Home pages and adds a complete workshop RSVP feature built with controller actions, Razor views, model binding, Tag Helpers, ViewData, and an in-memory registration collection.

## Requirements

- .NET 8 SDK

## Run locally

```powershell
dotnet restore
dotnet run
```

Open the HTTPS or HTTP address displayed in the console, then choose **Workshops** in the navigation bar.

## Required pages

- `/` - default Home page
- `/Workshops` - Workshop RSVP landing page
- `/Workshops/RsvpForm` - strongly typed RSVP form
- `/Workshops/Registrations` - current in-memory registrations

Registrations intentionally use in-memory storage for the lab. They are cleared whenever the application process restarts or Azure recycles the app.

## Azure deployment

Use Visual Studio's **Publish** workflow or an authenticated Azure CLI session to deploy to a Windows App Service using the .NET 8 runtime. Select a free tier if it is available for the subscription; review and approve any paid plan before creating it. After deployment, verify the Home, Workshops, RSVP, confirmation, and registrations pages at the real Azure URL.

## Submission

Brightspace requires the verified Azure website URL, a browser screenshot of the real Azure-hosted application, and the verified GitHub repository URL. Do not substitute a local URL or project ZIP for those three required items.

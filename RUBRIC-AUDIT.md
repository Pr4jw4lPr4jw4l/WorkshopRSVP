# Lab 3 Rubric Audit

Audit date: October 12, 2026

This audit maps the completed implementation to the official Lab 3 rubric. It is a readiness assessment, not a guarantee of the instructor's grade.

## 1. Project setup and folder structure - 2 points

Status: Implemented and tested locally.

- `WorkshopRSVP.csproj` targets .NET 8 using `Microsoft.NET.Sdk.Web`.
- `Program.cs` registers MVC with `AddControllersWithViews()` and maps the conventional default route.
- The default `HomeController`, `Views/Home/Index.cshtml`, and `Views/Home/Privacy.cshtml` are preserved.
- The required `Controllers/WorkshopsController.cs`, `Models/Rsvp.cs`, and four `Views/Workshops` Razor views are present.
- `dotnet build --configuration Release` completed with 0 warnings and 0 errors.

## 2. Layout navigation - 3 points

Status: Implemented and tested locally.

- `Views/Shared/_Layout.cshtml` contains Home, Workshops, RSVP, Registrations, and Privacy navigation.
- All application links use MVC Tag Helpers (`asp-controller` and `asp-action`) rather than hardcoded application paths.
- Automated HTTP checks confirmed the generated Workshop links and verified that Home, Privacy, Workshops, RSVP form, and Registrations endpoints return successfully.
- The navbar collapses at the mobile breakpoint and was visually reviewed at desktop and 500-pixel widths.

## 3. RSVP model - 3 points

Status: Implemented and tested locally.

- `Models/Rsvp.cs` contains the required `FullName`, `NeedsAccommodation`, and `WorkshopTitle` properties.
- Required-field, display-name, and length validation attributes provide clean server-side and client-side validation.
- `SubmissionId` is an additional hidden value used to make repeated submissions idempotent without changing the required RSVP data.
- Automated tests verified binding for name, workshop selection, and both checked and unchecked accommodation states.

## 4. Controller actions - 6 points

Status: Implemented and tested locally.

- `Index` GET returns the Workshop landing page.
- `RsvpForm` GET returns a strongly typed form and supplies the workshop options.
- `Confirm` POST validates the model and workshop allow-list, stores successful registrations in memory, prevents duplicate storage for a repeated submission ID, sets `ViewData["Message"] = $"Thanks for registering, {model.FullName}!";`, and returns `View(model)`.
- Invalid POSTs return the populated RSVP form with validation messages.
- `Registrations` GET returns a strongly typed, sorted read-only snapshot of the thread-safe in-memory collection.
- Automated tests covered all actions, invalid data, valid submissions, a repeated POST, and multiple registrations.

## 5. Views quality - 5 points

Status: Implemented and tested locally.

- `Views/Workshops/Index.cshtml` provides an informative landing page and Tag Helper calls to action.
- `Views/Workshops/RsvpForm.cshtml` is strongly typed and uses label, input, select, checkbox, validation, form, and link Tag Helpers.
- `Views/Workshops/Confirm.cshtml` is strongly typed and displays the ViewData message plus all submitted RSVP details.
- `Views/Workshops/Registrations.cshtml` is strongly typed to a collection, uses Razor conditions and loops, includes an empty state, and renders all required table columns.
- `wwwroot/css/site.css` adds responsive, accessible presentation while retaining Bootstrap and the standard shared layout.
- Razor views compiled successfully and were exercised through real HTTP requests. Desktop and narrow layouts were rendered in Edge and visually inspected after the final styling correction.

## 6. ViewData usage - 1 point

Status: Implemented and tested locally.

- `Controllers/WorkshopsController.cs` sets the exact personalized confirmation value in `ViewData["Message"]`.
- `Views/Workshops/Confirm.cshtml` reads and displays `@ViewData["Message"]` while also receiving the RSVP with `View(model)`.
- The automated POST test verified the rendered message `Thanks for registering, Jordan Lee!`.

## Local readiness summary

All six rubric categories are implemented. The project builds, publishes, and passes the 17-test local regression suite. The required external deliverables are still outstanding: a verified GitHub repository URL, a live Windows Azure URL, and a screenshot of that real Azure-hosted application.

The in-memory registration collection intentionally resets when the process restarts or an Azure App Service instance recycles. This matches the lab requirement and is not persistent database storage.

# Test Results

Execution date: October 12, 2026

## Build and publish

| Check | Result | Evidence |
|---|---|---|
| Restore | Pass | Dependencies restored for the .NET 8 project. |
| Release build | Pass | 0 warnings and 0 errors. |
| Release publish | Pass | Publish output generated successfully from `WorkshopRSVP.csproj`. |
| Razor compilation | Pass | All Razor views compiled in the Release build and rendered during HTTP tests. |

## Executed local application checks

All 17 automated checks passed against a running Release build on a temporary localhost port:

1. Default Home page returned HTTP 200 and rendered its default content.
2. Shared layout generated the Workshops, RSVP, and Registrations links.
3. Workshops landing page returned HTTP 200 and rendered its heading.
4. Landing page rendered Register and View Registrations actions.
5. Registrations page rendered the empty state before submissions.
6. RSVP form rendered all required model-bound controls.
7. RSVP form rendered Routing Basics, EF Core Intro, and Razor Essentials.
8. Missing name and workshop produced both required validation messages.
9. A valid POST displayed the personalized ViewData confirmation message.
10. The strongly typed confirmation displayed name, workshop, and accommodation status.
11. Repeating the same valid POST returned a valid confirmation response.
12. Repeating a submission ID produced only one stored registration row.
13. An unchecked accommodation box bound to false and displayed Not requested.
14. Two distinct registrations appeared in the table.
15. The table rendered Full name, Workshop, and Needs accommodation columns.
16. A tampered, unavailable workshop value was rejected.
17. The preserved default Privacy page returned HTTP 200.

## Visual checks

- Workshop landing page reviewed at 1440 by 1200 pixels.
- RSVP form reviewed at 1440 by 1200 pixels.
- Registrations table reviewed at 1440 by 1200 pixels after correcting badge readability.
- Landing page and form reviewed at the Bootstrap mobile breakpoint using a 500-pixel-wide browser render.
- No clipping, overlap, unreadable status labels, or broken layout was observed in the final reviewed renders.

## Not executed

- GitHub repository accessibility was not tested because GitHub publishing is not connected in this environment.
- Azure deployment was not executed because Azure CLI and an authenticated Azure deployment interface are unavailable.
- Azure-hosted page behavior was not tested.
- No Azure screenshot was captured.

These external items must not be marked complete until their real URLs and screenshot are verified.

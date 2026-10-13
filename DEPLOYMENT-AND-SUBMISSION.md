# Deployment and Submission Handoff

## GitHub

The project is prepared as a local Git repository on branch `main`. To publish after GitHub is connected:

```powershell
git remote add origin https://github.com/<your-account>/<your-repository>.git
git push -u origin main
```

Then open the repository in a signed-in browser and verify that it is accessible before copying the real repository URL into Brightspace. Do not submit a placeholder URL.

## Windows Azure App Service

The project targets .NET 8 and has passed a Release publish. In Visual Studio:

1. Open `WorkshopRSVP.slnx`.
2. Right-click the `WorkshopRSVP` project and choose **Publish**.
3. Choose **Azure**, then **Azure App Service (Windows)**.
4. Sign in and select the correct subscription.
5. Create or select a resource group and Windows App Service.
6. Select a .NET 8 runtime and 64-bit platform.
7. Prefer a free tier when the subscription offers one. If only paid plans are available, stop, review the displayed monthly cost, and obtain approval before creating the resource.
8. Publish the project.
9. Open the exact Azure URL and test Home, Workshops, RSVP, confirmation, and Registrations.
10. Confirm that a newly submitted registration appears in the Azure-hosted Registrations table.

In-memory registrations can disappear when App Service restarts, scales, or recycles. That behavior is expected for this lab.

## Required genuine screenshot

After the real Azure deployment works:

1. Open the Azure-hosted Workshops page in a browser.
2. Keep the address bar visible so the real Azure host is readable.
3. Capture the browser window with the working Workshop RSVP interface.
4. Save the image as `Lab3_Azure_Screenshot.png`.
5. Open the saved image once to verify that the URL and page are readable.

Do not use a localhost screenshot or edit a URL into the image.

## Brightspace checklist

- [ ] Paste the verified live Windows Azure website URL.
- [ ] Upload `Lab3_Azure_Screenshot.png`, captured from that real Azure website.
- [ ] Paste the verified GitHub repository URL.
- [ ] Reopen each submitted link in a signed-out/private browser where appropriate to confirm the instructor can access it.
- [ ] Optionally keep the project ZIP as a backup; it does not replace the three required items above.

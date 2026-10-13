using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkshopRSVP.Models;

namespace WorkshopRSVP.Controllers;

public class WorkshopsController : Controller
{
    private static readonly string[] WorkshopTitles =
    [
        "Routing Basics",
        "EF Core Intro",
        "Razor Essentials"
    ];

    private static readonly ConcurrentDictionary<Guid, Rsvp> RegistrationsStore = new();

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RsvpForm()
    {
        PopulateWorkshopOptions();
        return View(new Rsvp());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Confirm(Rsvp model)
    {
        model.FullName = model.FullName?.Trim() ?? string.Empty;
        model.WorkshopTitle = model.WorkshopTitle?.Trim() ?? string.Empty;

        if (!WorkshopTitles.Contains(model.WorkshopTitle, StringComparer.Ordinal))
        {
            ModelState.AddModelError(nameof(model.WorkshopTitle), "Please select an available workshop.");
        }

        if (!ModelState.IsValid)
        {
            PopulateWorkshopOptions();
            return View("RsvpForm", model);
        }

        if (model.SubmissionId == Guid.Empty)
        {
            model.SubmissionId = Guid.NewGuid();
        }

        RegistrationsStore.TryAdd(
            model.SubmissionId,
            new Rsvp
            {
                SubmissionId = model.SubmissionId,
                FullName = model.FullName,
                NeedsAccommodation = model.NeedsAccommodation,
                WorkshopTitle = model.WorkshopTitle
            });

        ViewData["Message"] = $"Thanks for registering, {model.FullName}!";
        return View(model);
    }

    [HttpGet]
    public IActionResult Registrations()
    {
        var registrations = RegistrationsStore.Values
            .OrderBy(registration => registration.FullName, StringComparer.OrdinalIgnoreCase)
            .ToList()
            .AsReadOnly();

        return View(registrations);
    }

    private void PopulateWorkshopOptions()
    {
        ViewBag.WorkshopOptions = new SelectList(WorkshopTitles);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using WebApplication3.Data;
using WebApplication3.Services;
using WebApplication3.Services.Interfaces;
using WebApplication3.Repositories.Interfaces;
using WebApplication3.Views.ViewModels;
using WebApplication3.Views.ViewModels;

namespace WebApplication3.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index(DateTime? startDateMin, DateTime? startDateMax, string sortOrder)
        {
            var projects = await _projectService.GetProjectsAsync();

            if (startDateMin.HasValue)
            {
                projects = projects.Where(p => p.StartDate >= startDateMin).ToList();
            }

            if (startDateMax.HasValue)
            {
                projects = projects.Where(p => p.StartDate <= startDateMax).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    projects = projects.OrderByDescending(p => p.Name).ToList();
                    break;
                case "StartDate":
                    projects = projects.OrderBy(p => p.StartDate).ToList();
                    break;
                case "start_date_desc":
                    projects = projects.OrderByDescending(p => p.StartDate).ToList();
                    break;
                default:
                    projects = projects.OrderBy(p => p.Name).ToList();
                    break;
            }

            var viewModel = new ProjectViewModel
            {
                Projects = projects.ToList(),
                StartDateMin = startDateMin,
                StartDateMax = startDateMax,
                SortOrder = sortOrder
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CustomerCompany,ExecutorCompany,StartDate,EndDate,Priority,ProjectManager")] Project project)
        {
            if (ModelState.IsValid)
            {
                await _projectService.CreateProjectAsync(project);
                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CustomerCompany,ExecutorCompany,StartDate,EndDate,Priority,ProjectManager")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _projectService.UpdateProjectAsync(project);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _projectService.ProjectExists(id))
                    {
                        await _projectService.DeleteProjectAsync(id);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}

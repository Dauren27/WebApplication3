using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using DAL.Data;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    { 


        private readonly WebApplication3Context _context;

    public ProjectRepository(WebApplication3Context context)
    {
        _context = context;
    }
    public async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Project.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Project.FindAsync(id);
        }

        public async Task CreateProjectAsync(Project project)
        {
            _context.Project.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}

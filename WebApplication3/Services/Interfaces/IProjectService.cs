using Common.Models;

namespace WebApplication3.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        Task<bool> ProjectExists(int id);
    }
}

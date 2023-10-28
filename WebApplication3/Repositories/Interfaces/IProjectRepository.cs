using Common.Models;

namespace WebApplication3.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        //Task<bool> ProjectExists(int id);
    }
}

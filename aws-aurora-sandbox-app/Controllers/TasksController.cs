using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aws_aurora_sandbox_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public Task<ListTasksResult[]> ListTasks()
        {
            return _context.Tasks.Select(t => new ListTasksResult() { Id = t.Id, Name = t.Name }).ToArrayAsync();
        }

        [HttpPost()]
        public async Task<Guid> RegisterTask(RegisterTaskCommand command)
        {
            var task = new Task(command.Name);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }
    }
}
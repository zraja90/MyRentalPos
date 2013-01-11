using MyRentalPos.Core.Domain.Tasks;

namespace MyRentalPos.Services.Tasks
{
    /// <summary>
    /// Task service interface
    /// </summary>
    public partial interface IScheduleTaskService : ICrudService<ScheduleTask>
    {
        /// <summary>
        /// Gets a task by its type
        /// </summary>
        /// <param name="type">Task type</param>
        /// <returns>Task</returns>
        ScheduleTask GetTaskByType(string type);
    }
}

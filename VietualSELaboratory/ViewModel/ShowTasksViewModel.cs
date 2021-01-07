using Domain.RDBMS.Entities;
using ReflectionIT.Mvc.Paging;

namespace VietualSELaboratory.ViewModel
{
    public class ShowTasksViewModel
    {
        public int[] CompletedTasksIds { get; set; }
        public PagingList<Exercise> Exercises { get; set; }
    }
}

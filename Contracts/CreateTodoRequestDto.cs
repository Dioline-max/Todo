using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Contracts
{
    public class CreateTodoRequestDto
    {
        public string Title{ get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual AppUser? User { get; set; }
        public string OwnerID { get; set; }
    }
}
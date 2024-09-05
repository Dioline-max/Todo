using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class ToDo
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Title{ get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public AppUser? User { get; set; }
        public string OwnerID { get; set; }

        public ToDo()
        {
            IsComplete = false;
        }
        
    }
}
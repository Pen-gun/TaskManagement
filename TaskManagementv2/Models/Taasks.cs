using System.ComponentModel.DataAnnotations;

namespace TaskManagementv2.Models
{
    public class Taasks
    {
        [Key]
        public int TaskId { get; set; } // Primary key

        [Required]
        [StringLength(100)]
        public string Title { get; set; } // Task title

        [StringLength(500)]
        public string Description { get; set; } // Task description

        [Required]
        [Range(1, 3)]
        public int Priority { get; set; } // Task priority (e.g., 1 = High, 2 = Medium, 3 = Low)

        [Required]
        public DateTime Deadline { get; set; } // Task deadline

        public string AssignedTo { get; set; } // Name or ID of the assigned person

        [Required]
        public string Status { get; set; } // Status of the task (e.g., Pending, Completed)

        public DateTime CreatedDate { get; set; } // Date the task was created
        public DateTime? UpdatedDate { get; set; } // Date the task was last updated
    }
}

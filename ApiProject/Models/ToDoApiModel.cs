using System.ComponentModel.DataAnnotations;
using TodoLibrary.Models;

namespace ApiProject.Models
{
    public class TodoApiModel : ITodoModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(400)]
        public string? Task { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int AssignedTo { get; set; }

        [Required]
        public bool IsComplete { get; set; }

    }
}

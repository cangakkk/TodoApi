using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        [Key]
        public int Id {get;set;}
        [Required]
        public string? Title {get; set;}
        public bool isCompleted {get; set;}
    }
}
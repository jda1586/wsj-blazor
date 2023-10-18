using System.ComponentModel.DataAnnotations;

namespace wsj.Domain.Entities;

public class Invitation
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public bool Accept { get; set; }
    public DateTime UpdatedAt { get; set; }
}
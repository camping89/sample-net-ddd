using System.ComponentModel.DataAnnotations;

namespace SampleDDD.Domain;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseEnterprise.Domain;
/// <summary>
/// Организация
/// </summary>
[Table("organization")]
public class Organization
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    [Column("name")]
    [MaxLength(50)]
    [Required]
    public required string Name { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    [Column("address")]
    [MaxLength(50)]
    [Required]
    public required string Address { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseEnterprise.Domain;
/// <summary>
/// Товар
/// </summary>
[Table("product")]
public class Product
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Код товара
    /// </summary>
    [Column("code")]
    [Required]
    public required int Code { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    [Column("name")]
    [MaxLength(50)]
    [Required]
    public required string Name { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseEnterprise.Domain;
/// <summary>
/// Ячейка склада
/// </summary>
[Table("cell")]
public class Cell
{
    /// <summary>
    /// Идентификатор ячейки
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Товар
    /// </summary>
    [Column("product")]
    [Required]
    public Product? Product { get; set; }
    /// <summary>
    /// Количество товара в ячейке
    /// </summary>
    [Column("quantity")]
    [Required]
    public required int Quantity { get; set; }
}
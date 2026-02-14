using System.ComponentModel.DataAnnotations;

namespace GameCatalog.Models;

public class Game
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название")]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите разработчика")]
    [StringLength(100)]
    public string Developer { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введите жанр")]
    [StringLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Range(1970, 2030, ErrorMessage = "Некорректный год")]
    public int Year { get; set; }

    [Range(1, 10, ErrorMessage = "Оценка от 1 до 10")]
    public int Rating { get; set; }
}
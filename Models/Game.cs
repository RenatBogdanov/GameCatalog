using System.ComponentModel.DataAnnotations;

namespace GameCatalog.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название игры")]
        [StringLength(100)]
        [Display(Name = "Название")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите разработчика")]
        [StringLength(100)]
        [Display(Name = "Разработчик")]
        public string Developer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите жанр")]
        [StringLength(50)]
        [Display(Name = "Жанр")]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(1970, 2026, ErrorMessage = "Год от 1970 до 2026")]
        [Display(Name = "Год выпуска")]
        public int Year { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Оценка от 0 до 10")]
        [Display(Name = "Рейтинг")]
        public double Rating { get; set; }
    }
}
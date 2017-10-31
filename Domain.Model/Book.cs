// Класс книга
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Book : BaseEntity
    {
        // Идентификатор экземпляра книги
        [Required]
        [Range(1, UInt32.MaxValue, ErrorMessage = "Введите номер экземпляра")]
        [Display(Name = "Экземпляр")]
        public int? BookExampleId { get; set; }
        // Название
        [Required]
        [Display(Name = "Название")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }
        // Автор
        // Название
        [Required]
        [Display(Name = "Автор")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Author { get; set; }
        // Дата последней выдачи
        [Required]
        [Display(Name = "Дата выдачи")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Opened { get; set; }
        // Предполагаемая дата возврата
        [Required]
        [Display(Name = "Дата возврата")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Closed { get; set; }
        // Статус книги (возвращена или нет)
        [Required]
        [Display(Name = "Статус книги")]
        public BookStatus Status { get; set; }
        //  читатель
        public int? ReaderId { get; set; }
        public virtual Reader Reader { get; set; }
    }

    // Статус книги
    public enum BookStatus
    {
        free = 0,
        taken = 1,
        lost = 2

    }
}

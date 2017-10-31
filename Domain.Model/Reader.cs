// Класс читатель
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Reader : BaseEntity
    {
        // номер читательского билета
        [Required]
        [Display(Name = "№ Ч.Б.")]
        public int? LibraryCardId { get; set; }
        // Фамилия Имя Отчество
        [Required]
        [Display(Name = "ФИО")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }
        // Дата рождения       
        [Required]
        [Display(Name = "Д. рождения")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        // Книги
        public virtual ICollection<Book> Books { get; set; }
    }
}

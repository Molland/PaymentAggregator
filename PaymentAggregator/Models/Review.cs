using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PaymentAggregator.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        [StringLength(100, ErrorMessage = "Имя слишком длинное")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Email")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        [StringLength(150, ErrorMessage = "Email слишком длинный")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, напишите текст отзыва")]
        [AllowHtml]
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace MinerShop.Models.Orders
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина имени более 50 символов")]

        public string Name { get; set; }

        [Display(Name = "Введите город")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина города более 50 символов")]
        public string City { get; set; }

        [Display(Name = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [Required(ErrorMessage = "Длина номера телефона более 12 символов")]
        public string Phone { get; set; }

        [Display(Name = "Введите Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина Email более 50 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
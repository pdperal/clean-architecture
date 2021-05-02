﻿using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOS
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

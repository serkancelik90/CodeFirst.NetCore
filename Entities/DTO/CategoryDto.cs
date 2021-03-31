using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class CategoryDto:IDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

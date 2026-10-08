using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.BaseData.Dtos
{
    public class ColourDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicApplication.Core.Entities.Base
{
    public class BaseEntity:IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

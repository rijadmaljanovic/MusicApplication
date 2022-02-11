using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApplication.Core.Entities.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime? ModifiedAt { get; set; }
        DateTime CreatedAt { get; set; }
    }
}

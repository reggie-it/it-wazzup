using System;

namespace itwazzup.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity() 
        {
        }
        public int Id { get; set; }
    }
}

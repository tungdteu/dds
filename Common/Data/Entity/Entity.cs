using System.ComponentModel.DataAnnotations;

namespace Common.Data.Entity
{
    public class Entity : IBaseEntity
    {
        /// <summary>
        /// This is a indentify field to indicate that : its value will automatic increase !
        /// </summary>
        [Key]
        public virtual int Id { get; set; }
    }
}

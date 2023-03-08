using System.ComponentModel.DataAnnotations;

namespace myfinance_web_netcore.Domain.Entities
{
    public class GenericEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
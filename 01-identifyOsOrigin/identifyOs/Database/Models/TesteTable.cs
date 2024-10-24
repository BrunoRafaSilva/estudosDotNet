using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace identifyOs.Database.Models
{
    [Table("Cassino")]
    public class TesteTable: BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }
        [Column("Oi")]
        public string Oi { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Oie.DataAccess.DbSets
{
    [Table("fakedepts")]
    public class FakeDepartment
    {
        
        [Key, Column("name")]
        public string Name { get; set; }
    }
}

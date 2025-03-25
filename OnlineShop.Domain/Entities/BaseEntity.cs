using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public interface IBaseEntity
    {
        Guid ID { get; set; }
        Guid? MemberID { get; set; }
        DateTime? CreateDateTime { get; set; }
        bool IsDelete { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            
        }
        public Guid ID { get; set; }
        public Guid? MemberID { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public bool IsDelete { get; set; }
    }
}

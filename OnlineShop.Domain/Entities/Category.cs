using OnlineShop.Common.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Category:BaseEntity
    {
        [Description("نام گروه")]
        public string Title { get; set; }

        [Description("توضیحات گروه")]
        public string Description { get; set; }
    }
}

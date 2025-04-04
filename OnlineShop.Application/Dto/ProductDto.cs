using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dto
{
    //برای تست نویسی ایجاد شده است
    public class ProductDto: BaseEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void UpdateTitle(string Title)
        {
            if(Title.Trim().Length==0)
            {
                throw new Exception("Title Shoud not Empty");
            }
            this.Title = Title;
        }
    }
}

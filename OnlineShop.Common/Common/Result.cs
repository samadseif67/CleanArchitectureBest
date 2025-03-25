using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.Common
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> ErrorLst { get; set; }


        public static Result<T> SuccessResult(T Data,string Message="عملیات با موفقیت انجام شد")
        {
            return new Result<T>()
            {
                Data = Data,
                Message = Message,
                Success = true,
            };
        }

        public Result<T> ErrorResult(T Data,string Message="خطای رخ داد")
        {
            return new Result<T>()
            {
                ErrorLst=new List<string>() { Message },
                Success = false,
                Message = Message ,
                Data= Data
            };
        }

        public static Result<T> ErrorResult(T Data, List<string> ErrorLst)
        {
            return new Result<T>()
            {
                ErrorLst = ErrorLst,
                Success = false,
                Message = null,
                Data = Data
            };
        }
         

    }
}

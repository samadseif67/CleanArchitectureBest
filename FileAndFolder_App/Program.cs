﻿

string path1 = @"E:\projectEducation\OnlineShop\OnlineShop\FileAndFolder_App\Temp";
string[] dirs = Directory.GetDirectories(path1, "*", SearchOption.AllDirectories);//پیدا کردن تمام پوشه ها در مسیر مورد نظر
foreach (string item in dirs)
{
    Console.WriteLine(item);
}

Console.WriteLine("***************************************************************************************");

var dir=Directory.CreateDirectory(path1 + @"\NewDirectory");//ایجاد مسیر جدید
string[] files = Directory.GetFiles(path1, "*.*", SearchOption.AllDirectories);//پیدا کردن تمام فایل ها در مسیر مورد نظر
foreach (string item in files)
{
    Console.WriteLine(item);//مسیر فایل
    Console.WriteLine(Path.GetFileNameWithoutExtension(item));//نام فایل بدون پسوند
    Console.WriteLine(Path.GetFileName(item));//نام فایل با پسوند
    Console.WriteLine(Path.GetExtension(item));//پسوند فایل
    Console.WriteLine(Path.GetDirectoryName(item));//مسیر فایل

    var info=new FileInfo(item);//برای بدست آوردن اطلاعات خاص فایل 
    Console.WriteLine("Length=="+info.Length);//بدست آوردن حجم فایل

    Console.WriteLine("************************");

    File.Copy(item, $"{path1}\\NewDirectory\\{Guid.NewGuid().ToString()+Path.GetFileName(item)}");//برای کپی کردن فایل ها از یک مسیر به مسیر دیگر
    File.Move(item, $"{path1}\\NewDirectory\\{Guid.NewGuid().ToString() + Path.GetFileName(item)}");//برای کات یا جابجایی کردن فایل ها از یک مسیر به مسیر دیگر

}

var existDirectory = Directory.Exists(path1);//برای تشخیص وجود داشتن پوشه یا همان دایرکتوری
var existFile = File.Exists(path1);//برای تشخیص وجود داشتن فایل
//***************************************************************************************************


Console.ReadKey();


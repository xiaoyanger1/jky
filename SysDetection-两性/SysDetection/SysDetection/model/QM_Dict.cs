using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysDetection.model
{
   public class QM_Dict
    {
       /// <summary>
       /// 气密等级字典
       /// </summary>
       public class Dict
       {
           public List<Dict> GetList()
           {
               List<Dict> dictList = new List<Dict>();
               dictList.Add(new Dict() { value = 0, level = 1 });
               dictList.Add(new Dict() { value = 0, level = 1 });
               dictList.Add(new Dict() { value = 100, level = 2 });
               dictList.Add(new Dict() { value = 150, level = 3 });
               dictList.Add(new Dict() { value = 200, level = 4 });
               dictList.Add(new Dict() { value = 250, level = 5 });
               dictList.Add(new Dict() { value = 300, level = 6 });
               dictList.Add(new Dict() { value = 350, level = 7 });
               dictList.Add(new Dict() { value = 400, level = 8 });
               dictList.Add(new Dict() { value = 500, level = 9 });
               dictList.Add(new Dict() { value = 600, level = 10 });
               dictList.Add(new Dict() { value = 700, level = 11 });
               return dictList;
           }

           public int level { get; set; }
           public int value { get; set; }
       }
    }
}

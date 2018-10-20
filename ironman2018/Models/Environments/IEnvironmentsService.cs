using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironman2018.Models.Environments
{
    public interface IEnvironmentsService
    {
        /// <summary>
        /// 回傳 runtime 的環境名稱
        /// </summary>
        /// <returns></returns>
        string GetEnvironmentName();
    }
}

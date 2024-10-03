using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularAppLoader
{
    public interface IPlugin
    {
        /// <summary>
        /// 執行插件的邏輯
        /// </summary>
        void Execute(); 

        /// <summary>
        /// 獲取下次執行的時間
        /// </summary>
        /// <returns></returns>
        DateTime GetNextExecutionTime();

        /// <summary>
        /// 獲取插件的描述
        /// </summary>
        /// <returns></returns>
        string GetDescription();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularAppLoader
{
    public class PluginInfo
    {
        /// <summary>
        /// 功能名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 功能描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 下次執行時間還有多久(HH:MM:ss)
        /// </summary>
        public DateTime NextExecutionTime { get; set; }

        /// <summary>
        /// 下次執行時間
        /// </summary>
        public TimeSpan TimeUntilNextExecution { get; set; }
    }
}

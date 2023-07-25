using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace Automation.Test.Cores.ShareData
{
    public static class DataStorage
    {
        private static AsyncLocal<Dictionary<string, object>> _data;

        public static void InitData() {
            _data = new AsyncLocal<Dictionary<string, object>>();
        } 

        public static void SetData(string key, object value) {
            _data.Value[key] = value;
        }

        public static object GetData(string key) {
            return _data.Value.GetValueOrDefault(key);
        }

        public static void ClearData() {
            if (_data.Value is not null)
                _data.Value.Clear();
        }
    }
}
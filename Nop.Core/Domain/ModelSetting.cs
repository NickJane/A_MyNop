using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Nop.Core.Domain
{
    /// <summary>
    /// 持久个性化设置的类
    /// </summary>
    public  class ModelSetting
    {
        
        private Dictionary<string, string> _hash;
        public ModelSetting() {
            _hash = new Dictionary<string, string>();
        }

        /// <summary>
        /// 把数据库中的bytes转化成可用的dictionary
        /// </summary>
        /// <param name="bytes"></param>
        public void Load(byte[] bytes)
        {
            using (MemoryStream ms1 = new MemoryStream(bytes)) {
                BinaryFormatter bf = new BinaryFormatter();
                _hash = (Dictionary<string, string>)bf.Deserialize(ms1);
            }
        }
        /// <summary>
        /// 把实体中的dictionary转成bytes
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            using (MemoryStream ms1 = new MemoryStream())
            {
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(ms1, _hash);
                return ms1.ToArray();
            }
        }



        public ICollection Keys
        {
            get
            {
                return _hash.Keys;
            }
        }

        public string Get(string Name, string Def){
             if (_hash.ContainsKey(Name))
                 return _hash[Name];
             else
                 return Def;
        }
        public void Set(string Name, string Val)
        {
            if (Val == null)
                Val = "";
            _hash[Name] = Val;
        }
    }
}

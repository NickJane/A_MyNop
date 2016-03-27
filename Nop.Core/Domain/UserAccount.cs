using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain
{
    public class UserAccount : Nop.Core.BaseEntity
    {
        /// <summary>
        /// 当前对象所属站点ID
        /// </summary>
        public int SiteID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool Active { get; set; }
        public bool IsDelete { get; set; }
        /// <summary>
        /// 数据库的Settings字段
        /// </summary>
        public virtual byte[] Settings { get; set; }

        /// <summary>
        /// Setting设置帮助类
        /// </summary>
        protected ModelSetting modelsetting = new ModelSetting();
        private Dictionary<string, string> _allSettings = new Dictionary<string, string>();
        private bool _isLoaded = false;
        /// <summary>
        /// 通过这个访问个性化设置
        /// </summary>
        public Dictionary<string, string> AllSettings
        {
            get {
                if (!_isLoaded)
                    LoadSettings();
                return _allSettings;
            }
        }

        /// <summary>
        /// 将二进制的内容加载成具体的对象
        /// </summary>
        private void LoadSettings()
        {
            if (Settings != null && Settings.Length > 1)
            {
                modelsetting.Load(Settings);

                _allSettings.Clear();
                foreach (string key in modelsetting.Keys)
                {
                    _allSettings.Add(key, modelsetting.Get(key, string.Empty));
                }

                _isLoaded = true;
            }
        }
        /// <summary>
        /// 将单一的某个设置的键值对，存入网站本身二进制的Setting里.
        /// 本方法只是临时将键值对，放入字典。真正更新数据库，还需要SaveSetting()再Update（YibuSite）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetOneSetting(string key, string value)
        {
            if (AllSettings.ContainsKey(key))
            {
                AllSettings[key] = value;
            }
            else
            {
                AllSettings.Add(key, value);
            }
        }
        public void SaveSetting()
        {
            foreach (string key in _allSettings.Keys)
            {
                modelsetting.Set(key, _allSettings[key]);
            }
            Settings = modelsetting.ToByteArray();
        }


        
        public virtual ICollection<Auth_Role> Auth_Roles { get; set; }

        public virtual UserExt UserExt { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}

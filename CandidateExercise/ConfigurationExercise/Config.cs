using System;
using System.Collections.Generic;
using log4net;

namespace FutureWonder.Exercises.Configuration
{
    using KVP = KeyValuePair<string, ConfigValue>;
    using KVPList = IList<KeyValuePair<string, ConfigValue>>;
    using KList = IList<string>;

    // Strongly named exceptions
    public class ConfigErrorException : Exception
    {
    }

    public class User
    {
        public string Username { get; set; }
    }

    public class App
    {
        public string Appname { get; set; }
    }

    public interface IConfig
    {
        void Initialize();
        void Shutdown(); // if needed

        #region 1. Basic operations

        ConfigValue GetValue(string key);
        void SaveValue(KVP kvp);
        void SaveValues(KVPList kvps);
        KVPList GetValues(KList keys);

        #endregion 1. Basic operations

        #region 2. User operations

        ConfigValue GetValue(User user, string key);
        KVPList GetValues(User user, KList keys);
        void SaveValue(User user, KVP kvp);
        void SaveValues(User user, KVPList kvps);

        #endregion 2. User operations

        #region 3a. App operations

        ConfigValue GetValue(App app, string key);
        KVPList GetValues(App user, KList keys);
        void SaveValue(App user, KVP kvp);
        void SaveValues(App user, KVPList kvps);

        #endregion 3a. App operations

        #region 3b. App / User operations

        ConfigValue GetValue(App app, User user, string key);
        KVPList GetValues(App app, User user, KList keys);
        void SaveValue(App app, User user, KVP kvp);
        void SaveValues(App app, User user, KVPList kvps);

        #endregion 3b. App / User operations
    }

    public class Config : IConfig
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(Config));
        private IPersistSource _persistSource;

        public Config(IPersistSource persistSource)
        {
            _persistSource = persistSource;
        }

        public void Initialize()
        {
            _log.Info("Initializing Config");
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }

        public ConfigValue GetValue(string key)
        {
            // Creating a new List and adding the key in the list
            IList<string> keyList = new List<string>(); keyList.Add(key);

            if(_persistSource != null) {
                KVPList kvpList = _persistSource.LoadValues(keyList); // Loading values from PersistSource using the list

                if (kvpList != null) // If the loaded KVPList is not empty
                    if (kvpList.Count == 1) // If the number of elements in the list is 1, return the Value (ConfigValue)
                        return kvpList[0].Value;
                    else if (kvpList.Count > 1) // If the number of elements is more than 1, throw an exception
                        throw new Exception("ERROR! Key with Multiple Values!");
            }

            return new ConfigValue(); // If the none of the above conditions satisfy, return an empty object
        }

        public void SaveValue(KVP kvp)
        {
            if (GetValue(kvp.Key).Value != null) { // Calling GetValue to check if the key provided in the KVP already exists in the PersistSource
                
                // Creating a new KVPList and adding the KVP to the list
                IList<KeyValuePair<string, ConfigValue>> kvpList = new List<KeyValuePair<string, ConfigValue>>();
                kvpList.Add(kvp);

                // Saving the KVPList in the PersistSource
                if (_persistSource != null)
                { _persistSource.PersistValues(kvpList);
                }
            }
            else
            {
                // Displaying an error if the KVP already exists in the PersistSource
                _log.Error("ERROR! Key Given in the KVP Already Exists!");
            }
        }

        public void SaveValues(KVPList kvps)
        {
            // Saving the given KVPList in the PersistSource
            if (_persistSource != null)
            {
                _persistSource.PersistValues(kvps);
            }
        }

        public KVPList GetValues(KList keys)
        {
            // Returning the KVPList on the basis of the given KList
            if (_persistSource != null)
            {
                return _persistSource.LoadValues(keys);
            }

            return null; // Returning null if PersistSource is null
        }

        public ConfigValue GetValue(User user, string key)
        {
            throw new NotImplementedException();
        }

        public KVPList GetValues(User user, KList keys)
        {
            throw new NotImplementedException();
        }

        public void SaveValue(User user, KVP kvp)
        {
            throw new NotImplementedException();
        }

        public void SaveValues(User user, KVPList kvps)
        {
            throw new NotImplementedException();
        }

        public ConfigValue GetValue(App app, string key)
        {
            throw new NotImplementedException();
        }

        public KVPList GetValues(App user, KList keys)
        {
            throw new NotImplementedException();
        }

        public void SaveValue(App user, KVP kvp)
        {
            throw new NotImplementedException();
        }

        public void SaveValues(App user, KVPList kvps)
        {
            throw new NotImplementedException();
        }

        public ConfigValue GetValue(App app, User user, string key)
        {
            throw new NotImplementedException();
        }

        public KVPList GetValues(App app, User user, KList keys)
        {
            throw new NotImplementedException();
        }

        public void SaveValue(App app, User user, KVP kvp)
        {
            throw new NotImplementedException();
        }

        public void SaveValues(App app, User user, KVPList kvps)
        {
            throw new NotImplementedException();
        }
    }
}
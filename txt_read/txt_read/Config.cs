using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using txt_read.Modifiers;
using txt_read.Modifiers.ChangingEnd;

namespace txt_read
{
    internal class Config
    {
        public List<Modifier> Modifiers { get; private set; } = new List<Modifier>();
        [JsonProperty("ChangingEndModifier")]
        public ChangingEndModifier ChangingEndModifier
        {
            set
            {
                Modifiers.Add(value);
                _channingEndModifier = value;
            }
            get
            {
                return _channingEndModifier;
            }
        }

        [JsonProperty("CheckNumModifier")]
        public CheckNumModifier CheckNumModifier
        {
            set
            {
                Modifiers.Add(value);
                _checkNumModifier = value;
            }
            get
            {
                return _checkNumModifier;
            }
        }

        [JsonProperty("DuplicatesAllModifier")]
        public DuplicateAllModifier DuplicateAllModifier
        {
            set
            {
                Modifiers.Add(value);
                _duplicateAllModifier = value;
            }
            get
            {
                return _duplicateAllModifier;
            }
        }

        [JsonProperty("DuplicatesNumberModifier")]
        public DuplicatesNumberModifier DuplicatesNumberModifier
        {
            set
            {
                Modifiers.Add(value);
                _duplicatesNumberModifier = value;
            }
            get
            {
                return _duplicatesNumberModifier;
            }
        }

        [JsonProperty("MultiEndModifier")]
        public MultiEndModifier MultiEndModifier
        {
            set
            {
                Modifiers.Add(value);
                _multiEndModifier = value;
            }
            get
            {
                return _multiEndModifier;
            }
        }

        [JsonProperty("OneByOneModifier")]
        public OneByOneModifier OneByOneModifier
        {
            set
            {
                Modifiers.Add(value);
                _oneByOneModifier = value;
            }
            get
            {
                return _oneByOneModifier;
            }
        }


        [JsonProperty("TwoNumbersWordsModifier")]
        public TwoNumbersWordsModifier TwoNumbersWordsModifier
        {
            set
            {
                Modifiers.Add(value);
                _twoNumbersWordsModifier = value;
            }
            get
            {
                return _twoNumbersWordsModifier;
            }
        }


        private static Config _config;
        private CheckNumModifier _checkNumModifier;
        private DuplicateAllModifier _duplicateAllModifier;
        private DuplicatesNumberModifier _duplicatesNumberModifier;
        private MultiEndModifier _multiEndModifier;
        private OneByOneModifier _oneByOneModifier;
        private ReplacementModifier _replacementModifier;
        private TwoNumbersWordsModifier _twoNumbersWordsModifier;
        private ChangingEndModifier _channingEndModifier;

        public Config()
        {
        }

        public static Config GetConfig()
        {
            if (_config is null)
            {
                _config = Create();
            }
            return _config;
        }

        private static Config Create()
        {
            var configSerilized = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<Config>(configSerilized);
            if (config is null)
                throw new ArgumentException("Could not parse config!!");
            return config;
        }
    }
}

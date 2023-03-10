using System.Collections.Generic;

namespace PixelmindSDK
{
    [System.Serializable]
    public class CreateImagineResult
    {
        public CreateImagineRequest request { get; set; }
    }
    
    public class CreateImagineRequest
    {
        public string id { get; set; }
    }
    
    [System.Serializable]
    public class GetImagineResult
    {
        public GetImagineRequest request { get; set; }
    }
    
    public class GetImagineRequest
    {
        public string file_url { get; set; }
        public string status { get; set; }
        public string prompt { get; set; }
    }
    
    [System.Serializable]
    public class Generator
    {
        public int id { get; set; }
        public string generator { get; set; }
        public Dictionary<string, Param> @params { get; set; }
    }
    
    [System.Serializable]
    public class Param
    {
        public string name { get; set; }
        public string type { get; set; }
        public string default_value { get; set; }
        public bool required { get; set; }
    }
    
    public class GeneratorField
    {
        public string key;
        
        public string name;
        
        public string value;
        
        public bool required;
    
        // Constructor to initialize field with data from API response
        public GeneratorField(KeyValuePair<string, Param> fieldData)
        {
            key = fieldData.Key; // "prompt"
            name = fieldData.Value.name; // "Imagine text prompt"
            value = fieldData.Value.default_value ?? "";
            required = fieldData.Value.required;
        }
    }
}
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elsevier_CodeChallenge
{
    /// <summary>
    /// A seperated class for the Json script (save object data). Could be put in Presenter instead, but has been put here to seperate code a bit and make it easier to work around for now.
    /// </summary>
    public class JsonReturner
    {
        public static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        public static void SimpleWrite(Presenter names)
        {
            var jsonString = JsonSerializer.Serialize(names,_options);
            File.WriteAllText("test.json", jsonString);
        }
    }
}

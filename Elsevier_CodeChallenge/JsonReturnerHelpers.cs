using System.Collections.Generic;
using System.Text.Json;

namespace Elsevier_CodeChallenge
{
    internal static class JsonReturnerHelpers
    {
        public static void SimpleWrite(List<Names>names)
        {
            var jsonString = JsonSerializer.Serialize(names, JsonReturner._options);
        }
    }
}
using System.Text.Json;

namespace HyRsn
{
    internal class AIConfig
    {
        internal String Provider { get; set; } = V.SEP;
        internal String ApiKey { get; set; } = V.SEP;
        internal String EndPoint { get; set; } = V.SEP;
        internal String Model { get; set; } = V.SEP;
        internal String Proxy { get; set; } = V.SEP;
        internal List<Object> History { get; set; } = [];
        internal AIStyle Style { get; set; } = new AIStyle();
        internal AIConfig() { }
        private static String JsonGetString(JsonElement Parent, String Name) =>
            Parent.TryGetProperty(Name, out JsonElement JE) ? JE.GetString() ?? V.SEP : V.SEP;
        internal AIConfig(String Path)
        {
            String J = File.ReadAllText(Path);
            try
            {
                using JsonDocument JD = JsonDocument.Parse(J);
                JsonElement JERoot = JD.RootElement;

                Provider = JsonGetString(JERoot, "Provider");
                ApiKey = JsonGetString(JERoot, "ApiKey");
                EndPoint = JsonGetString(JERoot, "EndPoint");
                Model = JsonGetString(JERoot, "Model");
                Proxy = JsonGetString(JERoot, "Proxy");
                History = [];

                if (JERoot.TryGetProperty(nameof(Style), out JsonElement JEStyle))
                {
                    String Name = JsonGetString(JEStyle, "Name");
                    if (String.IsNullOrWhiteSpace(Name)) Name = "Customer AI";
                    String Fore = JsonGetString(JEStyle, "Fore");
                    if (String.IsNullOrWhiteSpace(Fore)) Fore = "#000000";
                    String Back = JsonGetString(JEStyle, "Back");
                    if (String.IsNullOrWhiteSpace(Back)) Back = "#B0C4DE";
                    Style = new AIStyle(Name, Fore, Back);
                }
            }
            catch (Exception EX)
            { MessageBox.Show($"{EX.Message}\r\n{EX.StackTrace}", "[AIConfig] Error!", V.MBBO, V.MBIE); }
        }
    }

    internal class AIStyle
    {
        internal String Name { get; set; } = "Custom AI";
        internal Color Fore { get; set; } = Color.Black;
        internal Color Back { get; set; } = Color.LightSteelBlue;
        private static Color FromHex(String? Hex)
            => string.IsNullOrWhiteSpace(Hex) ? Color.Black : ColorTranslator.FromHtml(Hex);
        internal AIStyle() { }
        internal AIStyle(String? Name, String? Fore, String? Back)
        { this.Name = Name ?? "Custom AI"; this.Fore = FromHex(Fore); this.Back = FromHex(Back); }
    }
}
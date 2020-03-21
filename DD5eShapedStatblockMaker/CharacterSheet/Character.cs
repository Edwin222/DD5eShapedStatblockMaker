using System.IO;

namespace DD5eShapedStatblockMaker.CharacterSheet
{
    public class Character
    {
        public PersonalInfo PersonalInfo { get; set; }

        public Character() { }

        public void WriteData()
        {
            using(var streamWriter = new StreamWriter(new FileStream($"{PersonalInfo.Name}.sheet.md", FileMode.Create, FileAccess.Write)))
            {
                streamWriter.Write(ToMarkdownData());
            }
        }

        string ToMarkdownData()
        {
            var result = "";

            result += "# Character\n";
            result += PersonalInfo;

            return result;
        }
    }
}

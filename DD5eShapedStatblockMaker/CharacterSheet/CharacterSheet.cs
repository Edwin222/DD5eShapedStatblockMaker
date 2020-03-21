using System.IO;

namespace DD5eShapedStatblockMaker.CharacterSheet
{
    public class CharacterSheet
    {
        public readonly PersonalInfo PersonalInfo;

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

            result += PersonalInfo;

            return result;
        }
    }
}

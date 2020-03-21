using DD5eShapedStatblockMaker.Data.Definition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD5eShapedStatblockMaker.Data
{
    public class CharacterSheet
    {
        public string Name { get; set; }
        public CreatureSize Size { get; set; }
        public RacialType Type { get; set; }
        public string TypeTag { get; set; }
        public string Alignment { get; set; }

        public void WriteData()
        {
            using(var streamWriter = new StreamWriter(new FileStream($"{Name}.sheet.md", FileMode.Create, FileAccess.Write)))
            {
                streamWriter.Write(ToMarkdownData());
            }
        }

        string ToMarkdownData()
        {
            var result = "";

            result += $"# {Name}\n";
            result += $"## Personal Info\n";
            result += $"* Tag: {TypeTag}\n";
            result += $"* Alignment: {Alignment}\n";

            return result;
        }
    }
}

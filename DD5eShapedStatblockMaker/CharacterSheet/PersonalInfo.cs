using DD5eShapedStatblockMaker.Data.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD5eShapedStatblockMaker.CharacterSheet
{
    public class PersonalInfo
    {
        public string Name { get; set; }
        public CreatureSize Size { get; set; }
        public RacialType Type { get; set; }
        public string TypeTag { get; set; }
        public string Alignment { get; set; }

        public override string ToString()
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

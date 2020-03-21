using DD5eShapedStatblockMaker.Data.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD5eShapedStatblockMaker.Data
{
    public class Character
    {
        public string Name { get; set; }
        public CreatureSize Size { get; set; }
        public RacialType Type { get; set; }
        public string TypeTag { get; set; }
        public string Alignment { get; set; }
    }
}

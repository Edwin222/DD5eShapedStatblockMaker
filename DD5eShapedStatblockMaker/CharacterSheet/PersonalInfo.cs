using DD5eShapedStatblockMaker.Data.Definition;

namespace DD5eShapedStatblockMaker.CharacterSheet
{
    public struct PersonalInfo
    {
        public readonly string Name;
        public readonly CreatureSize Size;
        public readonly RacialType Type;
        public readonly string TypeTag;
        public readonly string Alignment;

        public PersonalInfo(string name, CreatureSize size, RacialType type, string typeTag, string alignment)
        {
            Name = name;
            Size = size;
            Type = type;
            TypeTag = typeTag;
            Alignment = alignment;
        }

        public override string ToString()
        {
            var result = "";

            result += $"## PersonalInfo\n";
            result += $"* Name: {Name}\n";
            result += $"* Size: {Size}\n";
            result += $"* Type: {Type}\n";
            result += $"* TypeTag: {TypeTag}\n";
            result += $"* Alignment: {Alignment}\n";

            return result;
        }
    }
}

namespace DBCaseSystem_KokovinMedvedevStartsev.Queries
{
    public class LinkNodeTable : LinkNode
    {
        Attribute Attribute;
        public LinkNodeTable(Attribute attribute)
        {
            Attribute = attribute;
        }

        public override object LinkEnd => Attribute;
    }
}

namespace DBCaseSystem_KokovinMedvedevStartsev.Queries
{
    public class LinkNodeQuery : LinkNode
    {
        QueryOutput QueryOutput;
        public LinkNodeQuery(QueryOutput queryOutput)
        {
            QueryOutput = queryOutput;
        }

        public override object LinkEnd => QueryOutput;
    }
}

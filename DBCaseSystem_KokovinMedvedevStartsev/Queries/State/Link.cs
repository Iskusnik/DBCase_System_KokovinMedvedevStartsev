namespace DBCaseSystem_KokovinMedvedevStartsev.Queries
{
    public class Link
    {
        LinkNode left, right;
        public Link(Attribute left, Attribute right)
        {
            this.left = new LinkNodeTable(left);
            this.right = new LinkNodeTable(right);
        }
        public Link(Attribute left, QueryOutput right)
        {

            this.left = new LinkNodeTable(left);
            this.right = new LinkNodeQuery(right);
        }
        public Link(QueryOutput left, QueryOutput right)
        {
            this.left = new LinkNodeQuery(left);
            this.right = new LinkNodeQuery(right);
        }

        public object Left => left.LinkEnd;
        public object Right => right.LinkEnd;
    }
}

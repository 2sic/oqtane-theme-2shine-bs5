namespace ToSic.Oqt.Themes.ToShineBs5.Client.Internal.Menu
{
    internal class MenuNode
    {
        public int Id;
        public bool Force;
    }

    public class StartNode
    {
        public string Anchor { get; set; } = "*";
        public int Level { get; set; } = 0; // 0 meaning current, not top...

        public bool Children { get; set; } = false;
    }

    internal class StartingPoint
    {
        public int PageId;
        public bool Children = false;


        public string SearchStart = ""; // "*", ".", "14"
        public int Level = 0; // -1, -2, -3; 1, 2, 3
    }
}

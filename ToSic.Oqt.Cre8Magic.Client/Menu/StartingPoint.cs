namespace ToSic.Oqt.Cre8Magic.Client.Menu
{
    internal class StartingPoint
    {
        public int Id { get; set; }

        public bool Force { get; set; } = false;

        public string From { get; set; } = "*"; // "*", ".", "43"

        public int Level { get; set; } = 0; // 0 meaning current, not top...// -1, -2, -3; 1, 2, 3

        public bool Children { get; set; } = false;

    }
}

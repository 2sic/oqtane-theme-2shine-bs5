﻿namespace ToSic.Oqt.Cre8ive.Client.Menu
{
    public class StartingPoint
    {
        public int Id { get; set; }

        public bool Force { get; set; } = false;

        public string From { get; set; } = "*"; // "*", ".", "43"

        public int Level { get; set; } = 0; // 0 meaning current, not top...// -1, -2, -3; 1, 2, 3

        public bool Children { get; set; } = false;

    }

    //public class StartingPoint
    //{

    //    public bool Force { get; set; } = false;
    //}
    
}
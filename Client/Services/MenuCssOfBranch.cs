namespace ToSic.Oqt.Themes.ToShineBs5.Client.Services
{
    internal class MenuCssOfBranch
    {
        private readonly MenuCss _menuCss;
        private readonly MenuBranch _branch;

        public MenuCssOfBranch(MenuCss menuCss, MenuBranch branch)
        {
            _menuCss = menuCss;
            _branch = branch;
        }

        public string Classes(string tag) =>
            tag switch
            {
                "a" => _menuCss.ClassesUl(_branch),
                "li" => _menuCss.ClassesLi(_branch),
                "ul" => _menuCss.ClassesUl(_branch),
                _ => ""
            };
    }
}

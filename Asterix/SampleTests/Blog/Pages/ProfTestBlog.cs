using Asterix.Framework.WebUi.Browser;

namespace SampleTests.Blog.Pages
{
    public class ProfTestBlog
    {
        private readonly Browser _browser;

        public const string ServerAddress = "https://professionaltestingblog.wordpress.com/";

        public ProfTestBlog(Browser browser)
        {
            _browser = browser;
        }

        public MainPage MainPage { get {return new MainPage(_browser);} }
    }
}

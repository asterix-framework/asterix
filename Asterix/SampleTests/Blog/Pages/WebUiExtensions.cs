using SampleTests.google.Pages;
using TestContext;

namespace SampleTests.Blog.Pages
{
    public static class WebUiExtensions
    {
        public static ProfTestBlog ProfTestBlog(this WebUi webUi)
        {
                return new ProfTestBlog(webUi.WebBrowser);
        }

        public static Google Google(this WebUi webUi)
        {
            return new Google(webUi.WebBrowser);
        }
    }
}

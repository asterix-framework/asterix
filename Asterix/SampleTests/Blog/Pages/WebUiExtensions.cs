using TestContext;

namespace SampleTests.Blog.Pages
{
    public static class WebUiExtensions
    {
        public static ProfTestBlog ProfTestBlog(this WebUi webUi)
        {
                return new ProfTestBlog(webUi.Browser);
        }
    }
}

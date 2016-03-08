﻿using Asterix.Framework.WebUi.Browser;
using NUnit.Framework;
using TestContext;
using SampleTests.Blog.Pages;

namespace SampleTests.Blog
{
    [TestFixture]
    public class ProfessionalTestingBlogTests
    {
        [Test]
        public void ProTestingBlogTitleDisplayed()
        {
            using (var testContext = TestContextFactory.Create())
            {
                ProfTestBlog profTestBlog = testContext.WebUi.ProfTestBlog();
                
                profTestBlog.MainPage.Navigate(ProfTestBlog.ServerAddress);
                string pageTitle = profTestBlog.MainPage.Title;

                Assert.That(pageTitle, Is.EqualTo("The Professional Testing Blog"));
            }
        }

        [Test]
        [Ignore("Not fully implemented yet")]
        public void ProTestingBlogSearch()
        {
            using (var browser = BrowserFactory.Create(BrowserType.Firefox))
            {
                var profTestBlog = new ProfTestBlog(browser);

                profTestBlog.MainPage.Navigate(ProfTestBlog.ServerAddress);

                profTestBlog.MainPage.Search.Clear();
                profTestBlog.MainPage.Search.SetValue("NUnit");
                //todo click

                var post1Title = profTestBlog.MainPage.FirstPostTitle.Text;

                Assert.That(post1Title, Is.EqualTo("Unit testing with Visual Studio Unit Testing Framework, NUnit and XUnit"));
            }
        }
    }
}


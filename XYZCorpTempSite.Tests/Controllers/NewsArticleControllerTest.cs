using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XYZCorpTempSite;
using XYZCorpTempSite.Contexts;
using XYZCorpTempSite.Controllers;
using XYZCorpTempSite.Interfaces;
using XYZCorpTempSite.Models;
using XYZCorpTempSite.Repositories;

namespace XYZCorpTempSite.Tests.Controllers
{
    [TestClass]
    public class NewsArticleControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var mockRepo = new Mock<NewsRepository>();
            var mockContext = new Mock<NewsContext>();
            mockRepo.Setup(x => x.GetFeaturedArticle(It.IsAny<NewsContext>()))
                .Returns(new NewsArticle
                {
                    Content = "string",
                    Header = "header",
                    NewsEditor = "editor",
                    NewsArticleId = 44
                });
            mockRepo.Setup(x => x.GetArticleById(It.IsAny<NewsContext>(), It.IsAny<int>()))
                .Returns(new NewsArticle
                {
                    Content = "string",
                    Header = "header",
                    NewsEditor = "editor",
                    NewsArticleId = 44
                });
            mockRepo.Setup(x => x.GetArticles(It.IsAny<NewsContext>()))
                .Returns(new List<NewsArticle>
                {
                    new NewsArticle
                    {
                        Content = "string",
                        Header = "header",
                        NewsEditor = "editor",
                        NewsArticleId = 44
                    }
                });
            mockRepo.Setup(x => x.GetCurrentLogo(It.IsAny<NewsContext>()))
                .Returns(new Logo { Alt = "alt", Class = "class", Src = "src" });
            var controller = new NewsArticlesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            var mockRepo = new Mock<NewsRepository>();
            var mockContext = new Mock<NewsContext>();
            mockRepo.Setup(x => x.GetFeaturedArticle(It.IsAny<NewsContext>()))
                .Returns(new NewsArticle
                {
                    Content = "string",
                    Header = "header",
                    NewsEditor = "editor",
                    NewsArticleId = 44
                });
            mockRepo.Setup(x => x.GetArticleById(It.IsAny<NewsContext>(), It.IsAny<int>()))
                .Returns(new NewsArticle
                {
                    Content = "string",
                    Header = "header",
                    NewsEditor = "editor",
                    NewsArticleId = 44
                });
            mockRepo.Setup(x => x.GetArticles(It.IsAny<NewsContext>()))
                .Returns(new List<NewsArticle>
                {
                    new NewsArticle
                    {
                        Content = "string",
                        Header = "header",
                        NewsEditor = "editor",
                        NewsArticleId = 44
                    }
                });
            mockRepo.Setup(x => x.GetCurrentLogo(It.IsAny<NewsContext>()))
                .Returns(new Logo {Alt = "alt", Class = "class", Src = "src"});
            var controller = new NewsArticlesController();

            // Act
            ViewResult result = controller.Edit(34) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();

            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

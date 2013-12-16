using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using GeekTweet.Controllers;
using GeekTweet.Domain.Abstract;
using GeekTweet.Domain.Entities;
using GeekTweet.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeekTweet._6.Tests
{
    [TestClass]
    public class TwitterControllerUnitTest
    {
        [TestMethod]
        public void Unit_Test_Index_Model_count_of_Tweets_are_3()
        {
            // Arrange
            var mockService = new Mock<IGeekTweetService>();
            mockService.Setup(s => s.GetTweets("a")).
                Returns(new List<Tweet> 
                { 
                    new Tweet(),
                    new Tweet(),
                    new Tweet()
                });

            var model = Mock.Of<TwitterIndexViewModel>();
            model.ScreenName = "a";

            var controller = new TwitterController(mockService.Object);

            // Act
            var result = controller.Index(model) as ViewResult;

            // Assert
            var viewModel = result.Model as TwitterIndexViewModel;
            Assert.IsTrue(viewModel.Tweets.Count() == 3);
        }

        [TestMethod]
        public void Unit_Test_Index_exception_handeled_calling_GetTweets()
        {
            // Arrange
            var mockService = new Mock<IGeekTweetService>();
            mockService.Setup(s => s.GetTweets("a")).
                Throws(new Exception("Test!"));

            var mockModel = Mock.Of<TwitterIndexViewModel>();
            mockModel.ScreenName = "a";

            var controller = new TwitterController(mockService.Object);

            // Act
            var result = controller.Index(mockModel) as ViewResult;
            
            // Assert
            Assert.IsNotNull(result.ViewData.ModelState[""].Errors.Count == 1);
        }
    }
}

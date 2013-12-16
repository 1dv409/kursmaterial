using System;
using GeekTweet._6.Tests.Fake;
using GeekTweet.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeekTweet._6.Tests
{
    [TestClass]
    public class TwitterIndexViewModelUnitTest
    {
        [TestMethod]
        public void Unit_Test_ModelState_validation_is_thrown()
        {
            // Arrange
            var controller = new FakeController();
            var viewModel = new TwitterIndexViewModel()
            {
                ScreenName = null, // This is a required property and so this value is invalid.
            };

            // Act
            var result = controller.TestTryValidateModel(viewModel);

            // Assert
            Assert.IsFalse(result);

            var modelState = controller.ModelState;

            Assert.AreEqual(1, modelState.Keys.Count);

            Assert.IsTrue(modelState.Keys.Contains("ScreenName"));
            Assert.IsTrue(modelState["ScreenName"].Errors.Count == 1);
            Assert.AreEqual("The Name field is required.", modelState["ScreenName"].Errors[0].ErrorMessage);
        }
    }
}

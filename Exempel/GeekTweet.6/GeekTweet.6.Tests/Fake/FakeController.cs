using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;

namespace GeekTweet._6.Tests.Fake
{
    public class FakeController : Controller
    {
        public FakeController()
        {
            ControllerContext = (new Mock<ControllerContext>()).Object;
        }

        public bool TestTryValidateModel(object model)
        {
            return TryValidateModel(model);
        }
    }
}

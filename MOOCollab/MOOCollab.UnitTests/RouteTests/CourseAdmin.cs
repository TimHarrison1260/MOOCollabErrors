using System.Web;
using System.Web.Routing;
using MOOCollab.WebUI;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using MOOCollab.Domain;
namespace MOOCollab.UnitTests.RouteTests
{
    [TestClass]
    public class CourseAdmin
    {
        [TestMethod]
        public void courseadmin_index_route()
        {
            var mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                       .Returns("~/CourseAdmin");

            var routes = new RouteCollection();

            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(mockContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("CourseAdmin",routeData.Values["Controller"]);
            Assert.AreEqual("Index",routeData.Values["action"]);
        }

        [TestMethod]
        public void courseadmin_create_route()
        {
            var mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                       .Returns("~/CourseAdmin/Create");

            var routes = new RouteCollection();

            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(mockContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("CourseAdmin", routeData.Values["Controller"]);
            Assert.AreEqual("Create", routeData.Values["action"]);
        }

        [TestMethod]
        public void courseadmin_edit_route()
        {
            var mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                       .Returns("~/CourseAdmin/Edit");

            var routes = new RouteCollection();

            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(mockContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("CourseAdmin", routeData.Values["Controller"]);
            Assert.AreEqual("Edit", routeData.Values["action"]);
        }

        [TestMethod]
        public void courseadmin_details_route()
        {
            var mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                       .Returns("~/CourseAdmin/Details");

            var routes = new RouteCollection();

            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(mockContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("CourseAdmin", routeData.Values["Controller"]);
            Assert.AreEqual("Details", routeData.Values["action"]);
        }

        [TestMethod]
        public void courseadmin_delete_route()
        {
            var mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                       .Returns("~/CourseAdmin/Delete");

            var routes = new RouteCollection();

            RouteConfig.RegisterRoutes(routes);

            RouteData routeData = routes.GetRouteData(mockContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("CourseAdmin", routeData.Values["Controller"]);
            Assert.AreEqual("Delete", routeData.Values["action"]);
        }
    }
}
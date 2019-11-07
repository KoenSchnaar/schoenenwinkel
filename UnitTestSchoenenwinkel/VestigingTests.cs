using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schoenenwinkel.Controllers;
using Schoenenwinkel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnitTestSchoenenwinkel.FakeRepositories;

namespace UnitTestSchoenenwinkel
{
    [TestClass]
    public class VestigingTests
    {
        [TestMethod]
        public void GetVoorraadVestiging_Action_Should_Return_Viewresult()
        {
            //Arrange
            var controller = new VestigingController(new FakeVestigingVoorraadRepo());

            //Act
            var result = controller.GetVoorraadVestiging(1, "TestFotoPath");

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetVoorraadVestiging_Action_Should_Correct_Model()
        {
            //Arrange
            var controller = new VestigingController(new FakeVestigingVoorraadRepo());

            //Act
            var result = controller.GetVoorraadVestiging(1, "TestFotoPath");
            var viewresult = (ViewResult)result;

            //Assert
            Assert.IsInstanceOfType(viewresult.Model, typeof(List<VestigingVoorraadModel>));
        }

        [TestMethod]
        public void GetVoorraadVestiging_Action_Should_Return_Same_ProductID_As_Input()
        {
            //Arrange
            var controller = new VestigingController(new FakeVestigingVoorraadRepo());

            //Act
            var result = controller.GetVoorraadVestiging(1, "TestFotoPath");
            var viewresult = (ViewResult)result;
            var model = (List<VestigingVoorraadModel>) viewresult.Model;

            //Assert
            Assert.IsTrue(model[0].ProductID == 1);
        }
        [TestMethod]
        public void GetVoorraadVestiging_Post_Should_Return_View_When_Modelstate_Is_Valid()
        {
            //Arrange
            var controller = new VestigingController(new FakeVestigingVoorraadRepo());

            //Act
            controller.ModelState.AddModelError("", new Exception());
            var result = controller.GetVoorraadVestiging(new List<VestigingVoorraadModel>(), "TestFotopath", 1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetVoorraadVestiging_Post_Should_Return_Redirect_When_Modelstate_Is_Not_Valid()
        {
            //Arrange
            var controller = new VestigingController(new FakeVestigingVoorraadRepo());

            //Act
            controller.ModelState.IsValidField("");
            var result = controller.GetVoorraadVestiging(new List<VestigingVoorraadModel>(), "TestFotopath", 1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}

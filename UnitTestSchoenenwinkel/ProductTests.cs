using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schoenenwinkel.Controllers;
using Schoenenwinkel.Models;
using Schoenenwinkel.Repositories;
using UnitTestSchoenenwinkel.FakeRepositories;

namespace UnitTestSchoenenwinkel
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void Producten_Action_Should_Return_ViewResult()
        {
            //arrange
            var controller = new ProductController(new FakeProductRepo());

            //act
            var result = controller.Producten();

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Producten_Action_Should_Return_Correct_Model()
        {
            //arrange
            var controller = new ProductController(new FakeProductRepo());

            //act
            var result = controller.Producten();
            var viewresult = (ViewResult)result;

            //assert
            Assert.IsInstanceOfType(viewresult.Model, typeof(List<ProductModel>));
        }

        [TestMethod]
        public void Producten_Action_Should_Return_Correct_Model_Data()
        {
            //arrange
            var controller = new ProductController(new FakeProductRepo());

            //act
            var result = controller.Producten();
            var viewresult = (ViewResult)result;
            var model = (List<ProductModel>)viewresult.Model;

            //assert
            Assert.IsTrue(model[0].Model == "testModel");
        }

        [TestMethod]
        public void Update_Action_Should_Return_View_Type_When_ModelState_Is_Not_Valid()
        {

            //arrange
            var controller = new ProductController(new FakeProductRepo());

            //act
            controller.ModelState.AddModelError("", new Exception());
            var result = controller.Update(new ProductModel());

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Update_Action_Should_Return_redirection_When_ModelState_Is_Valid()
        {
            //arrange
            var controller = new ProductController(new FakeProductRepo());

            //act
            controller.ModelState.IsValidField("");
            var result = controller.Update(new ProductModel());

            //assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}

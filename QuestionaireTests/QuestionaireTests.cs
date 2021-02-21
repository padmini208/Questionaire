using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using q.Controllers;
using SampleAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace QuestionaireTests
{
    [TestClass]
    public class QuestionaireTests
    {
        
        [TestMethod]
        public async Task TestGetAll()
        {
            var controller = new ques(_reasonToHireContext);
            ActionResult<IEnumerable<ReasonToHire>> result = await controller.GetReasonsToHire();
            IEnumerable<ReasonToHire> reasons = result.Value;
            Assert.IsNotNull(reasons);
            Assert.IsTrue(reasons.Count() > 0);
            //ensure that the reasons are deleted, otherwise we'll end up trying to insert more in the next test run
            _reasonToHireContext.Database.EnsureDeleted();
        }
        [TestMethod]
        public async Task TestGetOne()
        {
            var controller = new ReasonToHireController(_reasonToHireContext);
            ActionResult<ReasonToHire> result = await controller.GetReasonToHire(1);
            ReasonToHire reason = result.Value;
            Assert.IsNotNull(reason);
            Assert.IsTrue(reason.Id == 1);
            //ensure that the reasons are deleted, otherwise we'll end up trying to insert more in the next test run
            _reasonToHireContext.Database.EnsureDeleted();
        }
    }
}

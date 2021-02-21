using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questionaire;
using Questionaire.Model;
using Questionaire.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace QuestionaireTest
{
    public class Tests
    {
        List<ReasonsToBeHired> ReasonsList;
        private DataContext _QuestionaireContext;
        private SqlQuestionaireRepository sqlrepository;
                public IConfiguration Configuration { get; }

        string DefaultConnection = "Server=LAPTOP-RJVR05K4\\SQLEXPRESS; " +
                "Database = Questionaire;Trusted_Connection = True;MultipleActiveResultSets=True";
 
        [SetUp]
        public void Setup()
        {
            SetUpMockData();
            var builder = new DbContextOptionsBuilder<DataContext>()
                                .UseSqlServer<DataContext>(DefaultConnection, null);
            var context = new DataContext(builder.Options);
            
            
            sqlrepository = new SqlQuestionaireRepository(context);
            foreach (var reason in ReasonsList)
            {
                context.ReasonstoBeHired.Add(reason);
                context.SaveChanges();
            }
            context.ReasonstoBeHired.AddRange(ReasonsList);
            
            _QuestionaireContext = context;
              
        }

        public void SetUpMockData()
        {
            ReasonsList =  new List<ReasonsToBeHired>()
            {
                new ReasonsToBeHired
                {
                     
                    FirstName = "John",
                    LastName="Mecham",
                    FirstReason = "Reason 1",
                    SecondReason = "Reason 2",
                    ThirdReason = "Reason 3",
                    Email = "abc@gmail.com"


                },
                 new ReasonsToBeHired
                {
                    
                    FirstName = "John",
                    LastName="Mecham",
                    FirstReason = "Reason 11",
                    SecondReason = "Reason 22",
                    ThirdReason = "Reason 33",
                    Email = "abc@gmail.com"



                },
                 new ReasonsToBeHired
                {
                     
                    FirstName = "John",
                    LastName="Mecham",
                    FirstReason = "Reason 31",
                    SecondReason = "Reason 32",
                    ThirdReason = "Reason 33",
                     Email = "abc@gmail.com"

                },
          };
            



    }
    

     
 
        [Test]
        public  void  TestGetAllReasons()
        {
            var controller = new Questionaire.Controllers.QuestionaireController(sqlrepository);
            ActionResult<IEnumerable<ReasonsToBeHired>> result =  controller.GetReasonsForAll();
            
            IEnumerable<ReasonsToBeHired> reasons =(IEnumerable<ReasonsToBeHired>)Convert.ChangeType((result.Result as ObjectResult)?.Value, typeof(ReasonsToBeHired));//result.Value;
            Assert.IsNotNull(reasons);
            Assert.IsTrue(reasons.Count() > 0);
           
            _QuestionaireContext.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetOneReason()
        {
            var controller = new Questionaire.Controllers.QuestionaireController(sqlrepository);
            ActionResult<ReasonsToBeHired> result =   controller.GetReasonsbyID(2) ;
             ReasonsToBeHired reason =  
                                      (ReasonsToBeHired)Convert.ChangeType((result.Result as ObjectResult)?.Value, typeof(ReasonsToBeHired));
            Assert.IsNotNull(result);

            
           
            _QuestionaireContext.Database.EnsureDeleted();
        }




    }
}



 

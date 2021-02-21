using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Questionaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Questionaire.Repository
{
    class MockQuestionaireRepository : IQuestionaireRepository
    {
        private List<ReasonsToBeHired> ReasonsList;

        public MockQuestionaireRepository()
        {
            ReasonsList = new List<ReasonsToBeHired>()
            {
                new ReasonsToBeHired
                {
                    ID = 101,
                    FirstName = "John",
                    LastName="Mecham",
                    FirstReason = "Reason 1",
                    SecondReason = "Reason 2",
                    ThirdReason = "Reason 3",
                    Email = "abc@gmail.com"


                },

                new ReasonsToBeHired
                {
                    ID = 102,
                    FirstName = "John",
                    LastName="Mecham",
                    FirstReason = "Reason 11",
                    SecondReason = "Reason 22",
                    ThirdReason = "Reason 33",
                    Email = "abc@gmail.com"



                },
                 new ReasonsToBeHired
                {
                    ID = 103,
                    FirstName = "John",
                    LastName="Mecham",
                    FirstReason = "Reason 31",
                    SecondReason = "Reason 32",
                    ThirdReason = "Reason 33",
                     Email = "abc@gmail.com"

                },
            };
        }

        public ReasonsToBeHired AddReason(ReasonsToBeHired reasonsToBeHired)
        {
            if (reasonsToBeHired != null)
            {
                ReasonsList.Add(reasonsToBeHired);
                return reasonsToBeHired;
            }
            else
            {
                return null;
            }
        }

        public ReasonsToBeHired DeleteReason(int ID)
        {
            var deletedReason = ReasonsList.FirstOrDefault(a => a.ID == ID);
            deletedReason.IsDeleted = true;

            return deletedReason;
        }


        public ReasonsToBeHired GetMyReasons(int ID)
        {
            ReasonsToBeHired MyReason = ReasonsList.FirstOrDefault(a => a.ID == ID && a.IsDeleted == false);
            return MyReason;
        }

        public IEnumerable<ReasonsToBeHired> GetReasonsForAll()
        {

            return ReasonsList.Where(a => a.IsDeleted == false);

        }

        public ReasonsToBeHired UpdateReason(int ID, ReasonsToBeHired Reason)
        {
            var ModifiedReason = ReasonsList.FirstOrDefault(a => a.ID == ID);

            ModifiedReason.FirstName = Reason.FirstName;
            ModifiedReason.LastName = Reason.LastName;
            ModifiedReason.FirstReason = Reason.FirstReason;
            ModifiedReason.SecondReason = Reason.SecondReason;
            ModifiedReason.ThirdReason = Reason.ThirdReason;
            ModifiedReason.Email = Reason.Email;
            ModifiedReason.LastUpdated = DateTime.Now;

            return ModifiedReason;

        }

        Task<ReasonsToBeHired> IQuestionaireRepository.AddReason(ReasonsToBeHired reasonsToBeHired)
        {
            throw new NotImplementedException();
        }

        Task<ReasonsToBeHired> IQuestionaireRepository.DeleteReason(int ID)
        {
            throw new NotImplementedException();
        }

        Task<ReasonsToBeHired> IQuestionaireRepository.UpdateReason(int ID, ReasonsToBeHired Reason)
        {
            throw new NotImplementedException();
        }
    }

       

}

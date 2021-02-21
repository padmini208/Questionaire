using Microsoft.AspNetCore.Mvc;
using Questionaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionaire.Repository
{
    public interface IQuestionaireRepository
    {
        public IEnumerable<ReasonsToBeHired> GetReasonsForAll();
        public ReasonsToBeHired GetMyReasons(int ID);
        public Task<ReasonsToBeHired> AddReason(ReasonsToBeHired reasonsToBeHired);
        public Task<ReasonsToBeHired> DeleteReason(int ID);
        public Task<ReasonsToBeHired> UpdateReason(int ID, ReasonsToBeHired Reason);

    }
}

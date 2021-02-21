using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Questionaire.Repository
{
    public class SqlQuestionaireRepository : IQuestionaireRepository
    {
        private readonly DataContext dataContext;

        public SqlQuestionaireRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ReasonsToBeHired> AddReason(ReasonsToBeHired reasonsToBeHired)
        {
            try
            {
                await dataContext.AddAsync(reasonsToBeHired);
                await dataContext.SaveChangesAsync();
                return reasonsToBeHired;
            }

            catch 
            {
                //write to Log;
                
                return null;
            }
        }

        public  async Task<ReasonsToBeHired> DeleteReason(int ID)
        {
            ReasonsToBeHired reasonsToBeHired =    dataContext.ReasonstoBeHired
                                                   .FirstOrDefault(a => a.IsDeleted == false && a.ID == ID);

            try
            {
                if (reasonsToBeHired != null)
                {
                    reasonsToBeHired.IsDeleted = true;
                    reasonsToBeHired.LastUpdated = DateTime.Now;
                    await dataContext.SaveChangesAsync();
                }

                return reasonsToBeHired;

            }
            catch (Exception ex)
            {
                //log in the file using Nlog
                return null;
             }
        }

        public ReasonsToBeHired GetMyReasons(int ID)
        {
            try
            {
                var reasonToBeHired = dataContext.ReasonstoBeHired
                                    .FirstOrDefault(a => a.IsDeleted == false && a.ID == ID);
                return reasonToBeHired != null ? reasonToBeHired : null;
            }

            catch (Exception ex)
            {
                //log exception 
                return null;//status code later
            }
          
        }

        public IEnumerable<ReasonsToBeHired> GetReasonsForAll()
        {
            try
            {
               IEnumerable<ReasonsToBeHired> Reasons = dataContext.ReasonstoBeHired.ToList()
                                                        .Where(a => a.IsDeleted == false);
                                                        
               
                return Reasons.Count() > 0 ? Reasons : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       public async Task<ReasonsToBeHired> UpdateReason(int ID, ReasonsToBeHired Reason)
        {
            var ModifiedReasontoBeHired = dataContext.ReasonstoBeHired.FirstOrDefault(a => a.ID == ID);

            try
            {
                if (ModifiedReasontoBeHired != null)
                {
                    ModifiedReasontoBeHired.FirstName = Reason.FirstName;
                    ModifiedReasontoBeHired.LastName = Reason.LastName;
                    ModifiedReasontoBeHired.FirstReason = Reason.FirstReason;
                    ModifiedReasontoBeHired.SecondReason = Reason.SecondReason;
                    ModifiedReasontoBeHired.ThirdReason = Reason.ThirdReason;
                    ModifiedReasontoBeHired.Email = Reason.Email;
                    ModifiedReasontoBeHired.LastUpdated = DateTime.Now;
                   await  dataContext.SaveChangesAsync();

                    return ModifiedReasontoBeHired;
                }
                else
                {

                    return null;
                }

            }
            catch ( DbUpdateException ex)
            {

                return null;
                //Log in the log file.
            }

           

           
        }

       
        

       

       
    }
}

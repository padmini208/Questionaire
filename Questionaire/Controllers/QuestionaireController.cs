using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Questionaire.Model;
using Questionaire.Repository;
 using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace Questionaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionaireController : ControllerBase
    {
        private readonly IQuestionaireRepository questionaireRepository;
       

        public QuestionaireController(IQuestionaireRepository questionaireRepository )
        {
            this.questionaireRepository = questionaireRepository;
           
        }

        [HttpGet]
        public   ActionResult<IEnumerable<ReasonsToBeHired>> GetReasonsForAll()
        {
            try
            {
                var Reasons = (questionaireRepository.GetReasonsForAll());
                if (Reasons == null)
                {return NotFound();}

                return Ok(Reasons);
            }
            catch(Exception ex)
            {
              //  _logger.Log(LogLevel.Error, ex.Message, ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ReasonsToBeHired> GetReasonsbyID(int ID)
        {
            try
            {
                  var Reason = questionaireRepository.GetMyReasons(ID);
                  if (Reason == null)
                    { return NotFound();}
                   
                     return Ok(Reason);
            }
            catch (Exception ex)
            {
              //  _logger.Log(LogLevel.Error, ex.Message,ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpPost]
        public  async Task<ActionResult<ReasonsToBeHired>> AddReason([FromBody] ReasonsToBeHired reasonsToBeHired)
        {
            try
            {
                var newReason = await questionaireRepository.AddReason(reasonsToBeHired);
                return Ok(newReason);
            }
            catch  (Exception ex)
            {
           //     _logger.Log(LogLevel.Error, ex.Message, ex.StackTrace);
                return BadRequest("Unable to process your request");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReasonsToBeHired>> UpdateReason(int id, [FromBody] ReasonsToBeHired reasonsToBeHired)
        {
            try
            {
                   var UpdatedReason = await questionaireRepository.UpdateReason(id, reasonsToBeHired);
                    if (UpdatedReason == null )
                    { return NotFound("Record not Found"); }
                    return Ok(UpdatedReason);
            }
            catch (Exception ex)
            {
              //  _logger.Log(LogLevel.Error, ex.Message, ex.StackTrace);
                return BadRequest("Unable to update the Record");
            }
       }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReason(int id)
        {
            try
            {
                    var DeletedRecord = await questionaireRepository.DeleteReason(id);
                    if (DeletedRecord ==null)
                    {
                        return NotFound("Unable to find the Record");
                    }
                    return Ok(DeletedRecord);
            }
            catch (Exception ex)
            {
             //   _logger.Log(LogLevel.Error, ex.Message, ex.StackTrace);
                return BadRequest("Unable to delete the record");
            }
        }
    }
}

using LoanApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanContext _context;
        public LoanController(LoanContext loanDbContext)
        {
            _context = loanDbContext;
        }

        [HttpGet("getLoanDetails")]
        public IActionResult getLoanDetails()
        {
            var loanDetails = _context.LoanDetails.AsQueryable();

            return Ok(loanDetails);
        }
        [HttpPost("addNewLoan")]
        public IActionResult addNewLoan(LoanDetails objLoanDetails)
        {
           var isExistLoan= _context.LoanDetails.Where(a => a.LoanNumber == objLoanDetails.LoanNumber).FirstOrDefault();
            if (isExistLoan == null)
            {
                objLoanDetails.LoanId = 0;
                objLoanDetails.LoanAmmount = Convert.ToDouble(objLoanDetails.LoanAmmount);

                _context.LoanDetails.Add(objLoanDetails);
                _context.SaveChanges();

                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Loan added Suceessfully"
                });
            }
            else
            {
                return Ok(new 
                {
                    StatusCode = 400,
                    Message = "Loan Number is Already Present"

                });
            }
            
        }


        [HttpPost("updateLoanDetails")]

        public IActionResult updateLoanDetails(LoanDetails objUpdateLoanDetails)
        {
            var updatableObj = _context.LoanDetails.Find(objUpdateLoanDetails.LoanId);

            if (updatableObj != null)
            {
                updatableObj.LoanAccountHolderFirstName = objUpdateLoanDetails.LoanAccountHolderFirstName;
                updatableObj.LoanAccountHolderLastName = objUpdateLoanDetails.LoanAccountHolderLastName;
                updatableObj.PropertyAddress = objUpdateLoanDetails.PropertyAddress;
                updatableObj.LoanTerm = objUpdateLoanDetails.LoanTerm;
                updatableObj.LoanType = objUpdateLoanDetails.LoanType;
                updatableObj.LoanAmmount = objUpdateLoanDetails.LoanAmmount;

                _context.LoanDetails.Update(updatableObj);
                _context.SaveChanges();

                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Loan Deatils Update Suceessfully"
                });

            }
            else
            {
                return Ok(new
                {
                    StatusCode = 400,
                    Message = "Update Failed!"
                });
            }

           
        }
    }
}

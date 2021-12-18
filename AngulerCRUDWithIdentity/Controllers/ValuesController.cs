using AngulerCRUDWithIdentity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngulerCRUDWithIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly paymentDbContext _context;
        public ValuesController(paymentDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<PaymentInfo>> Get()
        {
            return await _context.paymentInfos.ToListAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<PaymentInfo> Get(int id)
        {
            return await _context.paymentInfos.Where(x => x.paymentId == id).FirstOrDefaultAsync();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<PaymentInfo> Post([FromBody] PaymentInfo model)
        {
            try
            {
                if (model.paymentId == 0)
                {
                    await _context.paymentInfos.AddAsync(model);
                }
                else
                {
                    var obj = await _context.paymentInfos.FindAsync(model.paymentId);
                    obj.cardOwnerName = model.cardOwnerName;
                    obj.cardNumber = model.cardNumber;
                    obj.cvcNumber = model.cvcNumber;
                    obj.amount = model.amount;
                    obj.expiryDate = model.expiryDate;
                    obj.paymentDate = model.paymentDate;
                    obj.remarks = model.remarks;
                    obj.status = model.status;
                    _context.paymentInfos.Update(obj);
                }
                await _context.SaveChangesAsync();
                return await _context.paymentInfos.Where(x => x.paymentId == model.paymentId).FirstOrDefaultAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            try
            {
                var obj = await _context.paymentInfos.FindAsync(id);
                _context.paymentInfos.Remove(obj);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

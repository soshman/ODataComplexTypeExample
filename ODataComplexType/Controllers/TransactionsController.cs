using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataComplexType.Entities;

namespace ODataComplexType.Controllers
{
    public class TransactionsController : ODataController
    {
        private readonly ODataContext _dataContext;

        public TransactionsController(ODataContext dataContext) => _dataContext = dataContext;

        [EnableQuery]
        public ActionResult<IEnumerable<Transaction>> Get() => Ok(_dataContext.Transactions);

        [EnableQuery]
        public async Task<ActionResult<Transaction>> Get([FromRoute] int key)
        {
            if (!await _dataContext.Transactions.AnyAsync(p => p.Id.Equals(key)))
            {
                return NotFound();
            }

            return Ok(SingleResult.Create(_dataContext.Transactions.Where(p => p.Id.Equals(key))));
        }
    }
}

using CQRSDemo.Data;
using CQRSDemo.Framework.CQRS.Command;
using CQRSDemo.Framework.CQRS.Query;
using CQRSDemo.Framework.Request;
using CQRSDemo.Framework.Response;
using CQRSDemo.Framework.Validators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GetAll

        [HttpGet("getall")]
        public async Task<ActionResult<List<CustomerResponse>>> GetAllCustomers()
        {
            var query = new GetAllCustomerQuery();
            var response = await _mediator.Send(query);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        #endregion

        #region Create

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] AddCustomerRequest addCustomer)
        {
            try
            {
                var validator = new AddCustomerValidator();
                var validationResult = await validator.ValidateAsync(addCustomer);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var addCustomerCommand = new AddCustomerCommand(addCustomer);
                var responseCreate = await _mediator.Send(addCustomerCommand);

                ResponseModel response = new ResponseModel();
                response.Success = true;
                response.Message = "Customer created successfully";

                return Ok(response);

            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetById

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<CustomerByIdResponse>> GetCustomerById([FromRoute(Name = "id")] long customerID)
        {
            var query = new GetCustomerByIdQuery(customerID);
            var response = await _mediator.Send(query);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        #endregion

        #region Update

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest updateCustomer)
        {
            try
            {
                var validation = new UpdateCustomerValidator();
                var validationResult = await validation.ValidateAsync(updateCustomer);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                var customer = new UpdateCustomerCommand(updateCustomer);
                var responseUpdate = await _mediator.Send(customer);


                ResponseModel response = new ResponseModel();
                response.Success = true;
                response.Message = "Customer updated successfully";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        #endregion

        #region Delete

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute(Name = "id")] long ID)
        {
            var customer = new DeleteCustomerCommand(ID);
            var responseDelete = await _mediator.Send(customer);


            ResponseModel response = new ResponseModel();
            response.Success = true;
            response.Message = "Customer deleted successfully";
            return Ok(response);
        }
        #endregion
    }
}

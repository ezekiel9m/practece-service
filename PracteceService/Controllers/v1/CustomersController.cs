using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracteceService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TecmExceptions;
using VeripagExceptions;

namespace PracteceService.Controllers.v1
{
    [EnableCors("AllowAll")]
    [Route("v1/[controller]")]
    public class CustomersController : BaseController
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Forms()
        {
            return  View("Forms");
        }

        [HttpGet]
        public IActionResult ListCustomer()
        {
            try
            {
                var customer = _customerService.GetCustomer().Select(x => Mappings.CustomerMap.Mapping(x));

               //return View("List", customer);

                return Ok(customer);
            }
            catch(TecmErrorException rex)
            {
                return ResponseByCode(rex.ErrorModel.ErrorCode, rex.ErrorModel);
            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();

            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerSpecific([FromRoute] string customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomerSpecific(customerId);

                var response = Mappings.CustomerMap.Mapping(customer);

                //return View("Details", Ok(response));

                return Ok(response);
            }
            catch (TecmErrorException rex)
            {
                return ResponseByCode(rex.ErrorModel.ErrorCode, rex.ErrorModel);
            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();

            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Models.Customer.CustomerModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ParameterName = "customer_not_created",
                        Message = "customer model is null"
                    });
                }

                if (model.BirthDate > DateTime.UtcNow)
                {
                    throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ParameterName = "birth_date_invalid ",
                        Message = "birth date greater than the current date"
                    });
                }


                var userValidator = new Models.Validator.CustomerValidator(_customerService);

                var validation = userValidator.Validate(model);

                if (!validation.IsValid)
                {
                    return StatusCode(400, validation.ValidationError());
                }

                var customer = await  _customerService.CreateCustomer(model);

                var response = Mappings.CustomerMap.Mapping(customer);

                //return View("Forms", response);

                return Created(response);
            }
            catch (TecmErrorException rex)
            {
                return ResponseByCode(rex.ErrorModel.ErrorCode, rex.ErrorModel);
            }
            catch(Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();

            }
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Models.Customer.CustomerModel model, string customerId)
        {
            try
            {
                if (model == null)
                {
                    throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ParameterName = "customer_not_updated",
                        Message = "customer model is null"
                    });
                }

                var customer = await _customerService.UpdateCustomer(model, customerId);

                var response = Mappings.CustomerMap.Mapping(customer);

                //return View("Forms", Ok(response));
                return Ok(response);
            }
            catch (TecmErrorException rex)
            {
                return ResponseByCode(rex.ErrorModel.ErrorCode, rex.ErrorModel);
            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();

            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            try
            {
                await _customerService.DeleteCustomer(customerId);

                //return View("List", customer);

                return NoContent();
            }
            catch (TecmErrorException rex)
            {
                return ResponseByCode(rex.ErrorModel.ErrorCode, rex.ErrorModel);
            }
            catch (Exception ex)
            {
#if DEBUG
                return InternalServerError(ex);
#endif
                return InternalServerError();

            }
        }
    }
}

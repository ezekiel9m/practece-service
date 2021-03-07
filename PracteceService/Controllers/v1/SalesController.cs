using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PracteceService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TecmExceptions;

namespace PracteceService.Controllers.v1
{
    [EnableCors("AllowAll")]
    [Route("v1/[controller]")]
    public class SalesController : BaseController
    {
        private readonly SaleService _saleService;
        public SalesController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult ListSales()
        {
            try
            {
                var saleList = _saleService.ListSales().Select(x => Mappings.SaleMap.Mapping(x));

               // return View("List", saleList);

                return Ok(saleList);
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

        [HttpGet("{saleId}")]
        public async Task<IActionResult> GetSaleSpecific(int saleId)
        {
            try
            {
                var sale = await _saleService.GetSaleSpecific(saleId);

                var response = Mappings.SaleMap.Mapping(sale);

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
        public async Task<IActionResult> CreateSale([FromBody] Models.Sale.SaleModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ParameterName = "sale_not_created",
                        Message = "sale model is null"
                    });
                }

                var sale = await _saleService.CreateSale(model);

                var response = Mappings.SaleMap.Mapping(sale);

                //return View("Forms", Ok(response));

                return Created(response);
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

        [HttpPut("{saleId}")]
        public async Task<IActionResult> UpdateSale([FromBody] Models.Sale.SaleModel model, int saleId)
        {
            try
            {
                if (model == null)
                {
                    throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                    {
                        ErrorCode = 400,
                        ParameterName = "sale_not_updated",
                        Message = "sale model is null"
                    });
                }

                var sale = await _saleService.UpdateSale(model, saleId);

                var response = Mappings.SaleMap.Mapping(sale);

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

        [HttpDelete("{saleId}")]
        public async Task<IActionResult> DeleteSale(int saleId)
        {
            try
            {

                await _saleService.DeleteSale(saleId);

                //return View("List", Ok(customer));

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

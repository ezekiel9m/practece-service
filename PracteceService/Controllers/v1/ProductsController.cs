using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductsController : BaseController
    {
        private readonly SaleService _saleService;
        private readonly ProductService _productService;

        public ProductsController(ProductService productService, SaleService saleService)
        {
            _saleService = saleService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ListProduct()
        {
            try
            {
                var products =   _productService.ListProduct().Select(x => Mappings.ProductMap.Mapping(x));

                //return View("List", products);

                return Ok(products);
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


        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductSpecific(int productId)
        {
            try
            {
                var product = await _productService.GetProductSpecific(productId);

                var response = Mappings.ProductMap.Mapping(product);

                // return View("Details", Ok(customer));

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
        public async Task<IActionResult> CreateProduct([FromBody] Models.Product.ProductModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ParameterName = "product_not_created",
                        Message = "product model is null"
                    });
                }

                var userValidator = new Models.Validator.ProductValidator(_productService);

                var validation = userValidator.Validate(model);

                if (!validation.IsValid)
                {
                    return StatusCode(400, validation.ValidationError());
                }

                var product = await _productService.CreateProduct(model);

                var response = Mappings.ProductMap.Mapping(product);

                //return View("Forms", response);

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

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Models.Product.ProductModel model, int productId)
        {
            try
            {
                if (model == null)
                {
                    throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                    {
                        ErrorCode = (int)HttpStatusCode.BadRequest,
                        ParameterName = "prodcut_not_updated",
                        Message = "product model is null"
                    });
                }

                var product = await _productService.UpdateProduct(model, productId);

                var response = Mappings.ProductMap.Mapping(product);

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

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                await _saleService.DeleteProductSale(productId);

                await _productService.DeleteProduct(productId);

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

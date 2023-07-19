using AppDomain.Dtos.Product;
using Application.Features.Commands.CreateProduct;
using Application.Features.Queries.GetAllProduct;
using Application.Features.Queries.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IMediator _mediator;
        ILogger<ProductController> _logger;
        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _logger.LogInformation("Product controller is called!");
        }

        [HttpGet]
        public async Task<List<GetProductDto>> GetAll()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

        [HttpGet("{Id}")]
        public async Task<GetProductDto> Get(GetByIdProductQuery request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]
        public async Task<CreateProductDto> Add(CreateProductCommand request)
        {
            _logger.LogInformation("Product Add method ise basladi!");
            return await _mediator.Send(request);

            //    var problemDetails = new ProblemDetails
            //    {
            //        Status = StatusCodes.Status403Forbidden,
            //        Type = "https://example.com/probs/out-of-credit",
            //        Title = $"{ex.Message}",
            //        Detail = ex.StackTrace,
            //        Instance = HttpContext.Request.Path
            //    };
        }
    }
}
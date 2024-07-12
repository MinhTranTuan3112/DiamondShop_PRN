using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Certificate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiamondShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly IServiceFactory _serviceFactory;

        public CertificatesController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        [HttpPost]
        public async Task<ActionResult<GetCertificateIdDto>> CreateCertificate([FromBody] CreateCertificateDto createCertificateDto)
        {
            return Created(nameof(CreateCertificate), await _serviceFactory.GetCertificateService().CreateCertificate(createCertificateDto));
        }
        [HttpGet("{origin}/{reportNumber}")]
        public async Task<ActionResult<GetCertificateDetailDto>> GetCertificateByOriginAndReportNumberForCreateDiamond(string origin, string reportNumber)
        {
            return await _serviceFactory.GetCertificateService().GetCertificateByOriginAndReportNumberForCreateDiamond(origin, reportNumber);
        }
        [HttpGet]
        public async Task<ActionResult<List<GetListCertificateDto>>> GetAllCertificates()
        {
            return await _serviceFactory.GetCertificateService().GetAllCertificates();
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateCertificate(Guid id, [FromBody] UpdateCertificateDto updateCertificateDto)
        {
            await _serviceFactory.GetCertificateService().UpdateCertificate(id, updateCertificateDto);
            return NoContent();
        }
    }
}

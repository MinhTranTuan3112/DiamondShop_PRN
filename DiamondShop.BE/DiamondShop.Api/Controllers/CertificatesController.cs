using DiamondShop.BusinessLogic.Interfaces;
using DiamondShop.DataAccess.DTOs.Certificate;
using DiamondShop.DataAccess.DTOs.Query;
using DiamondShop.DataAccess.Enums;
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
        public async Task<ActionResult<PagedResult<GetListCertificateDto>>> GetPageCertificates([FromQuery] QueryCertificateDto queryCertificateDto)
        {
            return await _serviceFactory.GetCertificateService().GetPageCertificates(queryCertificateDto);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateCertificate(Guid id, [FromBody] UpdateCertificateDto updateCertificateDto)
        {
            await _serviceFactory.GetCertificateService().UpdateCertificate(id, updateCertificateDto);
            return NoContent();
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetCertificateByIdDto>> GetCertificateById(Guid id)
        {
            return await _serviceFactory.GetCertificateService().GetCertificateById(id);
        }
        
        [HttpPut("{certificateId:guid}/{status}")]
        public async Task<ActionResult> ChangeStatusCategory(Guid certificateId, CertificateStatus status)
        {
            await _serviceFactory.GetCertificateService().ChangStatusCertificate(certificateId, status);
            return NoContent();
        }
    }
}

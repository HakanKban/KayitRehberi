using KayitRehberi.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KayitRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ICommercialActivityWriteRepository _commercialActivityWriteRepository;

        public CustomersController(ICustomerWriteRepository customerWriteRepository, ICommercialActivityWriteRepository commercialActivityWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _commercialActivityWriteRepository = commercialActivityWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _customerWriteRepository.AddAsync(new()
            {
                Id = 1,
                Name = "Hakan",
                SurName = "Kaban",
                City = "İstanbul",
                PhoneNumber = "sss",
                Photo = "sss",
                Email = "h@"

            });
            await _commercialActivityWriteRepository.AddAsync(new()
            {
                ServiceCharge = 33,
                ServiceName = "İş",
                CustomerId = 1,

            });
            await _commercialActivityWriteRepository.SaveAsync();
        }
    }
}

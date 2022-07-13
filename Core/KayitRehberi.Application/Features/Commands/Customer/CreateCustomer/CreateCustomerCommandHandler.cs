using KayitRehberi.Application.Managers;
using KayitRehberi.Application.Repositories;
using KayitRehberi.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayitRehberi.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;
        readonly RabbitMQPublisher _rabbitMQPublisher;

        public CreateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository, RabbitMQPublisher rabbitMQPublisher)
        {
            _customerWriteRepository = customerWriteRepository;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            _rabbitMQPublisher.Publish(new CustomerImageCreatedEvent()
            {
                ImageName = FileManager.GetUniqueNameAndSavePhotoToDisk(request.Photo)
            });



            await _customerWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                SurName = request.SurName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Photo=FileManager.GetUniqueNameAndSavePhotoToDisk(request.Photo)

            });
            await _customerWriteRepository.SaveAsync();
            return new CreateCustomerCommandResponse();
        }
    }
}

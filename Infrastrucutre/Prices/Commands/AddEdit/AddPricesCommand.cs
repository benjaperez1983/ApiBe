using AutoMapper;
using Infrastructure.Context;
using MediatR;
using Shared.Dtos;

namespace Application.Prices.Commands.AddEdit
{
    public class AddPricesCommand : IRequest<Guid>
    {
        public Root RootData { get; set; } 

        public AddPricesCommand(Root RootData)
        {
            this.RootData = RootData;
        }
    }

    internal class AddPricesCommandHandler : IRequestHandler<AddPricesCommand, Guid>
    {
        readonly IApiBEDbContext context;
        readonly IMapper mapper;
        public AddPricesCommandHandler(IApiBEDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(AddPricesCommand command, CancellationToken ct)
        {
            var identifier = Guid.NewGuid();
            var rootToInsert = mapper.Map<DomainModel.Entities.PricesHeader>(command.RootData);
            rootToInsert.created = DateTime.Now; 
            rootToInsert.guid = identifier;
            rootToInsert.pricesDetail = mapper.Map<List<DomainModel.Entities.PricesDetail>>(command.RootData.prices); 
            context.PricesHeader.Add(rootToInsert);
            await context.SaveChangesAsync(ct);

            return identifier;
        }
    }
}

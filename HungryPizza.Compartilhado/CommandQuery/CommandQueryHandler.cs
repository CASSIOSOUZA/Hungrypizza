using AutoMapper;

namespace HungryPizza.Compartilhado.CommandQuery
{
    public class CommandQueryHandler
    {
        public readonly IMapper _mapper;

        public CommandQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
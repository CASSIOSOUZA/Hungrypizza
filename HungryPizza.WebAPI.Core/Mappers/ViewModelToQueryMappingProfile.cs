using AutoMapper;
using HungryPizza.Compartilhado.Models;
using HungryPizza.Servico.Entities;
using HungryPizza.Servico.Queries.Pizza;
using HungryPizza.Servico.Queries.Request;
using HungryPizza.WebAPI.Core.ViewModels.Queries.Pizza;
using HungryPizza.WebAPI.Core.ViewModels.Queries.Request;

namespace HungryPizza.WebAPI.Core.Mappers
{
    public class ViewModelToQueryMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelToQueryMappingProfile"/> class.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        public ViewModelToQueryMappingProfile(AppSettings appSettings)
        {
            #region Pizza

            CreateMap<PizzaGetQueryVM, Pizza>();
            CreateMap<PizzaGetQueryVM, PizzaGetQuery>().ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            CreateMap<RequestGetQueryVM, RequestGetQuery>().ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            CreateMap<RequestHistoryQueryVM, RequestHistoryQuery>().ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));

            #endregion Pizza
        }
    }
}
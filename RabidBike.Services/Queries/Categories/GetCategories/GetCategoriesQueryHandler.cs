using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Categories.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoriesResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository,
                                            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriesResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CategoriesResponse>>(await _categoryRepository.GetCategories());
        }
    }
}

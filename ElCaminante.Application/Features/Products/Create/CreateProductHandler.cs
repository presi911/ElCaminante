using ElCaminante.Domain.Entities;
using ElCaminante.Infrastructure.Repositories;
using MediatR;

namespace ElCaminante.Application.Features.Products.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                AvailableStock = request.AvailableStock
            };

            var productId = await _productRepository.AddAsync(product);
            return productId;
        }
    }
}
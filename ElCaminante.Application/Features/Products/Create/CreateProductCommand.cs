using MediatR;

namespace ElCaminante.Application.Features.Products.Create
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int AvailableStock { get; set; }
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Material { get; set; } = string.Empty;
        public int ProductType { get; set; }
    }
}
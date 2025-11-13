using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElCaminante.Application.Features.Order.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public string ShoeModel { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public string DeliveryAddress { get; set; }
    }
}

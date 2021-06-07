using API.Dto;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private IConfiguration Config { get; }

        public ProductUrlResolver(IConfiguration config)
        {
            Config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
            => !string.IsNullOrWhiteSpace(source.PictureUrl) ? Config["ApiUrl"] + source.PictureUrl : null;
    }
}
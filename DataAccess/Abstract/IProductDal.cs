using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Bunu tanımlamayı unutma entitiesdeki oluşturduğun db için olan classların mutlaka dataaccess de interface'i olması gerekir
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();

    }
}

// Code Refactoring
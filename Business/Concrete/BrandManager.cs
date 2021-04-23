using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
           return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length>=2 && brand.BrandName.Length<=10)
            {
                Console.WriteLine("eklendi");
                _brandDal.Update(brand);
            }
            else
            {
                Console.WriteLine("HATA");
            }
           
            
        }
    

       
    }
}

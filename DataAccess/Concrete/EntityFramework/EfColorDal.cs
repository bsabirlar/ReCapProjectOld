using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
                
        }

        public Color Get(Expression<Func<Color, bool>> filter = null)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {

                return context.Set<Color>().SingleOrDefault(filter);
            }

        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                return filter == null 
                    ? context.Set<Color>().ToList() 
                    : context.Set<Color>().Where(filter).ToList();

            }

            
        }

        public void Update(Color entity)
        {
            using (CarReCapDbContext context = new CarReCapDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}

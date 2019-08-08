using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using AutoMapper;
using MVC.Budget.DataAccess.Model;

namespace Repositories
{
    public class OperationTypeRepo : IOperationTypeRepo<OperationTypeDto>
    {
        public int Add(OperationTypeDto item)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toAdd = Mapper.Map<OperationTypeDto, OperationType>(item);
                context.OperationTypes.Add(toAdd);
                context.SaveChanges();

                return toAdd.Id;
            }
        }
        public List<OperationTypeDto> All()
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<OperationType> fromDb = context.OperationTypes.ToList();
                return Mapper.Map<List<OperationType>, List<OperationTypeDto>>(fromDb);
            }
        }
        public bool Delete(int id)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toDelete = context.OperationTypes.FirstOrDefault(d => d.Id == id);
                if (toDelete == null)
                {
                    return false;
                }

                context.OperationTypes.Remove(toDelete);
                context.SaveChanges();
                return true;
            }
        }
        public OperationTypeDto Get(int i)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toGet = context.OperationTypes.FirstOrDefault(d => d.Id == i);
                if (toGet == null)
                {
                    return null;
                }
                return Mapper.Map<OperationType, OperationTypeDto>(toGet);
            }
        }
        public void Update(OperationTypeDto t)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toUpdate = Mapper.Map<OperationTypeDto, OperationType>(t);

                context.OperationTypes.Attach(toUpdate);
                context.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

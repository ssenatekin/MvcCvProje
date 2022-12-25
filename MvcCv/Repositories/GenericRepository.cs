using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI.WebControls;

namespace MvcCv.Repositories
{
    //T değeri gönderilen sınıflar, where t ->sınıf olmalı,sınıfın özelliklerini alsın
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            //T den gelen değeri liste olarak döndür
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            //parametreden gelen değeri ekle.
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            //p den gelen değeri kaldır
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        //id ye göre getirme işlemi, t türünde olduğu ve int olduğu için return olcak
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        //t türünde find adında bulma metotu
        public T Find(Expression<Func<T,bool>> where)
        {
            //where den gelen şarta göre değer getir
            return db.Set<T>().FirstOrDefault(where);
       
        }

    }
}
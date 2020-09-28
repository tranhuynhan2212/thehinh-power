using DatatableHelper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Service.Interfaces
{
    public interface IBaseService<T, H, K> where T: class where H : class
    {
        ResponseData GetAllData(RequestData requestData, params Expression<Func<T, object>>[] includeProperties);

        ResponseData GetAllDataWithPaging(RequestData requestData, params Expression<Func<T, object>>[] includeProperties);

        ResponseData GetAllDataWithPagingAndCustomFilter(RequestData requestData, Expression<Func<T, bool>> customFilter, params Expression<Func<T, object>>[] includeProperties);

        ResponseHandle Add(H viewModel);

        ResponseHandle Update(H viewModel);

        ResponseHandle Delete(K id);

        List<H> GetAll(params Expression<Func<T, object>>[] includeProperties);

        List<H> GetAllByFilter(Expression<Func<T, bool>> filter);

        H GetById(K id, params Expression<Func<T, object>>[] includeProperties);

        Expression<Func<T, bool>> CreateExpression(string propertyName, object value);
    }
}

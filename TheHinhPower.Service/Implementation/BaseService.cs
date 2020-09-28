using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatatableHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TheHinhPower.Infrastructure;
using TheHinhPower.Infrastructure.Interfaces;
using TheHinhPower.Infrastructure.SharedKernel;
using TheHinhPower.Service.Interfaces;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Service.Implementation
{
    public class BaseService<T, H, K> : IBaseService<T, H, K> where T : DomainEntity<K> where H : BaseViewModel<K>
    {
        private IRepository<T, K> _repository;
        private IUnitOfWork _unitOfWork;

        public BaseService(IRepository<T, K> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public ResponseHandle Add(H viewModel)
        {
            try
            {
                //Map từ viewModel to entity
                var model = Mapper.Map<H, T>(viewModel);
                _repository.Add(model);
                // save change lại để lưu trên server
                _unitOfWork.Commit();
                viewModel.Id = model.Id;
                return new ResponseHandle(true, "", viewModel);
            }
            catch(Exception ex)
            {
                return new ResponseHandle(false, ex.Message, null);
            }
        }
        public ResponseHandle Update(H viewModel)
        {
            try
            {
                var model = Mapper.Map<H, T>(viewModel);
                _repository.Update(model);
                _unitOfWork.Commit();
                return new ResponseHandle(true, "", viewModel);
            }
            catch (Exception e)
            {
                return new ResponseHandle(false, e.Message, null);
            }
        }
        public ResponseHandle Delete(K id)
        {
            try
            {
                _repository.Remove(id);
                _unitOfWork.Commit();
                return new ResponseHandle(true, "", id);
            }
            catch (Exception e)
            {
                return new ResponseHandle(false, e.Message, "");
            }
        }
        public Expression<Func<T, bool>> CreateExpression(string propertyName, object value)
        {
            MethodInfo method = typeof(T).GetProperty(propertyName).GetMethod;
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            MemberExpression member = Expression.Property(param, method);
            var constant = Expression.Convert(Expression.Constant(value), member.Type);
            var exp = Expression.Equal(member, Expression.Convert(Expression.Constant(value), member.Type));
            return Expression.Lambda<Func<T, bool>>(exp, param);
        }
        public H GetById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return Mapper.Map<T, H>(_repository.FindById(id, includeProperties));
        }
        public List<H> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            return Mapper.Map<List<T>, List<H>>(_repository.FindAll(includeProperties).ToList());
        }

        public List<H> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            return _repository.FindAll().Where(filter).ProjectTo<H>().ToList();
        }

        public ResponseData GetAllData(RequestData requestData, params Expression<Func<T, object>>[] includeProperties)
        {
            var expressionSearch = ExpressionHelper.CreateFilterExpression<T>(requestData.SearchValues);
            var iData = _repository.FindAllAsync(expressionSearch, includeProperties).Result.AsQueryable();
            var data = iData.OrderBy(requestData.SortValue).ToList();
            var dataViewModel = Mapper.Map<List<T>, List<H>>(data);
            return new ResponseData(requestData.Draw, iData.Count(), iData.Count(), dataViewModel);
        }

        public ResponseData GetAllDataWithPaging(RequestData requestData, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public ResponseData GetAllDataWithPagingAndCustomFilter(RequestData requestData, Expression<Func<T, bool>> customFilter, params Expression<Func<T, object>>[] includeProperties)
        {
            var expressionSearch = ExpressionHelper.CreateFilterExpression<T>(requestData.SearchValues);
            var iData = _repository.FindAllWithPaging(expressionSearch, includeProperties).Where(customFilter);
            var data = iData.Skip(requestData.Start).Take(requestData.Length).OrderBy(requestData.SortValue).ToList();
            var dataViewModel = Mapper.Map<List<T>, List<H>>(data);
            return new ResponseData(requestData.Draw, iData.Count(), iData.Count(), dataViewModel);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple.Entities;
using Purple.DAL;
using System.Transactions;
using Purple.DAL.UnitOfWork;

using AutoMapper;

namespace Purple.Business
{
    public class PropertyBusiness : IPropertyBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public PropertyBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }


        public Property GetPropertyById(int propertyId)
        {
            var property = _unitOfWork.PropertyRepository.GetByID(propertyId);
            if (property != null)
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<tblProperty, Property>(); });
                var propertyModel = Mapper.Map<tblProperty, Property>(property);
                return propertyModel;
            }
            return null;
        }


        public int CreateProperty(Property property)
        {
            using (var scope = new TransactionScope())
            {
                var newproperty = new tblProperty
                {
                    Description = property.Description,
                    Price = property.Price,
                    IsSold = property.IsSold
                };

                _unitOfWork.PropertyRepository.Insert(newproperty);
                _unitOfWork.Save();
                scope.Complete();
                return newproperty.PropertyID;

            }
        }
      


        /// <summary>
        /// _property : contains new values, 
        ///  property : is the updated record, as properties are saved from parameter object
        /// </summary>
        /// <param name="_property"></param>
        /// <returns></returns>
        public bool UpdateProperty(Property _property)
        {

            var success = false;
            if (_property != null)
            {
                using (var scope = new TransactionScope())
                {
                    var property = _unitOfWork.PropertyRepository.GetByID(_property.PropertyID);
                    if (property != null)
                    {
                        property.Description = _property.Description;
                        property.Price = _property.Price;
                        property.IsSold = _property.IsSold;

                        _unitOfWork.PropertyRepository.Update(property);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }



        public bool DeleteProperty(int propertyId)
        {
            var success = false;
            if (propertyId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var property = _unitOfWork.PropertyRepository.GetByID(propertyId);
                    if (property != null)
                    {
                        _unitOfWork.PropertyRepository.Delete(property);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;

        }

        public IEnumerable<Property> GetAllProperties()
        {
            var properties = _unitOfWork.PropertyRepository.GetAll().ToList();
            if (properties.Any())
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<tblProperty, Property>(); });
                var propertiesModel = Mapper.Map<List<tblProperty>, List<Property>>(properties);           
                
                return propertiesModel;
            }
            return null;

        }
    }
}

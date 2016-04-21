using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purple.Entities;

namespace Purple.Business
{
    public interface IPropertyBusiness
    {
        Property GetPropertyById(int propertyId);
        IEnumerable<Property> GetAllProperties();
        int CreateProperty(Property property);
        bool UpdateProperty(Property property);
        bool DeleteProperty(int propertyId);
    }
}

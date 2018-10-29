using Domain1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain1.Abstract
{
    public interface IOrderProcessor
    {
        void Processor(Cart cart, ShoppingDetails shoppingDetails);
    }
}

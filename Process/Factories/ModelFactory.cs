using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Process.Models;

namespace Process.Factories
{
    public class ModelFactory
    {
        public ModelFactory()
        {

        }

        public DomainModel Create(Domain domain)
        {
            return new DomainModel
            {
                name = domain.name

            };
        }

        public SessionModel Create(Session session)
        {
            return new SessionModel
            {
                status = session.status,
                ticket = session.ticket
            };
        }

        public UserModel Create(User user)
        {
            return new UserModel
            {
                username = user.username,
                password = user.password,
                domain = Create(user.domain)
            };
        }

        public UserModel Create(string[] array)
        {
            return new UserModel
            {
                username = array[0],
                password = array[1],
                domain = new DomainModel
                {
                    name = array[2]
                }
            };
        }

        public BasketModel Create(Basket basket)
        {
            return new BasketModel
            {
                type = basket.pType,
                from = basket.pFrom,
                docNumber = basket.pNudoc,
                wfParent = basket.pWfp,
                wfChild = basket.pWfa,
                dateStart = basket.pFrom_date,
                dateEnd = basket.pTo_date,
                detail = basket.pDetail
            };
        }
    }
}
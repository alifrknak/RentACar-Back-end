using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramewrok
{
	public class EfUserDal : EfRepositroyBase<User, RentContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context = new  RentContext())
			{
				var result = from operationClaim in context.OperationClaims
							 join userOperationClaim in context.UserOperationClaims
								 on operationClaim.Id equals userOperationClaim.OperationClaimId
					 where user.Id == userOperationClaim.UserId
			 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

				return result.ToList();
			}
		}
	}
}

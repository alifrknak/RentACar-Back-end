﻿using Businees.Concrete;
using DataAccess.Concrete.EntityFramewrok;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Cryptography;

namespace Car 
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager a = new UserManager(new EfUserDal());

           var fc= a.GetByMail("fun2@gmail.com");

            if (fc==null)
            {
                Console.WriteLine("!!");
            }
            else
            {
                Console.WriteLine("var  +"+fc.Last_name);
            }
		}
	}
}
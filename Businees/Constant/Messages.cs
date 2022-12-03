using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Businees.Constant
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInValid = "ürün ismi geçersiz";
        public static string Maintenancetime = "Zaman aşımı sistem bakımda.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserAlreadyExists = "kullanıcı zaten var";
        public static string UserRegistered = "kullanıcı kaydoldu";
        public static string EmailIsUsing = "e posta baska biri tarafından kullanılıyor";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "sifre hathalı";
		public static string SuccessfulLogin = "giriş başarılı";
        public static string AccessTokencreate = "access token oluşturuldu";
	}
}

﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages : IMessages
    {
        public static string BrandAdded = "Marka Eklendi";
        public static string CarAdded = "Araba Eklendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string RentalAdded = "Araba Kiralandı";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string BrandNameInvalid = "Marka Adı En Az 2 Karakter İçermelidir";
        public static string CarNameInvalid = "Araba Adı En Az 3 Karakter İçermelidir";
        public static string ColorNameInvalid = "Renk Adı En Az 2 Karakter İçermelidir";
        public static string DailyPriceInvalid = "Günlük Kiralama Ücreti 0'dan Büyük Olmalıdır";
        public static string RentalAddingFailed = "Kiralama İşlemi Başarısız";
        public static string BrandDeleted = "Marka Silindi";
        public static string CarDeleted = "Araba Silindi";
        public static string ColorDeleted = "Renk Silindi";
        public static string RentalDeleted = "Kiralama Bilgisi Silindi";
        public static string CustomerDeleted = "Kullanıcı Silindi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string Updated = "Bilgiler Güncellendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ImageUploaded = "Resim Başarıyla Yüklendi";
        public static string ImageDeleted = "Resim Silindi";
        public static string ImageUpdated = "Resim Güncellendi";
        public static string AuthorizationDenied = "Erişim Yetkiniz Yok";
        public static string UserRegistered = "Kayıt Başarılı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated = "Access Token Üretildi";
    }
}

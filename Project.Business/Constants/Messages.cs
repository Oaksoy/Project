
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string StudentNameSurnameExist="Aynı isim soyisimle öğrenci bulunmaktadır. Lütfen başka isim soyisim giriniz";

        public static string StudentAdded = "Öğrenci Eklendi";

        public static string StudentUpdated= "Öğrenci Güncellendi";

        public static string StudentDeleted = "Öğrenci Silindi";

        public static string YearOfRegistrationDateLowerThanThisYear = "Geçmiş Yıla Öğrenci Kaydedilemez";

        public static string StudentsListed = "Öğrenciler Listelendi";

        public static string CourseAdded = "Ders Eklendi";
        public static string CoursesListed = "Dersler Listelendi";
        public static string CourseUpdated = "Ders Güncellendi.";
    }
}

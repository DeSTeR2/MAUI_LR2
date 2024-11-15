using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public static class Translator
    {
        static Dictionary<string, string> translations = new Dictionary<string, string> {
            {"Name", "Ім'я"},
            {"Department", "Департамент"},
            {"DepartmentSection", "Сексія департамента"},
            {"Position", "Позиція"},
            {"Salary", "Заробітня плата"},
            {"Duration", "Досвід роботи"},
            {"Ім'я", "Name"},
            {"Департамент", "Department"},
            {"Сексія департамента", "DepartmentSection"},
            {"Позиція", "Position"},
            {"Заробітня плата", "Salary"},
            {"Досвід роботи", "Duration"}
        };

        public static string GetTranslation(string name)
        {
            if (translations.ContainsKey(name)) return translations[name];
            return "";
        }
    }
}
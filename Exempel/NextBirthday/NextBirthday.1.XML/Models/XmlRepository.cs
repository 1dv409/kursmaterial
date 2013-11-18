using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NextBirthday.Models
{
    public class XmlRepository
    {
        private static readonly string PhysicalPath;

        private XDocument _document;

        private XDocument Document
        {
            get
            {
                return _document ?? (_document = XDocument.Load(PhysicalPath));
            }
        }

        static XmlRepository()
        {
            PhysicalPath = HttpContext.Current.Server.MapPath("~/App_Data/Birthdates.xml");
        }

        public List<Birthday> GetBirthdays()
        {
            return (from birthdate in Document.Descendants("birthdate")
                    select new Birthday
                    {
                        Name = birthdate.Element("name").Value,
                        Birthdate = DateTime.Parse(birthdate.Element("date").Value)
                    }).OrderBy(b => b.DaysUntilNextBirthday).ToList();
        }

        public void InsertBirthday(Birthday birthday)
        {
            Document.Root.Add(
                new XElement("birthdate",
                    new XElement("name", birthday.Name),
                    new XElement("date", birthday.Birthdate)));
        }

        public void Save()
        {
            Document.Save(PhysicalPath);
        }
    }
}
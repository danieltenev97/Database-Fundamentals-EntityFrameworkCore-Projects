namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners.Where(x => ids.Contains(x.Id) == true)
                .OrderBy(x => x.FullName).ThenBy(x => x.Id)
                .Select(x => new
                {
                    x.Id,
                    Name = x.FullName,
                    x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(e => new
                    {
                        OfficerName = e.Officer.FullName,
                        Department = e.Officer.Department.Name
                    }).OrderBy(e => e.OfficerName).ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(e => e.Officer.Salary)
                }).ToArray();

            var jsonPrisoner = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);

            return jsonPrisoner;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var Names = prisonersNames.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var prisoners = context.Prisoners
                .Where(x => Names.Contains(x.FullName) == true)
                .OrderBy(x => x.FullName).ThenBy(x => x.Id)
                .Select(x => new PrisonersExportDto()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture),
                    mailDtos = x.Mails.Select(e => new MailDto()
                    {
                        Description = ReverseString(e.Description)

                    }).ToArray()
                }).ToArray();


            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(PrisonersExportDto[]), new XmlRootAttribute("Prisoners"));
            serializer.Serialize(new StringWriter(sb), prisoners, xmlNamespaces);

            return sb.ToString();
        }

        private static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
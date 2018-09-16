namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departments = JsonConvert.DeserializeObject<DepartmentsDto[]>(jsonString);
            StringBuilder messages = new StringBuilder();
            List<Department> departmentsToBeAdded = new List<Department>();
            List<Cell> cellsToBeAdded = new List<Cell>();
             
            foreach (var department in departments)
            {
                List<Cell> cells = new List<Cell>();

                var currentDepartment = new Department()
                {
                    Name = department.Name,
                };


                bool isValid = IsValid(currentDepartment);
                bool isCellValid = true;
             
                if(isValid==false)
                {
                    messages.AppendLine("Invalid Data");
                    continue;
                }

                foreach (var item in department.Cells)
                {
                    var cell = new Cell()
                    {
                        CellNumber = item.CellNumber,
                        HasWindow = item.hasWindow,
                        Department=currentDepartment
                        
                    };

                    
                    isCellValid = IsValid(cell);

                    if (!isCellValid)
                    {

                        break;
                    }
                    

                   
                  
                    cellsToBeAdded.Add(cell);
                    cells.Add(cell);
               
                }

                if (!isCellValid)
                {
                    messages.AppendLine("Invalid Data");
                    continue;
                }

            

             

                messages.AppendLine($"Imported {department.Name} with {cells.Count} cells");
                departmentsToBeAdded.Add(currentDepartment);
            }
           
            context.Departments.AddRange(departmentsToBeAdded);
            context.SaveChanges();

            context.Cells.AddRange(cellsToBeAdded);
            context.SaveChanges();

          

            return messages.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisoners = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);
            StringBuilder messages = new StringBuilder();
            List<Prisoner> prisonersTobeAdded = new List<Prisoner>();
            List<Mail> mailsTobeAdded = new List<Mail>();


            foreach (var prisoner in prisoners)
            {

                DateTime? releaseDate;
                var incDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
               

                if (prisoner.ReleaseDate == null)
                {
                    releaseDate = null;
                }

                else
                {
                    releaseDate = DateTime.ParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
              
                var currentprisoner = new Prisoner();

                bool isvalid = IsValid(prisoner);

                if (!isvalid)
                {
                    messages.AppendLine("Invalid Data");
                    continue;
                }

                currentprisoner = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incDate,
                    ReleaseDate = releaseDate,
                    Bail =prisoner.Bail,
                    CellId = prisoner.CellId

                };

             
                var mails = prisoner.Mails;
                bool validMails = true;
                List<Mail> mailS = new List<Mail>();

                foreach (var item in mails)
                {

                    var currentMail = new Mail()
                    {
                        Description = item.Description,
                        Sender = item.Sender,
                        Address = item.Address,
                      

                    };
                  
                    validMails = IsValid(currentMail);

                    if(!validMails)
                    {
                        break;
                    }

                    currentMail.Prisoner = currentprisoner;
                    mailS.Add(currentMail);
                }

                if(!validMails)
                {
                    messages.AppendLine("Invalid Data");
                    continue;
                }

                mailsTobeAdded.AddRange(mailS);

          
                prisonersTobeAdded.Add(currentprisoner);
                messages.AppendLine($"Imported {currentprisoner.FullName} {currentprisoner.Age} years old");
            }
            ;
            context.Prisoners.AddRange(prisonersTobeAdded);
            context.SaveChanges();
            context.Mails.AddRange(mailsTobeAdded);
            context.SaveChanges();
      
            
            
            return messages.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
          
            StringBuilder messages = new StringBuilder();
            List<Officer> officers = new List<Officer>();
            List<OfficerPrisoner> officerPrisoners = new List<OfficerPrisoner>();
            
            var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));

            var deserializedOfficers =(OfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var officer in deserializedOfficers)
            {
                bool validofficer = IsValid(officer);
                 if(!validofficer)
                {
                    messages.AppendLine("Invalid Data");
                    continue;
                }
                Position position;
                Weapon weapon;
                try
                {
                     position = (Position)Enum.Parse(typeof(Position), officer.Position);
                     weapon = (Weapon)Enum.Parse(typeof(Weapon), officer.Weapon);

                }
                catch
                {
                    messages.AppendLine("Invalid Data");
                    continue;
                }
            
                var currentOfficer = new Officer()
                {
                    FullName=officer.FullName,
                    Salary=officer.Salary,
                    Position=position,
                    Weapon=weapon,
                    DepartmentId=officer.DepartmentId
                };


                 foreach (var prisoner in officer.PrisonerDtos)
                {
                    int id = prisoner.PrisonerId;
                    var currentPrisoner = context.Prisoners.FirstOrDefault(x => x.Id == id);

                    if(currentPrisoner==null)
                    {
                        validofficer = false;
                        break;
                    }

                    var currentOfficersPrisoners = new OfficerPrisoner()
                    {
                        Officer=currentOfficer,
                        Prisoner=currentPrisoner
                    };
                    officerPrisoners.Add(currentOfficersPrisoners);
                }
                if (!validofficer)
                {
                    messages.AppendLine("Invalid Data");
                    continue;
                }

                officers.Add(currentOfficer);
                messages.AppendLine($"Imported {officer.FullName} ({officer.PrisonerDtos.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();
            context.OfficersPrisoners.AddRange(officerPrisoners);
            context.SaveChanges();


            return messages.ToString().TrimEnd();
        }


        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }

    }
}
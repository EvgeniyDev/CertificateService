﻿using System;

namespace CertificateService.Web.API.Core.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentTicketNumber { get; set; }
        public DateTime StudentTicketDateOfIssue { get; set; }
        public DateTime StudentTicketDateOfExpiry { get; set; }
        public int GroupId { get; set; }
    }
}

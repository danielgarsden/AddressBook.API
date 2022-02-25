﻿using AddressBook.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace AddressBook.UI.Pages
{
    partial class AddressDetails
    {
        [Parameter]
        public string AddressID { get; set; }

        public AddressDto Address { get; set; } = new AddressDto();

        public IEnumerable<AddressDto> Addresses { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitialiseAddresses();
            Address = Addresses.FirstOrDefault(a => a.AddressId == int.Parse(AddressID));
            return base.OnInitializedAsync();
        }

        public void InitialiseAddresses()
        {
            Addresses = new List<AddressDto>()
            {
                new AddressDto { AddressId = 1, FirstName = "Donovan", LastName = "Richards", AddressLine1 = "985-833 Nec St.", AddressLine2 = "5764 Sed Avenue", AddressLine3 = "P.O. Box 758, 8826 Elit, Rd.", City = "Albi", PostCode = "340233", LandLineNumber = "07063173681", MobileNumber = "016977 8268" },
                new AddressDto { AddressId = 2, FirstName = "Carson", LastName = "Hodges", AddressLine1 = "664-4638 In Ave", AddressLine2 = "605-2745 Neque. Street", AddressLine3 = "591-3519 Euismod Ave", City = "Dieppe", PostCode = "7392 RN", LandLineNumber = "08454642", MobileNumber = "09453373485" },
                new AddressDto { AddressId = 3, FirstName = "Chaim", LastName = "Wise", AddressLine1 = "Ap #492-630 Magnis Rd.", AddressLine2 = "P.O. Box 866, 2469 Lectus Rd.", AddressLine3 = "8578 Nullam St.", City = "Dworp", PostCode = "6208 UT", LandLineNumber = "07404768240", MobileNumber = "07624903289" },
                new AddressDto { AddressId = 4, FirstName = "Russell", LastName = "Raymond", AddressLine1 = "5466 Ipsum. Ave", AddressLine2 = "245-6617 Nec, St.", AddressLine3 = "6634 Natoque Road", City = "Pakpatan", PostCode = "233571", LandLineNumber = "07099169730", MobileNumber = "01715990221" },
                new AddressDto { AddressId = 5, FirstName = "Lionel", LastName = "Vinson", AddressLine1 = "6574 Morbi St.", AddressLine2 = "153-2462 Metus. St.", AddressLine3 = "3768 Donec St.", City = "Khanewal", PostCode = "450162", LandLineNumber = "07028594797", MobileNumber = "0252749 5696" },
                new AddressDto { AddressId = 6, FirstName = "Chadwick", LastName = "Watts", AddressLine1 = "P.O. Box 102, 4495 Pede Rd.", AddressLine2 = "P.O. Box 569, 9405 At, Rd.", AddressLine3 = "7355 Pulvinar St.", City = "Ergani", PostCode = "Z2200", LandLineNumber = "08934848872", MobileNumber = "09277225860" },
                new AddressDto { AddressId = 7, FirstName = "Henry", LastName = "Pickett", AddressLine1 = "P.O. Box 838, 3021 Bibendum Rd.", AddressLine2 = "608-7007 Arcu. Ave", AddressLine3 = "Ap #393-2002 In Ave", City = "Villenave-d'Ornon", PostCode = "31207", LandLineNumber = "01052892190", MobileNumber = "05542645886" },
                new AddressDto { AddressId = 8, FirstName = "Otto", LastName = "Pope", AddressLine1 = "897-4991 Turpis Av.", AddressLine2 = "P.O. Box 272, 9214 Tempus, Rd.", AddressLine3 = "P.O. Box 687, 4093 Placerat. Street", City = "Rotheux-RimiŽre", PostCode = "34216", LandLineNumber = "01811303688", MobileNumber = "07694881089" },
                new AddressDto { AddressId = 9, FirstName = "Noah", LastName = "Hartman", AddressLine1 = "Ap #812-8930 Augue Avenue", AddressLine2 = "1066 Facilisis Street", AddressLine3 = "2597 Ac, Ave", City = "Geertruidenberg", PostCode = "72744-440", LandLineNumber = "07624466343", MobileNumber = "01771165803" },
                new AddressDto { AddressId = 10, FirstName = "Clarke", LastName = "Bryant", AddressLine1 = "104-2284 Mi St.", AddressLine2 = "Ap #853-8214 Feugiat Rd.", AddressLine3 = "P.O. Box 645, 7213 Tristique Rd.", City = "Limena", PostCode = "992804", LandLineNumber = "0800786717", MobileNumber = "070 4820 2574" }
            };
        }
    }
}

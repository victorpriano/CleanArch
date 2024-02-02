﻿using System.Text.Json.Serialization;
using CleanArch.Domain.Validations;

namespace CleanArch.Domain.Entities;

public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    
    public string? LastName  { get; private set; }

    public string? Gender { get; private set; }

    public string? Email { get; private set; }

    public bool? IsActive { get; private set; }

    public Member(string firstName, string lastName, string gender, string email, bool active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }
    
    public Member(){}
    
    [JsonConstructor]
    public Member(int id, string firstName, string lastName, string gender, string email, bool active)
    {
        DomainValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    public void Update(string firstName, string lastName, string gender, string email, bool active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }
    
    private void ValidateDomain(string firstname, string lastname, string gender, 
        string email, bool? active)
    {
        DomainValidation.When(string.IsNullOrEmpty(firstname),
            "Invalid name. FirstName is required");

        DomainValidation.When(firstname.Length < 3,
            "Invalid name, too short, minimum 3 characters");

        DomainValidation.When(string.IsNullOrEmpty(lastname),
            "Invalid lastname. LastName is required");

        DomainValidation.When(lastname.Length < 3,
            "Invalid lastname, too short, minimum 3 characters");

        DomainValidation.When(email?.Length > 250,
            "Invalid email, too long, maximum 250 characters");

        DomainValidation.When(email?.Length < 6,
            "Invalid email, too short, minimum 6 characters");

        DomainValidation.When(string.IsNullOrEmpty(gender),
            "Invalid gender, Gender is required");

        DomainValidation.When(!active.HasValue,
            "Must define activity");

        FirstName = firstname;
        LastName = lastname;
        Gender = gender;
        Email = email;
        IsActive = active;
    }
}
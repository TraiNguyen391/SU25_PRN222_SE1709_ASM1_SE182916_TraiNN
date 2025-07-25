﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolMedical.Repository.TraiNN.Models;

public partial class MedicationTraiNn
{
    public int MedicationTraiNNid { get; set; }

    [Display(Name = "Dongui ID")]
    [Range(1, int.MaxValue, ErrorMessage = "Dongui ID must be a positive integer")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Dongui ID must be a valid number")]
    public int? DonguiId { get; set; }

    [Required(ErrorMessage = "Medicine name is required")]
    [StringLength(50, ErrorMessage = "Medicine name cannot exceed 50 characters")]
    [Display(Name = "Medicine Name")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Medicine name can only contain letters and spaces")]
    public string MedicineName { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
    [Display(Name = "Quantity")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Quantity must be a valid number")]
    public int? Quantity { get; set; }

    [Required(ErrorMessage = "Unit is required")]
    [StringLength(20, ErrorMessage = "Unit cannot exceed 20 characters")]
    [Display(Name = "Unit")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Unit can only contain letters and spaces")]
    public string Unit { get; set; }

    [Required(ErrorMessage = "Type is required")]
    [StringLength(50, ErrorMessage = "Note cannot exceed 50 characters")]
    [Display(Name = "Type")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Type can only contain letters and spaces")]
    public string Type { get; set; }

    //[Required(ErrorMessage = "Status is required")]
    [Display(Name = "Status")]
    [RegularExpression(@"^(true|false)$", ErrorMessage = "Status must be true or false")]
    public bool? Status { get; set; }

    [Display(Name = "Parent Note")]
    [StringLength(200, ErrorMessage = "Parent note cannot exceed 200 characters")]
    [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Parent note can only contain letters, numbers, spaces, and punctuation")]
    [Required(ErrorMessage = "Parent note is required")]
    public string ParentNote { get; set; }

    [Display(Name = "Nurse Note")]
    [StringLength(200, ErrorMessage = "Nurse note cannot exceed 200 characters")]
    [RegularExpression(@"^[a-zA-Z0-9\s.,!?]+$", ErrorMessage = "Nurse note can only contain letters, numbers, spaces, and punctuation")]
    [Required(ErrorMessage = "Nurse note is required")]
    public string NurseNote { get; set; }

    [Display(Name = "Receive Date")]
    [DataType(DataType.Date)]
    //[RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Receive date must be in the format YYYY-MM-DD")]
    [Required(ErrorMessage = "Receive date is required")]
    public DateTime? ReceiveDate { get; set; }

    public virtual MedicationOrderTraiNn Dongui { get; set; }
}
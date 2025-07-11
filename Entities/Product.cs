﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities;

[Table("Product")]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    public int? CategoryId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProductName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Description { get; set; }

    public int? Price { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
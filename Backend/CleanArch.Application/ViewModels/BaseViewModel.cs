using CleanArch.Domain.Entities;
using CleanArch.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CleanArch.Domain.Common;
using System;

namespace CleanArch.Application.ViewModels
{
    public abstract class BaseViewModel<TKey> 
    {
        public TKey Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }


}

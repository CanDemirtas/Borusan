using CleanArch.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class MaterialViewModel : BaseViewModel<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }

    }
}

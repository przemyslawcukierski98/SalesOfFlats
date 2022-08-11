using Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateFlatDtoValidator : AbstractValidator<CreateFlatDto>
    {
        public CreateFlatDtoValidator()
        {
            #region Title
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is empty.");
            RuleFor(x => x.Title).Length(0, 200).WithMessage("Title must be not longer than 200 characters");
            #endregion

            #region Description
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is empty.");
            RuleFor(x => x.Description).Length(0, 1000).WithMessage("Description must be not longer than 1000 characters");
            #endregion

            #region Area
            RuleFor(x => x.Area).Must(x => x > 0).WithMessage("Area must be greater than zero");
            #endregion

            #region NumberOfRooms
            RuleFor(x => x.NumberOfRooms).Must(x => x > 0).WithMessage("Number of rooms must be greater than zero");
            #endregion

            #region Price
            RuleFor(x => x.Price).Must(x => x > 0).WithMessage("Price must be greater than zero");
            #endregion
        }
    }
}

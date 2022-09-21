
using FluentValidation;

namespace PayCore.ProductCatalog.Service.Dto_Validator
{
    class ColorDtoValidator:AbstractValidator<ColorUpsertDto>
    {
        public ColorDtoValidator()
        {
            RuleFor(x => x.ColorName).NotEmpty().WithMessage("Color can not be null");
        }
    }
}

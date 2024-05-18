using FluentValidation;

namespace Identity.Requests;


internal sealed record TwoFactorRequest(
    bool? Enable,
    string? TwoFactorCode,
    bool ResetSharedKey = false,
    bool ResetRecoveryCodes = false,
    bool ForgetMachine = false)
{
    internal sealed class Validator : AbstractValidator<TwoFactorRequest>
    {
        public Validator() =>
            When(x => x.Enable == true, () =>
            {
                RuleFor(x => x.ResetSharedKey).Empty();
                RuleFor(x => x.TwoFactorCode).NotEmpty();
            });
    }
}
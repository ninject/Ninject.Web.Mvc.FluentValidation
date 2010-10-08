FluentValidation Ninject integration

To use follow these steps:

1. Wire up Asp.net MVC to use the NinjectValidatorFactory:

<code>
NinjectValidatorFactory ninjectValidatorFactory = new NinjectValidatorFactory(ninjectKernel);
ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(ninjectValidatorFactory));
DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
</code>

2. Add a module to your project that will bind all of your validators:

<code>
public class FluentValidatorModule : NinjectModule
{
	public override void Load()
	{
		AssemblyScanner.FindValidatorsInAssemblyContaining<UserValidator>()
			.ForEach(match => Bind(match.InterfaceType).To(match.ValidatorType));
    }
}
</code>

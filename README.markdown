FluentValidation Ninject integration

To use follow these steps:

1. Wire up Asp.net MVC to use the NinjectValidatorFactory:

```C#
NinjectValidatorFactory ninjectValidatorFactory = new NinjectValidatorFactory(ninjectKernel);
ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(ninjectValidatorFactory));
DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
```

2. Add a module to your project that will bind all of your validators:

```C#
public class FluentValidatorModule : NinjectModule
{
	public override void Load()
	{
		AssemblyScanner.FindValidatorsInAssemblyContaining<UserValidator>()
			.ForEach(match => Bind(match.InterfaceType).To(match.ValidatorType));
    }
}
```

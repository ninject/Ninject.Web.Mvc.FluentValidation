namespace Ninject.Web.Mvc.FluentValidation
{
    using System;
    using global::FluentValidation;

    /// <summary>
    /// Validation factory that uses ninject to create validators  
    /// </summary>
    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectValidatorFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectValidatorFactory(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        /// <summary>
        /// Gets or sets the kernel.
        /// </summary>
        /// <value>The kernel.</value>
        public IKernel Kernel { get; set; }

        /// <summary>
        /// Creates an instance of a validator with the given type using ninject.
        /// </summary>
        /// <param name="validatorType">Type of the validator.</param>
        /// <returns>The newly created validator</returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            return this.Kernel.Get(validatorType) as IValidator;
		}
	}
}

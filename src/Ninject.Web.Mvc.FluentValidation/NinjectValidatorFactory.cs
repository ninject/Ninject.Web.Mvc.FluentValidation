using System;
using FluentValidation;
using System.Linq;

namespace Ninject.Web.Mvc.FluentValidation
{
    /// <summary>
    /// Validation factory that uses ninject to create validators  
    /// </summary>
    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectValidatorFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectValidatorFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Creates an instance of a validator with the given type using ninject.
        /// </summary>
        /// <param name="validatorType">Type of the validator.</param>
        /// <returns>The newly created validator</returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            if (!_kernel.GetBindings(validatorType).Any())
            {
                return null;
            }

            return _kernel.Get(validatorType) as IValidator;
        }
    }
}

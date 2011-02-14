using System;
using System.Collections.Generic;
using FluentValidation;
using Ninject.Planning.Bindings;

namespace Ninject.Web.Mvc.FluentValidation
{
   /// <summary>
   /// Validation factory that uses ninject to create validators  
   /// </summary>
   public class NinjectValidatorFactory : ValidatorFactoryBase
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="NinjectValidatorFactory"/> class.
      /// </summary>
      /// <param name="kernel">The kernel.</param>
      public NinjectValidatorFactory( IKernel kernel )
      {
         Kernel = kernel;
      }

      /// <summary>
      /// Gets or sets the kernel.
      /// </summary>
      /// <value>The kernel.</value>
      public IKernel Kernel
      {
         get;
         set;
      }

      /// <summary>
      /// Creates an instance of a validator with the given type using ninject.
      /// </summary>
      /// <param name="validatorType">Type of the validator.</param>
      /// <returns>The newly created validator</returns>
      public override IValidator CreateInstance( Type validatorType )
      {
         if ( ((IList<IBinding>)Kernel.GetBindings(validatorType)).Count == 0 )
         {
            return null;
         }

         return Kernel.Get( validatorType ) as IValidator;
      }
   }
}
